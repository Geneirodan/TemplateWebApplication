using MassTransit;
using Messages.Contracts;

namespace Messages.Commands.Infrastructure.MassTransit.EventHandlers;

internal sealed class MessageReadEventHandler(IPublishEndpoint endpoint)
    : IntegrationEventHandler<MessageReadEvent>(endpoint);