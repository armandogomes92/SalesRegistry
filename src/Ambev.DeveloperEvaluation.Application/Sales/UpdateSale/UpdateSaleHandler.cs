using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ISaleService _saleService;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ISaleService saleService)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _saleService = saleService;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Sale>(command);

            foreach (var saleItem in sale.SaleItems)
            {
                saleItem.Discount = _saleService.CalculateItemTotalWithDiscount(saleItem.Quantity, saleItem.UnitPrice);
            }

            var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
            var result = _mapper.Map<UpdateSaleResult>(updatedSale);
            return result;
        }
    }
}
