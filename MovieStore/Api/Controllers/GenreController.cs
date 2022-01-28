using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.Api.Application.GenreOperations.Commands.DeleteGenre;
using MovieStore.Api.Application.GenreOperations.Commands.UpdateGenre;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class GenreController : ControllerBase
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public GenreController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
        command.Model = newGenre;

        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.Id = id;
        command.Model = updatedGenre;

        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        command.Id = id;

        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}