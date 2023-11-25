using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progile.Application
{
    //TODO reflection ile register etme islemini yap!
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration));
            });
        }
    }
}
