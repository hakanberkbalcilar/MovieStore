using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Api.Entities;


public class Actor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public List<MovieActor> MovieActors { get; set; } = null!;
}