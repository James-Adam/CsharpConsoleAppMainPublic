using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AuthenticatedSchoolSystem.Back_End.Tokens
{
    //Creating Custom Security Tokens
    public class MySTP : SecurityTokenProvider
    {
        private readonly X509Certificate2 myCert;

        public MySTP(X509Certificate2 cert)
        {
            myCert = cert;
        }

        protected override SecurityToken GetTokenCore(TimeSpan to)
        {
            return new X509SecurityToken(myCert);
        }
    }

    internal class MyCCSTM : ClientCredentialsSecurityTokenManager
    {
        private readonly ClientCredentials creds;

        public MyCCSTM(ClientCredentials cCred) : base(cCred)
        {
            creds = cCred;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement str)
        {
            return new MySTP(creds.ClientCertificate.Certificate);
        }
    }
}