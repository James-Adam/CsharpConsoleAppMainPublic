//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace AuthenticatedSchoolSystem.Back_End.ExternalAuth
//{
//    public class FacebookProviderAuthorizer : IOAuthProviderFacebookAuthorizer
//    {
//        #region Methods

// private AuthorizeState VerifyAuthentication(string returnUrl) { var authResult =
// this.FacebookApplication.VerifyAuthentication(_httpContext, GenerateLocalCallbackUri());

// if (authResult.IsSuccessful) { if (!authResult.ExtraData.ContainsKey("Id")) throw new
// Exception("authentication result does not contain id data");

// if (!authResult.ExtraData.ContainsKey("accesstoken")) throw new Exception("Authentication result
// does not contain accesstoken data");

// var parameters = new OAuthenticationParameters(Provider.SystemName) { ExternalIdentifier =
// authResult.ProviderUserId, OAuthToken = authResult.ExtraData["accesstoken"], OAuthAccessToken =
// authResult.ProviderUserId, }; if (_externalAuthenticationSettings.AutoRegisterEnabled)
// ParseClams(authResult, parameters);

// var result = _authorizer.Authorize(parameters);

// return new AuthorizeState(returnUrl, result); }

// var state = new AuthorizeState(returnUrl, OpenAuthenticationStatus.Error); var error =
// authResult.Error != null ? authResult.Error.Message : "Unknown error"; state.AddError(error);
// return state; }

// private object GenerateLocalCallbackUri() { throw new NotImplementedException(); }

// private void ParseClams(AuthenticationResult authenticationResult, OAuthenticationParameters
// parameters) { var claims = new UserClaims(); claims.Contact = new ContactClaims(); if
// (authenticationResult.ExtraData.ContainsKey("username")) { claims.Contact.Email =
// authenticationResult.ExtraData["username"]; } else { //request email claims.Contact.Email =
// RequestEmailFromFacebook(authenticationResult.ExtraData["accesstoken"]); } claims.Name = new
// NameClaims(); if (authenticationResult.ExtraData.ContainsKey("name")) { var name =
// authenticationResult.ExtraData["name"]; if (!String.IsNullOrEmpty(name)) { var nameSplit =
// name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); if (nameSplit.Length >= 2) {
// claims.Name.First = nameSplit[0]; claims.Name.Last = nameSplit[1]; } else { claims.Name.Last =
// nameSplit[0]; } } } parameters.AddClaim(claims); }

// private object RequestEmailFromFacebook(string v) { throw new NotImplementedException(); }

// private AuthorizeState RequestAuthentication() { throw new NotImplementedException(); }

// public AuthorizeState Authorize(string returnUrl, bool? verifyResponse = null) { if
// (!verifyResponse.HasValue) throw new ArgumentException("Facebook cannot automatically determine
// verifyResponse property");

// if (!verifyResponse.Value) return VerifyAuthentication(returnUrl);

// return RequestAuthentication();

// }

//        #endregion
//    }
//}

