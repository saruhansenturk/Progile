using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Domain.Entities.Common;
using Progile.Persistence.Repositories;

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
        }
    }
}
