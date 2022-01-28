using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.MovieOperations.Commands.CreateMovie;

public class CreateMovieCommand
{

    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public CreateMovieModel Model { get; set; } = null!;

    public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _mapper.Map<Movie>(Model);
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }
}