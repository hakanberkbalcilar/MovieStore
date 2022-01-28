namespace MovieStore.Api.Entities;

public class Director
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public List<Movie> Movies { get; set; } = null!;
}