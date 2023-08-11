namespace SchoolSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student
    {
        public int StudentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public long? Mobile { get; set; }

        [StringLength(50)]
        public string RollNo { get; set; }

        public string Address { get; set; }

        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
