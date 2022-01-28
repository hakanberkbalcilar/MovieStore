namespace MovieStore.Api.Application.MovieOperations.Commands.CreateMovie;

public class CreateMovieModel
{
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public double Price { get; set; }

}