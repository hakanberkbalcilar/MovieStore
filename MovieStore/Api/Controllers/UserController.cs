using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.UserOperations.Commands;
using MovieStore.Api.Application.UserOperations.Commands.CreateToken;
using MovieStore.Api.Application.UserOperations.Commands.CreateUser;
using MovieStore.Api.Application.UserOperations.Commands.RefreshToken;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.Model = newUser;

        CreateUserCommandValidator validator = new CreateUserCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }

    [HttpPost("connect/token")]
    public IActionResult CreateToken(CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
        command.Model = login;

        return Ok(command.Handle());
    }


    [HttpGet("refreshToken")]
    public IActionResult RefreshToken([FromQuery] string refreshToken)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
        command.RefreshToken = refreshToken;

        return Ok(command.Handle());
    }
}
