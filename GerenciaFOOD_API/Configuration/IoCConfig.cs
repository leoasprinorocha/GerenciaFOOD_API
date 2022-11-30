using GerenciaFood_Domain.Interfaces.Usuarios;
using GerenciaFood_Services.Services.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaFOOD_API.Configuration
{
    public static class IoCConfig
    {
        public static IServiceCollection AddIoCServices(this IServiceCollection services)
        {
            services.AddExternalServices();
            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
