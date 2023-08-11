using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public double AnnualSalary { get; set; }

        //Relationships
        public List<Staff_Course> Staffs_Courses { get; set; }

        

    }
}