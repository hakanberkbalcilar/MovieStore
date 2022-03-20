namespace MovieStore.Api.Application.MovieOperations.Queries.GetMovies;

public class GetMoviesViewModel{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public String Genre { get; set; } = null!;
    public String Director { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public double Price { get; set; }
}