using Ambev.DeveloperEvaluation.Application.Dtos;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale.List;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    /// <summary>
    /// Profile for mapping ListSales feature requests to commands
    /// </summary>
    public class ListSalesProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListSales feature
        /// </summary>
        public ListSalesProfile()
        {
            CreateMap<ListSalesRequest, GetSaleListCommand>();
            CreateMap<GetSaleListResult, ListSalesResponse>()            
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<SaleItem, SaleItemResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Customer, CustomerDto>();
            CreateMap<Subsidiary, SubsidiaryDto>();
        }
    }
}
