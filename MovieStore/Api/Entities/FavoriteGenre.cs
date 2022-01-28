namespace MovieStore.Api.Entities;

public class FavoriteGenre
{

    public int Id { get; set; }

    public int GenreId { get; set; }

    public int UserId { get; set; }


    public Genre Genre { get; set; } = null!;
    public User User { get; set; } = null!;

}