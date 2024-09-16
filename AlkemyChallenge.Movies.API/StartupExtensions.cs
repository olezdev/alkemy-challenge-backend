using AlkemyChallenge.Movies.Application;
using AlkemyChallenge.Movies.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AlkemyChallenge.Movies.API;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddSwagger();

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();

            });
        });

        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Alkemy Challenge Movies API");
            });
        }
        // enable swagger in production
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Alkemy Challenge Movies API");
            });
        }


        app.UseHttpsRedirection();
        app.UseRouting();
        //app.UseCustomExceptionHandler();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    private static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Alkemy Challenge Movies API"
            });

            c.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                               Enter 'Bearer' [space] and then your token in the text input below.
                               Example: 'Bearer xxxxx.yyyyy.zzzz'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http, //ApiKey
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                 {
                   new OpenApiSecurityScheme
                   {
                     Reference = new OpenApiReference
                     {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                     },
                     Scheme = "oauth2",
                     Name = "Bearer",
                     In = ParameterLocation.Header,

                   },
                   new List<string>()
                 }
            });
        });
    }

    public class SwaggerAuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                var roles = authorizeAttributes
                    .Where(attr => !string.IsNullOrEmpty(attr.Roles))
                    .Select(attr => attr.Roles)
                    .Distinct();

                var rolesText = roles.Any() ? $"Roles: {string.Join(", ", roles)}" : "Authorization required";

                operation.Description += $"<br/><b>{rolesText}</b>";
            }
        }
    }
}
