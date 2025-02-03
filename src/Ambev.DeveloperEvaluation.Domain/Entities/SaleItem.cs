using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sale, including product details, quantity, price, and discounts.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the product associated with this sale item.
    /// </summary>
    public Product Product { get; set; } = new Product();

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total amount for this sale item.
    /// </summary>
    public decimal TotalAmount => (UnitPrice * Quantity) - Discount;

    /// <summary>
    /// Applies discount based on the quantity of the product sold.
    /// </summary>
    public void ApplyDiscount()
    {
        if (Quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");

        if (Quantity < 4)
        {
            Discount = 0;
            return;
        }
        var quantityDiscount = Quantity >= 10 ? 0.2m : 0.1m;

        Discount = Quantity * UnitPrice * quantityDiscount;
    }
}