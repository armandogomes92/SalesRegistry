using Ambev.DeveloperEvaluation.Application.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommand : IRequest<List<GetSaleResult>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? SubsidiaryId { get; set; }
    public Guid? SalesId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}