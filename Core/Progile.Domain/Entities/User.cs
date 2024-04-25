using Microsoft.AspNetCore.Identity;

namespace Progile.Domain.Entities;

public class User: IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public ICollection<Comment> Comments { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Team> Teams { get; set; }
}