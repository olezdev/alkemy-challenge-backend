using AlkemyChallenge.Movies.Domain.Common;
using System.Text.Json.Serialization;

namespace AlkemyChallenge.Movies.Domain.Entities;

public class Character : IEntity
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string? History { get; set; }
    [JsonIgnore]
    public ICollection<Movie>? Movies { get; set; }
}
