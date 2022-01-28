using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.ActorOperations.Commands.CreateActor;

public class CreateActorCommand{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public CreateActorModel Model { get;set;} = null!;

    public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle(){
        var actor = _context.Actors.FirstOrDefault(x=> x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower());
        if(actor is not null)
            throw new InvalidOperationException("Actor with the same name is already exist!");

        actor = _mapper.Map<Actor>(Model);

        _context.Actors.Add(actor);
        _context.SaveChanges();
    }

}