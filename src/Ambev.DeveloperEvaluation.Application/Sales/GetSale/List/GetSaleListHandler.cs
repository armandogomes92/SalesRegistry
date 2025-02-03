using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale.List;

public class GetSaleListHandler : IRequestHandler<GetSaleListCommand, List<GetSaleListResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleListHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetSaleListResult>> Handle(GetSaleListCommand request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync(cancellationToken);

        if (sales == null)
            throw new InvalidOperationException($"Not found anyone sales");

        return _mapper.Map<List<GetSaleListResult>>(sales);
    }
}