<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACompInfo.aspx.cs" Inherits="SGIMSIMS.ACompInfo" %>



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
                            <div class="dropdown-menu" aria-labelledby="notification">
                                <p class="red">You have 3 Notification</p>
                                <a class="dropdown-item media bg-flat-color-1" href="#">
                                <i class="fa fa-check"></i>
                                <p>Server #1 overloaded.</p>
                            </a>
                                <a class="dropdown-item media bg-flat-color-4" href="#">
                                <i class="fa fa-info"></i>
                                <p>Server #2 overloaded.</p>
                            </a>
                                <a class="dropdown-item media bg-flat-color-5" href="#">
                                <i class="fa fa-warning"></i>
                                <p>Server #3 overloaded.</p>
                            </a>
                            </div>
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
                        <h1>Dashboard/ <asp:Label ID="Labelsession" runat="server" Text="Label"></asp:Label></h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Admin</a></li>
                            <li class="active">Add Conmany Info</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
            <div class="animated fadeIn">

                 <div class="row">
                    <div class="col-md-8 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                  <div class="card">
                                                        <div class="card-header">Enter Company Information</div>
                                                        <div class="card-body card-block">
                                                            
                                                               <div class="form-group">
				                                               <div class="input-group">
                                                                       
                                                                         <asp:TextBox ID="TextBoxBussName" runat="server" Placeholder="Enter Bussiness Name" cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                  
                                                                 
                                                                        <div class="input-group-addon"><i class="fa fa-briefcase"></i></div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="input-group">
                                                                          
                                                                          <asp:TextBox ID="TextBoxTin" runat="server" Placeholder="Enter TIN Number" cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                     
                                                                        <div class="input-group-addon"><i class="fa fa-plus-square"></i></div>
                                                                    </div>
                                                                </div>
																<div class="form-group">
                                                                    <div class="input-group">
                                                                       
                                                                          <asp:TextBox ID="TextBoxRegion" runat="server" Placeholder="Enter Region" cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                     
                                                                        <div class="input-group-addon"><i class="fa fa-asterisk"></i></div>
                                                                    </div>
                                                                </div>
																<div class="form-group">
                                                                    <div class="input-group">
                                                                        
                                                                          <asp:TextBox ID="TextBoxSubCity" runat="server" Placeholder="Enter Zone/Sub CIty" cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                      
                                                                        <div class="input-group-addon"><i class="fa fa-asterisk"></i></div>
                                                                    </div>
                                                                </div>
																<div class="form-group">
                                                                    <div class="input-group">
                                                                      
                                                                          <asp:TextBox ID="TextBoxWoreda" runat="server" Placeholder="Enter Woreda" cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                
                                                                        <div class="input-group-addon"><i class="fa fa-asterisk"></i></div>
                                                                    </div>
                                                                </div>
																<div class="form-group">
                                                                    <div class="input-group">
                                                                       
                                                                          <asp:TextBox ID="TextBoxHsno" runat="server" Placeholder="House No." cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                
                                                                        <div class="input-group-addon"><i class="fa fa-asterisk"></i></div>
                                                                    </div>
                                                                </div>
																<div class="form-group">
                                                                    <div class="input-group">
                                                                    
                                                                          <asp:TextBox ID="TextBoxTelno" runat="server" Placeholder="Tel No." cssclass="form-control-sm form-control" ></asp:TextBox>
                                                                        <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="input-group">
                                                                        
                                                                          <asp:TextBox ID="TextBoxMobno" runat="server" Placeholder="Mobile No." CssClass="form-control-sm form-control" ></asp:TextBox>
                                                              
                                                                        <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                                                    </div>
                                                                </div>
                                                                <div class="row form-group">
                                                                    <div class="col-lg-6"></div>
                                                                   
                                                                 <div class="col-lg-6">  <asp:Button ID="Buttonsaveci"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Save" OnClick="savecompanyinfo"  />
                                                                 </div>
                                                                </div> 
                                                     
                                                            </div>
                                                    </div>
                                
                            </div>
                        </section>
                    </div>
                </div>
                                                              
				
				                                         
                                        </div><!-- .animated -->
                                    </div><!-- .content -->
                                </div><!-- /#right-panel -->
                                <!-- Right Panel -->

        </form>
                            <script src="vendors/jquery/dist/jquery.min.js"></script>
                            <script src="vendors/popper.js/dist/umd/popper.min.js"></script>

                            <script src="vendors/jquery-validation/dist/jquery.validate.min.js"></script>
                            <script src="vendors/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>

                            <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
                            <script src="assets/js/main.js"></script>
</body>
</html>

