using FluentValidation;

namespace MovieStore.Api.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>{
    public UpdateGenreCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Name).MinimumLength(4);
    }
}