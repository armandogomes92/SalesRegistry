namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SubsidiaryId { get; set; }
        public Guid? SalesId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
