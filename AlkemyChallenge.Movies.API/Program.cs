using AlkemyChallenge.Movies.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

app.MapGet("/", () => "Alkemy Challenge Movies");

app.Run();
