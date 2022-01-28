using MovieStore.Api.DbOperations;
using MovieStore.Core.TokenOperations;
using MovieStore.Core.TokenOperations.Models;

namespace MovieStore.Api.Application.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{

    private IMovieStoreDbContext _context;
    private IConfiguration _configuration;

    public string RefreshToken { get; set; } = null!;

    public RefreshTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public Token Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate < DateTime.Now);
        if (user is null)
            throw new InvalidOperationException("Refresh Token is not found!");

        TokenHandler handler = new TokenHandler(_configuration);
        var token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}