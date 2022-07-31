using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using alkemy_challenge_backend.Models;

namespace alkemy_challenge_backend.Data;

public class UserContext : IdentityDbContext<User>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
}