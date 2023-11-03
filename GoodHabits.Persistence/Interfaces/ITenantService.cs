using GoodHabits.Persistence.Configurations;

namespace GoodHabits.Persistence.Interfaces;

public interface ITenantService
{
    public string GetConnectionString();

    public Tenant GetTenant();
}