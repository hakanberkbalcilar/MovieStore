using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Core.TokenOperations;
using MovieStore.Core.TokenOperations.Models;

namespace MovieStore.Api.Application.UserOperations.Commands.CreateToken;

public class CreateTokenCommand
{

    private IMovieStoreDbContext _context;
    private IConfiguration _configuration;

    public CreateTokenModel Model { get; set; } = null!;

    public CreateTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
        if (user is null)
            throw new InvalidOperationException("User is not found!");

        TokenHandler handler = new TokenHandler(_configuration);
        Token token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}