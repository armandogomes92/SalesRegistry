using Xunit;
using FluentAssertions;
using NSubstitute;
using AutoMapper;
using Bogus;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Dtos;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Unit.Tests.Sales
{
    public class SalesFlowUnitTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        private readonly Faker _faker;
        private readonly Sale _fakeSale;
        private readonly List<SaleItemDto> _fakeSaleItems;

        public SalesFlowUnitTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _saleService = Substitute.For<ISaleService>();
            
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CreateSaleProfile>();
                cfg.AddProfile<UpdateSaleProfile>();
                cfg.CreateMap<SaleItemDto, SaleItem>().ReverseMap();
                cfg.CreateMap<CreateSaleCommand, Sale>();
                cfg.CreateMap<Sale, CreateSaleResult>();
            });
            
            _mapper = config.CreateMapper();
            _faker = new Faker();

            // Setup fake data
            _fakeSaleItems = new List<SaleItemDto> 
            {
                new SaleItemDto 
                {
                    ProductId = Guid.NewGuid(),
                    Quantity = _faker.Random.Number(1, 10),
                    UnitPrice = _faker.Random.Decimal(10, 100)
                }
            };

            _fakeSale = new Sale
            {
                Id = Guid.NewGuid(),
                SalesDate = DateTime.UtcNow,
                TotalOfSale = _fakeSaleItems.Sum(x => x.Quantity * x.UnitPrice),
                Customer = new Customer { Id = Guid.NewGuid() },
                Subsidiary = new Subsidiary { Id = Guid.NewGuid() },
                SaleItems = _mapper.Map<List<SaleItem>>(_fakeSaleItems)
            };
        }

        [Fact]
        public async Task Should_CreateSale_Successfully()
        {
            _saleRepository
                .CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(_fakeSale);

            var handler = new CreateSaleHandler(_saleRepository, _mapper, _saleService);
            var command = new CreateSaleCommand 
            {
                SalesDate = DateTime.Now,
                TotalOfSale = _fakeSale.TotalOfSale,
                CustomerId = _fakeSale.Customer.Id,
                SubsidiaryId = _fakeSale.Subsidiary.Id,
                SaleItems = _fakeSaleItems
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
            await _saleRepository
                .Received(1)
                .CreateAsync(Arg.Is<Sale>(s => 
                    s.Customer.Id == command.CustomerId && 
                    s.TotalOfSale == command.TotalOfSale
                ), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Should_ThrowException_WhenCreatingSaleWithInvalidData()
        {
            var handler = new CreateSaleHandler(_saleRepository, _mapper, _saleService);
            var invalidCommand = new CreateSaleCommand
            {
                SalesDate = DateTime.UtcNow,
                CustomerId = Guid.Empty,
                SubsidiaryId = Guid.Empty,
                SaleItems = new List<SaleItemDto>()
            };

            Func<Task> act = async () => await handler.Handle(invalidCommand, CancellationToken.None);

            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
            await _saleRepository
                .DidNotReceive()
                .CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Should_UpdateSale_Successfully()
        {
            var saleId = Guid.NewGuid();
            var updatedProducts = new List<string> { _faker.Commerce.ProductName() };
            
            _saleRepository.GetByIdAsync(saleId)
                .Returns(new Sale { Id = saleId });
            _saleRepository.UpdateAsync(Arg.Any<Sale>()).Returns(true);

            var handler = new UpdateSaleHandler(_saleRepository, _mapper, _saleService);
            var command = new UpdateSaleCommand
            {
                Id = saleId,
                SalesNumber = 1,
                SalesDate = DateTime.Now,
                CustomerId = Guid.NewGuid(),
                SubsidiaryId = Guid.NewGuid(),
                TotalOfSale = _fakeSale.TotalOfSale,
                SaleItems = _fakeSaleItems

            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Id.Should().Be(saleId);
            await _saleRepository.Received(1).UpdateAsync(Arg.Any<Sale>());
        }

        [Fact]
        public async Task Should_DeleteSale_Successfully()
        {
            var saleId = Guid.NewGuid();
            _saleRepository.DeleteAsync(saleId).Returns(true);

            var handler = new DeleteSaleHandler(_saleRepository);
            var command = new DeleteSaleCommand { SaleId = saleId };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsDeleted.Should().BeTrue();
            await _saleRepository.Received(1).DeleteAsync(saleId);
        }
    }
}