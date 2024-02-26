using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                loadallbrand();
            }

            
           

        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        private void loadallbrand()
        {
           
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownrmbrand.DataTextField = "ProductBrand";
            DropDownrmbrand.DataValueField = "ProductBrand";
            DropDownrmbrand.DataSource = probrand.Tables[0];
            DropDownrmbrand.DataBind();
            DropDownrmbrand.Items.Insert(0, "--የጥሬ ዕቃ አይነት ምረጥ--");
            DropDownrmbrand.Items[0].Value = "0";
        }

        private void loadallgages(string brand)
        {
           
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListrmgage.DataTextField = "ProductGage";
            DropDownListrmgage.DataValueField = "ProductGage";
            DropDownListrmgage.DataSource = progage.Tables[0];
            DropDownListrmgage.DataBind();
            DropDownListrmgage.Items.Insert(0, "--የጥሬ ዕቃ ጌጅ ምረጥ--");
            DropDownListrmgage.Items[0].Value = "0";
        }

        protected void generateRequestid(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToShortDateString();

            var guid = Guid.NewGuid().ToString().Substring(0, 3);
            string uniqueid = date.ToString() + '-' + guid;

            TextBoxMReqId.Text = "RMReq" + '-' + uniqueid;
            
           
        }

        protected void sendrmrequest(object sender, EventArgs e)
        {
            clsRMRequest Dal = new clsRMRequest();
            RMRequest obj = InitalizeObject();
            Dal.AddNewRMrequest(obj);
                       

            clearAfterSave();

        }

        private RMRequest InitalizeObject()
        {
            RMRequest rmr = new RMRequest();

            string date = DateTime.Now.ToShortDateString();
            string by = Session["UserName"].ToString();

            rmr.RMWidth = Convert.ToDecimal(TextBoxrmwidth.Text);
            rmr.RMLength= Convert.ToDecimal(TextBoxrmlength.Text);
            rmr.RMRecID = TextBoxMReqId.Text;
            rmr.RecDate = date;
            rmr.RecBy = by;
            rmr.RMGage = DropDownListrmgage.SelectedItem.ToString();
            rmr.RMBrand = DropDownrmbrand.SelectedItem.ToString();
            rmr.Status = "Requested";
            return rmr;

        }

        private void clearAfterSave()
        {
            TextBoxMReqId.Text = "";
            TextBoxrmlength.Text = "";
            TextBoxrmwidth.Text = "";
            DropDownListrmgage.SelectedValue = "0";
            DropDownrmbrand.SelectedValue = "0";

        }

        protected void loadbrandgages(object sender, EventArgs e)
        {
            string brand = DropDownrmbrand.SelectedItem.ToString();
            DropDownListrmgage.Items.Clear();
            loadallgages(brand);
        }
    }
}