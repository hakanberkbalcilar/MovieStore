using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Entities;

namespace MovieStore.Api.DbOperations;

public interface IMovieStoreDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<FavoriteGenre> FavoriteGenres { get; set; }

    int SaveChanges();

}