using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Progile.Application.Abstraction.Services;
using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Domain.Entities.Common;
using Progile.Persistence.Repositories;
using Progile.Persistence.Services;

namespace Progile.Persistence
{
    public static class ServiceRegistration
    {
        //TODO service ler reflection ile register edilecek.
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            // getting currently executing assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // get interface types Assembly
            Assembly assemblyInterface = Assembly.LoadFrom("..\\..\\Infrastructure\\Progile.Persistence\\bin\\Debug\\net7.0\\Progile.Application.dll");

            var interfaceTypes = assemblyInterface.GetTypes().Where(t => t.IsInterface && t.Name?.EndsWith("Repository") == true).ToList();

            var classTypes = assembly.GetTypes().Where(t => t.IsClass && t.Name?.EndsWith("Repository") == true).ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                // another variation for Substring <-> Name[1..]
                var classType = classTypes.FirstOrDefault(t => t.Name.Contains(interfaceType.Name[1..]));
                services.AddScoped(interfaceType, classType!);
            }

            // todo below registration process will change. Only test.
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
