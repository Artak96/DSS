using DSS.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DSS.Data.Context
{
    public class DSSDbContext : DbContext
    {
        public DSSDbContext() { }

        public DSSDbContext(DbContextOptions<DSSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
                var entityConfigurationsAssembly = typeof(TaskEntityConfiguration).GetTypeInfo().Assembly;
                modelBuilder.ApplyConfigurationsFromAssembly(entityConfigurationsAssembly);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException!.ToString());

            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                         .Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                    continue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("ModifyiedDate").CurrentValue = DateTime.UtcNow;
                }
            }
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
