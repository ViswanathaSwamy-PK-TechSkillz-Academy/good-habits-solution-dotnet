﻿namespace GoodHabits.Persistence.Configurations;

public class TenantSettings
{
    public string? DefaultConnectionString { get; set; }

    public List<Tenant>? Tenants { get; set; }
}
