using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMsales : System.Web.UI.Page
    {
        decimal qtyord, unitprice, totalserpri;
        decimal prepaid;
        string username;
        decimal UnitPricepm, UnitPricerm, UnitPriceser, UnitPricepur;
        string orderidforsale;
        decimal pmwidth;
        decimal pmlength;
        decimal preamount;
        string notevat, pmproname, pmpbrand,pmpgage;
        string solduser;
        decimal unitpriceofpro, unitpriceofser;
        string CreditApproved;
        int totalsale, totalsaleor;
        decimal addrev;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {


                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                username = Session["UserName"].ToString();
               solduser = Session["UserBy"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            TextBoxSalesDate.Text = DateTime.UtcNow.AddHours(3).ToShortDateString();
            // TextBoxSalesDate.Text = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                loadpremanprolist();
                loadservicelist();
                loadallbrand();
                LoadBankName();
                loadallpurchasematlst();
                Labelprepaid.Text = "0";
                Labelamount.Text = "0";
                LabelSaleprice.Text = "0";
                creditsale.Style["visibility"] = "hidden";
                creditsale.Style["display"] = "none";
                showsalelist.Style["visibility"] = "hidden";
                showsalelist.Style["display"] = "none";
                Loadallcreditsales();
            }
          
        }

        private void Loadallcreditsales()
        {
            clsSalesData Dal = new clsSalesData();
            DataSet crsa = Dal.LoadAllCrediSale(username);

            if (crsa.Tables[0].Rows.Count != 0)
            {


                GridViewcrdsaleList.DataSource = crsa.Tables[0];
                GridViewcrdsaleList.DataBind();
                totalcrdtsale.Text = (GridViewcrdsaleList.DataSource as DataTable).Rows.Count.ToString();

                
            }
        }

        private void LoadBankName()
        {
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankBankName();
            DropDownListbankname.DataTextField = "BankName";
            DropDownListbankname.DataValueField = "BankName";


            DropDownListbankname.DataSource = ba.Tables[0];
            DropDownListbankname.DataBind();
            DropDownListbankname.Items.Insert(0, "-- የባንክ ስም ምረጥ--");
            DropDownListbankname.Items[0].Value = "0";

            DropDownListcrdbankname.DataTextField = "BankName";
            DropDownListcrdbankname.DataValueField = "BankName";


            DropDownListcrdbankname.DataSource = ba.Tables[0];
            DropDownListcrdbankname.DataBind();
            DropDownListcrdbankname.Items.Insert(0, "-- የባንክ ስም ምረጥ--");
            DropDownListcrdbankname.Items[0].Value = "0";
        }
        private void loadallpurchasematlst()
        {
            
           
            string type = "Purchased";
            clsProduct Dal = new clsProduct();
            DataSet proname = Dal.FillProname(type);
            DropDownListpurprolst.DataTextField = "ProductName";
            DropDownListpurprolst.DataValueField = "ProductName";
            DropDownListpurprolst.DataSource = proname.Tables[0];
            DropDownListpurprolst.DataBind();
            DropDownListpurprolst.Items.Insert(0, "-- Select Product Name--");
            DropDownListpurprolst.Items[0].Value = "0";
        }

        private void loadallbrand()
        {


            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrand.DataTextField = "ProductBrand";
            DropDownListbrand.DataValueField = "ProductBrand";
            DropDownListbrand.DataSource = probrand.Tables[0];
            DropDownListbrand.DataBind();
            DropDownListbrand.Items.Insert(0, "-- Select Product Brand--");
            DropDownListbrand.Items[0].Value = "0";


            DropDownListpmbrand.DataTextField = "ProductBrand";
            DropDownListpmbrand.DataValueField = "ProductBrand";
            DropDownListpmbrand.DataSource = probrand.Tables[0];
            DropDownListpmbrand.DataBind();
            DropDownListpmbrand.Items.Insert(0, "-- Select Product Brand--");
            DropDownListpmbrand.Items[0].Value = "0";
        }

        private void loadallgages(string brand)
        {
            if(DropDownListbrand.SelectedValue!="0")
            {
                DropDownListgage.Items.Clear();
                clsProduct Dal = new clsProduct();
                DataSet progage = Dal.FillProGage(brand);
                DropDownListgage.DataTextField = "ProductGage";
                DropDownListgage.DataValueField = "ProductGage";
                DropDownListgage.DataSource = progage.Tables[0];
                DropDownListgage.DataBind();
                DropDownListgage.Items.Insert(0, "-- Select Product Gage--");
                DropDownListgage.Items[0].Value = "0";
            }
            else
            {

            }
           
        }
        private void loadpremanprolist()
        {
          
            string type = "Pre-Manufucture";
            clsProduct Dal = new clsProduct();
            DataSet proname = Dal.FillProname(type);
            DropDownListpreman.DataTextField = "ProductName";
            DropDownListpreman.DataValueField = "ProductName";
            DropDownListpreman.DataSource = proname.Tables[0];
            DropDownListpreman.DataBind();
            DropDownListpreman.Items.Insert(0, "-- Select Product Name--");
            DropDownListpreman.Items[0].Value = "0";
        }

        private void loadservicelist()
        {
            
            clsService Dal = new clsService();
            DataSet proname = Dal.LoadServiceName();
            DropDownListser.DataTextField = "ProductName";
            DropDownListser.DataValueField = "ProductName";
            DropDownListser.DataSource = proname.Tables[0];
            DropDownListser.DataBind();
            DropDownListser.Items.Insert(0, "-- Select Service Name--");
            DropDownListser.Items[0].Value = "0";
        }

        protected void newsaleslistpage(object sender, GridViewPageEventArgs e)
        {

            GridViewSaleitemlst.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        private void LoadGrid()
        { 

            //string OrderId = TextBoxsearchkey.Text;
        
            //clsOrder Dal = new clsOrder();
            //DataSet Order = Dal.LoadPriceTosaleTable(OrderId);

            //if (Order.Tables[0].Rows.Count != 0)
            //{
            //    GridViewSaleitemlst.DataSource = Order.Tables[0];
            //    GridViewSaleitemlst.DataBind();
            //    totaloprice = Order.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CurrentCost"));
            //    OrderIdFP = Order.Tables[0].AsEnumerable().Max(row => row.Field<string>("OrderId"));
            //    lock 

            //    GridViewSaleitemlst.FooterRow.Cells[7].Text = "Total";
            //    GridViewSaleitemlst.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            //    GridViewSaleitemlst.FooterRow.Cells[8].Text = totaloprice.ToString("N2");

            //    LabelSaleprice.Text = Convert.ToString(totaloprice);
               
            //    LoadOrderPrice();
            //}
        }

        private void LoadOrderPrice()
        {
            //string OrderId = LabelOrderId.Text;
            //decimal TotalOPrice = Convert.ToDecimal(Labeltotalorderprice.Text);
            //clsOrderTPrice Dal = new clsOrderTPrice();
            //DataSet ds = Dal.LoadPriceTosaleTable(OrderId, TotalOPrice);
           
            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    TextBoxPrePaid.Text = (ds.Tables[0].Rows[0]["PrePaidPamount"]).ToString();
            //    TextBoxremainpr.Text = (ds.Tables[0].Rows[0]["RemainingPamount"]).ToString();
                
            //}
            //else
            //{
            //    TextBoxremainpr.Text = "0";
            //}


        }
        protected void showproser(object sender, EventArgs e)
        {
        }

        //protected void showproser(object sender, EventArgs e)
        //{
        //    if(DropDownListproserlst.SelectedItem.ToString() == "Ordered Product")
        //    {

        //        all.Style["visibility"] = "visible";
        //        all.Style["display"] = "block";
        //        order.Style["visibility"] = "visible";
        //        order.Style["display"] = "block";

        //        premanpro.Style["visibility"] = "hidden";
        //        premanpro.Style["display"] = "none";
        //        service.Style["visibility"] = "hidden";
        //        service.Style["display"] = "none";
        //    }
        //    else if(DropDownListproserlst.SelectedItem.ToString() == "Pre-Man Product")
        //    {
        //        all.Style["visibility"] = "visible";
        //        all.Style["display"] = "block";
        //        premanpro.Style["visibility"] = "visible";
        //        premanpro.Style["display"] = "block";

        //        order.Style["visibility"] = "hidden";
        //        order.Style["display"] = "none";
        //        service.Style["visibility"] = "hidden";
        //        service.Style["display"] = "none";
        //    }
        //    else if(DropDownListproserlst.SelectedItem.ToString() == "Service")
        //    {
        //        all.Style["visibility"] = "visible";
        //        all.Style["display"] = "block";
        //        service.Style["visibility"] = "visible";
        //        service.Style["display"] = "block";

        //        premanpro.Style["visibility"] = "hidden";
        //        premanpro.Style["display"] = "none";
        //        order.Style["visibility"] = "hidden";
        //        order.Style["display"] = "none";
        //    }
        //    else
        //    {
        //        all.Style["visibility"] = "hidden";
        //        all.Style["display"] = "none";
        //        order.Style["visibility"] = "hidden";
        //        order.Style["display"] = "none";
        //        service.Style["visibility"] = "hidden";
        //        service.Style["display"] = "none";
        //        premanpro.Style["visibility"] = "hidden";
        //        premanpro.Style["display"] = "none";
        //    }

        //}



        protected void addpremanprosale(object sender, EventArgs e)
        {
            if(DropDownListpreman.SelectedValue== "0" || string.IsNullOrWhiteSpace(TextBoxpreproqty.Text) || string.IsNullOrWhiteSpace(TextBoxunitprice.Text))
            {
                //error
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TextBoxpmwidth.Text))
                {
                    pmwidth = 1;
                }
                else
                {
                    pmwidth = Convert.ToDecimal(TextBoxpmwidth.Text);
                }
                if (string.IsNullOrWhiteSpace(TextBoxpmlength.Text))
                {
                    pmlength = 1;
                }
                else
                {
                    pmlength = Convert.ToDecimal(TextBoxpmlength.Text);
                }
                if (DropDownListpmbrand.SelectedValue == "0")
                {
                    pmpbrand = "";
                }
                else
                {
                    pmpbrand = DropDownListpmbrand.SelectedItem.ToString();

                }
                if (DropDownListpmgage.SelectedValue == "0")
                {
                    pmpgage = "";
                }
                else
                {
                    pmpgage = DropDownListpmbrand.SelectedItem.ToString();

                }
               
                string ProductName = DropDownListpreman.SelectedItem.ToString();
              
                string MaterialUsed = "("+ pmpbrand + "," + pmpgage + ")" ;
               


                decimal Quantity = Convert.ToDecimal(TextBoxpreproqty.Text);
                if (!string.IsNullOrWhiteSpace(TextBoxnewpmprice.Text))
                {
                    decimal newprice = Convert.ToDecimal(TextBoxnewpmprice.Text);
                    decimal unitprice = Convert.ToDecimal(TextBoxunitprice.Text);
                    if (newprice > unitprice)
                    {
                        UnitPricepm = Convert.ToDecimal(TextBoxnewpmprice.Text);
                    }
                    else
                    {
                        UnitPricepm = Convert.ToDecimal(TextBoxunitprice.Text);

                    }
                }
                else
                {
                    UnitPricepm = Convert.ToDecimal(TextBoxunitprice.Text);

                }

               // decimal UnitPrice = Convert.ToDecimal(TextBoxunitprice.Text);
               
                string TransactionType = "FOD";
                string Protype = "Premanufucture";

              
                decimal CurrentCost = Quantity * UnitPricepm * pmlength;
                string MaterialSize = "("+ pmwidth+ "," +pmlength +")";
                //load to grid order list with name, width,length qty pricetotal using orderid
                Random rnd = new Random();
                int spcnum = rnd.Next(1, 1000000);
                //AddpremanSaleData(DropDownListpreman.SelectedItem.ToString(), TextBoxpreproqty.Text, TextBoxunitprice.Text, TextBoxtotprice.Text;)

                clsSalesData Dal = new clsSalesData();
                Dal.AddPManProSale(ProductName, MaterialUsed, MaterialSize, Quantity, UnitPricepm, CurrentCost, TransactionType, Protype, username,solduser, spcnum);
                // GridViewSaleitemlst.DataSource= null;

                LoadGridFromSaletbl();
                hideallcolapse();
            }
            
        
        }
        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MaterialUsed", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MaterialSize", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CurrentCost", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();

                    }
                }
                dr = dt.NewRow();
                dr[0] = DropDownListpreman.SelectedItem.ToString();
                dr[1] = "";
                dr[2] = "";
                dr[3] = TextBoxpreproqty;
                dr[4] = TextBoxunitprice.Text;
                //dr[5] = TextBoxtotprice.Text;

                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr = dt.NewRow();
                dr[0] = DropDownListpreman.SelectedItem.ToString();
                dr[1] = "";
                dr[2] = "";
                dr[3] = TextBoxpreproqty;
                dr[4] = TextBoxunitprice.Text;
                //dr[5] = TextBoxtotprice.Text;

                dt.Rows.Add(dr);

            }

            // If ViewState has a data then use the value as the DataSource
            if (ViewState["CurrentData"] != null)
            {

                GridViewSaleitemlst.DataSource = (DataTable)ViewState["CurrentData"];
                GridViewSaleitemlst.DataBind();
            }
            else
            {
                // Bind GridView with the initial data assocaited in the DataTable
                GridViewSaleitemlst.DataSource = dt;
                GridViewSaleitemlst.DataBind();

            }
            // Store the DataTable in ViewState to retain the values
            ViewState["CurrentData"] = dt;

        }
        protected void orderselladd(object sender, EventArgs e)
        {
            if(TextBoxorderid.Text=="")
            {
                //error
            }
            else
            {
                string orderid = TextBoxorderid.Text;
                orderidforsale = TextBoxorderid.Text;
                clsSalesData Dal = new clsSalesData();
                DataSet crsa = Dal.LoadSaleByID(username, solduser,orderid);

                if (crsa.Tables[0].Rows.Count != 0)
                {

                    LoadPreSaledataford();
                    LoadPrepaid(orderid);
                    hideallcolapse();
                }
                else
                {
                    Random rnd = new Random();
                    int spcnum = rnd.Next(1, 1000000);
                    clsSalesData Dal2 = new clsSalesData();
                    Dal2.insertoredertosell(orderid, username, solduser, spcnum);
                    LoadGridFromSaletbl();
                    LoadPrepaid(orderid);
                    // LoadSaleGrid(orderid);
                    //load to grid order list with name, size using orderid
                    //load total prices of orders
                    //load remainng amt from ordertprice 
                    //  clearaftersale();

                    hideallcolapse();
                }
               
            }
           
        }

        private void LoadPreSaledataford()
        {
            clsSalesData Dal = new clsSalesData();
            DataSet pro = Dal.LoadPreSaledata(username, solduser);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewSaleitemlst.DataSource = pro.Tables[0];
                GridViewSaleitemlst.DataBind();
                decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CurrentCost"));
                totalsaleor = (GridViewSaleitemlst.DataSource as DataTable).Rows.Count;
                GridViewSaleitemlst.FooterRow.Cells[5].Text = "Total";
                GridViewSaleitemlst.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                GridViewSaleitemlst.FooterRow.Cells[6].Text = totaloprice.ToString("N2");
                LabelSaleprice.Text = Convert.ToString(totaloprice);
            }
            else
            {


            }
        }

        private void LoadPrepaid(string orderid)
        {
            clsOrderTPrice Dal = new clsOrderTPrice();
            DataSet ds = Dal.FindPrePaid(orderid);
            if (ds.Tables[0].Rows.Count != 0)
            {
                
                decimal prepaid = Convert.ToDecimal((ds.Tables[0].Rows[0]["PrePaidPamount"]).ToString());
                decimal firt = prepaid + Convert.ToDecimal(Labelprepaid.Text);
                Labelprepaid.Text = Convert.ToString(firt);
            }
            else
            {

            }
        }

        private void LoadGridFromSaletbl()
        {

            clsSalesData Dal = new clsSalesData();
            DataSet pro = Dal.LoadPreSaledata(username,solduser);

            if (pro.Tables[0].Rows.Count != 0) 
            {

                GridViewSaleitemlst.DataSource = pro.Tables[0];
                GridViewSaleitemlst.DataBind();
               decimal totaloprice = pro.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CurrentCost"));
                 totalsale = (GridViewSaleitemlst.DataSource as DataTable).Rows.Count;
                GridViewSaleitemlst.FooterRow.Cells[5].Text = "Total";
                GridViewSaleitemlst.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                GridViewSaleitemlst.FooterRow.Cells[6].Text = totaloprice.ToString("N2");
                LabelSaleprice.Text = Convert.ToString(totaloprice);
            }
            else
            {


            }
        }
        private void LoadSaleGrid(string orderid)
        {
            clsSalesData Dal = new clsSalesData();
            DataSet pro = Dal.LoadOrderProductDetail(orderid);

            if (pro.Tables[0].Rows.Count != 0)
            {

                GridViewSaleitemlst.DataSource = pro.Tables[0];
                GridViewSaleitemlst.DataBind();
              
            }
            else
            {


            }
        }

        protected void addsersale(object sender, EventArgs e)
        {
            if(TextBoxlength.Text=="" || TextBoxqty.Text == "" || TextBoxserviceprice.Text == "" || DropDownListsertype.SelectedValue=="0" || DropDownListser.SelectedValue=="0")
            {
                //error
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(TextBoxnewseruprice.Text))
                {
                    decimal newprice = Convert.ToDecimal(TextBoxnewseruprice.Text);
                    decimal unitprice = Convert.ToDecimal(TextBoxserviceprice.Text);
                    if (newprice > unitprice)
                    {
                        UnitPriceser = Convert.ToDecimal(TextBoxnewseruprice.Text);
                    }
                    else
                    {
                        UnitPriceser = Convert.ToDecimal(TextBoxserviceprice.Text);

                    }
                }
                else
                {
                    UnitPriceser = Convert.ToDecimal(TextBoxserviceprice.Text);

                }
                decimal len = Convert.ToDecimal(TextBoxlength.Text);
                //load to grid order list with name, width,length qty pricetotal using orderid
                string ProductName = DropDownListser.SelectedItem.ToString();
                string MaterialUsed = DropDownListsertype.SelectedItem.ToString();
                string MaterialSize = "";
                decimal Quan = Convert.ToDecimal(TextBoxqty.Text);
               // decimal UnitPrice = Convert.ToDecimal(TextBoxserviceprice.Text);
                decimal CurrentCost = Quan * UnitPriceser * len;
                string TransactionType = "FOD";
                string Protype = "Service";
                Random rnd = new Random();
                int spcnum = rnd.Next(1, 1000000);
               // order.spcificid = spcnum;
                //load to grid order list with name, width,length qty pricetotal using orderid

                //AddpremanSaleData(DropDownListpreman.SelectedItem.ToString(), TextBoxpreproqty.Text, TextBoxunitprice.Text, TextBoxtotprice.Text;)

                clsSalesData Dal = new clsSalesData();
                Dal.AddPManProSale(ProductName, MaterialUsed, MaterialSize, Quan, UnitPriceser, CurrentCost, TransactionType, Protype, username,solduser, spcnum);
                //  GridViewSaleitemlst.DataSource = null;
                hideallcolapse();
                clearaftersale();
                LoadGridFromSaletbl();
            }
           
        }

        protected void showserviceprice(object sender, EventArgs e)
        {
            
            string proname = DropDownListser.SelectedItem.ToString();
            if(DropDownListsertype.SelectedValue=="0")
            {
                //error
            }
           else
            {
               string  sertype = DropDownListsertype.SelectedItem.ToString();
                clsService Dal2 = new clsService();
                DataSet ds2 = Dal2.FindServiceSalePrice(proname, sertype);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ServiceUnitprice"]).ToString());
                    TextBoxserviceprice.Text = Convert.ToString(unitpriceofser);
                }
                else
                {
                    TextBoxserviceprice.Text = "0";
                }
            }
           
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";

            collapseFive.Attributes["class"] = "collapse show";

        }

        protected void showproductprice(object sender, EventArgs e)
        {
            if(DropDownListpmbrand.SelectedValue=="0" || DropDownListpmgage.SelectedValue=="0" || DropDownListpreman.SelectedValue !="0")
            {
                string proname = DropDownListpreman.SelectedItem.ToString();
                //show preman unit price
                clsProduct Dal2 = new clsProduct();
                DataSet ds2 = Dal2.FindPricepreman(proname);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["MatNeed"]).ToString());


                    TextBoxunitprice.Text = Convert.ToString(unitpriceofser);
                }
                else
                {

                }
            }
            else
            {
                
                

            }
            
          

            collapseTwo.Attributes["class"] = "collapse show";
            collapseFour.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void createsale(object sender, EventArgs e)
        {
            if(GridViewSaleitemlst.Rows.Count==0 || DropDownListpaymenttype.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxSalesID.Text))
            {
                //error
            }
            // string saleby = Session["UserName"].ToString();
            // string transtype = "Sold";
            else
            {
                if (DropDownListpaymenttype.SelectedValue == "0")
                {
                    //error
                }
                else if(DropDownListpaymenttype.SelectedValue == "Credit")
                {
                    CreditApproved = "NO";
                }
                else if (DropDownListpaymenttype.SelectedValue != "0" && DropDownListpaymenttype.SelectedValue != "Credit")
                {
                    CreditApproved = "YES";
                }

                int saleitemno = GridViewSaleitemlst.Rows.Count;
               
                if (CheckBoxattach.Checked == true)
                {
                    notevat = "YES";
                }
                else
                {
                    notevat = "NO";
                }
                decimal newaddrev =0;
               
                               
                clsSalesData lp = new clsSalesData();
                DataSet lpds = lp.SelectSaleLargePrice(solduser);
                if (lpds.Tables[0].Rows.Count != 0)
                {
                   
                    string custname = TextBoxcusname.Text;
                    string transacct = TextBoxacctno.Text;
                    string cusphone = TextBoxcusphone.Text;
                    // decimal prepaid = Convert.ToDecimal(Labelprepaid.Text);
                    qtyord = lpds.Tables[0].Rows.Count;
                    prepaid = Convert.ToDecimal(Labelprepaid.Text);
                    preamount = prepaid / qtyord;
                  
                    decimal addrevs = newaddrev / qtyord;
                    //  DateTime datesa = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", CultureInfo.InvariantCulture);
                    //string date4 = DateTime.Now.ToShortDateString();
                    // DateTime datesale = DateTime.Now.Date;

                    //string toDate = DateTime.Now.ToShortDateString();
                    //System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                    //dateInfo.ShortDatePattern = "yyyy/MM/dd";
                    //DateTime datesale = Convert.ToDateTime(toDate, dateInfo);
                    string datesale = TextBoxSalesDate.Text;
                    string saleid = TextBoxSalesID.Text;
                    string paymenttype = DropDownListpaymenttype.SelectedItem.ToString();
                    //create new sale
                    clsSalesData Dal2 = new clsSalesData();
                    Dal2.SetSaleByAndTransType(username, datesale, saleid, preamount, notevat, paymenttype, custname,cusphone,transacct,CreditApproved,solduser,addrevs);
                }
                else
                {
                    
                    clsSalesData Dal = new clsSalesData();
                    DataSet pro = Dal.LoadPreSaledata(username, solduser);

                    if (pro.Tables[0].Rows.Count != 0)
                    {

                       
                       decimal totalsales = pro.Tables[0].Rows.Count;
                        addrev = newaddrev / totalsales;
                    }
                    else
                    {


                    }
                    string custname = TextBoxcusname.Text;
                    string transacct = TextBoxacctno.Text;
                    string cusphone = TextBoxcusphone.Text;
                    preamount = 0;
                  //  int totalsale = (GridViewSaleitemlst.DataSource as DataTable).Rows.Count;
                   
                    //  DateTime datesa = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "d/MM/yyyy", null);
                    //string date4 = DateTime.Now.ToShortDateString();
                    // DateTime datesale = DateTime.Now.Date;
                    string datesale = TextBoxSalesDate.Text;
                    //string toDate = DateTime.Now.ToShortDateString();
                    //System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                    //dateInfo.ShortDatePattern = "yyyy/MM/dd";
                    //DateTime datesale = Convert.ToDateTime(toDate, dateInfo);
                    string saleid = TextBoxSalesID.Text;
                    string paymenttype = DropDownListpaymenttype.SelectedItem.ToString();

                    //create new sale
                    clsSalesData Dal2 = new clsSalesData();
                    Dal2.SetSaleByAndTransType(username, datesale, saleid, preamount, notevat, paymenttype, custname, cusphone, transacct, CreditApproved,solduser,addrev);
                }

            
                foreach (GridViewRow row in GridViewSaleitemlst.Rows)

                {

                    for (int i = 0; i < GridViewSaleitemlst.Columns.Count; i++)
                    {


                        string proname = Convert.ToString(row.Cells[1].Text);
                        decimal quantity = Convert.ToDecimal(row.Cells[4].Text);
                        string protype = Convert.ToString(row.Cells[7].Text);
                        string progage = Convert.ToString(row.Cells[2].Text);
                        clsProduct Dal = new clsProduct();
                        Dal.UpdatePreManProQty(proname, progage, username, quantity, protype);
                      
                    }

                }


                GridViewSaleitemlst.DataSource = null;
                GridViewSaleitemlst.DataBind();

                if (!string.IsNullOrWhiteSpace(TextBoxorderid.Text))
                {
                    string orderidfor = TextBoxorderid.Text;
                    clsSalesData Dal = new clsSalesData();
                    Dal.UpdateOrderTransType(orderidfor);
                }
                else
                {


                }

                Labelamount.Text = "0";
                Labelprepaid.Text = "0";
                LabelSaleprice.Text = "0";

                clearafteraddsale();
                clearaftersale();

            }


        }

        private void clearaftersale()
        {
            TextBoxSalesID.Text = "";
            TextBoxlength.Text = "";
            TextBoxorderid.Text = "";
            TextBoxpreproqty.Text = "";
            TextBoxqty.Text = "";
            TextBoxserviceprice.Text = "";
            TextBoxunitprice.Text = "";
            TextBoxrmlength.Text = "";
            TextBoxrmqty.Text = "";
            TextBoxrmwidth.Text = "";
            TextBoxrmunitprice.Text = "";
            TextBoxacctno.Text = "";
            TextBoxcusname.Text = "";
            TextBoxcusphone.Text = "";
            DropDownListpaymenttype.SelectedValue = "0";

        }

        protected void generatesaleid(object sender, EventArgs e)
        {
            //generatesaleid

            var date = DateTime.UtcNow.AddHours(9).ToShortDateString();

            var guid = Guid.NewGuid().ToString().Substring(0, 4);
            string uniqueid = date.ToString() + '-' + guid;

            TextBoxSalesID.Text = "Sale" + '-' + uniqueid;
          
        }

        protected void enableproser(object sender, EventArgs e)
        {

        }

        protected void addpurchasesale(object sender, EventArgs e)
        {
            if(DropDownListselltype.SelectedValue == "0"|| DropDownListpurprolst.SelectedValue=="0" || TextBoxpurqty.Text=="" || TextBoxpurunitprice.Text=="")
            {
                //error
            }
            else
            {

                if (!string.IsNullOrWhiteSpace(TextBoxnewpuruprice.Text))
                {
                    decimal newprice = Convert.ToDecimal(TextBoxnewpuruprice.Text);
                    decimal unitprice = Convert.ToDecimal(TextBoxpurunitprice.Text);
                    if (newprice > unitprice)
                    {
                        UnitPricepur = Convert.ToDecimal(TextBoxnewpuruprice.Text);
                    }
                    else
                    {
                        UnitPricepur = Convert.ToDecimal(TextBoxpurunitprice.Text);
                    }
                }
                else
                {
                    UnitPricepur = Convert.ToDecimal(TextBoxpurunitprice.Text);

                }
                // decimal len = Convert.ToDecimal(TextBoxlength.Text);
                //load to grid order list with name, width,length qty pricetotal using orderid
                string ProductName = DropDownListpurprolst.SelectedItem.ToString();
                string MaterialUsed = DropDownListselltype.SelectedItem.ToString();
                string MaterialSize = "";
                decimal Quantity = Convert.ToDecimal(TextBoxpurqty.Text);
               // decimal UnitPrice = Convert.ToDecimal(TextBoxpurunitprice.Text);
                decimal CurrentCost = Quantity * UnitPricepur;
                string TransactionType = "FOD";
                string Protype = "Purchase";
                Random rnd = new Random();
                int spcnum = rnd.Next(1, 1000000);
                clsSalesData Dal = new clsSalesData();
                Dal.AddPManProSale(ProductName, MaterialUsed, MaterialSize, Quantity, UnitPricepur, CurrentCost, TransactionType, Protype, username,solduser, spcnum);
               
                //  GridViewSaleitemlst.DataSource = null;
                LoadGridFromSaletbl();
                hideallcolapse();
                clearaftersale();
            }
          
           
        }

        private void clearafteraddsale()
        {
            DropDownListpurprolst.SelectedValue = "0"; 

            DropDownListpreman.SelectedValue = "0";

            DropDownListselltype.SelectedValue = "0";
            DropDownListbrand.SelectedValue = "0";
            DropDownListgage.Items.Clear();
        }

        protected void showpurproprice(object sender, EventArgs e)
        {
            if(DropDownListpurprolst.SelectedValue=="0")
            {
                //error
            }
         else
            {
                if(DropDownListselltype.SelectedValue=="0")
                {
                    //error
                }
                else
                {
                    string proname = DropDownListpurprolst.SelectedItem.ToString();
                    string selltype = DropDownListselltype.SelectedItem.ToString();
                    //show preman unit price
                    clsProduct Dal2 = new clsProduct();
                    DataSet ds2 = Dal2.FindPricePuchase(proname, selltype);
                    if (ds2.Tables[0].Rows.Count != 0)
                    {

                        decimal unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ProductUnitPrice"]).ToString());


                        TextBoxpurunitprice.Text = Convert.ToString(unitpriceofser);
                    }
                    else
                    {

                    }
                    collapseTwo.Attributes["class"] = "collapse";
                    collapseFour.Attributes["class"] = "collapse show";
                    collapseThree.Attributes["class"] = "collapse";

                    collapseFive.Attributes["class"] = "collapse";
                }
            }
          
        }

        protected void showsersale(object sender, EventArgs e)
        {
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";

            collapseFive.Attributes["class"] = "collapse show";
        }
        protected void hideallcolapse()
        {
            
            decimal sale = Convert.ToDecimal(LabelSaleprice.Text);
            decimal prepaid = Convert.ToDecimal(Labelprepaid.Text);
            decimal tot = sale - prepaid;
            Labelamount.Text = Convert.ToString(tot);
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void HideOneColumn(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;

            //if (GridView1.Columns.Count > 0)
            //    GridView1.Columns[0].Visible = false;
            //elsee .Row.Cells.Count - 1
            //{
            //    GridView1.HeaderRow.Cells[0].Visible = false;
            //    foreach (GridViewRow gvr in GridView1.Rows)
            //    {
            //        gvr.Cells[0].Visible = false;
            //    }
            //}


            //if ((e.Row.RowType == DataControlRowType.Header))
            //{
            //    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
            //    foreach (GridViewRow row in GridViewSaleitemlst.Rows)
            //    {

            //        GridViewSaleitemlst.Rows[7].Visible = false;
            //    };
            //    // For setting the width of first column to 100px
            //    //TableCell cell = e.Row.Cells[1];
            //    ////GridViewRecAssignOrder.Columns[2].ItemStyle.Width = 400;
            //    //cell.Width = new Unit("530px");


            //    //GridViewSaleitemlst.Columns[5].Visible = false;

            //}
        }

        protected void addrowmatsale(object sender, EventArgs e)
        {
          if(TextBoxrmwidth.Text ==""|| TextBoxrmlength.Text ==""|| DropDownListbrand.SelectedValue=="0"|| DropDownListgage .SelectedValue=="0"|| TextBoxrmqty.Text=="" || TextBoxrmunitprice.Text=="")
            {
                //error
            }
          else
            {
                if (!string.IsNullOrWhiteSpace(TextBoxnewrmuprice.Text))
                {
                    decimal newprice = Convert.ToDecimal(TextBoxnewrmuprice.Text);
                    decimal unitprice = Convert.ToDecimal(TextBoxrmunitprice.Text);
                    if (newprice > unitprice)
                    {
                        UnitPricerm = Convert.ToDecimal(TextBoxnewrmuprice.Text);
                    }
                    else
                    {
                        UnitPricerm = Convert.ToDecimal(TextBoxrmunitprice.Text);
                    }
                }
                else
                {
                    UnitPricerm = Convert.ToDecimal(TextBoxrmunitprice.Text);

                }
                decimal width = Convert.ToDecimal(TextBoxrmwidth.Text);
                decimal length = Convert.ToDecimal(TextBoxrmlength.Text);
                decimal r1 = Convert.ToDecimal(0.33);
                decimal r2 = Convert.ToDecimal(0.67);
                decimal arearm;
                if (r1 == width)
                {
                    UnitPricerm = UnitPricerm * 1/3 ;
                }
                else if(r2 == width)
                {
                    UnitPricerm = UnitPricerm * 2 / 3 ;
                }
                else
                {
                    UnitPricerm = UnitPricerm * width;
                }
               
                string ProductName = DropDownListbrand.SelectedItem.ToString();
                string MaterialUsed = DropDownListgage.SelectedItem.ToString();
                string MaterialSize = TextBoxrmwidth.Text + "X" + TextBoxrmlength.Text;
                decimal Quantity = Convert.ToDecimal(TextBoxrmqty.Text)  * width * length;
               // decimal UnitPrice = Convert.ToDecimal(TextBoxrmunitprice.Text);
                decimal CurrentCost = length * UnitPricerm * Convert.ToDecimal(TextBoxrmqty.Text);
                string TransactionType = "FOD";
                string Protype = "RMaterial";
                Random rnd = new Random();
                int spcnum = rnd.Next(1, 1000000);
                clsSalesData Dal = new clsSalesData();
                Dal.AddPManProSale(ProductName, MaterialUsed, MaterialSize, Quantity, UnitPricerm, CurrentCost, TransactionType, Protype, username,solduser, spcnum);
                hideallcolapse();
                clearaftersale();
                LoadGridFromSaletbl();
            }
        
        }

        protected void showmaterialprice(object sender, EventArgs e)
        {
            if (DropDownListbrand.SelectedValue == "0" || DropDownListgage.SelectedValue == "0")
            {

            }
            else
            {
                string probrand = DropDownListbrand.SelectedItem.ToString();
                string progage = DropDownListgage.SelectedItem.ToString();
                clsProduct Dal = new clsProduct();
                DataSet ds = Dal.FindPricerowmat(probrand, progage, username);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    unitpriceofpro  = Convert.ToDecimal((ds.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                   // TextBoxrmunitprice.Text = Convert.ToString(unitpriceofpro);
                }
                else
                {

                }
                string sername = "CutRow";
                clsService Dal2 = new clsService();
                DataSet ds2 = Dal2.FindServicePrice(sername);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ServiceUnitprice"]).ToString());

                }
                else
                {
                    unitpriceofser = 0;
                }

                decimal totalseproprice = unitpriceofpro + unitpriceofser;
                TextBoxrmunitprice.Text = Convert.ToString(totalseproprice);
            }

         
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse show";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void showrmgage(object sender, EventArgs e)
        {
           string brand = DropDownListbrand.SelectedItem.ToString();
            loadallgages(brand);
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse show";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void viewdtlsaledtal(object sender, EventArgs e)
        {
            GridViewRow row = GridViewcrdsaleList.SelectedRow;
           
           
           TextBoxcerdsaleid.Text = row.Cells[1].Text;
            TextBoxcdtsaledt.Text = row.Cells[2].Text;
            TextBoxcrdcusname.Text = row.Cells[3].Text;
          
            TextBoxcrdphono.Text = row.Cells[4].Text;

          

            string saleref = TextBoxcerdsaleid.Text;
            clsSalesData Dal = new clsSalesData();
            DataSet crsa = Dal.LoadCrediSaleTotAmount(username,saleref);

            if (crsa.Tables[0].Rows.Count != 0)
            {

                decimal totalamount = Convert.ToDecimal((crsa.Tables[0].Rows[0][0]));
                totalamount = Math.Round(totalamount, 2);
                TextBoxcrdtamount.Text = Convert.ToString(totalamount);


            }
        }

        protected void showdailysale(object sender, EventArgs e)
        {
           
            creditsale.Style["visibility"] = "hidden";
            creditsale.Style["display"] = "none";
            dailysale.Style["visibility"] = "visible";
            dailysale.Style["display"] = "block";
            showsalelist.Style["visibility"] = "hidden";
            showsalelist.Style["display"] = "none";
        }

        protected void showtcreditsale(object sender, EventArgs e)
        {
            crbanktrans.Style["visibility"] = "hidden";
            crbanktrans.Style["display"] = "none";
            dailysale.Style["visibility"] = "hidden";
            dailysale.Style["display"] = "none";
            creditsale.Style["visibility"] = "visible";
            creditsale.Style["display"] = "block";
            showsalelist.Style["visibility"] = "hidden";
            showsalelist.Style["display"] = "none";
        }

      

        protected void newcreditsalelist(object sender, GridViewPageEventArgs e)
        {


            GridViewcrdsaleList.PageIndex = e.NewPageIndex;
            Loadallcreditsales();
        }

        protected void UpdateSaleCredit(object sender, EventArgs e)
        {
            if(DropDownListnewpaytype.SelectedValue=="0")
            {

            }
            else
            {
                string salref = TextBoxcerdsaleid.Text;
                string paytype = DropDownListnewpaytype.SelectedItem.ToString();
                string toacct = TextBoxcrdeditbankno.Text;

                string saledate = DateTime.UtcNow.AddHours(6).ToShortDateString();
                if (CheckBoxcrdtsale.Checked == true)
                {
                    notevat = "Yes";

                }
                else
                {
                    notevat = "No";
                }
                clsSalesData Dal = new clsSalesData();
                Dal.UpdateOrderTransType(salref, paytype, toacct, notevat, saledate, solduser);

                clearafercredittrans();
            }
            
        }

        private void clearafercredittrans()
        {
            TextBoxcdtsaledt.Text = "";
            TextBoxcerdsaleid.Text = "";
            TextBoxcrdphono.Text = "";
            TextBoxcrdtamount.Text = "";
            TextBoxcrdeditbankno.Text = "";
            TextBoxcrdcusname.Text = "";
            DropDownListcrdbankname.SelectedValue = "0";
            DropDownListnewpaytype.SelectedValue = "0";

            crbanktrans.Style["visibility"] = "hidden";
            crbanktrans.Style["display"] = "none";
        }

        protected void showcreditbankacct(object sender, EventArgs e)
        {
            if(DropDownListcrdbankname.SelectedValue=="0" || DropDownLiholrname.SelectedValue == "0")
            {

            }
            else
            {
                string bankname = DropDownListcrdbankname.SelectedItem.ToString();
                string holder = DropDownLiholrname.SelectedItem.ToString();

                clsBankAccount Dal = new clsBankAccount();
                DataSet ba = Dal.LoadBankAcctnoBNHN(bankname, holder);
                if (ba.Tables[0].Rows.Count != 0)
                {


                    TextBoxcrdeditbankno.Text = (ba.Tables[0].Rows[0][0]).ToString();
                    // TextBoxamount.Text = Labelcashathand.Text;
                }
                else
                {

                }
            }
          
         
        }

        protected void showcrdbanktrans(object sender, EventArgs e)
        {
            string paytype = DropDownListnewpaytype.SelectedItem.ToString();
            if (paytype == "Bank Transfer")
            {
                crbanktrans.Style["visibility"] = "visible";
                crbanktrans.Style["display"] = "block";
            }
            else
            {
                crbanktrans.Style["visibility"] = "hidden";
                crbanktrans.Style["display"] = "none";
            }
        }

        protected void showcreditbaccthoder(object sender, EventArgs e)
        {
            if(DropDownListcrdbankname.SelectedValue=="0")
            {

            }
            else
            {
                string bankname = DropDownListcrdbankname.SelectedItem.ToString();
                clsBankAccount Dal = new clsBankAccount();
                DataSet ba = Dal.LoadBankBankBraAcct(bankname);

                DropDownLiholrname.DataSource = ba.Tables[0];

                DropDownLiholrname.DataTextField = "HolderName";
                DropDownLiholrname.DataValueField = "HolderName";

                DropDownLiholrname.DataBind();
                //DropDownLiholrname.Items.Insert(0, "--የባለቤት ስም ምረጥ--");
                DropDownLiholrname.Items[0].Value = "0";
            }
          
        }

        protected void showpmproprice(object sender, EventArgs e)
        {
            if (DropDownListpmbrand.SelectedValue == "0" || DropDownListpreman.SelectedValue == "0" || string.IsNullOrWhiteSpace(TextBoxpmwidth.Text) || DropDownListpmgage.SelectedValue == "0")
            {

            }
            else
            {
                pmproname = DropDownListpreman.SelectedItem.ToString();
                
                string probrand = DropDownListpmbrand.SelectedItem.ToString();
                string progage = DropDownListpmgage.SelectedItem.ToString();
                clsProduct Dal2 = new clsProduct();
                DataSet ds2 = Dal2.FindPricepreman(pmproname);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal matneedpmp = Convert.ToDecimal((ds2.Tables[0].Rows[0]["MatNeed"]).ToString());

                    if (matneedpmp == 0)
                    {

                        double pmprowidth = Convert.ToDouble(TextBoxpmwidth.Text);
                        clsProduct Dal4 = new clsProduct();
                        DataSet ds4 = Dal4.FindPricerowmat(probrand, progage,username);
                        if (ds4.Tables[0].Rows.Count != 0)
                        {
                            
                            unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                            if (pmprowidth <= 0.33)
                            {
                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.05);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxunitprice.Text = Convert.ToString(totalseproprice);
                            }
                            else if (pmprowidth <= 0.67)
                            {

                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.02);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxunitprice.Text = Convert.ToString(totalseproprice);
                            }

                            else if (pmprowidth >= 1)
                            {

                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.05);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxunitprice.Text = Convert.ToString(totalseproprice);
                            }
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }

                    }
                    else
                    {
                        TextBoxpmwidth.Text = Convert.ToString(matneedpmp);
                        TextBoxpmlength.Visible = false;
                        clsProduct Dal4 = new clsProduct();
                        DataSet ds4 = Dal4.FindPricerowmat(pmpbrand, pmpgage, username);
                        if (ds4.Tables[0].Rows.Count != 0)
                        {

                            unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                            decimal totalpmpwitmnd = unitprice * matneedpmp;
                            TextBoxunitprice.Text = Convert.ToString(totalpmpwitmnd);
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }
                        
                    }

                }
                else
                {

                }

               


            }



            collapseTwo.Attributes["class"] = "collapse show";
            collapseFour.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void loadacctholdersale(object sender, EventArgs e)
        {
            if (DropDownListbankname.SelectedValue == "0")
            {
               

            }
            else
            {
                string bankname = DropDownListbankname.SelectedItem.ToString();
                clsBankAccount Dal = new clsBankAccount();
                DataSet ba = Dal.LoadBankBankBraAcct(bankname);

                DropDownLisalebkhona.DataSource = ba.Tables[0];

                DropDownLisalebkhona.DataTextField = "HolderName";
                DropDownLisalebkhona.DataValueField = "HolderName";

                DropDownLisalebkhona.DataBind();
                DropDownLisalebkhona.Items.Insert(0, "--የባለቤት ስም ምረጥ--");
                DropDownLisalebkhona.Items[0].Value = "0";
            }
        }

        protected void stayonpprosale(object sender, EventArgs e)
        {
            collapseTwo.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse show";
            collapseThree.Attributes["class"] = "collapse";

            collapseFive.Attributes["class"] = "collapse";
        }

        protected void print(object sender, EventArgs e)
        {
            clsRMRequest ObjDal = new clsRMRequest();
            DateTime fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            DateTime todt = Convert.ToDateTime(TextBoxtodt.Text);
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
        
            if (TextBoxfromdt.Text == "" || TextBoxtodt.Text == "")
            {
                //error msg

            }
            else
            {

                fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
                todt = Convert.ToDateTime(TextBoxtodt.Text);

                // string record = ConfigurationManager.AppSettings["UserRecord"];
                // string RecordPageNumber = ConfigurationManager.AppSettings["PageNumber"];
                try
                {

                    int PageNumber = 0;
                    // string filename = Server.MapPath("UserDataSheet");
                    string filename = "SalesList" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    //dt2 = ObjDal.ExportAllRMReq(fromdt, todt);LoadSaleAllBydt
                   
                    dt2 = ObjDal.ExportAllSales(fromdt, todt, orderby, sentby);

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
            }
        }

        protected void TextBoxnewpmprice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void showdailylist(object sender, EventArgs e)
        {
            creditsale.Style["visibility"] = "hidden";
            creditsale.Style["display"] = "none";
            dailysale.Style["visibility"] = "hidden";
            dailysale.Style["display"] = "none";
            showsalelist.Style["display"] = "block";
            showsalelist.Style["visibility"] = "visible";
        }

        protected void newsalelistpage(object sender, GridViewPageEventArgs e)
        {

            GridViewsalelst.PageIndex = e.NewPageIndex;
            loadsalelist();
        }

        protected void searchsalelst(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxfromdt.Text) && !string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                loadsalelist();
            }
            else
            {
                //error
            }
        }

        private void loadsalelist()
        {
            DateTime fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            DateTime todt = Convert.ToDateTime(TextBoxtodt.Text);
            string soldby = Session["UserName"].ToString();
            string soldusr = Session["UserBy"].ToString();
            clsSalesData Dal = new clsSalesData();
            DataSet Order = Dal.LoadSaleAllBydt(fromdt, todt, soldby, soldusr);

            if (Order.Tables[0].Rows.Count != 0)
                
            {
               
                decimal sale = Order.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CurrentCost"));
                decimal  ordiscount = Order.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("Discount"));
               
                decimal totalsale = sale - ordiscount;
                string saleamt = Convert.ToString(totalsale);
                
                GridViewsalelst.DataSource = Order.Tables[0];
                GridViewsalelst.DataBind();
                Labeltotalorder.Text = (GridViewsalelst.DataSource as DataTable).Rows.Count.ToString() +"," + saleamt;
            }
        }

        protected void showbanktrans(object sender, EventArgs e)
        {
            hideallcolapse();
            string paytype = DropDownListpaymenttype.SelectedItem.ToString();
            if (paytype == "Bank Transfer")
            {
                banktrans.Style["visibility"] = "visible";
                banktrans.Style["display"] = "block";
            }
            else
            {
                banktrans.Style["visibility"] = "hidden";
                banktrans.Style["display"] = "none";
            }
        }

        protected void showacctno(object sender, EventArgs e)
        {
            string bankname = DropDownListbankname.SelectedItem.ToString();

           
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankAcctno(bankname);
            if (ba.Tables[0].Rows.Count != 0)
            {


                TextBoxacctno.Text = (ba.Tables[0].Rows[0][0]).ToString();
               // TextBoxamount.Text = Labelcashathand.Text;
            }
            else
            {

            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        protected void showpmgage(object sender, EventArgs e)
        {
            if (DropDownListpmbrand.SelectedValue != "0")
            {
                string brand = DropDownListpmbrand.SelectedItem.ToString();
                DropDownListpmgage.Items.Clear();
                clsProduct Dal = new clsProduct();
                DataSet progage = Dal.FillProGage(brand);
                DropDownListpmgage.DataTextField = "ProductGage";
                DropDownListpmgage.DataValueField = "ProductGage";
                DropDownListpmgage.DataSource = progage.Tables[0];
                DropDownListpmgage.DataBind();
                DropDownListpmgage.Items.Insert(0, "-- Select Product Gage--");
                DropDownListpmgage.Items[0].Value = "0";
            }
            else
            {

            }

            collapseTwo.Attributes["class"] = "collapse show";
            collapseFour.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";
            collapseFive.Attributes["class"] = "collapse";
        }
         
        protected void showpmmatprice(object sender, EventArgs e)
        {
            //if(DropDownListpmbrand.SelectedValue=="0" || DropDownListpmgage.SelectedValue=="0")
            //{

            //}
            // else
            //{
            //    if (DropDownListpreman.SelectedValue == "0" )
            //    {
                 
            //    }
            //    else
            //    {
            //        pmproname = DropDownListpreman.SelectedItem.ToString();
            //    }
            //    string probrand = DropDownListpmbrand.SelectedItem.ToString();
            //    string progage = DropDownListpmgage.SelectedItem.ToString();
            //    clsProduct Dal2 = new clsProduct();
            //    DataSet ds2 = Dal2.FindPricepreman(pmproname);
            //    if (ds2.Tables[0].Rows.Count != 0)
            //    {

            //        decimal matneedpmp = Convert.ToDecimal((ds2.Tables[0].Rows[0]["MatNeed"]).ToString());

            //        if (matneedpmp == 0)
            //        {
                     
            //            double pmprowidth = Convert.ToDouble(pmwidth);
            //            clsProduct Dal4 = new clsProduct();
            //            DataSet ds4 = Dal4.FindPricerowmat(pmpbrand, pmpgage);
            //            if (ds4.Tables[0].Rows.Count != 0)
            //            {

            //                unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
            //                if (pmprowidth <= 0.52)
            //                {
            //                    totalserpri = unitprice * Convert.ToDecimal(pmprowidth);
            //                    decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
            //                    decimal totalseproprice = totalse + totalserpri;
            //                    TextBoxunitprice.Text = Convert.ToString(totalseproprice);
            //                }
            //                else
            //                {

            //                    totalserpri = unitpriceofpro * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(0.7);
            //                    decimal totalse = unitpriceofpro * Convert.ToDecimal(pmprowidth);
            //                    decimal totalseproprice = totalse + totalserpri;
            //                    TextBoxunitprice.Text = Convert.ToString(totalseproprice);
            //                }
            //            }
            //            else
            //            {
            //                unitpriceofpro = 0;
            //            }

            //        }
            //        else
            //        {
            //            clsProduct Dal4 = new clsProduct();
            //            DataSet ds4 = Dal4.FindPricerowmat(pmpbrand, pmpgage);
            //            if (ds4.Tables[0].Rows.Count != 0)
            //            {

            //                unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());

            //            }
            //            else
            //            {
            //                unitpriceofpro = 0;
            //            }
            //            decimal totalpmpwitmnd = unitprice * matneedpmp;
            //            TextBoxunitprice.Text = Convert.ToString(totalpmpwitmnd);
            //        }

            //    }
            //    else
            //    {

            //    }

            //    //clsProduct Dal = new clsProduct();
            //    //DataSet ds = Dal.FindPricerowmat(probrand, progage);
            //    //if (ds.Tables[0].Rows.Count != 0)
            //    //{

            //    //     pmrmp = Convert.ToDecimal((ds.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());

            //    //}
            //    //else
            //    //{
            //    //    pmrmp = 0;
            //    //}
            //    //clsService Dal2 = new clsService();
            //    //DataSet ds2 = Dal2.FindServicePrice(pmproname);
            //    //if (ds2.Tables[0].Rows.Count != 0)
            //    //{

            //    //    pmpserp = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ServiceUnitprice"]).ToString());

            //    //}
            //    //else
            //    //{
            //    //    pmpserp = 0;
            //    //}

            //    //decimal totalseproprice = pmrmp + pmpserp;
            //    //TextBoxunitprice.Text = Convert.ToString(totalseproprice);


            //}



            collapseTwo.Attributes["class"] = "collapse show";
            collapseFour.Attributes["class"] = "collapse";
            collapseFour.Attributes["class"] = "collapse";
            collapseThree.Attributes["class"] = "collapse";
            collapseFive.Attributes["class"] = "collapse";
        }

        protected void deletewrongsell(object sender, EventArgs e)
        {

            GridViewRow row =  GridViewSaleitemlst.SelectedRow;
            string ProductName = row.Cells[1].Text.Replace("&nbsp;", "");
            string MaterialUsed = row.Cells[2].Text.Replace("&nbsp;", "");
            
            decimal Quantity = Convert.ToDecimal(row.Cells[4].Text);
            decimal UnitPrice = Convert.ToDecimal(row.Cells[5].Text);
            decimal CurrentCost = Convert.ToDecimal(row.Cells[6].Text);
            string specificid = row.Cells[7].Text.Replace("&nbsp;", "");
            int Slid = Int32.Parse(specificid);

            clsSalesData dal = new clsSalesData();
            dal.DeleteWrongOrder(MaterialUsed, ProductName, Quantity, UnitPrice, CurrentCost, username,solduser, Slid);
            GridViewSaleitemlst.DataSource = null;
            GridViewSaleitemlst.DataBind();
            LoadGridFromSaletbl();

        }
    }
}