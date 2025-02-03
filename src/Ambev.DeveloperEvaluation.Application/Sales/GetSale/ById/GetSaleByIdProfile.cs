using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.ById
{
    public class GetSaleByIdProfile : Profile
    {
        public GetSaleByIdProfile()
        {
            CreateMap<Sale, GetSaleByIdResult>();
        }
    }
}