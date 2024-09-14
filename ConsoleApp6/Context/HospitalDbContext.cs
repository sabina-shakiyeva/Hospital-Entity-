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
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KBFH69R7;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(dep => dep.Doctors)
                .HasForeignKey(d => d.DepartmentId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pediatry>()
                .ToTable("Pediatries");

            modelBuilder.Entity<Stamology>()
                .ToTable("Stamologies");
            modelBuilder.Entity<Traumatology>()
                .ToTable("Traumatologies");
        }

    }
}
