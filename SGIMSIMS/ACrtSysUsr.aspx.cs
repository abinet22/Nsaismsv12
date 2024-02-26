using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ACrtSysUsr : System.Web.UI.Page
    {
        string usertype;
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
            if(!IsPostBack)
            {
                LoadShopName();
                LoadUsrtoGrid();
                Buttonudtusr.Visible = false;
                Buttonaddusr.Visible = true;
                Buttondltusr.Visible = false;
            }
          
        }

        protected void addusr(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(TextBoxpassword.Text) || string.IsNullOrEmpty(TextBoxusrid.Text) || string.IsNullOrEmpty(TextBoxusrid.Text) || DropDownListshoplst.SelectedValue == "0" || DropDownListuroll.SelectedValue == "0")
            {
               //error
            }
            else
            {
                clsUser Dal = new clsUser();
                User obj = InitalizeObject();
                Dal.AddNewUser(obj);
                Clearallaftersave();
                LoadUsrtoGrid();
            }
           
        }

        private void LoadUsrtoGrid()
        {

            clsUser Dal = new clsUser();
            DataSet shop = Dal.LoadUser();

            if (shop.Tables[0].Rows.Count != 0)
            {

                GridViewUsrLst.DataSource = shop.Tables[0];
                GridViewUsrLst.DataBind();
                //Labelrecorder.Text = GridViewshpinfo.Rows.Count.ToString();
            }
            else
            {



            }

            
        }
        private void LoadShopName()
        {
            DropDownListshoplst.Items.Clear();
            DropDownListshoplst.DataSource = null;
            DropDownListshoplst.DataBind();
            clsShop Dal = new clsShop();
            DataSet shopname = Dal.LoadShopName();

            DropDownListshoplst.DataTextField = "ShopName";
            DropDownListshoplst.DataValueField = "ShopName";
            DropDownListshoplst.DataSource = shopname.Tables[0];
            DropDownListshoplst.DataBind();
            DropDownListshoplst.Items.Insert(0, "-- Select Shop Name--");
            DropDownListshoplst.Items[0].Value = "0";

        }

        private void Clearallaftersave()
        {
            TextBoxpassword.Text = "";
            TextBoxusrid.Text = "";
            TextBoxusrname.Text = "";
            DropDownListshoplst.SelectedValue = "0";
            DropDownListuroll.SelectedValue = "0";
        }

        private User InitalizeObject()
        {
            User user = new User();

           user.Password = TextBoxpassword.Text;
           user.UserId = TextBoxusrid.Text;
           user.UserName =  TextBoxusrname.Text;
           user.AssignShop = DropDownListshoplst.SelectedItem.ToString();
           user.UserRoll = DropDownListuroll.SelectedItem.ToString();
            if (CheckBoxattach.Checked == true)
            {
                usertype = "YES";
            }
            else
            {
                usertype = "NO";
            }

            user.IsAdmin = usertype;

            return user;
        }

        protected void udtusr(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxpassword.Text) || string.IsNullOrEmpty(TextBoxusrid.Text) || string.IsNullOrEmpty(TextBoxusrid.Text) || DropDownListuroll.SelectedValue=="0")
            {
                //error
            }
            else
            {
                clsUser Dal = new clsUser();
                User obj = InitalizeObject();
                Dal.UpdateUser(obj);
                Clearallaftersave();
                LoadUsrtoGrid();
            }

        }

        protected void dltusr(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxpassword.Text) || string.IsNullOrEmpty(TextBoxusrid.Text) )
            {
                //error
            }
            else
            {
                string userid = TextBoxusrid.Text;
                clsUser Dal = new clsUser();
          
                Dal.DeleteUser(userid);
                Clearallaftersave();
                LoadUsrtoGrid();
            }
        }

        protected void Loadsysusrpage(object sender, GridViewPageEventArgs e)
        {
            GridViewUsrLst.PageIndex = e.NewPageIndex;
            LoadUsrtoGrid();
        }

        protected void Loadsysuserlst(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUsrLst.SelectedRow;
            TextBoxusrid.Text = row.Cells[1].Text;
            TextBoxpassword.Text = row.Cells[3].Text;
            TextBoxusrname.Text = row.Cells[2].Text;
            DropDownListshoplst.Visible = false;
          
            Buttonudtusr.Visible = true;
            Buttonaddusr.Visible = false;
            Buttondltusr.Visible = true;
        }

        protected void Genproductid(object sender, EventArgs e)
        {
            Buttonaddusr.Visible = true;
            var guid = Guid.NewGuid().ToString().Substring(0, 4);

            TextBoxusrid.Text = "User" + '-' + guid;
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
    }
}