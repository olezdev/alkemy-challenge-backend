namespace alkemy_challenge_backend.Data;

public static class Extensions
{
  public static void CreateDb(this IHost host)
  {
    using (var scope = host.Services.CreateScope())
    {
      var services = scope.ServiceProvider;
      var context = services.GetRequiredService<MovieContext>();
      if (context.Database.EnsureCreated())
      {
        DbInitializer.Initialize(context);
      }
    }
  }
}