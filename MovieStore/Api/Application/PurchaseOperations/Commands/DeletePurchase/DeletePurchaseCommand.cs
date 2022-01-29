using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.PurchaseOperations.Commands.DeletePurchase;

public class DeletePurchaseCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }

    public DeletePurchaseCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var purchase = _context.Purchases.FirstOrDefault(x => x.Id == Id && x.IsActive);
        if(purchase is null)
            throw new InvalidOperationException("Purchase is not found!");
        
        purchase.IsActive = false;
        _context.SaveChanges();
    }
}