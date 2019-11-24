using Microsoft.Extensions.DependencyInjection;
using Read;
using Read.QueryHandlers;

namespace System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReadDependencies(this IServiceCollection services)
            => services.AddTransient<IBarbecueReadonlyRepository, BarbecueReadonlyRepository>()
            .AddTransient<IParticipantReadonlyRepository, ParticipantReadonlyRepository>();
    }
}