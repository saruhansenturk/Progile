using Microsoft.Extensions.Configuration;

namespace Progile.Infrastructure.Extensions
{
    public static class BindingExtension
    {
        public static T GetBindFromAppSettings<T>(this IConfiguration configuration) where T : class, new()
        {
            T instance = new T();
            configuration.Bind(typeof(T).Name, instance);
            return instance;
        }
    }
}
