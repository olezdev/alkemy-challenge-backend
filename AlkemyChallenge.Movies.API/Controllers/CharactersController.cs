using AlkemyChallenge.Movies.Application.Features.Characters.Commands;
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
    public async Task<IActionResult> GetCharacters([FromQuery] string? name, [FromQuery] int? age, [FromQuery] int? movieId)
    {
        var query = new GetCharactersQuery
        {
            Name = name,
            Age = age,
            MovieId = movieId
        };

        var characters = await _mediator.Send(query);
        return Ok(characters);
    }

    [HttpGet("{id}", Name = "GetCharacterById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponse))]
    public async Task<ActionResult<CharacterResponse>> GetCharacterById(int id)
    {
        var getCharacterDetailQuery = new GetCharacterByIdQuery() { Id = id };
        return Ok(await _mediator.Send(getCharacterDetailQuery));
    }

    [HttpPost(Name = "AddCharacter")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    public async Task<ActionResult<int>> AddCharacter(CreateCharacterCommand command)
    {
        return CreatedAtRoute("GetCharacterById", new { id = await _mediator.Send(command) }, command);
    }

    [HttpPut("{id}", Name = "UpdateCharacter")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateCharacter(int id, UpdateCharacterCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCharacter")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        var deleteCharacterCommand = new DeleteCharacterCommand() { Id = id };
        await _mediator.Send(deleteCharacterCommand);
        return NoContent();
    }
}
