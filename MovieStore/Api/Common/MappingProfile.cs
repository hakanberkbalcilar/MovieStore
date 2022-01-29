using AutoMapper;
using MovieStore.Api.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Api.Application.ActorOperations.Queries.GetActors;
using MovieStore.Api.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.Api.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.Api.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Api.Application.PurchaseOperations.Commands.CreatePurchase;
using MovieStore.Api.Application.UserOperations.Commands.CreateUser;
using MovieStore.Api.Entities;

namespace MovieStore.Api.Common;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        //User
        CreateMap<CreateUserModel, User>();

        //Director
        CreateMap<CreateDirectorModel, Director>();

        //Actor
        CreateMap<CreateActorModel, Actor>();
        CreateMap<Actor, GetActorsViewModel>();

        //Genre
        CreateMap<CreateGenreModel, Genre>();

        //Movie
        CreateMap<CreateMovieModel, Movie>();

        //Purchase
        CreateMap<CreatePurchaseModel, Genre>();
    }
}