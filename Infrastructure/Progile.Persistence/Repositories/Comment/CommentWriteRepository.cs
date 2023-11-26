using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories;

public class CommentWriteRepository: WriteRepository<Comment>, ICommentWriteRepository
{
    public CommentWriteRepository(ProgileContext context) : base(context)
    {
    }
}