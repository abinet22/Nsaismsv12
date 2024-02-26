using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace SGIMSIMS
{
    public partial class SMreports : System.Web.UI.Page
    {
        string by,solduser;
        decimal totalsale;
        decimal cashathandbyord;
        decimal cashathandbysale;
        string date;
        DateTime todt, fromdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                solduser= Session["UserBy"].ToString();
                date = DateTime.UtcNow.AddHours(3).ToShortDateString();
                by = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                LoadNewCustomers();
               
                LoadDailyOrder();
                LoadDailySale();
                LoadBankName();
                accountdtail.Style["visibility"] = "hidden";
                accountdtail.Style["display"] = "none";
                divMessage.Style["visibility"] = "hidden";
                divMessage.Style["display"] = "none";

                detailreports();
            }
            LoadCashAtHand();
            //Session["UserName"].ToString();
        }

        private void detailreports()
        {
          
            by = Session["UserName"].ToString();
            clsReport Dal2 = new clsReport();

            DataSet ds9 = Dal2.saleaddval(date, by, solduser);
            if (ds9.Tables[0].Rows.Count != 0)
            {

                if (ds9.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    Labeladdval.Text = "0";


                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds9.Tables[0].Rows[0][0] ?? 0));
                    totalamount = Math.Round(totalamount, 2);
                    //Labelsalecredit.Text = Convert.ToString(totalamount);
                    Labeladdval.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }





            DataSet ds1 = Dal2.salecredit(date, by,solduser);
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
            DataSet ds2 = Dal2.salecash(date, by,solduser);
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
            DataSet ds3 = Dal2.salebanktransfer(date, by,solduser);
          
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
            string date1 = DateTime.UtcNow.AddHours(3).ToShortDateString();

            DataSet ds4 = Dal2.orderppcredit(date1, by, solduser);
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
            DataSet ds5 = Dal2.orderppcash(date1, by,solduser);
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
            DataSet ds6 = Dal2.orderppbanktransfer(date1, by,solduser);
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
            DataSet ds7 = Dal2.dailyexpense(date6, by, solduser);
            if (ds7.Tables[0].Rows.Count != 0)
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
            decimal totcash= Convert.ToDecimal(Labelsalecash.Text) + Convert.ToDecimal(Labelordppcash.Text);
            Labelrevcash.Text = Convert.ToString(totcash);
            decimal totcredit = Convert.ToDecimal(Labelsalecredit.Text) + Convert.ToDecimal(Labelordppcredit.Text);
            Labelrevcredit.Text = Convert.ToString(totcredit);
            decimal totbanktrans = Convert.ToDecimal(Labelsalebantrans.Text) + Convert.ToDecimal(Labelordppbtrans.Text);
            Labelrevbanktrans.Text = Convert.ToString(totbanktrans);
            decimal totcashathands= Convert.ToDecimal(Labelsalecash.Text) + Convert.ToDecimal(Labelordppcash.Text)- Convert.ToDecimal(Labeldayexpense.Text);
            Labelcasand.Text = Convert.ToString(totcashathands);
        }

        private void LoadDailySale()
        {
         
           // by = Session["UserName"].ToString();
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailySale(date, by,solduser);
            if (ds2.Tables[0].Rows.Count != 0)
            {

              
                // Convert.ToString(totalsale) + " , "
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

        private void LoadBankName()
        {
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankBankName();
            DropDownListbankname.DataTextField = "BankName";
            DropDownListbankname.DataValueField = "BankName";


            DropDownListbankname.DataSource = ba.Tables[0];
            DropDownListbankname.DataBind();
            DropDownListbankname.Items.Insert(0, "--የባንክ ስም ምረጥ--");
            DropDownListbankname.Items[0].Value = "0";
        }

        private void LoadCashAtHand()
        {
            string date1 = DateTime.UtcNow.AddHours(3).ToShortDateString();

            clsOrderTPrice Dal = new clsOrderTPrice();
            DataSet ds = Dal.TotalCashAtHand(date1, by, solduser);
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
            DataSet ds2 = Dal2.TotalCashBySale(date, by, solduser);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    cashathandbysale = 0;
                }

                else

                {

                    //decimal cuncost = ds2.Tables[0].AsEnumerable().Sum(row => row.Field<decimal?>("CurrentCost") ?? 0);
                    //decimal disct = ds2.Tables[0].AsEnumerable().Sum(row => row.Field<decimal?>("Discount") ?? 0);

                    cashathandbysale = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
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
            by = Session["UserName"].ToString();
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
            by = Session["UserName"].ToString();
            clsReport Dal2 = new clsReport();

            DataSet ds2 = Dal2.FindDailyOrder(date, by, solduser);
            if (ds2.Tables[0].Rows.Count != 0)
            {

                
                 
                if (ds2.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelnoordsale.Text ="0";
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

        protected void addaccountdailycash(object sender, EventArgs e)
        {
           
            if(string.IsNullOrWhiteSpace(TextBoxamount.Text) || string.IsNullOrWhiteSpace(TextBoxaccno.Text) || string.IsNullOrWhiteSpace(TextBoxReceiptId.Text))
            {
                Labelalertonbtntopr.Text = "እባክዎት አስፈላጊ መረጃዎችን ያስገቡ";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else if(DropDownListbankname.SelectedValue== "0" ||  DropDownListholdrname.SelectedValue == "0" )
            {
                Labelalertonbtntopr.Text = "እባክዎት አስፈላጊ መረጃዎችን ያስገቡ";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {
                string date = DateTime.UtcNow.AddHours(3).ToShortDateString();
                string bywho = Session["UserName"].ToString();
                decimal amount = Convert.ToDecimal(TextBoxamount.Text);
                string bankname = DropDownListbankname.SelectedItem.ToString();
              
                string acctno = TextBoxaccno.Text;
                string transacid = TextBoxReceiptId.Text;
                string holdername = DropDownListholdrname.SelectedItem.ToString();

                clsBankAccount Dal = new clsBankAccount();
                Dal.Adddailytansaction(transacid, bankname, holdername, acctno, date, bywho, amount, solduser);
                Labelalertonbtntopr.Text = "ትዕዛዝዎ በትክክል ተከናውኖአል";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
                Clearallaftersave();
            }
           
        }

        private void Clearallaftersave()
        {
            TextBoxReceiptId.Text = "";
            TextBoxaccno.Text = "";
            DropDownListbankname.SelectedValue = "0";
           
            DropDownListholdrname.Items.Clear();
            TextBoxamount.Text = "";
            
        }

        protected void showctdtform(object sender, EventArgs e)
        {
            if (accountdtail.Style["visibility"] == "hidden" && accountdtail.Style["display"] == "none")
            {
                accountdtail.Style["visibility"] = "visible";
                accountdtail.Style["display"] = "block";
            }

            else if(accountdtail.Style["visibility"] == "visible" && accountdtail.Style["display"] == "block")
            {
                accountdtail.Style["visibility"] = "hidden";
                accountdtail.Style["display"] = "none";
            }
        

        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }


        protected void loadallholrname(object sender, EventArgs e)
        {
            string bankname = DropDownListbankname.SelectedItem.ToString();
          
            DropDownListholdrname.Items.Clear();
            Loadholdername(bankname);
            TextBoxaccno.Focus();

        }

        private void Loadholdername(string bankname)
        {
            if(DropDownListbankname.SelectedValue !="0")
            {
                clsBankAccount Dal = new clsBankAccount();
                DataSet ba = Dal.LoadBankBankBraAcct(bankname);

                DropDownListholdrname.DataSource = ba.Tables[0];

                DropDownListholdrname.DataTextField = "HolderName";
                DropDownListholdrname.DataValueField = "HolderName";

                DropDownListholdrname.DataBind();
                DropDownListholdrname.Items.Insert(0, "--የባለቤት ስም ምረጥ --");
                DropDownListholdrname.Items[0].Value = "0";
            }
         
            else
            {

            }
          
          
        }

        protected void peiodicsearch(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(TextBoxfromdt.Text) || string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                //error
            }
            else
            {
                todt = Convert.ToDateTime(TextBoxtodt.Text);
                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
             
               
                LoadNewCustomers(fromdt, todt, solduser, by);
                LoadCashAtHand(fromdt, todt, solduser, by);
                LoadDailyOrder(fromdt, todt, solduser, by);
                LoadDailySale(fromdt, todt, solduser, by);
                detailreports(fromdt, todt, solduser, by);
            }
        }

        private void detailreports(DateTime fromdt, DateTime todt, string by, string solduser)
        {
            clsReport Dal2 = new clsReport();

            DataSet ds1 = Dal2.salecredit(fromdt, todt, by);
            if (ds1.Tables[0].Rows.Count != 0)
            {
                if (ds1.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelsalecredit.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds1.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalecredit.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
            DataSet ds2 = Dal2.salecash(fromdt, todt, by);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                if (ds2.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelsalecash.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalecash.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
            DataSet ds3 = Dal2.salebanktransfer(fromdt, todt, by);

            if (ds3.Tables[0].Rows.Count != 0)
            {
                if (ds3.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelsalebantrans.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds3.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelsalebantrans.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }


            DataSet ds4 = Dal2.orderppcredit(fromdt, todt, by);
            if (ds4.Tables[0].Rows.Count != 0)
            {
                if (ds4.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelordppcredit.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds4.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppcredit.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }

            DataSet ds5 = Dal2.orderppcash(fromdt, todt, by);
            if (ds5.Tables[0].Rows.Count != 0)
            {
                if (ds5.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelordppcash.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds5.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppcash.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
            DataSet ds6 = Dal2.orderppbanktransfer(fromdt, todt, by);
            if (ds6.Tables[0].Rows.Count != 0)
            {
                if (ds6.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labelordppbtrans.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds6.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    Labelordppbtrans.Text = Convert.ToString(totalamount);
                }
            }
            else
            {

            }
           // DateTime date6 = DateTime.Now.Date;
            DataSet ds7 = Dal2.dailyexpense(fromdt, todt, by);
            if (ds7.Tables[0].Rows.Count != 0)
            {
                if (ds7.Tables[0].Rows[0][0] == DBNull.Value) //which is working properly

                {

                    //    Labeldayexpense.Text = "0";

                    Labeldayexpense.Text = "0";
                }

                else

                {
                    decimal totalamount = Convert.ToDecimal((ds7.Tables[0].Rows[0][0]));
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

        private void LoadDailySale(DateTime fromdt, DateTime todt, string by, string solduser)
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

        private void LoadDailyOrder(DateTime fromdt, DateTime todt, string by, string solduser)
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

        private void LoadCashAtHand(DateTime fromdt, DateTime todt, string by, string solduser)
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

        protected void exportrowmaterialsale(object sender, EventArgs e)
        {
            clsRMRequest ObjDal = new clsRMRequest();
           
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
         
            if (string.IsNullOrWhiteSpace(TextBoxfromdt.Text) || string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                //error
            }
            else
            {

                todt = Convert.ToDateTime(TextBoxtodt.Text);
                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);

                // string record = ConfigurationManager.AppSettings["UserRecord"];
                // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                try
                {

                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "RMSaleList" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    //dt2 = ObjDal.ExportAllRMReq(fromdt, todt);
                    dt2 = ObjDal.ExportRMSales(fromdt, todt, orderby, sentby);

                    int a = dt2.Rows.Count;
                    int RowsPerPage = Convert.ToInt32(a);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {

                        // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                        GridView gridView = new GridView();
                        gridView.AutoGenerateColumns = true;
                        gridView.ShowHeader = (i == 0);
                        // DataTable dtn = new DataTable();
                        gridView.DataSource = dt2;

                        gridView.DataBind();
                        gridView.RenderControl(htmlWriter);
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                        Response.ContentType = "application/ms-excel";
                        Response.Charset = "";
                        PageNumber = PageNumber + RowsPerPage;
                        //
                        i = PageNumber;
                    }
                    htmlWriter.Close();
                    Response.Write(writer.ToString());
                    Response.End();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void exportallsales(object sender, EventArgs e)
        {
            clsRMRequest ObjDal = new clsRMRequest();
          
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
            if (string.IsNullOrWhiteSpace(TextBoxfromdt.Text) || string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                //error
            }
            else
            {
                todt = Convert.ToDateTime(TextBoxtodt.Text);
                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
              
                // string record = ConfigurationManager.AppSettings["UserRecord"];
                // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                try
                {

                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "AllSaleList" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    //dt2 = ObjDal.ExportAllRMReq(fromdt, todt);
                    dt2 = ObjDal.ExportAllSales(fromdt, todt, orderby, sentby);

                    int a = dt2.Rows.Count;
                    int RowsPerPage = Convert.ToInt32(a);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {

                        // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                        GridView gridView = new GridView();
                        gridView.AutoGenerateColumns = true;
                        gridView.ShowHeader = (i == 0);
                        // DataTable dtn = new DataTable();
                        gridView.DataSource = dt2;

                        gridView.DataBind();
                        gridView.RenderControl(htmlWriter);
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                        Response.ContentType = "application/ms-excel";
                        Response.Charset = "";
                        PageNumber = PageNumber + RowsPerPage;
                        //
                        i = PageNumber;
                    }
                    htmlWriter.Close();
                    Response.Write(writer.ToString());
                    Response.End();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void LoadNewCustomers(DateTime fromdt, DateTime todt, string by, string solduser)
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

        protected void loadallaccountno(object sender, EventArgs e)
        {
            string bankname = DropDownListbankname.SelectedItem.ToString();
          
            string holder = DropDownListholdrname.SelectedItem.ToString();
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankAcctnoBNHN(bankname,holder);
            if (ba.Tables[0].Rows.Count != 0)
            {

                TextBoxaccno.Text = (ba.Tables[0].Rows[0][0]).ToString();
                TextBoxamount.Text = Labelcasand.Text;
            }
            else
            {

            }
        }
    }
}