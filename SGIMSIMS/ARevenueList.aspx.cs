using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ARevenueList : System.Web.UI.Page
    {
        DateTime fromdt, todt;
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
                Loadware();
             
                explist.Style["visibility"] = "hidden";
                explist.Style["display"] = "none";
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        private void Loadware()
        {
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserName();
            DropDownListwarehouse.DataTextField = "AssignShop";
            DropDownListwarehouse.DataValueField = "AssignShop";


            DropDownListwarehouse.DataSource = warename.Tables[0];
            DropDownListwarehouse.DataBind();
            DropDownListwarehouse.Items.Insert(0, "-- Select Shop Name--");
            DropDownListwarehouse.Items[0].Value = "0";
            DropDowwarehome.DataTextField = "AssignShop";
            DropDowwarehome.DataValueField = "AssignShop";


            DropDowwarehome.DataSource = warename.Tables[0];
            DropDowwarehome.DataBind();
            DropDowwarehome.Items.Insert(0, "-- Select Shop Name--");
            DropDowwarehome.Items[0].Value = "0"; 
        }

        protected void search(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {
                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.Revenue(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewSaleRevList.DataSource = pro.Tables[0];
                    GridViewSaleRevList.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                    GridViewSaleRevList.FooterRow.Cells[1].Text = "Total";
                    GridViewSaleRevList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewSaleRevList.FooterRow.Cells[2].Text = totaloprice.ToString("N2");

                    Labeltotrev.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }
            }
           // LoadAllRevenue();
        }

        protected void loadsalerevlitpage(object sender, EventArgs e)
        {
           
        }

        protected void loadsalerevlitpage(object sender, GridViewPageEventArgs e)
        {
            if(Session["note"].ToString() == "explst")
            {
                GridViewSaleRevList.PageIndex = e.NewPageIndex;
                loadallexplst();
            }
            else if (Session["note"].ToString() == "allrev")
            {
                GridViewSaleRevList.PageIndex = e.NewPageIndex;
                loadrevenuelst();
            }
            else
            {

            }
        
        }

        private void loadrevenuelst()
        {
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            clsReport Dal = new clsReport();
            DataSet pro = Dal.RevenueByshop(fromdt, todt);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                GridViewSaleRevList.FooterRow.Cells[2].Text = "Total";
                GridViewSaleRevList.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                GridViewSaleRevList.FooterRow.Cells[3].Text = totaloprice.ToString("N2");

                Labeltotrev.Text = Convert.ToString(totaloprice);
            }
            else
            {


            }
        }

        protected void searchbyVAT(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
            {
                //error
            }
            else
            {
                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            //    todt = Convert.ToDateTime(TextBoxfromdt.Text);
                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
               todt = Convert.ToDateTime(TextBoxtodt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.RevenuebyVAT(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewSaleRevList.DataSource = pro.Tables[0];
                    GridViewSaleRevList.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                    GridViewSaleRevList.FooterRow.Cells[2].Text = "Total";
                    GridViewSaleRevList.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    GridViewSaleRevList.FooterRow.Cells[3].Text = totaloprice.ToString("N2");

                    Labeltotrev.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }
            }
        }

        protected void searchPaytype(object sender, EventArgs e)
            {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
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
                    DataSet pro = Dal.RevenuebyPaytype(fromdt, todt, byy);

                    if (pro.Tables[0].Rows.Count != 0)
                    {

                        GridViewSaleRevList.DataSource = pro.Tables[0];
                        GridViewSaleRevList.DataBind();
                        decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                        GridViewSaleRevList.FooterRow.Cells[2].Text = "Total";
                        GridViewSaleRevList.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                        GridViewSaleRevList.FooterRow.Cells[3].Text = totaloprice.ToString("N2");

                        Labeltotrev.Text = Convert.ToString(totaloprice);
                    }
                    else
                    {


                    }

                } }

        protected void searchminusexp(object sender, EventArgs e)
                {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
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
              //  todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDownListwarehouse.SelectedItem.ToString();
                        clsReport Dal = new clsReport();
                        DataSet pro = Dal.Revenue(fromdt, todt, byy);

                        if (pro.Tables[0].Rows.Count != 0)
                        {

                            GridViewSaleRevList.DataSource = pro.Tables[0];
                            GridViewSaleRevList.DataBind();
                            decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                            GridViewSaleRevList.FooterRow.Cells[1].Text = "Total";
                            GridViewSaleRevList.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                            GridViewSaleRevList.FooterRow.Cells[2].Text = totaloprice.ToString("N2");

                            Labeltotrev.Text = Convert.ToString(totaloprice);
                        }
                        else
                        {


                        }
                    }
                }

        protected void showexprpt(object sender, EventArgs e)
        {
            explist.Style["visibility"] = "visible";
            explist.Style["display"] = "block";
            revlist.Style["visibility"] = "hidden";
            revlist.Style["display"] = "none";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            Labelnoteheader.Text = "Expense Report";
        }

        protected void showrevrpt(object sender, EventArgs e)
        {
            revlist.Style["visibility"] = "visible";
            revlist.Style["display"] = "block";
            explist.Style["visibility"] = "hidden";
            explist.Style["display"] = "none";
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            Labelnoteheader.Text = "Revenue Report";
        }

        protected void searchexp(object sender, EventArgs e)
        {

            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxexpfrmdt.Text == "" || TextBoxextodt.Text == "" || DropDowwarehome.SelectedValue == "0")
            {
                //error
            }
            else
            {

                fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);

                todt = Convert.ToDateTime(TextBoxextodt.Text);
                //  todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDowwarehome.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.dailyAllexpense(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewSaleRevList.DataSource = pro.Tables[0];
                    GridViewSaleRevList.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ExpenseAmount"));
                    GridViewSaleRevList.FooterRow.Cells[0].Text = "Total";
                    GridViewSaleRevList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewSaleRevList.FooterRow.Cells[1].Text = totaloprice.ToString("N2");

                    Labeltotrev.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }
            }
        }

        protected void searchbyCAT(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxexpfrmdt.Text == "" || TextBoxextodt.Text == "" || DropDowwarehome.SelectedValue == "0")
            {
                //error
            }
            else
            {
                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);

                todt = Convert.ToDateTime(TextBoxextodt.Text);
                //  todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDowwarehome.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.dailyreasexpense(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewSaleRevList.DataSource = pro.Tables[0];
                    GridViewSaleRevList.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ExpenseAmount"));
                    GridViewSaleRevList.FooterRow.Cells[1].Text = "Total";
                    GridViewSaleRevList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewSaleRevList.FooterRow.Cells[2].Text = totaloprice.ToString("N2");

                    Labeltotrev.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }
            }
        }

        protected void searchBYnes(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxexpfrmdt.Text == "" || TextBoxextodt.Text == "" || DropDowwarehome.SelectedValue == "0")
            {
                //error
            }
            else
            {
                //DateTime date = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //todt = DateTime.ParseExact(TextBoxfromdt.Text, "d/MM/yyyy", CultureInfo.InvariantCulture);

                //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);

                todt = Convert.ToDateTime(TextBoxextodt.Text);
                //  todt = Convert.ToDateTime(TextBoxfromdt.Text);
                byy = DropDowwarehome.SelectedItem.ToString();
                clsReport Dal = new clsReport();
                DataSet pro = Dal.dailynoeexpense(fromdt, todt, byy);

                if (pro.Tables[0].Rows.Count != 0)
                {

                    GridViewSaleRevList.DataSource = pro.Tables[0];
                    GridViewSaleRevList.DataBind();
                    decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ExpenseAmount"));
                    GridViewSaleRevList.FooterRow.Cells[1].Text = "Total";
                    GridViewSaleRevList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    GridViewSaleRevList.FooterRow.Cells[2].Text = totaloprice.ToString("N2");

                    Labeltotrev.Text = Convert.ToString(totaloprice);
                }
                else
                {


                }
            }
        }

        protected void searchbyShop(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
            {
                //error
            }
            else
            {
                Session["note"] = "allrev";
                loadrevenuelst();
              
            }

        }

        protected void searchallexplst(object sender, EventArgs e)
        {
            GridViewSaleRevList.DataSource = null;
            GridViewSaleRevList.DataBind();
            if (TextBoxexpfrmdt.Text == "" || TextBoxextodt.Text == "")
            {
                //error
            }
            else
            {
                Session["note"] = "explst";
                loadallexplst();
               
            }
        }

        private void loadallexplst()
        {
            fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);

            todt = Convert.ToDateTime(TextBoxextodt.Text);
            //  todt = Convert.ToDateTime(TextBoxfromdt.Text);
            byy = DropDowwarehome.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet pro = Dal.AllexpenseList(fromdt, todt);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                //   decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ExpenseAmount"));
                //GridViewSaleRevList.FooterRow.Cells[0].Text = "Total";
                //GridViewSaleRevList.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //GridViewSaleRevList.FooterRow.Cells[1].Text = totaloprice.ToString("N2");

                //Labeltotrev.Text = Convert.ToString(totaloprice);
            }
            else
            {


            }
        }

        protected void exportexplst(object sender, EventArgs e)
        {
           
            clsReport ObjDal = new clsReport();
            //  DataSet ObjDal = Dal.AllexpenseList(fromdt, todt);
            fromdt = Convert.ToDateTime(TextBoxexpfrmdt.Text);

            todt = Convert.ToDateTime(TextBoxextodt.Text);

            // string record = ConfigurationManager.AppSettings["UserRecord"];
            // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
            try
            {

                int PageNumber = 0;
                // string filename = Server.MapPath("UserDataSheet");
                string filename = "ExpenseList" + TextBoxexpfrmdt.Text + " to" + TextBoxextodt.Text;
                DataTable dt = new DataTable();
                //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                DataTable dt2 = new DataTable();
                dt2 = ObjDal.ExportAllExpList(fromdt, todt);
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

        protected void exportrevlst(object sender, EventArgs e)
        {
            clsReport ObjDal2 = new clsReport();
            //  DataSet ObjDal = Dal.AllexpenseList(fromdt, todt);
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            byy = DropDownListwarehouse.SelectedItem.ToString();
            // string record = ConfigurationManager.AppSettings["UserRecord"];
            // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
            try
            {

                int PageNumber = 0;
                // string filename = Server.MapPath("UserDataSheet");
                string filenames = "SaleRevList" + TextBoxfromdt.Text + " to" + TextBoxtodt.Text;
                DataTable dt1 = new DataTable();
                //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                StringWriter writer = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                DataTable dt3 = new DataTable();
                dt3 = ObjDal2.ExportAllSaleRevList(fromdt, todt,byy);
                int a = dt3.Rows.Count;
                int RowsPerPage = Convert.ToInt32(a);

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                    GridView gridView2 = new GridView();
                    gridView2.AutoGenerateColumns = true;
                    gridView2.ShowHeader = (i == 0);
                    // DataTable dtn = new DataTable();
                    gridView2.DataSource = dt3;

                    gridView2.DataBind();
                    gridView2.RenderControl(htmlWriter);
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=" + filenames + ".xls");
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

        private void LoadAllRevenue()
        {
            //fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            //todt = Convert.ToDateTime(TextBoxtodt.Text);
            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            todt = Convert.ToDateTime(TextBoxtodt.Text);
            byy = DropDownListwarehouse.SelectedItem.ToString();
            clsReport Dal = new clsReport();
            DataSet pro = Dal.Revenue(fromdt,todt,byy);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewSaleRevList.DataSource = pro.Tables[0];
                GridViewSaleRevList.DataBind();
                decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("SaleRevenue"));
                GridViewSaleRevList.FooterRow.Cells[2].Text = "Total";
                GridViewSaleRevList.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                GridViewSaleRevList.FooterRow.Cells[3].Text = totaloprice.ToString("N2");

                Labeltotrev.Text = Convert.ToString(totaloprice);
            }
            else
            {


            }
        }
    }
}