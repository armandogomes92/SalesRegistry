namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSalesRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SubsidiaryId { get; set; }
        public Guid SalesId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
