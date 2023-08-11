using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;

namespace SchoolSystem.Tokens
{
    public class MyAP : IAuthorizationPolicy
    {
        public string id;
        public ClaimSet myClaims;
        public ClaimSet myIssuer;

        public MyAP(ClaimSet claims)
        {
            this.myIssuer = claims.Issuer;
            this.myClaims = claims;
            this.id = Guid.NewGuid().ToString();


        }

        public ClaimSet Issuer
        {
            get { return this.myIssuer; }
        }

        public string Id
        {
            get { return this.id; }
        }

        public bool Evaluate(EvaluationContext eC, ref object state)
        {
            //eC.AddClaimSet(myClaims);
            return true;
        }
    }
}