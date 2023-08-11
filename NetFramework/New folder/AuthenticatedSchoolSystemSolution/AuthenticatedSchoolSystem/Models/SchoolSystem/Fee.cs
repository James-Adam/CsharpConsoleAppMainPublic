using System.ComponentModel.DataAnnotations;

namespace AuthenticatedSchoolSystem.Models.SchoolSystem
{
    public class Fee
    {
        [Key] public int FeesId { get; set; }

        public int? ClassId { get; set; }

        public int? FeesAmount { get; set; }

        public virtual Class Class { get; set; }
    }
}