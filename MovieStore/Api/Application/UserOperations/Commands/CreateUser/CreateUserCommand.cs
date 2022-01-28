using AutoMapper;
using MovieStore.Api.DbOperations;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Application.UserOperations.Commands.CreateUser;

public class CreateUserCommand
{

    private IMovieStoreDbContext _context;
    private IMapper _mapper;

    public CreateUserModel Model { get; set; } = null!;

    public CreateUserCommand(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
        if (user is not null)
            throw new InvalidOperationException("User with same email address is already exist");

        user = _mapper.Map<User>(Model);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

}