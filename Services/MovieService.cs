using alkemy_challenge_backend.Models;
using alkemy_challenge_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace alkemy_challenge_backend.Services;

public class MovieService
{
  private readonly MovieContext _context;

  public MovieService(MovieContext context)
  {
    _context = context;
  }

  // static List<Movie> Movies {get; }
  // static int nextId = 3;
  // static MovieService()
  // {
  //   Movies = new List<Movie>
  //   {
  //     new Movie {
  //       Id = 1,
  //       Title = "Thor Love and Thunder" ,
  //       Year = 2022,
  //       Rating = 3
  //     },
  //     new Movie {
  //       Id = 2,
  //       Title = "Top Gun Maverick" ,
  //       Year = 2022,
  //       Rating = 4
  //     }
  //   };
  // }

  public IEnumerable<Movie> GetAll() 
  {
    return _context.Movies
      .AsNoTracking()
      .ToList();
  }

  public Movie? GetById(int id) 
  {
    return _context.Movies
      .Include(m => m.Characters)
      .Include(m => m.Genre)
      .AsNoTracking()
      .SingleOrDefault(m => m.Id == id);
  }

  public Movie? Create(Movie newMovie)
  {
    _context.Movies.Add(newMovie);
    _context.SaveChanges();

    return newMovie;
  }

  public void Update(Movie movie)
  {
    var index = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
    if (index is null)
      return;
    _context.Movies.Update(movie);
    _context.SaveChanges();
  }

  public void UpdateGenre(int MovieId, int GenreId)
  {
    var movieToUpdate = _context.Movies.Find(MovieId);
    var genreToUpdate = _context.Genres.Find(GenreId);

    if (movieToUpdate is null || genreToUpdate is null)
      throw new NullReferenceException("Pelicula o genero no existe");
    
    movieToUpdate.Genre = genreToUpdate;

    _context.SaveChanges();
  }

  public void DeleteById(int MovieId)
  {
    var movieToDelete = _context.Movies.Find(MovieId);
    if (movieToDelete is not null)
    {
      _context.Movies.Remove(movieToDelete);
      _context.SaveChanges();
    }
  }

}