using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AExpReqList : System.Web.UI.Page
    {
        string addnote;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["Userroll"].ToString() == "Admin")
            {
                Labelsession.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                loadallreq();
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Div1.Style["visibility"] = "hidden";
                Div1.Style["display"] = "none";
            }
        }

        private void loadallreq()
        {
            clsExpense Dal = new clsExpense();

            DataSet rmrec = Dal.LoadAllExpLst();

            if (rmrec.Tables[0].Rows.Count != 0)
            {

                GridViewReqList.DataSource = rmrec.Tables[0];
                GridViewReqList.DataBind();
                LabelreqEmp.Text = (GridViewReqList.DataSource as DataTable).Rows.Count.ToString();

            }
            else
            {

                LabelreqEmp.Text = "0";


            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        protected void loadexpensereqdet(object sender, EventArgs e)
        {
            GridViewRow row = GridViewReqList.SelectedRow;
            TextBoxexprecId.Text = row.Cells[1].Text;
            TextBoxexpreason.Text = row.Cells[2].Text;
            TextBoxempname.Text = row.Cells[3].Text;
            TextBoxayamnt.Text = row.Cells[4].Text;
            TextBoxnote.Text = row.Cells[5].Text;
            TextBoxreqby.Text = row.Cells[6].Text;

            if(TextBoxexpreason.Text == "Employee Salary" ||  TextBoxexpreason.Text == "AdvancePayment")
            {
                empslaexp.Style["visibility"] = "visible";
                empslaexp.Style["display"] = "block";
                Div1.Style["visibility"] = "hidden";
                Div1.Style["display"] = "none";
                string empname = TextBoxempname.Text;
                clsEmployee dal = new clsEmployee();
                DataSet ds = dal.loadempdata(empname);

                if (ds.Tables[0].Rows.Count != 0)
                {

                    TextBoxsaltype.Text = ds.Tables[0].Rows[0][0].ToString();

                    TextBoxayamnt.Text = ds.Tables[0].Rows[0][1].ToString();

                }
                else
                {
                    //error

                }

                clsExpense dal2 = new clsExpense();
                DataSet ds2 = dal2.checklastpfemp(empname);
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    DateTime day = Convert.ToDateTime(ds2.Tables[0].Rows[0][0].ToString());
                    TextBoxlastaydt.Text = Convert.ToString(day);

                    if (TextBoxsaltype.Text == "Daily")
                    {
                        DateTime end = day.AddDays(1);
                        TextBoxnxtsalarydt.Text = Convert.ToString(end);
                    }
                    else if (TextBoxsaltype.Text == "Weekly")
                    {
                        DateTime end = day.AddDays(7);
                        TextBoxnxtsalarydt.Text = Convert.ToString(end);
                    }
                    else if (TextBoxsaltype.Text == "Monthly")
                    {
                        DateTime end = day.AddDays(30);
                        TextBoxnxtsalarydt.Text = Convert.ToString(end);
                    }
                    else
                    {

                    }

                }
                else
                {

                    clsEmployee dal5 = new clsEmployee();
                    DataSet ds5 = dal5.checkempwrkstrt(empname);
                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        DateTime day = Convert.ToDateTime(ds5.Tables[0].Rows[0][0].ToString());
                        TextBoxlastaydt.Text = Convert.ToString(day);

                        if (TextBoxsaltype.Text == "Daily")
                        {
                            DateTime end = day.AddDays(1);
                            TextBoxnxtsalarydt.Text = Convert.ToString(end);
                        }
                        else if (TextBoxsaltype.Text == "Weekly")
                        {
                            DateTime end = day.AddDays(7);
                            TextBoxnxtsalarydt.Text = Convert.ToString(end);
                        }
                        else if (TextBoxsaltype.Text == "Monthly")
                        {
                            DateTime end = day.AddDays(30);
                            TextBoxnxtsalarydt.Text = Convert.ToString(end);
                        }
                        else
                        {

                        }
                    }
                }

                clsExpense dal3 = new clsExpense();
                DataSet ds3 = dal3.advancepay(empname);
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    TextBoxadvanceay.Text = ds3.Tables[0].Rows[0][0].ToString();


                }
                else
                {

                  
                }

            }
            else if(TextBoxexpreason.Text == "Other")
            {
                Div1.Style["visibility"] = "visible";
                Div1.Style["display"] = "block";
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
            }
            else
            {
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Div1.Style["visibility"] = "hidden";
                Div1.Style["display"] = "none";
            }

           
              
        }

        protected void confirmxprequest(object sender, EventArgs e)
        {
            string expid = TextBoxexprecId.Text;
            if (TextBoxexpreason.Text == "Employee Salary" || TextBoxexpreason.Text == "AdvancePayment")
            {
                addnote = "Yes";
            }
              
            else if(TextBoxexpreason.Text == "Other")
            {
                string paytype = TextBoxempname.Text;
                clsExpense dal3 = new clsExpense();
                DataSet ds3 = dal3.checkaddtionalinfo(paytype);
                if (ds3.Tables[0].Rows.Count != 0)
                {

                    addnote = ds3.Tables[0].Rows[0][0].ToString();


                }
                else
                {


                }
            }
            clsExpense Dal = new clsExpense();
            Dal.UpdateconfirmExpLst(expid, addnote);
            GridViewReqList.DataSource = null;
            GridViewReqList.DataBind();
            loadallreq();
            clearall();

        }

        private void clearall()
        {

            empslaexp.Style["visibility"] = "hidden";
            empslaexp.Style["display"] = "none";
            TextBoxexprecId.Text = "";
            TextBoxexpreason.Text = "";
            TextBoxempname.Text = "";
            TextBoxayamnt.Text = "";
            TextBoxnote.Text = "";
            TextBoxreqby.Text = "";

        }

        protected void newreqlstpage(object sender, GridViewPageEventArgs e)
        {

            GridViewReqList.PageIndex = e.NewPageIndex;
            loadallreq();
        }

        protected void deltrmxprequest(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxexprecId.Text))
            {
                string reqid = TextBoxexprecId.Text.ToString();

                clsExpense dal3 = new clsExpense();
                dal3.deleteExpLst(reqid);
            }
            else
            {

            }
        }
    }
}