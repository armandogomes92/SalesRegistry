using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSalesRequestValidator : AbstractValidator<ListSalesRequest>
    {
        public ListSalesRequestValidator()
        {
            RuleFor(request => request.StartDate).LessThanOrEqualTo(request => request.EndDate)
                .When(request => request.StartDate.HasValue && request.EndDate.HasValue);
        }
    }
}
