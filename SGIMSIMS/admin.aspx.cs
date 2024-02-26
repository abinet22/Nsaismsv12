using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class admin : System.Web.UI.Page
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
                LoadAllMessahenot();
            }
           
        }

        private void LoadAllMessahenot()
        {
            clsReport Dal = new clsReport();
            DataSet invent = Dal.AllCheckMessagesrm();
            if (invent.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent.Tables[0].Rows[0][0]).ToString());

                if (rm > 1)
                {

                    divMessagermlost.Style["visibility"] = "visible";
                    divMessagermlost.Style["display"] = "block";
                    Labelrmlost.Text = rm.ToString();
                }
                else
                {

                }
            }
            else
            {

            }
            clsReport Dal2 = new clsReport();
            DataSet invent2 = Dal2.AllCheckMessagespp();
            if (invent2.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent2.Tables[0].Rows[0][0]).ToString());

                if (rm > 1)
                {

                    divMessagepplost.Style["visibility"] = "visible";
                    divMessagepplost.Style["display"] = "block";
                    Labelpplost.Text = rm.ToString();
                }
                else
                {

                }
            }
            else
            {

            }
            clsReport Dal3 = new clsReport();
            DataSet invent3 = Dal3.AllCheckMessagespmp();
            if (invent3.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent3.Tables[0].Rows[0][0]).ToString());

                if (rm > 1)
                {

                    divMessagepmplost.Style["visibility"] = "visible";
                    divMessagepmplost.Style["display"] = "block";
                    Labelpmplost.Text = rm.ToString();
                   
                }
                else
                {

                }
            }
            else
            {

            }
            clsReport Dal4 = new clsReport();
            DataSet invent4 = Dal4.LoadAllRMReqs();
            if (invent4.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent4.Tables[0].Rows[0][0]).ToString());

                if (rm > 1)
                {

                    divMessagermreq.Style["visibility"] = "visible";
                    divMessagermreq.Style["display"] = "block";
                    Labelrmreq.Text = rm.ToString();
                    
                }
                else
                {

                }
            }
            else
            {

            }
            clsReport Dal5 = new clsReport();
            DataSet invent5 = Dal5.LoadAllExpLsts();
            if (invent5.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent5.Tables[0].Rows[0][0]).ToString());

                if (rm > 1)
                {

                    divMessageexreq.Style["visibility"] = "visible";
                    divMessageexreq.Style["display"] = "block";
                    Labelexreq.Text = rm.ToString();
                    
                }
                else
                {

                }
            }
            else
            {

            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
    }
}