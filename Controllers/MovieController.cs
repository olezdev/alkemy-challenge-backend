using alkemy_challenge_backend.Models;
using alkemy_challenge_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace alkemy_challenge_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
  MovieService _service;
  public MovieController(MovieService service)
  {
    _service = service;
  }

  [HttpGet]
  public IEnumerable<Movie> GetAll()
  {
    return _service.GetAll();
  }
  
  [HttpGet("{id}")]
  public ActionResult<Movie> GetById(int id)
  {
    var movie = _service.GetById(id);

    if(movie is not null)
      return movie;
    else
      return NotFound();
  }

  [HttpPost]
  public IActionResult Create(Movie newMovie)
  {
    var movie = _service.Create(newMovie);
    return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Movie movie)
  {
    if (id != movie.Id)
      return BadRequest();

    var existingMovie = _service.GetById(id);
    if (existingMovie is null)
      return NotFound();
    
    _service.Update(movie);
    return NoContent();
  }

  [HttpPut("{id}/updategenre")]
  public IActionResult UpdateGenre(int id, int genreId)
  {
    var movieToUpdate = _service.GetById(id);
    if(movieToUpdate is not null)
    {
      _service.UpdateGenre(id, genreId);
      return NoContent();
    }
    else
    {
      return NotFound();
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var movie = _service.GetById(id);

    if (movie is not null)
    {
      _service.DeleteById(id);
      return Ok();
    }
    else
    {
      return NotFound();
    }
  }
  
}