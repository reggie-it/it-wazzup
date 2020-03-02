using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using itwazzup.Api.Filters;

namespace itwazzup.Api.Configurations
{
    public static class Mvc {
        /// <summary>
        /// Registers the mvc.
        /// </summary>
        /// <returns>The mvc.</returns>
        /// <param name="services">Services.</param>
        internal static IMvcBuilder RegisterMvc (IServiceCollection services) {
            return services.AddMvc (options => {
                options.Filters.Add (typeof (CustomExceptionFilterAttribute));
                options.Filters.Add (typeof (ActionValidationFilterAttribute));
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
			  .AddNewtonsoftJson(options =>
			  {
				  options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				  options.SerializerSettings.Converters.Add(new StringEnumConverter());
				  options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			  });
        }
        /// <summary>
        /// Configures the mvc.
        /// </summary>
        /// <param name="app">App.</param>
        internal static void ConfigureMvc (IApplicationBuilder app) {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}