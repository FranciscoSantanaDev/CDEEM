using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdeem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cdeem.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserService>();

            return services;
        }
    }
}
