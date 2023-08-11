using System;
using System.Web;
using System.Web.UI;

namespace AuthenticatedSchoolSystem.Back_End.Products
{
    //<!-- //Defining a route to handle a url pattern-->
    public partial class ProductDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productName = HttpContext.Current.Request.RequestContext.RouteData.Values["productName"].ToString();
            lblOutput.Text = "you have selected " + productName;
        }
    }
}