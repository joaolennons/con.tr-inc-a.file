using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Write;
using Write.Repositories;

namespace System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWriteDependencies(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<WriteContext>(options => options.UseSqlServer(configuration.GetConnectionString(Consts.WRITE_DB)))
            .AddTransient<IBarbecueRepository, BarbecueRepository>()
            .AddTransient<IPresenceRepository, PresenceRepository>();
    }
}
