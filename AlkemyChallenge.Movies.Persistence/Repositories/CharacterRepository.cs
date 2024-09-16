using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AlkemyChallenge.Movies.Persistence.Data;

namespace AlkemyChallenge.Movies.Persistence.Repositories;

public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
{
    public CharacterRepository(MoviesDbContext context)
        : base(context)
    {
    }
}