using alkemy_challenge_backend.Models;
using alkemy_challenge_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace alkemy_challenge_backend.Services;

public class CharacterService
{
  private readonly MovieContext _context;

  public CharacterService(MovieContext context)
  {
    _context = context;
  }

  // public IEnumerable<Character> GetAll()
  // {
  //   return _context.Characters
  //     .AsNoTracking()
  //     .ToList();
  // }
  // public IEnumerable<CharacterDTO> GetAll()
  // {
  //   return _context.Characters
  //     .Select(x => CharacterToDTO(x))
  //     .ToList();
  // }

  public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetAll()
  {
    return await _context.Characters
      .Select(x => CharacterToDTO(x))
      .ToListAsync();
  }
  
  public Character? GetById(int id)
  {
    return _context.Characters
      .Include(c => c.Movies)
      .AsNoTracking()
      .SingleOrDefault(c => c.Id == id);
  }

  public Character? GetByParams([BindRequired] string name, [BindRequired] int age)
  {
    return _context.Characters
      .Include(c => c.Movies)
      .AsNoTracking()
      .SingleOrDefault(c => c.Name == name || c.Age == age);
  }

  public Character? GetByName([FromQuery] string name)
  {
    return _context.Characters
      .Include(c => c.Movies)
      .AsNoTracking()
      .SingleOrDefault(c => c.Name == name);
  }

  public Character? GetByAge([FromQuery] int age)
  {
    return _context.Characters
      .Include(c => c.Movies)
      .AsNoTracking()
      .SingleOrDefault(c => c.Age == age);
  }

  //   public Character? GetByName([BindRequired] string name)
  // {
  //   return _context.Characters
  //     .Include(c => c.Movies)
  //     .AsNoTracking()
  //     .SingleOrDefault(c => c.Name == name);
  // }

  // public Character? GetByAge([BindRequired] int age)
  // {
  //   return _context.Characters
  //     .Include(c => c.Movies)
  //     .AsNoTracking()
  //     .SingleOrDefault(c => c.Age == age);
  // }


  private static CharacterDTO CharacterToDTO(Character character) =>
    new CharacterDTO
    {
        Id = character.Id,
        Image = character.Image,
        Name = character.Name
    };
}