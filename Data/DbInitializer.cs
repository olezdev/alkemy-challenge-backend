using alkemy_challenge_backend.Models;

namespace alkemy_challenge_backend.Data;

public static class DbInitializer
{
  public static void Initialize(MovieContext context)
  {
    if(context.Movies.Any() && context.Characters.Any() && context.Genres.Any())
      return;

    #region Genre
    var Comedia = new Genre { Name = "Comedia", Image = "" }; 
    var Drama = new Genre { Name = "Drama", Image = "" }; 
    var Accion = new Genre { Name = "Acción", Image = "" }; 
    var CienciaFiccion = new Genre { Name = "Ciencia ficción", Image = "" }; 
    var Fantasía = new Genre { Name = "Fantasía", Image = "" }; 
    var Musical = new Genre { Name = "Musical", Image = "" }; 
    var Terror = new Genre { Name = "Terror", Image = "" }; 
    var Suspenso = new Genre { Name = "Suspenso", Image = "" }; 
    var Romance = new Genre { Name = "Romance", Image = "" }; 
    var Melodrama = new Genre { Name = "Melodrama", Image = "" }; 
    var Policiaco = new Genre { Name = "Policíaco", Image = "" }; 
    var Belico = new Genre { Name = "Bélico", Image = "" }; 
    var Biografico = new Genre { Name = "Biográfico", Image = "" }; 
    var Western = new Genre { Name = "Western", Image = "" }; 
    var Animacion = new Genre { Name = "Animación", Image = "" }; 
    var CineIndependiente = new Genre { Name = "Cine independiente", Image = "" }; 
    var SerieB = new Genre { Name = "Serie B", Image = "" }; 
    var Historico = new Genre { Name = "Histórico", Image = "" }; 
    var Documental = new Genre { Name = "Documental", Image = "" }; 
  #endregion

    #region Character
    var RobertDowneyJr = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg/220px-Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg", Name = "Robert John Downey Jr", Age = 57, Weight = 78, History = "es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York. Se mudó con su padre a California, pero abandonó sus estudios para enfocarse completamente en su carrera. Tras numerosos proyectos fallidos, Downey ganó relevancia en el cine protagonizando la película Chaplin (1992), actuación con la cual ganó un BAFTA y fue nominado a los premios Óscar y los Globo de Oro. Sin embargo, se vio envuelto en una serie de problemas legales por posesión de drogas que llevaron a que fuera arrestado en numerosas ocasiones y a su vez que las productoras se negaran a contratarlo para nuevos papeles. Gracias al apoyo de Mel Gibson, Downey pudo regresar a la actuación y en 2001 ganó reconocimiento en la televisión con su papel en la serie Ally McBeal, con el cual ganó un Globo de Oro. En 2004 debutó como cantante con el lanzamiento de su álbum debut The Futurist. En 2008, recibió elogios de la crítica por su papel en Tropic Thunder (2008), actuación por la cual sería nuevamente nominado a los premios Óscar. También fue elogiado por su papel en Sherlock Holmes (2009), con el cual ganó un segundo Globo de Oro y realizó una secuela titulada Sherlock Holmes: Juego de sombras (2011)." }; 
    var ChristopherHemsworth = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/Chris_Hemsworth_by_Gage_Skidmore_2_%28cropped%29.jpg/220px-Chris_Hemsworth_by_Gage_Skidmore_2_%28cropped%29.jpg", Name = "Christopher Hemsworth", Age = 38, Weight = 88, History = "conocido simplemente como Chris Hemsworth, es un actor, actor de voz y productor australiano. Criado en la comunidad de Bulman, al norte de Australia, mostró interés por la actuación motivado por su hermano mayor e inició su carrera en 2002 con apariciones menores en series de televisión de su país. Años más tarde, se mudó a Sídney para conseguir mejores oportunidades y logró reconocimiento tras unirse al elenco principal de Home and Away, serie para la que grabó 189 episodios en cuestión de tres años" }; 
    var ChrisEvans = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Chris_Evans_2020_%28cropped%29.jpg/220px-Chris_Evans_2020_%28cropped%29.jpg", Name = "Christopher Robert Evans", Age = 41, Weight = 85, History = "conocido simplemente como Chris Evans, es un actor, actor de voz, director y productor de cine estadounidense. Criado en el pueblo de Sudbury, mostró interés a temprana edad por la actuación y se mudó a Nueva York para estudiar teatro luego de terminar la secundaria. Debutó como actor en 1997 al aparecer en un cortometraje educativo y años más tarde, en el 2000, protagonizó la serie Opposite Sex. Después de ello, ganó reconocimiento por su participación en películas como Not Another Teen Movie (2001) y The Perfect Score (2004)" }; 
    var PaulRudd = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Paul_Rudd_Ant-Man_%26_The_Wasp_premiere.jpg/455px-Paul_Rudd_Ant-Man_%26_The_Wasp_premiere.jpg", Name = "Paul Stephen Rudd", Age = 53, Weight = 70, History = "es un actor, comediante, escritor y productor de cine estadounidense. Estudió teatro en la Universidad de Kansas y en la Academia Americana de Artes Dramáticas, antes de hacer su debut como actor en 1992 con la serie dramática de NBC titulada Sisters. Es conocido por sus papeles en las películas: Clueless (1995), Romeo + Juliet (1996), The Object of My Affection (1998), Wet Hot American Summer (2001), Anchorman: The Legend of Ron Burgundy (2004), The 40 Year Old Virgin (2005), Knocked Up (2007), Role Models (2008), I Love You, Man (2009), This Is 40 (2012), The Perks of Being a Wallflower (2012), Anchorman 2:The Legend Continues (2013), Los principios del cuidado (2016), Mute (2018) e Ideal Home (2018)" }; 
    var NataliePortman = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Natalie_Portman_%2848470988352%29_%28cropped%29.jpg/220px-Natalie_Portman_%2848470988352%29_%28cropped%29.jpg", Name = "Neta-Lee Hershlag", Age = 41, Weight = 65, History = "es una actriz, directora y productora israelí nacionalizada estadounidense. Es una de las pocas actrices que ha ganado los cuatro premios más importantes del cine por una misma película: el Óscar (Mejor Actriz), el BAFTA (a la mejor actriz), el Globo de oro (a la mejor actriz en un drama) y el Premio del Sindicato de Actores (a la mejor actriz protagonista) por su trabajo en Black Swan (2010) del director Darren Aronofsky" }; 
    var ScarlettJohansson = new Character {  Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Scarlett_Johansson_by_Gage_Skidmore_2_%28cropped%29.jpg/220px-Scarlett_Johansson_by_Gage_Skidmore_2_%28cropped%29.jpg", Name = "Scarlett Ingrid Johansson", Age = 37, Weight = 67, History = "es una actriz, cantante, directora, productora y empresaria estadounidense. Comenzó a mostrar intereses en la actuación desde temprana edad, y a lo largo de su infancia y adolescencia se formó en distintos institutos como actriz. Tras tener varios papeles secundarios en distintas producciones, obtuvo su primer protagónico a los once años con la película Manny & Lo (1996), a la que luego le siguieron The Horse Whisperer (1998) y Ghost World (2001), actuaciones que le valieron elogios de la crítica" }; 
    #endregion

    #region Movies
    var movies = new Movie[]
    { 
      new Movie
      {
        Image = "https://upload.wikimedia.org/wikipedia/commons/d/df/ThorLoveandThunder.png", 
        Title = "Thor: Love and Thunder", 
        Year = 2022, 
        Rating = 3, 
        Genre = CienciaFiccion, 
        Characters = new List<Character> 
          { 
            ChristopherHemsworth, 
            NataliePortman
          }
      }, 
      new Movie
      {
        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Avengers-infinity-war-logo.svg/220px-Avengers-infinity-war-logo.svg.png", 
        Title = "Vengadores: Infinity War", 
        Year = 2018, 
        Rating = 5, 
        Genre = CienciaFiccion, 
        Characters = new List<Character> 
          { 
            RobertDowneyJr,
            ChristopherHemsworth, 
            ChrisEvans,
            ScarlettJohansson
          }
      }
    
    };
    #endregion

  context.Movies.AddRange(movies);
  context.SaveChanges();
  }
}