using Ambev.DeveloperEvaluation.Application.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for sale creation command.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.SalesDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(sale => sale.TotalOfSale).GreaterThan(0);
            RuleFor(sale => sale.CustomerId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(sale => sale.SubsidiaryId).NotEmpty().NotEqual(Guid.Empty);
            RuleForEach(sale => sale.SaleItems).SetValidator(new SaleItemValidator());
        }
    }

    /// <summary>
    /// Validator for SaleItemDto that defines validation rules for sale items.
    /// </summary>
    public class SaleItemValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
            RuleFor(item => item.ProductId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}