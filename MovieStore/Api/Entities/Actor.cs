namespace MovieStore.Api.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public List<MovieActor> MovieActors { get; set; } = null!;
}