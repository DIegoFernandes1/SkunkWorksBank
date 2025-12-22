using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.Application.SharedContext.Behavios;

namespace SkunkWorksBank.Application.SharedContext
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                x.AddBehavior(typeof(ValidationBehavior<,>)); //<,> significa que funciona com qualquer combinação de "TRequest, TResponse" 
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
