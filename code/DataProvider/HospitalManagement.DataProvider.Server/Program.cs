
using HospitalManagement.DataProvider.Server.DependencyInjection;

namespace HospitalManagement.DataProvider.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string CorsPolicyName = "CorsPolicy";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, builder =>
                   builder.SetIsOriginAllowed(_ => true)
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
            });

            // Add services to the container.
            builder.WebHost.UseUrls("http://*:53050");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHospitalServerConfig(builder.Configuration);
            builder.Services.AddHospitalServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(CorsPolicyName);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}