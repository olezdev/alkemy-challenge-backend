// using alkemy_challenge_backend.Models;
// using alkemy_challenge_backend.Services;
// using Microsoft.AspNetCore.Mvc;

// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;

// namespace alkemy_challenge_backend.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class TokenController : ControllerBase
// {
//   [HttpGet]
//   public async Task<IActionResult> GetToken(AuthenticateRequest request, UserManager<User> userManager) 
//   {
//     // Verificamos credenciales con Identity
//     var user = await userManager.FindByNameAsync(request.UserName);

//     if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
//     {
//         return Results.Forbid();
//     }

//     var roles = await userManager.GetRolesAsync(user);

//     // Generamos un token según los claims
//     var claims = new List<Claim>
//     {
//         new Claim(ClaimTypes.Sid, user.Id),
//         new Claim(ClaimTypes.Name, user.UserName),
//         new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
//     };

//     foreach (var role in roles)
//     {
//         claims.Add(new Claim(ClaimTypes.Role, role));
//     }

//     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
//     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
//     var tokenDescriptor = new JwtSecurityToken(
//         issuer: builder.Configuration["Jwt:Issuer"],
//         audience: builder.Configuration["Jwt:Audience"],
//         claims: claims,
//         expires: DateTime.Now.AddMinutes(720),
//         signingCredentials: credentials);

//     var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

//     return Results.Ok(new
//     {
//         AccessToken = jwt
//     });
//   }

// }
