using HospitalManagement.Common.Interfaces;
using HospitalManagement.Core.Common.Interfaces;
using HospitalManagement.Services;

namespace HospitalManagement.DependencyInjection
{
    public static class RegisterServiceExtensions
    {
        public static IServiceCollection AddWebAppServices(this IServiceCollection services) 
        {
            services.AddScoped<IHeadOfficeService, HeadOfficeService>();
            services.AddScoped<IDataProviderCommunicator, DataProviderCommunicatorService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
