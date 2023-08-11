using System.Data.Entity;

namespace SchoolSystem.Models
{
    public partial class EntityContext : DbContext
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
        //public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> userAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAttendance>()
                .Property(e => e.RollNo)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
