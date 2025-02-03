namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleService
{
    decimal CalculateItemTotalWithDiscount(int quantity, decimal unitPrice);
}