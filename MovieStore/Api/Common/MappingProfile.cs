using AutoMapper;
using MovieStore.Api.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Api.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.Api.Application.UserOperations.Commands.CreateUser;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Common;

public class MappingProfile : Profile{

    public MappingProfile(){
        //User
        CreateMap<User, CreateUserModel>();

        //Director
        CreateMap<Director, CreateDirectorModel>();
        
        //Actor
        CreateMap<Actor, CreateActorModel>();
    }
}