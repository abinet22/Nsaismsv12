using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGIMSIMS
{
    public class Businesslayer
    {

    }
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRoll { get; set; }
        public string AssignShop { get; set; }

        public string IsAdmin { get; set; }
        

    }
    public class BankAccount
    {
        public string AccountId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountHead { get; set; }
        public string AccountType { get; set; }
        public string HolderName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }

    }
    public class Settings
    {
        public string ProductBrand { get; set; }
        public string ProductGage { get; set; }
        public string ProductShape { get; set; }
        public string ShapeDetail { get; set; }
    }
    public class CompanyInfo
    {

        public string BusinessName { get; set; }
        public string TinNo { get; set; }
        public string Region { get; set; }

        public string Subcity { get; set; }
        public string Woreda { get; set; }
        public string HouseNo { get; set; }
        public string TelNo { get; set; }

        public string MobNo { get; set; }
    }
    public class Warehouse
    {
       
        public string WareName { get; set; }
        public string WareAddress { get; set; }
        public string WareManager { get; set; }

        public string WareManagerPhn { get; set; }
    }
    public class Shop
    {
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        
        public string ShopManagerPhn { get; set; }
    }
    public class Employee
    {
        public Employee()
        {

            EmpStatus = "Active";
            Busy = "False";
        }
        
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpAddress { get; set; }
        public string EmpType { get; set; }
        public string EmpPosition { get; set; }
        public decimal EmpSalary { get; set; }
        public string EmpSalaryType { get; set; }

        public DateTime EmpWrkStrdt { get; set; }
        public string EmpStatus { get; set; }
        public string Busy { get; set; }

    }
    public class Products
    {

        public string ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductShape { get; set; }
       
        public string ProductBrand { get; set; }
        public string ProductGage { get; set; }
       
        public decimal ProductUnitprice { get; set; }

   

    }

    public class Service
    {

        public string ServiceId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public decimal ServiceUnitprice { get; set; } 

    }

    public class WIPProduct
    {
        public WIPProduct()
        {

            TransactionType = "WIP";
           
        }

        public string WorkId { get; set; }
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public string ProductShape { get; set; }
        public double Quantity { get; set; }
        public string AssignEmp { get; set; }
        public string WorkSrtDt { get; set; }
        public string WorkFinDt { get; set; }
        public string TransactionType { get; set; }
    }
    public class RowMaterial
    {

        public string RMaterialId { get; set; }
        public string RMaterialName { get; set; }
        public string RMaterialBrand { get; set; }
        public string RMaterialGage { get; set; }
        public decimal RMaterialQty { get; set; }
        public decimal RMaterialwidth { get; set; }
        public decimal RMaterialMxMprice { get; set; }
        public string RMaterialWare { get; set; }

       
    }

    public class OAssets
    {
        public string AssetId { get; set; }
        public string AssetType { get; set; }
        public string AssetName { get; set; }
        public string AssetQty { get; set; }
        public string AssetBrand { get; set; }
        public double AssetUnitprice { get; set; }
    }
    public class Order
    {
        public Order()
    {
        //CurrentCost = 0;
        TransactionType = "O";
    }

        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string ProductBrand { get; set; }
        public string ProductGage { get; set; }
        public string ProductName { get; set; }
       
        public decimal ProductSize { get; set; }
       

        public string ProductShape{ get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Length { get; set; }
        public decimal CurrentCost { get; set; }
        public string TransactionType { get; set; }
        
        public string OrderBy { get; set; }
        
        public string CoppingSize { get; set; }
        public string SentBy { get; set; }
        public string OrderType { get; set; }
        public int spcificid { get; set; }

    }
    public class OrderTPrice
    {
        public OrderTPrice()
        {
            
        }
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
       
        public decimal TotalOPrice { get; set; }
        public decimal PrePaidPamount { get; set; }
        public decimal RemainingPamount { get; set; }
    }

    public class ManProducts
    {
        public ManProducts()
        {
            
            TransactionType = "WIP";
        }
      
        public string ManWId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductSize { get; set; }
        public string ProductShape { get; set; }
        public decimal Quantity { get; set; }
        public string WstartedDate { get; set; }
        public string WfinishDate { get; set; }
        public string AssignEmp { get; set; }
        public string TransactionType { get; set; }
     
        public string ProductBrand { get; set; }
        public string ProductGage { get; set; }
        public decimal Length { get; set; }
        public string CoppingSize { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone{ get; set; }
        public string Workshop { get; set; }
        public string Wstrby { get; set; }
    }
    public class Receive
    {
        public Receive()
        {
            CurrentCost = 0;
            TransactionType = "R";
        }

        public string ReceiveId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ManufId { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public Decimal UnitCost { get; set; }
        public Decimal CurrentCost { get; set; }
        public string TransactionType { get; set; }



    }

    public class SalesData
    {
        public SalesData()
        {
            TransactionType = "S";
        }

        public string SalesId { get; set; }
        public string SalesDate { get; set; }
       
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CurrentCost { get; set; }
        public string TransactionType { get; set; }


    }
    public class Supplier
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


    }

    public class Expense
    {
        public Expense()
        {
            //CurrentCost = 0;
            Status = "Requested";
        }


        public string ExpRecId { get; set; }
        public string ExpReason { get; set; }
        public string PayableTo { get; set; }
        public decimal Amount { get; set; }
        public string ExpNote { get; set; }
        public string ExpReqBy { get; set; }
        public string ExpRecDate { get; set; }
        public string Status { get; set; }
    }

    public class RMRequest
    {
        public RMRequest()
        {
            //CurrentCost = 0;
            Status = "Requested";
        }
        public string RMRecID { get; set; }
        public string RMBrand { get; set; }
        public string RMGage { get; set; }
        public string RecBy { get; set; }
        public decimal RMWidth { get; set; }
        public decimal RMLength { get; set; }
        public string RecDate { get; set; }
        public string Status { get; set; }
    }
}