using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.ActorOperations.Queries.GetActors;

public class GetActorsQuery
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetActorsViewModel> Handle(){
        var actors = _context.Actors.OrderBy(x => x.Id);
        
        var vm = _mapper.Map<List<GetActorsViewModel>>(actors);
        
        return vm;
    }
}