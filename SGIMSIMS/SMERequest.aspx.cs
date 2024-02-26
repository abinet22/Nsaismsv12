using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMERequest : System.Web.UI.Page
    {
        string expyn;
        string byy,today;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["UserName"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {
                Labelsession.Text = Session["UserName"].ToString();
                byy = Session["UserName"].ToString();
                today = DateTime.UtcNow.AddHours(3).ToShortDateString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                loadallemp();
                loadallpaymentlst();
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = false;
                Buttweek.Visible = false;
            }
          
        }

        private void loadallpaymentlst()
        {

            clsExpense Dal = new clsExpense();
            DataSet PaymentType = Dal.FillPaymentList();
            if (PaymentType.Tables[0].Rows.Count != 0)
            {

                DropDownListpaymentlst.DataTextField = "PaymentType";
                DropDownListpaymentlst.DataValueField = "PaymentType";
                DropDownListpaymentlst.DataSource = PaymentType.Tables[0];
                DropDownListpaymentlst.DataBind();
                DropDownListpaymentlst.Items.Insert(0, "-- የወጪ አይነት ምረጥ--");
                DropDownListpaymentlst.Items[0].Value = "0";


            }
            else
            {
               
            }
        }

        private void loadallemp()
        {
            clsEmployee Dal = new clsEmployee();
            DataSet Empname = Dal.FillEmpNameTeam();
            if (Empname.Tables[0].Rows.Count != 0)
            {
               
                DropDownListemplst.DataTextField = "EmpName";
                DropDownListemplst.DataValueField = "EmpName";
                DropDownListemplst.DataSource = Empname.Tables[0];
                DropDownListemplst.DataBind();
                DropDownListemplst.Items.Insert(0, "-- የሰራተኛ ስም ምረጥ--");
                DropDownListemplst.Items[0].Value = "0";

             
            }
            else
            {
                // Labelrecorder.Text = " ሁሉም ሰራተኞች በስራ ላይ ናቸው። ስራ ሲረከቡ እንደገና ይሞክሩ።";
            }
        }


        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }
        protected void sendexprequest(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxexprecId.Text) || string.IsNullOrWhiteSpace(TextBoxayamnt.Text))
            {

            }
            else if(DropDownexpreason.SelectedItem.ToString()== "Employee Salary" && !string.IsNullOrWhiteSpace(TextBoxexprecId.Text))
            {
                if(DropDownListemplst.SelectedValue!="0")
                {
                    string exreqid = TextBoxexprecId.Text;
                    string reason = "Employee Salary";
                    string payto = DropDownListemplst.SelectedItem.ToString();
                    string note = TextBoxnote.Text;
                    decimal amount= Convert.ToDecimal(TextBoxayamnt.Text);
                    string expy = "YES";
                    clsExpense dal = new clsExpense();
                    dal.addnewexpreq(exreqid, reason, payto, amount, byy ,today,note, expy );
                    clearaftersend();
                }
                else
                {

                }
            

            }
            else if(DropDownexpreason.SelectedItem.ToString() == "Other" && !string.IsNullOrWhiteSpace(TextBoxexprecId.Text))
            {
                if (DropDownListpaymentlst.SelectedValue != "0")
                {
                    string payname = DropDownListpaymentlst.SelectedItem.ToString();
                    clsExpense dal = new clsExpense();
                    DataSet ds = dal.loadpaymenisyn(payname);

                    if (ds.Tables[0].Rows.Count != 0)
                    {

                        expyn = ds.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {

                    }

                    string exreqid = TextBoxexprecId.Text;

                    string exnot = TextBoxnote.Text;
                    string reason = "Other";
                    decimal examt = Convert.ToDecimal(TextBoxayamnt.Text);
                    string paytooth = DropDownListpaymentlst.SelectedItem.ToString();


                    clsExpense dal2 = new clsExpense();
                    dal.addnewexpreq(exreqid, reason, paytooth, examt, byy, today, exnot, expyn);
                    clearaftersend();
                }
                
            }
            else if (DropDownexpreason.SelectedItem.ToString() == "AdvancePayment" && !string.IsNullOrWhiteSpace(TextBoxexprecId.Text))
            {
                if (DropDownListemplst.SelectedValue != "0")
                {
                    string exreqid = TextBoxexprecId.Text;

                    string exnot = TextBoxnote.Text;
                    string reason = "AdvancePayment";
                    decimal examt = Convert.ToDecimal(TextBoxayamnt.Text);
                    string paytooth = DropDownListemplst.SelectedItem.ToString();
                    string expy = "YES";
                    clsExpense dal = new clsExpense();
                    dal.addnewexpreq(exreqid, reason, paytooth, examt, byy, today, exnot, expy);
                    clearaftersend();
                }
                else
                {

                }
                
            }
         
            else
            {

            }

        }
        protected void clearafter()
        {
            empslaexp.Style["visibility"] = "hidden";
            empslaexp.Style["display"] = "none";
            DropDownListemplst.SelectedValue = "0";
            TextBoxexprecId.Text = "";
            TextBoxlastaydt.Text = "";
            TextBoxnote.Text = "";
            TextBoxsaltype.Text = "";
            TextBoxnxtsalarydt.Text = "";
            TextBoxayamnt.Text = "";
            TextBoxadvanceay.Text = "";
            DropDownListpaymentlst.SelectedValue = "0";
        }

       protected void clearaftersend()
        {
            empslaexp.Style["visibility"] = "hidden";
            empslaexp.Style["display"] = "none";
            DropDownListemplst.SelectedValue = "0";
            TextBoxexprecId.Text = "";
            TextBoxlastaydt.Text = "";
            TextBoxnote.Text = "";
            TextBoxsaltype.Text = "";
            TextBoxnxtsalarydt.Text = "";
            TextBoxayamnt.Text = "";
            TextBoxadvanceay.Text = "";
            DropDownListpaymentlst.SelectedValue = "0";
            DropDownexpreason.SelectedValue = "0";
        }

        protected void generateexrectid(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 6);

            TextBoxexprecId.Text = "EXP" + '-' + guid;
        }

        protected void clearAdvance(object sender, EventArgs e)
        {
            string empname = DropDownListemplst.SelectedItem.ToString();
            decimal amt = 0;
            clsExpense dal3 = new clsExpense();
           dal3.advancepay(empname,amt);
           

        }

        protected void expensereaselchg(object sender, EventArgs e)
        {
            if(DropDownexpreason.SelectedItem.ToString()== "Employee Salary")
            {
                DropDownListpaymentlst.Visible = false;
                empslaexp.Style["visibility"] = "visible";
                empslaexp.Style["display"] = "block";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = false;
                Buttweek.Visible = false;
            }
            
            else if (DropDownexpreason.SelectedItem.ToString() == "Other")
            {
                DropDownListpaymentlst.Visible = true;
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = false;
                Buttweek.Visible = false;

            }
            else if (DropDownexpreason.SelectedItem.ToString() == "AdvancePayment")
            {
                DropDownListpaymentlst.Visible = false;
                empslaexp.Style["visibility"] = "visible";
                empslaexp.Style["display"] = "block";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = false;
                Buttweek.Visible = false;

            }
            else if (DropDownexpreason.SelectedItem.ToString() == "All Daily Salary" )
            {
                DropDownListpaymentlst.Visible = true;
                Buttdaily.Visible = true;
                Buttmonthly.Visible = false;
                Buttweek.Visible = false;
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                clsEmployee dal = new clsEmployee();
                DataSet ds = dal.loaddaysaldata();

                if (ds.Tables[0].Rows.Count != 0)
                {

                    TextBoxayamnt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {

                }
            }
            else if (DropDownexpreason.SelectedItem.ToString() == "All Weekly Salary" )
            {
                DropDownListpaymentlst.Visible = true;
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = false;
                Buttweek.Visible = true;
                clsEmployee dal = new clsEmployee();
                DataSet ds = dal.loadweeksaldata();

                if (ds.Tables[0].Rows.Count != 0)
                {

                    TextBoxayamnt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {

                }


            }
            else if (DropDownexpreason.SelectedItem.ToString() == "All Monthly Salary" )
            {
                DropDownListpaymentlst.Visible = true;
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
                Buttdaily.Visible = false;
                Buttmonthly.Visible = true;
                Buttweek.Visible = false;
                clsEmployee dal = new clsEmployee();
                DataSet ds = dal.loadmonthsaldata();

                if (ds.Tables[0].Rows.Count != 0)
                {

                    TextBoxayamnt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {

                }

            }
            else
            {
                DropDownListpaymentlst.Visible = false;
                empslaexp.Style["visibility"] = "hidden";
                empslaexp.Style["display"] = "none";
               


            }
        }

        protected void Isynexpense(object sender, EventArgs e)
        {
            if(DropDownListpaymentlst.SelectedValue!="0")
            {
                string payname = DropDownListpaymentlst.SelectedItem.ToString();
                clsExpense dal = new clsExpense();
                DataSet ds = dal.loadpaymenisyn(payname);

                if (ds.Tables[0].Rows.Count != 0)
                {

                  expyn =   ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {

                }
            }
        }

        protected void senddaysalrec(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxexprecId.Text) || string.IsNullOrWhiteSpace(TextBoxayamnt.Text))
            {

            }
            else
            {
                string exreqid = TextBoxexprecId.Text;
                string reason = "Employee Daily Salary";
                string payto = "All  Daily Salary Employee";
                string note = TextBoxnote.Text;
                decimal amount = Convert.ToDecimal(TextBoxayamnt.Text);
                string expy = "YES";
                clsExpense dal = new clsExpense();
                dal.addnewexpreq(exreqid, reason, payto, amount, byy, today, note, expy);
                clsEmployee ObjDal = new clsEmployee();
                try
                {
                    string salaryday = DateTime.UtcNow.AddHours(3).ToShortDateString();
                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "DailySalaryPayrol" + salaryday;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    dt2 = ObjDal.loaddaypayrol();
                    int a = dt2.Rows.Count;
                    int RowsPerPage = Convert.ToInt32(a);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                        GridView gridView = new GridView();
                        gridView.AutoGenerateColumns = true;
                        gridView.ShowHeader = (i == 0);
                        // DataTable dtn = new DataTable();
                        gridView.DataSource = dt2;

                        gridView.DataBind();
                        gridView.RenderControl(htmlWriter);
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                        Response.ContentType = "application/ms-excel";
                        Response.Charset = "";
                        PageNumber = PageNumber + RowsPerPage;
                        //
                        i = PageNumber;
                    }
                    htmlWriter.Close();
                    Response.Write(writer.ToString());
                    Response.End();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                clearaftersend();
            }
            

        }

        protected void sendweeksalrec(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxexprecId.Text) || string.IsNullOrWhiteSpace(TextBoxayamnt.Text))
            {

            }
            else
            {
                string exreqid = TextBoxexprecId.Text;
                string reason = "Employee Weekly Salary";
                string payto = "All  Weekly Salary Employee";
                string note = TextBoxnote.Text;
                decimal amount = Convert.ToDecimal(TextBoxayamnt.Text);
                string expy = "YES";
                clsExpense dal = new clsExpense();
                dal.addnewexpreq(exreqid, reason, payto, amount, byy, today, note, expy);
                clsEmployee ObjDal = new clsEmployee();
                try
                {
                    string salaryday = DateTime.UtcNow.AddHours(3).ToShortDateString();
                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "WeeklySalaryPayrol" + salaryday;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    dt2 = ObjDal.loadweekpayrol();
                    int a = dt2.Rows.Count;
                    int RowsPerPage = Convert.ToInt32(a);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                        GridView gridView = new GridView();
                        gridView.AutoGenerateColumns = true;
                        gridView.ShowHeader = (i == 0);
                        // DataTable dtn = new DataTable();
                        gridView.DataSource = dt2;

                        gridView.DataBind();
                        gridView.RenderControl(htmlWriter);
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                        Response.ContentType = "application/ms-excel";
                        Response.Charset = "";
                        PageNumber = PageNumber + RowsPerPage;
                        //
                        i = PageNumber;
                    }
                    htmlWriter.Close();
                    Response.Write(writer.ToString());
                    Response.End();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                clearaftersend();
            }
        }

        protected void sendmonthsalrec(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxexprecId.Text) || string.IsNullOrWhiteSpace(TextBoxayamnt.Text))
            {

            }
            else
            {
                string exreqid = TextBoxexprecId.Text;
                string reason = "Employee Monthly Salary";
                string payto = "All  Monthly Salary Employee";
                string note = TextBoxnote.Text;
                decimal amount = Convert.ToDecimal(TextBoxayamnt.Text);
                string expy = "YES";
                clsExpense dal = new clsExpense();
                dal.addnewexpreq(exreqid, reason, payto, amount, byy, today, note, expy);

                clsEmployee ObjDal = new clsEmployee();
                try
                {
                    string salaryday = DateTime.UtcNow.AddHours(3).ToShortDateString();
                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "MonthlySalaryPayrol" + salaryday ;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    dt2 = ObjDal.loadmonthpayrol();
                    int a = dt2.Rows.Count;
                    int RowsPerPage = Convert.ToInt32(a);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        // dt = ObjDal.ExportAllRMReq(fromdt, todt);
                        GridView gridView = new GridView();
                        gridView.AutoGenerateColumns = true;
                        gridView.ShowHeader = (i == 0);
                        // DataTable dtn = new DataTable();
                        gridView.DataSource = dt2;

                        gridView.DataBind();
                        gridView.RenderControl(htmlWriter);
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                        Response.ContentType = "application/ms-excel";
                        Response.Charset = "";
                        PageNumber = PageNumber + RowsPerPage;
                        //
                        i = PageNumber;
                    }
                    htmlWriter.Close();
                    Response.Write(writer.ToString());
                    Response.End();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                clearaftersend();
            }
        }

        protected void loadempsaldetail(object sender, EventArgs e)
        {
            string empname = DropDownListemplst.SelectedItem.ToString();
            if (DropDownListemplst.SelectedValue!="0")
            {
            
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
                    if (ds2.Tables[0].Rows[0][0].ToString() == " ")
                    {
                        //clsEmployee dal5 = new clsEmployee();
                        //DataSet ds5 = dal5.checkempwrkstrt(empname);
                        //if (ds5.Tables[0].Rows.Count != 0)
                        //{
                        //    DateTime day = Convert.ToDateTime(ds5.Tables[0].Rows[0][0].ToString());
                        //    TextBoxlastaydt.Text = Convert.ToString(day);

                        //    if (TextBoxsaltype.Text == "Daily")
                        //    {
                        //        DateTime end = day.AddDays(1);
                        //        TextBoxnxtsalarydt.Text = Convert.ToString(end);
                        //    }
                        //    else if (TextBoxsaltype.Text == "Weekly ")
                        //    {
                        //        DateTime end = day.AddDays(7);
                        //        TextBoxnxtsalarydt.Text = Convert.ToString(end);
                        //    }
                        //    else if (TextBoxsaltype.Text == "Monthly")
                        //    {
                        //        //  DateTime end = day.AddDays(30);
                        //        TextBoxnxtsalarydt.Text = "fuck";
                        //    }
                        //    else
                        //    {

                        //    }
                        //}
                        //else
                        //{

                        //}
                    }

                    else
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
                }
                else
                {
                    
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
            else
            {

            }
                

              


        }
           
          
    }
 }
