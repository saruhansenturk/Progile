using Microsoft.AspNetCore.Identity;

namespace Progile.Domain.Entities;

public class Role : IdentityRole<string>
{
    public ICollection<User> Users { get; set; }
    
    public Guid TeamId { get; set; }
    public Team Team { get; set; }
}