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

        //Authentication and authorization
        public DbSet<User> Users { get; set; }

    


        // Academic structure
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        // Profiles
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

      



        // Many-to-many
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }



        // Operations
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Mark> Marks { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //key configurations
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);


            //unique constraints
            modelBuilder.Entity<User>()
           .HasIndex(u => u.UserName)
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

            //many-to-many relationships Teacher
           modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);


            //Mamy - many relationships Student
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
            .HasOne(ss => ss.Student)
            .WithMany(s => s.StudentSubjects)
            .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
            .HasOne(ss => ss.Subject)
            .WithMany(s => s.StudentSubjects)
            .HasForeignKey(ss => ss.SubjectId);

            ////Branch -Semester (One to many)
            modelBuilder.Entity<Semester>()
                .HasOne(S=> S.Branch)
                .WithMany(Branch => Branch.Semesters)
                .HasForeignKey(S => S.BranchId);

            // Semester → Subjects (One-to-Many)
            // ===============================
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Semester)
                .WithMany(se => se.Subjects)
                .HasForeignKey(s => s.SemesterId);

            //  Branch → Teachers (One-to-Many)
            // ===============================
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Branch)
                .WithMany(b => b.Teachers)
                .HasForeignKey(t => t.BranchId);

            // Branch → Students (One-to-Many) with Restrict
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Branch)
                .WithMany(b => b.Students)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Semester → Students (One-to-Many) with Restrict
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Semester)
                .WithMany(se => se.Students)
                .HasForeignKey(s => s.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);




            // Attendance Relationships
            // ===============================
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Subject)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.SubjectId);


            //  Fee Relationship
            // ===============================
            modelBuilder.Entity<Fee>()
                .HasOne(f => f.Student)
                .WithMany(s => s.Fees)
                .HasForeignKey(f => f.StudentId);

            // Feedback Relationships
            // ===============================
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Student)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Teacher)
                .WithMany(t => t.Feedbacks)
                .HasForeignKey(f => f.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Subject)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(f => f.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
            //Mark Relationships

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);




            // Fee amount precision
            modelBuilder.Entity<Fee>()
                .Property(f => f.Amount)
                .HasPrecision(10, 2);

            // Mark score precision
            modelBuilder.Entity<Mark>()
                .Property(m => m.Score)
                .HasPrecision(18, 2);

            //Keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Teacher>().HasKey(t => t.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

        }

    }
}
