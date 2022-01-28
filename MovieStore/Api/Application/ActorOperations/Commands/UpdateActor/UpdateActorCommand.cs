using AutoMapper;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.ActorOperations.Commands.UpdateActor;

public class UpdateActorCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }
    public UpdateActorModel Model { get; set; } = null!;

    public UpdateActorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var actor = _context.Actors.FirstOrDefault(x=> x.Id == Id);
        if(actor is null)
            throw new InvalidOperationException("Actor is not found!");

        if(_context.Actors.Any(x=> x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Name.ToLower()))
            throw new InvalidOperationException("Actor with the same is already exist!");

        actor.Name = Model.Name != default ? Model.Name : actor.Name;
        actor.Surname = Model.Surname != default ? Model.Surname : actor.Surname;

        _context.SaveChanges();
    }
}