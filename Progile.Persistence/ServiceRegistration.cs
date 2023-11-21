using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Progile.Application.Repositories;
using Progile.Persistence.Repositories;

namespace Progile.Persistence
{
    public static class ServiceRegistration
    {
        //TODO service ler reflection ile register edilecek.
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamWriteRepository, TeamWriteRepository>();
            services.AddScoped<ITeamReadRepository, TeamReadRepository>();
        }
    }
}
