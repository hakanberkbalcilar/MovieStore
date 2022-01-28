using FluentValidation;

namespace MovieStore.Api.Application.ActorOperations.Commands.UpdateActor;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {

    }
}