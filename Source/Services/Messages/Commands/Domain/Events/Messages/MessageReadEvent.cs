using MediatR;

namespace Messages.Commands.Domain.Events.Messages;

public record MessageReadEvent : INotification;