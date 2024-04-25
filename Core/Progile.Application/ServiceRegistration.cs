using Microsoft.Extensions.DependencyInjection;

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
