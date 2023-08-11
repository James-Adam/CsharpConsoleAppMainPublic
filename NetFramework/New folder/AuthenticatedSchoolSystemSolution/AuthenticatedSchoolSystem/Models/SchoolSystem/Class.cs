using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    [Table("Class")]
    public class Class
    {
        public Class()
        {
            Exams = new HashSet<Exam>();
            Expenses = new HashSet<Expense>();
            Fees = new HashSet<Fee>();
            Students = new HashSet<Student>();
            StudentAttendances = new HashSet<StudentAttendance>();
            Subjects = new HashSet<Subject>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int ClassId { get; set; }

        [StringLength(50)] public string ClassName { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Fee> Fees { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}