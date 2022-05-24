using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Contracts.Infrastructure;
using Order.Application.Contracts.Models;
using Order.Application.Contracts.Persistence;
using Order.Infrastrucutre.Mail;
using Order.Infrastrucutre.Persistence;
using Order.Infrastrucutre.Repositories;

namespace Order.Infrastrucutre
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
