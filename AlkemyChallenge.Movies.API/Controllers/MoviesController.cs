using AlkemyChallenge.Movies.Application.Features.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyChallenge.Movies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetMovies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetMoviesQuery>>> GetAll()
    {
        var response = await _mediator.Send(new GetMoviesQuery());
        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetMovieById")]
    public async Task<ActionResult<MovieResponse>> GetMovieById(int id)
    {
        var getMovieDetailQuery = new GetMovieByIdQuery() { Id = id };
        return Ok(await _mediator.Send(getMovieDetailQuery));
    }
}
