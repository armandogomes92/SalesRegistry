using Ambev.DeveloperEvaluation.Application.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.List;

public class GetSaleListCommand : IRequest<List<GetSaleListResult>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? SubsidiaryId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}