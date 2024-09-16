using AlkemyChallenge.Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyChallenge.Movies.Persistence.Seeding;

public static class SeedInitial
{
    public static void IntialSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Comedia", Image = "" },
            new Genre { Id = 2, Name = "Drama", Image = "" },
            new Genre { Id = 3, Name = "Acción", Image = "" },
            new Genre { Id = 4, Name = "Ciencia ficción", Image = "" },
            new Genre { Id = 5, Name = "Fantasía", Image = "" },
            new Genre { Id = 6, Name = "Musical", Image = "" },
            new Genre { Id = 7, Name = "Terror", Image = "" },
            new Genre { Id = 8, Name = "Suspenso", Image = "" }
        );

        modelBuilder.Entity<Character>().HasData(
            new Character
            {
                Id = 1,
                Name = "Robert John Downey Jr",
                Age = 57,
                Weight = 78,
                History = "Actor conocido por su papel en Iron Man.",
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg/220px-Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg"
            },
            new Character
            {
                Id = 2,
                Name = "Christopher Hemsworth",
                Age = 38,
                Weight = 88,
                History = "Actor conocido por su papel en Thor.",
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/Chris_Hemsworth_by_Gage_Skidmore_2_%28cropped%29.jpg/220px-Chris_Hemsworth_by_Gage_Skidmore_2_%28cropped%29.jpg"
            },
            new Character
            {
                Id = 3,
                Name = "Natalie Portman",
                Age = 41,
                Weight = 65,
                History = "Actriz ganadora de un Oscar por Black Swan.",
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Natalie_Portman_%2848470988352%29_%28cropped%29.jpg/220px-Natalie_Portman_%2848470988352%29_%28cropped%29.jpg"
            }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Thor: Love and Thunder",
                Year = 2022,
                Rating = 3,
                GenreId = 4,
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/ThorLoveandThunder.png"
            },
            new Movie
            {
                Id = 2,
                Title = "Vengadores: Infinity War",
                Year = 2018,
                Rating = 5,
                GenreId = 4,
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Avengers-infinity-war-logo.svg/220px-Avengers-infinity-war-logo.svg.png"
            }
        );

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Characters)
            .WithMany(c => c.Movies)
            .UsingEntity(j => j.HasData(
                new { MoviesId = 1, CharactersId = 2 },  // Thor: Love and Thunder - Christopher Hemsworth
                new { MoviesId = 1, CharactersId = 3 },  // Thor: Love and Thunder - Natalie Portman
                new { MoviesId = 2, CharactersId = 1 },  // Infinity War - Robert Downey Jr
                new { MoviesId = 2, CharactersId = 2 },  // Infinity War - Christopher Hemsworth
                new { MoviesId = 2, CharactersId = 3 }   // Infinity War - Chris Evans
            ));
    }
}
