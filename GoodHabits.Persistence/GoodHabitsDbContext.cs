using GoodHabits.Persistence.Entities;
using GoodHabits.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.Persistence;

public class GoodHabitsDbContext : DbContext
{
    private readonly ITenantService _tenantService;

    public string TenantName => _tenantService.GetTenant()?.TenantName ?? string.Empty;

    public DbSet<Habit>? Habits => Set<Habit>();

    public DbSet<User>? Users => Set<User>();

    public DbSet<Progress>? Progress => Set<Progress>();

    public DbSet<Reminder>? Reminders => Set<Reminder>();

    public DbSet<Goal>? Goals => Set<Goal>();

    public GoodHabitsDbContext(DbContextOptions options, ITenantService service) : base(options) =>
        _tenantService = service;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenantConnectionString = _tenantService.GetConnectionString();

        if (!string.IsNullOrEmpty(tenantConnectionString))
        {
            _ = optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Habit>().HasQueryFilter(a => a.TenantName == TenantName);

        SeedData.Seed(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries<IHasTenant>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
            .ToList().ForEach(entry => entry.Entity.TenantName = TenantName);

        return await base.SaveChangesAsync(cancellationToken);
    }

}