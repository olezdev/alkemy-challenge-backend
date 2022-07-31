using System.Text.Json.Serialization;

namespace alkemy_challenge_backend.Models;

public class CharacterDTO
{
  public int Id { get; set; }

  public string? Image { get; set; }

  public string? Name { get; set; }

  [JsonIgnore]
  public ICollection<Movie>? Movies { get; set; }
}