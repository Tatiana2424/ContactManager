using ContactManager.BLL.Interfaces.Logging;
using ContactManager.BLL.Services.Logging;
using ContactManager.DAL.Persistence;
using ContactManager.DAL.Repositories.Interfaces.Base;
using ContactManager.DAL.Repositories.Realizations.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ContactManager.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();

        var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        services.AddAutoMapper(currentAssemblies);
        services.AddMediatR(currentAssemblies);
        
        services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
      
    }
    public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ContactManagerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ContactManagerDb"), opt =>
            {
              
                opt.MigrationsAssembly(typeof(ContactManagerDbContext).Assembly.GetName().Name);
                opt.MigrationsHistoryTable("__EFMigrationsHistory", schema: "entity_framework");
            });
        });

        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
            });
        });

        services.AddControllers();
    }
}
