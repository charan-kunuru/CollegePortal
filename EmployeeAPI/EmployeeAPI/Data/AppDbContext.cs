using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //key configurations
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);


            //unique constraints
            modelBuilder.Entity<User>()
           .HasIndex(u => u.RollNo)
           .IsUnique();

            //relationship configurations
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u=> u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId);


            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);






        }

    }
}
