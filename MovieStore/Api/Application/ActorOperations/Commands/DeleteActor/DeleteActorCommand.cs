using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Application.ActorOperations.Commands.DeleteActor;

public class DeleteActorCommand
{
    private IMovieStoreDbContext _context;

    public int Id { get; set; }

    public DeleteActorCommand(IMovieStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var actor = _context.Actors.FirstOrDefault(x=> x.Id == Id);
        if(actor is null)
            throw new InvalidOperationException("Actor is not found!");
        
        _context.Actors.Remove(actor);
        _context.SaveChanges();
    }
}