using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progile.Application.Dtos.Project
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TeamId { get; set; }
    }
}
