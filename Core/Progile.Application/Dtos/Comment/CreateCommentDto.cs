namespace Progile.Application.Dtos.Comment;

public class CreateCommentDto
{
    public string Content { get; set; }
    public byte[]? Image { get; set; }
    public byte[]? Document { get; set; }
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}