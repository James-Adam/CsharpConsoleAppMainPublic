namespace SchoolSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Exam")]
    public partial class Exam
    {
        public int ExamId { get; set; }

        public int? ClassId { get; set; }

        public int? SubjectId { get; set; }

        [StringLength(20)]
        public string RollNo { get; set; }

        public int? TotalMarks { get; set; }

        public int? OutOfMarks { get; set; }

        public virtual Class Class { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
