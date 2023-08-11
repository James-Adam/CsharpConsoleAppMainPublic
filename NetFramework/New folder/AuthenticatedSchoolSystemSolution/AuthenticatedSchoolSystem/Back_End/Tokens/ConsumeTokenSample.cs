using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Tokens;
using System;
using System.Text;

namespace AuthenticatedSchoolSystem.Back_End.Tokens
{
    public class ConsumeTokenSample
    {
        public void TestConsumtion()
        {
            string username = Environment.UserName;
            byte[] passworBytes = GetPassword();
            string passwordTest = Convert.ToBase64String(passworBytes);
            SecurityToken myToken = new UsernameToken(username, passwordTest, PasswordOption.SendHashed);

            SecurityTokenServiceClient client =
                new SecurityTokenServiceClient(new Uri("http://localhost/TokenService/myLink.asmx"));

            RequestSecurityToken secureToken;
            secureToken = new RequestSecurityToken("http://theTargetSite", myToken,
                "http://localhost/TokenService/myLinkService.ashx");
            //client.RequestSigningToken = myToken;

            _ = client.IssueSecurityToken(secureToken);
        }

        public byte[] GetPassword()
        {
            return Encoding.ASCII.GetBytes("password");
        }
    }
}