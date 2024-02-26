using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMEmpRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
             
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(!IsPostBack)
            {
                LoadGridEmpList();
                Loademplist();
                loadempteams();
            }
           
            TextBoxEmpworkstrtdt.Text = DateTime.Now.ToShortDateString();
        }

        private void loadempteams()
        {
           
            clsEmployee Dal = new clsEmployee();
            DataSet Empname = Dal.FillEmpTeam();
            DropDownListteamname.DataTextField = "TeamName";
            DropDownListteamname.DataValueField = "TeamName";
            DropDownListteamname.DataSource = Empname.Tables[0];
            DropDownListteamname.DataBind();
            DropDownListteamname.Items.Insert(0, "-- የቡድን ስም ምረጥ--");
            DropDownListteamname.Items[0].Value = "0";
        }

        private void Loademplist()
        {
            clsEmployee Dal = new clsEmployee();
            DataSet Empname = Dal.FillEmpname();
            if (Empname.Tables[0].Rows.Count != 0)
            {

                ListBoxteam.DataTextField = "EmpName";
                ListBoxteam.DataValueField = "EmpName";
                ListBoxteam.DataSource = Empname.Tables[0];
                ListBoxteam.DataBind();
                ListBoxteam.Items.Insert(0, "-- የሰራተኛ ስም ምረጥ--");
                ListBoxteam.Items[0].Value = "0";
            }
            else
            {
               // Labelrecorder.Text = " ሁሉም ሰራተኞች በስራ ላይ ናቸው። ስራ ሲረከቡ እንደገና ይሞክሩ።";
            }
        }

        protected void generateEmpid(object sender, EventArgs e)
        {
            
            var date = DateTime.Now.ToShortDateString();

            var guid = Guid.NewGuid().ToString().Substring(0, 5);
            string uniqueid = date.ToString() + '-' + guid;

            TextBoxEmpId.Text = "EMP" + '-' + uniqueid;

        }

        protected void AddnwEmp(object sender, EventArgs e)
        {
            if (DropDownListemtype.SelectedValue == "0" || DropDownListsalarytype.SelectedValue == "0")
            {
                //error
            }
            if (string.IsNullOrWhiteSpace(TextBoxEmpAddress.Text)  || string.IsNullOrWhiteSpace(TextBoxEmpworkstrtdt.Text) || string.IsNullOrWhiteSpace(TextBoxEmpId.Text) || string.IsNullOrWhiteSpace(TextBoxEmpname.Text) || string.IsNullOrWhiteSpace(TextBoxEmpPhone.Text) || string.IsNullOrWhiteSpace(TextBoxEmpPosition.Text) || string.IsNullOrWhiteSpace(TextBoxEmpSalary.Text))
            {
               //error
            }
            string empname = TextBoxEmpname.Text;
            clsEmployee Dal = new clsEmployee();
            DataSet emp = Dal.CheckunqiueEmpName(empname);
            if(emp.Tables[0].Rows.Count !=0)
            {
                //error
                TextBoxEmpname.Focus();
            }
            else
            {
                clsEmployee Dal2 = new clsEmployee();
                Employee obj = InitalizeObject();
                Dal2.AddNewEmployee(obj);
                string wrksdtd = DateTime.Now.ToShortDateString();
                DateTime wrksdt = Convert.ToDateTime(wrksdtd);
                clsExpense dal = new clsExpense();
                dal.addnewwrkstrt("NewEmploye","Employee Salary", empname, 0, "NewEmployee", wrksdt, "Paid");
                LoadGridEmpList();
                clearAfterSave();
            }
           

            
        }

        private void clearAfterSave()
        {
            TextBoxEmpId.Text = "";
            TextBoxEmpname.Text = "";
            TextBoxEmpPhone.Text = "";
            TextBoxEmpPosition.Text = "";
            TextBoxEmpSalary.Text = "";
            
            DropDownListemtype.SelectedValue = "0";
            TextBoxEmpAddress.Text = "";
         
            DropDownListsalarytype.SelectedValue = "0";
        }

        private void LoadGridEmpList()
        {
            clsEmployee Dal = new clsEmployee();
            DataSet Order = Dal.LoadEmp();

            if (Order.Tables[0].Rows.Count != 0)
            {
               
                GridViewEmpList.DataSource = Order.Tables[0];
                GridViewEmpList.DataBind();
                string totalemp = (GridViewEmpList.DataSource as DataTable).Rows.Count.ToString();

                LabeltotalnoEmp.Text = totalemp;
            }
        }

        private Employee InitalizeObject()
        {
            Employee Emp = new Employee();
                   
            Emp.EmpId = TextBoxEmpId.Text;

            Emp.EmpName = TextBoxEmpname.Text;
            Emp.EmpPhone = TextBoxEmpPhone.Text;

            Emp.EmpAddress = TextBoxEmpAddress.Text;
            Emp.EmpType = DropDownListemtype.SelectedItem.ToString();

            Emp.EmpPosition  = TextBoxEmpPosition.Text;

            Emp.EmpSalaryType = DropDownListsalarytype.SelectedItem.ToString();
            Emp.EmpSalary = Convert.ToDecimal(TextBoxEmpSalary.Text);
            Emp.EmpWrkStrdt =Convert.ToDateTime( DateTime.Now.ToShortDateString());
            Emp.EmpStatus = "Active";
            Emp.Busy = "False";
            return Emp;
        }

        protected void UpdateEmp(object sender, EventArgs e)
        {
            if(DropDownListemtype.SelectedValue == "0" || DropDownListsalarytype.SelectedValue == "0")
            {
                //error
            }
            else
            {
                ButtongenEmpid.Enabled = true;
                clsEmployee Dal = new clsEmployee();
                Employee obj = InitalizeObject();
                Dal.UpdateEmp(obj);

                LoadGridEmpList();

                clearAfterSave();
                EnableAll();
            }

            
        }

        private void EnableAll()
        {
            TextBoxEmpname.Text = "";
            TextBoxEmpPhone.Text = "";
            TextBoxEmpPosition.Text = "";
            TextBoxEmpSalary.Text = "";
            DropDownListsalarytype.SelectedValue = "0";
            TextBoxEmpAddress.Text = "";
            TextBoxEmpworkstrtdt.Text = "";
            DropDownListemtype.SelectedValue = "0";

            TextBoxEmpname.Enabled = true;
            TextBoxEmpPhone.Enabled = true;
            TextBoxEmpPosition.Enabled = true;
            TextBoxEmpSalary.Enabled = true;
           
            TextBoxEmpAddress.Enabled = true;
            TextBoxEmpworkstrtdt.Enabled = true;
           
        }

        protected void DeleteEmp(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxEmpId.Text))
            {
                //error
            }
            else
            {
                string EmpId = TextBoxEmpId.Text;
                clsEmployee Dal = new clsEmployee();
                Employee obj = InitalizeObject();
                Dal.DeleteEmp(EmpId);

                LoadGridEmpList();

                clearAfterSave();
                EnableAll();
            }
           
        }

        protected void LoadNxtEmpList(object sender, GridViewPageEventArgs e)
        {
            GridViewEmpList.PageIndex = e.NewPageIndex;
            LoadGridEmpList();
        }

        protected void SelectEMpLoadTxtbox(object sender, EventArgs e)
        {
            
            TextBoxEmpname.Enabled = false;
            TextBoxEmpPhone.Enabled = false;

            TextBoxEmpAddress.Enabled = false;
            ButtongenEmpid.Enabled = false;
            //  TextBoxEmpworkstrtdt.Enabled = false;

            GridViewRow row = GridViewEmpList.SelectedRow;
            
            clsOrder Dal = new clsOrder();
            TextBoxEmpId.Text = row.Cells[1].Text;
            TextBoxEmpname.Text = row.Cells[2].Text;
            TextBoxEmpPhone.Text = row.Cells[3].Text;
            if (DropDownListemtype.Items.FindByValue(row.Cells[4].Text.ToString().Trim()) != null)
            {
                DropDownListemtype.SelectedValue = row.Cells[4].Text.ToString().Trim();
            }
           // DropDownListemtype.SelectedItem.Value = row.Cells[4].Text;
            TextBoxEmpPosition.Text = row.Cells[5].Text;
            if (DropDownListsalarytype.Items.FindByValue(row.Cells[6].Text.ToString().Trim()) != null)
            {
                DropDownListsalarytype.SelectedValue = row.Cells[6].Text.ToString().Trim();
            }
           // DropDownListsalarytype.SelectedItem.Value = row.Cells[6].Text;
            TextBoxEmpSalary.Text = row.Cells[7].Text;
            TextBoxEmpworkstrtdt.Text= row.Cells[8].Text; 
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"]= null;
            Response.Redirect("login.aspx");
        }

        protected void showempregistry(object sender, EventArgs e)
        {
            empteam.Style["visibility"] = "hidden";
            empteam.Style["display"] = "none";
            empreg.Style["visibility"] = "visible";
            empreg.Style["display"] = "block";
        }

        protected void showtempteamcreatn(object sender, EventArgs e)
        {
            empreg.Style["visibility"] = "hidden";
            empreg.Style["display"] = "none";
            empteam.Style["visibility"] = "visible";
            empteam.Style["display"] = "block";
        }

        protected void Addnewteam(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxteamid.Text) || DropDownListteamname.SelectedValue=="0" || ListBoxteam.SelectedValue == "0")
            {
                string teamhead = TextBoxteamhead.Text;
                string teamid = TextBoxteamid.Text;
                string teamname = TextBoxteamname.Text;

                foreach (ListItem listItem in ListBoxteam.Items)
                {
                    if (listItem.Selected == true)
                    {
                        string empllst = ListBoxteam.SelectedItem.ToString();
                        clsEmployee Dal = new clsEmployee();
                        Dal.AddEmpTeam(teamhead, empllst, teamname);
                        
                    }
                }
                clearteampage();
            }
            else
            {
                if(DropDownListteamname.SelectedValue=="0" || ListBoxteam.SelectedValue=="0" )
                {
                    //error
                }
                string teamhead = TextBoxteamhead.Text;
              
                string teamname = DropDownListteamname.SelectedItem.ToString();
                
                foreach (ListItem listItem in ListBoxteam.Items)
                {
                    if (listItem.Selected ==true)
                    {
                        string empllst = listItem.Text;
                        clsEmployee Dal = new clsEmployee();
                        Dal.AddEmpTeam(teamhead, empllst, teamname);
                       
                    }
                }
                clearteampage();
            }
               
        }

        private void clearteampage()
        {
            TextBoxteamhead.Text = "";
            TextBoxteamid.Text = "";
            TextBoxteamname.Text = "";
            ListBoxteam.SelectedValue = "0";
            DropDownListteamname.SelectedValue = "0";
        }

        protected void Updateteammemeber(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxteamhead.Text) || DropDownListteamname.SelectedValue == "0" || ListBoxteam.SelectedValue == "0")
            {
               //error
            }
            else
            {
              
                string teamhead = TextBoxteamhead.Text;

                string teamname = DropDownListteamname.SelectedItem.ToString();

                foreach (ListItem listItem in ListBoxteam.Items)
                {
                    if (listItem.Selected == true)
                    {
                        string empllst = ListBoxteam.SelectedItem.ToString();
                        clsEmployee Dal = new clsEmployee();
                        Dal.UpdateEmpTeam(teamhead, empllst, teamname);
                        loadempteams();
                    }
                }
                clearteampage();
            }

        }

      

        protected void generateteamid(object sender, EventArgs e)
        {
           
            var guid = Guid.NewGuid().ToString().Substring(0, 3);
           
            TextBoxteamid.Text = "TEAM" + '-' + guid;
        }

        protected void loadteamleader(object sender, EventArgs e)
        {
            if(DropDownListteamname.SelectedValue=="0")
            {
                TextBoxteamhead.Text = "";
            }
            else
            {
                string teamname = DropDownListteamname.SelectedItem.ToString();
                clsEmployee Dal = new clsEmployee();
               DataSet ds =  Dal.AddEmpTeamHead(teamname);
                if(ds.Tables[0].Rows.Count !=0)
                {
                    TextBoxteamhead.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {

                }


            }
        }
    }
}