using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VisionLib.Models;

namespace VisionLib.Database
{
    public abstract class VisionDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>()
                 .HasIndex(u => u.Key)
                 .IsUnique();
        }
    }
}
