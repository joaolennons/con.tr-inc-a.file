using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Domain;
using Microsoft.Extensions.Configuration;

namespace System
{
    public static class ServiceCollectionExtensions
    { 
        public static IServiceCollection AddDomainDependency(this IServiceCollection services, IConfiguration configuration)
            => services.AddMediatR(Assembly.GetAssembly(typeof(CreateNoReasonBarbecue)))
            .AddWriteDependencies(configuration)
            .AddDrinkingValues(configuration);

        private static IServiceCollection AddDrinkingValues(this IServiceCollection services, IConfiguration configuration)
        {
            var no = configuration.GetSection("DrinkingOptionValues:no")?.Value ?? "10";
            var yes = configuration.GetSection("DrinkingOptionValues:yes")?.Value ?? "20";
            var values = new DrinkingOptionValue(decimal.Parse(no), decimal.Parse(yes));
            return services.AddSingleton(values);
        }
    }
}