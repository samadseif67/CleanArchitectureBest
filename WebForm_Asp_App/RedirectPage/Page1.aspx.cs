using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm_Asp_App.RedirectPage
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendParameter_Click(object sender, EventArgs e)
        {
            string name = txtName.Value;
            string family=txtFamily.Value;
            Response.Redirect($"Page2.aspx?name={name}&family={family}");
        }
    }
}