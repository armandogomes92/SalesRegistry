using Ambev.DeveloperEvaluation.Application.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(request => request.SalesDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(request => request.TotalOfSale).GreaterThan(0);
            RuleFor(request => request.CustomerId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(request => request.SubsidiaryId).NotEmpty().NotEqual(Guid.Empty);
            RuleForEach(request => request.SaleItems).SetValidator(new SaleItemValidator());
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
                RuleFor(request => request.ProductId).NotEmpty().NotEqual(Guid.Empty);
            }
        }
    }
}
