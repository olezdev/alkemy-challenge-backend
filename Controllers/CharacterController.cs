using alkemy_challenge_backend.Models;
using alkemy_challenge_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace alkemy_challenge_backend.Controllers;


[ApiController]
[Route("[controller]")]
// [Authorize]
public class CharacterController : ControllerBase
{
  CharacterService _service;



  public CharacterController(CharacterService service)
  {
    _service = service;
  }

  // [HttpGet]
  // public IEnumerable<Character> GetAll()
  // {
  //   return _service.GetAll();
  // }
  // [HttpGet]
  // public IEnumerable<CharacterDTO> GetAll()
  // {
  //   return _service.GetAll();
  // }
  [HttpGet]
  // [Authorize]
  public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetAll()
  {
    return await _service.GetAll();
  }

  [HttpGet("{id}")]
  public ActionResult<Character> GetById(int id)
  {
    var character = _service.GetById(id);
    if(character is not null)
      return character;
    else
      return NotFound();
  }

  // [HttpGet("/characters")]
  // public ActionResult<Character> GetByParams([BindRequired] string name, [BindRequired] int age)
  // {
  //   var character = _service.GetByParams(name, age);
  //   if(character is not null)
  //     return character;
  //   else
  //     return NotFound();
  // }

  [HttpGet("/characters")]
  public ActionResult<Character> GetByParams([BindRequired] string name, [BindRequired] int age)
  {
    if (name is not null && age != 0)
    {
      var character = _service.GetByParams(name, age);
      if(character is not null)
        return character;
      else
        return NotFound();
    }
    if (name is not null )
    {
      var character = _service.GetByName(name);
      if(character is not null)
        return character;
      else
        return NotFound();
    }
    else if (age != 0)
    {
      var character = _service.GetByAge(age);
      if(character is not null)
        return character;
      else
        return NotFound();
    }
    else
    {
      return NotFound();
    }
  }
  
  // [HttpGet]
  // public ActionResult<Character> GetByAge([FromQuery] int age)
  // {
  //   var character = _service.GetByAge(age);
  //   if(character is not null)
  //     return character;
  //   else
  //     return NotFound();
  // }
    // [HttpGet("/characters")]
  // public ActionResult<Character> GetByName([BindRequired] string name)
  // {
  //   var character = _service.GetByName(name);
  //   if(character is not null)
  //     return character;
  //   else
  //     return NotFound();
  // }
  
  // [HttpGet("/characters")]
  // public ActionResult<Character> GetByAge([BindRequired] int age)
  // {
  //   var character = _service.GetByAge(age);
  //   if(character is not null)
  //     return character;
  //   else
  //     return NotFound();
  // }

}