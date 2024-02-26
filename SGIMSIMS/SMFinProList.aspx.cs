using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMFinProList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Buttsrchfinshorder_Click(object sender, EventArgs e)
        {
            GridViewFinOrdList.DataSource = null;
            GridViewFinOrdList.DataBind();
            LoadSearchKeyGird();
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        private void LoadSearchKeyGird()
        {
            string searchkey = TextBoxsearchkey.Text;
            string by = Session["UserName"].ToString();
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadFinishedOrderBySrchkey(searchkey ,by);

            if (Order.Tables[0].Rows.Count != 0)
            {
                GridViewFinOrdList.DataSource = Order.Tables[0];
                GridViewFinOrdList.DataBind();
                Labeltotalfinpro.Text = GridViewFinOrdList.Rows.Count.ToString();
            }
            else
            {
                Labeltotalfinpro.Text = "0";
            }
        }

        protected void LoadFinordLstpage(object sender, GridViewPageEventArgs e)
        {
            GridViewFinOrdList.PageIndex = e.NewPageIndex;
            LoadFinOrdLstGrid();
        }

        private void LoadFinOrdLstGrid()
        {
            string by = Session["UserName"].ToString();
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadFinishedOrder(by);

            if (Order.Tables[0].Rows.Count != 0)
            {
                GridViewFinOrdList.DataSource = Order.Tables[0];
                GridViewFinOrdList.DataBind();
                Labeltotalfinpro.Text = GridViewFinOrdList.Rows.Count.ToString();
              
            }
            else
            {
                Labeltotalfinpro.Text = "0";
          
            }
        }

        protected void loadallfinprolst(object sender, EventArgs e)
        {
            LoadFinOrdLstGrid();
        }
    }
}