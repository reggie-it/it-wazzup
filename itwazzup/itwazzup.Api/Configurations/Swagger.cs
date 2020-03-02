using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;


namespace itwazzup.Api.Configurations {

    public static class Swagger
    {
        /// <summary>
        /// Register Swagger
        /// </summary>
        internal static void RegisterSwagger(IServiceCollection services)
        {
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "v1";
                c.Title = "itwazzup Api";
                c.Version = "v1";
                c.Description = "RESTFul Api for itwazzup";

                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer ' + valid JWT token into field"
                });

                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
            });

        }

        /// <summary>
        /// Configure Swagger
        /// </summary>
        internal static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseOpenApi(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Your company name.",
                        Email = string.Empty,
                        Url = "http://yourwebsite.com"
                    };
                };
            });
            app.UseSwaggerUi3();
        }

    }
}