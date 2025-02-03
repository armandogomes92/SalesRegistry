using Xunit;
using FluentAssertions;
using NSubstitute;
using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Dtos;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using NSubstitute.ReceivedExtensions;
using Ambev.DeveloperEvaluation.Application.Events.Handlers;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Functional.Tests.Sales
{
    public class SalesFlowFunctionalTests : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Faker _faker;

        public SalesFlowFunctionalTests()
        {
            var services = new ServiceCollection();

            services.AddAutoMapper(typeof(CreateSaleProfile).Assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateSaleCommand).Assembly);
            });

            services.AddScoped<ISaleRepository>(sp =>
                NSubstitute.Substitute.For<ISaleRepository>());

            services.AddScoped<CreateSaleHandler>();
            services.AddScoped<GetSaleHandler>();

            services.AddLogging(configure => configure.AddConsole())
                    .AddTransient<SaleEventHandler>();

            _serviceProvider = services.BuildServiceProvider();
            _faker = new Faker();
        }

        [Fact]
        public async Task Should_ExecuteCompleteSalesFlow_Successfully()
        {
            var (mediator, saleRepository) = GetServices();
            var testData = CreateTestData();
            SetupRepositoryMocks(saleRepository, testData);

            var createResult = await ExecuteCreateSaleCommand(mediator, testData.CreateCommand);
            var getResult = await ExecuteGetSaleCommand(mediator, createResult.Id);

            ValidateTestResults(getResult, testData, saleRepository);
        }

        private (IMediator mediator, ISaleRepository saleRepository) GetServices()
        {
            return (
                _serviceProvider.GetRequiredService<IMediator>(),
                _serviceProvider.GetRequiredService<ISaleRepository>()
            );
        }

        private TestData CreateTestData()
        {
            var saleItems = new List<SaleItemDto>
            {
                new()
                {
                    ProductId = Guid.NewGuid(),
                    Quantity = _faker.Random.Number(1, 10),
                    UnitPrice = _faker.Random.Decimal(10, 100),
                    Discount = _faker.Random.Decimal(10, 100)
                }
            };

            var command = new CreateSaleCommand
            {
                SalesDate = DateTime.Now,
                TotalOfSale = saleItems.Sum(x => (x.UnitPrice * x.Quantity) - x.Discount), // Calcular TotalOfSale
                CustomerId = Guid.NewGuid(),
                SubsidiaryId = Guid.NewGuid(),
                SaleItems = saleItems,
                IsCanceled = false
            };

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SalesDate = command.SalesDate,
                TotalOfSale = command.TotalOfSale,
                Customer = new Customer { Id = command.CustomerId, ContractName = _faker.Person.FullName },
                Subsidiary = new Subsidiary { Id = command.SubsidiaryId, Name = _faker.Company.CompanyName() },
                IsCanceled = command.IsCanceled,
                SaleItems = command.SaleItems.Select(si => new SaleItem
                {
                    Id = Guid.NewGuid(),
                    Product = new Product { Id = si.ProductId },
                    Quantity = si.Quantity,
                    UnitPrice = si.UnitPrice,
                    Discount = si.Discount
                }).ToList()
            };

            return new TestData(command, sale, saleItems);
        }

        private void SetupRepositoryMocks(ISaleRepository saleRepository, TestData testData)
        {
            saleRepository
                .CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(testData.CreatedSale);

            saleRepository
                .GetByIdAsync(testData.CreatedSale.Id, Arg.Any<CancellationToken>())
                .Returns(testData.CreatedSale);

            saleRepository
                .GetAllAsync(Arg.Any<Guid?>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<CancellationToken>())
                .Returns(new List<Sale> { testData.CreatedSale });
        }

        private static async Task<CreateSaleResult> ExecuteCreateSaleCommand(
            IMediator mediator,
            CreateSaleCommand command)
        {
            var result = await mediator.Send(command);
            result.Should().NotBeNull();
            return result;
        }

        private static async Task<GetSaleResult> ExecuteGetSaleCommand(IMediator mediator, Guid saleId)
        {
            var results = await mediator.Send(new GetSaleCommand { SalesId = saleId, PageNumber = 1, PageSize = 1 });
            var result = results.FirstOrDefault();
            result.Should().NotBeNull();
            return result;
        }

        private static void ValidateTestResults(
            GetSaleResult getResult,
            TestData testData,
            ISaleRepository saleRepository)
        {
            getResult.Should().NotBeNull();
            getResult.Id.Should().Be(testData.CreatedSale.Id);
            getResult.TotalOfSale.Should().Be(testData.CreateCommand.TotalOfSale);
            getResult.Customer.Id.Should().Be(testData.CreateCommand.CustomerId);
            getResult.Subsidiary.Id.Should().Be(testData.CreateCommand.SubsidiaryId);
            getResult.IsCanceled.Should().Be(testData.CreateCommand.IsCanceled);

            getResult.SaleItems.Should().HaveCount(testData.SaleItems.Count);
            getResult.SaleItems.Should().BeEquivalentTo(testData.SaleItems,
                options => options.ComparingByMembers<SaleItemDto>()
                                  .Including(si => si.Discount)
                                  .Including(si => si.TotalAmount));

            saleRepository.Received(1)
                .CreateAsync(Arg.Is<Sale>(s =>
                    s.Customer.Id == testData.CreateCommand.CustomerId &&
                    s.Subsidiary.Id == testData.CreateCommand.SubsidiaryId &&
                    s.TotalOfSale == testData.CreateCommand.TotalOfSale
                ), Arg.Any<CancellationToken>());
        }

        private record TestData(
            CreateSaleCommand CreateCommand,
            Sale CreatedSale,
            List<SaleItemDto> SaleItems
        );

        public void Dispose()
        {
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
