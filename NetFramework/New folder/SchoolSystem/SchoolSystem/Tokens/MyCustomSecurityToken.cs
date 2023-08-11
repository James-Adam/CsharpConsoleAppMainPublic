
using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Cryptography;
using Microsoft.Web.Services2.Security.Tokens;
using System;

namespace SchoolSystem.Tokens
{
    //custom security token service class
    public class MyCustomSecurityToken : SecurityTokenService
    {
        protected override RequestSecurityTokenResponse IssueSecurityToken(SecurityTokenMessage myRequest)
        {
            if (myRequest == null)
                throw new ArgumentNullException("myRequest");

            RequestSecurityToken rst = myRequest as RequestSecurityToken;
            if (rst == null)
                throw new TrustFault(TrustFault.BadRequestMessage,
                    TrustFault.BadRequestCode,
                    new Exception("Throw error"));

            UsernameToken issuedUserToken = new UsernameToken("test", "test");
            RequestSecurityTokenResponse requestSecurityTokenResponse = new RequestSecurityTokenResponse(issuedUserToken);

            requestSecurityTokenResponse.RequestedProofToken = new RequestedProofToken(
                ((SymmetricKeyAlgorithm)issuedUserToken.Key).KeyBytes,
                base.RequestSigningToken);

            return requestSecurityTokenResponse;
        }

    }
}