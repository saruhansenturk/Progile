using Progile.Domain.Entities.Common;

namespace Progile.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }
        
    public byte[]? Image { get; set; }
    public byte[]? Document { get; set; }
        
    public string UserId { get; set; }
    public User User { get; set; }

    public Guid TaskId { get; set; }
    public Task Task { get; set; }
}