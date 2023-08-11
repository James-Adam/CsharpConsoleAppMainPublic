using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Cryptography;
using Microsoft.Web.Services2.Security.Tokens;
using System;

namespace AuthenticatedSchoolSystem.Back_End.Tokens
{
    //custom security token service class
    public class MyCustomSecurityToken : SecurityTokenService
    {
        protected override RequestSecurityTokenResponse IssueSecurityToken(SecurityTokenMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!(request is RequestSecurityToken))
            {
                throw new TrustFault(TrustFault.BadRequestMessage,
                    TrustFault.BadRequestCode,
                    new Exception("Throw error"));
            }

            UsernameToken issuedUserToken = new UsernameToken("test", "test");
            RequestSecurityTokenResponse requestSecurityTokenResponse =
                new RequestSecurityTokenResponse(issuedUserToken)
                {
                    RequestedProofToken = new RequestedProofToken(
                        ((SymmetricKeyAlgorithm)issuedUserToken.Key).KeyBytes,
                        RequestSigningToken)
                };

            return requestSecurityTokenResponse;
        }
    }
}