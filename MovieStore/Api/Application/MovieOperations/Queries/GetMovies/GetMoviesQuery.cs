using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.MovieOperations.Queries.GetMovies;

public class GetMoviesQuery
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetMoviesViewModel> Handle()
    {
        var movies = _context.Movies.OrderBy(x => x.Id);
        
        var vm = _mapper.Map<List<GetMoviesViewModel>>(movies);

        return vm;
    }
}