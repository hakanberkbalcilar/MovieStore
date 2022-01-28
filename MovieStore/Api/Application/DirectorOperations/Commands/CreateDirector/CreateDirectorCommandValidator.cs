using FluentValidation;

namespace MovieStore.Api.Application.DirectorOperations.Commands.CreateDirector;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>{

    public CreateDirectorCommandValidator(){
        RuleFor(command => command.Model.Name).MinimumLength(4);
        RuleFor(command => command.Model.Surname).MinimumLength(4);
    }
}