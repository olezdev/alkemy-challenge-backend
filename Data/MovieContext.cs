using Microsoft.EntityFrameworkCore;
using alkemy_challenge_backend.Models;

namespace alkemy_challenge_backend.Data;

public class MovieContext : DbContext
{
  public MovieContext (DbContextOptions<MovieContext> options)
    : base(options)
  {}

  public DbSet<Movie> Movies => Set<Movie>();
  public DbSet<Character> Characters => Set<Character>();
  public DbSet<Genre> Genres => Set<Genre>();
}