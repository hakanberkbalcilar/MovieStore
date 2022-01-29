using FluentValidation;

namespace MovieStore.Api.Application.PurchaseOperations.Commands.CreatePurchase;

public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>{
    public CreatePurchaseCommandValidator(){
        RuleFor(command => command.Model.MovieId).GreaterThan(0);
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.Paid).GreaterThan(0);
        RuleFor(command => command.Model.Date).NotEmpty().LessThan(DateTime.Now);
    }
}