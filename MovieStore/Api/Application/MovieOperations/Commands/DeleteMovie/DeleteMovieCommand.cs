using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.MovieOperations.Commands.DeleteMovie;

public class DeleteMovieCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }

    public DeleteMovieCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == Id);
        if (movie is null)
            throw new InvalidOperationException("Movie is not found!");

        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }
}