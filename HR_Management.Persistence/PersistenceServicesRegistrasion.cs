using HR_Management.Application.Contracts.Persistence;
using HR_Management.Persistence.Context;
using HR_Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Persistence
{
    public static class PersistenceServicesRegistrasion
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region DbContext

            services.AddDbContext<HR_ManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HR_ManagementConnectionString"));
            });

            #endregion

            #region Dependency Injection

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            #endregion

            return services;

        }
    }
}
