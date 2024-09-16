using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Movies.Queries;

public class GetMoviesQuery : IRequest<List<MoviesResponse>>
{
}

public class MoviesResponse
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Rating { get; set; }
}

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MoviesResponse>>
{
    private readonly IAsyncRepository<Movie> _repository;
    private readonly IMapper _mapper;

    public GetMoviesQueryHandler(
        IAsyncRepository<Movie> repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<MoviesResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var accesoPenetracionProvincias = await _repository.ListAllAsync<MoviesResponse>(_mapper.ConfigurationProvider);
        return accesoPenetracionProvincias.ToList();
    }
}

public class GetMoviesQueryProfile : Profile
{
    public GetMoviesQueryProfile()
    {
        CreateMap<Movie, MoviesResponse>();
    }
}