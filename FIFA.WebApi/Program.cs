using FIFA.Application.Common.Mappings;
using FIFA.Application.Interfaces;
using FIFA.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using FIFA.Application;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<FootballersDbContext>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IFootballersDbContext).Assembly));
});

IConfiguration Configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistance(Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<FootballersDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {

        //throw;
    }
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
