using Application.Interfaces;
using Common.Abstractions;
using Common.Mediator.Attributes;
using Common.Results;
using FluentResults;
using MediatR;


namespace Application.Commands;

[Authorize]
public sealed record DeleteProfileCommand : IRequest<Result>;

public sealed class DeleteProfileCommandHandler(IUser user, IProfileRepository repository, IPublisher publisher) 
    : IRequestHandler<DeleteProfileCommand, Result>
{
    public async Task<Result> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await repository.FindAsync(user.Id!.Value, cancellationToken).ConfigureAwait(false);
        
        if(profile is null)
            return ErrorResults.NotFound();
        
        var @event = profile.Delete();
        
        await repository.DeleteAsync(profile, cancellationToken).ConfigureAwait(false);
        
        await repository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        await publisher.Publish(@event, cancellationToken).ConfigureAwait(false);
        
        return Result.Ok();
    }
}