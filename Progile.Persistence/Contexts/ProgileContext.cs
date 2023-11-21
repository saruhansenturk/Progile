using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progile.Domain.Entities;
using Progile.Domain.Entities.Common;
using Task = Progile.Domain.Entities.Task;

namespace Progile.Persistence.Contexts
{
    public class ProgileContext: DbContext
    {
        public ProgileContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.ModifiedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
