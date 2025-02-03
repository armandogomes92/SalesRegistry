using Xunit;
using FluentAssertions;
using Bogus;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions.Execution;
using Ambev.DeveloperEvaluation.ORM;

namespace Ambev.DeveloperEvaluation.Integration.Tests.Sales
{
    public class SalesFlowIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly Faker _faker;

        public SalesFlowIntegrationTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _faker = new Faker();
        }

        [Fact]
        public async Task Should_CreateAndRetrieveSale_Successfully()
        {
            var sale = await _fixture.CreateSaleWithValidData();

            var created = await _fixture.SaleRepository.CreateAsync(sale);
            var retrieved = await _fixture.SaleRepository.GetByIdAsync(created.Id);

            using var assertion = new AssertionScope();
            retrieved.Should().NotBeNull();
            retrieved!.Id.Should().Be(created.Id);
            retrieved.TotalOfSale.Should().Be(sale.TotalOfSale);
            retrieved.Customer.Id.Should().Be(sale.Customer.Id);
            retrieved.SaleItems.Should().HaveCount(sale.SaleItems.Count);
        }

        [Fact]
        public async Task Should_NotRetrieveSale_WhenIdDoesNotExist()
        {
            var nonExistentId = Guid.NewGuid();

            var result = await _fixture.SaleRepository.GetByIdAsync(nonExistentId);

            result.Should().BeNull();
        }
    }

    public class DatabaseFixture : IAsyncLifetime
    {
        public DefaultContext Context { get; }
        public ISaleRepository SaleRepository { get; }
        private readonly Faker _faker;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;

            Context = new DefaultContext(options);
            SaleRepository = new SaleRepository(Context);
            _faker = new Faker();
        }

        public async Task InitializeAsync()
        {
            await Context.Database.EnsureCreatedAsync();
            await SeedTestDataAsync();
        }

        private async Task SeedTestDataAsync()
        {
            var customer = new Customer 
            {
                Id = Guid.NewGuid(),
                MainName = _faker.Person.FullName,
                ContractName = _faker.Company.CompanyName(),
                Email = _faker.Internet.Email(),
                Phone = _faker.Phone.PhoneNumber("(##) #####-####"),
                CreatedAt = DateTime.UtcNow
            };

            var subsidiary = new Subsidiary 
            {
                Id = Guid.NewGuid(),
                Name = _faker.Company.CompanyName(),
                CompanyIdentifierCode = _faker.Company.CatchPhrase(),
                Address = _faker.Address.FullAddress(),
                Phone = _faker.Phone.PhoneNumber("(##) #####-####"),
                CreatedAt = DateTime.UtcNow
            };

            Context.Customers.Add(customer);
            Context.Subsidiaries.Add(subsidiary);
            await Context.SaveChangesAsync();
        }

        public async Task<Sale> CreateSaleWithValidData()
        {
            var customer = await Context.Customers.FirstAsync();
            var subsidiary = await Context.Subsidiaries.FirstAsync();

            return new Sale
            {
                SalesDate = DateTime.UtcNow,
                Customer = new Customer { Id = customer.Id },
                Subsidiary = new Subsidiary { Id = subsidiary.Id },
                SaleItems = new List<SaleItem>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Product = new Product { Id = Guid.NewGuid() },
                        Quantity = _faker.Random.Number(1, 10),
                        UnitPrice = _faker.Random.Decimal(10, 100)
                    }
                },
                IsCanceled = false
            };
        }

        public async Task DisposeAsync()
        {
            await Context.Database.EnsureDeletedAsync();
            await Context.DisposeAsync();
        }
    }
}