namespace SchoolSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TeacherAttendance")]
    public partial class TeacherAttendance
    {
        public int Id { get; set; }

        public int? TeacherId { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
