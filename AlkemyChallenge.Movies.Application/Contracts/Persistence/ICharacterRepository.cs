using AlkemyChallenge.Movies.Domain.Entities;

namespace AlkemyChallenge.Movies.Application.Contracts.Persistence;

public interface ICharacterRepository : IAsyncRepository<Character>
{
}