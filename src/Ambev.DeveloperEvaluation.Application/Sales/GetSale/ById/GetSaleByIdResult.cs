using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.ById;

public class GetSaleByIdResult
{
    /// <summary>
    /// Gets or sets the sale.
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
    public bool IsCanceled { get;    }

    /// <summary>
    /// Gets or sets the items included in the sale.
    /// </summary>
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    /// <summary>
    /// Gets or sets the customer associated with the sale.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets the subsidiary where the sale was made.
    /// </summary>
    public Subsidiary Subsidiary { get; set; }
}