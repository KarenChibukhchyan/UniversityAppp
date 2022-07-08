using Microsoft.Extensions.DependencyInjection;
using UniversityAppp.Models;

namespace UniversityAppp.Services
{
    public static class ServiceInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService<Student>, PersonService<Student>>();
            services.AddScoped<IPersonService<Teacher>, PersonService<Teacher>>();
            return services;
        }
    }
}