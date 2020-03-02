using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace itwazzup.Api.Configurations
{
    public static class AutoMapper {
        internal static void RegisterAutoMapper (IServiceCollection services) {
            //http://docs.automapper.org/en/stable/Inline-Mapping.html
            services.AddAutoMapper(
                configAction =>
                {
                    ///TODO: What happened to inline maps. Do more research?
                    //configAction.ValidateInlineMaps = false;
                },
                typeof(Application.Response)
                );
        }
    }
}