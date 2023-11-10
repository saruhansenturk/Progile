using Progile.Domain.Entities.Common;
using Progile.Domain.Enums;

namespace Progile.Domain.Entities;

public class Task : BaseEntity
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsLimited { get; set; }
    public UrgentStatus UrgentStatus { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public bool IsCanceled { get; set; }


    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public ICollection<Comment> Comment { get; set; }
    public ICollection<User> Users { get; set; }
}