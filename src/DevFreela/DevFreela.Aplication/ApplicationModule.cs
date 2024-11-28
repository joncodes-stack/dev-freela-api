using DevFreela.Aplication.Commands.Projects.InsertProject;
using DevFreela.Aplication.Commands.Users.InsertUser;
using DevFreela.Application.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Aplication
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertUserCommand>());

            services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();

            return services;
        }
    }
}
