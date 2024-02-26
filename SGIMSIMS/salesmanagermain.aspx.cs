using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class salesmanagermain : System.Web.UI.Page
    {
        string byware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] !=null && Session["UserBy"] != null && Session["Userroll"].ToString()== "Sales Manager")
            {
               
             
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                byware = Session["UserName"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            LoadAllMessages();
            //if(!IsPostBack)
            //{
            //    divMessage.Style["visibility"] = "hidden";
            //    divMessage.Style["display"] = "none";
            //    divMessage2.Style["visibility"] = "hidden";
            //    divMessage2.Style["display"] = "none";

            //    divMessage3.Style["visibility"] = "hidden";
            //    divMessage3.Style["display"] = "none";


            //    divMessage1.Style["visibility"] = "hidden";
            //    divMessage1.Style["display"] = "none";
            //}
        }

        private void LoadAllMessages()
        {
           
          
            clsReport Dal = new clsReport();
            DataSet invent = Dal.AllCheckMessagesrm(byware);
            if (invent.Tables[0].Rows.Count != 0)
            {
                decimal rm = Convert.ToDecimal((invent.Tables[0].Rows[0][0]).ToString());

                if (rm>1)
                {
                    divMessage.Style["visibility"] = "visible";
                    divMessage.Style["display"] = "block";
                    Labelrm.Text = rm.ToString();
                }
                else
                {

                }
            }
            else
            {

            }
            DataSet invent2 = Dal.AllCheckMessagespp(byware);
            if (invent2.Tables[0].Rows.Count != 0)
            {
                decimal pp = Convert.ToDecimal((invent2.Tables[0].Rows[0][0]).ToString());
                if (pp > 1)
                {
                    divMessage1.Style["visibility"] = "visible";
                    divMessage1.Style["display"] = "block";
                    Labelppro.Text = pp.ToString();
                }
                else
                {

                }
            }
            else
            {

            }
            DataSet invent3 = Dal.AllCheckMessagespmp(byware);
            if (invent3.Tables[0].Rows.Count != 0)
            {
                decimal pmp = Convert.ToDecimal((invent3.Tables[0].Rows[0][0]).ToString());
                if (pmp > 1)
                {
                    Labelpmpro.Text = pmp.ToString();
                    divMessage2.Style["visibility"] = "visible";
                    divMessage2.Style["display"] = "block";
                }
                else
                {

                }
            }
            else
            {

            }
            DataSet invent4 = Dal.Allcredittrans(byware);
            if (invent4.Tables[0].Rows.Count != 0)
            {
                int pmp = invent4.Tables[0].Rows.Count;
                if (pmp > 1)
                {

                    Labelcredit.Text = pmp.ToString();
                    divcredit.Style["visibility"] = "visible";
                    divcredit.Style["display"] = "block";
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


        protected void changepassword(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxewpass.Text) || string.IsNullOrWhiteSpace(TextBoxewpass.Text) || string.IsNullOrWhiteSpace(TextBoxewpass.Text))
            {
                Labelmsg.Visible = true;
                Labelmsg.Text = "አስፈላጊ መረጅዎችን በትክክል ያስገቡ!";
                TextBoxprepass.Focus();
            }
            else if (TextBoxewpass.Text != TextBoxretypenpass.Text)
            {
                Labelmsg.Visible = true;
                Labelmsg.Text = "አዲስ ያስገቡት መላያ ተመሳሳይ አይደለም!";
                TextBoxprepass.Focus();
            }
            else
            {
                string user = Session["UserBy"].ToString();
                string userroll = Session["Userroll"].ToString();
                string password = TextBoxprepass.Text;
                string newpass = TextBoxewpass.Text;
                string newpassre = TextBoxretypenpass.Text;
                clsUser Dal = new clsUser();

                DataSet ds = Dal.FindPassword(user, password);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    clsUser Dal2 = new clsUser();

                    Dal.UpdatePassword(user, newpass, userroll);
                    Labelmsg.Visible = true;
                    Labelmsg.Text = "አዲስ መላያ ቀይረዋል!";
                    clearall();
                }

                else
                {
                    Labelmsg.Visible = true;
                    Labelmsg.Text = "የተሳሳተ መለያ ነው ያስገቡት!";
                    TextBoxprepass.Focus();

                }
            }


        }

        private void clearall()
        {
            TextBoxprepass.Text = "";
            TextBoxretypenpass.Text = "";
            TextBoxewpass.Text = "";
        }
    }
}