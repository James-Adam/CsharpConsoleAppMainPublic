using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticatedSchoolSystem.Models.HR
{
    public class Employee
    {
        [Key] public string firstName { get; set; }

        public string lastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Salary { get; set; }
    }
}