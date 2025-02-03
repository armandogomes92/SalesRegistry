using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
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
}
