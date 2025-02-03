using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Services;

public class SaleService : ISaleService
{
    public SaleService()
    {
    }

    /// <summary>
    /// Calculates the total amount of a sale item, considering the quantity and unit price, applying discounts if applicable.
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="unitPrice"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public decimal CalculateItemTotalWithDiscount(int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 items of the same product.");

        if (quantity >= 10)
            return unitPrice * quantity * 0.8m;
        if (quantity >= 4)
            return unitPrice * quantity * 0.9m;

        return unitPrice * quantity;
    }
}