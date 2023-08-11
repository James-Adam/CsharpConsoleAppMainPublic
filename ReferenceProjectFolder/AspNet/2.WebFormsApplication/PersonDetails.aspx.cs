using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.WebFormsApplication
{
    public partial class PersonDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddSalutation.DataSource = SalutationList();
                ddSalutation.DataBind();
            }
        }

        public IEnumerable<ListItem> SalutationList()
        {
            List<ListItem> SalutationList = new List<ListItem>
            {
                new ListItem("Mr.", "1"),
                new ListItem("Mrs.", "2"),
                new ListItem("Miss", "3"),
                new ListItem("Ms.", "4"),
                new ListItem("Dr.", "5")
            };

            return SalutationList;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Greetings " + ddSalutation.SelectedItem.Text + " " + txtFirstName.Text + " " +
                              txtLastName.Text;
        }
    }
}