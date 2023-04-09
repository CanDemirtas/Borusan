using CleanArch.Application.Contracts.Persistence;
using CleanArch.Persistence.Context;
using CleanArch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"), b => b.MigrationsAssembly("CleanArch.Api")));

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
