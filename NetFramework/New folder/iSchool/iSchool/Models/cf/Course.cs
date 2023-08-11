using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class Course
    {
        [Key]
        public string Id { get; set; }
        public string SchoolYear_Id { get; set; }
        
        public string Title { get; set; }
        public string Credits { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<SchoolYear> SchoolYears { get; set; }
        public List<Staff_Course> Staffs_Courses { get; set; }

       
    }
}