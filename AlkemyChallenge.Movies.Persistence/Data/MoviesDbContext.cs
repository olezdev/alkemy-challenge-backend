using AlkemyChallenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AlkemyChallenge.Movies.Persistence.Data;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
    : base(options)
    { }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        Seeding.SeedInitial.IntialSeed(builder);
    }
}