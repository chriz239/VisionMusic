using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionLib.Database;
using VisionLib.Models;

namespace VisionWebService.Database
{
    public class VisionServerContext : VisionDbContext
    {
        public DbSet<User> Users { get; private set; }

        public DbSet<Artist> Artists { get; private set; }

        public DbSet<Track> Tracks { get; private set; }

        public DbSet<Album> Albums { get; private set; }

        public DbSet<Repository> Repositories { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=music.db");
        }
    }
}
