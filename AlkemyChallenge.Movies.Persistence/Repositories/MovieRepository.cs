using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AlkemyChallenge.Movies.Persistence.Data;

namespace AlkemyChallenge.Movies.Persistence.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MoviesDbContext context)
        : base(context)
    {
    }
}