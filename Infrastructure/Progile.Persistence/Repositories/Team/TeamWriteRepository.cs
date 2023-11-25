using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories
{
    public class TeamWriteRepository : WriteRepository<Team>, ITeamWriteRepository
    {
        public TeamWriteRepository(ProgileContext context) : base(context)
        {
        }
    }
}
