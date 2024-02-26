using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class AAddPrice : System.Web.UI.Page
    {
        string ware;
        decimal len;
        decimal brwidth;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                ware = Session["UserName"].ToString();

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                LoadProName();
                Label1.Visible = false;
                Label2.Visible = false;
                LoadWareHouse();
                loadbrand();
                Labelmessage.Visible = false;
                //premanreg.Style["visibility"] = "visible";
                //premanreg.Style["display"] = "block";
            }
           
        }

        private void loadbrand()
        {
           
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrand.DataTextField = "ProductBrand";
            DropDownListbrand.DataValueField = "ProductBrand";
            DropDownListbrand.DataSource = probrand.Tables[0];
            DropDownListbrand.DataBind();
            DropDownListbrand.Items.Insert(0, "--የጥሬ ዕቃ ምረጥ--");
            DropDownListbrand.Items[0].Value = "0";

            DropDownListtranbrand.DataTextField = "ProductBrand";
            DropDownListtranbrand.DataValueField = "ProductBrand";
            DropDownListtranbrand.DataSource = probrand.Tables[0];
            DropDownListtranbrand.DataBind();
            DropDownListtranbrand.Items.Insert(0, "--የጥሬ ዕቃ ምረጥ--");
            DropDownListtranbrand.Items[0].Value = "0";
        }

        private void LoadWareHouse()
        {
            string usrroll = "Sales Manager";
            //string name = Session["UserName"].ToString();
            clsProduct Dal = new clsProduct();
            DataSet warename = Dal.FillUserName(usrroll);
            DropDownListtranware.DataTextField = "AssignShop";
            DropDownListtranware.DataValueField = "AssignShop";

            DropDownListtranware.DataSource = warename.Tables[0];
            DropDownListtranware.DataBind();
            DropDownListtranware.Items.Insert(0, "--የሚያክበት ቦታ ምረጥ--");
            DropDownListtranware.Items[0].Value = "0";
        }

        private void LoadProName()
        {
            string type = "Pre-Manufucture";
            clsProduct Dal = new clsProduct();
            DataSet warename = Dal.FillProname(type);
            DropDownListproname.DataTextField = "ProductName";
            DropDownListproname.DataValueField = "ProductName";



            DropDownListproname.DataSource = warename.Tables[0];
            DropDownListproname.DataBind();
           DropDownListproname.Items.Insert(0, "--የምርት ስም ምረጥ--");
           DropDownListproname.Items[0].Value = "0";

            DropDownListtranproname.DataTextField = "ProductName";
            DropDownListtranproname.DataValueField = "ProductName";



            DropDownListtranproname.DataSource = warename.Tables[0];
            DropDownListtranproname.DataBind();
            DropDownListtranproname.Items.Insert(0, "--የምርት ስም ምረጥ--");
            DropDownListtranproname.Items[0].Value = "0";
        }

    

        protected void addproprice(object sender, EventArgs e)
        {
          
           if(DropDownListproname.SelectedValue=="0" || DropDownListbrand.SelectedValue == "0" || DropDownListgage.SelectedValue=="0" || string.IsNullOrWhiteSpace(TextBoxqtyforprodu.Text))
            {
                Labelmessage.Visible = true;
                Labelmessage.Text = "እባክዎ በመጀመሪያ መረጃዎችን በትክክል ያስገቡ።";
            }
            else
            {
                if(string.IsNullOrWhiteSpace(TextBoxlength.Text))
                {
                    len = 1;
                }
                else
                {
                    len = Convert.ToDecimal(TextBoxlength.Text);
                }
                if (string.IsNullOrWhiteSpace(TextBoxwidth.Text))
                {
                    brwidth = 1;
                }
                else
                {
                    brwidth = Convert.ToDecimal(TextBoxwidth.Text);
                }
                
                string brand = DropDownListbrand.SelectedItem.ToString();
                string gage = DropDownListgage.SelectedItem.ToString();
                string name = DropDownListproname.SelectedItem.ToString();
                string ware = Session["UserName"].ToString();
                decimal qty = Convert.ToDecimal(TextBoxqtyforprodu.Text);
                decimal quantity = qty * len * brwidth;
                string protype = "RMaterial";
                clsProduct Dal1 = new clsProduct();
                DataSet pmpl = Dal1.CheckPMPNameLst(name,brand,gage,brwidth,len, ware, qty);
                if (pmpl.Tables[0].Rows.Count != 0)
                {
                   
                    clsRowMaterial Dalav = new clsRowMaterial();
                    DataSet pmpl3 = Dalav.checkregavalromat(brand, gage, ware);

                   
                    if (pmpl3.Tables[0].Rows.Count != 0)
                    {
                        clsProduct Dal5 = new clsProduct();
                        Dal5.UpdatePMPQtyLst(name, brand, gage, brwidth, len, ware, qty);
                        clsProduct Dal = new clsProduct();
                        Dal.UpdatePreManProQty(brand, gage, ware, quantity, protype);

                        LoadPrremanstorelstoGrid();
                        Clearallaftersave();
                    }
                    else
                    {
                        Labelmessage.Visible = true;
                        Labelmessage.Text = "የጥሬ ዕቃ ስለሌልዎት በመጀመሪያ የጥሬ ዕቃ ጥያቄ ያቅርቡ።";
                    }
                }
                else
                {
                    clsRowMaterial Dalav = new clsRowMaterial();
                    DataSet pmpl3 = Dalav.checkregavalromat(brand, gage, ware);


                    if (pmpl3.Tables[0].Rows.Count != 0)
                    {
                        clsProduct Dal = new clsProduct();
                        Dal.AddNewPMPLst(name, brand, gage, brwidth, len, ware, qty);
                        clsProduct Dal2 = new clsProduct();
                        Dal2.UpdatePreManProQty(brand, gage, ware, quantity, protype);

                        LoadPrremanstorelstoGrid();
                        Clearallaftersave();
                    }
                    else
                    {
                        Labelmessage.Visible = true;
                        Labelmessage.Text = "የጥሬ ዕቃ ስለሌልዎት በመጀመሪያ የጥሬ ዕቃ ጥያቄ ያቅርቡ።";
                    }
                        
                }


              
            }
            
        }

        private void Clearallaftersave()
        {
            DropDownListproname.SelectedValue = "0";
          
            TextBoxqtyforprodu.Text = "";
            DropDownListtranproname.SelectedValue = "0";
           DropDownListtranware.SelectedValue = "0";
            TextBoxreqid.Text = "";
            TextBoxtransqty.Text = "";
        }

      

        private void LoadPrremanstorelstoGrid()
        {
            clsProduct Dal = new clsProduct();
            DataSet pro = Dal.LoadPreManStore(ware);

            if (pro.Tables[0].Rows.Count != 0)
            {
               
                GridViewpreprolst.DataSource = pro.Tables[0];
                GridViewpreprolst.DataBind();
                
            }
            else
            {


            }
        }

        protected void udtproprice(object sender, EventArgs e)
        {

        }

        protected void dltproprice(object sender, EventArgs e)
        {

        }

        protected void newpricelistpage(object sender, GridViewPageEventArgs e)
        {
            if (premantransfer.Style["visibility"] != "hidden")

            {
                GridViewpreprolst.PageIndex = e.NewPageIndex;
                LoadPrremanreqtGrid();
            }
            else
            {
                GridViewpreprolst.PageIndex = e.NewPageIndex;
                LoadPrremanstorelstoGrid();
            }
           
        }

        protected void selectandeditpricelst(object sender, EventArgs e)
        {
            Buttontansprempro.Visible = true;
            GridViewRow row = GridViewpreprolst.SelectedRow;
            TextBoxreqid.Text = row.Cells[1].Text;
            TextBoxtranwidth.Text = row.Cells[5].Text;
            TextBoxtranlen.Text = row.Cells[6].Text;
            TextBoxtransqty.Text = row.Cells[7].Text;
            
            
            //DropDownListtranproname.SelectedValue = row.Cells[2].Text;

            // DropDownListtranware.SelectedValue = row.Cells[5].Text;
            // DropDownListtranware.SelectedValue = row.Cells[5].Text;
           
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        protected void showaddpreman(object sender, EventArgs e)
        {
            premantransfer.Style["visibility"] = "hidden";
            premantransfer.Style["display"] = "none";
            premanreg.Style["visibility"] = "visible";
            premanreg.Style["display"] = "block";
            Label1.Visible = true;
            Label1.Text = "ያለ ትዕዛዝ የተፈበረኩ ምርቶች ዝርዝር";
            GridViewpreprolst.DataSource = null;
            GridViewpreprolst.DataBind();
            LoadPrremanstorelstoGrid();
        }

        protected void showtranspreman(object sender, EventArgs e)
        {
            Buttontansprempro.Visible = false;
            premanreg.Style["visibility"] = "hidden";
            premanreg.Style["display"] = "none";
            premantransfer.Style["visibility"] = "visible";
            premantransfer.Style["display"] = "block";
            Label1.Visible = true;
            Label1.Text = "የተጠየቁ ያለ ትዕዛዝ የተፈበረኩ ምርቶች ዝርዝር";
            GridViewpreprolst.DataSource = null;
            GridViewpreprolst.DataBind();
            LoadPrremanreqtGrid();
        }

        private void LoadPrremanreqtGrid()
        {
            clsPMPequest Dal = new clsPMPequest();
            DataSet pro = Dal.LoadAllRMReq(ware);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewpreprolst.DataSource = pro.Tables[0];
                GridViewpreprolst.DataBind();

            }
            else
            {


            }
        }

        protected void transproprice(object sender, EventArgs e)
        {
            if (DropDownListtranproname.SelectedValue == "0" || DropDownListtranware.SelectedValue=="0" ||string.IsNullOrWhiteSpace(TextBoxreqid.Text) || string.IsNullOrWhiteSpace(TextBoxtransqty.Text))
            {
                //error
            }
            else
            {
                decimal tranlen, tranwdth;
                string recid = TextBoxreqid.Text;
                string username = Session["UserName"].ToString();
                string name = DropDownListtranproname.SelectedItem.ToString();
                string ware = DropDownListtranware.SelectedItem.ToString();
                decimal qty = Convert.ToDecimal(TextBoxtransqty.Text);
                string brand = DropDownListtranbrand.SelectedItem.ToString();
                string gage = DropDownListtrangage.SelectedItem.ToString();
                if(string.IsNullOrWhiteSpace(TextBoxtranlen.Text))
                {
                    tranlen = 1;
                }
                else
                {
                    tranlen = Convert.ToDecimal(TextBoxtranlen.Text);
                }
                if (string.IsNullOrWhiteSpace(TextBoxtranwidth.Text))
                {
                    tranwdth = 1;
                }
                else
                {
                    tranwdth = Convert.ToDecimal(TextBoxtranwidth.Text);
                }
                clsProduct Dal1 = new clsProduct();
                DataSet pmpl = Dal1.CheckPMPNameLst(name,brand,gage,tranwdth,tranlen, ware, qty);
                if (pmpl.Tables[0].Rows.Count != 0)
                {

                    decimal qtyold = Convert.ToDecimal((pmpl.Tables[0].Rows[0]["PreManProductQty"]).ToString());

                    clsProduct Dal2 = new clsProduct();
                    Dal2.UpdatePMPQtyLst(name, brand, gage, tranwdth, tranlen, ware, qty);

                    clsProduct Dal3 = new clsProduct();
                    Dal3.UpdateIntManPMPQtyLst(name, brand, gage, tranwdth, tranlen, username, qty);
                    clsPMPequest Dal = new clsPMPequest();
                        Dal.SendRecRM(recid);
                    GridViewpreprolst.DataSource = null;
                    GridViewpreprolst.DataBind();
                    LoadPrremanreqtGrid();
                    Label2.Visible = true;
                    Label2.Text = "ምርት ልከዋል መድረሱን ደውለው ያረጋግጡ።";
                    Clearallaftersave();
                }
                else
                {
                    Label2.Visible = true;
                    Label2.Text = "ምርት ልከዋል መድረሱን ደውለው ያረጋግጡ።";
                    clsProduct Dal = new clsProduct();
                    Dal.AddNewPMPLst(name, brand, gage, tranwdth, tranlen, ware, qty);
                    clsProduct Dal3 = new clsProduct();
                    Dal3.UpdateIntManPMPQtyLst(name, brand, gage, tranwdth, tranlen, username, qty);
                    clsPMPequest Da4 = new clsPMPequest();
                    Da4.SendRecRM(recid);
                    GridViewpreprolst.DataSource = null;
                    GridViewpreprolst.DataBind();
                    LoadPrremanreqtGrid();

                    Clearallaftersave();
                }

             
            }
        }

        protected void width(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header))
            {

                if (premantransfer.Style["visibility"] != "hidden")

                {

                    GridViewpreprolst.Columns[0].Visible = true;
                }
                else
                {
                    GridViewpreprolst.Columns[0].Visible = false;
                }
            }
        }

        protected void enableddlgage(object sender, EventArgs e)
        {
           
            if (DropDownListtranbrand.SelectedValue != "0")
            {
                string brand = DropDownListtranbrand.SelectedItem.ToString();
                DropDownListgage.Items.Clear();
                clsProduct Dal = new clsProduct();
                DataSet progage = Dal.FillProGage(brand);
                DropDownListtrangage.DataTextField = "ProductGage";
                DropDownListtrangage.DataValueField = "ProductGage";
                DropDownListtrangage.DataSource = progage.Tables[0];
                DropDownListtrangage.DataBind();
                DropDownListtrangage.Items.Insert(0, "--የጥሬ ዕቃ ጌጅ ምረጥ--");
                DropDownListtrangage.Items[0].Value = "0";
                
            }
            else if(DropDownListbrand.SelectedValue!="0")
            {
                string brand = DropDownListbrand.SelectedItem.ToString();
                DropDownListgage.Items.Clear();
                clsProduct Dal = new clsProduct();
                DataSet progage = Dal.FillProGage(brand);
                DropDownListgage.DataTextField = "ProductGage";
                DropDownListgage.DataValueField = "ProductGage";
                DropDownListgage.DataSource = progage.Tables[0];
                DropDownListgage.DataBind();
                DropDownListgage.Items.Insert(0, "--የጥሬ ዕቃ ጌጅ ምረጥ--");
                DropDownListgage.Items[0].Value = "0";
            }
            else
            {

            }
        }

        protected void udtproqty(object sender, EventArgs e)
        {
            if (DropDownListtranproname.SelectedValue == "0" || DropDownListtranware.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxreqid.Text) || string.IsNullOrWhiteSpace(TextBoxtransqty.Text))
            {
                //error
            }
            else
            {
                decimal tranwdth, tranlen;
                if (string.IsNullOrWhiteSpace(TextBoxtranlen.Text))
                {
                    tranlen = 1;
                }
                else
                {
                    tranlen = Convert.ToDecimal(TextBoxtranlen.Text);
                }
                if (string.IsNullOrWhiteSpace(TextBoxtranwidth.Text))
                {
                    tranwdth = 1;
                }
                else
                {
                    tranwdth = Convert.ToDecimal(TextBoxtranwidth.Text);
                }
                string brand = DropDownListbrand.SelectedItem.ToString();
                string gage = DropDownListgage.SelectedItem.ToString();
                string name = DropDownListproname.SelectedItem.ToString();
                string ware = Session["UserName"].ToString();
                decimal qty = Convert.ToDecimal(TextBoxqtyforprodu.Text);

                clsProduct Dal3 = new clsProduct();
                Dal3.updatepremanqtyerr(name, brand, gage, tranwdth, tranlen, ware, qty);
            }
        }
    }
}