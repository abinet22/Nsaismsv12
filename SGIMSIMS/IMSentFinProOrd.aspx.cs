using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMSentFinProOrd : System.Web.UI.Page
    {
        string ware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                ware = Session["UserName"].ToString();

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
               // LoadFinishProducts();
               // Labelordcount.Visible = false;
            }
           
        }

        private void LoadFinishProducts()
        {
            clsManProducts Dal = new clsManProducts();
            DataSet FinOrder = Dal.LoadWorkOrdersFin(ware);

            if (FinOrder.Tables[0].Rows.Count != 0)
            {
                GridViewFinOrders.DataSource = FinOrder.Tables[0];
                GridViewFinOrders.DataBind();
                LabeltotalFinOrders.Text = (GridViewFinOrders.DataSource as DataTable).Rows.Count.ToString();
                LabeltotalFinOrders.Text = (GridViewFinOrders.DataSource as DataTable).Rows.Count.ToString();
                Labelfinshorder.Text= GridViewFinOrders.Rows.Count.ToString();
               
            }
            else
            {
                LabeltotalFinOrders.Text = "0";
                Labelfinshorder.Text = "0";


            }
        }

        protected void searchFinord(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxOrderId.Text))
            {
                //error
            }
            else
            {
                string OrderId = TextBoxOrderId.Text;
                GridViewFinOrders.DataSource = null;
                GridViewFinOrders.DataBind();
                LoadFinshOrderGrid(OrderId);
                clsOrder dal = new clsOrder();
                DataSet ord = dal.countnordertot(OrderId, ware);
                if (ord.Tables[0].Rows.Count != 0)
                {
                    Labelordcount.Visible = true;
                    Labelordcount.Text = Convert.ToString(ord.Tables[0].Rows[0][0]);
                }
                else
                {
                    Labelordcount.Visible = false;
                }
            }
           
        }

        private void LoadFinshOrderGrid(string OrderId)
        {
           
            clsManProducts Dal = new clsManProducts();
            DataSet ManProducts = Dal.LoadFinishOrdByOId(OrderId, ware);


            if (ManProducts.Tables[0].Rows.Count != 0)
            {
                GridViewFinOrders.DataSource = ManProducts.Tables[0];
                GridViewFinOrders.DataBind();
                int totalWorkord = (GridViewFinOrders.DataSource as DataTable).Rows.Count;

                LabeltotalFinOrders.Text = Convert.ToString(totalWorkord);
                Labelordcount.Visible = true;
            }
        }

        protected void searchNew(object sender, EventArgs e)
        {
            ClearAll();
           
        }

        private void ClearAll()
        {
            TextBoxOrderId.Text = "";

            Labelordcount.Visible = false;
            GridViewFinOrders.DataSource = null;
            GridViewFinOrders.DataBind();
            LoadFinishProducts();

        }

        protected void LoadFinOrdpage(object sender, GridViewPageEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxOrderId.Text))
            {
                GridViewFinOrders.PageIndex = e.NewPageIndex;
                LoadFinishProducts();
            }
            else
            {
                GridViewFinOrders.PageIndex = e.NewPageIndex;

                string OrderId = TextBoxOrderId.Text;
                LoadFinshOrderGrid(OrderId);
            }
          

        }

        protected void SeeandSendFinOrder(object sender, EventArgs e)
        {
            GridViewRow row = GridViewFinOrders.SelectedRow;
            string manid = row.Cells[2].Text;
            string OrderId = row.Cells[3].Text;
            string productName = row.Cells[4].Text;
            decimal productSize = Convert.ToDecimal(row.Cells[5].Text);
            string productShape = row.Cells[6].Text;
            decimal quantity = Convert.ToDecimal(row.Cells[7].Text);
            string productBrand = row.Cells[9].Text;
            string productGage = row.Cells[10].Text;
            string Wsntby = Session["UserBy"].ToString();
            clsManProducts Dal = new clsManProducts();

            Dal.SentFinManProudt(OrderId,manid,ware, Wsntby);
            clsOrder Dal2 = new clsOrder();
            Dal2.SentFinManPro(OrderId, productName,productBrand, productGage, productSize, quantity, ware);
            ClearAferSent();
        }

        private void ClearAferSent()
        {
            string OrderId = TextBoxOrderId.Text;
            clsManProducts Dal = new clsManProducts();
            DataSet ManProducts = Dal.LoadWorkOrdersFin(ware);
            GridViewFinOrders.DataSource = ManProducts.Tables[0];
            GridViewFinOrders.DataBind();
            GridViewFinOrders.DataSource = null;
          //  LoadFinishProducts();
           
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void width(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header))
            {

                // For setting the width of first column to 100px
                TableCell cell = e.Row.Cells[1];
                //GridViewRecAssignOrder.Columns[2].ItemStyle.Width = 400;
                cell.Width = new Unit("530px");


            }
        }
    }
}