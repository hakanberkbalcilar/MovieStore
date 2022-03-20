using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Api.Application.MovieOperations.Commands.DeleteMovie;
using MovieStore.Api.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.Api.Application.MovieOperations.Queries.GetMovies;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class MovieController : ControllerBase
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public MovieController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]

    public IActionResult GetMovies()
    {
        GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
    {
        CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
        command.Model = newMovie;

        CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updatedMovie)
    {
        UpdateMovieCommand command = new UpdateMovieCommand(_context);
        command.Id = id;
        command.Model = updatedMovie;

        UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        DeleteMovieCommand command = new DeleteMovieCommand(_context);
        command.Id = id;

        DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}