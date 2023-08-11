using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class Student
    {
        [Key]
        ////[DisplayName("Student ID")]
        ////[Required(ErrorMessage = "Please supply an student id.")]
        ////[Range(0, 50000, ErrorMessage = "Please supply a number between 0 and 50000")]
        public string Id { get; set; }
        /////////////////////////////////////////////////////////
        //[DisplayName("First Name")]
        //[Required(ErrorMessage = "Please supply a first name.")]
        //[StringLength(35, ErrorMessage = "first  names cannot exceed 35 characters")]
        //[DataType(DataType.Text)]
        public string FirstName { get; set; }
        /////////////////////////////////////////////////////////
        //[DisplayName("Last Name")]
        //[Required(ErrorMessage = "Please supply a last name.")]
        //[StringLength(35, ErrorMessage = "last  names cannot exceed 35 characters")]
        //[DataType(DataType.Text)]
        public string LastName { get; set; }
        /////////////////////////////////////////////////////////
        //[DisplayName("BirthDate")]
        //[DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please supply a BirthDate.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        /////////////////////////////////////////////////////////

        public string Grade { get; set; }
        /////////////////////////////////////////////////////////
        public virtual ICollection<Report> Report { get; set; }

    }
}