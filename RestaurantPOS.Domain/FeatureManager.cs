using RestaurantPOS.Database;
using RestaurantPOS.Domain.Model.Role;
using System.Net.Mail;

namespace RestaurantPOS.Domain;

public static class FeatureManager
{
    public static IServiceCollection AddModularService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddBuilderServies(builder)
            .AddBusinessLogic()
            .AddDataAccessLogic();
        return services;
    }

    public static IServiceCollection AddBuilderServies(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient
        );
        return services;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<BL_Role>();
        return services;
    }

    public static IServiceCollection AddDataAccessLogic(this IServiceCollection services)
    {
        services.AddScoped<DA_Role>();
        return services;
    }

}