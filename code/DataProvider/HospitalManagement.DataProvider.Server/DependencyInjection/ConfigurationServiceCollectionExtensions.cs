using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace HospitalManagement.DataProvider.Server.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static void AddHospitalServerConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<HospitalDBConnectionInfo>(config.GetSection("Database"));
            services.TryAddSingleton(sp => sp.GetRequiredService<IOptions<HospitalDBConnectionInfo>>().Value);

            services.Configure<BaseUrls>(config.GetSection("BaseUrls"));
            services.TryAddSingleton(sp => sp.GetRequiredService<IOptions<BaseUrls>>().Value);
        }
    }
}
