using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AAddSer : System.Web.UI.Page
    {
      public string type;
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

            LoadServiceGrid();


            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
     
        private void LoadProductName(string type)
        { 

           
            clsProduct Dal = new clsProduct();
            DataSet proname = Dal.FillProname(type);
            DropDownListproname.DataTextField = "ProductName";
            DropDownListproname.DataValueField = "ProductName";
            DropDownListproname.DataSource = proname.Tables[0];
            DropDownListproname.DataBind();
            DropDownListproname.Items.Insert(0, "-- Select--");
            DropDownListproname.Items[0].Value = "0";
        }
        protected void Addservice(object sender, EventArgs e)
        {
            if(TextBoxserid.Text=="" ||  DropDownListprotype.SelectedValue== "0" || DropDownListproname.SelectedValue== "0" || DropDownListsertyp.SelectedValue== "0" || TextBoxserprce.Text=="")
            {
                Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                TextBoxserid.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            string proName = DropDownListproname.SelectedItem.ToString();
            string sertype = DropDownListsertyp.SelectedItem.ToString();
            string protype = DropDownListprotype.SelectedItem.ToString();
            clsService Da2 = new clsService();
            DataSet da2 = Da2.checkservicename(proName, sertype, protype);
            if (da2.Tables[0].Rows.Count == 0)
            {
                clsService Dal = new clsService();
                Service obj = InitalizeObject();
                Dal.AddNewService(obj);

                LoadServiceGrid();

                clearAfterSave();
            }
            else
            {
                Labelalertonbtntopr.Text = "Service Already registered";
               // TextBoxserid.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
           
        }

        private Service InitalizeObject()
        {
            Service ser = new Service();
            ser.ServiceId = TextBoxserid.Text;
            ser.ProductType = DropDownListprotype.SelectedItem.ToString();
            ser.ProductName = DropDownListproname.SelectedItem.ToString();
            ser.ServiceType = DropDownListsertyp.SelectedItem.ToString();
            ser.ServiceUnitprice =Convert.ToDecimal(TextBoxserprce.Text);
            ser.ServiceName = TextBoxsername.Text;
            return ser;
        }

        private void LoadServiceGrid()
        {
            clsService Dal = new clsService();
            DataSet ser = Dal.LoadService();

            if (ser.Tables[0].Rows.Count != 0)
            {
                GridViewservicelst.DataSource = ser.Tables[0];
                GridViewservicelst.DataBind();
            
            }
        }

        private void clearAfterSave()
        {
            TextBoxserid.Text = "";
            DropDownListprotype.SelectedValue = "0";
            DropDownListproname.Items.Clear();
            DropDownListsertyp.SelectedValue = "0";
            TextBoxserprce.Text = "";
            TextBoxsername.Text = "";
        }

        protected void Adtservice(object sender, EventArgs e)
        {
            if (TextBoxserid.Text == "" || DropDownListprotype.SelectedValue == "0" || DropDownListproname.SelectedValue == "0" || DropDownListsertyp.SelectedValue == "0" || TextBoxserprce.Text == "")
            {
                Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                TextBoxserid.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

            else
            {
                string serid = TextBoxserid.Text;
                decimal serprice = Convert.ToDecimal(TextBoxserprce.Text);
                string proName = DropDownListproname.SelectedItem.ToString();
                string sertype = DropDownListsertyp.SelectedItem.ToString();
                string protype = DropDownListprotype.SelectedItem.ToString();
                clsService Da2 = new clsService();
                DataSet da2 = Da2.checkservicename(proName, sertype, protype);
                if (da2.Tables[0].Rows.Count != 0)
                {
                    clsService Dal = new clsService();
                 
                    Dal.UpdateService(serid, sertype, serprice);

                    LoadServiceGrid();

                    clearAfterSave();
                }
                else
                {
                    Labelalertonbtntopr.Text = " Register Service First";
                    // TextBoxserid.CssClass = "form-control-sm form-control is -invalid";
                    divMessage.Style["visibility"] = "visible";
                    divMessage.Style["display"] = "block";
                }
            
            }
        }

        protected void DltService(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxserid.Text) )
            {

            }
            else
            {
                string proname = TextBoxsername.Text;
                string proid = TextBoxserid.Text;
                string proype = DropDownListprotype.SelectedItem.ToString();
                clsService Da2 = new clsService();
                Da2.DeleteService( proid);
                clearAfterSave();
            }
        }

        protected void newserlistpage(object sender, GridViewPageEventArgs e)
        {

            GridViewservicelst.PageIndex = e.NewPageIndex;
            LoadServiceGrid();
        }

        protected void selectandeditser(object sender, EventArgs e)
        {
            GridViewRow row = GridViewservicelst.SelectedRow;
            TextBoxserid.Text = row.Cells[1].Text;
            TextBoxsername.Text = row.Cells[5].Text;
           
            TextBoxserprce.Text = row.Cells[6].Text;
            DropDownListprotype.Visible = false;
            DropDownListproname.Visible = false;
           
        }

        protected void loadproducname(object sender, EventArgs e)
        {
            type = DropDownListprotype.SelectedValue.ToString();
            DropDownListproname.Items.Clear();

            LoadProductName(type);
        }

        protected void GeneserID(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 4);


            TextBoxserid.Text = "Ser" + '-' + guid;
          
        }

        protected void loadservicename(object sender, EventArgs e)
        {
            TextBoxsername.Text = DropDownListproname.SelectedItem.ToString();
        }
    }
}