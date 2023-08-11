using System;

namespace MvcModel.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}