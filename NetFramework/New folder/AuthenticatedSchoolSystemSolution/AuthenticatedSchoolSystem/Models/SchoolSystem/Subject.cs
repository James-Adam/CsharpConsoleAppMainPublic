using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    [Table("Subject")]
    public class Subject
    {
        public Subject()
        {
            Exams = new HashSet<Exam>();
            Expenses = new HashSet<Expense>();
            StudentAttendances = new HashSet<StudentAttendance>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int SubjectId { get; set; }

        public int? ClassId { get; set; }

        [StringLength(50)] public string SubjectName { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}