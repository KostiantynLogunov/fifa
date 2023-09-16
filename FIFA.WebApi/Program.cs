using FIFA.Application.Common.Mappings;
using FIFA.Application.Interfaces;
using FIFA.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using FIFA.Application;
using Microsoft.Extensions.Configuration;
using FIFA.WebApi.Middleware;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using FIFA.WebApi;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog.Events;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("NotesWebAppLog-.txt", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();

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

builder.Services.AddVersionedApiExplorer(options =>
    options.GroupNameFormat="'v'VVV");

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
    ConfigureSwaggerOptions>();

builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<FootballersDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "an error occured while app initialization");
        //throw;
    }
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    foreach (var description in provider.ApiVersionDescriptions)
    {
        config.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant());
        config.RoutePrefix = string.Empty;
    }
});

//app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseApiVersioning();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
