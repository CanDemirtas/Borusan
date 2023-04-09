using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Infrastructure.Order;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
