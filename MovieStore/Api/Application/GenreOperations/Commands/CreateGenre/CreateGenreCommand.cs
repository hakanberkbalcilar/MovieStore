using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommand
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public CreateGenreModel Model { get; set; } = null!;

    public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _context.Genres.FirstOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());
        if(genre is not null)
            throw new InvalidOperationException("Genre with the same name is already exist!");

        genre = _mapper.Map<Genre>(Model);
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }
}