using AppServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServiceDependencies(this IServiceCollection services, IConfiguration configuration)
            => services.AddTransient<IBarbecueAppService, BarbecueAppService>()
            .AddTransient<IParticipantAppService, ParticipantAppService>()
            .AddDomainDependency(configuration);
    }
}
