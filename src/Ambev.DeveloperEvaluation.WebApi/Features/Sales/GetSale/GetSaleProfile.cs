using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale.ById;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Profile for mapping GetSale feature requests to commands
    /// </summary>
    public class GetSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSale feature
        /// </summary>
        public GetSaleProfile()
        {
            CreateMap<Guid, GetSaleByIdCommand>();
        }
    }
}
