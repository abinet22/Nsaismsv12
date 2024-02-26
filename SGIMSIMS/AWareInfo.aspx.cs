using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AWareInfo1 : System.Web.UI.Page
    {
        int id;
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
            LoadWaretoGrid();
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        protected void LoadWarehousepage(object sender, GridViewPageEventArgs e)
        {
            GridViewLoadWarehouse.PageIndex = e.NewPageIndex; 
            LoadWaretoGrid();
        }
        private void LoadWaretoGrid()
        {
            clsWarehouse Dal = new clsWarehouse();
            DataSet Order = Dal.LoadWarehouseGrid();

            if (Order.Tables[0].Rows.Count != 0)
            {
                GridViewLoadWarehouse.DataSource = Order.Tables[0];
                GridViewLoadWarehouse.DataBind();
                //LabeltotalrecOrders.Text = GridViewRecAssignOrder.Rows.Count.ToString();
                //Labelrecorder.Text = GridViewRecAssignOrder.Rows.Count.ToString();
            }  
            else
            {
                //Labelrecorder.Text = "0";
                //LabeltotalrecOrders.Text = "0";


            }
        }
        protected void LoadWarehouse(object sender, EventArgs e)
        {
            GridViewRow row = GridViewLoadWarehouse.SelectedRow;

            id = Convert.ToInt32(row.Cells[1].Text);
            TextBoxwarename.Text = row.Cells[2].Text;
            TextBoxwareadd.Text = row.Cells[3].Text;
            TextBoxwaremgr.Text = row.Cells[4].Text;
            TextBoxwarephn.Text = row.Cells[5].Text;
           
        }

        protected void addwarehuse(object sender, EventArgs e)
        {
            clsWarehouse Dal = new clsWarehouse();
            Warehouse obj = InitalizeObject();
            Dal.AddNewWarehouse(obj);
            Clearallaftersave();
            LoadWaretoGrid();
        }

        private void Clearallaftersave()
        {
            TextBoxwarename.Text = "";
           TextBoxwareadd.Text = "";
            TextBoxwaremgr.Text = "";
            TextBoxwarephn.Text = "";
        }

        private Warehouse InitalizeObject()
        {
            Warehouse Ware = new Warehouse();

            Ware.WareName = TextBoxwarename.Text;
            Ware.WareAddress = TextBoxwareadd.Text;
            Ware.WareManager = TextBoxwaremgr.Text;
            Ware.WareManagerPhn = TextBoxwarephn.Text;
            return Ware;
        }

        protected void updatewarehouse(object sender, EventArgs e)
        {

           string warename= TextBoxwarename.Text;
           string wareadd= TextBoxwareadd.Text;
           string waremgr =  TextBoxwaremgr.Text;
          string warephn =   TextBoxwarephn.Text;
            clsWarehouse Ware = new clsWarehouse();
            Ware.UpdateWarehouse(id, warename, wareadd, waremgr, warephn);
            Clearallaftersave();
            LoadWaretoGrid();
        }

        protected void deletewarehouse(object sender, EventArgs e)
        {
            string warename = TextBoxwarename.Text;
            string wareadd = TextBoxwareadd.Text;
            string waremgr = TextBoxwaremgr.Text;
            string warephn = TextBoxwarephn.Text;
            clsWarehouse Ware = new clsWarehouse();
          
            Ware.DeleteWarehouse(id);
            Clearallaftersave();
            LoadWaretoGrid();
        }
    }
}