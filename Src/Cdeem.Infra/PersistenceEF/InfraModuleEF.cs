using Cdeem.Core.Repositories;
using Cdeem.Infra.Messaging;
using Cdeem.Infra.PersistenceEF.Context;
using Cdeem.Infra.PersistenceEF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cdeem.Infra.PersistenceEF
{
    public static class InfraModuleEF
    {
        public static IServiceCollection AddInfraEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEF(configuration);
            services.AddRepository().AddMessageBus();
            return services;
        }

        public static void AddEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
             options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsAssembly("Cdeem.Infra")
                 ));
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<INoteRepository, NoteRespository>();

            return services;
        }

        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusService, RabbitMqService>();
            return services;
        }
    }
}
