
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleDeletedEvent : INotification
{
    public Sale Sale { get; }

    public SaleDeletedEvent(Sale sale)
    {
        Sale = sale;
    }
}