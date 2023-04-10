using CleanArch.Application.Contracts.Persistence;
using CleanArch.Persistence.Context;
using CleanArch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArch.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"), b => b.MigrationsAssembly("CleanArch.Api")));

            //services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
