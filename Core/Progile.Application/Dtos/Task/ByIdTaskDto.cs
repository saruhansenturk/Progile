using Progile.Domain.Enums;

namespace Progile.Application.Dtos.Task;

public class ByIdTaskDto
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
}