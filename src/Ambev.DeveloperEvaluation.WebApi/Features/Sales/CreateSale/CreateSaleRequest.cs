using Ambev.DeveloperEvaluation.Application.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the date of the sale.
    /// </summary>
    public DateTime SalesDate { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the sale.
    /// </summary>
    public decimal TotalOfSale { get; set; }

    /// <summary>
    /// Gets or sets the ID of the customer.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the subsidiary.
    /// </summary>
    public Guid SubsidiaryId { get; set; }

    /// <summary>
    /// Gets or sets the list of sale items.
    /// </summary>
    public List<SaleItemDto> SaleItems { get; set; }
}