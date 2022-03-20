using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.PurchaseOperations.Commands.CreatePurchase;

public class CreatePurchaseCommand
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;
    public CreatePurchaseModel Model { get; set; } = null!;

    public CreatePurchaseCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == Model.MovieId);
        if (movie is null)
            throw new InvalidDataException("Movie is not found!");

        var purchase = _context.Purchases.FirstOrDefault(x => x.UserId == Model.UserId && x.MovieId == Model.MovieId);
        if (purchase is not null)
            throw new InvalidOperationException("Movie has already been bought!");

        purchase = _mapper.Map<Purchase>(Model);
        _context.Purchases.Add(purchase);
        _context.SaveChanges();
    }
}