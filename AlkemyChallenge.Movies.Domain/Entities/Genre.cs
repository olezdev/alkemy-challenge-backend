namespace AlkemyChallenge.Movies.Domain.Entities;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
