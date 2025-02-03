using MediatR;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Events.Handlers;

public class SaleEventHandler :
    INotificationHandler<SaleCreatedEvent>,
    INotificationHandler<SaleDeletedEvent>,
    INotificationHandler<SaleUpdatedEvent>
{
    private readonly ILogger<SaleEventHandler> _logger;

    public SaleEventHandler(ILogger<SaleEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
_logger.LogInformation($"Sale created: {notification.Sale.Id}");
        return Task.CompletedTask;
    }

    public Task Handle(SaleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sale updated: {notification.Updated}");
        return Task.CompletedTask;
    }

    public Task Handle(SaleDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sale deleted: {notification.Sale.Id}");
        return Task.CompletedTask;
    }
}