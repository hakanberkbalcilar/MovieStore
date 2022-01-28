using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.DirectorOperations.Commands.DeleteDirector;

public class DeleteDirectorCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }

    public DeleteDirectorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var director = _context.Directors.FirstOrDefault(x => x.Id == Id);
        if (director is null)
            throw new InvalidOperationException("Director is not found!");

        _context.Directors.Remove(director);
        _context.SaveChanges();
    }


}