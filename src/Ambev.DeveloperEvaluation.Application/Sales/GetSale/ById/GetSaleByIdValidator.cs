using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.ById;

public class GetSaleByIdValidator : AbstractValidator<GetSaleByIdCommand>
{
    public GetSaleByIdValidator()
    {
        RuleFor(command => command.SaleId).NotEmpty().NotEqual(Guid.Empty);
    }
}