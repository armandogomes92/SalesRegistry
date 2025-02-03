using Ambev.DeveloperEvaluation.Application.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.SalesNumber).GreaterThan(0);
            RuleFor(sale => sale.SalesDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(sale => sale.TotalOfSale).GreaterThan(0);
            RuleFor(sale => sale.CustomerId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(sale => sale.SubsidiaryId).NotEmpty().NotEqual(Guid.Empty);
            RuleForEach(sale => sale.SaleItems).SetValidator(new SaleItemValidator());
        }
    }

    public class SaleItemValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
            RuleFor(item => item.ProductId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title).NotEmpty();
            RuleFor(product => product.Price).GreaterThan(0);
            RuleFor(product => product.Description).NotEmpty();
            RuleFor(product => product.Category).NotEmpty();
        }
    }
}
