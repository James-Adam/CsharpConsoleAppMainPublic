using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.OptimizationEncryption
{
    public static class URLEncrypt
    {
        public static MvcHtmlString MyActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName) //Correct
        {
            StringBuilder a = new StringBuilder();

            _ = a.Append("<a href='");
            if (controllerName.Length > 0)
            {
                _ = a.Append("/");
                _ = a.Append(controllerName);
            }

            if (actionName != "Index")
            {
                _ = a.Append("/");
                _ = a.Append(actionName);
            }

            _ = a.Append("?q=");
            _ = a.Append(Encrypt("myPlainTextStringToBeEncrypted"));
            _ = a.Append("'>");
            _ = a.Append(linkText);
            _ = a.Append("</a>");

            return new MvcHtmlString(a.ToString());
        }

        private static string Encrypt(string plainText) //correct
        {
            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            byte[] EK = Encoding.UTF8.GetBytes("myVerySecureEncryptKey!!");
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] inp = Encoding.UTF8.GetBytes(plainText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(EK, IV), CryptoStreamMode.Write);
            cs.Write(inp, 0, inp.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string eqs = HttpContext.Current.Request.QueryString.Get("q");
            if (!string.IsNullOrEmpty(eqs))
            {
                string qs = Decrypt(eqs);
                filterContext.ActionParameters["q"] = qs;
            }
            else
            {
                filterContext.ActionParameters["q"] = string.Empty;
            }

            base.OnActionExecuting(filterContext);
        }

        private static string Decrypt(string encryptedText)
        {
            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            byte[] DK = Encoding.UTF8.GetBytes("myVerySecureEncryptKey!!");
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] inp = Encoding.UTF8.GetBytes(encryptedText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(DK, IV), CryptoStreamMode.Write);
            cs.Write(inp, 0, inp.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    public static class MyHash
    {
        public static MvcHtmlString MyHashActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName)
        {
            StringBuilder a = new StringBuilder();

            _ = a.Append("<a href='");
            if (controllerName.Length > 0)
            {
                _ = a.Append("/");
                _ = a.Append(controllerName);
            }

            if (actionName != "Index")
            {
                _ = a.Append("/");
                _ = a.Append(actionName);
            }

            _ = a.Append("?q=myPlainTextStringToBeHashed&hash=");
            _ = a.Append(Hash("myPlainTextStringToBeHashed"));
            _ = a.Append("'>");
            _ = a.Append(linkText);
            _ = a.Append("</a>");

            return new MvcHtmlString(a.ToString());
        }

        public static string Hash(string hashIt)
        {
            byte[] HK = Encoding.UTF8.GetBytes("MyVerySecureEncryptKey!!");
            HMACSHA1 hash = new HMACSHA1(HK);

            _ = hash.ComputeHash(Encoding.UTF8.GetBytes(hashIt));
            return Convert.ToBase64String(hash.Hash);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyHashActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string qs = HttpContext.Current.Request.QueryString.Get("q");
            string oHash = HttpContext.Current.Request.QueryString.Get("hash");
            if (!string.IsNullOrEmpty(qs) && !string.IsNullOrEmpty(oHash))
            {
                string nHash = MyHash.Hash(qs);
                filterContext.ActionParameters["q"] = qs;
                filterContext.ActionParameters["hash"] = oHash == nHash
                    ? "parameter q is good."
                    : (object)"parameter q has been tampered with.";
            }
            else
            {
                filterContext.ActionParameters["q"] = string.Empty;
                filterContext.ActionParameters["hash"] = string.Empty;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}