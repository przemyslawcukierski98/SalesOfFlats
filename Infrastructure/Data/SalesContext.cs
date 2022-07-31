using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Flat> Flats { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach(var item in entries)
            {
                ((AuditableEntity)item.Entity).LastModified = DateTime.UtcNow;

                if(item.State == EntityState.Added)
                {
                    ((AuditableEntity)item.Entity).Created = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
