using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }

    public DeleteGenreCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle(){
        var genre = _context.Genres.FirstOrDefault(x=> x.Id == Id);
        if(genre is null)
            throw new InvalidOperationException("Genre is not found!");
        
        _context.Genres.Remove(genre);
        _context.SaveChanges();
    }
}