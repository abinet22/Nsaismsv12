using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AManEmployee : System.Web.UI.Page
    {
        DateTime fromdt, todt;
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
            if (!IsPostBack)
            {
                performance.Style["visibility"] = "hidden";
                performance.Style["display"] = "none";
                Labelheader.Text = "Search Results Will Be Here";
                Loadware();
            }
        }

        private void Loadware()
        {
            string username = Session["UserBy"].ToString();
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNameex(username);
            DropDownListwarehouse.DataTextField = "UserName";
            DropDownListwarehouse.DataValueField = "UserName";


            DropDownListwarehouse.DataSource = warename.Tables[0];
            DropDownListwarehouse.DataBind();
            DropDownListwarehouse.Items.Insert(0, "-- Select--");
            DropDownListwarehouse.Items[0].Value = "0";
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void showmanusr(object sender, EventArgs e)
        {
            showaccttrans.Style["visibility"] = "visible";
            showaccttrans.Style["display"] = "block";
            performance.Style["visibility"] = "hidden";
            performance.Style["display"] = "none";
        }

        protected void showempper(object sender, EventArgs e)
        {
            performance.Style["visibility"] = "visible";
            performance.Style["display"] = "block";
            showaccttrans.Style["visibility"] = "hidden";
            showaccttrans.Style["display"] = "none";
        }

        protected void searchworksnt(object sender, EventArgs e)
        {
            if(DropDownListwarehouse.SelectedValue!= "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "Finordsentby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                Finordsentby();
               
            }
        }

        private void Finordsentby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Results For Finished Product Sent By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.Finordsentby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchordsrt(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "Newordsrtwork";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                Newordsrtwork();
               
            }
            else
            {


            }

        }

        private void Newordsrtwork()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Order Product Work Start By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.Newordsrtwork(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchorder(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "newordrsentby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                newordrsentby();
               
            }
            else
            {

            }
        }

        private void newordrsentby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Results For Order Recieve and Sent By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.newordrsentby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchsold(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" ||  TextBoxfromdt.Text != "" || TextBoxtodt.Text != "" )
            {
                Session["Note"] = "Prosoldby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                Prosoldby();
               
            }
            else
            {


            }
        }

        private void Prosoldby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Product Sold By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.Prosoldby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchrmapt(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "rmacptby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                rmacptby();
               
            }
            else
            {

            }
        }

        private void rmacptby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Row Material Accept By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.rmacptby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchtrmsent(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "rmsentby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                rmsentby();
                
            }
            else
            {

            }
        }

        private void rmsentby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Row Material Sent By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.rmsentby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchorderrec(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "ordrecmanpro";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                ordrecmanpro();
               
            }
            else
            {

            }
        }

        private void ordrecmanpro()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Recived In Inventory By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.ordrecmanpro(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void searchwrkrec(object sender, EventArgs e)
        {
            if (DropDownListwarehouse.SelectedValue != "0" || TextBoxfromdt.Text != "" || TextBoxtodt.Text != "")
            {
                Session["Note"] = "manproacpby";
                GridViewbankacctlst.DataSource = null;
                GridViewbankacctlst.DataBind();
                manproacpby();
               
            }
        }

        private void manproacpby()
        {
            todt = Convert.ToDateTime(TextBoxtodt.Text);

            fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            string username = DropDownListwarehouse.SelectedItem.ToString();
            Labelheader.Text = "Search Finish Work Recieve By" + "/" + username;
            clsReport Dal = new clsReport();
            DataSet pro = Dal.manproacpby(fromdt, todt, username);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewbankacctlst.DataSource = pro.Tables[0];
                GridViewbankacctlst.DataBind();


            }
            else
            {


            }
        }

        protected void newsrchlistpage(object sender, GridViewPageEventArgs e)
        {
            GridViewbankacctlst.PageIndex = e.NewPageIndex;
            LoadSearchGrid();
        }

        private void LoadSearchGrid()
        {
            if(Session["Note"].ToString() == "Finordsentby")
            {
                Finordsentby();
            }
            else if(Session["Note"].ToString() == "Newordsrtwork")
            {
                Newordsrtwork();
            }
            else if (Session["Note"].ToString() == "newordrsentby")
            {
                newordrsentby();
            }
            else if (Session["Note"].ToString() == "Prosoldby")
            {
                Prosoldby();
            }
            else if (Session["Note"].ToString() == "rmacptby")
            {
                rmacptby();
            }
            else if (Session["Note"].ToString() == "rmsentby")
            {
                rmsentby();
            }
            else if (Session["Note"].ToString() == "ordrecmanpro")
            {
                ordrecmanpro();
            }
            else if (Session["Note"].ToString() == "manproacpby")
            {
                manproacpby();
            }
            else
            {

            }
        }

        protected void Binschart(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxtodt.Text) && !string.IsNullOrWhiteSpace(TextBoxfromdt.Text))
            {
                DateTime todt = Convert.ToDateTime(TextBoxtodt.Text);

                DateTime fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                clsReport Dal = new clsReport();
                DataSet ds = Dal.EmployeeQuantity(fromdt, todt);
                DataSet ds2 = Dal.EmployeeProduct(fromdt, todt);
               

                DataTable ChartData = ds.Tables[0];

                DataTable ChartData2 = ds2.Tables[0];
             



                //storing total rows count to loop on each Record  

                string[] XPointMember = new string[ChartData.Rows.Count];

                int[] YPointMember = new int[ChartData.Rows.Count];

                string[] XPointMember2 = new string[ChartData2.Rows.Count];

                int[] YPointMember2 = new int[ChartData2.Rows.Count];
              

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    XPointMember[count] = ChartData.Rows[count][0].ToString();

                    //storing values for Y Axis  

                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count][1]);
                }

                Chart7.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                Chart7.Series[0].ChartType = SeriesChartType.Column;
                //  Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart7.Legends[0].Enabled = true;

                for (int count = 0; count < ChartData2.Rows.Count; count++)
                {
                    XPointMember2[count] = ChartData2.Rows[count][0].ToString();

                    //storing values for Y Axis  

                    YPointMember2[count] = Convert.ToInt32(ChartData2.Rows[count][1]);
                }

                Chart8.Series[0].Points.DataBindXY(XPointMember2, YPointMember2);
                Chart8.Series[0].ChartType = SeriesChartType.Column;
                // Chart4.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart8.Legends[0].Enabled = true;



            }

        }
    }
}