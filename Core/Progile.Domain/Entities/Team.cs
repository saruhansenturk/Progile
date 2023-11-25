using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Domain.Entities.Common;

namespace Progile.Domain.Entities
{
    public class Team: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
