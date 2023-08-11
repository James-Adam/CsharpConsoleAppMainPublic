using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcModel.Models
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        [Required(ErrorMessage = "Please supply an employee id.")]
        [Range(0, 50000, ErrorMessage = "Please supply a number between 0 and 50000")]
        public int Id { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Please supply an employee name.")]
        [StringLength(35, ErrorMessage = " Employee names cannot exceed 35 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Email Address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please supply a real email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}