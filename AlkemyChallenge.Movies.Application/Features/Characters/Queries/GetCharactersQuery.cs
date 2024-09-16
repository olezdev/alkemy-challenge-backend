using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Queries;

public class GetCharactersQuery : IRequest<List<CharactersResponse>>
{
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
        var characters = await _repository.ListAllAsync<CharactersResponse>(_mapper.ConfigurationProvider);
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