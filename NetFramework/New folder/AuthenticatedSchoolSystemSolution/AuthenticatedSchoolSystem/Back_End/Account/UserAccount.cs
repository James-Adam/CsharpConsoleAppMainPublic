//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace AuthenticatedSchoolSystem.Back_End.Account
//{
//    public class UserAccount
//    {
//        [Key]
//        public int UserID { get; set; }
//        [Required(ErrorMessage = "Username is required.")]
//        public string UserName { get; set; }

// [Required(ErrorMessage = "Password is required.")] [DataType(DataType.Password)] public string
// Password { get; set; }

//        [Required(ErrorMessage = "Confirm Password is required.")]
//        [DataType(DataType.Password)]
//        [Compare("Password", ErrorMessage = "Your confirm password does not match")]
//        public string ConfirmPassword { get; set; }
//    }
//}

