using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    [Table("StudentAttendance")]
    public class StudentAttendance
    {
        public int Id { get; set; }

        public int? ClassId { get; set; }

        public int? SubjectId { get; set; }

        [StringLength(20)] public string RollNo { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")] public DateTime? Date { get; set; }

        public virtual Class Class { get; set; }

        public virtual Subject Subject { get; set; }
    }
}