using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class SMorderedproduct : System.Web.UI.Page
    {
        clsOrder Dal = new clsOrder();
        public string type;
        public string size;
        public string name;
        public string day;
        public string brand;
        public string gage,acctno;

        decimal totaloprice, unitprice;
        decimal totalserpri;
        public decimal unitpriceofpro,addedprice;
           public decimal unitpriceofser;
        decimal prosize, qtyo, length;
        decimal prepaid, totalprice;
        decimal uprice;
        string protype;
       
        string probrand;
        string progage;
        string proname;
        string shopprice;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Sales Manager")
            {

                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();
                shopprice = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            // TextBoxorderdt.Text = DateTime.Now.AddHours(11).ToShortDateString();
            // Labelsession.Text = Session["UserName"].ToString();
            // TextBoxcusname.Text = DateTime.Now.ToString();
            TextBoxorderdt.Text = DateTime.UtcNow.AddHours(3).ToShortDateString();
            Labelalertonbtntopr.Text = "";

            Estimatetimetodeliver();
            if(!IsPostBack)
            {
                showaccttrans.Style["visibility"] = "hidden";
                showaccttrans.Style["display"] = "none";
                TextBoxcusname.Focus();
                loadbankname();
                loadinventorymanager();
            }
        }

        private void loadbankname()
        {
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankBankName();
            DropDownListbankname.DataTextField = "BankName";
            DropDownListbankname.DataValueField = "BankName";


            DropDownListbankname.DataSource = ba.Tables[0];
            DropDownListbankname.DataBind();
            DropDownListbankname.Items.Insert(0, "-- የባንክ ስም ምረጥ--");
            DropDownListbankname.Items[0].Value = "0";
        }

        private void loadinventorymanager()
        {
           
            clsUser Dal = new clsUser();
            DataSet probrand = Dal.FillUserName();
            DropDownLisinventmanlst.DataTextField = "AssignShop";
            DropDownLisinventmanlst.DataValueField = "AssignShop";
            DropDownLisinventmanlst.DataSource = probrand.Tables[0];
            DropDownLisinventmanlst.DataBind();
            DropDownLisinventmanlst.Items.Insert(0, "-- የዎርክ ሾፕ ምረጥ--");
            DropDownLisinventmanlst.Items[0].Value = "0";
        }

        private void LoadProductBrand()
        {
           
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListprobrand.DataTextField = "ProductBrand";
            DropDownListprobrand.DataValueField = "ProductBrand";
            DropDownListprobrand.DataSource = probrand.Tables[0];
            DropDownListprobrand.DataBind();
            DropDownListprobrand.Items.Insert(0, "-- የጥሬ ዕቃ ስም ምረጥ--");
            DropDownListprobrand.Items[0].Value = "0";
        }
        private void LoadProductGage(string brand)
        {
           
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListprogage.DataTextField = "ProductGage";
            DropDownListprogage.DataValueField = "ProductGage";
            DropDownListprogage.DataSource = progage.Tables[0];
            DropDownListprogage.DataBind();
            DropDownListprogage.Items.Insert(0, "--የጥሬ ዕቃ ጌጅ ምረጥ --");
            DropDownListprogage.Items[0].Value = "0";
        }
        private void LoadProductName(string type)
        {
         
            clsProduct Dal = new clsProduct();
            DataSet proname = Dal.FillProname(type);
            DropDownListproname.DataTextField = "ProductName";
            DropDownListproname.DataValueField = "ProductName";
            DropDownListproname.DataSource = proname.Tables[0];
            DropDownListproname.DataBind();
            DropDownListproname.Items.Insert(0, "-- የምርት ስም ምረጥ--");
            DropDownListproname.Items[0].Value = "0";
        }

        private void LoadProductShape()
        {
         
            clsProduct Dal = new clsProduct();
            DataSet proshape = Dal.FillProshape();
            DropDownListproshape.DataTextField = "ProductShape";
            DropDownListproshape.DataValueField = "ProductShape";


            DropDownListproshape.DataSource = proshape.Tables[0];
            DropDownListproshape.DataBind();
            DropDownListproshape.Items.Insert(0, "-- የምርት ቅርፅ ምረጥ--");
            DropDownListproshape.Items[0].Value = "0";
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }
        private Order InitalizeObject()
        {
            Order order = new Order();

            order.OrderId = TextBoxorderid.Text;

            order.CustomerName = TextBoxcusname.Text;
            order.CustomerPhone = TextBoxcusphone.Text;

            order.OrderDate = TextBoxorderdt.Text;
            DateTime a = Convert.ToDateTime(TextBoxrecdate.Text);
            
            order.DeliveryDate = a.ToShortDateString();

            order.ProductName = DropDownListproname.SelectedItem.ToString();
            if (DropDownListproshape.Enabled ==true && DropDownListproshape.SelectedValue !="0")
            {
                order.ProductShape = DropDownListproshape.SelectedItem.ToString() + "(" + TextBoxshpspecic.Text + ")";
            }
            else
            {
                order.ProductShape = null;
            }
            if (!string.IsNullOrWhiteSpace(TextBoxproductsize.Text))
            {
                order.ProductSize = Convert.ToDecimal(TextBoxproductsize.Text);
            }
            else
            {
                order.ProductSize = 1;
            }

            if (!string.IsNullOrWhiteSpace(TextBoxlen.Text))
            {
                order.Length = Convert.ToDecimal(TextBoxlen.Text);
            }
            else
            {
                order.Length = 1;
            }
            order.UnitPrice =Convert.ToDecimal(TextBoxuprice.Text);
            if (!string.IsNullOrWhiteSpace(TextBoxqty.Text))
            {
                order.Quantity = Convert.ToDecimal(TextBoxqty.Text);
            }
            else
            {
                order.Quantity = 1;
            }
            if (DropDownListprogage.Enabled==true && DropDownListprogage.SelectedValue != "0")
            {
                order.ProductGage = DropDownListprogage.SelectedItem.ToString();
            }
            else
            {
                order.ProductGage = null;
            }
            if (DropDownListprobrand.Enabled== true && DropDownListprobrand.SelectedValue != "0")
            {
                order.ProductBrand = DropDownListprobrand.SelectedItem.ToString();
            }
            else
            {
                order.ProductBrand = null;
            }
            order.CurrentCost = Convert.ToDecimal(TextBoxcurntprice.Text);


            order.OrderBy = Session["UserName"].ToString();
            order.SentBy = Session["UserBy"].ToString();
            if (DropDownList1.SelectedValue!="0" && DropDownList2.SelectedValue != "0" && DropDownList3.SelectedValue != "0" && DropDownList4.SelectedValue != "0" )
            {
                
                order.CoppingSize = "(" + "ሆድ" + DropDownList1.SelectedItem.ToString() + "ቋሚ" + DropDownList2.SelectedItem.ToString() + "ቀሪ" + DropDownList3.SelectedItem.ToString() + "ጭራ" + DropDownList4.SelectedItem.ToString()+")" ;
            }
            else
            {
                order.CoppingSize = null;
            }
            order.TransactionType = "O";
            order.OrderType = DropDownListprotype.SelectedItem.ToString();
            Random rnd = new Random();
            int spcnum = rnd.Next(1, 1000000);
            order.spcificid = spcnum;
            return order;
        }
        

        private void ClearAll()
        {
           
            TextBoxrecdate.Text = "";
           // TextBoxorderdt.Text = "";
            TextBoxcusname.Text = "";
            TextBoxcusphone.Text = "";
           
            TextBoxorderid.Text = "";
            DropDownList1.SelectedValue = "0";
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            DropDownList4.SelectedValue = "0";
            TextBoxlen.Text = "";
            DropDownListaccountno.Items.Clear();
            DropDownListtransfertype.SelectedValue = "0";
            TextBoxshpspecic.Text = "";
            DropDownLisinventmanlst.SelectedValue = "0";
            DropDownListproname.Items.Clear();
            DropDownListprotype.Enabled = false;
            DropDownListproshape.Items.Clear();
            TextBoxproductsize.Text = "";
            banktransfer.Style["visibility"] = "hidden";
            banktransfer.Style["display"] = "none";
            DropDownListprobrand.Items.Clear();
            DropDownListprogage.Items.Clear();
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
            string OrderId = TextBoxorderid.Text;
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadOrder(OrderId, orderby,sentby);
            GridView3.DataSource = Order.Tables[0];
            GridView3.DataBind();
            GridView3.DataSource = null;
            LoadGrid();

            TextBoxuprice.Text = "";
            TextBoxqty.Text = "";
          
            TextBoxprepaid.Text = "";
            TextBoxremainprice.Text = "";
            Labeltotalorderprice.Text = "";

            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";
        }

        
        private void LoadGrid()
        {

            string OrderId = TextBoxorderid.Text.ToString();
            FindOrderByOrderId(OrderId);
        }
        private void FindOrderByOrderId(string OrderId)
        {
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadOrder(OrderId, orderby,sentby);

            if (Order.Tables[0].Rows.Count != 0)
            {
                GridView3.DataSource = Order.Tables[0];
                GridView3.DataBind();
                totaloprice = Order.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("CurrentCost"));
                
                GridView3.FooterRow.Cells[6].Text = "Total";
                GridView3.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                GridView3.FooterRow.Cells[7].Text = totaloprice.ToString("N2");
                Labeltotalorderprice.Text = Convert.ToString(totaloprice);
            }
        }

        protected void Addorder(object sender, EventArgs e)
        {
           
            clsOrder Dal = new clsOrder();
            Order obj = InitalizeObject();
            Dal.AddNewOrder(obj);
           
            LoadGrid();

            clearAfterSave();
            Buttonaddorder.Visible = false;
            DropDownListprotype.Focus();
        }

        private void clearAfterSave()
        {
            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";
            // string ProductName;
            DropDownListproname.Items.Clear();
            DropDownListprobrand.Items.Clear();
            DropDownListprogage.Items.Clear();
            DropDownListproshape.Items.Clear();
            TextBoxshpspecic.Text = "";
            TextBoxproductsize.Text = "";
            
            TextBoxlen.Text = "";
            TextBoxproductsize.Visible=false;

            TextBoxlen.Visible = false;
            TextBoxuprice.Text = "";
            TextBoxqty.Text = "";
            DropDownList1.SelectedValue = "0";
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            DropDownList4.SelectedValue = "0";
            TextBoxcurntprice.Text = "";
            DropDownListprotype.SelectedValue = "0";
            DropDownListprotype.Focus();
            DropDownListproname.Enabled = false;
            DropDownListproshape.Enabled = false;
           
            DropDownListprobrand.Enabled = false;
            DropDownListprogage.Enabled = false;
        }

        protected void calculatepriceqty(object sender, EventArgs e)
        {
            if (TextBoxcusname.Text == "" || TextBoxcusphone.Text == "" || TextBoxorderid.Text == "" || TextBoxorderdt.Text == "" || TextBoxrecdate.Text == "")
            {

                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ኣስፈላጊ መረጃዎችን በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
         
            if (DropDownListproname.Enabled == false || DropDownListproname.SelectedValue == "0")
            {

                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት የምርት ስም በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            if (DropDownListprotype.Enabled == true && DropDownListprotype.SelectedValue == "0")
            {

                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት የምርት ኣይነት በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            if (string.IsNullOrWhiteSpace(TextBoxuprice.Text))
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ኣስፈላጊ መረጃዎችን በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {
                uprice = Convert.ToDecimal(TextBoxuprice.Text);
            }

            if (string.IsNullOrWhiteSpace(TextBoxproductsize.Text) )
            {
                prosize = 1;
              
            }
            else
            {
                 prosize = Convert.ToDecimal(TextBoxproductsize.Text);
              
            
            }
            if (string.IsNullOrWhiteSpace(TextBoxlen.Text))
            {
               
                length = 1;
            }
            else
            {
               
                length = Convert.ToDecimal(TextBoxlen.Text);

            }
            if (string.IsNullOrWhiteSpace(TextBoxqty.Text))
            {
                qtyo= 1;
                
            }
            else
            {
               qtyo= Convert.ToDecimal(TextBoxqty.Text);

            }
            
               
            if (!string.IsNullOrWhiteSpace(TextBoxnewpriceunit.Text))
            {
                decimal newprice = Convert.ToDecimal(TextBoxnewpriceunit.Text);
                decimal unitprice = Convert.ToDecimal(TextBoxuprice.Text);
                if(newprice > unitprice)
                {
                    addedprice = Convert.ToDecimal(TextBoxnewpriceunit.Text);
                }
                else
                {
                    addedprice = Convert.ToDecimal(TextBoxuprice.Text);
                }
            }
            else
            {
                addedprice = Convert.ToDecimal(TextBoxuprice.Text);

            }
            decimal total =  length * addedprice;

            decimal upriqty= total * qtyo;
            TextBoxcurntprice.Text = upriqty.ToString();
            Buttonaddorder.Visible= true;
        }
        protected void calculatetotaloprice(object sender, EventArgs e)
        {
            if(DropDownListtransfertype.SelectedValue=="0")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት የክፍያ አይነት  በትክክል ይምረጡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            if (string.IsNullOrWhiteSpace(TextBoxprepaid.Text))
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ኣስፈላጊ የቀብድ መጠን በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {
                prepaid = Convert.ToDecimal(TextBoxprepaid.Text);
               totalprice = Convert.ToDecimal(Labeltotalorderprice.Text);
            }
          
            if(prepaid > totalprice)
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት የቀብድ መጠን በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Labeltotalorderprice.Text))
                {
                    Labelalertonbtntopr.Visible = true;
                    Labelalertonbtntopr.Text = "እባኮዎት ትዕዛዝ በትክክል ያስገቡ።";
                    divMessage.Style["visibility"] = "visible";
                    divMessage.Style["display"] = "block";
                }
                else
                {
                    decimal remordprice = Convert.ToDecimal(Labeltotalorderprice.Text) - Convert.ToDecimal(TextBoxprepaid.Text);

                    TextBoxremainprice.Text = remordprice.ToString();
                    DropDownLisinventmanlst.Focus();
                }
                   
            }
           
        }

        protected void enableproname(object sender, EventArgs e)
        {
            type = DropDownListprotype.SelectedValue.ToString();
            
            DropDownListproname.Items.Clear();
            LoadProductName(type);
           
            DropDownListproname.Enabled = true;
          
        }

        protected void gnereateorderid(object sender, EventArgs e)
        {
           
            var date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            var ticks = DateTime.Now.Ticks.ToString().Substring(0,4);
            var guid = Guid.NewGuid().ToString().Substring(0,5);
            string uniqueid = date.ToString() + '-' + guid;
         
            TextBoxorderid.Text = "Ord" + '-'+ uniqueid;
            DropDownListprotype.Enabled = true;
            Buttongenordrid.Enabled = false;
        }
        protected void Estimatetimetodeliver()
        {

           clsOrder Dal = new clsOrder();
           DataSet ds =  Dal.DeliveryEstdt();
            if (ds.Tables[0].Rows.Count != 0)
            {


                int totalorders = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

                double day = totalorders / 15;

                if (day <= 1)
                {
                    Labelsugdeltydte.Text = "ትዕዛዙ ለነገ መድረስ ይችላል።";
                }
                else
                {
                    Labelsugdeltydte.Text = "ትዕዛዙ በ" + ": " + day + " " + "ቀናት ውስጥ መድረስ ይችላል።";
                   
                }
              
            }

            else
            {

                Labelsugdeltydte.Text = "ትዕዛዙ ለነገ መድረስ ይችላል።";
            }

        }
        protected void sendordertoinvent(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBoxremainprice.Text) || DropDownListtransfertype.SelectedValue == "0" || DropDownLisinventmanlst.SelectedValue == "0")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ትዕዛዝ በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

            else if (DropDownListtransfertype.SelectedItem.ToString() == "Bank Transfer" && DropDownListbankname.SelectedValue == "0" || DropDownListaccountno.SelectedValue == "0")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ትዕዛዝ በትክክል ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

            else
            {
               if (DropDownListtransfertype.SelectedItem.ToString() == "Bank Transfer" && DropDownListaccountno.SelectedValue != "0" )
                {
                    acctno = DropDownListaccountno.SelectedItem.ToString();
                }
                else
                {
                    acctno = "";
                }
                clsOrderTPrice Dal = new clsOrderTPrice();
                string OrderId = TextBoxorderid.Text;
                string CustomerName = TextBoxcusname.Text;
                string CustomerPhone = TextBoxcusphone.Text;
                decimal TotalOPrice = Convert.ToDecimal(Labeltotalorderprice.Text);
                decimal PrePaidPamount = Convert.ToDecimal(TextBoxprepaid.Text);
                string by = Session["UserName"].ToString();
                string sentby = Session["UserBy"].ToString();
                decimal RemainingPamount = Convert.ToDecimal(TextBoxremainprice.Text);
                string date = DateTime.UtcNow.AddHours(3).ToShortDateString();
                string transtype = DropDownListtransfertype.SelectedItem.ToString();
                
             
                string inventman = DropDownLisinventmanlst.SelectedItem.ToString();

                Dal.AddNewOrderTPrice(OrderId, CustomerName, CustomerPhone, TotalOPrice, PrePaidPamount, RemainingPamount, date, by, acctno, transtype,sentby);

                clsOrder Dalo = new clsOrder();
                Dalo.SentOrderUpdate(OrderId, inventman);
                ClearAll();
                Buttsendorder.Attributes["class"]= "btn btn-secondary btn - sm btn - block" ;

                //TextBoxcusname.Focus();
                Buttongenordrid.Enabled = true;
            }
           
        }

        protected void selectandeditorder(object sender, EventArgs e)
        {
           
            GridViewRow row = GridView3.SelectedRow;
             clsOrder Dal = new clsOrder();
            string OrderId = TextBoxorderid.Text;
            string ProductName = row.Cells[3].Text;
            decimal ProductSize = Convert.ToDecimal(row.Cells[4].Text);
            string ProductShape = row.Cells[5].Text;
            decimal CurrentCost = Convert.ToDecimal(row.Cells[10].Text);
            string sentby = Session["UserBy"].ToString();
            string orderby = Session["UserName"].ToString();
            Dal.DeleteWrongOrder(OrderId, ProductName, ProductSize, CurrentCost,orderby,sentby);
           
            GridView3.DataSource = null;
            GridView3.DataBind();
            LoadGrid();
            DropDownListprotype.Focus();
        }



        protected void neworderlistpage(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void deleteneworderlistrow(object sender, GridViewDeleteEventArgs e)
        {
   
        }

        protected void CreatenewOrder(object sender, EventArgs e)
        {
            
            ClearAll();
            TextBoxcusname.Focus();
            TextBoxorderdt.Text = DateTime.UtcNow.AddHours(3).ToShortDateString();
            Buttongenordrid.Enabled = true;
            Buttsendorder.Attributes["class"] = "btn btn-primary btn - sm btn - block";

        }

        protected void enableprogage(object sender, EventArgs e)
        {
            brand = DropDownListprobrand.SelectedValue.ToString();
         
            DropDownListprogage.Items.Clear();
            LoadProductGage(brand);
            DropDownListprogage.Enabled = true;
        }

        protected void loadinventoryman(object sender, EventArgs e)
        {
            //show no of orders in each shop
        }

        protected void claculateandshowppaid(object sender, EventArgs e)
        {
           if(DropDownListtransfertype.SelectedItem.ToString()=="Cash")
            {

                banktransfer.Style["visibility"] = "hidden";
                TextBoxprepaid.Enabled = true;
                banktransfer.Style["display"] = "none";

            }
           else if(DropDownListtransfertype.SelectedItem.ToString()== "Bank Transfer")
            {
                banktransfer.Style["visibility"] = "visible";
                TextBoxprepaid.Enabled = true;
                banktransfer.Style["display"] = "block";
            }
            else if (DropDownListtransfertype.SelectedItem.ToString() == "Credit")
            {
                banktransfer.Style["visibility"] = "hidden";
                banktransfer.Style["display"] = "none";
                TextBoxprepaid.Text = "0";
                TextBoxprepaid.Enabled = false;
                TextBoxremainprice.Text = Labeltotalorderprice.Text;
            }
            else
            {
                banktransfer.Style["visibility"] = "hidden";
                banktransfer.Style["display"] = "none";
            }
            TextBoxprepaid.Focus();
        }

        protected void showorders(object sender, EventArgs e)
        {
           

            showaccttrans.Style["visibility"] = "visible";
            showaccttrans.Style["display"] = "block";
            addacct.Style["visibility"] = "hidden";
            addacct.Style["display"] = "none";
        }

        protected void showorderform(object sender, EventArgs e)
        {
            addacct.Style["visibility"] = "visible";
            addacct.Style["display"] = "block";
            showaccttrans.Style["visibility"] = "hidden";
            showaccttrans.Style["display"] = "none";
        }

        protected void searchordlst(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxfromdt.Text) && !string.IsNullOrWhiteSpace(TextBoxtodt.Text))
            {
                loadorderlist();
            }
            else
            {
                //error
            }
        }

        private void loadorderlist()
        {
            DateTime fromdt = Convert.ToDateTime(TextBoxfromdt.Text);
            DateTime todt = Convert.ToDateTime(TextBoxtodt.Text);
            string orderby = Session["UserName"].ToString();
            string sentby = Session["UserBy"].ToString();
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadOrderAllBydt(fromdt,todt, orderby, sentby);

            if (Order.Tables[0].Rows.Count != 0)
            {

                GridVieworderlst.DataSource = Order.Tables[0];
                GridVieworderlst.DataBind();
                Labeltotalorder.Text = (GridVieworderlst.DataSource as DataTable).Rows.Count.ToString();
            }
        }

        protected void newserlistpage(object sender, GridViewPageEventArgs e)
        {
            GridVieworderlst.PageIndex = e.NewPageIndex;
            loadorderlist();
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
                    string filename = "OrderList" + TextBoxfromdt.Text + "to" + TextBoxtodt.Text;
                    DataTable dt = new DataTable();
                    //  DataTable rmrect = Dal.ExportAllRMReq(fromdt, todt);
                    StringWriter writer = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                    DataTable dt2 = new DataTable();
                    //dt2 = ObjDal.ExportAllRMReq(fromdt, todt);
                    dt2 = ObjDal.ExportAllOrder(fromdt, todt, orderby, sentby);

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

        protected void loadunsentorder(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxresetordid.Text))
            {
                string OrderId = TextBoxresetordid.Text;
                TextBoxorderid.Text = TextBoxresetordid.Text;
                FindOrderByOrderId(OrderId);
            }
        }

        protected void LoadBanacctno(object sender, EventArgs e)
        {
            string bankname = DropDownListbankname.SelectedItem.ToString();
            clsBankAccount Dal = new clsBankAccount();
            DataSet ba = Dal.LoadBankAcctno(bankname);
            DropDownListaccountno.DataTextField = "AccountNumber";
            DropDownListaccountno.DataValueField = "AccountNumber";


            DropDownListaccountno.DataSource = ba.Tables[0];
            DropDownListaccountno.DataBind();
            DropDownListaccountno.Items.Insert(0, "-- የአካውንት ቁጥር ምረጥ--");
            DropDownListaccountno.Items[0].Value = "0";
        }

        protected void enableshapespecific(object sender, EventArgs e)
        {
            
           
        }

        protected void calculatetodayprice(object sender, EventArgs e)
        {
           
           
          

            if (TextBoxorderid.Text == "" || DropDownListprotype.SelectedValue=="0" || DropDownListproname.SelectedValue=="0")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ኣስፈላጊ መረጃዎችን በትክክል ያስገቡ።";
                
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

            else
            {
                 protype = DropDownListprotype.SelectedValue.ToString();
               probrand = DropDownListprobrand.SelectedValue.ToString();
               progage = DropDownListprogage.SelectedValue.ToString();
                 proname = DropDownListproname.SelectedValue.ToString();
            }
           if(!string.IsNullOrWhiteSpace(TextBoxproductsize.Text) &&  DropDownListprotype.SelectedItem.ToString() == "Ordered" && DropDownListprobrand.SelectedValue !="0" && DropDownListprogage.SelectedValue!="0" && DropDownListproname.SelectedValue!="0")
            {
                decimal prowidth = Convert.ToDecimal(TextBoxproductsize.Text);
                clsProduct Dal = new clsProduct();
                DataSet ds = Dal.FindPricerowmat(probrand, progage,shopprice);
                if (ds.Tables[0].Rows.Count != 0)
                {

                     unitpriceofpro = Convert.ToDecimal((ds.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());

                }
                else
                {
                    unitpriceofpro = 0;
                }
                clsService Dal2 = new clsService();
                DataSet ds2 = Dal2.FindServicePrice(proname,protype);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                   unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ServiceUnitprice"]).ToString());
                    if (unitpriceofser == 0)
                    {
                        double proserwidth = Convert.ToDouble(TextBoxproductsize.Text);
                        clsProduct Dal4 = new clsProduct();
                        DataSet ds4 = Dal4.FindPricerowmat(probrand, progage, shopprice);
                        if (ds4.Tables[0].Rows.Count != 0)
                        {

                            unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                            if (proserwidth <= 0.52)
                            {
                                totalserpri = unitprice * Convert.ToDecimal(proserwidth);
                                decimal totalse = unitpriceofpro * prowidth;
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxuprice.Text = Convert.ToString(totalseproprice);
                            }
                            else
                            {

                                totalserpri = unitprice * Convert.ToDecimal(proserwidth) * Convert.ToDecimal(0.7);
                                decimal totalse = unitpriceofpro * prowidth;
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxuprice.Text = Convert.ToString(totalseproprice);
                            }
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }

                    }
                    else
                    {
                        decimal totalse = unitpriceofpro * prowidth;
                        decimal totalseproprice = totalse + unitpriceofser;
                        TextBoxuprice.Text = Convert.ToString(totalseproprice);
                    }
                }
                else
                {
                    unitpriceofser = 0;
                }
               
            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Pre-Manufucture" && DropDownListproname.SelectedValue!="0")
            {
                clsProduct Dal2 = new clsProduct();
                DataSet ds2 = Dal2.FindPricepreman(proname);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal matneedpmp = Convert.ToDecimal((ds2.Tables[0].Rows[0]["MatNeed"]).ToString());

                    if (matneedpmp == 0)
                    {
                        double pmprowidth = Convert.ToDouble(TextBoxproductsize.Text);
                        clsProduct Dal4 = new clsProduct();
                        DataSet ds4 = Dal4.FindPricerowmat(probrand, progage,shopprice);
                        if (ds4.Tables[0].Rows.Count != 0)
                        {
                            unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                            if (pmprowidth <= 0.33)
                            {
                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.05);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxuprice.Text = Convert.ToString(totalseproprice);
                            }
                            else if (pmprowidth <= 0.67)
                            {

                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.02);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxuprice.Text  = Convert.ToString(totalseproprice);
                            }
                           
                            else if (pmprowidth >= 1)
                            {

                                totalserpri = unitprice * Convert.ToDecimal(pmprowidth) * Convert.ToDecimal(1.05);
                                decimal totalse = unitprice * Convert.ToDecimal(pmprowidth);
                                decimal totalseproprice = totalse + totalserpri;
                                TextBoxuprice.Text = Convert.ToString(totalseproprice);
                            }

                            
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }

                    }
                    else
                    {
                        clsProduct Dal4 = new clsProduct();
                        DataSet ds4 = Dal4.FindPricerowmat(probrand, progage, shopprice);
                        if (ds4.Tables[0].Rows.Count != 0)
                        {

                            unitprice = Convert.ToDecimal((ds4.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                         
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }
                        decimal totalpmpwitmnd = unitprice * matneedpmp;
                        TextBoxuprice.Text = Convert.ToString(totalpmpwitmnd);
                    }
                   
                }
                else
                {

                }
               
            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Purchased" && DropDownListproname.SelectedValue != "0")
            {
                string selltype = "Unit";
                clsProduct Dal2 = new clsProduct();
                DataSet ds2 = Dal2.FindPricePuchase(proname, selltype);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    decimal unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ProductUnitPrice"]).ToString());


                    TextBoxuprice.Text = Convert.ToString(unitpriceofser);
                }
                else
                {

                }
            }
            else if (!string.IsNullOrWhiteSpace(TextBoxproductsize.Text) && DropDownListprotype.SelectedItem.ToString() == "Service" && DropDownListproname.SelectedValue != "0")
            {

                
                clsService Dal2 = new clsService();
                DataSet ds2 = Dal2.FindServicePrice(proname);
                if (ds2.Tables[0].Rows.Count != 0)
                {

                    unitpriceofser = Convert.ToDecimal((ds2.Tables[0].Rows[0]["ServiceUnitprice"]).ToString());
                    if(unitpriceofser==0)
                    {
                        double prowidth = Convert.ToDouble(TextBoxproductsize.Text);
                        clsProduct Dal = new clsProduct();
                        DataSet ds = Dal.FindPricerowmat(probrand, progage, shopprice);  
                        if (ds.Tables[0].Rows.Count != 0)
                        {

                            unitpriceofpro = Convert.ToDecimal((ds.Tables[0].Rows[0]["RMaterialMxMprice"]).ToString());
                            if(prowidth<=0.52)
                            {
                                decimal totalse = unitpriceofpro * Convert.ToDecimal(prowidth);
                              //  decimal totalseproprice = totalse * 2;
                                TextBoxuprice.Text = Convert.ToString(totalse);
                            }
                            else 
                            {

                                decimal totalse = unitpriceofpro * Convert.ToDecimal(prowidth) * Convert.ToDecimal(0.7);
                                //decimal totalserprice = totalse*;
                                TextBoxuprice.Text = Convert.ToString(totalse);
                            }
                        }
                        else
                        {
                            unitpriceofpro = 0;
                        }
                      
                    }
                    else
                    {
                        TextBoxuprice.Text = Convert.ToString(unitpriceofser);
                    }
                }
                else
                {
                    unitpriceofser = 0;
                }
               
            }
            else
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባኮዎት ኣስፈላጊ መረጃዎችን በትክክል ያስገቡ።";

                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }

        }

        protected void enableproshape(object sender, EventArgs e)
        {
            name = DropDownListproname.SelectedValue.ToString();
           
            if (name != "ኮፒንግ" || name != "አሸንዳ" )
            {
               
                DropDownListproshape.Items.Clear();
                LoadProductShape();
                DropDownListproshape.Enabled = true;
              
            }
           else if (DropDownListprotype.SelectedItem.ToString() != "Ordered")
            {
                DropDownListproshape.Items.Clear();
                DropDownListproshape.Enabled = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
        

            }
            else if (DropDownListproname.SelectedValue == "0" && DropDownListprotype.SelectedItem.ToString() == "Ordered")
            {
                DropDownListproshape.Items.Clear();
                DropDownListproshape.Enabled = true;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
              
                DropDownListproshape.Items.Clear();
                LoadProductShape();

            }
            else if(name == "ኮፒንግ" || name == "አሸንዳ" && DropDownListprotype.SelectedItem.ToString() == "Ordered")
            {
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownListproshape.Enabled = true;
                DropDownListproshape.Items.Clear();
                LoadProductShape();
            }
            else
            {
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
            }
        }

        protected void enableprobrand(object sender, EventArgs e)
        {
            if (DropDownListprotype.SelectedItem.ToString() == "Pre-Manufucture")
            {
                type = DropDownListprotype.SelectedValue.ToString();
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownListproname.Items.Clear();
                DropDownListproname.Enabled = false;
                TextBoxproductsize.Visible = true;
                TextBoxlen.Visible = true;
                DropDownListprobrand.Enabled = true;
                DropDownListprobrand.Items.Clear();
                LoadProductBrand();
            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Ordered")
            {
                type = DropDownListprotype.SelectedValue.ToString();
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownListproname.Items.Clear();
                DropDownListproname.Enabled = false;
                TextBoxproductsize.Visible = true;
                TextBoxlen.Visible = true;
                DropDownListprobrand.Enabled = true;
                DropDownListprobrand.Items.Clear();
                LoadProductBrand();
            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Service")
            {
                type = DropDownListprotype.SelectedValue.ToString();
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                DropDownListproname.Items.Clear();
                DropDownListproname.Enabled = false;
                TextBoxproductsize.Visible = true;
                TextBoxlen.Visible = true; 
                DropDownListprobrand.Enabled = true;
                DropDownListprobrand.Items.Clear();
                LoadProductBrand();
            }
            else if (DropDownListprotype.SelectedItem.ToString() == "Purchased")
            {
                type = DropDownListprotype.SelectedValue.ToString();

                DropDownListproname.Items.Clear();
                LoadProductName(type);
                DropDownListprobrand.Items.Clear();
                DropDownListprogage.Items.Clear();
            
                DropDownListprobrand.Enabled = false;
                DropDownListprogage.Enabled = false;
                DropDownListproname.Enabled = true;
             
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                DropDownListproshape.Items.Clear();
                DropDownListproshape.Enabled = false;
                TextBoxproductsize.Visible = false;
                TextBoxlen.Visible = false;
            }
            else
            {

                DropDownListproname.Items.Clear();

                DropDownListprobrand.Items.Clear();
                DropDownListprogage.Items.Clear();
             
                DropDownListproshape.Items.Clear();
                DropDownListproshape.Enabled = false;
                DropDownListprobrand.Enabled = false;
                DropDownListprogage.Enabled = false;
                DropDownListproname.Enabled = false;
            
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;

                TextBoxproductsize.Visible = false;
                TextBoxlen.Visible = false;
            }
          

        }
    }
}