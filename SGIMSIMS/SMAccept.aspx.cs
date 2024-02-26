using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMAccept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                Labelsession.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            LoadAppRMlistGird();
        }

        private void LoadAppRMlistGird()
        {
            clsRMRequest Dal = new clsRMRequest();
            string RecBy = Session["UserName"].ToString();
            DataSet rmrec = Dal.LoadSentReq(RecBy);

            if (rmrec.Tables[0].Rows.Count != 0)
            {

                GridViewReqList.DataSource = rmrec.Tables[0];
                GridViewReqList.DataBind();
                totalapptransfer.Text = GridViewReqList.Rows.Count.ToString();
              
            }
            else
            {

                totalapptransfer.Text = "0";


            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void acceptrm(object sender, EventArgs e)
        {
            string acptdate = DateTime.Now.ToShortDateString();
            string Recid = TextBoxreqid.Text;
            string rmacptby = Session["UserBy"].ToString();
            clsRMRequest Dal = new clsRMRequest();
            Dal.AccptAppRmReq(Recid, acptdate, rmacptby);
            string RMaterialBrand = TextBoxbrand.Text;
            string RMaterialGage = TextBoxgage.Text;

            decimal width = Convert.ToDecimal(TextBoxrmwidth.Text);
            decimal length = Convert.ToDecimal(TextBoxrmlength.Text);
            decimal newqty = width * length;


            string RMaterialWare = Session["UserName"].ToString();
            //addrowmaterialinventoryhere
            clsRowMaterial udt = new clsRowMaterial();
            udt.Minusrmatudt(RMaterialBrand, RMaterialGage, newqty, RMaterialWare);
            //addrowmaterialinventoryhere

            ClearAll();
           // LoadAppRMlistGird();
        }

        private void ClearAll()
        {
            TextBoxreqid.Text = "";
            TextBoxbrand.Text = "";
            TextBoxgage.Text = "";

            TextBoxrmwidth.Text = "";
            TextBoxrmlength.Text = "";
            TextBoxrecdate.Text = "";
            TextBoxwarehouseto.Text = "";
            GridViewReqList.DataSource = null;
            GridViewReqList.DataBind();
            LoadAppRMlistGird();
            Buttonacceptrm.Visible = false;
        }

        protected void viewdetail(object sender, EventArgs e)
        {
              GridViewRow row = GridViewReqList.SelectedRow;
            TextBoxreqid.Text = row.Cells[1].Text;
            TextBoxbrand.Text = row.Cells[2].Text;
            TextBoxgage.Text = row.Cells[3].Text;
          
            TextBoxrmwidth.Text = row.Cells[4].Text;
            TextBoxrmlength.Text = row.Cells[5].Text;
            TextBoxrecdate.Text = row.Cells[6].Text;
            TextBoxwarehouseto.Text = row.Cells[7].Text;
            Buttonacceptrm.Visible = true;

        }

        protected void acceptrmnxtpage(object sender, GridViewPageEventArgs e)
        {
            GridViewReqList.PageIndex = e.NewPageIndex;
            LoadAppRMlistGird();
        }
    }
}