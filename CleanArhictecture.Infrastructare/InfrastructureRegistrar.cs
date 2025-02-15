using CleanArhictecture.Domain.Employees;
using CleanArhictecture.Infrastructare.Context;
using CleanArhictecture.Infrastructare.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Infrastructare
{
    public static class InfrastructureRegistrar
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                string connectionString = configuration.GetConnectionString("SqlServer")!;
                opt.UseSqlServer(connectionString);
            });

            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

            services.Scan(opt => opt
            .FromAssemblies(typeof(InfrastructureRegistrar).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            return services;
        }
    }
}
