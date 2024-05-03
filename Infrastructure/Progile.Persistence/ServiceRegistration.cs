using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Progile.Application.Abstraction.Services;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;
using Progile.Persistence.Services;


namespace Progile.Persistence
{
    public static class ServiceRegistration
    {
        //TODO service ler reflection ile register edilecek.
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // getting currently executing assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Progile.Application.dll"));
            Assembly assemblyInterface = Assembly.LoadFrom(path);

            // get interface types Assembly
            // Assembly assemblyInterface = Assembly.LoadFrom(@"..\..\Infrastructure\Progile.Persistence\bin\Debug\net8.0\Progile.Application.dll");

            var interfaceTypes = assemblyInterface.GetTypes()
                .Where(t => t.IsInterface && t.Name?.EndsWith("Repository") == true).ToList();

            var classTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Name?.EndsWith("Repository") == true).ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                var classType = classTypes.FirstOrDefault(t => t.Name.Contains(interfaceType.Name[1..]));
                services.AddScoped(interfaceType, classType);
            }

            // Register services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IUserService<>), typeof(UserService<>));

            // Register DbContext
            var connection = configuration.GetConnectionString("ProgileConnectionString");
            services.AddDbContext<ProgileContext>(opt => opt.UseNpgsql(connection));

            services.AddIdentity<User, Role>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ProgileContext>()
                .AddDefaultTokenProviders();
        }
    }
}

