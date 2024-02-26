<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AAddPro.aspx.cs" Inherits="SGIMSIMS.AAddPro" %>


<!doctype html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="en">
<!--<![endif]-->

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>SGIMIMS</title>
    <meta name="description" content=" ">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="apple-icon.png">
    <link rel="shortcut icon" href="favicon.ico">


    <link rel="stylesheet" href="vendors/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendors/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="vendors/themify-icons/css/themify-icons.css">
    <link rel="stylesheet" href="vendors/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" href="vendors/selectFX/css/cs-skin-elastic.css">

    <link rel="stylesheet" href="assets/css/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>



</head>

<body>
    <!-- Left Panel -->
    <form runat="server">
     <aside id="left-panel" class="left-panel">
        <nav class="navbar navbar-expand-sm navbar-default">

            <div class="navbar-header">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu" aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fa fa-bars"></i>
                </button>
                 <a class="navbar-brand" href="./"><img src="images/logo.png" alt="Logo"></a>
                <a class="navbar-brand hidden" href="./"><img src="images/logo2.png" alt="Logo"></a>
            </div>

            <div id="main-menu" class="main-menu collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li class="active">
                        <a href="admin.aspx"> <i class="menu-icon fa fa-dashboard"></i>Dashboard </a>
                    </li>
                    <h3 class="menu-title">Manage </h3><!-- /.menu-title -->
                    <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="menu-icon fa fa-home"></i> System Configuration</a>
                        <ul class="sub-menu children dropdown-menu">
							<li><i class="fa fa-bars"></i><a href="ACompInfo.aspx">Company Information</a></li>
                            <li><i class="fa fa-bars"></i><a href="AWareInfo.aspx">WareHouse</a></li>
                            <li><i class="fa fa-bars"></i><a href="AShopinfo.aspx">Shops</a></li>
                            
                             <li><i class="fa fa-bars"></i><a href="AEmpTAPosn.aspx">Supliers</a></li>
                             <li><i class="fa fa-bars"></i><a href="ASetting.aspx">Setting</a></li>
                             <li><i class="fa fa-bars"></i><a href="ABankAccount.aspx">BankAccount</a></li>
                         
                        </ul>
                    </li>
                    <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i class="menu-icon fa fa-plus-square"></i>Manage Users</a>
                        <ul class="sub-menu children dropdown-menu">
                          <li><i class="menu-icon fa fa-th"></i><a href="ACrtSysUsr.aspx">Create Users</a></li>
                        </ul>
                    </li>
					 <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i class="menu-icon  fa fa-book"></i>Manage Product</a>
                        <ul class="sub-menu children dropdown-menu">
					   <li><i class="fa fa-share-square-o"></i><a href="AAddPro.aspx">Add Product</a></li>
                       <li><i class="fa fa-share-square-o"></i><a href="AAddSer.aspx">Add Service</a></li>
                        
                        </ul>
                    </li>
					
					   <li class="menu-item-has-children dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <em class="menu-icon fa fa-laptop"></em>Manage RowMaterial</a>
					     <ul class="sub-menu children dropdown-menu">
					     <li><i class="fa fa-share-square-o"></i><a href="AAddRowMat.aspx">Add RowMaterial </a></li>
                         <li><i class="fa fa-share-square-o"></i><a href="ASndRowMat.aspx">RowMaterial Requests </a></li>  
                         <li><i class="fa fa-share-square-o"></i><a href="ARMtranLog.aspx">RowMaterial Log </a></li>
                        </ul>
                    </li>
					  <li class="fa fa-table">
                        <a href="AManEmployee.aspx"> <i class="menu-icon fa fa-table"></i>Manage Employee</a>
                       
                    </li> 
					                  
                   
					 <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i class="menu-icon fa fa-dollar"></i>Manage Money</a>
                        <ul class="sub-menu children dropdown-menu">
                           
                             <li><i class="menu-icon fa fa-th"></i><a href="ARevenueList.aspx">Revenue And Expense</a></li>
                          
                             <li><i class="menu-icon fa fa-th"></i><a href="AExpReqList.aspx">Expense Request</a></li>
                              
                            <li><i class="menu-icon fa fa-th"></i><a href="ATransLog.aspx">Manage Sale</a></li>
                            <li><i class="menu-icon fa fa-th"></i><a href="AManPurchase.aspx">Manage Purchase</a></li>

                        </ul>
                    </li>
 
					 
                    <h3 class="menu-title">Data</h3><!-- /.menu-title -->

                                  
                    <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <i class="menu-icon fa fa-bar-chart"></i>Report</a>
                        <ul class="sub-menu children dropdown-menu">
                            <li><i class="menu-icon fa fa-line-chart"></i><a href="ADayRpt.aspx">View Daily Report</a></li>
                            <li><i class="menu-icon fa fa-area-chart"></i><a href="AGenRpt.aspx">Periodic Report</a></li>
                             <li><i class="menu-icon fa fa-th"></i><a href="ADayExpense.aspx">Stastics</a></li>
                        </ul>
                    </li>

                    
                    <h3 class="menu-title">Extras</h3><!-- /.menu-title -->
                    <li class="fa fa-table">
                        <a href="AInvLog.aspx"> <i class="menu-icon fa fa-table"></i>Inventory Counter</a>
                       
                    </li>
                   
					
					
                </ul>
            </div><!-- /.navbar-collapse -->
        </nav>
    </aside><!-- /#left-panel -->

    <!-- Right Panel -->

    <div id="right-panel" class="right-panel">

        <!-- Header-->
        <header id="header" class="header">

            <div class="header-menu">

                <div class="col-sm-7">
                    <a id="menuToggle" class="menutoggle pull-left"><i class="fa fa fa-tasks"></i></a>
                    <div class="header-left">
                        <button class="search-trigger"><i class="fa fa-search"></i></button>
                        <div class="form-inline">
                            <form class="search-form">
                                <input class="form-control mr-sm-2" type="text" placeholder="Search ..." aria-label="Search">
                                <button class="search-close" type="submit"><i class="fa fa-close"></i></button>
                            </form>
                        </div>

                        <div class="dropdown for-notification">
                            <button class="btn btn-secondary dropdown-toggle" type="button" id="notification" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fa fa-bell"></i>
                                <span class="count bg-danger">5</span>
                            </button>
                           
                        </div>

                        
                    </div>
                </div>

                <div class="col-sm-5">
                    <div class="user-area dropdown float-right">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img class="user-avatar rounded-circle" src="images/admin.jpg" alt="User Avatar">
                        </a>

                        <div class="user-menu dropdown-menu">
                            <a class="nav-link" href="#"><i class="fa fa-user"></i> My Profile</a>

                           
                            <a class="nav-link" href="#"><i class="fa fa-cog"></i> Change Password</a>

                            <a class="nav-link" href="#"><i class="fa fa-power-off"></i><asp:Button ID="Buttonlogout" class="btn btn-link btn-sm" runat="server" Text="Logout" OnClick="Logout" /></a>
                        </div>
                    </div>

                  

                </div>
            </div>

        </header><!-- /header -->
        <!-- Header-->

        <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Dashboard/ <asp:Label ID="Labelsession" runat="server"  Text="Label"></asp:Label></h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Admin</a></li>
                            <li class="active">CreateProducts</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="col-sm-12">
              <div class="card bg-secondary">
                            <div class="card-body">
                                <div class="row">
                                          <div class="col-lg-3"> </div>
                                    <div class="col-lg-3">
                       
                       <asp:Button ID="Buttaddnewpro" runat="server" class="btn btn-secondary btn-sm btn-block" Text="አዲስ ምርት መመዝገቢያ " OnClick="showaddproduct" />
                    </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butudtprice" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የምርት ዋጋ ማሻሻያ" OnClick="showupdateproduct" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
        <div class="row" >
            
            <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                 <div class="card" id="addproduct" runat="server" style="display:none; visibility:hidden">
                            <div class="card-header">
                                <strong class="card-title">Add Product <small><span class="badge badge-success float-right mt-1">Add Here</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                               
                                                          
                                                            <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">ProductType</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:DropDownList runat="server" ID="DropDownListprotype"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex">
                                                                         <asp:ListItem Value="0">--Select Product Type--</asp:ListItem>
                                                                         <asp:ListItem>Ordered</asp:ListItem>
                                                                         <asp:ListItem>Pre-Manufucture</asp:ListItem>
                                                                         <asp:ListItem>Purchased</asp:ListItem>
                                                                     </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">ProductID</label></div>
                                                                <div class="col-12 col-md-5">
                                                                     <asp:TextBox ID="TextBoxproid" runat="server" placeholder="Enter Product ID..." cssclass="form-control-sm form-control" Enabled="false"></asp:TextBox>
                                                                </div>
                                       <div class="col col-md-4 ">
                                               <asp:Button ID="Buttproid"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Add Product ID" OnClick="Genproductid"  />        
                                                           
                                       </div>
                                                            
                                                            </div>
                                                             <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">ProductName</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:TextBox ID="TextBoxproname" runat="server" placeholder="Enter Product Name..." cssclass="form-control-sm form-control"></asp:TextBox>
                                                              
                                                                </div>
                                                            </div>

                                <div id="all"   runat="server" style="display:none; visibility:hidden">

                                                         <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">ProductPrice</label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxproprice" runat="server" placeholder="Enter Product Price..." class="form-control-sm form-control"></asp:TextBox>
                                                               <asp:RegularExpressionValidator ID="RegularExpreprosize" runat="server" ControlToValidate="TextBoxproprice" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                    <div id="matneed" runat="server" class ="row form-group" style="display:none; visibility:hidden">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">Estimated Material Need</label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxamtneed" runat="server" placeholder="Enter Material Need In M2" class="form-control-sm form-control"></asp:TextBox>
                                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxamtneed" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                             
                                                                </div>
                                                            </div>
                                     <div class="row form-group">
                                          <div class="col-12 col-md-3"></div>
                                         <div class="col-12 col-md-9">
                                     <asp:DropDownList runat="server" ID="DropDownListselltype"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex" Visible="False">
                                                                         <asp:ListItem Value="0">--Select Sell Type--</asp:ListItem>
                                                                         <asp:ListItem>Unit</asp:ListItem>
                                                                         <asp:ListItem>Packed</asp:ListItem>
                                                                       
                                                                     </asp:DropDownList>
                                             </div>
                                         </div>
                                     <div class="row form-group">
                                                                <div class="col col-md-3"><asp:Label ID="Labelpurproqty" runat="server" class=" form-control-label" Text="Product Quantity"></asp:Label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxpurproqty" runat="server" placeholder="Enter Product Quantity..." class="form-control-sm form-control" Visible="False"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxpurproqty" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                </div>
                                                            </div>
                                     <div class="row form-group">
                                         <div class="col-12 col-md-3"></div>
                                         <div class="col-12 col-md-9">
                                    <asp:DropDownList runat="server" ID="DropDownListselestore"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex" Visible="False">
                                                                        
                                                                       
                                                                     </asp:DropDownList></div></div>
                                     <div class="row form-group">
                                                                <div class="col col-md-3"><asp:Label ID="Label2" runat="server" class=" form-control-label" Text="Supplier Name"></asp:Label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxsuppname" runat="server" placeholder="Enter Supplier Name..." class="form-control-sm form-control" ></asp:TextBox>
                                              
                                                                </div>
                                                            </div>
                                      <div class="row form-group">
                                                                <div class="col col-md-3"><asp:Label ID="Label1" runat="server" class=" form-control-label" Text="Supplier Price"></asp:Label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxsupprice" runat="server" placeholder="Enter Supplier Price..." class="form-control-sm form-control" ></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxsupprice" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                </div>
                                                            </div>
                                     <div class="row form-group">
                                         <div class="col-12 col-md-3"></div>
                                         <div class="col-12 col-md-9">
                                    <asp:DropDownList runat="server" ID="DropDownLispaymentype"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex" >
                                                                         <asp:ListItem Value="0">--Select Payment Type--</asp:ListItem>
                                                                         <asp:ListItem>Cash</asp:ListItem>
                                                                         <asp:ListItem>Bank Transfer</asp:ListItem>
                                                                      <asp:ListItem>Credit</asp:ListItem>
                                                                       
                                                                     </asp:DropDownList></div></div>
                                     <div class="row form-group">
                                                                    <div class="col-5">
                                                                        <asp:Label ID="Label3" runat="server" Text="Additional Note"></asp:Label>
                                                                    </div>
                                                                         <div class="col-7">
                                                                             <asp:TextBox ID="TextBoxnote" placeholder="ተጨማሪ ማብራሪያና ማስታዎሻ እዚህ ያስቀምጡ።"  Cssclass="form-control-sm form-control" runat="server" TextMode="MultiLine"></asp:TextBox></div>
                                                                   
                                                               </div>


                                </div>
                                                         
                                                          

                                                           <div class="row form-group">
                                                                <div class="col col-md-4">
                                                          
                                                                    </div>
                                                                <div class="col-12 col-md-4">
                                                                     <asp:Button ID="Buttaddpro"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Add" OnClick="addpro"  />        
                                                           
                                                              </div>
                                                               <div class="col-12 col-md-4">
                                                                     <asp:Button ID="Butdel"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Delete" OnClick="dltpro"  />        
                                                           
                                                              </div>
                                                            </div>
                              
                                                    </div>
                                    </div> 
                                 <div class="card" id="udtprice" runat="server" style="display:none; visibility:hidden">
                            <div class="card-header">
                                <strong class="card-title">Update Product Price<small><span class="badge badge-success float-right mt-1">Add Here</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                                  <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">ProductType</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:DropDownList runat="server" ID="DropDownListudtprotype"  cssclass="form-control-sm form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="udtTypeSelectedIndex">
                                                                         <asp:ListItem Value="0">--Select Product Type--</asp:ListItem>
                                                                     
                                                                         <asp:ListItem>Pre-Manufucture</asp:ListItem>
                                                                         <asp:ListItem>Purchased</asp:ListItem>
                                                                     </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                  <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">Product Name</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:DropDownList runat="server" ID="DropDownListudtprolist"  cssclass="form-control-sm  form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex">
                                                                         
                                                                     </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                 <div class="row form-group">
                                         <div class="col-12 col-md-3"></div>
                                         <div class="col-12 col-md-9">
                                    <asp:DropDownList runat="server" ID="DropDownListshoplst"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeSelectedIndex" Visible="False">
                                                                        
                                                                       
                                                                     </asp:DropDownList></div></div>
                                                             <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">New Product Price</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:TextBox ID="TextBoxudtprice" runat="server" placeholder="Enter New Product Price..." cssclass="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxudtprice" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                </div>
                                                            </div>
                                 <div class="row form-group">
                                                                <div class="col col-md-4">
                                                        
                                                                    </div>
                                                                <div class="col-12 col-md-4">
                                                             <asp:Button ID="Butudtpro"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Update Price" OnClick="udtpro"  />        
                                                                </div>
                                                               <div class="col-12 col-md-4">
                                                              </div>
                                                            </div>

                           </div></div>

                                 <div class="row form-group">
                                    <div class="col col-md-2"></div>
                                   <div class="col col-md-8">
                                        <div id="divMessage" class="alert with-close alert-danger alert-dismissible fade show" runat="server" style="display:none; visibility:hidden">
                                        <span class="badge badge-pill badge-danger">Alert</span>
                                         <asp:Label ID="Labelalertonbtntopr" runat="server"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                    </div>
                                   </div>
                                   <div class="col col-md-2"></div>
                                   
                                  
                               </div>
                        </div>
                            </section>
         </div>

        </div>
                       
              

                 <div class="col-lg-12">
                        
                        <section  class="card">
                            <div class="card-header">
                                <strong class="card-title">Product List <small><span class="badge badge-success float-right mt-1">Total Products
                                    <asp:Label ID="Labeltotalprodt" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block">
                               
                                <asp:GridView ID="GridViewprolst" runat="server" CssClass="table table-striped" PageSize="4" OnPageIndexChanging="Loadprodpage" OnSelectedIndexChanged="Loadproductlst" AllowPaging="True" >

                                       <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ዝርዝር አውጣ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>

                                            
                                         </Columns>


                                </asp:GridView>
                           
                                
                            </div>
                        </section>
                    </div>

            </div>
             </div><!-- .content -->

        </div> 
   
    </form>
    <!-- Right Panel -->

    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>


    <script src="vendors/chart.js/dist/Chart.bundle.min.js"></script>
    <script src="assets/js/dashboard.js"></script>
    <script src="assets/js/widgets.js"></script>
    <script src="vendors/jqvmap/dist/jquery.vmap.min.js"></script>
    <script src="vendors/jqvmap/examples/js/jquery.vmap.sampledata.js"></script>
    <script src="vendors/jqvmap/dist/maps/jquery.vmap.world.js"></script>
    <script>
        (function($) {
            "use strict";

            jQuery('#vmap').vectorMap({
                map: 'world_en',
                backgroundColor: null,
                color: '#ffffff',
                hoverOpacity: 0.7,
                selectedColor: '#1de9b6',
                enableZoom: true,
                showTooltip: true,
                values: sample_data,
                scaleColors: ['#1de9b6', '#03a9f5'],
                normalizeFunction: 'polynomial'
            });
        })(jQuery);
    </script>

</body>

</html>


