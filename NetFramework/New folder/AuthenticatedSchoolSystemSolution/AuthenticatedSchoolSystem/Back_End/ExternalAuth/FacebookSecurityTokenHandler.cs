//using Microsoft.IdentityModel.Claims;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens;
//using System.Linq;
//using System.Security.Principal;
//using System.Web;

//namespace AuthenticatedSchoolSystem.Back_End.ExternalAuth
//{
//    public class FacebookSecurityTokenHandler : System.IdentityModel.Tokens.UserNameSecurityTokenHandler
//    {
//        private IIdentity nameClaims;
//        private readonly IIdentity test;

// public bool CanValidateToken { get { return true; } }

// public ClaimsIdentityCollection ValidateToken(System.IdentityModel.Tokens.SecurityToken token) {
// if (token == null) { throw new ArgumentNullException(); } UserNameSecurityToken UNtoken =
// (UserNameSecurityToken)token; if (nameClaims == null) { throw new
// System.IdentityModel.Tokens.SecurityTokenException("Invalid token"); }

// Claim claim = new Claim(ClaimTypes.Name, UNtoken.UserName);

// //Do work

// return new ClaimsIdentityCollection();

//        }
//    }
//}

