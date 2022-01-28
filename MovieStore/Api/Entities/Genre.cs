using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Api.Entities;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Movie> Movies { get; set; } = null!;
}