using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.IO;

namespace EngLabAPI.Configuration
{
    public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = $"EngLab Api v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "An ASP.NET Core Web API for managing language schools",
                };
                options.SwaggerDoc(description.GroupName, openApiInfo);

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            }
        }

    }
}