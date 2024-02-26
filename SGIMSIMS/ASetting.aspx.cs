using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ASetting : System.Web.UI.Page
    {
        string exptype;
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
               
                revlist.Style["visibility"] = "hidden";
                revlist.Style["display"] = "none";
                explist.Style["visibility"] = "hidden";
                explist.Style["display"] = "none";
            }
        }

        private void loadalladdrevlst()
        {
            clsExpense Dal = new clsExpense();

            DataSet rmrec = Dal.LoadAlladdrev();

            if (rmrec.Tables[0].Rows.Count != 0)
            {
               
               GridViewAddRevList.DataSource = rmrec.Tables[0];
                GridViewAddRevList.DataBind();
                totaladdrevtot.Text = (GridViewAddRevList.DataSource as DataTable).Rows.Count.ToString();
               
            }
            else
            {

                totaladdrevtot.Text = "0";


            }
        }

       
        private void loadallexplst()
        {
            clsExpense Dal = new clsExpense();

            DataSet rmrec = Dal.LoadAllpaylist();

            if (rmrec.Tables[0].Rows.Count != 0)
            {

                GridViewexplst.DataSource = rmrec.Tables[0];
                GridViewexplst.DataBind();
                totexpls.Text = (GridViewexplst.DataSource as DataTable).Rows.Count.ToString();
                
            }
            else
            {

                totexpls.Text = "0";


            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void generataddrevid(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 3);


            Textrevid.Text = "AREV" + '-' + guid;
        }

        protected void addnewaddrevlst(object sender, EventArgs e)
        {
            string revid = Textrevid.Text;
            string revname = TextBoxaddrevname.Text;
            string revdt = TextBoxaddrevdate.Text;
            string revamt = TextBorevamount.Text;
          
            clsExpense dal = new clsExpense();
            dal.addnewaddrevlst(revid, revname, revdt, revamt);
            loadalladdrevlst();
            clearaftersafe();
        }

        protected void deletnewaddrevlst(object sender, EventArgs e)
        {
            string revid = Textrevid.Text;
            clsExpense dal = new clsExpense();
            dal.updatenewaddrevlst(revid);
            loadalladdrevlst();
            clearaftersafe();
        }

        protected void generataddexpid(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 3);

            TextBoxexpid.Text = "AEXP" + '-' + guid;
        }

        protected void addexplst(object sender, EventArgs e)
        {
            string expid =   TextBoxexpid.Text;
            string expname = TextBoxexpname.Text;
            string expdt= TextBoxexpdt.Text;
            string expamt =  TextBoxexpamont.Text;
            if(CheckBoxattach.Checked==true)
            {
                exptype = "YES";
            }
            else
            {
                exptype = "NO";
            }
            clsExpense dal = new clsExpense();
            dal.addnewexpenselst(expid, expname, expdt, expamt, exptype);
            loadallexplst();
            clearaftersafe();
        }

        protected void deletnedexplst(object sender, EventArgs e)
        {
            string expid = TextBoxexpid.Text;
            clsExpense dal = new clsExpense();
            dal.updatenewexplist(expid);
            loadallexplst();
            clearaftersafe();
        }

        private void clearaftersafe()
        {
            TextBoxexpid.Text = "";
            TextBoxexpname.Text = "";
            TextBoxexpdt.Text = "";
            TextBoxexpamont.Text = "";
            Textrevid.Text = "";
            TextBoxaddrevname.Text = "";
            TextBoxaddrevdate.Text = "";
            TextBorevamount.Text = "";
        }

        protected void nextpageaddrev(object sender, GridViewPageEventArgs e)
        {

            GridViewAddRevList.PageIndex = e.NewPageIndex;
            loadalladdrevlst();
        }

        protected void viewdtladdrev(object sender, EventArgs e)
        {
            GridViewRow row = GridViewAddRevList.SelectedRow;
            Textrevid.Text = row.Cells[1].Text;
        }

        protected void viewdtlexplst(object sender, EventArgs e)
        {
            GridViewRow row = GridViewexplst.SelectedRow;
            TextBoxexpid.Text = row.Cells[1].Text;
        }

        protected void nexpageexplist(object sender, GridViewPageEventArgs e)
        {
           
            GridViewexplst.PageIndex = e.NewPageIndex;
            loadallexplst();
        }

        protected void showaddrev(object sender, EventArgs e)
        {
            explist.Style["visibility"] = "hidden";
           explist.Style["display"] = "none";
           revlist.Style["visibility"] = "visible";
           revlist.Style["display"] = "block";
          
            loadalladdrevlst();
        }

        protected void showaddexp(object sender, EventArgs e)
        {
           revlist.Style["visibility"] = "hidden";
            revlist.Style["display"] = "none";
            explist.Style["visibility"] = "visible";
            explist.Style["display"] = "block";
            loadallexplst();
        }
    }
}