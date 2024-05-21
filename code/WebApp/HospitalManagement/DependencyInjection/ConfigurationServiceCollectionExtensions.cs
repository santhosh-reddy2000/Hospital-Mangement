using HospitalManagement.Core.Common.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace HospitalManagement.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddWebAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DataProviderCommunicationInfo>(config.GetSection("DataProvider"));
            services.TryAddSingleton(sp => sp.GetRequiredService<IOptions<DataProviderCommunicationInfo>>().Value);

            return services;
        }
    }
}
