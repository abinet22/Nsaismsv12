using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ABankAccount : System.Web.UI.Page
    {
        DateTime todt, fromdt;
        string byy;
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
                showaccttrans.Style["visibility"] = "hidden";
                showaccttrans.Style["display"] = "none";
                LoadAccountGrid();
                Loadware();
            }
        }
        private void Loadware()
        {
            string userroll = "Sales Manager";
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserName(userroll);
            DropDownListwarehouse.DataTextField = "AssignShop";
            DropDownListwarehouse.DataValueField = "AssignShop";


            DropDownListwarehouse.DataSource = warename.Tables[0];
            DropDownListwarehouse.DataBind();
            DropDownListwarehouse.Items.Insert(0, "-- Select--");
            DropDownListwarehouse.Items[0].Value = "0";

        }
        protected void BankAccountgenID(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 2);


            TextBoxbaccid.Text = "BankAcct" + '-' + guid;
           
        }

        protected void AddBacct(object sender, EventArgs e)
        {
            clsBankAccount dal = new clsBankAccount();
            BankAccount obj = Intializeobject();
            dal.AddNewAccount(obj);
            clearaftersave();
            LoadAccountGrid();
        }

        private void clearaftersave()
        {
            TextBoxbaccid.Text = "";
            TextBoxbankname.Text= "";
            TextBoxbrachname.Text= "";
            TextBoxacctno.Text = "";
            DropDownListaccttype.SelectedValue = "0";
            DropDownListacchead.SelectedValue = "0";
            TextBoxopbalnce.Text = "";
            TextBoxholrname.Text = "";
        }

        private BankAccount Intializeobject()
        {
            BankAccount ba = new BankAccount();

            ba.AccountId = TextBoxbaccid.Text;
            ba.BankName = TextBoxbankname.Text;
            ba.BranchName = TextBoxbrachname.Text;
            ba.AccountNumber = TextBoxacctno.Text;
            ba.AccountType = DropDownListaccttype.SelectedItem.ToString();
            ba.AccountHead = DropDownListacchead.SelectedItem.ToString();
            ba.AccountBalance = Convert.ToDecimal(TextBoxopbalnce.Text);
            ba.HolderName = TextBoxholrname.Text;

            return ba;
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
       
        protected void Dlbacct(object sender, EventArgs e)
        {

        }

        protected void newserlistpage(object sender, GridViewPageEventArgs e)
        {
            GridViewbankacctlst.PageIndex = e.NewPageIndex;
            LoadAccountGrid();
        }

        private void LoadAccountGrid()
        {
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankAccount();

            if (ba.Tables[0].Rows.Count != 0)
            {
               GridViewbankacctlst.DataSource = ba.Tables[0];
              GridViewbankacctlst.DataBind();

            }
        }

        protected void selectandeditser(object sender, EventArgs e)
        {
           
            GridViewRow row = GridViewbankacctlst.SelectedRow;
            TextBoxbaccid.Text = row.Cells[1].ToString();
            TextBoxbankname.Text = row.Cells[2].ToString();
            TextBoxbrachname.Text = row.Cells[3].ToString();
            TextBoxacctno.Text = row.Cells[7].ToString();
            DropDownListaccttype.SelectedValue = row.Cells[5].ToString();
            DropDownListacchead.SelectedValue = row.Cells[4].ToString();
            TextBoxopbalnce.Text = row.Cells[8].ToString();
            TextBoxholrname.Text = row.Cells[6].ToString();
        }

        protected void showaddacct(object sender, EventArgs e)
        {
          
            addacct.Style["visibility"] = "visible";
            addacct.Style["display"] = "block";
            showaccttrans.Style["visibility"] = "hidden";
            showaccttrans.Style["display"] = "none";
           
            Labelheader.Text = "Bank Account List";
        }

        protected void showbanktrans(object sender, EventArgs e)
        {
            showaccttrans.Style["visibility"] = "visible";
            showaccttrans.Style["display"] = "block";
            addacct.Style["visibility"] = "hidden";
            addacct.Style["display"] = "none";
            GridViewbankacctlst.DataSource = null;
            GridViewbankacctlst.DataBind();
            Labelheader.Text = "Bank Account Transactions";
        }

        protected void searchalltrans(object sender, EventArgs e)
        {
            GridViewbankacctlst.DataSource = null;
            GridViewbankacctlst.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {

                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                // todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.AllBankTransBY(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {
                    
                    GridViewbankacctlst.DataSource = pro.Tables[0];
                    GridViewbankacctlst.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("AccountBalance"));
                    GridViewbankacctlst.FooterRow.Cells[0].Text = "Total";
                    GridViewbankacctlst.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewbankacctlst.FooterRow.Cells[1].Text = totaloprice.ToString("N2");


                    Labeltotalserv.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }

            }
        }

        protected void searchtransbyah(object sender, EventArgs e)
        {
            GridViewbankacctlst.DataSource = null;
            GridViewbankacctlst.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {

                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                // todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.AllBankTransBYHN(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewbankacctlst.DataSource = pro.Tables[0];
                    GridViewbankacctlst.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("AccountBalance"));
                    GridViewbankacctlst.FooterRow.Cells[0].Text = "Total";
                    GridViewbankacctlst.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewbankacctlst.FooterRow.Cells[1].Text = totaloprice.ToString("N2");


                    Labeltotalserv.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }

            }
        }

        protected void searchtransbybn(object sender, EventArgs e)
        {
            GridViewbankacctlst.DataSource = null;
            GridViewbankacctlst.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {

                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                // todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.AllBankTransBYBN(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewbankacctlst.DataSource = pro.Tables[0];
                    GridViewbankacctlst.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("AccountBalance"));
                    GridViewbankacctlst.FooterRow.Cells[0].Text = "Total";
                    GridViewbankacctlst.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewbankacctlst.FooterRow.Cells[1].Text = totaloprice.ToString("N2");


                    Labeltotalserv.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }

            }
        }
        protected void searchtransbysaleper(object sender, EventArgs e)
        {
            GridViewbankacctlst.DataSource = null;
            GridViewbankacctlst.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {
                
                todt = Convert.ToDateTime(TextBoxtodt.Text);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                // todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.AllBankTransSaleper(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewbankacctlst.DataSource = pro.Tables[0];
                    GridViewbankacctlst.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("AccountBalance"));
                    GridViewbankacctlst.FooterRow.Cells[0].Text = "Total";
                    GridViewbankacctlst.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewbankacctlst.FooterRow.Cells[1].Text = totaloprice.ToString("N2");


                    Labeltotalserv.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }

            }
        }
    }
}