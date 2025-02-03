using Ambev.DeveloperEvaluation.Application.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public long SalesNumber { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal TotalOfSale { get; set; }
        public bool IsCanceled { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SubsidiaryId { get; set; }
        public List<SaleItemDto> SaleItems { get; set; }
    }
}
