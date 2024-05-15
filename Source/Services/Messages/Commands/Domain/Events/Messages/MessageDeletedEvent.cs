using MediatR;

namespace Messages.Commands.Domain.Events.Messages;

public record MessageDeletedEvent : IRequest, INotification;