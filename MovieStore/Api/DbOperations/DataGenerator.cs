using Microsoft.EntityFrameworkCore;

namespace MovieStore.Api.DbOperations;

public class DataGenerator{

    public static void Initialize(IServiceProvider serviceProvider){
        using(var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>())){

        }
    }
}