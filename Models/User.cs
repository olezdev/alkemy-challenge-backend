using Microsoft.AspNetCore.Identity;

namespace alkemy_challenge_backend.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
