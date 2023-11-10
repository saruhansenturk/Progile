using Progile.Domain.Entities.Common;

namespace Progile.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid TeamId { get; set; }
    public Team Team { get; set; }


    public ICollection<Task> Tasks { get; set; }
}