using System.Data.Entity;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=SchoolSystemConnectionString")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Class>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Exam>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Student>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsUnicode(false);

            _ = modelBuilder.Entity<StudentAttendance>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Teacher>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Teacher>()
                .Property(e => e.Address)
                .IsUnicode(false);

            _ = modelBuilder.Entity<Teacher>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}