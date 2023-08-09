using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleArchiteture.Data.EfConfig;
using SimpleArchiteture.Data.Interfaces;
using SimpleArchiteture.Data.Repository;

namespace SimpleArchiteture.Data
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(configuration.GetConnectionString("appDb"),
               x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IUnitofWork>(provider => provider.GetService<UnitOfWork>());
            return services;
        }
    }
}

