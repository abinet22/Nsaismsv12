using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGIMSIMS
{
    public partial class IMAssignEmpToorder : System.Web.UI.Page
    {
        decimal rMaterialQty;
     
        decimal Length;
        string ware;
        string rMaterialWare;
        string prbrand;
        string prgage;
        int selectedorderid =0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && Session["UserBy"] != null && Session["Userroll"].ToString() == "Inventory Manager")
            {
                Labelsession.Text = Session["UserName"].ToString() + "/" + Session["UserBy"].ToString();

                ware = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
          
            TextBoxworkstrtdt.Text = DateTime.Now.ToShortDateString();
           
           
            if(!IsPostBack)
            {
                DropDownListbrand.Visible = false;
                DropDownListgage.Visible = false;
                LoadEmpList();
                wip.Style["visibility"] = "hidden";
                wip.Style["display"] = "none";
                assignemp.Style["visibility"] = "hidden";
                assignemp.Style["display"] = "none";
                divMessage.Style["visibility"] = "hidden";
                divMessage.Style["display"] = "none";
                LoadrecAssignOrdersGrid();
             
            }
            //  LoadrecAssignOrdersGrid();
        }

        private void loadbrands()
        {
            clsProduct Dal = new clsProduct();
            DataSet probrand = Dal.FillProBrand();
            DropDownListbrand.DataTextField = "ProductBrand";
            DropDownListbrand.DataValueField = "ProductBrand";
            DropDownListbrand.DataSource = probrand.Tables[0];
            DropDownListbrand.DataBind();
            DropDownListbrand.Items.Insert(0, "-- Select Brand--");
            DropDownListbrand.Items[0].Value = "0";

        }

        private void LoadEmpList()
        {
            clsEmployee Dal = new clsEmployee();
            DataSet Empname = Dal.FillEmpTeam();
            if (Empname.Tables[0].Rows.Count != 0)
            {
               
                DropDownListemplist.DataTextField = "TeamName";
                DropDownListemplist.DataValueField = "TeamName";
                DropDownListemplist.DataSource = Empname.Tables[0];
                DropDownListemplist.DataBind();
                DropDownListemplist.Items.Insert(0, "-- የቡድን ስም ምረጥ--");
                DropDownListemplist.Items[0].Value = "0";
            }
            else
            {
                Labelrecorder.Text = " ሁሉም ሰራተኞች በስራ ላይ ናቸው። ስራ ሲረከቡ እንደገና ይሞክሩ።";
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["UserBy"] = null;
            Response.Redirect("login.aspx");
        }

        protected void LoadRecivedorderpage(object sender, GridViewPageEventArgs e)
        {
            if (assignemp.Style["visibility"] != "hidden")
               
            {
                GridViewRecAssignOrder.PageIndex = e.NewPageIndex;
                LoadrecAssignOrdersGrid();
            }
           
           
        }

        

        private void LoadrecAssignOrdersGrid()
        {
            clsOrder Dal = new clsOrder();
            DataSet Order = Dal.LoadReciveOrderToInventory(ware);

            if (Order.Tables[0].Rows.Count != 0)
            {
                //(GridViewRecAssignOrder.DataSource as DataTable).Rows.Count.ToString();
                GridViewRecAssignOrder.DataSource = Order.Tables[0];
                GridViewRecAssignOrder.DataBind();
                string noof = (GridViewRecAssignOrder.DataSource as DataTable).Rows.Count.ToString();
                Labelrecorder.Text  = " የተረከብካቸው " + noof + "ትዕዛዞች አሉ። ዝርዝሩን በመመልከት ሰራተኛ በመመደብ ወደ ስራ ያስገቡ።";
                LabeltotalrecOrders.Text = (GridViewRecAssignOrder.DataSource as DataTable).Rows.Count.ToString();
            }
            else
            {
                Labelrecorder.Text = "የተረከቧቸው ስራዎች  የሉም ።";
                LabeltotalrecOrders.Text = "0";


            }
        }

        protected void AssignEmpmakewip(object sender, EventArgs e)
        {
          
                ButtongenMworkid.Enabled = true;

                GridViewRow row = GridViewRecAssignOrder.SelectedRow;

                TextBoxorderid.Text = row.Cells[1].Text;
                TextBoxorderdt.Text = row.Cells[2].Text;
                TextBoxdelvrydt.Text = row.Cells[3].Text;
                TextBoxprobrand.Text = row.Cells[4].Text.Replace("&nbsp;", "");
                TextBoxproname.Text = row.Cells[5].Text;
                TextBoxprogage.Text = row.Cells[6].Text.Replace("&nbsp;", "");
                TextBoxprosize.Text = row.Cells[7].Text;
                TextBoxproshape.Text = row.Cells[8].Text.Replace("&nbsp;", "");
                TextBoxproqty.Text = row.Cells[9].Text;
                TextBoxprolen.Text = row.Cells[10].Text;
                TextBoxprocopsize.Text = row.Cells[11].Text.Replace("&nbsp;", "");
                TextBoxcusname.Text = row.Cells[12].Text;
                TextBoxcusphone.Text = row.Cells[13].Text;
                TextBoxordtype.Text = row.Cells[14].Text;
            TextBoxspecificid.Text = row.Cells[15].Text;
            string specificid = row.Cells[15].Text.Replace("&nbsp;", "");
                 selectedorderid = Int32.Parse(specificid);



        }

        protected void generateMWorkid(object sender, EventArgs e)
          {
            if (TextBoxprobrand.Text != "" && TextBoxprogage.Text != "")
            {
                DropDownListbrand.Visible = false;
                DropDownListgage.Visible = false;
            }
            else
            {
                DropDownListbrand.Visible = true;
                DropDownListgage.Visible = true;
                DropDownListbrand.Items.Clear();
                loadbrands();
            }
            var date = DateTime.UtcNow.AddHours(3).ToShortDateString();
            Buttonassignemptowork.Visible = true;
            var guid = Guid.NewGuid().ToString().Substring(0, 5);
            string uniqueid = date.ToString() + '-' + guid;

            TextBoxMWorkId.Text = "Wrk" + '-' + uniqueid;
           
          //  TextBoxMWorkId.Text = Guid.NewGuid().ToString().GetHashCode().ToString();
        }

        protected void assignemptowork(object sender, EventArgs e)
        {
            if (TextBoxMWorkId.Text == "")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባክዎት በመጀመሪያ የስራ መለያ ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else if (DropDownListemplist.SelectedValue == "0")
            {
                Labelalertonbtntopr.Visible = true;
                Labelalertonbtntopr.Text = "እባክዎት በመጀመሪያ የሰራተኛ ስም ያስገቡ።";
                divMessage.Style["visibility"] = "visible";
                divMessage.Style["display"] = "block";
            }
            else
            {

                ButtongenMworkid.Enabled = false;
              


                string OrderId = TextBoxorderid.Text;
            string OrderDate = TextBoxorderdt.Text;
            string DeliveryDate = TextBoxdelvrydt.Text;

                string ManWId = TextBoxMWorkId.Text;
            string ProductName = TextBoxproname.Text;
            decimal ProductSize;
            string ProductShape = TextBoxproshape.Text;
            decimal Quantity = Convert.ToDecimal(TextBoxproqty.Text);
            string ProductBrand;
            string ProductGage;
                int SpeciifcId = Int32.Parse(TextBoxspecificid.Text);

            if (!string.IsNullOrEmpty(TextBoxprobrand.Text))
            {
                ProductBrand = TextBoxprobrand.Text;
            }
            else
            {
                ProductBrand = null;
            }
            if (!string.IsNullOrEmpty(TextBoxprogage.Text))
            {
                ProductGage = TextBoxprogage.Text;

            }
            else
            {

                ProductGage = null;
            }
            if (!string.IsNullOrEmpty(TextBoxprosize.Text))
            {
                ProductSize = Convert.ToDecimal(TextBoxprosize.Text);

            }
            else
            {
                ProductSize = 1;


            }
            if (!string.IsNullOrEmpty(TextBoxprolen.Text))
            {

                Length = Convert.ToDecimal(TextBoxprolen.Text);

            }
            else
            {
                Length = 1;

            }

           
            
                rMaterialQty = ProductSize * Length * Quantity;

           

            if (TextBoxprobrand.Text != "" && TextBoxprogage.Text != "")
            {
                    if(TextBoxordtype.Text=="Service")
                    {
                        clsManProducts Dal = new clsManProducts();
                        ManProducts obj = InitalizeObject();
                        Dal.AddNewWIPPro(obj);
                        string empname = DropDownListemplist.SelectedItem.ToString();

                        clsEmployee empdal = new clsEmployee();
                        DataSet ds = empdal.Selectempbyteam(empname);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            DataTable ChartData = ds.Tables[0];


                            for (int count = 0; count < ChartData.Rows.Count; count++)
                            {
                                string date = DateTime.UtcNow.AddHours(3).ToShortDateString();
                                string name = ds.Tables[0].Rows[count][0].ToString();
                                clsEmployee empper = new clsEmployee();
                                empper.Addempperdata(name, ProductName, rMaterialQty, date);


                            }

                        }
                        else
                        {

                        }

                        empdal.UpdateEMPstatusTrue(empname);
                       
                        clsOrder Dal1 = new clsOrder();
                        Dal1.MakeOrderStartedWip(OrderId, OrderDate, DeliveryDate, ProductName, Quantity, Length, ware, SpeciifcId);
                    }
                    else
                    {
                        DropDownListbrand.Visible = false;
                        DropDownListgage.Visible = false;
                        clsRowMaterial Dalav = new clsRowMaterial();
                        DataSet rma = Dalav.checkregavalromat(ProductBrand, ProductGage, ware);

                        if (rma.Tables[0].Rows.Count != 0)
                        {
                            decimal oldqty = Convert.ToDecimal((rma.Tables[0].Rows[0]["RMaterialQty"]).ToString());

                            if (oldqty <= 0)
                            {
                                Labelalertonbtntopr.Visible = true;
                                Labelalertonbtntopr.Text = "በቂ እቃ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                                divMessage.Style["visibility"] = "visible";
                                divMessage.Style["display"] = "block";
                            }
                            else
                            {
                                decimal newqty = Decimal.Subtract(oldqty, rMaterialQty);
                                newqty = Math.Round(newqty, 2);


                                if (newqty >= 0)
                                {
                                    clsManProducts Dal = new clsManProducts();
                                    ManProducts obj = InitalizeObject();
                                    Dal.AddNewWIPPro(obj);
                                    string empname = DropDownListemplist.SelectedItem.ToString();

                                    clsEmployee empdal = new clsEmployee();
                                    DataSet ds = empdal.Selectempbyteam(empname);
                                    if (ds.Tables[0].Rows.Count != 0)
                                    {
                                        DataTable ChartData = ds.Tables[0];


                                        for (int count = 0; count < ChartData.Rows.Count; count++)
                                        {
                                            string date = DateTime.Now.ToShortDateString();
                                            string name = ds.Tables[0].Rows[count][0].ToString();
                                            clsEmployee empper = new clsEmployee();
                                            empper.Addempperdata(name, ProductName, rMaterialQty, date);


                                        }

                                    }
                                    else
                                    {

                                    }

                                    empdal.UpdateEMPstatusTrue(empname);
                                    clsRowMaterial udt = new clsRowMaterial();
                                   // decimal rqty = Convert.ToDecimal(TextBoxprolen.Text) * Convert.ToDecimal(TextBoxproqty) * Convert.ToDecimal(TextBoxprosize.Text);

                                    udt.UpdateRowmatqty(ProductBrand, ProductGage, newqty, ware);
                                     clsManProducts Dalmp = new clsManProducts();
                                    Dalmp.AssignMatNeedWIP(ManWId, rMaterialQty, ProductName, OrderId, ProductSize, Quantity, ware);
                                    clsOrder Dal1 = new clsOrder();
                                    Dal1.MakeOrderStartedWip(OrderId, OrderDate, DeliveryDate, ProductName, Quantity, Length, ware, SpeciifcId);
                                }
                                else
                                {
                                    Labelalertonbtntopr.Visible = true;
                                    Labelalertonbtntopr.Text = "በቂ እቃ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                                    divMessage.Style["visibility"] = "visible";
                                    divMessage.Style["display"] = "block";
                                }

                            }

                        }
                        else
                        {
                            Labelalertonbtntopr.Visible = true;
                            Labelalertonbtntopr.Text = " እቃ በመጋዘን ውስጥ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                            divMessage.Style["visibility"] = "visible";
                            divMessage.Style["display"] = "block";
                        }
                    }
              
            }
            else
            {


                if (DropDownListbrand.SelectedValue == "0" && DropDownListgage.SelectedValue == "0")
                {
                    Labelalertonbtntopr.Visible = true;
                    Labelalertonbtntopr.Text = "እባኮት የጥሬ እቃ ኣይነት ይምረጡ።";
                    divMessage.Style["visibility"] = "visible";
                    divMessage.Style["display"] = "block";
                }
                else
                {
                    rMaterialWare = Session["UserName"].ToString();
                    prbrand = DropDownListbrand.SelectedItem.ToString();
                    prgage = DropDownListgage.SelectedItem.ToString();
                }


                clsRowMaterial Dalav = new clsRowMaterial();
                DataSet rma = Dalav.checkregavalromat(prbrand, prgage, rMaterialWare);

                if (rma.Tables[0].Rows.Count != 0)
                {
                    decimal oldqty = Convert.ToDecimal((rma.Tables[0].Rows[0]["RMaterialQty"]).ToString());

                    if (oldqty == 0)
                    {
                        Labelalertonbtntopr.Visible = true;
                        Labelalertonbtntopr.Text = "በቂ እቃ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                        divMessage.Style["visibility"] = "visible";
                        divMessage.Style["display"] = "block";
                    }
                    else
                    {
                        decimal newqty = Decimal.Subtract(oldqty, rMaterialQty);
                        newqty = Math.Round(newqty, 2);

                        if (newqty >= 0)
                        {
                                clsManProducts Dal = new clsManProducts();
                                ManProducts obj = InitalizeObject();
                                Dal.AddNewWIPPro(obj);
                                string empname = DropDownListemplist.SelectedItem.ToString();
                                clsEmployee empdal = new clsEmployee();
                                DataSet ds = empdal.Selectempbyteam(empname);
                                if (ds.Tables[0].Rows.Count != 0)
                                {
                                    DataTable ChartData = ds.Tables[0];

                                        for (int count = 0; count < ChartData.Rows.Count; count++)
                                        {
                                        string date = DateTime.Now.ToShortDateString();
                                        string name = ds.Tables[0].Rows[count][0].ToString();
                                        clsEmployee empper = new clsEmployee();
                                        empper.Addempperdata(name, ProductName, rMaterialQty, date);


                                        }
                                 
                                }
                                else
                                {

                                }
                                empdal.UpdateEMPstatusTrue(empname);
                             

                                clsRowMaterial udt = new clsRowMaterial();
                            udt.UpdateRowmatqty(prbrand, prgage, newqty, rMaterialWare);
                                clsManProducts Dalmp = new clsManProducts();
                                Dalmp.AssignMatNeedWIP(ManWId, rMaterialQty, ProductName, OrderId, ProductSize, Quantity,ware);
                                clsOrder Dal1 = new clsOrder();
                            Dal1.MakeOrderStartedWip(OrderId, OrderDate, DeliveryDate, ProductName, Quantity, Length, ware, SpeciifcId);
                        }
                        else
                        {
                            Labelalertonbtntopr.Visible = true;
                            Labelalertonbtntopr.Text = "በቂ እቃ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                            divMessage.Style["visibility"] = "visible";
                            divMessage.Style["display"] = "block";
                        }

                    }

                }
                else
                {
                    Labelalertonbtntopr.Visible = true;
                    Labelalertonbtntopr.Text = " እቃ በመጋዘን ውስጥ ስለሌልዎት የእቃ ጥያቄ ያቅርቡ።";
                    divMessage.Style["visibility"] = "visible";
                    divMessage.Style["display"] = "block";
                }
            }


            clearAfterSave();

            GridViewRecAssignOrder.DataSource = null;
            GridViewRecAssignOrder.DataBind();

            LoadrecAssignOrdersGrid();
                Buttonassignemptowork.Visible = false;
                Labelrecorder.Text = " ስራ ለመመድብ አዲስ ስራ ይምረጡ።";
            }
           
        }

      
        private ManProducts InitalizeObject()
        {
            
                ManProducts ManPro = new ManProducts();

                ManPro.ManWId = TextBoxMWorkId.Text;
                ManPro.OrderDate = TextBoxorderdt.Text;
                ManPro.DeliveryDate = TextBoxdelvrydt.Text;
                ManPro.OrderId = TextBoxorderid.Text;
                ManPro.ProductName = TextBoxproname.Text;
                ManPro.ProductSize = Convert.ToDecimal(TextBoxprosize.Text);
                ManPro.ProductShape = TextBoxproshape.Text;
                ManPro.Quantity = Convert.ToDecimal(TextBoxproqty.Text);
                ManPro.WstartedDate = TextBoxworkstrtdt.Text;
                ManPro.WfinishDate = "";
            string teamname = DropDownListemplist.SelectedItem.ToString();
            clsEmployee empdal = new clsEmployee();
            DataSet ds = empdal.Selecttheadteam(teamname);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ManPro.AssignEmp = (ds.Tables[0].Rows[0]["IsTeamHead"]).ToString();
            }
            else
            {

            }

              //  ManPro.AssignEmp = DropDownListemplist.SelectedItem.ToString();
                ManPro.TransactionType = "WIP";
                ManPro.CoppingSize = TextBoxprocopsize.Text;
                ManPro.ProductBrand = TextBoxprobrand.Text;
                ManPro.ProductGage = TextBoxprogage.Text;
                ManPro.Length = Convert.ToDecimal(TextBoxprolen.Text);
            ManPro.CustomerName = TextBoxcusname.Text;
            ManPro.CustomerPhone = TextBoxcusphone.Text;
            ManPro.Workshop = Session["UserName"].ToString();
            ManPro.Wstrby = Session["UserBy"].ToString();
            return ManPro;
        }

        private void clearAfterSave()
        {
            TextBoxcusphone.Text = "";
            TextBoxcusname.Text = "";
            TextBoxprobrand.Text = "";
            TextBoxprogage.Text = "";
            TextBoxprocopsize.Text = "";
            TextBoxprolen.Text = "";
            TextBoxorderid.Text = "";
            TextBoxorderdt.Text = "";
            TextBoxdelvrydt.Text = "";
            TextBoxproname.Text = "";
            TextBoxprosize.Text = "";
            TextBoxproshape.Text = "";
            TextBoxproqty.Text = "";
            TextBoxMWorkId.Text = "";
            DropDownListemplist.Items.Clear();
            LoadEmpList();
            DropDownListbrand.Visible = false;
            DropDownListgage.Visible = false;
        }

        protected void enableloagages(object sender, EventArgs e)
        {
            string brand = DropDownListbrand.SelectedItem.ToString();
            DropDownListgage.Items.Clear();
            loadallgages(brand);

        }

        private void loadallgages(string brand)
        {
            clsProduct Dal = new clsProduct();
            DataSet progage = Dal.FillProGage(brand);
            DropDownListgage.DataTextField = "ProductGage";
            DropDownListgage.DataValueField = "ProductGage";
            DropDownListgage.DataSource = progage.Tables[0];
            DropDownListgage.DataBind();
            DropDownListgage.Items.Insert(0, "-- Select Gage--");
            DropDownListgage.Items[0].Value = "0";
        }

        protected void showassignwork(object sender, EventArgs e)
        {
            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";

            assignemp.Style["visibility"] = "visible";
            assignemp.Style["display"] = "block";
            wip.Style["visibility"] = "hidden";
            wip.Style["display"] = "none";

            DropDownListbrand.Visible = false;
            DropDownListgage.Visible = false;
            ButtongenMworkid.Enabled = false;
            Buttonassignemptowork.Visible = false;
            clearAfterSave();
            GridViewRecAssignOrder.DataSource = null;
            GridViewRecAssignOrder.DataBind();
         
            GridViewRecAssignOrder.Columns[0].Visible = true;
           
            LoadrecAssignOrdersGrid();

        }

        protected void showwiplist(object sender, EventArgs e)
        {
            wip.Style["visibility"] = "visible";
            wip.Style["display"] = "block";
            divMessage.Style["visibility"] = "hidden";
            divMessage.Style["display"] = "none";
            assignemp.Style["visibility"] = "hidden";
            assignemp.Style["display"] = "none";
            GridViewRecAssignOrder.DataSource = null;
            GridViewRecAssignOrder.DataBind();
            loadwiplistgrid();
        }

        private void loadwiplistgrid()
        {
            clsManProducts  Dal = new clsManProducts();
            DataSet Order = Dal.LoadWIPListToInventory(ware);

            if (Order.Tables[0].Rows.Count != 0)
            {

                GridViewwip.DataSource = Order.Tables[0];
                GridViewwip.DataBind();
                LabeltotalrecOrders.Text = (GridViewwip.DataSource as DataTable).Rows.Count.ToString();
                string noof = (GridViewwip.DataSource as DataTable).Rows.Count.ToString();
                Labelrecorder.Text = " የተረከብካቸው " + noof + "ትዕዛዞች አሉ። ዝርዝሩን በመመልከት ሰራተኛ በመመደብ ወደ ስራ ያስገቡ።";
            }
            else
            {
                Labelrecorder.Text = " በስራ ላይ ያለ ትዕዛዝ የለም ።";
                LabeltotalrecOrders.Text = "0";


            }
        }

        protected void width(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header))
            {

                // For setting the width of first column to 100px
                 TableCell cell = e.Row.Cells[1];
                //GridViewRecAssignOrder.Columns[2].ItemStyle.Width = 400;
                 cell.Width = new Unit("330px");

                if (assignemp.Style["visibility"] != "hidden")

                {
                    GridViewRecAssignOrder.Columns[0].Visible = true;
                }
                else
                {
                
                }
             }
            
        }

        protected void wipnxtpage(object sender, EventArgs e)
        {
         

            GridViewRow row = GridViewwip.SelectedRow;
            clsOrder Dal = new clsOrder();
            string OrderId = row.Cells[2].Text;
            string ProductName = row.Cells[5].Text;
            string ProductBrand = row.Cells[9].Text;
            string manid = row.Cells[1].Text;
            string ProductGage = row.Cells[10].Text;
            decimal ProductSize = Convert.ToDecimal(row.Cells[6].Text);
            string ProductShape = Convert.ToString(row.Cells[7].Text);
            decimal Quantity = Convert.ToDecimal(row.Cells[8].Text);
            decimal Length = Convert.ToDecimal(row.Cells[11].Text);
            string RMaterialWare = Session["UserName"].ToString();
            decimal qty = ProductSize * Quantity * Length;
            Dal.DeleteCancelOrder(OrderId, ProductName, ProductSize, ProductShape, Quantity, Length);
            clsRowMaterial Dalav = new clsRowMaterial();
            DataSet rma = Dalav.checkregavalromat(ProductBrand, ProductGage, RMaterialWare);

            if (rma.Tables[0].Rows.Count != 0)
            {
                decimal oldqty = Convert.ToDecimal((rma.Tables[0].Rows[0]["RMaterialQty"]).ToString());
                decimal newqty = oldqty + qty;

                clsRowMaterial udt = new clsRowMaterial();
                udt.UpdateRowmatqty(ProductBrand, ProductGage, newqty, RMaterialWare);
            }
            clsManProducts man = new clsManProducts();
            man.deletesartWIPord(manid);
            GridViewwip.DataSource = null;
            GridViewwip.DataBind();
            loadwiplistgrid();
        }

        protected void Loadwippage(object sender, GridViewPageEventArgs e)
        {
            GridViewwip.PageIndex = e.NewPageIndex;
            loadwiplistgrid();

        }
    }
}