using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
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
