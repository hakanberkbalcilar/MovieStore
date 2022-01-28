using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.DirectorOperations.Commands.UpdateDirector;

public class UpdateDirectorCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }
    public UpdateDirectorModel Model { get; set; } = null!;


    public UpdateDirectorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var director = _context.Directors.FirstOrDefault(x=> x.Id == Id);
        if(director is null)
            throw new InvalidOperationException("Director is not found!");

        if (_context.Directors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower()))
            throw new InvalidOperationException("Director with the same name is already exist!");

        director.Name = Model.Name != default ? Model.Name : director.Name;
        director.Surname = Model.Surname != default ? Model.Surname : director.Surname;

        _context.SaveChanges();
    }
}