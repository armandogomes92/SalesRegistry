using Ambev.DeveloperEvaluation.Application.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
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
    /// Gets or sets a value indicating whether the sale is canceled.
    /// </summary>
    public bool IsCanceled { get; set; }
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