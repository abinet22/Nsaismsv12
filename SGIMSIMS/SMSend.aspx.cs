using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMSend : System.Web.UI.Page
    {
        string username, senderun;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                username = Session["UserName"].ToString();
                 senderun = Session["UserBy"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            LoadAppRMlistGird();
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void sendrm(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxreqid.Text) && string.IsNullOrWhiteSpace(TextBoxrmwidth.Text) && string.IsNullOrWhiteSpace(TextBoxrmlength.Text))
            {

            }
            else
            {
                if(TextBoxwarehouseto.Text=="Admin")
                {
                    string Recid = TextBoxreqid.Text;
                    clsRMRequest Dal = new clsRMRequest();
                    Dal.SendRecRM(Recid, senderun);
                    string protype = "RMaterial";
                    string RMaterialWare = "Admin";
                    decimal quantity = Convert.ToDecimal(TextBoxrmwidth.Text) * Convert.ToDecimal(TextBoxrmlength.Text);
                    string proname = TextBoxbrand.Text;
                    string progage = TextBoxgage.Text;

                    clsProduct Dal2 = new clsProduct();
                    Dal2.UpdatePreManProQty(proname, progage, username, quantity, protype);
                    clsRowMaterial Dal3 = new clsRowMaterial();
                    //RowMaterial obj = InitalizeObject();
                    Dal3.AddNewRowmat(Recid, proname, progage, quantity, 0, RMaterialWare);

                    ClearAll();

                    LoadAppRMlistGird();
                }
                else
                {
                    string Recid = TextBoxreqid.Text;
                    clsRMRequest Dal = new clsRMRequest();
                    Dal.SendRecRM(Recid, senderun);
                    string protype = "RMaterial";

                    decimal quantity = Convert.ToDecimal(TextBoxrmwidth.Text) * Convert.ToDecimal(TextBoxrmlength.Text);
                    string proname = TextBoxbrand.Text;
                    string progage = TextBoxgage.Text;
                    clsProduct Dal2 = new clsProduct();
                    Dal2.UpdatePreManProQty(proname, progage, username, quantity, protype);


                    ClearAll();

                    LoadAppRMlistGird();
                }
               
            }
            
        }

        private void LoadAppRMlistGird()
        {
            clsRMRequest Dal = new clsRMRequest();
            string from= Session["UserName"].ToString();
            DataSet rmrec = Dal.LoadAppReq(from);

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

        private void ClearAll()
        {
            TextBoxreqid.Text = "";
            TextBoxrmlength.Text = "";
            TextBoxrmwidth.Text = "";
            TextBoxwarehouseto.Text = "";
            TextBoxbrand.Text = "";
            TextBoxgage.Text = "";
            GridViewReqList.DataSource = null;
            GridViewReqList.DataBind();
            LoadAppRMlistGird();
            Buttonsendrm.Visible = false;
        }

        protected void viewdtlsndrmreq(object sender, EventArgs e)
        {
            GridViewRow row = GridViewReqList.SelectedRow;
            TextBoxreqid.Text = row.Cells[1].Text;
            TextBoxrmlength.Text = row.Cells[5].Text;
            TextBoxrmwidth.Text = row.Cells[4].Text;
            TextBoxwarehouseto.Text = row.Cells[6].Text;
            TextBoxbrand.Text = row.Cells[2].Text;
            TextBoxgage.Text = row.Cells[3].Text;
            Buttonsendrm.Visible = true;
        }
    }
}