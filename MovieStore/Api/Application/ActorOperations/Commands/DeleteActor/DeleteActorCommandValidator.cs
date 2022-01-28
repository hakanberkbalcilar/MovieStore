using FluentValidation;

namespace MovieStore.Api.Application.ActorOperations.Commands.DeleteActor;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>{

    public DeleteActorCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}