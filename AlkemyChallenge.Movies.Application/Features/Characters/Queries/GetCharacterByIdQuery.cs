using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Application.Features.Movies.Queries;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Queries;

public class GetCharacterByIdQuery : IRequest<CharacterResponse>
{
    public int Id { get; set; }
}

public class CharacterResponse
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string History { get; set; } = string.Empty;
    public ICollection<MovieDto> Movies { get; set; }

}
public class MovieDto
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Rating { get; set; }
    public int GenreId { get; set; }
    public GenreDto Genre { get; set; }
}

public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, CharacterResponse>
{
    private readonly IAsyncRepository<Character> _characterRepository;
    private readonly IMapper _mapper;

    public GetCharacterByIdQueryHandler(
        IAsyncRepository<Character> characterRepository,
        IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<CharacterResponse> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var characterDto = await _characterRepository
            .GetByIdProjectToAsync<CharacterResponse>(request.Id, _mapper.ConfigurationProvider);
        return characterDto;
    }
}

public class GetCharacterByIdQueryProfile : Profile
{
    public GetCharacterByIdQueryProfile()
    {
        CreateMap<Character, CharacterResponse>();
        CreateMap<Movie, MovieDto>();
    }
}