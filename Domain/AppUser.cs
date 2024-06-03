using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser<Guid>
{
    public string DisplayName { get; set; }

}
