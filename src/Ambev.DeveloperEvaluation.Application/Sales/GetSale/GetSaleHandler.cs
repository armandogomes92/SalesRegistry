using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, List<GetSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetSaleResult>> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync(
            request.SalesId,
            request.PageNumber,
            request.PageSize,
            cancellationToken
        );

        if (sales == null || !sales.Any())
            throw new InvalidOperationException("No sales found");

        return _mapper.Map<List<GetSaleResult>>(sales);
    }
}