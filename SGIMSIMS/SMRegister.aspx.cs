using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMRegister : System.Web.UI.Page
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
            if (IsPostBack)
            {
                loadPMProlst();
                Labelmessage.Visible = false;
                //premanreq.Style["visibility"] = "hidden";
                //premanreq.Style["display"] = "none";
                sendpremanpro.Style["visibility"] = "visible";
                sendpremanpro.Style["display"] = "block";
            }
        }

        private void loadapproveprolstgrid()
        {
            clsPMPequest Dal = new clsPMPequest();
            string RecBy = Session["UserName"].ToString();
            DataSet pmprec = Dal.LoadSentReq(RecBy);

            if (pmprec.Tables[0].Rows.Count != 0)
            {

                GridViewprolst.DataSource = pmprec.Tables[0];
                GridViewprolst.DataBind();

                Labeltotalprodt.Text = (GridViewprolst.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {


            }
        }

        private void loadPMProlst()
        {
         
            clsProduct pmp = new clsProduct();
            string type = "Pre-Manufucture";
            DataSet progage = pmp.FillProname(type);
            DropDownListproname.DataTextField = "ProductName";
            DropDownListproname.DataValueField = "ProductName";
            DropDownListproname.DataSource = progage.Tables[0];
            DropDownListproname.DataBind();
            DropDownListproname.Items.Insert(0, "--የምርት ስም ምረጥ--");
            DropDownListproname.Items[0].Value = "0";
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

     

        protected void Loadprodpage(object sender, GridViewPageEventArgs e)
        {

            GridViewprolst.PageIndex = e.NewPageIndex;
            loadapproveprolstgrid();
        }

        protected void Loadproductlst(object sender, EventArgs e)
        {
            GridViewRow row = GridViewprolst.SelectedRow;

            string acptdate = DateTime.Now.ToShortDateString();
            string Recid = row.Cells[1].Text;
            string AcceptBy = Session["UserBy"].ToString();
            clsPMPequest Dal = new clsPMPequest();
           
            Dal.AccptAppRmReq(Recid, acptdate, AcceptBy);
            GridViewprolst.DataSource = null;
            GridViewprolst.DataBind();
            loadapproveprolstgrid();
        }

        protected void genpmproreqid(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToShortDateString();
           
            var guid = Guid.NewGuid().ToString().Substring(0, 3);
            string uniqueid = date.ToString() + '-' + guid;
          
           TextBoxproid.Text = "PMPReq" + '-' + uniqueid;
         
        }

        protected void sendpmprorqst(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxproid.Text) || string.IsNullOrWhiteSpace(TextBoxwidth.Text) || string.IsNullOrWhiteSpace(TextBoxlen.Text) || string.IsNullOrWhiteSpace(TextBoxqty.Text) || DropDownListproname.SelectedValue=="0")
            {
                Labelmessage.Visible = true;
                Labelmessage.Text = "ፎርሙን ምትክክል ይሙሉ።";
            }
            else
            {
                string pMPid = TextBoxproid.Text;

                string pmProname = DropDownListproname.SelectedItem.ToString();

                decimal quantity = Convert.ToDecimal(TextBoxqty.Text);
                string reqdt = DateTime.Now.ToShortDateString();
                string reqby = Session["UserName"].ToString();
                string status = "Requested";
                decimal width = Convert.ToDecimal(TextBoxwidth.Text);
                decimal length = Convert.ToDecimal(TextBoxlen.Text);
                clsPMPequest Dal = new clsPMPequest();
                Dal.AddNewPMPrequest(pMPid, pmProname, quantity, reqdt, reqby, status, width, length);

                clearaftersave();
            }
            
        }

        private void clearaftersave()
        {
            TextBoxproid.Text = "";
            DropDownListproname.SelectedValue = "0";
            TextBoxqty.Text = "";
        }

        protected void showpremanreq(object sender, EventArgs e)
        {

            sendpremanpro.Style["visibility"] = "hidden";
            sendpremanpro.Style["display"] = "none";
            premanreq.Style["visibility"] = "visible";
            premanreq.Style["display"] = "block";
            GridViewprolst.DataSource = null;
            GridViewprolst.DataBind();
        }

        protected void showrecpreman(object sender, EventArgs e)
        {
            premanreq.Style["visibility"] = "hidden";
            premanreq.Style["display"] = "none";
            sendpremanpro.Style["visibility"] = "visible";
            sendpremanpro.Style["display"] = "block";
            loadapproveprolstgrid();
        }
    }
}