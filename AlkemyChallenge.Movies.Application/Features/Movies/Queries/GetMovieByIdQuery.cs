using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Movies.Queries;

public class GetMovieByIdQuery : IRequest<MovieResponse>
{
    public int Id { get; set; }
}

public class MovieResponse
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Rating { get; set; }
    public int GenreId { get; set; }
    public GenreDto Genre { get; set; }
    public ICollection<CharacterDto> Characters { get; set; }
}

public class GenreDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class CharacterDto
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string? History { get; set; }
}

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    private readonly IAsyncRepository<Movie> _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieByIdQueryHandler(
        IAsyncRepository<Movie> movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movieDto = await _movieRepository
            .GetByIdProjectToAsync<MovieResponse>(request.Id, _mapper.ConfigurationProvider);
        return movieDto;
    }
}

public class GetMovieByIdQueryProfile : Profile
{
    public GetMovieByIdQueryProfile()
    {
        CreateMap<Movie, MovieResponse>();
        CreateMap<Character, CharacterDto>();
        CreateMap<Genre, GenreDto>();
    }
}