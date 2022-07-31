using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace alkemy_challenge_backend.Models;

public class Character
{
  public int Id { get; set; }

  public string? Image { get; set; }

  public string? Name { get; set; }

  public int Age { get; set; }

  public decimal Weight { get; set; }

  public string? History { get; set; }

  // public Movie? Movie { get; set; }
  [JsonIgnore]
  public ICollection<Movie>? Movies { get; set; }

}

