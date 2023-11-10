using Progile.Domain.Entities.Common;

namespace Progile.Domain.Entities;

public class User: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }


    public ICollection<Task> Tasks { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Team> Teams { get; set; }
}