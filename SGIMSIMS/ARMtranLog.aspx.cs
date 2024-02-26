using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SGIMSIMS
{
    public partial class ARMtranLog : System.Web.UI.Page
    {
        string username;
        DateTime fromdt;
        DateTime todt;
        string brand;
        string gage;
        string ware;
      
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
               
                loadbrand();
                
                loadware();
            }
          
        }

        private void loadbrand()
        {
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListprobrand.DataTextField = "ProductBrand";
            DropDownListprobrand.DataValueField = "ProductBrand";
            DropDownListprobrand.DataSource = probrand.Tables[0];
            DropDownListprobrand.DataBind();
            DropDownListprobrand.Items.Insert(0, "-- Select--");
            DropDownListprobrand.Items[0].Value = "0";
        }

        private void loadware()
        {
            
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNamewITHAD();
            DropDownListwarehouse.DataTextField = "AssignShop";
            DropDownListwarehouse.DataValueField = "AssignShop";


            DropDownListwarehouse.DataSource = warename.Tables[0];
            DropDownListwarehouse.DataBind();
            DropDownListwarehouse.Items.Insert(0, "-- Select--");
            DropDownListwarehouse.Items[0].Value = "0";
        }

        private void loadgage(string brand)
        {
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListprogage.DataTextField = "ProductGage";
            DropDownListprogage.DataValueField = "ProductGage";
            DropDownListprogage.DataSource = progage.Tables[0];
            DropDownListprogage.DataBind();
            DropDownListprogage.Items.Insert(0, "-- Select--");
            DropDownListprogage.Items[0].Value = "0";
        }

        protected void search(object sender, EventArgs e)
        {

            if (RadioButtonListsrchrmtran.Items[0].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet rmrec = Dal.LoadAllRMReq(fromdt, todt);

                    if (rmrec.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = rmrec.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }

                }

            }
            else if (RadioButtonListsrchrmtran.Items[1].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListprobrand.SelectedValue == "0" || DropDownListprogage.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    brand = DropDownListprobrand.SelectedItem.ToString();
                    gage = DropDownListprogage.SelectedItem.ToString();
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet byrm = Dal.LoadRMReqByBrGa(fromdt, todt, brand, gage);

                    if (byrm.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = byrm.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else if (RadioButtonListsrchrmtran.Items[3].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet bysntad = Dal.LoadRMReqSntByAdmin(username, fromdt, todt);

                    if (bysntad.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = bysntad.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else if (RadioButtonListsrchrmtran.Items[2].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    ware = DropDownListwarehouse.SelectedItem.ToString();
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet byware = Dal.LoadRMReqByWare(ware, fromdt, todt);

                    if (byware.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = byware.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else
            {
                GridViewmatlst.DataSource = null;
                GridViewmatlst.DataBind();
            }
        }

       
     
        protected void loadbrandgages(object sender, EventArgs e)
        {
            string brand = DropDownListprobrand.SelectedItem.ToString();
            DropDownListprogage.Items.Clear();
            loadgage(brand);
        }

        protected void GridViewmatlst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Loadmatlstpage(object sender, GridViewPageEventArgs e)
        {
            GridViewmatlst.PageIndex = e.NewPageIndex;
            LoadGridViewmatlst();
        }

        private void LoadGridViewmatlst()
        {
            if (RadioButtonListsrchrmtran.Items[0].Selected.Equals(true))
            {
                //  BindGrid();
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet rmrec = Dal.LoadAllRMReq(fromdt, todt);

                    if (rmrec.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = rmrec.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }

                }

            }
            else if (RadioButtonListsrchrmtran.Items[1].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListprobrand.SelectedValue == "0" || DropDownListprogage.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    brand = DropDownListprobrand.SelectedItem.ToString();
                    gage = DropDownListprogage.SelectedItem.ToString();
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet byrm = Dal.LoadRMReqByBrGa(fromdt, todt, brand, gage);

                    if (byrm.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = byrm.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else if (RadioButtonListsrchrmtran.Items[3].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet bysntad = Dal.LoadRMReqSntByAdmin(username, fromdt, todt);

                    if (bysntad.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = bysntad.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else if (RadioButtonListsrchrmtran.Items[2].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    ware = DropDownListwarehouse.SelectedItem.ToString();
                    GridViewmatlst.DataSource = null;
                    GridViewmatlst.DataBind();
                    clsRMRequest Dal = new clsRMRequest();

                    DataSet byware = Dal.LoadRMReqByWare(ware, fromdt, todt);

                    if (byware.Tables[0].Rows.Count != 0)
                    {

                        GridViewmatlst.DataSource = byware.Tables[0];
                        GridViewmatlst.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            else
            {
                GridViewmatlst.DataSource = null;
                GridViewmatlst.DataBind();
            }
        }

        

       
        protected void radiobtnelectedindexchg(object sender, EventArgs e)
        {
        
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        protected void print(object sender, EventArgs e)
        {
            if (RadioButtonListsrchrmtran.Items[0].Selected.Equals(true))
            {
                //  BindGrid();
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    clsRMRequest ObjDal = new clsRMRequest();
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);

                    // string record = ConfigurationManager.AppSettings["UserRecord"];
                    // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                    try
                    {

                        int PageNumber = 0;
                        // string filename = Server.MapPath("UserDataSheet");
                        string filename = "AllRowmaterialLog" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                        DataTable dt = new DataTable();
                        //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                        StringWriter writer = new StringWriter();
                        HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                        DataTable dt2 = new DataTable();
                        dt2 = ObjDal.ExportAllRMReq(fromdt, todt);
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
            else if (RadioButtonListsrchrmtran.Items[1].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListprobrand.SelectedValue == "0" || DropDownListprogage.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    clsRMRequest ObjDal = new clsRMRequest();
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    brand = DropDownListprobrand.SelectedItem.ToString();
                    gage = DropDownListprogage.SelectedItem.ToString();
                    // string record = ConfigurationManager.AppSettings["UserRecord"];
                    // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                    try
                    {

                        int PageNumber = 0;
                        // string filename = Server.MapPath("UserDataSheet");
                        string filename = "RowmaterialLogBYBG" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                        DataTable dt = new DataTable();
                        //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                        StringWriter writer = new StringWriter();
                        HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                        DataTable dt2 = new DataTable();
                        dt2 = ObjDal.ExportAllRMReqBG(fromdt, todt,brand,gage);
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
            else if (RadioButtonListsrchrmtran.Items[2].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "" || DropDownListwarehouse.SelectedValue == "0")
                {
                    //error msg

                }
                else
                {
                    clsRMRequest ObjDal = new clsRMRequest();
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);
                    ware = DropDownListwarehouse.SelectedItem.ToString();
                    // string record = ConfigurationManager.AppSettings["UserRecord"];
                    // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                    try
                    {

                        int PageNumber = 0;
                        // string filename = Server.MapPath("UserDataSheet");
                        string filename = "RowmaterialLogWare" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                        DataTable dt = new DataTable();
                        //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                        StringWriter writer = new StringWriter();
                        HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                        DataTable dt2 = new DataTable();
                        dt2 = ObjDal.ExportAllRMReqWare(fromdt, todt,ware);
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
            else if (RadioButtonListsrchrmtran.Items[3].Selected.Equals(true))
            {
                if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
                {
                    //error msg

                }
                else
                {
                    clsRMRequest ObjDal = new clsRMRequest();
                    fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                    todt = Convert.ToDateTime(TextBoxtodt.Text);

                    // string record = ConfigurationManager.AppSettings["UserRecord"];
                    // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                    try
                    {

                        int PageNumber = 0;
                        // string filename = Server.MapPath("UserDataSheet");
                        string filename = "RowmaterialLogAdmin" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                        DataTable dt = new DataTable();
                        //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                        StringWriter writer = new StringWriter();
                        HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                        DataTable dt2 = new DataTable();
                        dt2 = ObjDal.ExportAlrqByAdmin(username,fromdt, todt);
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


                  


            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Prosperity.xlsx"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridViewmatlst.AllowPaging = false;
            //BindGrid();

            //DataTable tbl = GridViewmatlst.DataSource as DataTable;

            //GridViewmatlst.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //for (int a = 0; a < GridViewmatlst.HeaderRow.Cells.Count; a++)
            //{
            //    GridViewmatlst.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            //}
            //int j = 1;
            //foreach (GridViewRow gvrow in GridViewmatlst.Rows)
            //{
            //    //GridViewmatlst.BackColor = Color.White;
            //    if (j <= tbl.Rows.Count)
            //    {
            //        if (j % 2 != 0)
            //        {
            //            for (int k = 0; k < gvrow.Cells.Count; k++)
            //            {
            //                gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
            //            }
            //        }
            //    }
            //    j++;
            //}
            //GridViewmatlst.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();



            //if ((sender as Button).CommandArgument == "All")
            //{
            //    //Disable Paging.
            //    GridViewmatlst.AllowPaging = false;

            //    //Re-bind the GridView.
            //    BindGrid();

            //    //For Printing Header on each Page.
            //    GridViewmatlst.UseAccessibleHeader = true;
            //    GridViewmatlst.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    if (GridViewmatlst.TopPagerRow != null)
            //    {
            //        GridViewmatlst.TopPagerRow.TableSection = TableRowSection.TableHeader;
            //    }
            //    if (GridViewmatlst.BottomPagerRow != null)
            //    {
            //        GridViewmatlst.BottomPagerRow.TableSection = TableRowSection.TableFooter;
            //    }
            //    //  GridViewmatlst.FooterRow.TableSection = TableRowSection.TableFooter;
            //    GridViewmatlst.Attributes["style"] = "border-collapse:separate";
            //    foreach (GridViewRow row in GridViewmatlst.Rows)
            //    {
            //        if ((row.RowIndex + 1) % GridViewmatlst.PageSize == 0 && row.RowIndex != 0)
            //        {
            //            row.Attributes["style"] = "page-break-after:always;";
            //        }
            //    }
            //}

            //using (StringWriter sw = new StringWriter())
            //{
            //    //Render GridView to HTML.
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    GridViewmatlst.RenderControl(hw);

            //    //Enable Paging.
            //    //  GridViewmatlst.AllowPaging = true;
            //    this.BindGrid();

            //    //Remove single quotes to avoid JavaScript error.
            //    string gridHTML = sw.ToString().Replace(Environment.NewLine, "");
            //    string gridCSS = gridStyles.InnerText.Replace("\"", "'").Replace(Environment.NewLine, "");


            //    //Print the GridView.
            //    string script = "window.onload = function() { PrintGrid('" + gridHTML + "', '" + gridCSS + "'); }";
            //    ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", script, true);
            //}

            //ecel 2
            //HttpContext.Current.Response.Clear();
            ////HttpContext.Current.Response.AddHeader(
            ////    "content-disposition", string.Format("attachment; filename={0}",  GridViewExport.xls"));
            //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //HttpContext.Current.Response.ContentType = "application/ms-excel";

            //using (StringWriter sw = new StringWriter())
            //{
            //    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            //    {
            //        //  Create a table to contain the grid
            //        Table table = new Table();

            //        //  include the gridline settings
            //        table.GridLines = GridViewmatlst.GridLines;

            //        //  add the header row to the table
            //        if (GridViewmatlst.HeaderRow != null)
            //        {
            //            ARMtranLog.PrepareControlForExport(GridViewmatlst.HeaderRow);
            //            table.Rows.Add(GridViewmatlst.HeaderRow);
            //        }

            //        //  add each of the data rows to the table
            //        foreach (GridViewRow row in GridViewmatlst.Rows)
            //        {
            //            ARMtranLog.PrepareControlForExport(row);
            //            table.Rows.Add(row);
            //        }

            //        //  add the footer row to the table
            //        if (GridViewmatlst.FooterRow != null)
            //        {
            //            ARMtranLog.PrepareControlForExport(GridViewmatlst.FooterRow);
            //            table.Rows.Add(GridViewmatlst.FooterRow);
            //        }

            //        //  render the table into the htmlwriter
            //        table.RenderControl(htw);

            //        //  render the htmlwriter into the response
            //        HttpContext.Current.Response.Write(sw.ToString());
            //        HttpContext.Current.Response.End();
            //    }
            //}
            //excel
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    GridViewmatlst.AllowPaging = false;
            //    this.BindGrid();

            //    GridViewmatlst.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in GridViewmatlst.HeaderRow.Cells)
            //    {
            //        cell.BackColor = GridViewmatlst.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in GridViewmatlst.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = GridViewmatlst.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = GridViewmatlst.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    GridViewmatlst.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            //GridViewmatlst.AllowPaging = false;
            //GridViewmatlst.DataBind();
            //GridViewmatlst.Attributes["style"] = "border-collapse:separate";
            //foreach (GridViewRow row in GridViewmatlst.Rows)
            //{
            //    if (row.RowIndex % 10 == 0 && row.RowIndex != 0)
            //    {
            //        row.Attributes["style"] = "page-break-after:always;";
            //    }
            //}
            //GridViewmatlst.Columns[0].Visible = false;
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //GridViewmatlst.RenderControl(hw);
            //string gridHTML = sw.ToString().Replace("\"", "'")
            //    .Replace(System.Environment.NewLine, "");
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.onload = new function(){");
            //sb.Append("var printWin = window.open('', '', 'left=0");
            //sb.Append(",top=0,width=1000,height=600,status=0');");
            //sb.Append("printWin.document.write(\"");
            //sb.Append(gridHTML);
            //sb.Append("\");");
            //sb.Append("printWin.document.close();");
            //sb.Append("printWin.focus();");
            //sb.Append("printWin.print();};");
            //sb.Append("printWin.close();};");
            //sb.Append("</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            //GridViewmatlst.AllowPaging = true;
            //GridViewmatlst.DataBind();
            //GridViewmatlst.Columns[0].Visible = true;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {  
            /*Verifies that the control is rendered */
        }
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    ARMtranLog.PrepareControlForExport(current);
                }
            }
        }
        private void BindGrid()
        {
            if(string.IsNullOrEmpty(TextBoxfromdt.Text) || string.IsNullOrEmpty(TextBoxtodt.Text))
            
             {
                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);
                GridViewmatlst.DataSource = null;
                GridViewmatlst.DataBind();
             
                clsRMRequest Dal = new clsRMRequest();

                DataTable rmrect1 = new DataTable();
                DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);

                //if (rmrec.Tables[0].Rows.Count != 0)
                //{

                GridViewmatlst.DataSource = rmrect;
                    GridViewmatlst.DataBind();
                    
                //}
                //else
                //{

                //}
            }
           
        }

       


        }
}