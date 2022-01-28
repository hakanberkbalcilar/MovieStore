using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.DirectorOperations.Commands.CreateDirector;

public class CreateDirectorCommand
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public CreateDirectorModel Model { get; set; } = null!;

    public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _context.Directors.FirstOrDefault(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower());
        if (director is not null)
            throw new InvalidOperationException("Director with the same name is already exist!");

        director = _mapper.Map<Director>(Model);
        _context.Directors.Add(director);
        _context.SaveChanges();
    }
}