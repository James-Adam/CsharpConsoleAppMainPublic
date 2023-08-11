using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class SchoolYear
    {
        [Key]
        public string ID { get; set; }
        public DateTime SchoolYear1 { get; set; }

        public List<Staff_Course> Staffs_Courses { get; set; }
    }
}