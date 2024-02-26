using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    
    public partial class ADayRpt : System.Web.UI.Page
    {
        string by,user;
       string date;
        decimal totalsale;
        decimal cashathandbyord;
        decimal cashathandbysale;
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
                Loadware();
              
            }
            
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
            if (DropDownListwarehouse.SelectedValue == "0" || DropDownListsmname.SelectedValue == "0" )
            {
                //error
            }
           
                LoadNewCustomers();
                LoadCashAtHand();
                LoadDailyOrder();
                LoadDailySale();
                detailreports();
            
       
        }

        private void detailreports()
        {
            by = DropDownListwarehouse.SelectedItem.ToString();
            user = DropDownListsmname.SelectedItem.ToString();
            date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            clsReport Dal2 = new clsReport();

            DataSet ds9 = Dal2.saleaddrev(date, by, user);
            if (ds9.Tables[0].Rows.Count != 0)
            {
                if (ds9.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labeladdrev.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds9.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labeladdrev.Text = Convert.ToString(totalamount);
                   
                }
            }
            else
            {

            }

            DataSet ds1 = Dal2.salecredit(date, by,user);
            if (ds1.Tables[0].Rows.Count != 0)
            {
                if (ds1.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelsalecredit.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds1.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalecredit.Text = Convert.ToString(totalamount);

                }
            }
            else
            {

            }
            DataSet ds2 = Dal2.salecash(date, by,user);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                if (ds2.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelsalecash.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalecash.Text = Convert.ToString(totalamount);

                }
            }
            else
            {

            }
            DataSet ds3 = Dal2.salebanktransfer(date, by,user);

            if (ds3.Tables[0].Rows.Count != 0)
            {
                if (ds3.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelsalebantrans.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds3.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalebantrans.Text = Convert.ToString(totalamount);

                }
            }
            else
            {

            }
           // string date1 = DateTime.UtcNow.AddHours(3).ToShortDateString();

            DataSet ds4 = Dal2.orderppcredit(date, by,user);
            if (ds4.Tables[0].Rows.Count != 0)
            {
                if (ds4.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelordppcredit.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds4.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppcredit.Text = Convert.ToString(totalamount);

                }
            }
            else
            {

            }
            DataSet ds5 = Dal2.orderppcash(date, by,user);
            if (ds5.Tables[0].Rows.Count != 0)
            {
                if (ds5.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelordppcash.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds5.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppcash.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
            DataSet ds6 = Dal2.orderppbanktransfer(date, by,user);
            if (ds6.Tables[0].Rows.Count != 0)
            {
                if (ds1.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labelordppbtrans.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds6.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppbtrans.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
            DateTime date6 = DateTime.UtcNow.AddHours(3);
            DataSet ds7 = Dal2.dailyexpense(date6, by,user);
            if (ds6.Tables[0].Rows.Count != 0)
            {
                if (ds7.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labeldayexpense.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds7.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Labeldayexpense.Text = Convert.ToString(totalamount);
                }
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

        private void LoadDailySale()
        {

            by = DropDownListwarehouse.SelectedItem.ToString();
            user = DropDownListsmname.SelectedItem.ToString();
            date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailySale(date, by,user);
            if (ds2.Tables[0].Rows.Count != 0)
            {

                if (ds2.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labeldayexpense.Text = "0";


                }

                else

                {
                    totalsale = Convert.ToDecimal((ds2.Tables[0].Rows[0][0] ?? 0));

                    decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][1] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    Label7.Text = Convert.ToString(totalamount);
                    Labelnosalecount.Text = Convert.ToString(totalsale);
                }
            }
            else
            {
                Label7.Text = "";
            }
        }



        private void LoadCashAtHand()
        {
            string date1 = DateTime.UtcNow.AddHours(3).ToShortDateString();
            by = DropDownListwarehouse.SelectedItem.ToString();
            user = DropDownListsmname.SelectedItem.ToString();
            clsOrderTPrice Dal = new clsOrderTPrice();
            DataSet ds = Dal.TotalCashAtHand(date1, by,user);
            if (ds.Tables[0].Rows.Count != 0)
            {

                if (ds.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //  Labeldayexpense.Text = "0";

                    Label16.Text = "0";
                }

                else

                {

                    cashathandbyord = Convert.ToDecimal((ds.Tables[0].Rows[0][0]));

                    Label16.Text = Convert.ToString(cashathandbyord);
                }

            }
            else
            {
                Label16.Text = "0";
            }

            clsSalesData Dal2 = new clsSalesData();
            DataSet ds2 = Dal2.TotalCashBySale(date1, by,user);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    cashathandbysale = 0;
                }

                else

                {

                  
                    cashathandbysale =  Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
                }


            }
            else
            {
                cashathandbysale = 0;
            }
            decimal cashathandtotal = cashathandbyord + cashathandbysale;
            cashathandtotal = Math.Round(cashathandtotal, 2);
            Labelcashathand.Text = Convert.ToString(cashathandtotal);
        }



        private void LoadNewCustomers()
        {
            string date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            by = DropDownListwarehouse.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet ds = Dal.TotalCustomer(date, by);
            if (ds.Tables[0].Rows.Count != 0)
            {
                decimal customer = Convert.ToDecimal((ds.Tables[0].Rows[0][0] ?? 0));
                Labeltotalnewcustomer.Text = Convert.ToString(customer);

            }
            else
            {
                Labeltotalnewcustomer.Text = "No Vistors";
            }
        }

        public void LoadDailyOrder()
        {
            string date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            by = DropDownListwarehouse.SelectedItem.ToString();
            user = DropDownListsmname.SelectedItem.ToString();
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailyOrder(date, by,user);
            if (ds2.Tables[0].Rows.Count != 0)
            {

                if (ds2.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelnoordsale.Text = "0";
                }

                else

                {

                    decimal totalorder = Convert.ToDecimal((ds2.Tables[0].Rows[0][0] ?? 0));

                    decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][1] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    //    Label16.Text = Convert.ToString(totalamount);
                    //   Labelnosalecount.Text = Convert.ToString(totalsale);
                    Labelnoordsale.Text = Convert.ToString(totalorder);
                }
            }
            else
            {
                Label16.Text = "";
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void loadallalesname(object sender, EventArgs e)
        {
            if(DropDownListwarehouse.SelectedValue!="0")
            {
                string shop = DropDownListwarehouse.SelectedItem.ToString();
                clsRowMaterial Dal = new clsRowMaterial();
                DataSet warename = Dal.FillUserNameshop(shop);
                DropDownListsmname.DataTextField = "UserName";
                DropDownListsmname.DataValueField = "UserName";


                DropDownListsmname.DataSource = warename.Tables[0];
                DropDownListsmname.DataBind();
                DropDownListsmname.Items.Insert(0, "-- Select Sales Person--");
                DropDownListsmname.Items[0].Value = "0";
            }
            
        }
    }
}