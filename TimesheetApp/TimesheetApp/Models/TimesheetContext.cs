using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApp.Models
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext()
        {
        }

        public TimesheetContext(DbContextOptions<TimesheetContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ReportedTime> ReportedTime { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Password = "admin123",
                    FirstName = "Admin",
                    LastName = "Adminowski",
                    IsAdmin = true
                }
            );
        }
    }
}
