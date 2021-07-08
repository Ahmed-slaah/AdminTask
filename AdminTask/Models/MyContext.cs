using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTask.Models
{
    public class MyContext:DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Company>companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("server=DESKTOP-80K6C1R\\SQLEXPRESS;database=AdminTask;trusted_connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Employees)
                .WithOne(c => c.company)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
