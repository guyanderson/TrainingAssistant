using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelper.Models
{
    public class TrainingHelperDbContext : DbContext 
    {

        public TrainingHelperDbContext()
        {
        }

        public DbSet<Fab> Fab { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Bay> Bays { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Tool> Tools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TrainingHelper;integrated security=True");
        }

        public TrainingHelperDbContext(DbContextOptions<TrainingHelperDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
