using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

    }
}