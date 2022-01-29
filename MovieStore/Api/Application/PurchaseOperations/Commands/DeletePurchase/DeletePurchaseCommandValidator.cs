using FluentValidation;

namespace MovieStore.Api.Application.PurchaseOperations.Commands.DeletePurchase;

public class DeletePurchaseCommandValidator : AbstractValidator<DeletePurchaseCommand>
{
    public DeletePurchaseCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
    }
}