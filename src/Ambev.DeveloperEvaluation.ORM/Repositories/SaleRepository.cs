using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all sales from the database including related entities
    /// </summary>
    /// <param name="salesId">Optional sales ID to filter by</param>
    /// <param name="pageNumber">Page number for pagination</param>
    /// <param name="pageSize">Page size for pagination</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of sales</returns>
    public async Task<List<Sale>> GetAllAsync(Guid? salesId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = _context.Sales.AsNoTracking();

        if (salesId.HasValue)
        {
            query = query.Where(s => s.Id == salesId.Value);
        }

        // Apply pagination if pageNumber and pageSize are valid
        if (pageNumber > 0 && pageSize > 0)
        {
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        return await query
            .Select(s => new Sale
            {
                Id = s.Id,
                SalesNumber = s.SalesNumber,
                SalesDate = s.SalesDate,
                TotalOfSale = s.TotalOfSale,
                IsCanceled = s.IsCanceled,
                SaleItems = s.SaleItems.Select(si => new SaleItem
                {
                    Id = si.Id,
                    Product = new Product
                    {
                        Id = si.Product.Id,
                        Title = si.Product.Title,
                        Price = si.Product.Price,
                        Description = si.Product.Description,
                        Category = si.Product.Category,
                        RateAverage = si.Product.GetAverageRating(si.Product.Ratings)
                    },
                    Quantity = si.Quantity,
                    UnitPrice = si.UnitPrice,
                    Discount = si.Discount,
                }).ToList(),
                Customer = new Customer
                {
                    Id = s.Customer.Id,
                    MainName = s.Customer.MainName,
                    ContractName = s.Customer.ContractName,
                    Phone = s.Customer.Phone,
                    Email = s.Customer.Email
            
                },
                Subsidiary = new Subsidiary
                {
                    Id = s.Subsidiary.Id,
                    Name = s.Subsidiary.Name,
                    CompanyIdentifierCode = s.Subsidiary.CompanyIdentifierCode,
                    Address = s.Subsidiary.Address,
                    Phone = s.Subsidiary.Phone
                },
            })
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">Unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        foreach (var saleItem in sale.SaleItems)
        {
            saleItem.Product = await _context.Products.Where(s => s.Id == saleItem.Product.Id).FirstAsync(cancellationToken);
        }
        sale.Customer = await _context.Customers.Select(s => s).FirstAsync(cancellationToken);
        sale.Subsidiary = await _context.Subsidiaries.Select(s => s).FirstAsync(cancellationToken);

        if (String.IsNullOrEmpty(sale.Subsidiary.Name))
            throw new KeyNotFoundException($"Subsidiary with ID {sale.Subsidiary.Id} not found");

        if (String.IsNullOrEmpty(sale.Customer.ContractName))
            throw new KeyNotFoundException($"Customer with ID {sale.Customer.Id} not found");

        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Updates an existing sale in the database
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    public async Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">Unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;
        sale.IsCanceled = true;

        return await UpdateAsync(sale);
    }
}