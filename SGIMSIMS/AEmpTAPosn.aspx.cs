using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AEmpTAPosn : System.Web.UI.Page
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
            if(!IsPostBack)
            {
                LoadproshapeGrid();
                LoadbrandgageGrid();
            }
           
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        protected void Loadbrandgagepage(object sender, GridViewPageEventArgs e)
        {

            GridViewrmbrandgage.PageIndex = e.NewPageIndex;
            LoadbrandgageGrid();
        }

        protected void Loadbrandgagelst(object sender, EventArgs e)
        {

        }

        protected void Loademptypepage(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Loademptypelst(object sender, EventArgs e)
        {

        }

        protected void Loadempposnpage(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Loadempposnlst(object sender, EventArgs e)
        {

        }

        protected void Buttondltposngrd_Click(object sender, EventArgs e)
        {

        }

        protected void Buttonudtpsngrd_Click(object sender, EventArgs e)
        {

        }

        protected void Buttonaddpsngrd_Click(object sender, EventArgs e)
        {

        }

      

        protected void Button7addbrandgage_Click(object sender, EventArgs e)
        {
            clsSettings settings = new clsSettings();
            Settings obj = InitalizeObject();

            settings.AddBrandGageInfo(obj);

            LoadbrandgageGrid();

            clearAfterSave();

        }

        private Settings InitalizeObject()
        {
           
            Settings settings = new Settings();
          
                settings.ProductBrand = TextBoxbrand.Text;
          
                settings.ProductGage = TextBoxgage.Text;
           
                settings.ProductShape = TextBoxproshape.Text;

                settings.ShapeDetail = TextBoxshapedetail.Text;
           return settings;
        }

        private void clearAfterSave()
        {
            TextBoxbrand.Text = "";
            TextBoxgage.Text = "";
            TextBoxproshape.Text = "";
            TextBoxshapedetail.Text = "";
        }

        private void LoadbrandgageGrid()
        {
            
            clsSettings settings = new clsSettings();
            DataSet brand = settings.LoadBrandGage();

            if (brand.Tables[0].Rows.Count != 0)
            {
                GridViewrmbrandgage.DataSource = brand.Tables[0];
                GridViewrmbrandgage.DataBind();
             
            }
        }

        protected void Buttonudtbrandgage_Click(object sender, EventArgs e)
        {

        }

        protected void Buttondeletebrandgage_Click(object sender, EventArgs e)
        {
             
        }

        protected void Loadshapspage(object sender, GridViewPageEventArgs e)
        {

            GridViewshapes.PageIndex = e.NewPageIndex;
            LoadproshapeGrid();
        }

        protected void Loadproshapelst(object sender, EventArgs e)
        {

        }

        protected void btndltproshape(object sender, EventArgs e)
        {

        }

        protected void addproshapes(object sender, EventArgs e)
        {
            clsSettings settings = new clsSettings();
            Settings obj = InitalizeObject();

            settings.AddShapesInfo(obj);

            LoadproshapeGrid();

            clearAfterSave();
        }

        private void LoadproshapeGrid()
        {
            clsSettings settings = new clsSettings();
            DataSet shape = settings.LoadShape();

            if (shape.Tables[0].Rows.Count != 0)
            {
                GridViewshapes.DataSource = shape.Tables[0];
                GridViewshapes.DataBind();

            }
        }
    }
}