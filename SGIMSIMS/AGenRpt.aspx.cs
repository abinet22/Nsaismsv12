using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AGenRpt : System.Web.UI.Page
    {
        string by, saleper;
        decimal cashathandbyord, cashathandbysale;
        DateTime fromdt;
        DateTime todt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Admin")
            {

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                showcrdrpt.Style["visibility"] = "hidden";
                showcrdrpt.Style["display"] = "none";

                Loadware();
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        private void Loadware()
        {

           
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNamewITHAD();
            DropDownListwarehouse.DataTextField = "AssignShop";
            DropDownListwarehouse.DataValueField = "AssignShop";


            DropDownListwarehouse.DataSource = warename.Tables[0];
            DropDownListwarehouse.DataBind();
            DropDownListwarehouse.Items.Insert(0, "-- Select Shop Name--");
            DropDownListwarehouse.Items[0].Value = "0";
        }
        protected void search(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue == "0" || DropDownListsmname.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxfromdt.Text) || string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                //error
            }
            else
            {
                todt = Convert.ToDateTime(TextBoxtodt.Text);
                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                saleper = DropDownListwarehouse.SelectedItem.ToString();
               by = DropDownListsmname.SelectedItem.ToString();
                LoadNewCustomers(fromdt, todt,by, saleper);
                LoadCashAtHand(fromdt, todt, by, saleper);
                LoadDailyOrder(fromdt, todt, by, saleper);
                LoadDailySale(fromdt, todt, by, saleper);
                detailreports(fromdt, todt, by, saleper);
            }
        }

       
        private void detailreports(DateTime fromdt, DateTime todt, string by, string saleper)
        {

            clsReport Dal2 = new clsReport();

            DataSet ds1 = Dal2.salecredit(fromdt, todt, by);
            if (ds1.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds1.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labelsalecredit.Text = Convert.ToString(totalamount);
            }
            else
            {

            }
            DataSet ds2 = Dal2.salecash(fromdt, todt, by);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labelsalecash.Text = Convert.ToString(totalamount);
            }
            else
            {

            }
            DataSet ds3 = Dal2.salebanktransfer(fromdt, todt, by);

            if (ds3.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds3.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labelsalebantrans.Text = Convert.ToString(totalamount);
            }
            else
            {

            }

           
            DataSet ds4 = Dal2.orderppcredit(fromdt, todt, by);
            if (ds4.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds4.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labelordppcredit.Text = Convert.ToString(totalamount);
            }
            else
            {

            }

            DataSet ds5 = Dal2.orderppcash(fromdt, todt, by);
            if (ds5.Tables[0].Rows.Count != 0)
            {
                decimal totalamounts = Convert.ToDecimal((ds5.Tables[0].Rows[0][0]));
                totalamounts = Math.Round(totalamounts, 2);
                Labelordppcash.Text = Convert.ToString(totalamounts);
                
            }
            else
            {

            }
            DataSet ds6 = Dal2.orderppbanktransfer(fromdt, todt, by);
            if (ds6.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds6.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labelordppbtrans.Text = Convert.ToString(totalamount);
            }
            else
            {

            }
          //  DateTime date6 = DateTime.Now.Date;
            DataSet ds7 = Dal2.dailyexpense(fromdt, todt, by);
            if (ds7.Tables[0].Rows.Count != 0)
            {
                decimal totalamount = Convert.ToDecimal((ds7.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                Labeldayexpense.Text = Convert.ToString(totalamount);
            }
            else
            {

            }
            decimal totcash = Convert.ToDecimal(Labelsalecash.Text) + Convert.ToDecimal(Labelordppcash.Text);
            Labelrevcash.Text = Convert.ToString(totcash);
            decimal totcredit = Convert.ToDecimal(Labelsalecredit.Text) + Convert.ToDecimal(Labelordppcredit.Text);
            Labelrevcredit.Text = Convert.ToString(totcredit);
            decimal totbanktrans = Convert.ToDecimal(Labelsalebantrans.Text) + Convert.ToDecimal(Labelordppbtrans.Text);
            Labelrevbanktrans.Text = Convert.ToString(totbanktrans);
            decimal totcashathands = Convert.ToDecimal(Labelsalecash.Text) + Convert.ToDecimal(Labelordppcash.Text) - Convert.ToDecimal(Labeldayexpense.Text);
            Labelcasand.Text = Convert.ToString(totcashathands);
        }

        private void LoadDailySale(DateTime fromdt, DateTime todt, string by, string saleper)
        {
           
          
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailySale(fromdt, todt, by);
            if (ds2.Tables[0].Rows.Count != 0)
            {

                decimal totalsale = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));

                decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][1]));
                totalamount = Math.Round(totalamount, 2);
                Label7.Text = Convert.ToString(totalamount);

                Labelnosalecount.Text = Convert.ToString(totalsale);
            }
            else
            {
                Label7.Text = "";
            }
        }

        private void LoadDailyOrder(DateTime fromdt, DateTime todt, string by, string saleper)
        {
           
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailyOrder(fromdt, todt, by);
            if (ds2.Tables[0].Rows.Count != 0)
            {

                decimal totalorder = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));

                decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][1]));
                totalamount = Math.Round(totalamount, 2);
                //Label16.Text = Convert.ToString(totalamount);
                Labelnoordsale.Text = Convert.ToString(totalorder);

            }
            else
            {
                Label16.Text = "";
            }
        }

        private void LoadCashAtHand(DateTime fromdt, DateTime todt, string by, string saleper)
        {
          
            clsOrderTPrice Dal = new clsOrderTPrice();
            DataSet ds = Dal.TotalCashAtHand(fromdt, todt, by);
            if (ds.Tables[0].Rows.Count != 0)
            {


                cashathandbyord = Convert.ToDecimal((ds.Tables[0].Rows[0][0]));

                Label16.Text = Convert.ToString(cashathandbyord);

            }
            else
            {
                cashathandbysale = 0;
            }
            clsSalesData Dal2 = new clsSalesData();
            DataSet ds2 = Dal2.TotalCashBySale(fromdt, todt, by);
            if (ds2.Tables[0].Rows.Count != 0)
            {


                cashathandbysale = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));

            }
            else
            {
                cashathandbysale = 0;
            }
            decimal cashathandtotal = cashathandbyord + cashathandbysale;
            cashathandtotal = Math.Round(cashathandtotal, 2);
            Labelcashathand.Text = Convert.ToString(cashathandtotal);
        }

        protected void showperrpt(object sender, EventArgs e)
        {   
            showcrdrpt.Style["visibility"] = "hidden";
            showcrdrpt.Style["display"] = "none";
            showpeidrrpt.Style["visibility"] = "visible";
            showpeidrrpt.Style["display"] = "block";
        }

        protected void showcdtrpt(object sender, EventArgs e)
        {
            showpeidrrpt.Style["visibility"] = "hidden";
            showpeidrrpt.Style["display"] = "none";
            showcrdrpt.Style["visibility"] = "visible";
            showcrdrpt.Style["display"] = "block";
        }

        protected void newcrdrptpage(object sender, GridViewPageEventArgs e)
        {

            GridViewcrdrpt.PageIndex = e.NewPageIndex;
            LoadCreditGrid();
        }

        private void LoadCreditGrid()
        {
            DateTime fromdtt = Convert.ToDateTime(TextBoxcrdfrom.Text);
            DateTime todtt = Convert.ToDateTime(TextBoxcrdto.Text);
            clsSalesData Dal = new clsSalesData();
            DataSet ba = Dal.ShowCreditAll(fromdtt,todtt);

            if (ba.Tables[0].Rows.Count != 0)
            {
                GridViewcrdrpt.DataSource = ba.Tables[0];
                Labeltotalcrd.Text = (GridViewcrdrpt.DataSource as DataTable).Rows.Count.ToString();
                GridViewcrdrpt.DataBind();

            }
        }

        protected void searchcrdrpt(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxcrdfrom.Text) && !string.IsNullOrWhiteSpace(TextBoxcrdto.Text))
            {
                LoadCreditGrid();
            }
            else
            {
                //error
            }
        }

        protected void loadusername(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0")
            {
                string shop = DropDownListwarehouse.SelectedItem.ToString();
                clsRowMaterial Dal = new clsRowMaterial();
                DataSet warename = Dal.FillUserNameshop(shop);
                DropDownListsmname.DataTextField = "UserName";
                DropDownListsmname.DataValueField = "UserName";


                DropDownListsmname.DataSource = warename.Tables[0];
                DropDownListsmname.DataBind();
                DropDownListsmname.Items.Insert(0, "-- Select--");
                DropDownListsmname.Items[0].Value = "0";
            }
        }
     
        private void LoadNewCustomers(DateTime fromdt, DateTime todt, string by, string saleper)
        {
         
            clsReport Dal = new clsReport();
            DataSet ds = Dal.TotalCustomer(fromdt, todt, by);
            if (ds.Tables[0].Rows.Count != 0)
            {

                decimal customer = Convert.ToDecimal((ds.Tables[0].Rows[0][0]));
                Labeltotalnewcustomer.Text = Convert.ToString(customer);

            }
            else
            {
                Labeltotalnewcustomer.Text = "No Vistors";
            }
        }
    }
}