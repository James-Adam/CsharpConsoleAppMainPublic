using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace AuthenticatedSchoolSystem.Back_End.Tokens
{
    public class MySTA : SecurityTokenAuthenticator
    {
        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            return token is UserNameSecurityToken;
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
        {
            UserNameSecurityToken unToken = (UserNameSecurityToken)token;
            DefaultClaimSet claimSet1 = new DefaultClaimSet(ClaimSet.System,
                new Claim(ClaimTypes.Name, unToken.UserName, Rights.PossessProperty));
            DefaultClaimSet claimSet2 = new DefaultClaimSet(ClaimSet.System,
                new Claim(ClaimTypes.Gender, "Female", Rights.PossessProperty));
            List<IAuthorizationPolicy> p = new List<IAuthorizationPolicy>(2)
            {
                new MyAP(claimSet1),
                new MyAP(claimSet2)
            };
            return p.AsReadOnly();
        }
    }

    internal class MySCSTM : ServiceCredentialsSecurityTokenManager
    {
        private readonly ServiceCredentials creds;

        public MySCSTM(ServiceCredentials credentials) : base(credentials)
        {
            creds = credentials;
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(
            SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            outOfBandTokenResolver = null;
            return new MySTA();
        }
    }
}