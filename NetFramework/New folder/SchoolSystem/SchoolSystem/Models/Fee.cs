namespace SchoolSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Fee
    {
        [Key]
        public int FeesId { get; set; }

        public int? ClassId { get; set; }

        public int? FeesAmount { get; set; }

        public virtual Class Class { get; set; }
    }
}
