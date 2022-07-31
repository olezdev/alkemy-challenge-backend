using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace alkemy_challenge_backend.Models;

public class Movie
{
  public int Id { get; set; }
  public string? Image { get; set; }
  
  [Required]
  [MaxLength(100)]
  public string? Title { get; set; }
  public int Year { get; set; }

  [Range(1, 5)]
  public int Rating { get; set; }

  public Genre? Genre { get; set; }
  
  [JsonIgnore]
  public ICollection<Character>? Characters { get; set; }
}
