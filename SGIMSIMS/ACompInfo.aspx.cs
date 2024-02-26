using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ACompInfo : System.Web.UI.Page
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

        protected void savecompanyinfo(object sender, EventArgs e)
        {
            clsCompanyInfo cominfo = new clsCompanyInfo();
            CompanyInfo obj = InitalizeObject();
            cominfo.AddCompanyInfo(obj);

        }

        private CompanyInfo InitalizeObject()
        {

            CompanyInfo ACompInfo = new CompanyInfo();
            ACompInfo.BusinessName = TextBoxBussName.Text;
            ACompInfo.TinNo = TextBoxTin.Text;
            ACompInfo.Region = TextBoxRegion.Text;
            ACompInfo.Subcity = TextBoxSubCity.Text;
            ACompInfo.Woreda = TextBoxWoreda.Text;
            ACompInfo.HouseNo = TextBoxHsno.Text;
            ACompInfo.MobNo = TextBoxMobno.Text;
            ACompInfo.TelNo = TextBoxTelno.Text;

            return ACompInfo;
        }

        private void LoadCompanyInfo()
        {
            clsCompanyInfo Dal = new clsCompanyInfo();
            DataSet ACompInfo = Dal.LoadCompanyInfo();
          
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
    }
}