using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    [Table("Teacher")]
    public class Teacher
    {
        public Teacher()
        {
            TeacherAttendances = new HashSet<TeacherAttendance>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int TeacherId { get; set; }

        [StringLength(50)] public string Name { get; set; }

        [Column(TypeName = "date")] public DateTime? DOB { get; set; }

        [StringLength(50)] public string Gender { get; set; }

        public long? Mobile { get; set; }

        [StringLength(50)] public string Email { get; set; }

        public string Address { get; set; }

        [StringLength(20)] public string Password { get; set; }

        public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}