using FluentValidation;

namespace MovieStore.Api.Application.ActorOperations.Commands.CreateActor;

public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>{
    
    public CreateActorCommandValidator(){
        RuleFor(command => command.Model.Name).MinimumLength(4);
        RuleFor(command => command.Model.Surname).MinimumLength(4);
    }

}