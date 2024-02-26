using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMsentorder : System.Web.UI.Page
    {
        string inventoryman;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

                inventoryman = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                LoadNewOrdersGrid();
            }
            
        }
        private void LoadNewOrdersGrid()
        {
            
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadOrderToInventory(inventoryman);
            
            if (Order.Tables[0].Rows.Count != 0)
            {
                 GridViewRecNewOrder.DataSource = Order.Tables[0];
                GridViewRecNewOrder.DataBind();
               LabeltotalnewOrders.Text= (GridViewRecNewOrder.DataSource as DataTable).Rows.Count.ToString();
                Labelneworder.Text= (GridViewRecNewOrder.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {
                Labelneworder.Text = "0";
                LabeltotalnewOrders.Text = "0";


            }
        }
        protected void LoadRecNxtOrderpage(object sender, GridViewPageEventArgs e)
        {
            GridViewRecNewOrder.PageIndex = e.NewPageIndex;
            LoadNewOrdersGrid();
        }

        protected void RecOrderSentNot(object sender, EventArgs e)
        {
            GridViewRow row = GridViewRecNewOrder.SelectedRow;

            clsOrder Dal = new clsOrder();
            string OrderId = row.Cells[1].Text;
            string OrderDate = row.Cells[2].Text;
            string DeliveryDate = row.Cells[3].Text;
            string ProductBrand;
            string ProductGage;
            if (!string.IsNullOrEmpty(row.Cells[4].Text))
            {
                ProductBrand = row.Cells[4].Text;
            }
            else
            {
                 ProductBrand = null;
            }
            if (!string.IsNullOrEmpty(row.Cells[5].Text))
            {
                ProductGage = row.Cells[5].Text;
            }
            else
            {
                ProductGage = null;
            }
          
         
           
            string ProductName = row.Cells[6].Text;
            string ProductSize = row.Cells[7].Text;
          
           
            decimal Quantity = Convert.ToDecimal(row.Cells[10].Text);
            decimal Length = Convert.ToDecimal(row.Cells[11].Text);
            int specificid = Convert.ToInt32(row.Cells[15].Text);
            string userby = Session["UserBy"].ToString();


            Dal.MakeNewOrderRecieved(OrderId, OrderDate, DeliveryDate,ProductName, Quantity, Length,inventoryman, userby, specificid);

           
            GridViewRecNewOrder.DataSource = null;
            GridViewRecNewOrder.DataBind();
            LoadNewOrdersGrid();
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
                    
                    cell.Width = new Unit("430px");
                TableCell cell2 = e.Row.Cells[0];

                cell2.Width = new Unit("330px");

            }

        }
        
    }
}