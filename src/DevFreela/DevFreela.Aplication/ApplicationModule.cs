using DevFreela.Aplication.Interfaces;
using DevFreela.Aplication.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Aplication
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }
    }
}
