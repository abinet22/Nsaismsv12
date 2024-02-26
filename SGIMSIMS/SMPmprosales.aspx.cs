using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMPmprosales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void Loadingof()
        {
            if (DropDownListProType.SelectedItem.ToString() == "PreManufuctured Product")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }

            else if (DropDownListProType.SelectedItem.ToString() == "RowMaterial")
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
                Panel3.Visible = false;
            }
            else if (DropDownListProType.SelectedItem.ToString() == "Service")
            {
                Panel2.Visible = false;
                Panel1.Visible = false;
                Panel3.Visible = true;
            }
            else
            {
                Panel3.Visible = false;
                Panel2.Visible = false;
                Panel1.Visible = false;
            }
        }

        protected void newsaleslistpage(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Buttsaveordersale_Click(object sender, EventArgs e)
        {

        }

        protected void viewpanel(object sender, EventArgs e)
        {
           

          
        }
    }
}