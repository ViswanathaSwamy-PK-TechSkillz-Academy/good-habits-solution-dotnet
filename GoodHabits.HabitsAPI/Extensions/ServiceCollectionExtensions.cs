using GoodHabits.Persistence;
using GoodHabits.Persistence.Configurations;

namespace GoodHabits.HabitsAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAndMigrateDatabases(this IServiceCollection services, IConfiguration config)
    {
        var options = services.GetOptions<TenantSettings>(nameof(TenantSettings));

        var defaultConnectionString = options.DefaultConnectionString;

        services.AddDbContext<GoodHabitsDbContext>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(GoodHabitsDbContext).Assembly.FullName)));

        var tenants = options.Tenants;
        foreach (var tenant in tenants)
        {
            string? connectionString = string.IsNullOrEmpty(tenant.ConnectionString) ? defaultConnectionString : tenant.ConnectionString;

            using var scope = services.BuildServiceProvider().CreateScope();
            GoodHabitsDbContext dbContext = scope.ServiceProvider.GetRequiredService<GoodHabitsDbContext>();
            dbContext.Database.SetConnectionString(connectionString);

            if (dbContext.Database.GetMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
        return services;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();

        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        var section = configuration.GetSection(sectionName);

        var options = new T();

        section.Bind(options);

        return options;
    }

}