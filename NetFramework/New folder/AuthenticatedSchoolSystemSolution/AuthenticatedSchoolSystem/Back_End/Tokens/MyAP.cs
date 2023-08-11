using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;

namespace AuthenticatedSchoolSystem.Back_End.Tokens
{
    public class MyAP : IAuthorizationPolicy
    {
        public string id;
        public ClaimSet myClaims;
        public ClaimSet myIssuer;

        public MyAP(ClaimSet claims)
        {
            myIssuer = claims.Issuer;
            myClaims = claims;
            id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer => myIssuer;

        public string Id => id;

        public bool Evaluate(EvaluationContext eC, ref object state)
        {
            //eC.AddClaimSet(myClaims);
            return true;
        }
    }
}