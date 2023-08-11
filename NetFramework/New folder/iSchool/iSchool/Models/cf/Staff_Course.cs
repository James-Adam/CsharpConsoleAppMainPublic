using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class Staff_Course
    {
        
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int CourseId{ get; set; }
        public Course Course { get; set; }
    
     }
}