using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.MovieOperations.Commands.UpdateMovie;

public class UpdateMovieCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }
    public UpdateMovieModel Model { get; set; } = null!;

    public UpdateMovieCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle(){
        var movie = _context.Movies.FirstOrDefault(x=> x.Id == Id);
        if(movie is null)
            throw new InvalidOperationException("Movie is not found!");

        movie.Name = Model.Name != default ? Model.Name : movie.Name;
        movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
        movie.Price = Model.Price != default ? Model.Price : movie.Price;

        _context.SaveChanges();
    }
}