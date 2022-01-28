namespace MovieStore.Core.TokenOperations.Models;

public class Token
{
    public string AccessToken { get; set; } = null!;
    public DateTime ExpireDate { get; set; }
    public string RefreshToken { get; set; } = null!;
}