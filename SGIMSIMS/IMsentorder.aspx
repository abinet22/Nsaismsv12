﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IMsentorder.aspx.cs" Inherits="SGIMSIMS.IMsentorder" %>



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
    <link rel="stylesheet" href="vendors/jqvmap/dist/jqvmap.min.css">


    <link rel="stylesheet" href="assets/css/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>

</head>

<body>

    <form runat="server">
    <!-- Left Panel -->

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
                        <a href="inventorymanagermain.aspx"> <i class="menu-icon fa fa-dashboard"></i>Dashboard </a>
                    </li>
                    <h3 class="menu-title">Manage </h3><!-- /.menu-title -->
				
					<li class="fa fa-table">
                        <a href="IMsentorder.aspx" > <i class="menu-icon fa fa-table"></i>አዲስ ትዕዛዝ ማስተዳደሪያ  </a>
                        
                    </li>
                    
                     <li class="menu-item-has-children dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <em class="menu-icon fa fa-laptop"></em>ነባር ትዕዛዞች ማስተዳደሪያ </a>
					     <ul class="sub-menu children dropdown-menu">
					<li><i class="menu-icon fa fa-table"></i><a href="IMAssignEmpToorder.aspx" > ሰራትኛና ስራ መመደቢያ  </a></li>
                     <li><i class="menu-icon fa fa-table"></i><a href="IMrecivedFinProOrd.aspx" > ያለቁ ስራዎች መቀበያ </a></li>  
					 <li><i class="menu-icon fa fa-table"></i><a href="IMSentFinProOrd.aspx" > ያለቁ ስራዎች መላኪያ </a></li> 
                        </ul>
                    </li>
                   
                     <li class="menu-item-has-children dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"> <em class="menu-icon fa fa-laptop"></em>የማምረቻ ቦታ ማስተዳደሪያ</a>
					     <ul class="sub-menu children dropdown-menu">
					
                    
					 <li><i class="fa fa-share-square-o"></i><a href="IAddPreMan.aspx">የምርት መመዝገቢያ </a></li> 
                     <li><i class="fa fa-share-square-o"></i><a href="IMEmpRegister.aspx">የሰራተኛ መመዝግቢያ</a></li> 
                        </ul>
                    </li>

                   
                    <h3 class="menu-title">Reports</h3><!-- /.menu-title -->

                    <li class="fa fa-table">
                        <a href="IMreports.aspx" > <i class="menu-icon fa fa-bar-chart"></i>ሪፖርት </a>
                        
                    </li>
                   
                                       
                    <h3 class="menu-title">Extras</h3><!-- /.menu-title -->
                    <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="menu-icon fa fa-home"></i> የጥሬ ዕቃ ማስተላለፊያ</a>
                        <ul class="sub-menu children dropdown-menu">
							<li>  <i class="menu-icon fa fa-bar-chart"></i>  <a href="IMRequest.aspx" >የጥሬ ዕቃ መጠየቂያ</a></li>
                            <li> <i class="menu-icon fa fa-bar-chart"></i>   <a href="IMAccept.aspx" > የጥሬ ዕቃ መቀበያ</a></li>
                               <li>  <i class="menu-icon fa fa-bar-chart"></i><a href="IMSend.aspx" > የጥሬ ዕቃ መላኪያ</a></li>
                           
                    
                         
                        </ul>
                    </li>
                    <li class="fa fa-table">
                   
                    </li>
                        </ul>
                   
					
                 
            </div><!-- /.navbar-collapse -->
        </nav>
    </aside><!-- /#left-panel -->


    <!-- Left Panel -->

    <!-- Right Panel -->

    <div id="right-panel" class="right-panel">

        <!-- Header-->
        <header id="header" class="header">

            <div class="header-menu">

                <div class="col-sm-7">
                    <a id="menuToggle" class="menutoggle pull-left"><i class="fa fa fa-tasks"></i></a>
                    <div class="header-left">
                       
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
                        <h1>Dashboard/  <asp:Label ID="Labelsession" runat="server" Text="Label"></asp:Label></h1>
                        
                    </div>
                </div>
            </div>
			
		
            <div class="col-sm-8">
                <div class="page-header float-right">
                    	<div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Inventory Manager Admin</a></li>
                            <li class="active">Recieve New Order</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
 <div class="col-sm-12">
                <div class="sufee-alert alert with-close alert-danger alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-danger">Alert</span> በአጠቃላይ  
                     <asp:Label ID="Labelneworder" class="card-title" runat="server" Text=" "></asp:Label>
                     ትዕዛዞች ተልከዋል። ትዕዛዞችን በመቀበል ወደ ስራ ያስገቡ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
         <div class="col-lg-12">
                     
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">አዲስ የተላኩ ትዕዛዞች ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">አጠቃላይ አዲስ የትዕዛዞች ብዛት: <asp:Label ID="LabeltotalnewOrders" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">

                                <asp:GridView ID="GridViewRecNewOrder" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="LoadRecNxtOrderpage" OnSelectedIndexChanged="RecOrderSentNot" AllowPaging="True" OnRowDataBound="width" width="1850px" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ትዕዛዝ ተቀበል" ></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                            </div>
                              
                                     
                             
                        </section>
                   
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

</body>

</html>

