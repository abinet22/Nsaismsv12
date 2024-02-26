using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AAddRowMat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Admin")
            {

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
              //  string username = Labelsession.Text;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                LoadWareHouse();
                loadallbrand();
                Loadsaleshopname();
                udtrmatpr.Style["visibility"] = "hidden";
                udtrmatpr.Style["display"] = "none";
                // loadallgages();
            }
           
            LoadRowMattoGrid();
        }

        private void Loadsaleshopname()
        {
            //string userroll = "Sales Manager";
            clsRowMaterial Dal = new clsRowMaterial();

            DataSet probrand = Dal.FillUserNamewITHAD();
            DropDownListshopname.DataTextField = "AssignShop";
            DropDownListshopname.DataValueField = "AssignShop";
            DropDownListshopname.DataSource = probrand.Tables[0];
            DropDownListshopname.DataBind();
            DropDownListshopname.Items.Insert(0, "-- Select SaleShop/Inventory Name--");
            DropDownListshopname.Items[0].Value = "0";
        }

        private void loadallbrand()
        {

           
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrand.DataTextField = "ProductBrand";
            DropDownListbrand.DataValueField = "ProductBrand";
            DropDownListbrand.DataSource = probrand.Tables[0];
            DropDownListbrand.DataBind();
            DropDownListbrand.Items.Insert(0, "-- Select Brand Name--");
            DropDownListbrand.Items[0].Value = "0";
        }

        private void loadallgages(string brand)
        {

            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListgage.DataTextField = "ProductGage";
            DropDownListgage.DataValueField = "ProductGage";
            DropDownListgage.DataSource = progage.Tables[0];
            DropDownListgage.DataBind();
            DropDownListgage.Items.Insert(0, "-- Select Shop Name--");
            DropDownListgage.Items[0].Value = "0";
        }

        private void LoadWareHouse()
        {
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNamewITHAD();
            DropDownListwarelist.DataTextField = "AssignShop";
            DropDownListwarelist.DataValueField = "AssignShop";


            DropDownListwarelist.DataSource = warename.Tables[0];
            DropDownListwarelist.DataBind();
            DropDownListwarelist.Items.Insert(0, "-- Select Shop Name--");
            DropDownListwarelist.Items[0].Value = "0";
        }

        protected void newrowmatlistpage(object sender, GridViewPageEventArgs e)
        {
            GridViewrmlst.PageIndex = e.NewPageIndex;
            LoadRowMattoGrid();
        }

        protected void selectandeditrowmater(object sender, EventArgs e)
        {
            GridViewRow row = GridViewrmlst.SelectedRow;
       
            TextBoxrmid.Text = row.Cells[1].Text;
            TextBoxrmname.Text = row.Cells[2].Text;
            DropDownListbrand.SelectedItem.Value= row.Cells[3].Text;
            DropDownListgage.SelectedItem.Value = row.Cells[4].Text;
           
            TextBoxrmqty.Text = row.Cells[5].Text;
            TextBoxrmwidth.Text = row.Cells[6].Text;
            TextBoxpricepmlen.Text = row.Cells[7].Text;
        }

        protected void udtrmaterial(object sender, EventArgs e)
        {
            if (DropDownListbrands.SelectedValue == "0" || DropDownListgages.SelectedValue == "0" || DropDownListshopname.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxudtprice.Text))
            {

            }
            else
            {
                string brand = DropDownListbrands.SelectedItem.ToString();
                string gage = DropDownListgages.SelectedItem.ToString();
                string shopname = DropDownListshopname.SelectedItem.ToString();

                decimal price = Convert.ToDecimal(TextBoxudtprice.Text);
                clsRowMaterial Dal = new clsRowMaterial();
                Dal.UpdateRowmat(brand, gage, price,shopname);
                Clearallaftersave();
                LoadRowMattoGrid();
            }
               
        }

        protected void dltrowmat(object sender, EventArgs e)
        {
           
           
        }

        protected void addrowmat(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxrmid.Text) ||  string.IsNullOrWhiteSpace(TextBoxrmwidth.Text) || string.IsNullOrWhiteSpace(TextBoxrmqty.Text) || string.IsNullOrWhiteSpace(TextBoxpricepmlen.Text) )
            {

            }
            else if(DropDownListbrand.SelectedValue=="0" || DropDownListgage.SelectedValue == "0" || DropDownListwarelist.SelectedValue == "0")
            {

            }
            else
            {
                string RMaterialId = TextBoxrmid.Text;
                string RMaterialName = TextBoxrmname.Text;
                string RMaterialBrand = DropDownListbrand.SelectedItem.ToString();
                string RMaterialGage = DropDownListgage.SelectedItem.ToString();
                decimal RMaterialwidth = Convert.ToDecimal(TextBoxrmwidth.Text);
                decimal RMaterialQty = Convert.ToDecimal(TextBoxrmqty.Text) * Convert.ToDecimal(TextBoxrmwidth.Text);
                decimal RMaterialMxMprice = Convert.ToDecimal(TextBoxpricepmlen.Text);
                string RMaterialWare = DropDownListwarelist.SelectedItem.ToString();

                clsRowMaterial Dalav = new clsRowMaterial();
                DataSet rma = Dalav.checkregavalromat(RMaterialBrand, RMaterialGage, RMaterialWare);

                if (rma.Tables[0].Rows.Count != 0)
                {
                    decimal oldqty = Convert.ToDecimal((rma.Tables[0].Rows[0]["RMaterialQty"]).ToString());
                    decimal newqty = oldqty + RMaterialQty;

                    clsRowMaterial udt = new clsRowMaterial();
                    udt.UpdateRowmatqty(RMaterialBrand, RMaterialGage, newqty, RMaterialWare);

                    udt.UpdateRowmat(RMaterialBrand, RMaterialGage, RMaterialMxMprice, RMaterialWare);
                    string SupplierName = TextBoxrmname.Text;
                    string ProductType = "RowMaterial";
                    string PaymentType = DropDownListtransfertype.SelectedItem.ToString();
                    decimal PurchasePrice = Convert.ToDecimal(TextBoxsupplierprice.Text);
                    string AdditionalNote = TextBoxnote.Text;
                    //add from admin in table accept rowmaerial without request 
                    string Recby = DropDownListwarelist.SelectedItem.ToString();
                    string from = Session["UserName"].ToString();
                    string purdate = DateTime.Now.ToShortDateString();
                    string byy = Session["UserBy"].ToString();
                    clsRMRequest Dal2 = new clsRMRequest();

                    RMRequest obj = InitalizeObjectreq();
                    Dal2.AddNewRMrequest(obj);
                    Dal2.ApproveReqest(RMaterialId, Recby, RMaterialBrand, RMaterialGage, RMaterialwidth, RMaterialQty, from);
                    Dal2.SendRecRM(RMaterialId,byy);
                    clsRowMaterial Dal5 = new clsRowMaterial();
                    Dal5.AddPurchaseNote(RMaterialId, SupplierName, RMaterialBrand, RMaterialGage, ProductType, PurchasePrice, RMaterialQty,AdditionalNote, PaymentType, purdate);
                    Clearallaftersave();
                    //Clearallaftersave();
                    LoadRowMattoGrid();
                }
                else
                {
                    clsRowMaterial Dal = new clsRowMaterial();
                    //RowMaterial obj = InitalizeObject();
                    Dal.AddNewRowmat(RMaterialId,  RMaterialBrand, RMaterialGage, RMaterialQty, RMaterialMxMprice, RMaterialWare);
                    string purdate = DateTime.Now.ToShortDateString();
                    string SupplierName = TextBoxrmname.Text;
                    string ProductType = "RowMaterial";
                    string PaymentType = DropDownListtransfertype.SelectedItem.ToString();
                    decimal PurchasePrice = Convert.ToDecimal(TextBoxsupplierprice.Text);
                    string AdditionalNote = TextBoxnote.Text;
                    Dal.AddPurchaseNote(RMaterialId, SupplierName, RMaterialBrand, RMaterialGage, ProductType, PurchasePrice, RMaterialQty, AdditionalNote, PaymentType, purdate);

                    //add from admin in table accept rowmaerial without request 
                    string Recby = DropDownListwarelist.SelectedItem.ToString();
                    string from = Session["UserName"].ToString();
                    string byy = Session["UserBy"].ToString();
                    clsRMRequest Dal2 = new clsRMRequest();
                    RMRequest obj = InitalizeObjectreq();
                    Dal2.AddNewRMrequest(obj);
                    Dal2.ApproveReqest(RMaterialId, Recby, RMaterialBrand, RMaterialGage, RMaterialwidth, RMaterialQty, from);
                    Dal2.SendRecRM(RMaterialId,byy);
                    Clearallaftersave();
                    //Clearallaftersave();
                    LoadRowMattoGrid();

                }

            }



        }

        private RMRequest InitalizeObjectreq()
        {
            RMRequest rqt = new RMRequest();
            rqt.RMRecID = TextBoxrmid.Text;
           
            rqt.RMBrand= DropDownListbrand.SelectedItem.ToString();
            rqt.RMGage = DropDownListgage.SelectedItem.ToString();
            rqt.RMWidth = Convert.ToDecimal(TextBoxrmwidth.Text);
            rqt.RMLength= Convert.ToDecimal(TextBoxrmqty.Text);
            rqt.RecDate = DateTime.Now.ToShortDateString();
            rqt.RecBy= DropDownListwarelist.SelectedItem.ToString();
            rqt.Status = "Requested";
            return rqt;
        }

        private RowMaterial InitalizeObject()
        {
            RowMaterial rm = new RowMaterial();
            rm.RMaterialId = TextBoxrmid.Text;
            rm.RMaterialName = TextBoxrmname.Text;
            rm.RMaterialBrand = DropDownListbrand.SelectedItem.ToString();
            rm.RMaterialGage = DropDownListgage.SelectedItem.ToString();
           
            rm.RMaterialQty = Convert.ToDecimal(TextBoxrmqty.Text) * Convert.ToDecimal(TextBoxrmwidth.Text);
            rm.RMaterialMxMprice = Convert.ToDecimal(TextBoxpricepmlen.Text);
            rm.RMaterialWare = DropDownListwarelist.SelectedItem.ToString();
            return rm;
        }

        private void Clearallaftersave()
        {
           // TextBoxmxmuprice.Text = "";
            TextBoxpricepmlen.Text = "";
        
            DropDownListgage.Items.Clear();
            DropDownListbrand.SelectedValue = "0";
            DropDownListgages.Items.Clear();
            TextBoxrmid.Text = "";
            TextBoxrmqty.Text = "";
            TextBoxrmwidth.Text = "";
            TextBoxrmname.Text = "";
            TextBoxsupplierprice.Text = "";
            TextBoxaddedprice.Text = "";
            TextBoxudtprice.Text = "";

        }

        protected void calmxmpricerm(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxsupplierprice.Text) || string.IsNullOrWhiteSpace(TextBoxaddedprice.Text))
            {

            }
            else
            {
                decimal totalprice = Convert.ToDecimal(TextBoxsupplierprice.Text) + Convert.ToDecimal(TextBoxaddedprice.Text);

                decimal width = Convert.ToDecimal(TextBoxrmwidth.Text);
                decimal qty = Convert.ToDecimal(TextBoxrmqty.Text);

                decimal cmxcmarea = width * qty;

                decimal totalpricecmxcm = totalprice / cmxcmarea;
                totalpricecmxcm = Math.Round(totalpricecmxcm, 2);
                TextBoxpricepmlen.Text = Convert.ToString(totalpricecmxcm);
            }
          
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        private void LoadRowMattoGrid()
        {
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet rm = Dal.LoadRowmatList();

            if (rm.Tables[0].Rows.Count != 0)
            {
               GridViewrmlst.DataSource = rm.Tables[0];
                GridViewrmlst.DataBind();
                totalapptransfer.Text = (GridViewrmlst.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {

            }
        }

        protected void sendmaterial(object sender, EventArgs e)
        {

        }

        protected void loadselectedrowmat(object sender, EventArgs e)
        {

        }

        protected void GenRmid(object sender, EventArgs e)
        {
           
            var guid = Guid.NewGuid().ToString().Substring(0, 6);
         
            TextBoxrmid.Text = "RM" + '-' + guid;
           
        }

        protected void enableddlgage(object sender, EventArgs e)
        {
            string brand = DropDownListbrand.SelectedItem.ToString();
            DropDownListgage.Items.Clear();

            loadallgages(brand);
        }

        protected void showaddrmat(object sender, EventArgs e)
        {
            udtrmatpr.Style["visibility"] = "hidden";
            udtrmatpr.Style["display"] = "none";
            addmat.Style["visibility"] = "visible";
            addmat.Style["display"] = "block";
        }

        protected void showustrmat(object sender, EventArgs e)
        {
            addmat.Style["visibility"] = "hidden";
            addmat.Style["display"] = "none";
            udtrmatpr.Style["visibility"] = "visible";
            udtrmatpr.Style["display"] = "block";
            loadallbrands();
        }

        private void loadallbrands()
        {

            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrands.DataTextField = "ProductBrand";
            DropDownListbrands.DataValueField = "ProductBrand";
            DropDownListbrands.DataSource = probrand.Tables[0];
            DropDownListbrands.DataBind();
            DropDownListbrands.Items.Insert(0, "-- Select--");
            DropDownListbrands.Items[0].Value = "0";
        }

        protected void enabledgages(object sender, EventArgs e)
        {
            string brand = DropDownListbrands.SelectedItem.ToString();
            DropDownListgages.Items.Clear();

            loadalludtgages(brand);
        }

        private void loadalludtgages(string brand)
        {
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListgages.DataTextField = "ProductGage";
            DropDownListgages.DataValueField = "ProductGage";
            DropDownListgages.DataSource = progage.Tables[0];
            DropDownListgages.DataBind();
            DropDownListgages.Items.Insert(0, "-- Select--");
            DropDownListgages.Items[0].Value = "0";
        }

        protected void udtQuanty(object sender, EventArgs e)
        {
            if (DropDownListbrands.SelectedValue == "0" || DropDownListgages.SelectedValue == "0" || DropDownListshopname.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxudtprice.Text))
            {

            }
            else
            {
                string brand = DropDownListbrands.SelectedItem.ToString();
                string gage = DropDownListgages.SelectedItem.ToString();
                string shopname = DropDownListshopname.SelectedItem.ToString();

                decimal qty = Convert.ToDecimal(TextBoxudtprice.Text);
                clsRowMaterial Dal = new clsRowMaterial();
                Dal.UpdateRowmatqty(brand, gage, qty, shopname);
                Clearallaftersave();
                LoadRowMattoGrid();
            }
        }

        protected void SearchonWarehouse(object sender, EventArgs e)
        {
            if (DropDownListbrands.SelectedValue == "0" || DropDownListgages.SelectedValue == "0" || DropDownListshopname.SelectedValue == "0" )
            {

            }
            else
            {
                string brand = DropDownListbrands.SelectedItem.ToString();
                string gage = DropDownListgages.SelectedItem.ToString();
                string shopname = DropDownListshopname.SelectedItem.ToString();
                GridViewrmlst.DataSource = null;
                GridViewrmlst.DataBind();
                clsRowMaterial Dal = new clsRowMaterial();
                DataSet rm = Dal.LoadRowmatListbgs(brand,gage,shopname);

                if (rm.Tables[0].Rows.Count != 0)
                {
                    GridViewrmlst.DataSource = rm.Tables[0];
                    GridViewrmlst.DataBind();
                    totalapptransfer.Text = (GridViewrmlst.DataSource as DataTable).Rows.Count.ToString();
                }
                else
                {

                }
            }
        }
    }
}