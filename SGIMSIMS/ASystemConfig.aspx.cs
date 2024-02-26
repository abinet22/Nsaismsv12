using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ASystemConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["Userroll"].ToString() == "Admin")
            {
                Labelsession.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void neworderlistpage(object sender, GridViewPageEventArgs e)
        {

        }

        protected void selectandeditorder(object sender, EventArgs e)
        {

        }
    }
}