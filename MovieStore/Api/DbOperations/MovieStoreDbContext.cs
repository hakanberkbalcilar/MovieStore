using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Entities;

namespace MovieStore.Api.DbOperations;

public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
{

    public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Director> Directors { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;
    public DbSet<MovieActor> MovieActors { get; set; } = null!;
    public DbSet<FavoriteGenre> FavoriteGenres { get; set; } = null!;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}