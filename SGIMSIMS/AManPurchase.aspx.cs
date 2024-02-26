using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AManPurchase : System.Web.UI.Page
    {
        DateTime fromdt, todt;
        string protype, rmname;
        string note;
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
            if (!IsPostBack)
            {

                
                explist.Style["visibility"] = "hidden";
                explist.Style["display"] = "none";
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }
        protected void loadsalerevlitpage(object sender, GridViewPageEventArgs e)
        {
            GridViewSaleRevList.PageIndex = e.NewPageIndex;
            LoadAllPurchase();
        }

        private void LoadAllPurchase()
        {
            if (Session["note"].ToString() == "search")
            {
                AllPurchase();
            }
           else if (Session["note"].ToString() == "searchpt")
            {
                AllPurchasewithProty();
            }
           else if (Session["note"].ToString() == "searchcrt")
            {
                AllPuwithprotyrmname();
            }
            else if (Session["note"].ToString() == "searchcrd")
            {
                AllCreditPurchase();
            }
            else
            {

            }


        }

        private void AllCreditPurchase()
        {
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            protype = DropDownListprotype.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet pro = Dal.AllCreditPurchase(fromdt, todt);

            if (pro.Tables[0].Rows.Count != 0)
            {
                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                Labeltotpur.Text = (GridViewSaleRevList.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {

            }
        }

        private void AllPuwithprotyrmname()
        {
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            protype = DropDownListprotype.SelectedItem.ToString();
            rmname = DropDownListrmname.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet pro = Dal.AllPuwithprotyrmname(fromdt, todt, protype, rmname);

            if (pro.Tables[0].Rows.Count != 0)
            {
                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                Labeltotpur.Text = (GridViewSaleRevList.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {

            }
        }

        private void AllPurchasewithProty()
        {
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            protype = DropDownListprotype.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet pro = Dal.AllPurchasewithProty(fromdt, todt);

            if (pro.Tables[0].Rows.Count != 0)
            {
                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                Labeltotpur.Text = (GridViewSaleRevList.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {

            }
        }

        private void AllPurchase()
        {
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            clsReport Dal = new clsReport();
            DataSet pro = Dal.AllPurchase(fromdt, todt);

            if (pro.Tables[0].Rows.Count != 0)
            {
                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                Labeltotpur.Text = (GridViewSaleRevList.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {

            }
        }

        protected void showpurrpt(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            
            revlist.Style["visibility"] = "visible";
            revlist.Style["display"] = "block";
            explist.Style["visibility"] = "hidden";
            explist.Style["display"] = "none";
        }

        protected void showincomrpt(object sender, EventArgs e)
        {
            explist.Style["visibility"] = "visible";
            explist.Style["display"] = "block";
            revlist.Style["visibility"] = "hidden";
            revlist.Style["display"] = "none";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
          

        }

        protected void search(object sender, EventArgs e)
        {
            Session["note"] = "search";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" )
            {
                //error
            }
            else
            {

                AllPurchase();
            }


        }

        protected void searchPaytype(object sender, EventArgs e)
        {
            Session["note"] = "searchpt";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" )
            {
                //error
            }
            else
            {
                AllPurchasewithProty();
               
            }
        }

        protected void searchcriteria(object sender, EventArgs e)
        {
            Session["note"] = "searchcrt";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListprotype.SelectedValue=="0" || DropDownListrmname.SelectedValue=="0")
            {
                //error
            }
            else
            {
                AllPuwithprotyrmname();
               
            }
        }

        protected void searchcredit(object sender, EventArgs e)
        {
            Session["note"] = "searchcrd";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" )
            {
                //error
            }
            else
            {
                AllCreditPurchase();
                
            }
        }

        protected void hidecolomn(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header))
            {

              
                if (note == "click")

                {
                    GridViewSaleRevList.Columns[0].Visible = true;
                }
                else 
                {
                    GridViewSaleRevList.Columns[0].Visible = false;
                }
                
            }
        }

        protected void Updatecridet(object sender, EventArgs e)
        {
            GridViewRow row = GridViewSaleRevList.SelectedRow;
            string PurDate= Convert.ToString(row.Cells[1].Text);
            string SupplierName = Convert.ToString(row.Cells[2].Text.ToString());
            string ProductName = Convert.ToString(row.Cells[3].Text.ToString()); 
            string ProductGage = row.Cells[4].Text.ToString(); 
            decimal Quantity = Convert.ToDecimal(row.Cells[5].Text.ToString());
            clsReport Dal = new clsReport();
              Dal.AllUdtCreditPurch(PurDate, SupplierName, ProductName, ProductGage, Quantity);

        }

        protected void LoadProductName(object sender, EventArgs e)
        {
            if(DropDownListprotype.SelectedItem.ToString()== "RowMaterial")
            {
                DropDownListrmname.Items.Clear();
               clsProduct Dal = new clsProduct();
                DataSet probrand = Dal.FillProBrand();
                DropDownListrmname.DataTextField = "ProductBrand";
                DropDownListrmname.DataValueField = "ProductBrand";
                DropDownListrmname.DataSource = probrand.Tables[0];
                DropDownListrmname.DataBind();
                DropDownListrmname.Items.Insert(0, "-- የጥሬ ዕቃ ስም ምረጥ--");
                DropDownListrmname.Items[0].Value = "0";
            }
            else if(DropDownListprotype.SelectedItem.ToString()== "PurchaseProduct")
            {
                string type = "Purchased";
                DropDownListrmname.Items.Clear();
               clsProduct Dal = new clsProduct();
                DataSet proname = Dal.FillProname(type);
                DropDownListrmname.DataTextField = "ProductName";
                DropDownListrmname.DataValueField = "ProductName";
                DropDownListrmname.DataSource = proname.Tables[0];
                DropDownListrmname.DataBind();
                DropDownListrmname.Items.Insert(0, "-- የምርት ስም ምረጥ--");
                DropDownListrmname.Items[0].Value = "0";
            }
            else
            {

            }
        }

        protected void searchincomerpt(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxexpfrmdt.Text == "" || TextBoxextodt.Text == "")
            {
                //error
            }
            else
            {

                fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);
                todt = Convert.ToDateTime(TextBoxextodt.Text);
                clsReport Dal2 = new clsReport();

                DataSet ds2 = Dal2.FindDailySale(fromdt, todt);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal totalamount = Convert.ToDecimal((ds2.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);

                    Labelsale.Text = Convert.ToString(totalamount) + " " + "Birr"; 
                }
                else
                {

                }

                DataSet ds3 = Dal2.FindDailyOrder(fromdt, todt);
                if (ds3.Tables[0].Rows.Count != 0)
                {


                    decimal totalamount = Convert.ToDecimal((ds3.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);
                    //Label16.Text = Convert.ToString(totalamount);
                    Labelordprepaid.Text = Convert.ToString(totalamount) + " " + "Birr";

                }
                else
                {

                }

                DataSet ds7 = Dal2.dailyexpenseyes(fromdt, todt);
                if (ds7.Tables[0].Rows.Count != 0)
                {
                    decimal totalamount = Convert.ToDecimal((ds7.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);

                    Label1othexp.Text = Convert.ToString(totalamount) + " " + "Birr";
                }
                else
                {

                }
                DataSet ds8 = Dal2.dailyexpensenote(fromdt, todt);
                if (ds8.Tables[0].Rows.Count != 0)
                {
                    decimal totalamount = Convert.ToDecimal((ds8.Tables[0].Rows[0][0]));
                    totalamount = Math.Round(totalamount, 2);

                    Labelexpnot.Text = Convert.ToString(totalamount) + " " + "Birr";
                }
                else
                {

                }
            }
                   
          
        }
    }
}