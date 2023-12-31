using Asp.Versioning;
using GoodHabits.HabitsAPI.Extensions;
using GoodHabits.HabitsAPI.Interfaces;
using GoodHabits.HabitsAPI.Services;
using GoodHabits.Persistence.Configurations;
using GoodHabits.Persistence.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoodHabits.HabitsAPI", Version = "v1" }));
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.AddTransient<IHabitService, HabitService>();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);

    opt.AssumeDefaultVersionWhenUnspecified = true;

    opt.ReportApiVersions = true;

    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("x-api-version"),
            new MediaTypeApiVersionReader("x-api-version"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoodHabits.HabitsAPI v1"));

    app.UseCors(policy =>
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                );
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
