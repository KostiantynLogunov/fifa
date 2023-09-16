﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;

namespace FIFA.WebApi
{
    public class ConfigureSwaggerOptions: IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Footballers API {apiVersion}",
                        Description = " a simple pet project asp.net core web api",
                        Contact = new OpenApiContact
                        {
                            Name = "kostik",
                            Email = "777koc@gmail.com",
                            Url = new Uri("https://t.me/KostiaLogunov")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "kos ltd",
                            Url = new Uri("https://t.me/KostiaLogunov")
                        }
                    });

                options.AddSecurityDefinition($"AuthToken {apiVersion}", 
                    new OpenApiSecurityScheme
                    {
                        In=ParameterLocation.Header,
                        Type=SecuritySchemeType.Http,
                        BearerFormat="JWT",
                        Scheme="bearer",
                        Name="Authorization",
                        Description= "Authorization token"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        
                            Reference= new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id= $"AuthToken {apiVersion}"
                            }
                        },
                        new string[] {}
                     }
                });

                options.CustomOperationIds(ApiDescription =>
                    ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                    ? methodInfo.Name 
                    : null);
            }
        }
    }
}
