using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMreports : System.Web.UI.Page
    {
        string by;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                by = Session["UserName"].ToString();

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
           
            
            if (!IsPostBack)
            {
                LoadDailyreport();
                loadallbrand();
            }
        }

        private void loadallbrand()
        {


            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrand.DataTextField = "ProductBrand";
            DropDownListbrand.DataValueField = "ProductBrand";
            DropDownListbrand.DataSource = probrand.Tables[0];
            DropDownListbrand.DataBind();
            DropDownListbrand.Items.Insert(0, "--የጥሬ ዕቃ ስም ምረጥ--");
            DropDownListbrand.Items[0].Value = "0";
        }

        private void loadallgages(string brand)
        {

            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListgage.DataTextField = "ProductGage";
            DropDownListgage.DataValueField = "ProductGage";
            DropDownListgage.DataSource = progage.Tables[0];
            DropDownListgage.DataBind();
            DropDownListgage.Items.Insert(0, "--የጥሬ ዕቃ ጌጅ ምረጥ--");
            DropDownListgage.Items[0].Value = "0";
        }

        private void LoadDailyreport()
        {
            string date = DateTime.Now.ToShortDateString();
            by = Session["UserName"].ToString();
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailyWIP(date,by);
            if (ds2.Tables[0].Rows.Count != 0)
            {
               
                decimal ft = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
                Label4.Text = Convert.ToString(ft);
            }
            else
            {

            }
            clsReport Dal3 = new clsReport();
            DataSet ds3 = Dal3.FindDailyF(date,by);
            if (ds3.Tables[0].Rows.Count != 0)
            {
                decimal wipt = Convert.ToDecimal((ds3.Tables[0].Rows[0][0]));
                Label15.Text = Convert.ToString(wipt);
            }
            else
            {

            }
            clsReport Dal4 = new clsReport();
            DataSet ds4 = Dal4.FindAllWIP(date,by);
            if (ds4.Tables[0].Rows.Count != 0)
            {
                decimal sft = Convert.ToDecimal((ds4.Tables[0].Rows[0][0]));
                Label14.Text = Convert.ToString(sft);
            }
            else
            {

            }
        }

        protected void generateRpt(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxfrmdt.Text) || string.IsNullOrWhiteSpace(TextBoxtodate.Text) ||  DropDownListbrand.SelectedValue == "0" || DropDownListgage.SelectedValue == "0")
            {
                //error
            }
            else
            {
                DateTime fromdate = Convert.ToDateTime(TextBoxfrmdt.Text);
                DateTime fromto = Convert.ToDateTime(TextBoxtodate.Text);
                string brand = DropDownListbrand.SelectedItem.ToString();
                string gage = DropDownListgage.SelectedItem.ToString();
                string warehouse = Session["UserName"].ToString();
                loadreportsbydate(fromdate, fromto, warehouse, brand, gage);
            }

        

          
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");

        }

        protected void ProbrandSelectedIndex(object sender, EventArgs e)
        {
            string brand = DropDownListbrand.SelectedItem.ToString();
            loadallgages(brand);
        }

        protected void ProdgageSelectedIndex(object sender, EventArgs e)
        {
           
        }

        private void loadreportsbydate(DateTime fromdate, DateTime fromto, string warehouse, string brand, string gage)
        {
            clsReport dal2 = new clsReport();
            DataSet ds2 = dal2.FindMonthlyWorkShopRpt(fromdate, fromto, warehouse, brand, gage);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                
                Label12.Text = Convert.ToString(ds2.Tables[0].Rows[0].Field<decimal>(0)) + " " + "M \xB2";
                //Convert.ToString(ff);
            }
            else
            {
                Label11.Text = "";
            }
            clsReport dal3 = new clsReport();
            DataSet ds3 = dal3.FindMonthlyWorkShopaddRpt(fromdate, fromto, warehouse, brand, gage);
            if (ds3.Tables[0].Rows.Count != 0)
            {
                // Convert.ToString(ds.Tables[0].Columns["Bname"]);
                // decimal fff = Convert.ToDecimal((ds3.Tables[0].Rows[0][0].ToString()));
                
                Label11.Text = Convert.ToString(ds3.Tables[0].Rows[0].Field<decimal>(0)) + " " + "M \xB2";
                //Convert.ToString(fff);     
            }
            else
            {
                Label11.Text = "";
            }
            clsReport dal4 = new clsReport();
            DataSet ds4 = dal4.FindMonthlyrmathandRpt(warehouse, brand, gage);
            if (ds4.Tables[0].Rows.Count != 0)
            {
           
                decimal fe = ds4.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("RMaterialQty"));

                Label5.Text = Convert.ToString(fe) + " " + "M \xB2";
            }
            else
            {
                Label5.Text = "";
            }
            clsReport dal5 = new clsReport();
            DataSet ds5 = dal5.FindMonthMatUsed(fromdate, fromto, brand, gage, by);
            if (ds5.Tables[0].Rows.Count != 0)
            {

                string fe = Convert.ToString(ds5.Tables[0].Rows[0].Field<decimal>(0));

                Label6.Text = fe +" "+ "M \xB2";
            }
            else
            {
                Label6.Text = "";
            }
        }
    }
}