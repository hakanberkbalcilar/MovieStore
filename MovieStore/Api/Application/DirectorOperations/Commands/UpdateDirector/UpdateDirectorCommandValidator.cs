using FluentValidation;

namespace MovieStore.Api.Application.DirectorOperations.Commands.UpdateDirector;

public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Name).MinimumLength(4);
        RuleFor(command => command.Model.Surname).MinimumLength(4);
    }
}