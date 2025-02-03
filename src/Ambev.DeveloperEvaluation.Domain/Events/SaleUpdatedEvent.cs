using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleUpdatedEvent : INotification
{
    public bool Updated { get; }

    public SaleUpdatedEvent(bool sale)
    {
        Updated = sale;
    }
}