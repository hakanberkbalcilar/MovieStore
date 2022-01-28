using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Api.Entities;

public class MovieActor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int ActorId { get; set; }

    public Movie Movie { get; set; } = null!;
    public Actor Actor { get; set; } = null!;


}