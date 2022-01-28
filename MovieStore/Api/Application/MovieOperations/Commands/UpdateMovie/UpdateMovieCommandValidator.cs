using FluentValidation;

namespace MovieStore.Api.Application.MovieOperations.Commands.UpdateMovie;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>{
    public UpdateMovieCommandValidator(){
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.Price).GreaterThan(0);
        RuleFor(command => command.Model.Name).MinimumLength(0);
    }
}