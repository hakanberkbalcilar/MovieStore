namespace MovieStore.Api.Application.PurchaseOperations.Commands.CreatePurchase;

public class CreatePurchaseModel
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public double Paid { get; set; }
}