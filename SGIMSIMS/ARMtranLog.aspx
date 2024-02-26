﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ARMtranLog.aspx.cs" Inherits="SGIMSIMS.ARMtranLog" EnableEventValidation="false"%>


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

    <style id="gridStyles" runat="server" type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    table
    {
        border: 1px solid #ccc;
        border-collapse: collapse;
    }
    table th
    {
        color: #0090CB;
        font-weight: bold;
    }
    table th, table td
    {
        padding: 5px;
        border: 1px solid #ccc;
    }
    table, table table td
    {
        border: 0px solid #ccc;
    }
    thead
    {
        display: table-header-group;
    }
    tfoot
    {
        display: table-footer-group;
    }
</style>

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
                            <li class="active">Row Material Counter</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
            <div class="animated fadeIn">
        <div class="row">
            
            <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                 <div class="card">
                            <div class="card-header">
                                <strong class="card-title">Search For Row Material Log<small><span class="badge badge-success float-right mt-1">Add Here</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                              

                                       <div class="row form-group">
                                                                <div class="col col-md-6">
                                                                 <asp:TextBox ID="TextBoxfromdt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>
                    
                                                                </div>
                                                                <div class="col-12 col-md-6">
                                                                    <asp:TextBox ID="TextBoxtodt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>
                    
                                                                </div>
                                                            </div>

                                                            <div class="row form-group">
                                                                <div class="col col-md-6"><label for="hf-password" class=" form-control-label">Row Material Brand</label></div>
                                                                <div class="col-12 col-md-6">
                                                                    <asp:DropDownList runat="server" ID="DropDownListprobrand"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadbrandgages">
                                                                        </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <div class="col col-md-6"><label for="hf-password" class=" form-control-label">Row Material Gage</label></div>
                                                                <div class="col-12 col-md-6">
                                                                      <asp:DropDownList runat="server" ID="DropDownListprogage"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                        </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="row form-group">
                                                                <div class="col col-md-6"><label for="hf-password" class=" form-control-label">WareHouse Name</label></div>
                                                                <div class="col-12 col-md-6">
                                                                  <asp:DropDownList runat="server" ID="DropDownListwarehouse"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                        </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                             

                              <div class="row form-group">
                                  <div class="col col-md-4 ">
                                                               <label for="hf-password" class=" form-control-label">Please Select Search Criteria</label>    
                                                                </div>
                                  <div class="col col-md-8 ">
                                       <asp:RadioButtonList ID="RadioButtonListsrchrmtran" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="110%" OnSelectedIndexChanged="radiobtnelectedindexchg">
                                           <asp:ListItem>All</asp:ListItem>
                                                                        <asp:ListItem>By RowMaterial</asp:ListItem>
                                                                        <asp:ListItem>By WareHouse</asp:ListItem>
                                                                        <asp:ListItem>Sent By Admin</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                      </div>
                                
                                   </div>
                                                 

                                                         
                                                          
                                
                                                           <div class="row form-group">
                                                                <div class="col-12 col-md-4">
                                                                   
                                                                </div>
                                                                <div class="col col-md-4">
                                                         <asp:Button ID="Buttaddpmat"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="SEARCH" OnClick="search"  />        
                                                             
                                                                    </div>
                                                              
                                                               <div class="col-12 col-md-4">
                                                                   <asp:Button ID="btnPrintAll" runat="server" cssclass="btn btn-sm btn-info btn-block"  Text="Export RowMaterial Log" OnClick="print" />
                                                                </div>
                                                            </div>
                               
                                                    </div>
                                    <div id="divMessage" class="col-8 alert with-close alert-danger alert-dismissible fade show" runat="server" style="display:none; visibility:hidden">
                                        <span class="badge badge-pill badge-danger">Alert</span>
                                         <asp:Label ID="Labelalertonbtntopr" runat="server"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                    </div>
                        </div>

</div></section></div>
                              
            </div>

                 <div class="col-lg-12">
                        
                        <section  class="card">
                            <div class="card-header">
                                <strong class="card-title">Row Material Transaction Log<small><span class="badge badge-success float-right mt-1">Total Amount
                                    <asp:Label ID="Labeltotalprodt" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block">
                               
                                <asp:GridView ID="GridViewmatlst" runat="server" Cssclass="table table-striped"  PageSize="8" OnPageIndexChanging="Loadmatlstpage" AutoGenerateColumns="false"  OnSelectedIndexChanged="GridViewmatlst_SelectedIndexChanged" AllowPaging="True">

<Columns>
   						
        <asp:BoundField DataField="RecBy" HeaderText="RequestedBy" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Warehousefrm" HeaderText="Warehousefrom" ItemStyle-Width="120px"/>
        <asp:BoundField DataField="RMBrand" HeaderText="RMBrand" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="RMGage" HeaderText="RMGage" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="RMWidth" HeaderText="RMWidth" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="RMLength" HeaderText="RMLength" ItemStyle-Width="100px"/>
     <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" ItemStyle-Width="100px"/>
    </Columns>
                                    
                                   <%-- <PagerTemplate>
                                        
                                        <header> <br />Log Report<br /> </header>
                                        <footer>  </br> <hr /> Page <br /></footer>
                                    </PagerTemplate>--%>
                                    
                                   
      
                                </asp:GridView>
                                 
                            </div>
                        </section>
                    </div>

            </div>
             

        </div> <!-- .content -->
    </div><!-- /#right-panel -->
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
    <script type="text/javascript">
    function PrintGrid(html, css) {
        var printWin = window.open('', '', 'left=0,top=0,width=900,height=600,scrollbars=1');
        printWin.document.write('<style type = "text/css">' + css + '</style>');
        printWin.document.write(html);
       printWin.document.close();
        printWin.focus();
       printWin.print();
        printWin.close();
    };
</script>

</body>

</html>



