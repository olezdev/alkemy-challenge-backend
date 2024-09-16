using AlkemyChallenge.Movies.Application.Features.Characters.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyChallenge.Movies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CharactersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetCharacters")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CharactersResponse>))]
    public async Task<ActionResult<List<GetCharactersQuery>>> GetAll()
    {
        var response = await _mediator.Send(new GetCharactersQuery());
        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetCharacterById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
    public async Task<ActionResult<CharacterResponse>> GetCharacterById(int id)
    {
        var getCharacterDetailQuery = new GetCharacterByIdQuery() { Id = id };
        return Ok(await _mediator.Send(getCharacterDetailQuery));
    }
}
