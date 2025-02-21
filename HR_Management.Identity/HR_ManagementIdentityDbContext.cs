﻿using HR_Management.Identity.Configurations;
using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Identity
{
    public class HR_ManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HR_ManagementIdentityDbContext(DbContextOptions<HR_ManagementIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
