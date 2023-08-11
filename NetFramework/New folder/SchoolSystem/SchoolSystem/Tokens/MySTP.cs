using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SchoolSystem.Tokens
{

    //Creating Custom Security Tokens
    public class MySTP : SecurityTokenProvider
    {
        X509Certificate2 myCert = null;

        public MySTP(X509Certificate2 cert)
        {
            this.myCert = cert;
        }

        protected override SecurityToken GetTokenCore(TimeSpan to)
        {
            return new X509SecurityToken(myCert);
        }
    }

    class MyCCSTM : ClientCredentialsSecurityTokenManager
    {
        ClientCredentials creds = null;

        public MyCCSTM(ClientCredentials cCred) : base(cCred)
        {
            this.creds = cCred;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement str)
        {
            return new MySTP(creds.ClientCertificate.Certificate);
        }
    }
}