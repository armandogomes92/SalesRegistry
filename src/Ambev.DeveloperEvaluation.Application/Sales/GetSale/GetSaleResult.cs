using Ambev.DeveloperEvaluation.Application.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    /// <summary>
    /// Gets or sets the sales.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the sales number.
    /// </summary>
    public long SalesNumber { get; set; }

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
    /// Gets or sets the items included in the sale.
    /// </summary>
    public List<SaleItemResponseDto> SaleItems { get; set; }

    /// <summary>
    /// Gets or sets the customer associated with the sale.
    /// </summary>
    public CustomerDto Customer { get; set; }

    /// <summary>
    /// Gets or sets the subsidiary where the sale was made.
    /// </summary>
    public SubsidiaryDto Subsidiary { get; set; }
}