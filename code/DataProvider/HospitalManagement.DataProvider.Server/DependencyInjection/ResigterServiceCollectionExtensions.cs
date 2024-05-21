using HospitalManagement.Dataprovider.Services;
using HospitalManagement.DataProvider.Common.Interfaces;
using HospitalManagement.Repository;

namespace HospitalManagement.DataProvider.Server.DependencyInjection
{
    public static class ResigterServiceCollectionExtensions
    {
        public static void AddHospitalServices(this IServiceCollection services)
        {
            services.AddScoped<IHospitalSQLRepository,HospitalSQLRepository>();
            services.AddScoped<IHeadOfficeService, HeadOfficeService>();
            services.AddScoped<IBranchServices, BranchServices>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
        }
    }
}
