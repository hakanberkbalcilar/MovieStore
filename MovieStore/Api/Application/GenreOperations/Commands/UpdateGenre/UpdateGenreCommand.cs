using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommand
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public UpdateGenreModel Model { get; set; } = null!;

    public UpdateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle(){
        var genre = _context.Genres.FirstOrDefault(x => x.Id == Id);
        if(genre is null)
            throw new InvalidOperationException("Genre is not found!");
        
        if(_context.Genres.Any(x=> x.Name.ToLower() == Model.Name.ToLower()))
            throw new InvalidOperationException("Genre with the same name is already exist!");

        genre.Name = Model.Name != default ? Model.Name : genre.Name;
        _context.SaveChanges();
    }
}