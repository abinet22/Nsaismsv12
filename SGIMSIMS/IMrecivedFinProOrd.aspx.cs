using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMrecivedFinProOrd : System.Web.UI.Page
    {
        string ware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

                ware = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            Labeltoday.Text = DateTime.Now.ToShortDateString();
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void searchwrkord(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxMWorkId.Text))
            {
                //error
            }
            string ManWId = TextBoxMWorkId.Text;
            LoadWorkOrderGrid(ManWId);
        }

        private void LoadWorkOrderGrid(string ManWId)
        {
           
            clsManProducts Dal = new clsManProducts();
            DataSet ManProducts = Dal.LoadWorkOrders(ManWId,ware);

            


            if (ManProducts.Tables[0].Rows.Count != 0)
            {
                GridViewWorkOrders.DataSource = ManProducts.Tables[0];
                GridViewWorkOrders.DataBind();
                string totalWorkord = GridViewWorkOrders.Rows.Count.ToString();

                LabeltotalWorkOrders.Text = totalWorkord;
             
            }

            TextBoxMWorkId.Text = "";
            TextBoxMWorkId.Focus();
        }

        protected void LoadWorkOrdpage(object sender, GridViewPageEventArgs e)
        {


            GridViewWorkOrders.PageIndex = e.NewPageIndex;
            string ManWId = TextBoxMWorkId.Text;
            LoadWorkOrderGrid(ManWId);
            
        }

        protected void SeeandRecFinOrder(object sender, EventArgs e)
        {
            GridViewRow row = GridViewWorkOrders.SelectedRow;
            string finishdate = Labeltoday.Text.ToString();
            string ManWId = TextBoxMWorkId.Text;
            string orderId= row.Cells[1].Text;
            string productName= row.Cells[2].Text;
            string productSize= row.Cells[3].Text;
            string productShape= row.Cells[4].Text;
            decimal quantity= Convert.ToDecimal(row.Cells[5].Text);
            string productbrand = row.Cells[6].Text;
            string productgage = row.Cells[7].Text;
            decimal length = Convert.ToDecimal(row.Cells[8].Text);
            string accptusr  = Session["UserBy"].ToString();
            string empname = row.Cells[9].Text;
            clsOrder Dal = new clsOrder();
            Dal.MakeOrderManFInord(orderId,productName,quantity,length);

            clsManProducts Dal2 = new clsManProducts();
            Dal2.addorderfinishdate(finishdate,orderId, productName, quantity, length, accptusr);

            clsEmployee empdal = new clsEmployee();

           
           // empdal.UpdateEMPstatusFalse(empname);
            empdal.UpdateTeamstatusFalse(empname);
            GridViewWorkOrders.DataSource = null;
            GridViewWorkOrders.DataBind();

            
            LoadWorkOrderGrid(ManWId);

            
        }

        private void ClearAll()
        {
            TextBoxMWorkId.Text = "";
            string ManWId = TextBoxMWorkId.Text;
            clsManProducts Dal = new clsManProducts();
            DataSet ManProducts = Dal.LoadWorkOrders(ManWId,ware);
            GridViewWorkOrders.DataSource = ManProducts.Tables[0];
            GridViewWorkOrders.DataBind();
            GridViewWorkOrders.DataSource = null;
            LoadWorkOrderGrid(ManWId);
            LabeltotalWorkOrders.Text = "0";
        }

        protected void searchNew(object sender, EventArgs e)
        {
            ClearAll();
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