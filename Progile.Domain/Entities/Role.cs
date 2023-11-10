using Progile.Domain.Entities.Common;

namespace Progile.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public Guid TeamId { get; set; }
    public Team Team { get; set; }

    public ICollection<User> Users { get; set; }
}