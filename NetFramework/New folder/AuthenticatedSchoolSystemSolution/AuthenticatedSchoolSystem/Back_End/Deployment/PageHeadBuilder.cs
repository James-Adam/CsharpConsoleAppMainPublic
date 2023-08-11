using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AuthenticatedSchoolSystem.Back_End.Deployment
{
    public class PageHeadBuilder
    {
        protected virtual string GetBundleVirtualPath(string prefix, string extension, string[] parts)
        {
            if (parts == null || parts.Length == 0)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            //calculate hash
            string hash = ",";
            using (SHA256 sha = new SHA256Managed())
            {
                //string concatenation
                string hashInput = "";
                foreach (string part in parts)
                {
                    hashInput += part;
                    hashInput += ",";

                    byte[] input = sha.ComputeHash(Encoding.Unicode.GetBytes(hashInput));
                    hash = HttpServerUtility.UrlTokenEncode(input);
                }

                //ensure only valid chars
                //hash = SeoExtentions.GetSeName(hash);

                StringBuilder sb = new StringBuilder(prefix);
                _ = sb.Append(hash);

                return sb.ToString();
            }
        }
    }
}