using System.ComponentModel.DataAnnotations;

namespace IdentityManagementUsingSessionCookies.Models
{
    public class User
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
