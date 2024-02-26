using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class inventorymanagermain : System.Web.UI.Page
    {
        string ware;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                 ware = Session["UserName"].ToString();
            
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                loadallnotification();
                Labelmsg.Visible = false;
               
            }
        }

        private void loadallnotification()
        {
            string date = DateTime.Now.ToShortTimeString();
            clsReport Dal = new clsReport();
            DataSet invent = Dal.newordnote(ware);
            if (invent.Tables[0].Rows.Count != 0)
            {
                  
                newordnote.Style["visibility"] = "visible";
                newordnote.Style["display"] = "block";
                   
                
            }
            else
            {

            }
            clsReport Dal2 = new clsReport();
            DataSet invent2 = Dal2.deliveryordnote(date,ware);
            if (invent2.Tables[0].Rows.Count != 0)
            {
               

                delordnote.Style["visibility"] = "visible";
                delordnote.Style["display"] = "block";


            }
            else
            {

            }
            clsReport Dal3 = new clsReport();
            DataSet invent3 = Dal3.pmprotnote(ware);
            if (invent3.Tables[0].Rows.Count != 0)
            {


                pmpnote.Style["visibility"] = "visible";
                pmpnote.Style["display"] = "block";


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
            if(string.IsNullOrWhiteSpace(TextBoxewpass.Text) || string.IsNullOrWhiteSpace(TextBoxewpass.Text) || string.IsNullOrWhiteSpace(TextBoxewpass.Text))
            {
                Labelmsg.Visible = true;
                Labelmsg.Text = "አስፈላጊ መረጅዎችን በትክክል ያስገቡ!";
                TextBoxprepass.Focus();
            }
            else if(TextBoxewpass.Text != TextBoxretypenpass.Text)
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