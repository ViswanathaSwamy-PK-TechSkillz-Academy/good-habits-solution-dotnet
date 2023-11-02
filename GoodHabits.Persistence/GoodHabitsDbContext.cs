using GoodHabits.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.Persistence;

public class GoodHabitsDbContext : DbContext
{
    public DbSet<Habit>? Habits => Set<Habit>();

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Server=sqlserver;Database=GoodHabitsDatabase;User Id=sa;Password=Sample@123$;Integrated Security=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) => SeedData.Seed(modelBuilder);
}