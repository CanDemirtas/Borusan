using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Context
{
    public class ApplicationDbContext : AuditableContext
    {
 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
           .SelectMany(t => t.GetProperties())
           .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //builder.ApplicationSeed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "user Can";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "user Can";
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            
            return await base.SaveChangesAsync("123");
        }
    }
}
