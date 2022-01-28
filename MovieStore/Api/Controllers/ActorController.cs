using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Api.Application.ActorOperations.Commands.DeleteActor;
using MovieStore.Api.Application.ActorOperations.Commands.UpdateActor;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Controllers;


[ApiController]
[Route("[controller]s")]
public class ActorController : ControllerBase{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public ActorController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult CreateActor([FromBody] CreateActorModel newActor){
        CreateActorCommand command = new CreateActorCommand(_context,_mapper);
        command.Model = newActor;

        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();


        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel updateActor){
        UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
        command.Id = id;
        command.Model = updateActor;

        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteActor(int id){
        DeleteActorCommand command = new DeleteActorCommand(_context);
        command.Id = id;

        DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}