using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system, including details about the sale number, date, total amount, cancellation status, and items.
/// </summary>
public class Sale : BaseEntity
{
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
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    /// <summary>
    /// Gets or sets the customer associated with the sale.
    /// </summary>
    public Customer Customer { get; set; } = new Customer();

    /// <summary>
    /// Gets or sets the subsidiary where the sale was made.
    /// </summary>
    public Subsidiary Subsidiary { get; set; } = new Subsidiary();

    public Sale()
    {
        SalesDate = DateTime.Now;
    }

    public void Cancel()
    {
        if (IsCanceled)
        {
            throw new InvalidOperationException("Sale is already canceled.");
        }
        IsCanceled = true;
    }
}