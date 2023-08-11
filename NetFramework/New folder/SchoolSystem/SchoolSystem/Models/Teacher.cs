namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            TeacherAttendances = new HashSet<TeacherAttendance>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public int TeacherId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public long? Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Address { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
