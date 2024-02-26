using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMrecieveproduct : System.Web.UI.Page
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
                LoadrecSntFinOrds();
                ButtApSFpro.Visible = false;
            }
           
        }

        private void LoadrecSntFinOrds()
        {
            string shop = Session["UserName"].ToString();
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadRecieveSentFinOrds(shop);

            if (Order.Tables[0].Rows.Count != 0)
            {
                GridViewRecSFOrd.DataSource = Order.Tables[0];
                GridViewRecSFOrd.DataBind();
                
                Labeltotalsentpro.Text = GridViewRecSFOrd.Rows.Count.ToString();
                Labelrecorder.Text = GridViewRecSFOrd.Rows.Count.ToString();
            }
            else
            {
                Labeltotalsentpro.Text = "0";
                Labelrecorder.Text = "0";

            }
        }

        protected void ApproveRecieveSF(object sender, EventArgs e)
        {
           if(string.IsNullOrWhiteSpace(TextBoxorderid.Text))
            {

            }
            clsOrder Dal = new clsOrder();
            string OrderId = TextBoxorderid.Text;
            string ProductName = TextBoxproname.Text;
            decimal ProductSize = Convert.ToDecimal(TextBoxprosize.Text);
            string ProductShape = TextBoxproshape.Text;
            decimal Length = Convert.ToDecimal(TextBoxlength.Text);
            decimal Quantity = Convert.ToDecimal(TextBoxproqty.Text);
            string productBrand = TextBoxProBrand.Text;
            string productGage = TextBoxProgage.Text;
            string by = Session["UserName"].ToString();
            string AcceptBy = Session["UserBy"].ToString();
            Dal.LoadSentFinOrder(OrderId, ProductName, ProductSize, productBrand, productGage, Length, Quantity,by, AcceptBy);

            GridViewRecSFOrd.DataSource = null;
            GridViewRecSFOrd.DataBind();

            LoadrecSntFinOrds();
            clearAfterSave();
        }

        private void clearAfterSave()
        {
            TextBoxorderid.Text = "";
            TextBoxorderid.Text = "";
            TextBoxcusname.Text = "";
            TextBoxcusphn.Text = "";

            TextBoxproname.Text = "";
            TextBoxprosize.Text = "";

            TextBoxProBrand.Text = "";
            TextBoxProgage.Text = "";
            TextBoxproshape.Text = "";
            TextBoxlength.Text = "";
            TextBoxproqty.Text = "";
        }

        protected void ApproveSOrdsReciving(object sender, EventArgs e) 
        {
            GridViewRow row = GridViewRecSFOrd.SelectedRow;
            ButtApSFpro.Visible = true;
            TextBoxorderid.Text = row.Cells[1].Text;
            TextBoxcusname.Text = row.Cells[2].Text;
            TextBoxcusphn.Text = row.Cells[3].Text;
           
            TextBoxproname.Text = row.Cells[4].Text;
            TextBoxprosize.Text = row.Cells[5].Text;

            TextBoxProBrand.Text = row.Cells[6].Text;
            TextBoxProgage.Text = row.Cells[7].Text;
            TextBoxproshape.Text = row.Cells[8].Text;
            TextBoxlength.Text = row.Cells[9].Text;
            TextBoxproqty.Text = row.Cells[10].Text;
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        protected void LoadRecSFords(object sender, GridViewPageEventArgs e)
        {
            GridViewRecSFOrd.PageIndex = e.NewPageIndex;
            LoadrecSntFinOrds();
        }
    }
}