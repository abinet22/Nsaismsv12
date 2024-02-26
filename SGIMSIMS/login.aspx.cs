using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadinventorymanager();
            }
        }
        private User InitUser()
        {
            User obj = new User();
            obj.UserName = TextBoxun.Text;
            obj.Password = TextBoxpass.Text;
            obj.UserRoll = DropDownListur.SelectedItem.ToString();
            obj.AssignShop = DropDownListas.SelectedItem.ToString();
            return obj;
        }
        private void loadinventorymanager()
        {

            clsUser Dal = new clsUser();
            DataSet probrand = Dal.FillUserNamewITHAD();
            DropDownListas.DataTextField = "AssignShop";
            DropDownListas.DataValueField = "AssignShop";
            DropDownListas.DataSource = probrand.Tables[0];
            DropDownListas.DataBind();
            DropDownListas.Items.Insert(0, "-- Select Assigned Shop--");
            DropDownListas.Items[0].Value = "0";
        }
        protected void Buttonsignin_Click(object sender, EventArgs e)
        {
            string userroll = DropDownListur.SelectedItem.ToString();
           
            clsUser Dal = new clsUser();
            User obj = InitUser();

            DataSet ds = new DataSet();
            ds = Dal.ISValid(obj);
            if (ds.Tables[0].Rows.Count == 1)
            {
                FormsAuthentication.RedirectFromLoginPage(obj.UserName, true);
                if(DropDownListur.SelectedItem.Text == "Admin")
                {
                    Session["UserName"] = ds.Tables[0].Rows[0]["AssignShop"];
                    Session["Userroll"] = userroll;
                    Session["UserBy"] = ds.Tables[0].Rows[0]["UserName"];
                    Response.Redirect("admin.aspx");
                }
                
                else if(DropDownListur.SelectedItem.Text == "Sales Manager")
                    {
                    Session["UserName"] = ds.Tables[0].Rows[0]["AssignShop"];
                    Session["Userroll"] = userroll;
                    Session["UserBy"] = ds.Tables[0].Rows[0]["UserName"];
                    // Response.Redirect(this.ResolveClientUrl("~/Sales/SalesManager.Master"));
                    Response.Redirect("salesmanagermain.aspx");
                }
              
                else if (DropDownListur.SelectedItem.Text == "Inventory Manager")
                {
                    Session["UserName"] = ds.Tables[0].Rows[0]["AssignShop"];
                    Session["Userroll"] = userroll;
                    Session["UserBy"] = ds.Tables[0].Rows[0]["UserName"];
                    Response.Redirect("inventorymanagermain.aspx");
                }
            }

            else
            {
                // lblmessage.Text = "Invalid UserName or Password";
            }


            
        }
    }

}
