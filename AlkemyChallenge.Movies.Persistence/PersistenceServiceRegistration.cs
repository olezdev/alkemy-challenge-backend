using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Persistence.Data;
using AlkemyChallenge.Movies.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlkemyChallenge.Movies.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MoviesDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IMovieRepository, MovieRepository>();


        return services;
    }
}