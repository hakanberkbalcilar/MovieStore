namespace MovieStore.Api.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Movie> Movies { get; set; } = null!;
}