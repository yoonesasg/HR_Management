﻿using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;
using HR_Management.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}