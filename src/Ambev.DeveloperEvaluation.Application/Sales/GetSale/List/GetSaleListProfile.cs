using Ambev.DeveloperEvaluation.Application.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.List;

public class GetSaleListProfile : Profile
{
    public GetSaleListProfile()
    {
        CreateMap<Sale, GetSaleListResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<SaleItem, SaleItemResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<Customer, CustomerDto>();
        CreateMap<Subsidiary, SubsidiaryDto>();
    }
}