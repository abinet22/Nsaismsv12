using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMEAccept : System.Web.UI.Page
    {
        string byy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                byy = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                Loadallappexpreq();
            }
        }

        private void Loadallappexpreq()
        {
            clsExpense Dal = new clsExpense();

            DataSet rmrec = Dal.LoadAllExpLstApp(byy);

            if (rmrec.Tables[0].Rows.Count != 0)
            {

                GridViewAppExpenseList.DataSource = rmrec.Tables[0];
                GridViewAppExpenseList.DataBind();
                totalappexlst.Text = (GridViewAppExpenseList.DataSource as DataTable).Rows.Count.ToString();

            }
            else
            {

                totalappexlst.Text = "0";


            }
        }

        protected void withdrowmoney(object sender, EventArgs e)
        {   
            string payerun = Session["UserBy"].ToString();
            string expid = TextBoxexpreqid.Text;
            string EDate = DateTime.Now.ToShortDateString();
            DateTime ExppayDate = Convert.ToDateTime(EDate);
            clsExpense Dal = new clsExpense();
            Dal.UpdateExpLstPay(expid, ExppayDate, payerun);


            GridViewAppExpenseList.DataSource = null;
            GridViewAppExpenseList.DataBind();
            Loadallappexpreq();
            clearall();
        }

        private void clearall()
        {
            TextBoxexpreqid.Text = "";
            TextBoxexpreason.Text = "";
            TextBoxpaidto.Text = "";
            TextBoxpayamount.Text = "";
            TextBoxnote.Text = "";
            TextBoxpaidby.Text = "";
            Buttonpay.Visible = false;
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void selectappexlistdetail(object sender, EventArgs e)
        {
            Buttonpay.Visible = true;
            GridViewRow row = GridViewAppExpenseList.SelectedRow;
           
            TextBoxexpreqid.Text = row.Cells[1].Text;
            TextBoxexpreason.Text = row.Cells[2].Text;
            TextBoxpaidto.Text = row.Cells[3].Text;
            TextBoxpayamount.Text = row.Cells[4].Text;
            TextBoxnote.Text = row.Cells[5].Text;
            TextBoxpaidby.Text = Session["UserBy"].ToString();


        }

        protected void nextexplstpage(object sender, GridViewPageEventArgs e)
        {
            GridViewAppExpenseList.PageIndex = e.NewPageIndex;
            Loadallappexpreq();
        }
    }
}