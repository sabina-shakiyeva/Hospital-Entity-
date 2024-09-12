using ConsoleApp6.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp6.Context
{
    public class HospitalDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pediatry> Pediatries { get; set; }
        public DbSet<Stamology> Stamologies { get; set; }
        public DbSet<Traumatology> Traumatologies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=STHQ0116-16;Initial Catalog=Hospital;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(dep => dep.Doctors)
                .HasForeignKey(d => d.DepartmentId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
