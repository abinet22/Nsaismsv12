using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AShopinfo : System.Web.UI.Page
    {
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

        protected void addshp(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxshpid.Text)|| string.IsNullOrWhiteSpace(TextBoxshpphn.Text) || string.IsNullOrWhiteSpace(TextBoxshpname.Text) || string.IsNullOrWhiteSpace(TextBoxshpadd.Text))
            {
                //error msg
                
             
            }
            else
            {
                clsShop Dal = new clsShop();
                Shop obj = InitalizeObject();
                Dal.AddShopInfo(obj);
                Clearallaftersave();
                LoadWaretoGrid();
            }
               
        }

        private void LoadWaretoGrid()
        {

            clsShop Dal = new clsShop();
            DataSet shop = Dal.LoadShopInfo();

            if (shop.Tables[0].Rows.Count != 0)
            {
                GridViewshpinfo.DataSource = shop.Tables[0];
                GridViewshpinfo.DataBind();
                //Labelrecorder.Text = GridViewshpinfo.Rows.Count.ToString();
            }
            else
            {
               


            }
        }

        private void Clearallaftersave()
        {
            TextBoxshpid.Text = "";
            TextBoxshpname.Text = "";
            TextBoxshpadd.Text = "";
           
            TextBoxshpphn.Text = "";
        }

        private Shop InitalizeObject()
        {
            Shop shop = new Shop();

            shop.ShopId = TextBoxshpid.Text;
            shop.ShopName = TextBoxshpname.Text;
            shop.ShopAddress = TextBoxshpadd.Text;
            shop.ShopManagerPhn = TextBoxshpphn.Text;

            return shop;
        }

        protected void udtshp(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxshpid.Text) || string.IsNullOrWhiteSpace(TextBoxshpphn.Text) || string.IsNullOrWhiteSpace(TextBoxshpname.Text) || string.IsNullOrWhiteSpace(TextBoxshpadd.Text))
            {
                //error msg


            }
            else
            {
                clsShop Dal = new clsShop();
                Shop obj = InitalizeObject();
                Dal.UpdateShop(obj);
                Clearallaftersave();
                LoadWaretoGrid();
            }
        }

        protected void dltshp(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxshpid.Text) ||  string.IsNullOrWhiteSpace(TextBoxshpname.Text) )
            {
                //error msg


            }
            else
            {
                string ShopId = TextBoxshpid.Text;
                clsShop Dal = new clsShop();

                Dal.DeleteShop(ShopId);
                Clearallaftersave();
                LoadWaretoGrid();
            }
        }

        protected void Loadshoingopage(object sender, GridViewPageEventArgs e)
        {
            GridViewshpinfo.PageIndex = e.NewPageIndex;
            LoadWaretoGrid();
        }

        protected void LoadShop(object sender, EventArgs e)
        {
            GridViewRow row = GridViewshpinfo.SelectedRow;
            TextBoxshpid.Text = row.Cells[1].Text;
            TextBoxshpname.Text = row.Cells[2].Text;


        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
    }
}