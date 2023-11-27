using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories;

public class CommentReadRepository: ReadRepository<Comment>, ICommentReadRepository
{
    public CommentReadRepository(ProgileContext context) : base(context)
    {
    }
}