using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Api.Entities;

public class FavoriteGenre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int GenreId { get; set; }

    public int UserId { get; set; }


    public Genre Genre { get; set; } = null!;
    public User User { get; set; } = null!;

}