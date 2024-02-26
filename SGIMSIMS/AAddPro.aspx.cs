using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AAddPro : System.Web.UI.Page
    {
        string type;
        string protype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Admin")
            {

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                string username = Labelsession.Text;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                addproduct.Style["visibility"] = "hidden";
                addproduct.Style["display"] = "none";
                udtprice.Style["visibility"] = "hidden";
                udtprice.Style["display"] = "none";
                divMessage.Style["visibility"] = "hidden";
                divMessage.Style["display"] = "none";
                LoadWarehouse();
            }
            
           
            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";
        }

        private void LoadWarehouse()
        {
           
            clsRowMaterial Dal = new clsRowMaterial();
            DataSet warename = Dal.FillUserNamewITHAD();
            DropDownListselestore.DataTextField = "AssignShop";
            DropDownListselestore.DataValueField = "AssignShop";


            DropDownListselestore.DataSource = warename.Tables[0];
            DropDownListselestore.DataBind();
            DropDownListselestore.Items.Insert(0, "-- Select Store Name--");
            DropDownListselestore.Items[0].Value = "0";

            DropDownListshoplst.DataTextField = "AssignShop";
            DropDownListshoplst.DataValueField = "AssignShop";


            DropDownListshoplst.DataSource = warename.Tables[0];
            DropDownListshoplst.DataBind();
            DropDownListshoplst.Items.Insert(0, "-- Select Store Name--");
            DropDownListshoplst.Items[0].Value = "0";
            
        }

        protected void addpro(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxproname.Text) || string.IsNullOrEmpty(TextBoxproid.Text) ||  DropDownListprotype.SelectedValue == "0")
            {
                Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                TextBoxproid.CssClass  = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

            else
            {
                if (DropDownListprotype.SelectedItem.ToString() == "Ordered")
                {
                    string protype = DropDownListprotype.SelectedItem.ToString();
                    string ProductId = TextBoxproid.Text;
                    string ProductName = TextBoxproname.Text.ToString();
                 
                    string ProductType = DropDownListprotype.SelectedItem.ToString();

                   
                    clsProduct Dal = new clsProduct();
                    DataSet pro = Dal.LoadOrdProductListcheck(ProductName, ProductType);

                    if (pro.Tables[0].Rows.Count == 0)
                    {
                        clsProduct Dal3 = new clsProduct();

                        Dal3.AddNewOrderProduct(ProductId, ProductType, ProductName);
                        Clearallaftersave();
                        LoadProductstoGrid(protype);
                    }

                    else
                    {
                        Labelalertonbtntopr.Text = "Product is already registered";
                        divMessage.Style["visibility"] = "visible";
                        divMessage.Style["display"] = "block";
                    }
                    clearaftersave();
                }
                else if (DropDownListprotype.SelectedItem.ToString() == "Pre-Manufucture")
                {
                    if (string.IsNullOrEmpty(TextBoxproprice.Text) )
                    {
                        Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                        TextBoxproid.CssClass = "form-control-sm form-control is -invalid";
                        divMessage.Style["visibility"] = "visible";
                        divMessage.Style["display"] = "block";
                    }
                    string proid = TextBoxproid.Text;
                    string type = DropDownListprotype.SelectedItem.ToString();
                    string pmproname = TextBoxproname.Text;
                    decimal matneed = Convert.ToDecimal(TextBoxamtneed.Text);
                    decimal upmpro = Convert.ToDecimal(TextBoxproprice.Text);
                    clsProduct Dal = new clsProduct();
                    DataSet pro = Dal.LoadOrdProductListcheck(pmproname, type);

                    if (pro.Tables[0].Rows.Count == 0)
                    {
                        clsProduct Dal2 = new clsProduct();
                        Dal2.AddNewPMProduct(proid, pmproname, type, matneed, upmpro);
                        Clearallaftersave();
                    }
                    else
                    {
                        Labelalertonbtntopr.Text = "Product is already registered You can  update price.";
                      
                        divMessage.Style["visibility"] = "visible";
                        divMessage.Style["display"] = "block";
                    }
                    LoadProductstoGrid(type);
                    clearaftersave();
                }
                else if (DropDownListprotype.SelectedItem.ToString() == "Purchased")
                {
                    string productType = DropDownListprotype.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(TextBoxproprice.Text) || TextBoxpurproqty.Text=="" || DropDownListselltype.SelectedValue == "0")
                    {
                        Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                        TextBoxproid.CssClass = "form-control-sm form-control is -invalid";
                        divMessage.Style["visibility"] = "visible";
                        divMessage.Style["display"] = "block";
                    }
                    else
                    {
                        decimal perqty = Convert.ToDecimal(TextBoxpurproqty.Text);
                        string proid = TextBoxproid.Text;
                        string purproname = TextBoxproname.Text;
                        string selstore = DropDownListselestore.SelectedItem.ToString();
                        string ProductType = "PurchaseProduct";
                        string SupplierName = TextBoxsuppname.Text ;
                        string PaymentType = DropDownLispaymentype.SelectedItem.ToString();
                        string AdditionalNote =TextBoxnote.Text;
                        decimal PurchasePrice = Convert.ToDecimal(TextBoxsupprice.Text);
                        string selltype = DropDownListselltype.SelectedItem.ToString();
                        decimal upmpro = Convert.ToDecimal(TextBoxproprice.Text);
                        string purdate = DateTime.Now.ToShortDateString();
                        clsProduct Dal4 = new clsProduct();
                        DataSet propur = Dal4.Loadpurchaseprodcheck(proid, purproname, type, selstore);
                        
                        if (propur.Tables[0].Rows.Count == 0)
                        {
                            clsProduct Dal3 = new clsProduct();
                            Dal3.AddNewpurchproduct(proid, productType, purproname, selltype, upmpro, selstore, perqty);
                            clsRowMaterial Dal5 = new clsRowMaterial();
                            Dal5.AddPurchaseNote(proid, SupplierName, purproname, selltype, ProductType, PurchasePrice, perqty, AdditionalNote, PaymentType,purdate);

                            Clearallaftersave();
                        }
                        else
                        {

                           
                            // select qty from pur dbtable and update qty.
                            clsProduct Dal2 = new clsProduct();
                            Dal2.updatepurchproductqty(proid, productType, purproname, selltype, upmpro, selstore, perqty);
                            clsRowMaterial Dal5 = new clsRowMaterial();
                            Dal5.AddPurchaseNote(proid, SupplierName, purproname, selltype, ProductType, PurchasePrice, perqty, AdditionalNote, PaymentType,purdate);

                            Clearallaftersave();
                        }
                        DropDownListselestore.SelectedValue = "0";
                        DropDownListselestore.SelectedValue = "0";
                      

                    }
                   // LoadProductstoGrid(type);
                    clearaftersave();

                }



            }
            
           
        }

        private void clearaftersave()
        {
            TextBoxproid.Text = "";
            TextBoxproname.Text = "";
            TextBoxproprice.Text = "";
            TextBoxamtneed.Text = "";
           // DropDownListprotype.SelectedValue = "0";
        }

        private void LoadProductstoGrid(string protype)
        {
           
            clsProduct Dal = new clsProduct();
            DataSet pro = Dal.LoadProductList(protype);

            if (pro.Tables[0].Rows.Count != 0)
            {
                GridViewprolst.DataSource = pro.Tables[0];
                GridViewprolst.DataBind();
                Labeltotalprodt.Text = GridViewprolst.Rows.Count.ToString();
            }
            else
            {
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
            }
        }

        private void Clearallaftersave()
        {
           
            TextBoxproid.Text ="";
            TextBoxudtprice.Text = "";
            DropDownListudtprolist.SelectedValue = "0";
            DropDownListudtprotype.SelectedValue = "0";
            TextBoxproname.Text = "";
          
            TextBoxproprice.Text = "";
            DropDownListprotype.SelectedValue = "0";
            DropDownListselltype.SelectedValue = "0";

        }


        protected void udtpro(object sender, EventArgs e)
        {
            decimal udtprice = Convert.ToDecimal(TextBoxudtprice.Text);
            string proname = DropDownListudtprolist.SelectedItem.ToString();
            if(DropDownListudtprotype.SelectedValue== "0" || DropDownListudtprolist.SelectedValue=="0")
            {
                Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                DropDownListudtprotype.CssClass = "form-control-sm form-control is -invalid";
                DropDownListudtprolist.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            if(DropDownListudtprotype.SelectedItem.ToString()== "Pre-Manufucture")
            {
                string protype = DropDownListudtprotype.SelectedItem.ToString();
                clsProduct Dal = new clsProduct();
                Dal.udtpricepremanpri(protype, proname, udtprice);
                Clearallaftersave();
            }
            else if(DropDownListudtprotype.SelectedItem.ToString() == "Purchased")
            {
                string protype = DropDownListudtprotype.SelectedItem.ToString();
                string ware = DropDownListshoplst.SelectedItem.ToString();
                clsProduct Dal = new clsProduct();
                Dal.udtpriceperchasepri(protype, proname, udtprice,ware);
                Clearallaftersave();
            }
            else
            {
                Labelalertonbtntopr.Text = "Please Enter Required Data Attributes";
                DropDownListudtprotype.CssClass = "form-control-sm form-control is -invalid";
                DropDownListudtprolist.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

           
        }

        protected void dltpro(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxproid.Text) || DropDownListprotype.SelectedValue =="0")
            {

            }
            else
            {
                string pronames = TextBoxproname.Text;
                string proids = TextBoxproid.Text;
                string protypes = DropDownListprotype.SelectedItem.ToString();
                clsProduct pro = new clsProduct();
                pro.DeleteProducts(pronames, proids, protypes);
                clearaftersave();
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void Loadprodpage(object sender, GridViewPageEventArgs e)
        {
            if (DropDownListprotype.SelectedValue=="0")
            {
                Labelalertonbtntopr.Text = "Please Select Product Type First";
                TextBoxproid.CssClass = "form-control-sm form-control is -invalid";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {

                string protype = DropDownListprotype.SelectedItem.ToString();
                GridViewprolst.PageIndex = e.NewPageIndex;
                LoadProductstoGrid(protype);
            }
      
        }

        protected void Loadproductlst(object sender, EventArgs e)
        {
            GridViewRow row = GridViewprolst.SelectedRow;
            TextBoxproid.Text = row.Cells[1].Text;
            TextBoxproname.Text = row.Cells[2].Text;
            TextBoxproprice.Text = row.Cells[3].Text;

        }

        protected void ProductTypeSelectedIndex(object sender, EventArgs e)
        {
            if(DropDownListprotype.SelectedItem.ToString() == "Purchased")
            {
                protype = DropDownListprotype.SelectedItem.ToString();
                TextBoxpurproqty.Visible = true;
                DropDownListselltype.Visible = true;
                DropDownListselestore.Visible = true;
                matneed.Style["visibility"] = "hidden";
                matneed.Style["display"] = "none";
                all.Style["visibility"] = "visible";
                all.Style["display"] = "block";
                Labelpurproqty.Visible = true;
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
                LoadProductstoGrid(protype);
            }
            else if(DropDownListprotype.SelectedItem.ToString() == "Pre-Manufucture")
            {
                protype = DropDownListprotype.SelectedItem.ToString();
                matneed.Style["visibility"] = "visible";
                matneed.Style["display"] = "block";
                all.Style["visibility"] = "visible";
                all.Style["display"] = "block";
                DropDownListselltype.Visible = false;
                DropDownListselestore.Visible = false;
                TextBoxpurproqty.Visible = false;
                Labelpurproqty.Visible = false;
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
                LoadProductstoGrid(protype);
            }
            else if(DropDownListprotype.SelectedItem.ToString() == "Ordered")
            {
                 protype = DropDownListprotype.SelectedItem.ToString();
                all.Style["visibility"] = "hidden";
                all.Style["display"] = "none";
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
                LoadProductstoGrid(protype);
            }
            else
            {
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
                all.Style["visibility"] = "hidden";
                all.Style["display"] = "none";
            }
        }

        protected void showaddproduct(object sender, EventArgs e)
        {
            GridViewprolst.Visible = true;
            DropDownListprotype.SelectedValue = "0";
            all.Style["visibility"] = "hidden";
            all.Style["display"] = "none";
            addproduct.Style["visibility"] = "visible";
            addproduct.Style["display"] = "block";
            udtprice.Style["visibility"] = "hidden";
            udtprice.Style["display"] = "none";

        }

        protected void showupdateproduct(object sender, EventArgs e)
        {
            GridViewprolst.Visible = false;
            udtprice.Style["visibility"] = "visible";
            udtprice.Style["display"] = "block";
            addproduct.Style["visibility"] = "hidden";
            addproduct.Style["display"] = "none";
        }

        protected void udtTypeSelectedIndex(object sender, EventArgs e)
        {
            
            if (DropDownListudtprotype.SelectedItem.ToString() == "Pre-Manufucture")
            {
                
                type = DropDownListudtprotype.SelectedValue.ToString();

                DropDownListudtprolist.Items.Clear();
                LoadProductName(type);
                LoadProductstoGrid(type);
           
            }
            else if (DropDownListudtprotype.SelectedItem.ToString() == "Purchased")
            {
                type = DropDownListudtprotype.SelectedValue.ToString(); 

                DropDownListudtprolist.Items.Clear();
                LoadProductName(type);
                LoadProductstoGrid(type);
            }
            else
            {
                GridViewprolst.DataSource = null;
                GridViewprolst.DataBind();
            }
        }

        private void LoadProductName(string type)
        {
            clsProduct Dal = new clsProduct();
            DataSet proname = Dal.FillProname(type);
            DropDownListudtprolist.DataTextField = "ProductName";
            DropDownListudtprolist.DataValueField = "ProductName";
            DropDownListudtprolist.DataSource = proname.Tables[0];
            DropDownListudtprolist.DataBind();
            DropDownListudtprolist.Items.Insert(0, "-- Select Product Name--");
            DropDownListudtprolist.Items[0].Value = "0";
        }

        protected void Genproductid(object sender, EventArgs e)
        {
            if(DropDownListprotype.SelectedValue=="0")
            {
                    //error
            }
            if(DropDownListprotype.SelectedItem.ToString() == "Pre-Manufucture")
            {
                

                var guid = Guid.NewGuid().ToString().Substring(0, 4);
                

                TextBoxproid.Text = "Man-Pro" + '-' + guid;

            }
            else if(DropDownListprotype.SelectedItem.ToString() == "Purchased")
            {
                var guid = Guid.NewGuid().ToString().Substring(0, 4);


                TextBoxproid.Text = "Pur-Pro" + '-' + guid;

            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Ordered")
            {
                var guid = Guid.NewGuid().ToString().Substring(0, 4);
                
                TextBoxproid.Text = "Ord-Pro" + '-' + guid;

            }
            else 
            {

            }
        }
    }
}