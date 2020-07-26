using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;

namespace HospitalWeb.Extensions
{
    public static class ConfigureDependeciesExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<JwtManager>();

            services.AddTransient<AuthenticationService<User>>();

            services.AddTransient<UserService<User>>();

            services.AddTransient<PatientService>();

        }
    }
}