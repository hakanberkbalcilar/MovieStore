using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.PurchaseOperations.Commands.CreatePurchase;
using MovieStore.Api.Application.PurchaseOperations.Commands.DeletePurchase;
using MovieStore.Api.DbOperations;

namespace MovieStore.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class PurchaseController : ControllerBase
{
    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public PurchaseController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult CreatePurchase([FromBody] CreatePurchaseModel newPurchase)
    {
        CreatePurchaseCommand command = new CreatePurchaseCommand(_context, _mapper);
        command.Model = newPurchase;

        CreatePurchaseCommandValidator validator = new CreatePurchaseCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePurchase(int id)
    {
        DeletePurchaseCommand command = new DeletePurchaseCommand(_context);
        command.Id = id;

        DeletePurchaseCommandValidator validator = new DeletePurchaseCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}