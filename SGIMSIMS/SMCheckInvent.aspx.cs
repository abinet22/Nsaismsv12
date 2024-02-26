using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMCheckInvent : System.Web.UI.Page
    {
        string ware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {

                Labelsession.Text = Session["UserName"].ToString();
                ware = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void search(object sender, EventArgs e)
        {
            if(DropDownListprotype.SelectedValue=="0")
            {

            }
            else
            {
                LoadAllCheckinvent();
               
            }
        }

        protected void Loadmatlstpage(object sender, GridViewPageEventArgs e)
        {

            GridViewmatlst.PageIndex = e.NewPageIndex;
            LoadAllCheckinvent();
        }

        private void LoadAllCheckinvent()
        {
            string protype = DropDownListprotype.SelectedItem.ToString();
            string byware = Session["UserName"].ToString();
            GridViewmatlst.DataSource = null;
            GridViewmatlst.DataBind();
            clsReport Dal = new clsReport();
            DataSet invent = Dal.AllCheckInvent(protype, byware);
            if (invent.Tables[0].Rows.Count != 0)
            {

                GridViewmatlst.DataSource = invent.Tables[0];
                GridViewmatlst.DataBind();

            }
            else
            {

            }
        }
    }
}