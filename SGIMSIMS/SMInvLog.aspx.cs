using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMInvLog : System.Web.UI.Page
    {

        decimal qty;
        string brand;
        string gage;
        string ware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {

             Labelsession.Text = Session["UserName"].ToString();
                ware  = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {

                loadbrand();

            }
            LoadGridViewmatlst();
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        private void loadgage(string brand)
        {
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListprogage.DataTextField = "ProductGage";
            DropDownListprogage.DataValueField = "ProductGage";
            DropDownListprogage.DataSource = progage.Tables[0];
            DropDownListprogage.DataBind();
            DropDownListprogage.Items.Insert(0, "--የጥሬ እቃ ጌጅ--");
            DropDownListprogage.Items[0].Value = "0";
        }

        private void loadbrand()
        {
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListprobrand.DataTextField = "ProductBrand";
            DropDownListprobrand.DataValueField = "ProductBrand";
            DropDownListprobrand.DataSource = probrand.Tables[0];
            DropDownListprobrand.DataBind();
            DropDownListprobrand.Items.Insert(0, "--የጥሬ እቃ አይነት--");
            DropDownListprobrand.Items[0].Value = "0";
        }

        protected void addmatlst(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBoxmatlength.Text) || string.IsNullOrWhiteSpace(TextBoxmatwidth.Text))
            {

            }
            if (DropDownListprobrand.SelectedValue == "0" || DropDownListprogage.SelectedValue == "0")
            {

            }

            else
            {
                brand = DropDownListprobrand.SelectedItem.ToString();
                gage = DropDownListprogage.SelectedItem.ToString();
                decimal width = Convert.ToDecimal(TextBoxmatwidth.Text);
                decimal length = Convert.ToDecimal(TextBoxmatlength.Text);

                qty = width * length;
                checkavalbty(brand, gage);
                LoadGridViewmatlst();
                Clear();
            }



        }

        private void checkavalbty(string brand, string gage)
        {
            if (string.IsNullOrWhiteSpace(TextBoxmatlength.Text) || string.IsNullOrWhiteSpace(TextBoxmatlength.Text) || DropDownListprobrand.SelectedValue == "0" || DropDownListprogage.SelectedValue == "0")
            {
                //error
            }

            clsRMCount dal = new clsRMCount();
            DataSet ds = dal.Checkavalty(brand, gage,ware);

            if (ds.Tables[0].Rows.Count != 0)
            {

                decimal qtyav = Convert.ToDecimal((ds.Tables[0].Rows[0]["QtyMxM"]).ToString());

                decimal width = Convert.ToDecimal(TextBoxmatwidth.Text);
                decimal length = Convert.ToDecimal(TextBoxmatlength.Text);

                decimal qtyu = width * length;
                decimal qantudt = qtyu + qtyav;
                clsRMCount dal3 = new clsRMCount();
                dal3.Updatermlst(brand, gage, qantudt, ware);
                LoadGridViewmatlst();
                //clsRMCount dal2 = new clsRMCount();
                //dal2.AddRMCount(brand, gage, qtyu);
                Clear();

            }

            else
            {

                if (string.IsNullOrWhiteSpace(TextBoxmatlength.Text))
                {

                }
                else
                {
                    decimal width = Convert.ToDecimal(TextBoxmatwidth.Text);
                    decimal length = Convert.ToDecimal(TextBoxmatlength.Text);

                    qty = width * length;
                    clsRMCount dal2 = new clsRMCount();
                    dal2.AddRMCount(brand, gage, qty, ware);
                    LoadGridViewmatlst();
                    Clear();
                }


            }
        }

        private void Clear()
        {
          
            TextBoxmatlength.Text = "";
            TextBoxmatwidth.Text = "";
            DropDownListprobrand.SelectedValue = "0";
            DropDownListprogage.SelectedValue = "0";
        }

        protected void dltmatdatalst(object sender, EventArgs e)
        {
            clsRMCount dal3 = new clsRMCount();
            dal3.deleteall(ware);
            GridViewmatlst.DataSource = null;
            GridViewmatlst.DataBind();
            LoadGridViewmatlst();
        }

        protected void Loadmatlstpage(object sender, GridViewPageEventArgs e)
        {
            GridViewmatlst.PageIndex = e.NewPageIndex;
            LoadGridViewmatlst();
        }

        private void LoadGridViewmatlst()
        {
            clsRMCount dal2 = new clsRMCount();
            DataSet ds = dal2.Loadmatlst(ware);
            if (ds.Tables[0].Rows.Count != 0)
            {
                GridViewmatlst.DataSource = ds.Tables[0];
                GridViewmatlst.DataBind();

            }
        }

        protected void Loadmatlst(object sender, EventArgs e)
        {



        }

        protected void loadbrandgages(object sender, EventArgs e)
        {
            string brand = DropDownListprobrand.SelectedItem.ToString();
            DropDownListprogage.Items.Clear();
            loadgage(brand);
        }
    }
}