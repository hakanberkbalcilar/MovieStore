namespace MovieStore.Api.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpireDate { get; set; }


    public List<Purchase> Purchases { get; set; } = null!;
    public List<FavoriteGenre> FavoriteGenres { get; set; } = null!;
}