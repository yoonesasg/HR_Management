using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServicesRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
