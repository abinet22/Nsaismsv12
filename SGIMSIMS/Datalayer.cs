using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SGIMSIMS
{
    public class Datalayer
    {
        public string conString = ConfigurationManager.ConnectionStrings["SGIMSIMS"].ToString();

        public DataTable ExecuteSqlStringDT(string sqlstring)
        {
            SqlConnection objsqlconn = new SqlConnection(conString);
            try
            {

                objsqlconn.Open();

                DataTable Ds = new DataTable();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(Ds);
                return Ds;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                objsqlconn.Close();
            }


        }

        public DataSet ExecuteSqlString(string sqlstring)
        {
            SqlConnection objsqlconn = new SqlConnection(conString);
            try
            {
               
                objsqlconn.Open();

                DataSet Ds = new DataSet();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(Ds);
                return Ds;

              
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                objsqlconn.Close();
            }
          

        }

        public void InsertUpdateDeleteSQLString(string sqlstring)
        {
            SqlConnection objsqlconn = new SqlConnection(conString);
            try
            {
             
                objsqlconn.Open();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                objcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            finally
            {
                objsqlconn.Close();
            }

        }

      
        public DataSet FillProBrand()
        {  
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductBrand from tbl_Settings";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FillProGage(string brand)
        {
            
             DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductGage from tbl_Settings where ProductBrand LIKE N'" + brand +"'";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FillProGage()
        {

            DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductGage from tbl_Settings ";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet FillEmpName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct EmpName from tbl_Employee";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FillProname(string type)
        {
            string sql;
            DataSet obj = new DataSet();
            if (type == "Ordered")
            {
                sql = "SELECT ProductName from tbl_OrderProducts where ProductType='" + type + "'";
                obj = ExecuteSqlString(sql);
              
            }
            else if( type == "Pre-Manufucture")
            {
                sql = "SELECT  ProductName from tbl_PreManProduct where ProductType='" + type + "'";
                obj = ExecuteSqlString(sql);
               
            }

            else if(type == "Purchased")
            {
                sql = "SELECT  ProductName from tbl_PurchaseProduct where ProductType='" + type + "'";
                obj = ExecuteSqlString(sql);
                
            }
            else if (type == "Service")
            {
                sql = "SELECT  ProductName from tbl_PreManProduct UNION SELECT ProductName from tbl_OrderProducts  ORDER BY ProductName";
                obj = ExecuteSqlString(sql); 

            }

            return obj;


        }
       
        public DataSet FillProshape()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductShape from tbl_Shapes ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillProshapeDet(string proshape)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ShapeDetail from tbl_Shapes where ProductShape LIKE N'"+proshape+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillWareName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct WareName from tbl_Warehouse  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillUserName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct AssignShop from tbl_User where IsAdmin='NO' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillUserNamewITHAD()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct AssignShop from tbl_User   ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillUserName(string usrroll)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct AssignShop from tbl_User  where UserRoll= '" + usrroll + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillUserNameshop(string shop)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT UserName from tbl_User  where AssignShop= '" + shop + "' and UserRoll != 'Inventory Manager' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillUserNameex(string username)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct UserName from tbl_User where UserName != '"+username+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }

    // CompanyInfo class
    public class clsCompanyInfo : Datalayer
    {
        public DataSet LoadCompanyInfo()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT *  from tbl_CompanyInfo where id = '1'";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public void AddCompanyInfo(CompanyInfo obj)
        {
            string sql = "INSERT INTO tbl_CompanyInfo (BusinessName, TinNo, Region, Subcity, Woreda, HouseNo, TelNo, MobNo )"
                       + "VALUES( '" + obj.BusinessName + "','" + obj.TinNo + "', '" + obj.Region + "', '" + obj.Subcity + "','" + obj.Woreda + "', '" + obj.HouseNo + "', '" + obj.TelNo + "' , '" + obj.MobNo + "'  )";

            InsertUpdateDeleteSQLString(sql);
        }
          
   
    }
    // Shop class
    public class clsShop : Datalayer
    {
        public DataSet LoadShopInfo()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  ShopId,ShopName, ShopAddress, ShopPhone from tbl_Shop";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet LoadShopName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ShopName from tbl_Shop";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public void AddShopInfo(Shop obj)
        {
            string sql = "INSERT INTO tbl_Shop (ShopId, ShopName, ShopAddress, ShopPhone )"
                       + "VALUES( '" + obj.ShopId + "','" + obj.ShopName + "', '" + obj.ShopAddress+ "', '" + obj.ShopManagerPhn+ "' )";

            InsertUpdateDeleteSQLString(sql);
        }

        // Update existing user
        public void UpdateShop(Shop obj)
        {
             
            string sql = " UPDATE  tbl_Shop" +
                         " SET ShopName='" + obj.ShopName + "'," +
                         " ShopAddress='" + obj.ShopAddress + "'," +
                         
                          " ShopManagerPhn='" + obj.ShopManagerPhn + "'" +
                         "Where ShopId='" + obj.ShopId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing user
        public void DeleteShop(string ShopId)
        {
            User obj = new User();
            string sql = "Delete from tbl_Shop where ShopId='" + ShopId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
    }
    // Setting Class
    public class clsSettings: Datalayer
    {
        public void AddBrandGageInfo(Settings obj)
        {
            string sql = "INSERT INTO tbl_Settings (ProductBrand, ProductGage)"
                       + "VALUES( N'" + obj.ProductBrand + "', N'" + obj.ProductGage + "')";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadBrandGage()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductBrand, ProductGage  from tbl_Settings where ProductBrand is NOT NULL and  ProductGage IS NOT NULL";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet LoadShape()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductShape,ShapeDetail from tbl_Shapes where ProductShape IS NOT NULL";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void AddShapesInfo(Settings obj)
        {
            string sql = "INSERT INTO tbl_Shapes (ProductShape, ShapeDetail)"
                        + "VALUES( N'" + obj.ProductShape + "',N'" + obj.ShapeDetail + "')";

            InsertUpdateDeleteSQLString(sql);
        }
    }
    // User class
    public class clsUser : Datalayer
    {

        // Validate Username and Password
        public DataSet ISValid(User user)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT *  from tbl_User where UserName='" + user.UserName + "' and Password= '" + user.Password + "' and UserRoll= '" + user.UserRoll + "' and AssignShop= '" + user.AssignShop + "'";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        // Add new user on tlb_Login
        public void AddNewUser(User obj)
        {

            string sql = "INSERT INTO tbl_User (UserId, Username, Password , UserRoll ,AssignShop,IsAdmin)"
                        + "VALUES( '" + obj.UserId + "','" + obj.UserName + "', '" + obj.Password + "', '" + obj.UserRoll + "' , '" + obj.AssignShop + "', '" + obj.IsAdmin + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing user
        public void UpdateUser(User obj)
        {

            string sql = " UPDATE  tbl_User" +
                         " SET UserName='" + obj.UserName + "'," +
                         " Password='" + obj.Password + "'," +
                         " UserRoll='" + obj.UserRoll + "'" +
                         "Where UserId='" + obj.UserId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing user
        public void DeleteUser(string UserId)
        {
            User obj = new User();
            string sql = "Delete from tbl_User where UserId='" + UserId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all users to DataGrid
        public DataSet LoadUser()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT UserId, Username, Password , UserRoll ,AssignShop  from tbl_User";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet FindPassword(string user, string password)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT Username, Password , UserRoll  from tbl_User where Username='"+user+"' and  Password='"+password+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void UpdatePassword(string user, string password, string userroll)
        {
            string sql = " UPDATE  tbl_User" +
                         " SET Password='" + password + "'" +
                           "Where Username='" + user+ "' and UserRoll='" + userroll + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        internal void UpdateUserPro(User obj)
        {
            throw new NotImplementedException();
        }

        internal DataSet FillInventoryManager()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  Username from tbl_User where UserRoll='Inventory Manager'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }
    // Warehouse class
    public class clsWarehouse : Datalayer
    {

       


        // Add new user on tlb_Login
        public void AddNewWarehouse(Warehouse obj)
        {
               

        string sql = "INSERT INTO tbl_Warehouse (WareName, WareAddress, WareManager , WareManagerPhn )"
                        + "VALUES( '" + obj.WareName + "','" + obj.WareAddress + "', '" + obj.WareManager + "', '" + obj.WareManagerPhn + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing user
        public void UpdateWarehouse(int id, string WareName, string WareAddress, string WareManager, string WareManagerPhn)
        {

            string sql = " UPDATE  tbl_Warehouse" +
                         " SET WareName='" + WareName + "'," +
                         " WareAddress='" + WareAddress + "'," +
                         " WareManager='" + WareManager + "'," +
                          " WareManagerPhn='" + WareManagerPhn + "'," +
                         "Where id='id'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing user
        public void DeleteWarehouse(int id)
        {
            User obj = new User();
            string sql = "Delete from tbl_Warehouse where id='" + id + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all users to DataGrid
        public DataSet LoadWarehouse()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT WareName from tbl_Warehouse order by id";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadWarehouseGrid()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Warehouse order by id";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }
    //Product class
    public class clsProduct : Datalayer
    {
       

        // Update existing Product
        public void UpdatePreManProduct(decimal mxmprice, string name, string type)
        {

            string sql = "UPDATE  tbl_PreManProduct SET" +
                         " ProductUnitprice='" + mxmprice + "'" +
                         " Where ProductName= N'" + name + "'  and ProductType='" + type + "' ";

            InsertUpdateDeleteSQLString(sql);

        }
      
        //Delete existing Product
        public void DeleteProduct(Products obj)
        {
            DataSet ds = new DataSet();
            string sql = "Delete from tbl_Products" +
                         " where ProductId='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);
        }
      
        // Load  Product List to ProductDataGrid
        public DataSet LoadProductList(string protype)
        {
            DataSet obj = new DataSet();
            if (protype == "Purchased")
            {
               
                string sql = "SELECT ProductId, ProductName,ProductUnitPrice, Warehouse,PreManProductQty as Quantity  from tbl_PurchaseProduct ";
                obj = ExecuteSqlString(sql);
            
            }
            else if (protype == "Ordered")
            {
               
                string sql = "SELECT ProductId, ProductName from tbl_OrderProducts ";
                obj = ExecuteSqlString(sql);
             
            }
            else if (protype == "Pre-Manufucture")
            {
               
                string sql = "SELECT ProductID, ProductName,MatNeed, ProductUnitPrice  from tbl_PreManProduct  ";
                obj = ExecuteSqlString(sql);
             
            }
            else
            {
            }
          
            return obj;
        }
        public DataSet FindPricepreman(string productname)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct MatNeed FROM tbl_PreManProduct " +
                         " WHERE  ProductName LIKE N'" + productname + "'";
            obj = ExecuteSqlString(sql);
            return obj;


        }
        public DataSet FindPricepreman(string productname, string brand, string gage, decimal width, decimal length)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct ProductUnitPrice FROM tbl_PreManProduct " +
                         " WHERE  ProductName LIKE N'" + productname + "' and  ProductBrand LIKE N'" + brand + "' and  ProductGage LIKE N'" + gage + "' and  ProductWidth LIKE N'" + width + "' and  ProductLength LIKE N'" + length + "'";
            obj = ExecuteSqlString(sql);
            return obj;


        }

        public DataSet FindPricePuchase(string productname, string selltype)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct ProductUnitPrice FROM tbl_PurchaseProduct where ProductSellType='"+selltype+"' " +
                         " and ProductName LIKE N'" + productname + "'";
            obj = ExecuteSqlString(sql);
            return obj;


        }

        internal void updatepremanqtyerr(string name, string brand, string gage, decimal tranwdth, decimal tranlen, string ware, decimal qty)
        {
            string sql = "UPDATE  tbl_PreManProductStore SET" +
                      " PreManProductQty= '" + qty + "'" +
                      " Where ProductName LIKE N'" + name + "' and ProductBrand LIKE N'" + brand + "' and ProductGage LIKE N'" + gage + "' and ProductWidth='" + tranwdth + "' and ProductLength='" + tranlen + "' and WareHouse='" + ware + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        // Find   Pro MXM Price on textbox
        public DataSet FindPricerowmat(string rmatBrand, string rmatGage,string shopname)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct RMaterialMxMprice FROM tbl_RowMaterial" +
                         " WHERE  RMaterialBrand LIKE N'" + rmatBrand + "' and  RMaterialMxMprice != 0 and  RMaterialWare='" + shopname+"'" +
                          " and  RMaterialGage LIKE N'" + rmatGage + "' ";
            obj = ExecuteSqlString(sql);
            return obj;

       
        }

        public void AddNewPMProduct(string proid, string pmproname,string protype, decimal matneed, decimal upmpro)
        {
            string sql = "INSERT INTO tbl_PreManProduct " +
                         " (ProductID, ProductName, ProductType, MatNeed, ProductUnitPrice)" +
                         " VALUES('"+ proid + "', N'" + pmproname + "', '" + protype + "','" + matneed + "', '" + upmpro + "')";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet PreManpro()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductName from tbl_PreManProduct";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        
        public DataSet LoadOrdProductListcheck(string productName, string productType)
        {
            string sql;
            DataSet obj = new DataSet();
            if (productType == "Ordered")
            {
                sql = "SELECT ProductName from tbl_OrderProducts where ProductName LIKE N'" + productName + "' and ProductType='" + productType + "'";
                obj = ExecuteSqlString(sql);

            }
            else if (productType == "Pre-Manufucture")
            {
                sql = "SELECT  ProductName from tbl_PreManProduct where ProductName LIKE N'" + productName + "' and ProductType='" + productType + "'";
                obj = ExecuteSqlString(sql);

            }

            else
            {

            }


            return obj;

           
        }

        public DataSet Checkavaltypreman(string purproname, string username)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct PreManProductQty from tbl_PreManProductStore where ProductName LIKE N'" + purproname + "' and WareHouse = '"+username+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public void DeleteProducts(string proname, string proid ,string protype)
        {
            if (protype == "Purchased")
            {
                string sql = "delete from tbl_PurchaseProduct where ProductName LIKE N'" + proname + "' and ProductId='" + proid + "'";

                InsertUpdateDeleteSQLString(sql);
            } 
            else if (protype == "Ordered")
            {
                string sql = "delete from tbl_OrderProducts where ProductName LIKE N'" + proname + "' and ProductId='" + proid+"' ";

                InsertUpdateDeleteSQLString(sql);
            }

            else if (protype == "Pre-Manufucture")
            {
                string sql = "delete from tbl_PreManProduct where ProductID='" + proid + "' ";

                InsertUpdateDeleteSQLString(sql);
            }
            else
            {
            }



        }

        public void UpdatePreManProQty(string purproname, string progage, string username, decimal qtyav, string protype)
        {
            if (protype == "Purchase")
            {
                string sql = "UPDATE  tbl_PurchaseProduct SET" +
                       " PreManProductQty= PreManProductQty -'" + qtyav + "'" +
                       " Where ProductName LIKE N'" + purproname + "'  and Warehouse='" + username + "' ";

                InsertUpdateDeleteSQLString(sql);
            }
           else if (protype == "RMaterial") 
            {
                string sql = "UPDATE  tbl_RowMaterial SET" +
                       " RMaterialQty= RMaterialQty -'" + qtyav + "'" +
                       " Where RMaterialBrand LIKE N'" + purproname + "' and RMaterialGage LIKE N'" + progage + "'  and RMaterialWare='" + username + "' ";

                InsertUpdateDeleteSQLString(sql);
            }
           
            else if (protype == "Premanufucture") 
            {
                string sql = "UPDATE  tbl_PreManProductStore SET" +
                       " PreManProductQty= PreManProductQty -'" + qtyav + "'" +
                       " Where ProductName LIKE N'" + purproname + "'  and WareHouse='" + username + "' ";

                InsertUpdateDeleteSQLString(sql);
            }
            else 
            {
            }
           
          

        }

        public void AddNewOrderProduct(string productId, string productType, string productName)
        {
            string sql = "INSERT INTO tbl_OrderProducts " +
                          " (ProductId,ProductName, ProductType)" +
                          " VALUES('" + productId + "', N'" + productName + "', '" + productType + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        public void AddNewpurchproduct(string productId, string productType, string productName,string SellType, decimal price, string store, decimal qty)
        {
            string sql = "INSERT INTO tbl_PurchaseProduct " +
                         " (ProductId,ProductName,ProductType,ProductSellType, ProductUnitPrice, Warehouse, PreManProductQty)" +
                         " VALUES('" + productId + "', N'" + productName + "','" + productType + "', '" + SellType+"', '"+price+"' , '" +store+ "', '" + qty + "')";

            InsertUpdateDeleteSQLString(sql);
        }

       public DataSet checkestirmarea(string productName)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct MatNeed from tbl_PreManProduct where ProductName LIKE N'"+ productName + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void udtpricepremanpri(string protype, string proname, decimal udtprice)
        {
            string sql = "UPDATE  tbl_PreManProduct SET" +
                          " ProductUnitprice='" + udtprice + "'" +
                          " Where ProductName LIKE N'" + proname + "'  and ProductType='" + protype + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public void udtpriceperchasepri(string protype, string proname, decimal udtprice, string ware)
        {
            string sql = "UPDATE  tbl_PurchaseProduct  SET" +
                            " ProductUnitprice='" + udtprice + "'" +
                            " Where ProductName LIKE N'" + proname + "'  and ProductType='" + protype + "' Warehouse='"+ware+"'";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet Loadpurchaseprodcheck(string proid, string pmproname, string type, string selstore)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductName from tbl_PurchaseProduct where ProductId='" + proid + "'  and  ProductType='" + type + "' and  Warehouse='" + selstore + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void AddNewPMPLst(string name,string brand, string gage,decimal width,decimal len, string ware, decimal qty)
        {
            string sql = "INSERT INTO tbl_PreManProductStore" +
          " (ProductName,ProductBrand,ProductGage,ProductWidth,ProductLength, PreManProductQty, WareHouse)  VALUES ( N'" + name + "',N'" + brand + "',N'" + gage + "','" + width + "','" + len + "', '" + qty + "','" + ware + "')";

            
            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadPreManStore(string ware)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductName,ProductBrand,ProductGage,ProductWidth,ProductLength, PreManProductQty, WareHouse from tbl_PreManProductStore where  WareHouse='" + ware+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void updatepurchproductqty(string proid, string productType, string pmproname, string selltype, decimal upmpro, string selstore, decimal perqty)
        {
            string sql = "UPDATE  tbl_PurchaseProduct SET" +
                       " PreManProductQty= PreManProductQty + '" + perqty + "'" +
                       " Where ProductId='" + proid + "'  and Warehouse='" + selstore + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet CheckPMPNameLst(string name, string brand, string gage,decimal width, decimal len,string ware, decimal qty)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductName, PreManProductQty from tbl_PreManProductStore where ProductName LIKE N'"+name+ "' and ProductBrand LIKE N'" + brand + "' and ProductGage LIKE N'" + gage + "' and ProductWidth ='" + width + "' and ProductLength='" + len + "' and WareHouse='" + ware+ "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdatePMPQtyLst(string name,string brand,string gage,decimal width,decimal len, string ware, decimal qty)
        {
            string sql = "UPDATE  tbl_PreManProductStore SET" +
                       " PreManProductQty= PreManProductQty + '" + qty + "'" +
                       " Where ProductName LIKE N'" + name + "' and ProductBrand LIKE N'" + brand + "' and ProductGage LIKE N'" + gage + "' and ProductWidth='" + width + "' and ProductLength='" + len + "' and WareHouse='" + ware + "' ";

            InsertUpdateDeleteSQLString(sql);
        }
        internal void UpdateIntManPMPQtyLst(string name,string brand, string gage, decimal width,decimal len, string ware, decimal qty)
        {
            string sql = "UPDATE  tbl_PreManProductStore SET" +
                       " PreManProductQty= PreManProductQty - '" + qty + "'" +
                       " Where ProductName LIKE N'" + name + "'  and ProductBrand LIKE N'" + brand + "' and ProductGage LIKE N'" + gage + "' and ProductWidth='" + width + "' and ProductLength='" + len + "' and WareHouse='" + ware + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal void deleteProdt(string proid)
        {
            throw new NotImplementedException();
        }
    }

    // rowmaterial add
    public class clsRowMaterial : Datalayer
    {
        // Add new Product 
        public void AddNewRowmat(string RMaterialId,  string RMaterialBrand, string  RMaterialGage,  decimal RMaterialQty, decimal RMaterialMxMprice, string RMaterialWare)
        {
             
        string sql = "INSERT INTO tbl_RowMaterial " +
                         " (RMaterialId,RMaterialBrand, RMaterialGage, RMaterialQty, RMaterialMxMprice, RMaterialWare)" +
                         " VALUES('" + RMaterialId + "',N'" + RMaterialBrand + "' ," +
                         "N'" + RMaterialGage + "' , '" + RMaterialQty + "'," +
                         " '" + RMaterialMxMprice + "', '" + RMaterialWare + "')";

            InsertUpdateDeleteSQLString(sql);
        }

        // Update existing Product
        public void UpdateRowmat(string brand, string gage,decimal price, string shopname)
        {

            string sql = "UPDATE  tbl_RowMaterial SET RMaterialMxMprice = '"+price+"' " +
                         " Where RMaterialBrand LIKE N'" + brand + "' and RMaterialWare='"+shopname+"' and RMaterialGage LIKE N'" + gage + "'";

            InsertUpdateDeleteSQLString(sql);

        }
      
        //Delete existing Product
        public void DeleteRowMat(string RMaterialId)
        {
            DataSet ds = new DataSet();
            string sql = "Delete from tbl_RowMaterial" +
                         " where RMaterialId='" + RMaterialId + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        // Load  Product List to ProductDataGrid
        public DataSet LoadRowmatList()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RMaterialId, RMaterialBrand, RMaterialGage, RMaterialQty, RMaterialMxMprice, RMaterialWare from tbl_RowMaterial  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindPrice(string ProductBrand, string ProductGage, string ProductName, decimal ProductSize)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT ProductUnitPrice FROM tbl_RowMaterial" +
                         " WHERE  ProductBrand='" + ProductBrand + "' and  ProductUnitPrice != 0" +
                          " and ProductName='" + ProductName + "' and  ProductGage='" + ProductGage + "'" +
                         " and ProductSize='" + ProductSize + "'";
            obj = ExecuteSqlString(sql);
            return obj;


        }

        public DataSet ShowAvalQty(string recfrom, string brand, string gage)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT RMaterialQty FROM tbl_RowMaterial" +
                          " WHERE  RMaterialBrand= N'" + brand + "' and  RMaterialGage= N'" + gage + "'" +
                          " and RMaterialWare='" + recfrom + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet checkregavalromat(string rMaterialBrand, string rMaterialGage, string rMaterialWare)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT RMaterialBrand, RMaterialGage, RMaterialWare, RMaterialQty  FROM tbl_RowMaterial" +
                          " WHERE  RMaterialBrand= N'" + rMaterialBrand + "' and  RMaterialGage= N'" + rMaterialGage + "'" +
                          " and RMaterialWare='" + rMaterialWare + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void UpdateRowmatqty(string rMaterialBrand, string rMaterialGage, decimal rMaterialQty, string rMaterialWare)
        {
            string sql = "UPDATE  tbl_RowMaterial SET RMaterialQty= '" + rMaterialQty + "'" +
                         " Where RMaterialBrand LIKE N'" + rMaterialBrand + "' and RMaterialGage LIKE N'" + rMaterialGage + "' " +
                         "and RMaterialWare='" + rMaterialWare + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        public void Minusrmatudt(string rMaterialBrand, string rMaterialGage, decimal rMaterialQty, string rMaterialWare)
        {
            string sql = "UPDATE  tbl_RowMaterial SET RMaterialQty= RMaterialQty +'" + rMaterialQty + "'" +
                          " Where RMaterialBrand LIKE N'" + rMaterialBrand + "' and RMaterialGage LIKE N'" + rMaterialGage + "' " +
                          " and RMaterialWare='" + rMaterialWare + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        public void AddPurchaseNote(string rMaterialId, string supplierName, string rMaterialBrand, string rMaterialGage, string productType, decimal purchasePrice, decimal rMaterialQty, string additionalNote, string paymentType, string purdate)
        {
            string sql = "INSERT INTO tbl_Purchase " +
                         " (Purchaseid,SupplierName, ProductName, ProductGage,ProductType, PurchasePrice,Quantity,AdditionalNote,PaymentType,PurDate)" +
                         " VALUES('" + rMaterialId + "',N'" + supplierName + "' ," +
                         "N'" + rMaterialBrand + "' , N'" + rMaterialGage + "'," +
                         " '" + productType + "', '" + purchasePrice + "', '"+ rMaterialQty+"', N'"+additionalNote+"', '"+paymentType+ "' ,'" + purdate + "')";

            InsertUpdateDeleteSQLString(sql);
        }

        internal void UpdateRowmatqtys(string brand, string gage, decimal qty, string shopname)
        {
            throw new NotImplementedException();
        }

        internal DataSet LoadRowmatListbgs(string brand, string gage, string shopname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RMaterialId, RMaterialBrand, RMaterialGage, RMaterialQty, RMaterialMxMprice, RMaterialWare from tbl_RowMaterial where RMaterialBrand=N'"+brand+"'and  RMaterialGage=N'"+gage+"' and RMaterialWare=N'"+shopname+"'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }
    //Order Product Class
    public class clsOrder : Datalayer
    {
        // Add new Order on tlb_Order
        public void AddNewOrder(Order obj)
        {

            string sql = "INSERT INTO tbl_Order (OrderId , CustomerName, CustomerPhone, OrderDate, DeliveryDate, ProductName, ProductSize, " +

                "ProductShape,  UnitPrice, Quantity, Length, CurrentCost,  TransactionType, OrderBy, ProductBrand,  ProductGage, CoppingSize,SentBy,OrderType,spcificid)"
                        + "VALUES('" + obj.OrderId + "', N'" + obj.CustomerName + "' , '" + obj.CustomerPhone + "', '" + obj.OrderDate + "', " +
                        "'" + obj.DeliveryDate + "',N'" + obj.ProductName + "',  '" + obj.ProductSize + "', N'" + obj.ProductShape + "' ,'" + obj.UnitPrice + "'," +
                        " '" + obj.Quantity + "','" + obj.Length + "','" + obj.CurrentCost + "', '" + obj.TransactionType + "', " +
                          "'" + obj.OrderBy + "',N'" + obj.ProductBrand + "', N'" + obj.ProductGage + "',  N'" + obj.CoppingSize + "','" + obj.SentBy + "','"+obj.OrderType+ "','" + obj.spcificid + "')";




            InsertUpdateDeleteSQLString(sql);


        }
       
      
       
        // Load New Order to OrderDataGrid to sent
        public DataSet LoadOrder(string OrderId, string orderby, string sentby)
        {
            
              DataSet obj = new DataSet();
            string sql = "SELECT ProductBrand, ProductGage , ProductName, ProductSize ,Length,  ProductShape, CoppingSize, Quantity, UnitPrice, CurrentCost from tbl_Order where OrderId = '" + OrderId + "' and OrderBy='"+orderby+ "' and SentBy='" + sentby + "' and TransactionType = 'O' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadOrderAllBydt(DateTime fromdt,DateTime todt, string orderby, string sentby)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT OrderId , CustomerName, CustomerPhone, ProductBrand, ProductGage , ProductName, ProductSize ,Length,  ProductShape, CoppingSize, Quantity, UnitPrice, CurrentCost,TransactionType from tbl_Order where Cast(OrderDate as Date) between  '" + fromdt + "' and '" + todt + "' and OrderBy='" + orderby + "' and SentBy='" + sentby + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }


        // Update or delete Order list befere sent in sales man crt ords from DataGrid
        public void DeleteWrongOrder(string OrderId, string ProductName, decimal ProductSize, decimal CurrentCost, string orderby, string sentby)
        {

            string sql = "Delete from tbl_Order where OrderId='" + OrderId + "'" +
                          " and ProductName LIKE N'" + ProductName + "' and ProductSize='" + ProductSize + "'" +
                         " and Transactiontype='O' and CurrentCost='" + CurrentCost + "' and OrderBy='" + orderby+ "' and SentBy='" + sentby + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Update  Order transactionto O to SO
        public void SentOrderUpdate(string OrderId, string inventman)
        {
            string sql = " UPDATE  tbl_Order" +
                       " SET TransactionType = 'SO',WorkShop = '"+inventman+"' " +
                       " Where OrderId='" + OrderId + "'";

            InsertUpdateDeleteSQLString(sql);
        }
        // Load all Order to InventoryDataGrid
        public DataSet LoadOrderToInventory(string inventman)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT OrderId , OrderDate, DeliveryDate, ProductBrand,  ProductGage, ProductName,  ProductSize, ProductShape, CoppingSize, Quantity, Length, CustomerName, CustomerPhone,OrderType,spcificid  from tbl_Order where TransactionType = 'SO' and WorkShop ='" + inventman+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

       
        // Update all New Order to OR after seen by Inventman grid SO to OD
        public void MakeNewOrderRecieved(string orderId, string orderDate, string deliveryDate, string productName, decimal quantity, decimal length, string inventman, string userby,int specificid)
        {
            string sql = "Update tbl_Order SET TransactionType = 'OD',AcceptBy='"+userby+"' where OrderId='" + orderId + "'" +
                        " and OrderDate='" + orderDate + "' and DeliveryDate='" + deliveryDate + "'" +
                       
                          " and ProductName LIKE N'" + productName + "'" +
                         "  and Quantity='" + quantity + "'and Length='" + length + "' and Transactiontype='SO' and WorkShop ='" + inventman + "' and spcificid ='" + specificid+"'"; 
            InsertUpdateDeleteSQLString(sql);
        }


      

        //load recieved oredr in inventory to assign OD 
        public DataSet LoadReciveOrderToInventory( string inventman)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT OrderId , OrderDate, DeliveryDate,ProductBrand, ProductName, ProductGage, ProductSize, ProductShape, Quantity, Length, CoppingSize, CustomerName, CustomerPhone,OrderType,spcificid  from tbl_Order where TransactionType = 'OD' and WorkShop ='" + inventman + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        // Update all New Order to from OR to WIP after seen by Inventman grid OD to WIP
        public void MakeOrderStartedWip(string orderId, string orderDate, string deliveryDate, string productName, decimal quantity, decimal Length, string inventman,int SpeciifcId)
        {
            string sql = "Update tbl_Order SET TransactionType = 'WIP' where OrderId='" + orderId + "'" +
                       " and OrderDate='" + orderDate + "' and DeliveryDate='" + deliveryDate + "'" +
                         " and ProductName LIKE N'" + productName + "'" +
                        "  and Quantity='" + quantity + "'" +
                        "  and Length='" + Length + "' and Transactiontype='OD'  and WorkShop ='" + inventman + "' and spcificid ='" + SpeciifcId + "'";
            InsertUpdateDeleteSQLString(sql);
        }

       
      
        // make order is finish notification to invent WIP to F
        public void MakeOrderManFInord(string orderId, string productName, decimal quantity, decimal length)
        {
            string sql = "Update tbl_Order  SET TransactionType = 'F' where OrderId='" + orderId + "'" +
                         " and ProductName LIKE N'" + productName + "'" +
                         "  and Quantity='" + quantity + "' and Length = '" + length + "'" +
                         " and Transactiontype='WIP'";
            InsertUpdateDeleteSQLString(sql);
        }

        // Load Finished(Manufuctured) Order to SearchOrderDataGrid F
        public DataSet LoadFinishedOrder(string by)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT CustomerName, CustomerPhone, ProductName, ProductSize , ProductShape, UnitPrice, Quantity, CurrentCost from tbl_Order where TransactionType = 'F' and OrderBy='"+by+"'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        // search finsh orders in sales man to notify customer before delivery F orders
        public DataSet LoadFinishedOrderBySrchkey(string SrchKey, string by)
        {


            DataSet obj = new DataSet();
            string sql = "SELECT OrderId, CustomerName, CustomerPhone, ProductName, ProductSize , " +
                "ProductShape, UnitPrice, Quantity, CurrentCost from tbl_Order " +
                "where TransactionType = 'F' and OrderBy = '"+ by +"' and Customername LIKE '" + SrchKey + " ' OR CustomerPhone = '" + SrchKey + " ' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        // sent order to sales manager thats finished F to SF
        public void SentFinManPro(string orderId, string productName, string productBrand, string productGage, decimal productSize,decimal quantity, string inventman)
        {
            string sql = "Update tbl_Order SET TransactionType = 'SF' where OrderId='" + orderId + "'" +
                         " and ProductName LIKE N'" + productName + "' and ProductSize='" + productSize + "'" +
                         " and ProductBrand LIKE N'" + productBrand + "' and ProductGage LIKE N'" + productGage + "'" +
                         "  and Quantity='" + quantity + "' and Transactiontype='F' and Workshop='" + inventman + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        // Load sent oreders to sales man SF
        public DataSet LoadRecieveSentFinOrds(string shop)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT OrderId, CustomerName, CustomerPhone, ProductName, ProductSize ,ProductBrand, ProductGage , " +
                "ProductShape, Length, Quantity from tbl_Order " +
                "where TransactionType = 'SF' and OrderBy='"+shop+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        // recieve sent finsh orders in sales man to notification before SF to FOD
        public void LoadSentFinOrder(string orderId, string productName, decimal productSize, string productBrand, string productgage, decimal length, decimal quantity ,string by, string AcceptBy)
        {

            string sql = "Update tbl_Order SET TransactionType = 'FOD',AcceptBy='"+ AcceptBy +"' where OrderId='" + orderId + "'" +
                                  " and ProductName LIKE N'" + productName + "' and ProductSize='" + productSize + "' " +
                                   "and ProductBrand LIKE N'" + productBrand + "' and ProductGage LIKE N'" + productgage + "'" +
                                  "and Length='" + length + "' and OrderBy = '" + by + "'" +
                                  "  and Quantity='" + quantity + "' and Transactiontype='SF'";
            InsertUpdateDeleteSQLString(sql);
        }
        //Load FOD price to sell tables to sell orders
        public DataSet LoadPriceTosaleTable(string OrderId)
        {


            DataSet obj = new DataSet();
            string sql = "SELECT OrderId, CustomerName, CustomerPhone, ProductName, ProductSize , ProductShape, UnitPrice, Quantity, CurrentCost from tbl_Order where TransactionType = 'FOD' and OrderId  = '" + OrderId + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet DeliveryEstdt()
        {


            DataSet obj = new DataSet();
            string sql = " Select * from tbl_ManProducts where TransactionType = 'OR' ";
            string sql2 = " Select * from tbl_ManProducts where TransactionType = 'WIP' ";
            string sql3 = " Select * from tbl_Order where TransactionType = 'O' ";
            obj = ExecuteSqlString(sql);
            obj = ExecuteSqlString(sql2);
            obj = ExecuteSqlString(sql3);
            return obj;
        }

        public void MakeNewOrderRecieved(string orderId, string orderDate, string deliveryDate, string productBrand, string productGage, string productName, decimal quantity, decimal length)
        {
            string sql = "Update tbl_Order SET TransactionType = 'OD' where OrderId='" + orderId + "'" +
                     " and OrderDate='" + orderDate + "' and DeliveryDate='" + deliveryDate + "'" +
                     " and ProductBrand LIKE N'" + productBrand + "' and ProductGage LIKE N'" + productGage + "'" +
                       " and ProductName LIKE N'" + productName + "'" +
                      "  and Quantity='" + quantity + "'and Length='" + length + "' and Transactiontype='SO'";
            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet countnordertot(string orderId, string inventman)
        {
            DataSet obj = new DataSet();
            string sql = "select Count(OrderId) from tbl_Order where OrderId='" + orderId + "' and Workshop='" + inventman + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void DeleteCancelOrder(string orderId, string productName, decimal productSize, string productShape, decimal quantity, decimal length)
        {
            string sql = "Delete from tbl_Order where OrderId='" + orderId + "'" +
                          " and ProductName LIKE N'" + productName + "' and ProductSize='" + productSize + "'" +
                         "  and ProductShape='" + productShape + "' and Quantity='" + quantity + "' and Length='" + length + "'";
            InsertUpdateDeleteSQLString(sql);
        }
    }

    //ManProducts Class
    public class clsManProducts : Datalayer

{
    // Add new Order on tlb_Order
    public void AddNewWIPPro(ManProducts obj)
    {

        string sql = "INSERT INTO tbl_ManProducts (ManWId ,  OrderDate, DeliveryDate, OrderId , ProductName, ProductSize, ProductShape," +
                " Quantity, AssignEmp, WstartedDate, ProductBrand, ProductGage, CoppingSize, Length, WfinishDate, TransactionType,CustomerName,CustomerPhone, WorkShop,Wstrby)"
                    + "VALUES('" + obj.ManWId + "', '" + obj.OrderDate + "', '" + obj.DeliveryDate + "', '" + obj.OrderId + "', N'" + obj.ProductName + "', " +
                    " '" + obj.ProductSize + "', N'" + obj.ProductShape + "' , '" + obj.Quantity + "','" + obj.AssignEmp + "', '" + obj.WstartedDate + "', " +
                    " N'" + obj.ProductBrand + "', N'" + obj.ProductGage + "' , '" + obj.CoppingSize + "','" + obj.Length + "'," +
                    "'" + obj.WfinishDate + "', '" + obj.TransactionType + "',N'" + obj.CustomerName + "','" + obj.CustomerPhone + "','" + obj.Workshop + "','" + obj.Wstrby + "')";


        InsertUpdateDeleteSQLString(sql);


    }


        public DataSet LoadFinishOrdByOId(string OrderId, string inventman)
        {
              DataSet obj = new DataSet();
            string sql = "SELECT OrderDate, ManWId, OrderId , ProductName, ProductSize, ProductShape, Quantity, AssignEmp,  ProductBrand, ProductGage, CoppingSize, Length, CustomerName, CustomerPhone " +
            " from tbl_ManProducts where OrderId = '" + OrderId + "' and TransactionType = 'F' and WorkShop='" + inventman + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadWorkOrders(string ManWId, string ware)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT OrderId, ProductName, ProductSize , ProductShape, Quantity, ProductBrand , ProductGage, Length, AssignEmp,CustomerName,CustomerPhone from tbl_ManProducts where ManWId = '" + ManWId + "' and TransactionType = 'WIP' and WorkShop='"+ware+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        //load finish product to inventory view finish and sent grid
        public DataSet LoadWorkOrdersFin(string inventman)
        {
            DataSet obj = new DataSet(); 
            string sql = "SELECT OrderDate, ManWId, OrderId , ProductName, ProductSize, ProductShape, Quantity, AssignEmp,  ProductBrand, ProductGage, CoppingSize, Length,CustomerName,CustomerPhone from tbl_ManProducts where TransactionType = 'F' and WorkShop='" + inventman + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        //accept finish products and update
        public void MakeOrderManFinManPro(string orderId, string productName, decimal productSize, string productShape, decimal quantity)
        {
            string sql = "Update tbl_ManProducts SET TransactionType = 'F' where OrderId='" + orderId + "'" +
                         " and ProductName='" + productName + "' and ProductSize='" + productSize + "' and ProductShape = '" + productShape + "'" +
                         "  and Quantity='" + quantity + "' and Transactiontype='WIP'";
            InsertUpdateDeleteSQLString(sql);
        }

        // set order product finished date
        public void addorderfinishdate(string finishdate, string orderId, string productName, decimal quantity,  decimal length, string accptusr)
        {
            string sql = "Update tbl_ManProducts SET WfinishDate = '"+ finishdate + "', Waptby = '" + accptusr + "', Transactiontype='F' where OrderId='" + orderId + "'" +
                         " and ProductName LIKE N'" + productName + "'" +
                         "  and Quantity='" + quantity + "' and Length = '" + length + "' and Transactiontype='WIP'";
            InsertUpdateDeleteSQLString(sql);
        }
        //send finishproduct by orderid
        public void SentFinManProudt(string orderId, string manid, string inventman, string Wsntby)
        {
            string sql = "Update tbl_ManProducts SET TransactionType = 'SF', Wsntby='"+ Wsntby + "' where OrderId='" + orderId + "'" +
                         " and ManWId='"+manid+"' and Transactiontype='F'and WorkShop='" + inventman + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadWIPListToInventory(string inventman)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ManWId,OrderId, OrderDate, DeliveryDate, ProductName, ProductSize , ProductShape, Quantity, ProductBrand , ProductGage, Length, AssignEmp from tbl_ManProducts  where TransactionType = 'WIP' and Workshop='" + inventman+"'";
            obj = ExecuteSqlString(sql);
            return obj; 
        }
        // assign esti row mat need fro each wip at start 
        public void AssignMatNeedWIP(string ManWId,decimal matneed, string ProductName, string OrderId, decimal productSize, decimal quantity, string inventman)
        {
            string sql = "Update tbl_ManProducts SET MatNeed = '"+ matneed + "' where ManWId = '"+ ManWId + "' and OrderId='" + OrderId + "'" +
                         " and ProductName LIKE N'" + ProductName + "' and ProductSize='" + productSize + "'" +
                         "  and Quantity='" + quantity + "' and Transactiontype='WIP' and WorkShop ='" + inventman + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        internal void deletesartWIPord(string manid)
        {
            string sql = "Delete from tbl_ManProducts where  ManWId='" + manid + "'";
            InsertUpdateDeleteSQLString(sql);
        }
    }
// User Employee
    public class clsEmployee : Datalayer
    {



        // Add new user on tbl_Employee
        public void AddNewEmployee(Employee obj)
        { 
        
        string sql = "INSERT INTO tbl_Employee (EmpId, EmpName, EmpPhone, EmpAddress, EmpType, EmpPosition, EmpSalaryType, EmpSalary, EmpWrkStrdt, EmpStatus, Busy)"
                        + "VALUES( '" + obj.EmpId + "','" + obj.EmpName + "', '" + obj.EmpPhone + "', '" + obj.EmpAddress + "', '" + obj.EmpType + "', '" + obj.EmpPosition + "', '" + obj.EmpSalaryType + "', '" + obj.EmpSalary + "', '" + obj.EmpWrkStrdt + "', '" + obj.EmpStatus + "' , '" + obj.Busy + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing Employee
        public void UpdateEmp(Employee obj)
        {

            string sql = " UPDATE  tbl_Employee" +
                         " SET EmpType='" + obj.EmpType + "'," +
                         " EmpPosition='" + obj.EmpPosition + "'," +
                         " EmpSalary='" + obj.EmpSalary + "'," +
                          " EmpSalaryType='" + obj.EmpSalaryType + "'" +
                          "Where EmpId='" + obj.EmpId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing Employee
        public void DeleteEmp(string EmpId)
        {
            Employee obj = new Employee();
            string sql = " UPDATE tbl_Employee" +
                         " SET EmpStatus='Diactivate' where EmpId='" + EmpId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all Employee to DataGrid
        public DataSet LoadEmp()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpId, EmpName, EmpPhone, EmpType, EmpPosition, EmpSalaryType, EmpSalary, EmpWrkStrdt from tbl_Employee where EmpStatus='Active'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        // Generate Employee id
       

        public DataSet FillEmpname()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpName from tbl_Employee where EmpStatus='Active' and Busy='False'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FillEmpNameTeam()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpName from tbl_Employee where EmpStatus='Active'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet Selectempbyteam(string team)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpName from tbl_Employee where EmpStatus='Active' and TeamName LIKE N'" + team + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet Selecttheadteam(string team)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct IsTeamHead from tbl_Employee where EmpStatus='Active' and TeamName LIKE N'" + team + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet UpdateEMPstatusTrue(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "Update tbl_Employee SET Busy='True',TeamId='False' where EmpStatus='Active' and TeamName LIKE N'" + empname + "' and Busy='False'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet UpdateEMPstatusFalse(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "Update tbl_Employee SET Busy='False' where EmpStatus='Active' and IsTeamHead = '" + empname + "' and Busy='True'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet UpdateTeamstatusFalse(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "Update tbl_Employee SET Busy='False',TeamId='True' where EmpStatus='Active' and IsTeamHead = '" + empname + "' and Busy='True'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet CheckunqiueEmpName(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpName from tbl_Employee where EmpName='"+empname+ "' and EmpStatus='Active'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void AddEmpTeam(string teamhead, string empllst, string teamname)
        {
            string sql = " UPDATE tbl_Employee" +
                       " SET TeamName=N'"+ teamname + "',IsTeamHead='"+ teamhead + "',TeamId='True' where EmpName='" + empllst + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet FillEmpTeam()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct TeamName from tbl_Employee where TeamName IS NOT NULL and TeamId='True'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AddEmpTeamHead(string teamname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct IsTeamHead from tbl_Employee where TeamName LIKE N'" + teamname+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdateEmpTeam(string teamhead, string empllst, string teamname)
        {
            string sql = " UPDATE tbl_Employee" +
                       " SET TeamName=N'" + teamname + "',IsTeamHead='" + teamhead + "' where EmpName='" + empllst + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet loadempdata(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT EmpSalaryType, EmpSalary from tbl_Employee where EmpName LIKE N'" + empname + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataTable loadweekpayrol()
        {
            DataTable obj = new DataTable();
            string sql = "SELECT  * from tbl_Employee where EmpSalaryType ='Weekly' ";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        internal DataTable loaddaypayrol()
        {

            DataTable obj = new DataTable();
            string sql = "SELECT  * from tbl_Employee where EmpSalaryType ='Daily'";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        internal DataTable loadmonthpayrol()
        {
            DataTable obj = new DataTable();
            string sql = "SELECT  * from tbl_Employee where EmpSalaryType ='Monthly'";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        internal DataSet loaddaysaldata()
        {
            
            DataSet obj = new DataSet();
            string sql = "SELECT  COALESCE(SUM(EmpSalary),0) from tbl_Employee where EmpSalaryType ='Daily'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet loadweeksaldata()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  COALESCE(SUM(EmpSalary),0) from tbl_Employee where EmpSalaryType ='Weekly'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet loadmonthsaldata()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  COALESCE(SUM(EmpSalary),0) from tbl_Employee where EmpSalaryType ='Monthly'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet checkempwrkstrt(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT MAX(EmpWrkStrdt) from tbl_Employee where EmpStatus='Active' and EmpName LIKE N'" + empname + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

       public void Addempperdata(string name, string productName, decimal rMaterialQty, string dates)
        {
            string sql = "INSERT INTO tbl_EmpPerformance (Empname, ProductName, MaterialQty, Wrkdate)"
                        + "VALUES(N'" + name + "', N'" + productName + "' , '" + rMaterialQty + "', '" + dates + "')";

            InsertUpdateDeleteSQLString(sql);
        }
    }
    // OrderTPrice Class -------------------------

    public class clsOrderTPrice : Datalayer
    {
        // Add new user on tlb_Login
        public void AddNewOrderTPrice(string OrderId, string CustomerName, string CustomerPhone, decimal TotalOPrice, decimal PrePaidPamount, decimal RemainingPamount, string date, string by,string transacct, string transtype, string sentby)
        {

            string sql = "INSERT INTO tbl_OrderTPrice (OrderId, CustomerName, CustomerPhone, TotalOPrice, PrePaidPamount, RemainingPamount, MonRecDate, SaleBy,TransferedToAcct, TransferType,SentBy )"
                        + "VALUES('" + OrderId + "', '" + CustomerName + "' , '" + CustomerPhone + "', '" + TotalOPrice + "','" + PrePaidPamount + "','" + RemainingPamount + "','" + date + "','" + by + "','" + transacct + "','" + transtype + "','" + sentby + "')";

            InsertUpdateDeleteSQLString(sql);


        }
        //Load Price for ordered or sales product on text field

        public DataSet LoadPriceTosaleTable(string OrderId, decimal TotalOPrice)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT PrePaidPamount, RemainingPamount from tbl_OrderTPrice where OrderId = '" + OrderId + "' and TotalOPrice = '" + TotalOPrice + "'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet TotalCashAtHand(string date, string by, string solduser)
        {

            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(TotalOPrice),0) from tbl_OrderTPrice where MonRecDate = '" + date + "' and SaleBy = '" + by + "' and SentBy = '" + solduser + "' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }

        public DataSet FindPrePaid(string orderid)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT PrePaidPamount from tbl_OrderTPrice where OrderId = '" + orderid + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet TotalCashAtHand(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " Select  COALESCE(SUM(TotalOPrice),0) from tbl_OrderTPrice where Cast(MonRecDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' and SentBy = '" + byy + "' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }
    }

    // Supplier Class for Material Suppliers for INventory-------------------------
    public class clsSupplier : Datalayer
    {
        // Add new user on tlb_Login
        public void AddNewSupplier(Supplier obj)
        {

            string sql = "INSERT INTO tbl_Supplier (SupplierId,SupplierName,Address ,PhoneNumber )"
                        + "VALUES('" + obj.SupplierId + "', '" + obj.SupplierName + "' , '" + obj.Address + "', '" + obj.PhoneNumber + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing supplier
        public void UpdateSupplier(Supplier obj)
        {

            string sql = " UPDATE  tbl_Supplier" +
                         " SET SupplierName='" + obj.SupplierName + "'," +
                         " Address='" + obj.Address + "'," +
                         " PhoneNumber='" + obj.PhoneNumber + "'," +
                         " Where SupplierId='" + obj.SupplierId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing supplier
        public void DeleteSupplier(string SupplierId)
        {
            Supplier obj = new Supplier();
            string sql = "Delete from tbl_Supplier where SupplierId='" + SupplierId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all Supplier to DataGrid
        public DataSet LoadSupplier()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Supplier order by SupplierId";
            obj = ExecuteSqlString(sql);
            return obj;
        }


    }

    //  Receive Class Inventory recieve Row Material

    public class clsReceive : Datalayer
    {


        // Add new receive.
        public void AddNewReceive(Receive obj)
        {

            string sql = "INSERT INTO tbl_Receive" +
                         " (RecId,RecDate,SupplierId ,ManufId,ProductId,Quantity,UnitCost )" +
                         " VALUES('" + obj.ReceiveId + "', '" + obj.ReceiveDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitCost + "' )";


            InsertUpdateDeleteSQLString(sql);




        }
        public void AddNewProductDetail(Receive obj)
        {

            string sql = "INSERT INTO tbl_ProductDetail" +
                         " (RecId,RecDate,SupplierId ,ManufId,ProductId,Quantity,UnitCost,CurrentCost,Transactiontype )" +
                         " VALUES('" + obj.ReceiveId + "', '" + obj.ReceiveDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitCost + "','" + obj.CurrentCost + "','"
                                     + obj.TransactionType + "')";


            InsertUpdateDeleteSQLString(sql);




        }
        public void UpdateProductDetail(Receive obj)
        {

            string sql = " UPDATE  tbl_ProductDetail" +
                         " SET RecDate='" + obj.ReceiveDate + "'," +
                         " SupplierId='" + obj.SupplierId + "'," +
                         " ManufId='" + obj.ManufId + "'," +
                         " ProductId='" + obj.ProductId + "'," +
                         " Quantity='" + obj.Qty + "'," +
                         " UnitCost='" + obj.UnitCost + "'," +
                         " CurrentCost='" + obj.CurrentCost + "'" +
                         " Where RecId='" + obj.ReceiveId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        // Update Recevied information.
        public void UpdateReceive(Receive obj)
        {

            string sql = " UPDATE  tbl_Receive" +
                         " SET RecDate='" + obj.ReceiveDate + "'," +
                         " SupplierId='" + obj.SupplierId + "'," +
                         " ManufId='" + obj.ManufId + "'," +
                         " ProductId='" + obj.ProductId + "'," +
                         " Quantity='" + obj.Qty + "'," +
                         " UnitCost='" + obj.UnitCost + "'" +
                         "Where RecId='" + obj.ReceiveId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete Received product
        public void DeleteReceive(string recId)
        {

            string sql = "Delete from tbl_Receive where RecId='" + recId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load selected receive  to DataGrid
        //public DataSet LoadReceiveFromDB(string recId)
        //{
        //    DataSet obj = new DataSet();

        //    string sql = "SELECT  RecId,CONVERT(VARCHAR(10),RecDate,10) as RecDate,SupplierName,ManufacturerName,ProductName,Quantity,UnitCost" +
        //                 " FROM tbl_Receive INNER JOIN" +
        //                 " tbl_Product ON tbl_Receive.ProductId = tbl_Product.ProductId INNER JOIN" +
        //                 " tbl_Manufacturer ON tbl_Receive.ManufId = tbl_Manufacturer.ManufacturerID INNER JOIN" +
        //                 " tbl_Supplier ON tbl_Receive.SupplierId = tbl_Supplier.SupplierId" +
        //                 " where RecId = '" + recId + "'";
        //    obj = ExecuteSqlString(sql);
        //    return obj;
        //}
        // load receive record from memeory to Gridview
        //public List<Receive> LoadReceiveFromMemory(string recId)
        //{
        //    List<Receive> receives = new List<Receive>();
        //    try
        //    {
        //        SqlConnection objsqlconn = new SqlConnection(conString);
        //        objsqlconn.Open();
        //        String sqlstr = "SELECT * from tbl_Receive  where RecId = '" + recId + "'";
        //        SqlCommand objcmd = new SqlCommand(sqlstr, objsqlconn);
        //        SqlDataReader reader = objcmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Receive obj = new Receive();
        //            obj.ReceiveId = reader["RecId"].ToString();
        //            obj.ReceiveDate = Convert.ToDateTime(reader["RecDate"].ToString());
        //            obj.SupplierId = reader["SupplierId"].ToString();
        //            obj.ManufId = reader["ManufId"].ToString();
        //            obj.ProductId = reader["ProductId"].ToString();
        //            obj.Qty = Convert.ToInt16(reader["Qantity"].ToString());
        //            obj.UnitCost = Convert.ToDecimal(reader["UnitCost"].ToString());
        //            receives.Add(obj);

        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //    return receives;

        //}

        public DataSet GenerateNewReceiveId()
        {
            DataSet ds = new DataSet();
            string str = " Select" +
                         " CASE" +
                         " WHEN Max(RecId)  IS NULL THEN 1" +
                         " WHEN Max(RecId) >= 1 THEN Max(RecId) + 1" +
                         " END" +
                         " FROM tbl_Receive";
            ds = ExecuteSqlString(str);
            return ds;

        }
        public void DeleteReceiveDetail(string recId)
        {

            string sql = "Delete from tbl_ProductDetail where RecId='" + recId + "'" +
                         " and Transactiontype='R' and CurrentCost='0' ";
            InsertUpdateDeleteSQLString(sql);

        }
        public bool IsProductsGotPrice(string recId)
        {
            DataSet ds = new DataSet();
            string sql = "select CurrentCost from tbl_ProductDetail where RecID='" + recId + "'";
            ds = ExecuteSqlString(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }

    //  Sales Class

    public class clsSalesData : Datalayer
    {


        // Add new sales to sales table.
        public void AddPManProSale(string ProductName,string MaterialUsed,string MaterialSize,decimal Quantity,decimal UnitPrice,decimal CurrentCost,string TransactionType, string Protype, string username ,string solduser,int said)
        {

            string sql = "INSERT INTO tbl_SaleData" +
                         " (ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,TransactionType, Protype, Soldby,SoldUser,SaleSpcificId)" +
                         " VALUES(N'"+ProductName+"',N'"+MaterialUsed+"',N'"+MaterialSize+"','"+Quantity+"','"+UnitPrice+"','"+CurrentCost+"','"+TransactionType+ "','" + Protype+ "', '" + username + "', '" + solduser + "', '" + said + "')";


            InsertUpdateDeleteSQLString(sql);

        }
        public void insertoredertosell(string orderid, string soldby, string solduser,int spid)
        {
                        
            string sql = "INSERT INTO tbl_SaleData(ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,TransactionType, Protype,Soldby,SoldUser,OrderId,SaleSpcificId ) SELECT  ProductName, CAST(ProductBrand AS nvarchar)+'With' + CAST(ProductGage AS nvarchar) AS MaterialUsed, CAST(ProductSize AS varchar)+'X' + CAST(Length AS varchar) AS MaterialSize, Quantity, UnitPrice, CurrentCost, 'FOD', 'Ordered','" + soldby +"','"+solduser+ "',OrderId,'" + spid + "' " +
                         " FROM tbl_Order where OrderId = '" + orderid + "' and TransactionType ='FOD'";
            InsertUpdateDeleteSQLString(sql);
        }
        public void Deletewrongsell(string ProductName, string MaterialUsed, string MaterialSize, decimal Quantity, decimal UnitPrice, decimal CurrentCost, string username,int said)
        {

            string sql = "Delete  FROM tbl_SaleData where ProductName = '" + ProductName + "' and MaterialUsed  = '" + MaterialUsed + "' and MaterialSize = '" + MaterialSize + "' and Quantity = '" + Quantity + "' and UnitPrice = '" + UnitPrice + "' and id = '" + said + "' and CurrentCost = '" + CurrentCost + "'  and TransactionType = 'FOD' and Soldby='" + username + "' ";
            InsertUpdateDeleteSQLString(sql);
        }
        public DataSet LoadOrderProductDetail(string OrderId)
        {
            DataSet obj = new DataSet();
            
            string sql = "SELECT  ProductName, CAST(ProductBrand AS nvarchar)+'With'+CAST(ProductGage AS nvarchar) AS  MaterialUsed,CAST(ProductSize AS varchar)+'X'+CAST(Length AS varchar) AS  MaterialSize, Quantity,UnitPrice, CurrentCost" +
                         " FROM tbl_Order where OrderId = '" + OrderId + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet LoadPreSaledata(string username,string solduser)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  ProductName, MaterialUsed,MaterialSize, Quantity, UnitPrice, CurrentCost,SaleSpcificId" +
                         " FROM tbl_SaleData where TransactionType = 'FOD' and Soldby='"+ username + "' and SoldUser='" + solduser + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadPreSaledataford(string username, string solduser, string orderid)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  ProductName, MaterialUsed,MaterialSize, Quantity, UnitPrice, CurrentCost, Protype,id" +
                         " FROM tbl_SaleData where TransactionType = 'FOD' and Soldby='" + username + "' and SoldUser='" + solduser + "' and OrderId='"+orderid+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet TotalCashBySale(string date, string by ,string solduser)
        {

            DataSet obj = new DataSet();
            string sql = " Select (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0))  from tbl_SaleData where SaleDate = '" + date + "' and Soldby = '" + by + "' and SoldUser='" + solduser + "' ";
          
            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }
        public void SetSaleByAndTransType(string saleby, string datesale,string saleid, decimal discount, string notevat, string paymenttype, string custname, string cusphone, string transacct, string CreditApproved,string solduser, decimal addrev)
        {
            string sql = "Update tbl_SaleData SET  SaleRef = '"+ saleid + "', SaleDate='"+datesale+ "', Discount= '" + discount + "', Notevat= '" + notevat + "',PaymentType ='"+ paymenttype + "',CustomerName =N'" + custname + "'," +
                "PhoneNumber ='" + cusphone + "',TransferedToAcct ='" + transacct + "',CreditApproved ='" + CreditApproved + "',PriceVal='" + addrev + "'," +
                " TransactionType = 'Sold' where  Soldby='" + saleby + "' and SoldUser='"+solduser+ "'  and SaleRef IS NULL and SaleDate IS NULL and TransactionType='FOD'";
            InsertUpdateDeleteSQLString(sql);
        }

        public void UpdateOrderTransType(string orderidforsale)
        {
            
   
               string sql = " Update tbl_Order SET TransactionType = 'Sold' Where OrderId= '" + orderidforsale + "'";
            InsertUpdateDeleteSQLString(sql);
        }
        public void DeleteWrongOrder(string MaterialUsed, string ProductName, decimal Quantity, decimal UnitPrice, decimal CurrentCost, string username, string solduser,int slid)
        {

            string sql = "Delete from tbl_SaleData where  ProductName LIKE N'" + ProductName + "'" +
                         "and Quantity='" + Quantity + "'and UnitPrice='" + UnitPrice + "' and CurrentCost='" + CurrentCost + "' and Soldby='" + username + "'  and SoldUser='" + solduser + "' and SaleSpcificId ='" + slid + "'";
            InsertUpdateDeleteSQLString(sql);

        }

        internal DataSet TotalCashBySale(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " Select  (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0))  from tbl_SaleData where Cast(SaleDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' and SoldUser = '" + byy + "' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }

        internal void UpdateSalePrice(decimal price)
        {
            string sql = "Update tbl_SaleData SET CurrentCost= CurrentCost - '" + price + "'" +
               " where  Soldby IS NULL and SaleRef IS NULL and SaleDate IS NULL and TransactionType='FOD' and Protype = 'Ordered' ";
            InsertUpdateDeleteSQLString(sql);

        }

        internal DataSet SelectSaleLargePrice(string saleby)
        {
            DataSet obj = new DataSet();
            string sql = " Select CurrentCost from tbl_SaleData where SoldUser='" + saleby+"' and SaleRef IS NULL and SaleDate IS NULL and Protype = 'Ordered' and TransactionType='FOD' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }

        internal DataSet LoadAllCrediSale(string username)
        {
            DataSet obj = new DataSet();


            string sql = "select SaleRef,SaleDate, CustomerName, PhoneNumber, ProductName, UnitPrice, CurrentCost  from tbl_SaleData  where Soldby= '" + username + "' and PaymentType='Credit' and CreditApproved='NO'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet LoadCrediSaleTotAmount(string username, string saleref)
        {
            DataSet obj = new DataSet();


            string sql = "select COALESCE(SUM(CurrentCost),0)  from tbl_SaleData  where Soldby= '" + username + "' and PaymentType='Credit' and CreditApproved='NO' and SaleRef='"+saleref+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdateOrderTransType(string salref, string paytype, string toacct, string notevat, string saledate, string solduser)
        {
            string sql = " UPDATE  tbl_SaleData" +
                   " SET PaymentType= '" + paytype + "',SaleDate= '" + saledate + "',Notevat= '" + notevat + "',TransferedToAcct= '" + toacct + "',SoldUser= '" + solduser + "' " +
                   " Where SaleRef = '" + salref + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet LoadSaleByID(string username,string solduser,string orderid)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  ProductName, MaterialUsed,MaterialSize, Quantity, UnitPrice, CurrentCost, Protype" +
                         " FROM tbl_SaleData where TransactionType = 'FOD' and Soldby='" + username + "' and SoldUser='" + solduser + "' and OrderId='" + orderid + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet LoadSaleAllBydt(DateTime fromdt, DateTime todt, string soldby, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  SaleRef, ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,Discount, PriceVal, TransactionType, Protype, Soldby,SoldUser,SaleDate,Notevat from tbl_SaleData where Cast(SaleDate as Date) between  '" + fromdt + "' and '" + todt + "' and Soldby='" + soldby + "' and SoldUser='" + solduser + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet ShowCreditAll(DateTime fromdtt, DateTime todtt)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  SaleRef,CustomerName, PhoneNumber, ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,Discount, Protype, Soldby,SoldUser,SaleDate,TransactionType from tbl_SaleData where Cast(SaleDate as Date) between  '" + fromdtt + "' and '" + todtt + "' and PaymentType='Credit' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }

    //  ProductDetail Class

    public class clsProductDetail : Datalayer
    {

        // set price newly added product
        public void SaveCurrentCost(Receive obj)
        {

            string sql = " UPDATE  tbl_ProductDetail" +
                         " SET CurrentCost='" + obj.CurrentCost + "'" +
                         " Where ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }

        // load selected receive  to Grid using ReceiveId
        public DataSet LoadProductDetail(string recId)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  RecId,ProductName,Quantity,UnitCost,CurrentCost" +
                         " FROM tbl_ProductDetail INNER JOIN" +
                         " tbl_Product ON tbl_ProductDetail.ProductId = tbl_Product.ProductId " +
                         " where RecId = '" + recId + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public decimal CalculatePrice(Receive obj)
        {
            decimal NewPrice;
            NewPrice = (obj.UnitCost + (obj.UnitCost * 15) / 100);
            return NewPrice;
        }
        public DataSet FillReceiveAvalibleforPricing()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct RecId from tbl_ProductDetail where CurrentCost=0 ";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FindPriceandAvaliableQty(string productId, string supId, string manufId)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct CurrentCost,sum(Quantity)as Qty" +
                         " FROM tbl_ProductDetail" +
                         " WHERE productId='" + productId + "' and  CurrentCost != 0" +
                         " and SupplierId='" + supId + "' and ManufId='" + manufId + "'" +
                         " GROUP BY productId,CurrentCost";
            obj = ExecuteSqlString(sql);
            return obj;


        }


    }

    //  Report Class

    public  class clsReport: Datalayer
    {
        public DataSet Revenue(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select Cast(SaleDate as Date) as DateOfSale ,COUNT(*) as NoOfSale,(COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0))" +
                " as SaleRevenue from tbl_SaleData where  Cast(SaleDate as Date)  Between '" + fromdt + "' and '" + todt + "' " +
                "and TransactionType='Sold' and Soldby='"+ byy + "' group by Cast(SaleDate as Date) ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet RevenuebyVAT(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select Cast(SaleDate as Date) as DateOfSale,COUNT(*) as NoOfSale,Notevat, (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0))" +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold' and Soldby='" + byy + "' group by Cast(SaleDate as Date),Notevat " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet RevenuebyPaytype(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select Cast(SaleDate as Date) as DateOfSale,COUNT(*) as NoOfSale,PaymentType, (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0)) " +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold' and Soldby='" + byy + "' group by Cast(SaleDate as Date),PaymentType " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet TotalOrders(string today, string by)
        {


            DataSet obj = new DataSet();
            string sql = " Select * from tbl_Order where TransactionType = 'SO' and OrderDate = '"+ today + "' and OrderBy = '" + by + "'";
            
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet TotalRecievedOrder(string today)
        {


            DataSet obj = new DataSet();
            string sql = " Select * from tbl_Order where TransactionType = 'FOD' and DeliveryDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet TotalCashAtHand(string date, string by)
        {

            DataSet obj = new DataSet();
            string sql = " Select PrePaidPamount from tbl_OrderTPrice where MonRecDate = '" + date + "' and SaleBy = '" + by + "' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;
        }
        public DataSet TotalSales(string today)
        {


            DataSet obj = new DataSet();
            string sql = " Select * from tbl_Sales where TransactionType = 'Sale' and SaleDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet TotalCustomer(string today, string by)
        {


            DataSet obj = new DataSet();
            string sql = " Select COALESCE(Count(CustomerName),0) from tbl_Order where OrderDate = '" + today + "' and OrderBy = '" + by + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet FindallOrder(DateTime from, DateTime to)
        {
            DataSet obj = new DataSet();
            string sql = " Select distinct OrderId from tbl_Order where OrderDate Between '" + from + "' and '" + to + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet FindDailyOrder(string date, string by, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " Select Count(OrderId), COALESCE(SUM(CurrentCost),0) from tbl_Order where OrderDate = '" + date + "' and OrderBy= '" + by + "' and SentBy='"+solduser+"' ";

            obj = ExecuteSqlString(sql);
            return obj;
           

        }
        public DataSet FindDailyWIP(string date, string inventman)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(Count(ManWId),0) from tbl_ManProducts where WstartedDate = '" + date + "' and WorkShop='" + inventman + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindDailyF(string date, string inventman)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(Count(ManWId),0) from tbl_ManProducts where WfinishDate = '" + date + "'  and WorkShop='" + inventman + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindAllWIP(string date, string inventman)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(Count(ManWId),0) from tbl_ManProducts where TransactionType='WIP' and WorkShop='" + inventman + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindDailySale(string date, string by, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " Select Count(SaleRef), COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0) from tbl_SaleData where SaleDate = '" + date + "' and SoldUser='"+solduser+"' and Soldby= '" + by + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        //sentfrom rm
        public DataSet FindMonthlyWorkShopRpt(DateTime fromdate, DateTime fromto, string warehouse, string brand, string gage)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(RMWidth*RMLength),0)  from tbl_RowMaterialRequest where RecDate BETWEEN '" + fromdate + "' and '"+ fromto + "' and Warehousefrm = '" + warehouse+ "' and RMBrand LIKE N'" + brand+ "' and RMGage LIKE N'" + gage+ "' and Status='Delivered'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        //addeddrm
        public DataSet FindMonthlyWorkShopaddRpt(DateTime fromdate, DateTime fromto, string warehouse, string brand, string gage)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(RMWidth*RMLength),0) as RMaterialMxMAQTY from tbl_RowMaterialRequest where RecDate BETWEEN '" + fromdate + "' and '" + fromto + "' and RecBy= '" + warehouse + "' and RMBrand LIKE N'" + brand + "' and RMGage LIKE N'" + gage + "' and Status='Delivered'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        //rm at hand
        public DataSet FindMonthlyrmathandRpt(string warehouse, string brand, string gage)
        {
            DataSet obj = new DataSet();
            string sql = " Select RMaterialQty from tbl_RowMaterial where  RMaterialWare= '" + warehouse + "' and RMaterialBrand LIKE N'" + brand + "' and RMaterialGage LIKE N'" + gage + "'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindMonthMatUsed(DateTime fromdate, DateTime fromto, string brand, string gage, string inventman)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(MatNeed),0) from tbl_ManProducts where Cast(WstartedDate as Date) BETWEEN '" + fromdate + "' and '" + fromto + "' and ProductBrand LIKE N'" + brand + "' and ProductGage LIKE N'" + gage + "' and WorkShop='" + inventman + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet FindDailyOrder(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " Select Count(OrderId), COALESCE(SUM(CurrentCost),0) from tbl_Order where Cast(OrderDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' and SentBy= '" + byy + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet FindDailyOrder(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(CurrentCost),0) from tbl_Order where Cast(OrderDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet FindDailySale(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " Select Count(SaleRef), (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0)) from tbl_SaleData where Cast(SaleDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' and SoldUser= '" + byy + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet FindDailySale(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " Select (COALESCE(SUM(CurrentCost),0)-COALESCE(SUM(Discount),0)) from tbl_SaleData where Cast(SaleDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet TotalCustomer(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " Select Count(CustomerName) from tbl_Order where Cast(OrderDate as Date) BETWEEN '" + fromdt + "' and '" + todt + "'  and SentBy = '" + byy + "' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllTransaction(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select tbl_SaleData.SaleDate, Max(tbl_DailyTransaction.ByWho) as DepsoitedBy, Max( tbl_DailyTransaction.HolderName) as AccountOwnerName ,Max(tbl_DailyTransaction.AccountNumber) as AccountNumber," +

                "Max(tbl_DailyTransaction.AccountBalance) as DepoiteAmount, (COALESCE(SUM(CurrentCost), 0) - COALESCE(SUM(Discount), 0)) as TotalSaleRevenue from tbl_SaleData, tbl_DailyTransaction   where SaleDate BETWEEN '" + fromdt + "' and '" + todt + "' and Soldby='" + byy + "' " +
                "and tbl_DailyTransaction.DateTran = tbl_SaleData.SaleDate group by tbl_SaleData.SaleDate";
          
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllCheckInvent(string protype, string byware)
        {
            string sql;
            DataSet obj = new DataSet();
            if (protype == "Row-Material")
            {
                 
                sql = " select RMaterialBrand, RMaterialGage, RMaterialQty from tbl_RowMaterial  " +
                    " where RMaterialWare='" + byware + "' ";

               
               obj = ExecuteSqlString(sql);

            }
            else if (protype == "Pre-Manufucture")
               
            {
                sql = " select ProductName,PreManProductQty  from tbl_PreManProductStore " +
                    "  where WareHouse='" + byware + "' ";

          
               obj = ExecuteSqlString(sql);

               
            }

            else if (protype == "Purchased")
            {
                sql = " select ProductName,PreManProductQty from tbl_PurchaseProduct " +
                    "  where Warehouse='" + byware + "' ";


                obj = ExecuteSqlString(sql);

            }


            return obj;
          
        
          
        }
        internal DataSet AllCheckMessagesrm()
        {
            DataSet obj = new DataSet();


            string sql = " select count(RMaterialBrand) from tbl_RowMaterial where  RMaterialQty <=600 ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllCheckMessagesrm(string byware)
        {
            DataSet obj = new DataSet();


            string sql = " select count(RMaterialBrand) from tbl_RowMaterial where  RMaterialQty <=600 and RMaterialWare='" + byware + "'";
                obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllCheckMessagespp(string byware)
        {
            DataSet obj = new DataSet();


            string sql = "select count(ProductName) from tbl_PurchaseProduct where PreManProductQty <=100 and Warehouse='" + byware + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllCheckMessagespp()
        {
            DataSet obj = new DataSet();


            string sql = "select count(ProductName) from tbl_PurchaseProduct where PreManProductQty <=150 ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllCheckMessagespmp(string byware)
        {
            DataSet obj = new DataSet();


            string sql = " select count(ProductName) from tbl_PreManProductStore  where PreManProductQty <=150 and Warehouse='" + byware + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllCheckMessagespmp()
        {
            DataSet obj = new DataSet();


            string sql = " select count(ProductName) from tbl_PreManProductStore  where PreManProductQty <=150";
            obj = ExecuteSqlString(sql);
            return obj;
        }
       internal DataSet LoadAllRMReqs()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT count(RMRecID)   from tbl_RowMaterialRequest where Status = 'Requested' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet LoadAllExpLsts()
        {
            DataSet obj = new DataSet();
            string sql = "select count(ExpRecId)  from tbl_Expense where Status = 'Pending' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet newordnote(string inventman)
        {
            DataSet obj = new DataSet();


            string sql = " select ProductName from tbl_Order where TransactionType = 'SO' and WorkShop = '" + inventman + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet deliveryordnote( string date, string inventman)
        {
            DataSet obj = new DataSet();


            string sql = " select ProductName from tbl_ManProducts  where DeliveryDate ='" + date+ "' and WorkShop = '" + inventman + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet pmprotnote(string inventman)
        {
            DataSet obj = new DataSet();


            string sql = " select ProductName from tbl_PreManProductStore  where PreManProductQty <=100 and WareHouse= '" + inventman + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet Allcredittrans(string byware)
        {
            DataSet obj = new DataSet();


            string sql = " select OrderId from tbl_OrderTPrice   where SaleBy= '" + byware + "' and TransferType='Credit' and CreditApproved='NO' union" +
               " select ProductName from tbl_SaleData  where Soldby= '" + byware + "' and PaymentType='Credit' and CreditApproved='NO'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet salecredit(string date, string by,string solduser)
        {
            DataSet obj = new DataSet();
                     
            string sql = " select  COALESCE(SUM(CurrentCost), 0) from tbl_SaleData  where Soldby= '" + by + "' and SoldUser= '" + solduser + "' and SaleDate='" + date+"' and PaymentType='Credit' and CreditApproved='NO'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet salecredit(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();

            string sql = " select  COALESCE(SUM(CurrentCost), 0) from tbl_SaleData  where SoldUser= '" + by + "' and Cast(SaleDate as Date) between '" + fdate + "' and '" + tdate + "' and PaymentType='Credit' and CreditApproved='NO'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet salecash(string date, string by,string solduser)
        {
            DataSet obj = new DataSet();

            string sql = " select SUM(CurrentCost)- SUM(Discount) as soldamt from tbl_SaleData  where Soldby= '" + by + "' and SoldUser= '" + solduser + "' and SaleDate='" + date + "' and PaymentType='Cash' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet salecash(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();

            string sql = " select  SUM(CurrentCost)- SUM(Discount) from tbl_SaleData  where SoldUser= '" + by + "' and Cast(SaleDate as Date) between '" + fdate + "' and '" + tdate + "' and PaymentType='Cash' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet salebanktransfer(string date, string by,string solduser)
        {
            DataSet obj = new DataSet();

            string sql = " select  COALESCE(SUM(CurrentCost), 0) from tbl_SaleData  where Soldby= '" + by + "' and SoldUser= '" + solduser + "' and SaleDate='" + date + "' and PaymentType='Bank Transfer'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet salebanktransfer(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();

            string sql = " select  COALESCE(SUM(CurrentCost), 0) from tbl_SaleData  where SoldUser= '" + by + "' and Cast(SaleDate as Date) between '" + fdate + "' and '" + tdate + "' and PaymentType='Bank Transfer'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet orderppcredit(string date, string by, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(RemainingPamount), 0) from tbl_OrderTPrice   where SaleBy= '" + by + "' and SentBy='"+solduser+"' and MonRecDate='" + date+"' and TransferType='Credit' ";
              
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet orderppcredit(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(RemainingPamount), 0) from tbl_OrderTPrice   where SentBy= '" + by + "' and Cast(MonRecDate as Date) between '" + fdate + "' and '" + tdate + "' and TransferType='Credit' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet orderppcash(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(PrePaidPamount), 0) from tbl_OrderTPrice   where SentBy= '" + by + "' and Cast(MonRecDate as Date) between '" + fdate + "' and '" + tdate + "' and TransferType='Cash'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet orderppcash( string tdate, string by,string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " Select COALESCE(SUM(PrePaidPamount),0) from tbl_OrderTPrice where MonRecDate = '" + tdate + "' and SaleBy = '" + by + "' and SentBy = '" + solduser + "' and TransferType='Cash' ";
            //string sql1 = " Select * from tbl_OrderTPrice where TransactionType = 'SO' and MonRecDate = '" + today + "' ";

            obj = ExecuteSqlString(sql);
            //obj = ExecuteSqlString(sql1);
            return obj;


        }

        internal DataSet orderppbanktransfer(string date, string by, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(PrePaidPamount), 0) from tbl_OrderTPrice   where SaleBy= '" + by + "' and SentBy='" + solduser + "' and MonRecDate='" + date + "' and TransferType='Bank Transfer'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet orderppbanktransfer(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(PrePaidPamount), 0) from tbl_OrderTPrice   where SentBy= '" + by + "' and Cast(MonRecDate as Date) between '" + fdate + "' and '" + tdate + "' and TransferType='Bank Transfer'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailyexpense(DateTime date, string by, string solduser)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(Amount), 0) from tbl_Expense  where ExpReqBy= '" + by + "' and SentBy='" + solduser + "' and ExpPayDate='" + date + "' and Status='Paid'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailyexpense(DateTime fdate, DateTime tdate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(Amount), 0) from tbl_Expense  where SentBy= '" + by + "' and Cast(ExpPayDate as Date) between '" + fdate + "' and '" + tdate + "' and Status='Paid'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailyexpenseyes(DateTime fdate, DateTime tdate)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(Amount), 0) from tbl_Expense  where  Cast(ExpPayDate as Date) between '" + fdate + "' and '" + tdate + "' and Status='Paid' and AddtionalNote='YES'";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailyAllexpense(DateTime frdate, DateTime todate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(ExpPayDate as Date) as PayDay, SUM(Amount) as ExpenseAmount from tbl_Expense  where  ExpReqBy= '" + by + "' and ExpPayDate IS NOT NULL and CAST(ExpPayDate as Date) Between '" + frdate + "' and '" + todate + "' and Status='Paid' group by CAST(ExpPayDate as Date) ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailyreasexpense(DateTime frdate, DateTime todate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(ExpPayDate as Date) as PayDay,ExpReason as ExpenseReason, SUM(Amount) as ExpenseAmount from tbl_Expense  where ExpReqBy= '" + by + "' and ExpPayDate IS NOT NULL and CAST(ExpPayDate as Date) Between '" + frdate + "' and '" + todate + "' and Status='Paid' group by CAST(ExpPayDate as Date),ExpReason ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet dailynoeexpense(DateTime frdate, DateTime todate, string by)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(ExpPayDate as Date) as PayDay,AddtionalNote , SUM(Amount) as ExpenseAmount from tbl_Expense  where ExpReqBy= '" + by + "' and ExpPayDate IS NOT NULL and CAST(ExpPayDate as Date) Between '" + frdate + "' and '" + todate + "' and Status='Paid' group by CAST(ExpPayDate as Date),AddtionalNote ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllBankTransBY(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(DateTran as Date) as TransferDay, SUM(AccountBalance) as AccountBalance from tbl_DailyTransaction  where ByWho= '" + byy + "' and  CAST(DateTran as Date) Between '" + fromdt+ "' and '" + todt + "'  group by CAST(DateTran as Date) ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllBankTransBYBN(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(DateTran as Date) as TransferDay,BankName, SUM(AccountBalance) as AccountBalance from tbl_DailyTransaction  where ByWho= '" + byy + "' and  CAST(DateTran as Date) Between '" + fromdt + "' and '" + todt + "'  group by CAST(DateTran as Date),BankName ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllBankTransSaleper(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(DateTran as Date) as TransferDay,SoldUser as SalePerson, SUM(AccountBalance) as AccountBalance from tbl_DailyTransaction  where ByWho= '" + byy + "' and  CAST(DateTran as Date) Between '" + fromdt + "' and '" + todt + "'  group by CAST(DateTran as Date),SoldUser ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllBankTransBYHN(DateTime fromdt, DateTime todt, string byy)
        {
            DataSet obj = new DataSet();
            string sql = " select CAST(DateTran as Date) as TransferDay,BankName, HolderName, SUM(AccountBalance) as AccountBalance from tbl_DailyTransaction  where ByWho= '" + byy + "' and  CAST(DateTran as Date) Between '" + fromdt + "' and '" + todt + "'  group by CAST(DateTran as Date),BankName,HolderName ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet RevenuebyPaytype(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select PaymentType, SUM(CurrentCost) " +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold'  group by PaymentType " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet RevenuebyShopName(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select Soldby, SUM(CurrentCost) " +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold'  group by  Soldby " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet AllPurchase(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select PurDate  as PurchaseDate,SupplierName ,ProductName, ProductGage " +
                ",Quantity,AdditionalNote,PaymentType from tbl_Purchase where Cast(PurDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllPurchasewithProty(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select ProductName, Sum(Quantity) as Quantity,PaymentType from tbl_Purchase where Cast(PurDate as Date) Between '" + fromdt + "'and '" + todt + "'  group by PaymentType,ProductName ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllPuwithprotyrmname(DateTime fromdt, DateTime todt, string protype, string rmname)
        {
            DataSet obj = new DataSet();
            string sql = " select PurDate  as PurchaseDate,SupplierName ,ProductName, ProductGage " +
                ",Quantity,AdditionalNote,PaymentType from tbl_Purchase where Cast(PurDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and ProductType='"+ protype + "' and ProductName LIKE N'" + rmname + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllCreditPurchase(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select PurDate  as PurchaseDate,SupplierName ,ProductName, ProductGage " +
                ",Quantity,AdditionalNote from tbl_Purchase where Cast(PurDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and PaymentType='Credit' " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void AllUdtCreditPurch(string purDate, string supplierName, string productName, string productGage, decimal quantity)
        {
            string sql = " UPDATE  tbl_Purchase " +
                    " SET PaymentType = 'Cash'" +
                    " Where SupplierName= N'" + supplierName + "' and ProductName LIKE N'" + productName + "'  " +
                "and Quantity ='" + quantity + "'";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet dailyexpensenote(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select COALESCE(SUM(Amount), 0) from tbl_Expense  where  Cast(ExpPayDate as Date) between '" + fromdt + "' and '" + todt + "' and Status='Paid' and AddtionalNote='NO'";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet RevenuebyProName(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select ProductName, SUM(Quantity) " +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold' group by  ProductName " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet RevenuebySaleDate(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select Cast(SaleDate as Date), SUM(CurrentCost) " +
                "as SaleRevenue from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and TransactionType='Sold'  group by  Cast(SaleDate as Date) " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet newordrsentby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_Order where Cast(OrderDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and SentBy='"+ username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet ordrecmanpro(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_Order where Cast(OrderDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and AcceptBy='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet Prosoldby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_SaleData where Cast(SaleDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and SoldUser='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet manproacpby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_ManProducts where Cast(WstartedDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and Waptby='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet Newordsrtwork(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_ManProducts where Cast(WstartedDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and Wstrby='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet Finordsentby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_ManProducts where Cast(WstartedDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and Wsntby='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet rmacptby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_RowMaterialRequest where Cast(RecDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and AcptRBy='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet rmsentby(DateTime fromdt, DateTime todt, string username)
        {
            DataSet obj = new DataSet();
            string sql = " select * from tbl_RowMaterialRequest where Cast(RecDate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' and SentRBy='" + username + "'" +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet EmployeeQuantity(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select Empname,SUM(MaterialQty) from tbl_EmpPerformance where Cast(Wrkdate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' group by Empname " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet EmployeeProduct(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select Empname,Count(ProductName) from tbl_EmpPerformance where Cast(Wrkdate as Date) Between '" + fromdt + "' " +
                "and '" + todt + "' group by Empname " +
                "ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet saleaddval(string date, string by, string solduser)
        {
            DataSet obj = new DataSet();

            string sql = " select  COALESCE(SUM(PriceVal), 0) from tbl_SaleData  where Soldby= '" + by + "' and SoldUser= '" + solduser + "' and SaleDate='" + date + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet saleaddrev(string date, string by, string user)
        {
            DataSet obj = new DataSet();

            string sql = " select  COALESCE(SUM(PriceVal), 0) from tbl_SaleData  where Soldby= '" + by + "' and SoldUser= '" + user + "' and SaleDate='" + date + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet RevenueByshop(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select Cast(SaleDate as Date) as DateOfSale ,COUNT(*) as NoOfSale,Soldby as ShopName,COALESCE(SUM(CurrentCost),0)" +
                " as SaleRevenue from tbl_SaleData where  Cast(SaleDate as Date)  Between '" + fromdt + "' and '" + todt + "' " +
                "and TransactionType='Sold' group by Cast(SaleDate as Date),Soldby ORDER BY 1";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet AllexpenseList(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = " select ExpRecDate,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy, Status,AddtionalNote  from tbl_Expense  where   ExpPayDate IS NOT NULL and CAST(ExpPayDate as Date) Between '" + fromdt + "' and '" + todt + "' and Status='Paid'";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataTable ExportAllExpList(DateTime fromdt, DateTime todt)
        {
            DataTable obj = new DataTable();
            string sql = " select ExpRecDate,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy, Status,AddtionalNote  from tbl_Expense  where   ExpPayDate IS NOT NULL and CAST(ExpPayDate as Date) Between '" + fromdt + "' and '" + todt + "' and Status='Paid'";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }

        internal DataTable ExportAllSaleRevList(DateTime fromdt, DateTime todt, string solduser)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT  SaleRef, ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,Discount, PriceVal, TransactionType, Protype, Soldby,SoldUser,SaleDate,Notevat from tbl_SaleData where Cast(SaleDate as Date) between  '" + fromdt + "' and '" + todt + "' and  Soldby='" + solduser + "' ";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
    }

    public class clsExpense :Datalayer
    {
        // Add new expense 
        public void AddNewExpense(Expense obj)
        {
            

        string sql = "INSERT INTO tbl_Expense" +
                         " (ExpRecId ,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy ,ExpRecDate, Status )" +
                         " VALUES('" + obj.ExpRecId+ "', N'" + obj.ExpReason + "' ,N'"
                                     + obj.PayableTo+ "', '" + obj.Amount+ "',N'"
                                     + obj.ExpNote + "', '" + obj.ExpReqBy+ "','" + obj.ExpRecDate + "','"
                                     + obj.Status + "' )";


            InsertUpdateDeleteSQLString(sql);

        }

        internal void addnewexpreq(string exreqid, string reason, string payto,decimal amount, string byy , string today, string note,string expyn)
        {
            string sql = "INSERT INTO tbl_Expense" +
                          " (ExpRecId ,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy ,ExpRecDate, Status,AddtionalNote)" +
                          " VALUES('" + exreqid + "', N'" + reason + "' , N'"
                                      + payto + "', '" + amount + "',N'"
                                      + note + "', '" + byy + "','" + today + "','Pending','"+expyn+"')";


            InsertUpdateDeleteSQLString(sql);
        }
        internal void addnewwrkstrt(string exreqid, string reason, string payto, decimal amount, string byy, DateTime today, string note)
        {
            string sql = "INSERT INTO tbl_Expense" +
                          " (ExpRecId ,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy ,LastPaymentDate, Status )" +
                          " VALUES('" + exreqid + "', N'" + reason + "' , N'"
                                      + payto + "', '" + amount + "',N'"
                                      + note + "', '" + byy + "','" + today + "','Paid' )";


            InsertUpdateDeleteSQLString(sql);
        }

        internal void updatelastpayment(string date, string reqid)
        {

            string sql = " UPDATE  tbl_Expense" +
                      " SET ExpRecDate = '" + date + "'" +
                      " Where ExpRecId = '" + reqid+ "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet checklastpfemp(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT MAX(LastPaymentDate) from tbl_Expense where  LastPaymentDate IS NOT NULL and PayableTo = '" + empname+ "' and Status = 'Paid' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet advancepay(string empname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT COALESCE(SUM(AdvancePayment), 0) from tbl_Expense where PayableTo = '" + empname + "' and Status = 'Paid' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void advancepay(string empname, decimal amt)
        {
            string sql = " UPDATE  tbl_Expense" +
                      " SET AdvancePayment = 0" +
                      " Where PayableTo = '" + empname + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet LoadAllExpLst()
        {
            DataSet obj = new DataSet();
            string sql = "select  ExpRecId ,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy  from tbl_Expense where Status = 'Pending' ";

            obj = ExecuteSqlString(sql);
            return obj;
        }
        internal DataSet LoadAllExpLstApp(string byy)
        {
            DataSet obj = new DataSet();
            string sql = "select  ExpRecId ,ExpReason ,PayableTo ,Amount,ExpNote,ExpReqBy  from tbl_Expense where Status = 'Approved'  and ExpReqBy ='"+byy+"'";

            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdateconfirmExpLst(string expid, string addnote)
        {
            string sql = " UPDATE  tbl_Expense" +
                     " SET Status = 'Approved', AddtionalNote='"+addnote+"'" +
                     " Where ExpRecId = '" +  expid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }
        internal void deleteExpLst(string expid)
        {
            string sql = " delete from  tbl_Expense" +
                     " Where ExpRecId = '" + expid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }
        internal DataSet FillPaymentList()
        {
           
          DataSet obj = new DataSet();
            string sql = "SELECT  PaymentType from tbl_PaymentList where Status = 'Active' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet checkaddtionalinfo(string paytype)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  AddtionalNote from tbl_PaymentList where PaymentType = '"+paytype+"' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdateExpLstPay(string  reqid, DateTime date, string payedby)
        {
            string sql = " UPDATE  tbl_Expense" +
                     " SET ExpPayDate = '" + date + "',SentBy = '" + payedby + "', Status = 'Paid', LastPaymentDate='" + date+"'" +
                     " Where ExpRecId = '" + reqid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal void addnewexpenselst(string expid, string expname, string expdt, string expamt, string exptype)
        {
            string sql = "INSERT INTO tbl_PaymentList" +
                           " (PaymentId ,PaymentType ,PaymentDate ,PaymentAmount,Status,AddtionalNote )" +
                           " VALUES('" + expid + "', N'" + expname + "' , '"+ expdt + "', '" +expamt + "','Active','" + exptype + "')";


            InsertUpdateDeleteSQLString(sql);
        }

        internal void addnewaddrevlst(string revid, string revname, string revdt, string revamt)
        {
            string sql = "INSERT INTO tbl_AddRevenueList" +
                           " (AddRevenueId ,AddRevenueType ,AddRevenueDate ,AddRevenueAmount,Status )" +
                           " VALUES('" + revid + "', '" + revname + "' , '" + revdt + "', '" + revamt + "','Active')";


            InsertUpdateDeleteSQLString(sql);
        }

        internal void updatenewaddrevlst(string revid)
        {
            string sql = "UPDATE tbl_AddRevenueList set Status='Diactivate' where AddRevenueId='"+revid+"' ";


            InsertUpdateDeleteSQLString(sql);
        }

        internal void updatenewexplist(string expid)
        {
            string sql = "UPDATE tbl_PaymentList set Status='Diactivate' where PaymentId='" + expid + "' ";


            InsertUpdateDeleteSQLString(sql);
        }

        internal DataSet LoadAlladdrev()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT  AddRevenueId ,AddRevenueType ,AddRevenueDate ,AddRevenueAmount from tbl_AddRevenueList where Status = 'Active' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal DataSet LoadAllpaylist()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT PaymentId ,PaymentType ,PaymentDate ,PaymentAmount,AddtionalNote from tbl_PaymentList where Status = 'Active' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet loadpaymenisyn(string payname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AddtionalNote  from tbl_PaymentList where PaymentType LIKE N'"+payname+"' and Status = 'Active' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }

    public class clsRMRequest : Datalayer
    {
        // Add new expense 
        public void AddNewRMrequest(RMRequest obj)
        {
            

        string sql = "INSERT INTO tbl_RowMaterialRequest" +
                             " (RMRecID , RMBrand ,RMGage ,RMWidth ,RMLength ,RecDate ,RecBy , Status )" +
                             " VALUES('" + obj.RMRecID + "', N'" + obj.RMBrand + "' , N'"
                                         + obj.RMGage + "', '" + obj.RMWidth + "','"
                                         + obj.RMLength + "', '" + obj.RecDate + "','" + obj.RecBy + "','"
                                         + obj.Status + "' )";


            InsertUpdateDeleteSQLString(sql);

        }

        public DataSet LoadAppReq(string from)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT RMRecID , RMBrand ,RMGage ,RMWidth ,RMLength , RecBy from tbl_RowMaterialRequest where Warehousefrm = '" + from + "' and Status = 'Approved' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public void SendRecRM(string recid, string senderun)
        {
            string sql = " UPDATE  tbl_RowMaterialRequest" +
                      " SET Status = 'Sent',AcptRBy='"+senderun+"'" +
                      " Where RMRecID = '" + recid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadSentReq(string RecBy)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RMRecID , RMBrand ,RMGage ,RMWidth ,RMLength ,RecDate ,Warehousefrm from tbl_RowMaterialRequest where RecBy = '" + RecBy + "' and Status = 'Sent' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void AccptAppRmReq(string recid, string acptdate, string rmacptby)
        {
            string sql = " UPDATE  tbl_RowMaterialRequest" +
                      " SET Status = 'Delivered', AcptDate ='"+ acptdate + "',AcptRBy ='" + rmacptby + "' " +
                      " Where RMRecID = '" + recid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadAllRMReq()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RMRecID ,RecBy , RMBrand ,RMGage ,RMWidth ,RMLength ,RecDate  from tbl_RowMaterialRequest where Status = 'Requested' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void ApproveReqest(string reqid, string recby, string brand, string gage, decimal width, decimal length, string from)
        {
            string sql = " UPDATE  tbl_RowMaterialRequest" +
                      " SET Status = 'Approved', RMBrand = N'"+ brand + "', RMGage = N'" + gage + "', RMWidth = '" + width + "', RMLength = '" + length + "', Warehousefrm = '" + from +"'" +
                      " Where RMRecID = '" + reqid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadAllRMReq(DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate   from tbl_RowMaterialRequest where Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataTable ExportAllRMReq(DateTime fromdt, DateTime todt)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate   from tbl_RowMaterialRequest where Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "'";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        public DataTable ExportAllOrder(DateTime fromdt, DateTime todt,string orderby,string sentby)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT OrderId , CustomerName, CustomerPhone, ProductBrand, ProductGage , ProductName, ProductSize ,Length,  ProductShape, CoppingSize, Quantity, UnitPrice, CurrentCost,TransactionType from tbl_Order where Cast(OrderDate as Date) between  '" + fromdt + "' and '" + todt + "' and OrderBy='" + orderby + "' and SentBy='" + sentby + "' ";

            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        public DataTable ExportAllSales(DateTime fromdt, DateTime todt, string soldby, string soldusr)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT  SaleRef, ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,Discount, PriceVal, TransactionType, Protype, Soldby,SoldUser,SaleDate,Notevat from tbl_SaleData where Cast(SaleDate as Date) between  '" + fromdt + "' and '" + todt + "' and Soldby='" + soldby + "' and SoldUser='" + soldusr + "' ";

            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        public DataTable ExportRMSales(DateTime fromdt, DateTime todt, string soldby, string soldusr)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT  SaleRef, ProductName,  MaterialUsed, MaterialSize, Quantity,UnitPrice, CurrentCost,Discount, PriceVal, TransactionType, Protype, Soldby,SoldUser,SaleDate,Notevat from tbl_SaleData where Cast(SaleDate as Date) between  '" + fromdt + "' and '" + todt + "' and Soldby='" + soldby + "' and Protype='RMaterial' and SoldUser='" + soldusr + "' ";

            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
        public DataSet LoadRMReqSntByAdmin(string username, DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate  from tbl_RowMaterialRequest where Warehousefrm = 'Admin' and Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet LoadRMReqByBrGa(DateTime fromdt, DateTime todt, string brand, string gage)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate  from tbl_RowMaterialRequest where RMBrand LIKE N'" + brand+"' and RMGage LIKE N'"+gage+ "' and Cast(RecDate as Date)  Between '" + fromdt + "' and '" + todt + "'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadRMReqByWare(string ware, DateTime fromdt, DateTime todt)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date)  from tbl_RowMaterialRequest where Warehousefrm = '" + ware + "'  and Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "' UNION " +
            "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date)  from tbl_RowMaterialRequest where RecBy = '" + ware + "'  and Cast(RecDate as Date)  Between '" + fromdt + "' and '" + todt + "'  ";
          
            obj = ExecuteSqlString(sql);
            return obj;
            
        }

        internal void deleterequestrm(string id)
        {
            string sql = " delete from  tbl_RowMaterialRequest" +
                    " Where RMRecID = '" + id + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        internal DataTable ExportAllRMReqBG(DateTime fromdt, DateTime todt, string brand, string gage)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate  from tbl_RowMaterialRequest where RMBrand LIKE N'" + brand + "' and RMGage LIKE N'" + gage + "' and Cast(RecDate as Date)  Between '" + fromdt + "' and '" + todt + "'  ";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }

        internal DataTable ExportAllRMReqWare(DateTime fromdt, DateTime todt, string ware)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date)  from tbl_RowMaterialRequest where Warehousefrm = '" + ware + "'  and Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "' UNION " +
            "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date)  from tbl_RowMaterialRequest where RecBy = '" + ware + "'  and Cast(RecDate as Date)  Between '" + fromdt + "' and '" + todt + "'  ";

            obj = ExecuteSqlStringDT(sql);
            return obj;
        }

        internal DataTable ExportAlrqByAdmin(string username, DateTime fromdt, DateTime todt)
        {
            DataTable obj = new DataTable();
            string sql = "SELECT RecBy ,Warehousefrm, RMBrand ,RMGage ,RMWidth ,RMLength ,Cast(RecDate as Date) as RequestDate  from tbl_RowMaterialRequest where Warehousefrm = 'Admin' and Cast(RecDate as Date) Between '" + fromdt + "' and '" + todt + "'  ";
            obj = ExecuteSqlStringDT(sql);
            return obj;
        }
    }
    public class clsPMPequest : Datalayer
    {
        // Add new expense 
        public void AddNewPMPrequest(string pMPid, string pmProname, decimal quantity, string reqdt, string reqby, string status, decimal width, decimal length)
        {


            string sql = "INSERT INTO tbl_PMProductRequest" +
                                 " (PMPRecID, PMPName , Qty, RecDate ,RecBy , Status, ProductWidth,ProductLength )" +
                                 " VALUES('" + pMPid + "', N'" + pmProname + "' , '"+ quantity + "', '" + reqdt + "','"+ reqby + "','" + status + "', '"+ width+ "', '"+ length +"')";
                                           
            
            InsertUpdateDeleteSQLString(sql);

        }

        public DataSet LoadAppReq(string from)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT PMPRecID, PMPName , Qty, RecDate, RecBy from tbl_PMProductRequest where Warehousefrm = '" + from + "' and Status = 'Approved' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public void SendRecRM(string recid)
        {
            string sql = " UPDATE  tbl_PMProductRequest" +
                      " SET Status = 'Sent'" +
                      " Where PMPRecID = '" + recid + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadSentReq(string RecBy)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT PMPRecID, PMPName , Qty, RecDate,ProductWidth,ProductLength  from tbl_PMProductRequest where RecBy = '" + RecBy + "' and Status = 'Sent' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void AccptAppRmReq(string recid, string acptdate, string acptby)
        {
            string sql = " UPDATE  tbl_PMProductRequest" +
                      " SET Status = 'Delivered', AcptDate ='" + acptdate + "', AcceptBy='" + acptby + "'" +
                      " Where PMPRecID = '" + recid + "'  ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadAllRMReq(string ware)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT PMPRecID, PMPName as ProductName,ProductBrand,ProductGage,ProductWidth,ProductLength, Qty, RecDate, RecBy  from tbl_PMProductRequest where Status = 'Requested' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public void ApproveReqest(string PMPRecID, string PMPName , decimal Qty,string RecDate, string RecBy, string from)
        {
            string sql = " UPDATE  tbl_PMProductRequest" +
                      " SET Status = 'Approved', PMPName LIKE N'" + PMPName + "', Qty = '" + Qty + "', RecDate = '" + RecDate + "', RecBy = '" + RecBy + "', Warehousefrm = '" + from + "'" +
                      " Where PMPRecID = '" + PMPRecID + "' ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet PMPlst()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductName from tbl_PreManProduct";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }
    public class clsRMCount : Datalayer
    {
        // Add new expense 
        public void AddRMCount(string rmBrand, string rmGage, decimal quantity, string ware)
        {


            string sql = "INSERT INTO tbl_RowMatCount" +
                                 " (RmatBrand, RmatGage , QtyMxM, Ware)" +
                                 " VALUES(N'" + rmBrand + "', N'" + rmGage + "' , '"
                                             + quantity + "','" + ware + "' )";


            InsertUpdateDeleteSQLString(sql);

        }
        public void deleteall(string ware)
        {
            string sql = "Delete  from tbl_RowMatCount where Ware='"+ware+"' ";
            InsertUpdateDeleteSQLString(sql);
        }
        public DataSet Loadmatlst(string ware)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_RowMatCount  where Ware='" + ware + "'  ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public void Updatermlst(string rmBrand, string rmGage, decimal quantity, string ware)
        {
            string sql = " UPDATE  tbl_RowMatCount" +
                      " SET QtyMxM = '"+ quantity+"'" +
                      " Where RmatBrand LIKE N'" + rmBrand +"' and RmatGage LIKE N'"+ rmGage + "' and Ware='" + ware + "'  ";

            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet Checkavalty(string rmBrand, string rmGage, string ware)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct QtyMxM  from tbl_RowMatCount where RmatBrand LIKE N'" + rmBrand + "' and RmatGage LIKE N'" + rmGage + "' and Ware= '" + ware + "' and QtyMxM !=0";
            obj = ExecuteSqlString(sql);
            return obj;
        }

     

    }
    public class clsService: Datalayer
    {
        // Add new expense 
        public void AddNewService(Service obj)
        {


            string sql = "INSERT INTO tbl_Service" +
                                 " (ServiceId  , ProductType , ProductName , ServiceType, ServiceName, ServiceUnitprice )" +
                                 " VALUES('" + obj.ServiceId + "', '" + obj.ProductType + "' , N'"
                                            + obj.ProductName+ "', '" + obj.ServiceType + "',N'"
                                             + obj.ServiceName + "', '" + obj.ServiceUnitprice+ "')";


            InsertUpdateDeleteSQLString(sql);

        }
        public DataSet LoadServiceName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ProductName  from tbl_Service ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet LoadService()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ServiceId  , ProductType , ProductName , ServiceType, ServiceName, ServiceUnitprice from tbl_Service ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindServiceSalePrice(string proname, string servicetype)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT distinct ServiceUnitprice from tbl_Service where ProductName  LIKE N'" + proname + "' and ServiceUnitprice != 0 and ServiceType = '"+ servicetype + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet FindServicePrice(string proname, string protype)
        {
            
            DataSet obj = new DataSet();
            string sql = "SELECT distinct ServiceUnitprice from tbl_Service where ProductName  LIKE N'" + proname + "' and ProductType LIKE N'" + protype + "'  and ServiceType = 'WithMaterial'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet FindServicePrice(string proname)
        {

            DataSet obj = new DataSet();
            string sql = "SELECT distinct ServiceUnitprice from tbl_Service where ProductName  LIKE N'" + proname + "'  and ServiceType = 'WithOutMaterial'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet checkservicename(string proName, string sertype, string protype)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductName, ServiceType from tbl_Service where ProductName  LIKE N'" + proName + "' and ProductType = '"+ protype + "' and ServiceType =  '" + sertype + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }

        internal void UpdateService(string serid,string sertype, decimal newprice)
        {
            string sql = " update tbl_Service set  ServiceUnitprice = '"+ newprice + "' where ServiceType = '"+ sertype + "' and ServiceId ='" + serid + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        internal void DeleteService(string proid)
        {
            string sql = "delete from tbl_Service where ServiceId='" + proid + "'";

            InsertUpdateDeleteSQLString(sql);
        }
    }

    public class clsBankAccount:Datalayer
    {
        public void AddNewAccount(BankAccount obj)
        {
      

        string sql = "INSERT INTO tbl_BankAccount" +
                                 " (AccountId , BankName , BranchName , AccountHead, AccountType,  HolderName ,AccountNumber,AccountBalance )" +
                                 " VALUES('" + obj.AccountId + "', N'" + obj.BankName + "' , N'"
                                            + obj.BranchName + "', '" + obj.AccountHead + "','"
                                             + obj.AccountType + "', N'" + obj.HolderName + "','"
                                             + obj.AccountNumber + "', N'" + obj.AccountBalance + "')";


            InsertUpdateDeleteSQLString(sql);

        }
        public DataSet LoadBankBankName()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct BankName  from tbl_BankAccount ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadBankBranch(string bankname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct BranchName  from tbl_BankAccount where BankName=N'"+bankname+"'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadBankBankBraAcct(string bankname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT HolderName from tbl_BankAccount where BankName= N'" + bankname + "' ";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadBankAccount()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AccountId , BankName , BranchName , AccountHead, AccountType,  HolderName ,AccountNumber,AccountBalance from tbl_BankAccount ";
            obj = ExecuteSqlString(sql);
            return obj;
        }

       
        public void Adddailytansaction(string transid,string bankname,  string holdername, string acctno, string date, string byy, decimal amount, string solduser)
        {
            string sql = "INSERT INTO tbl_DailyTransaction" +
                                " (TransactionId , BankName , HolderName ,AccountNumber, Date, ByWho, AccountBalance,SoldUser )" +
                                " VALUES('" + transid + "', N'" + bankname + "' , N'" + holdername + "','"
                                            + acctno + "', '" + date + "','"+ byy + "', '" + amount + "', '" + solduser + "')";


            InsertUpdateDeleteSQLString(sql);
        }

        public DataSet LoadBankBankBraAcctno(string bankname, string branchname, string holder)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AccountNumber from tbl_BankAccount where BankName= N'" + bankname + "' and BranchName = N'" + branchname + "' and HolderName = N'" + holder + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadBankAcctno(string bankname)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AccountNumber from tbl_BankAccount where BankName LIKE N'" + bankname + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadBankAcctnoBNHN(string bankname ,string holder)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AccountNumber from tbl_BankAccount where BankName= N'" + bankname + "' and HolderName = N'" + holder + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }
}   