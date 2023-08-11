using System;
using System.Web.UI;

namespace _2.WebFormsApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "";
                Calendar1.SelectedDate = DateTime.Now;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "You have clicked the button";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = "Selected Date: " + Calendar1.SelectedDate.ToLongDateString();
        }
    }
}