using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Queries;

public class GetCharactersQuery : IRequest<List<CharactersResponse>>
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int? MovieId { get; set; }
}

public class CharactersResponse
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, List<CharactersResponse>>
{
    private readonly IAsyncRepository<Character> _repository;
    private readonly IMapper _mapper;

    public GetCharactersQueryHandler(
        IAsyncRepository<Character> repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CharactersResponse>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetQueryable();

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(c => c.Name.Contains(request.Name));
        }

        if (request.Age.HasValue)
        {
            query = query.Where(c => c.Age == request.Age);
        }

        if (request.MovieId.HasValue)
        {
            query = query.Where(c => c.Movies.Any(m => m.Id == request.MovieId));
        }

        var characters = await _repository.ProjectToListAsync<CharactersResponse>(
            query, 
            _mapper.ConfigurationProvider, 
            cancellationToken);

        return characters.ToList();
    }
}

public class GetCharactersQueryProfile : Profile
{
    public GetCharactersQueryProfile()
    {
        CreateMap<Character, CharactersResponse>();
    }
}