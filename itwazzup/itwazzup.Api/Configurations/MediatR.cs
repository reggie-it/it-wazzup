using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace itwazzup.Api.Configurations
{
    public static class MediatR {
        /// <summary>
        /// Registers MediatR - All command and query in the 'Application'
        /// </summary>
        /// <param name="services">Services.</param>
        internal static void RegisterMediatR (IServiceCollection services) {
            services.AddMediatR (typeof (Application.Exceptions.RecordNotFoundException).Assembly);
        }
    }
}