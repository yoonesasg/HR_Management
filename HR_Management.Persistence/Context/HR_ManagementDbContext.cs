using HR_Management.Domain;
using HR_Management.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Context
{
    public class HR_ManagementDbContext : DbContext
    {
        #region Constructor
        public HR_ManagementDbContext(DbContextOptions<HR_ManagementDbContext> options) : base(options)
        {

        }
        #endregion

        #region DbSet
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HR_ManagementDbContext).Assembly);
        }
        #endregion

        #region SaveChanges
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        #endregion
    }
}
