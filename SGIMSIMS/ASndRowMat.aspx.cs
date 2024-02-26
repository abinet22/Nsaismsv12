using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class ASndRowMat : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Admin")
            {

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                username = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
           
           
            Labelavalqty.Visible = false;
            LoadAllRMReq();
            if(!IsPostBack)
            {
                LoadWareHouse();
            }

            
            
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        private void LoadWareHouse()
        {
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNamewITHAD();
            DropDownrmwarehouse.DataTextField = "AssignShop";
            DropDownrmwarehouse.DataValueField = "AssignShop";


            DropDownrmwarehouse.DataSource = warename.Tables[0];
            DropDownrmwarehouse.DataBind();
            DropDownrmwarehouse.Items.Insert(0, "-- Select Shop Name--");
            DropDownrmwarehouse.Items[0].Value = "0";
        }
        private void LoadAllRMReq()
        {
            clsRMRequest Dal = new clsRMRequest();
            
            DataSet rmrec = Dal.LoadAllRMReq();

            if (rmrec.Tables[0].Rows.Count != 0)
            {

                GridViewReqList.DataSource = rmrec.Tables[0];
                GridViewReqList.DataBind();
                Labeltotalreq.Text = (GridViewReqList.DataSource as DataTable).Rows.Count.ToString();

            }
            else
            {

                Labeltotalreq.Text = "0";


            }
        }

        protected void approvermrequest(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxreqid.Text) || string.IsNullOrWhiteSpace(TextBoxrecby.Text) || string.IsNullOrWhiteSpace(TextBoxbrand.Text) || string.IsNullOrWhiteSpace(TextBoxgage.Text) || string.IsNullOrWhiteSpace(TextBoxrmwidth.Text) || string.IsNullOrWhiteSpace(TextBoxrmlength.Text) || DropDownrmwarehouse.SelectedValue=="0" )
            {
                //error
            }
            else
            {
                clsRMRequest Dal = new clsRMRequest();
                string reqid = TextBoxreqid.Text;
                string recby = TextBoxrecby.Text;
                string brand = TextBoxbrand.Text;
                string gage = TextBoxgage.Text;
                decimal width = Convert.ToDecimal(TextBoxrmwidth.Text);
                decimal length = Convert.ToDecimal(TextBoxrmlength.Text);
                string from = DropDownrmwarehouse.SelectedItem.ToString();
                // show available rowmaterial on each warehouse

                Dal.ApproveReqest(reqid, recby, brand, gage, width, length, from);
                GridViewReqList.DataSource = null;
                GridViewReqList.DataBind();
                
                LoadAllRMReq();
                ClearAll();
            }
           
        }

        private void ClearAll()
        {
            TextBoxreqid.Text="";
            TextBoxrecby.Text = "";
            TextBoxbrand.Text = "";
            TextBoxgage.Text = "";
            TextBoxrmwidth.Text = "";
            TextBoxrmlength.Text = "";
            TextBoxrecdate.Text = "";
        }

        protected void viewrequestlst(object sender, EventArgs e)
        {
            GridViewRow row = GridViewReqList.SelectedRow;
            TextBoxreqid.Text = row.Cells[1].Text;
            TextBoxrecby.Text = row.Cells[2].Text;
                     
            TextBoxbrand.Text = row.Cells[3].Text;
            TextBoxgage.Text = row.Cells[4].Text;
            TextBoxrmwidth.Text = row.Cells[5].Text;
            TextBoxrmlength.Text = row.Cells[6].Text;
            TextBoxrecdate.Text = row.Cells[7].Text;

        }

        protected void showavilableqty(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxreqid.Text) || string.IsNullOrWhiteSpace(TextBoxrecby.Text) || string.IsNullOrWhiteSpace(TextBoxbrand.Text) || string.IsNullOrWhiteSpace(TextBoxgage.Text) || string.IsNullOrWhiteSpace(TextBoxrmwidth.Text) || string.IsNullOrWhiteSpace(TextBoxrmlength.Text) )
            {
                //error
            }
            else
            {
                Labelavalqty.Visible = false;
                clsRowMaterial rm = new clsRowMaterial();
                string recfrom = DropDownrmwarehouse.SelectedItem.ToString();
                string brand = TextBoxbrand.Text;
                string gage = TextBoxgage.Text;
                decimal width = Convert.ToDecimal(TextBoxrmwidth.Text);

                DataSet ds = rm.ShowAvalQty(recfrom, brand, gage);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Labelavalqty.Visible = true;
                    string qty = ds.Tables[0].Rows[0]["RMaterialQty"].ToString();


                    Labelavalqty.Text = qty + " " + "M \xB2";
                }
                else
                {
                    Labelavalqty.Visible = true;
                    Labelavalqty.Text = "0" + "M \xB2";
                }
            }
           
        }

        protected void loadnxtsnndrmpage(object sender, GridViewPageEventArgs e)
        {
            GridViewReqList.PageIndex = e.NewPageIndex;
            LoadAllRMReq();
        }

        protected void dltrmrequest(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxreqid.Text))
            {
                string id = TextBoxreqid.Text.ToString();
                clsRMRequest Dal = new clsRMRequest();
                Dal.deleterequestrm(id);
                GridViewReqList.DataSource = null;
                GridViewReqList.DataBind();

                LoadAllRMReq();
            }
        }
    }
}