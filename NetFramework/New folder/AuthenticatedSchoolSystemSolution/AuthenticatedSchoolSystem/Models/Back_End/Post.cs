using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class Post
    {
        [AllowHtml] public string data { get; set; }
    }
}