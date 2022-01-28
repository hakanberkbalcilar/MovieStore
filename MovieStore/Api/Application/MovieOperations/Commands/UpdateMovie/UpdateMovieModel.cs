namespace MovieStore.Api.Application.MovieOperations.Commands.UpdateMovie;

public class UpdateMovieModel{
    public int GenreId { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
}