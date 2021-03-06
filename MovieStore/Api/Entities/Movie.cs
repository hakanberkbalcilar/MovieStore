using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Api.Entities;

public class Movie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public double Price { get; set; }

    public Genre Genre { get; set; } = null!;
    public Director Director { get; set; } = null!;

    public List<MovieActor> MovieActors { get; set; } = null!;
    public List<Purchase> Purchases { get; set; } = null!;
}