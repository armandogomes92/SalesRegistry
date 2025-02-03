using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.ById;

public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
{
    /// <summary>
    /// Gets or sets the ID of the sale to be retrieved.
    /// </summary>
    public Guid SaleId { get; set; }
}