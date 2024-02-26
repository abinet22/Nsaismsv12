using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ADayExpense : System.Web.UI.Page
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
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void Binschart(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxtodt.Text) && !string.IsNullOrWhiteSpace(TextBoxfromdt.Text))
            {
                DateTime todt = Convert.ToDateTime(TextBoxtodt.Text);

                DateTime fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                clsReport Dal = new clsReport();
                DataSet ds = Dal.RevenuebyPaytype(fromdt, todt);
                DataSet ds2 = Dal.RevenuebyShopName(fromdt, todt);
                DataSet ds3 = Dal.RevenuebyProName(fromdt, todt);
                DataSet ds4 = Dal.RevenuebySaleDate(fromdt, todt);


                DataTable ChartData = ds.Tables[0];

                DataTable ChartData2 = ds2.Tables[0];
                DataTable ChartData3 = ds3.Tables[0];
                DataTable ChartData4 = ds4.Tables[0];






                //storing total rows count to loop on each Record  

                string[] XPointMember = new string[ChartData.Rows.Count];

                int[] YPointMember = new int[ChartData.Rows.Count];

                string[] XPointMember2 = new string[ChartData2.Rows.Count];

                int[] YPointMember2 = new int[ChartData2.Rows.Count];
                string[] XPointMember3 = new string[ChartData3.Rows.Count];

                int[] YPointMember3 = new int[ChartData3.Rows.Count];
                string[] XPointMember4 = new string[ChartData4.Rows.Count];

                int[] YPointMember4 = new int[ChartData4.Rows.Count];

                for (int count = 0; count < ChartData3.Rows.Count; count++)
                {
                    XPointMember3[count] = ChartData3.Rows[count][0].ToString();

                    //storing values for Y Axis  

                    YPointMember3[count] = Convert.ToInt32(ChartData3.Rows[count][1]);
                }

                Chart3.Series[0].Points.DataBindXY(XPointMember3, YPointMember3);
                Chart3.Series[0].ChartType = SeriesChartType.Column;
                //  Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart3.Legends[0].Enabled = true;

                for (int count = 0; count < ChartData4.Rows.Count; count++)
                {
                    XPointMember4[count] = ChartData4.Rows[count][0].ToString();

                    //storing values for Y Axis  

                    YPointMember4[count] = Convert.ToInt32(ChartData4.Rows[count][1]);
                }

                Chart4.Series[0].Points.DataBindXY(XPointMember4, YPointMember4);
                Chart4.Series[0].ChartType = SeriesChartType.Line;
                // Chart4.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart4.Legends[0].Enabled = true;



                for (int count = 0; count < ChartData.Rows.Count; count++)

                {


                    //storing Values for X axis  

                    XPointMember[count] = ChartData.Rows[count]["PaymentType"].ToString();

                    //storing values for Y Axis  

                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["SaleRevenue"]);



                }
                for (int count = 0; count < ChartData2.Rows.Count; count++)

                {


                    //storing Values for X axis  

                    XPointMember2[count] = ChartData2.Rows[count]["Soldby"].ToString();

                    //storing values for Y Axis  

                    YPointMember2[count] = Convert.ToInt32(ChartData2.Rows[count]["SaleRevenue"]);



                }

                //binding chart control  

                Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

                Chart2.Series[0].Points.DataBindXY(XPointMember2, YPointMember2);



                //Setting width of line  

                Chart1.Series[0].BorderWidth = 10;

                //setting Chart type   

                Chart1.Series[0].ChartType = SeriesChartType.Pie;

                Chart2.Series[0].BorderWidth = 10;

                //setting Chart type   

                Chart2.Series[0].ChartType = SeriesChartType.Column;




                foreach (Series charts in Chart1.Series)

                {

                    foreach (DataPoint point in charts.Points)

                    {

                        switch (point.AxisLabel)

                        {

                            case "Credit": point.Color = Color.RoyalBlue; break;

                            case "Bank Transfer": point.Color = Color.SaddleBrown; break;

                            case "Cash": point.Color = Color.SpringGreen; break;

                        }

                        point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);



                    }

                }
            }
         
        
        }
    }
}