//using Microsoft.IdentityModel.Claims;
//using System;
//using System.IdentityModel.Tokens;
//using System.Security.Principal;

//namespace SchoolSystem.ExternalAuth
//{
//    public class FacebookSecurityTokenHandler : UserNameSecurityTokenHandler
//    {
//        private IIdentity nameClaims;
//        private readonly IIdentity test;

//        public bool CanValidateToken
//        {
//            get { return true; }
//        }

//        public ClaimsIdentityCollection ValidateToken(SecurityToken token)
//        {
//            if (token == null)
//            {
//                throw new ArgumentNullException();
//            }
//            UserNameSecurityToken UNtoken = (UserNameSecurityToken)token;
//            if (nameClaims == null)
//            {
//                throw new SecurityTokenException("Invalid token");
//            }

//            Claim claim = new Claim(ClaimTypes.Name, UNtoken.UserName);

//            //Do work

//            return new ClaimsIdentityCollection();


//        }
//    }
//}