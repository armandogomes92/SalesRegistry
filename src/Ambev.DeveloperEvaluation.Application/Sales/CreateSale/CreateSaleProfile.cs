using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ForPath(dest => dest.Customer.Id, opt => opt.MapFrom(src => src.CustomerId))
            .ForPath(dest => dest.Subsidiary.Id, opt => opt.MapFrom(src => src.SubsidiaryId));
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<SaleItemDto, SaleItem>()
            .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId));
    }
}