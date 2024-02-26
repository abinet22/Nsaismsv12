﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMreports.aspx.cs" Inherits="SGIMSIMS.SMreports" %>


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
    <meta name="description" content="">
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
                        <a href="salesmanagermain.aspx"> <i class="menu-icon fa fa-dashboard"></i>Dashboard </a>
                    </li>
                    <h3 class="menu-title">Manage </h3><!-- /.menu-title -->
				
					
                     <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="menu-icon fa fa-home"></i> ያለቁ ትዕዛዞች ማስተዳደሪያ</a>
                        <ul class="sub-menu children dropdown-menu">
						
                            <li><i class="fa fa-bars"></i><a href="SMFinProList.aspx">ያለቀ ትዕዛዝ ዝርዝር</a></li>
                            <li><i class="fa fa-bars"></i><a href="SMrecieveproduct.aspx">የተላከ ትዕዛዝ መቀበያ</a></li>
                         
                        </ul>
                    </li>
					
                  
                    <li class="fa fa-table">
                        <a href="SMorderedproduct.aspx"> <i class="menu-icon fa fa-table"></i>አዲስ ትዕዛዝ ማስተዳደሪያ</a>
                       
                    </li>
                    
                     <li class="fa fa-table">
                        <a href="SMRegister.aspx"> <i class="menu-icon fa fa-bar-chart"></i>ያለ ትዕዛዝ የተመረቱ ምርቶች ማስተዳደሪያ</a>
                        
                    </li>
                    <li class="fa fa-table">
                        <a href="SMsales.aspx"> <i class="menu-icon fa fa-bar-chart"></i>የሽያጭ ማስተዳደሪያ</a>
                        
                    </li>
                  
                   

                    <h3 class="menu-title">Reports</h3><!-- /.menu-title -->

                    <li class="fa fa-table">
                        <a href="SMreports.aspx"> <i class="menu-icon fa fa-bar-chart"></i>ሪፖርት</a>
                        
                    </li>
                   
                                       
                    <h3 class="menu-title">Extras</h3><!-- /.menu-title -->
                     <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="menu-icon fa fa-home"></i> የጥሬ ዕቃ ማስተላለፊያ</a>
                        <ul class="sub-menu children dropdown-menu">
							<li><i class="menu-icon fa fa-bar-chart"></i>  <a href="SMRequest.aspx" >የጥሬ ዕቃ መጠየቂያ</a></li>
                            <li><i class="menu-icon fa fa-bar-chart"></i> <a href="SMAccept.aspx" >የጥሬ ዕቃ መቀበያ</a></li>
                               <li>  <i class="menu-icon fa fa-bar-chart"></i><a href="SMSend.aspx" > የጥሬ ዕቃ መላኪያ</a></li>
                         
                         
                        </ul>
                    </li>
                   
                       <li class="menu-item-has-children dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="menu-icon fa fa-home"></i> የወጪ ማስተዳደሪያ</a>
                        <ul class="sub-menu children dropdown-menu">
							<li><i class="menu-icon fa fa-bar-chart"></i>  <a href="SMERequest.aspx" > የወጪ መጠየቂያ</a></li>
                            <li><i class="menu-icon fa fa-bar-chart"></i> <a href="SMEAccept.aspx" > የተፈቀዱ ወጪዎች መመልከቻ</a></li>
                            
                        </ul>
                    </li>
                   <li class="fa fa-table">
                        <a href="SMCheckInvent.aspx"> <i class="menu-icon fa fa-bar-chart"></i> ምርትና ዕቃዎች መመልከቻ</a>
                        
                    </li>
                        <li class="fa fa-table">
                        <a href="SMInvLog.aspx"> <i class="menu-icon fa fa-table"></i>የጥሬ ዕቃ መቁጠሪያ</a>
                       
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

                            <a class="nav-link" href="#"><i class="fa fa-power-off"></i> <asp:Button ID="Buttonlogout" class="btn btn-link btn-sm" runat="server" Text="Logout" OnClick="Logout" /></a>
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
                        <h1>Dashboard/
                             <asp:Label ID="Labelsession" runat="server" Text="Label"></asp:Label></h1>
                    </div>
                </div>
            </div>
			
		
            <div class="col-sm-8">
                <div class="page-header float-right">
                    	<div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li>Sales Admin</li>
							<li class="active">Reports</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">

             <div class="row">
            
            <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                 <div class="card">
                            <div class="card-header">
                                <strong class="card-title">የሽያጭ ቀን ይምረጡ።<small><span class="badge badge-success float-right mt-1">Add Here</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                              
                                                            <div class="row form-group">
                                                                <div class="col col-md-6">
                                                                 <asp:TextBox ID="TextBoxfromdt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>
                                                          <small class="text-muted text-uppercase font-weight-bold">የመጀመሪያ ቀን</small>                                                                </div>
                                                                <div class="col-12 col-md-6">
                                                                    <asp:TextBox ID="TextBoxtodt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>
                    <small class="text-muted text-uppercase font-weight-bold">የመጨረሻ ቀን</small> 
                                                                </div>
                                                            </div>
                             
                                
                                                           <div class="row form-group">
                                                               <div class="col col-md-4">
                                                         <asp:Button ID="Buttaddpmat"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ሪፖርት አሳይ" OnClick="peiodicsearch"  />        
                                                             
                                                                 
                                                         
                                                                    </div>
                                                               <div class="col-12 col-md-4">
                                                                  <asp:Button ID="Buttaddpmat0"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Export Row Material Sale" OnClick="exportrowmaterialsale"  />        
                                                               
                                                                </div>
                                                               
                                                              
                                                               <div class="col-12 col-md-4">
                                                                   <asp:Button ID="Buttaddpmat1"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="Export All Sales" OnClick="exportallsales"  />        
                                                             
                                                                </div>
                                                            </div>
                               
                                                    </div>
                                    <div id="div1" class="col-8 alert with-close alert-danger alert-dismissible fade show" runat="server" style="display:none; visibility:hidden">
                                        <span class="badge badge-pill badge-danger">Alert</span>
                                         <asp:Label ID="Label2" runat="server"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                    </div>
                        </div>

</div></section></div>
                              
            </div>
            <div class="col-sm-12 mb-4">
                    <div class="card-group">
            <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                        <i class="fa fa-users"></i>
                    </div>

                    <div class="h4 mb-0">
                        <span class="count">
                            <asp:Label ID="Labeltotalnewcustomer" runat="server" Text="Label"></asp:Label></span>
                    </div>

                    <small class="text-muted text-uppercase font-weight-bold">የደንበኛ ብዛት</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-1" style="width: 40%; height: 5px;"></div>
                </div>
            </div>
             <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                        <i class="fa fa-pie-chart"></i>
                    </div>
                    <div class="h4 mb-0">
                      <asp:Label ID="Labelnoordsale" runat="server" Text="Label"></asp:Label>
                        <small class="text-muted"> , </small> <asp:Label ID="Labelnosalecount" runat="server" Text="Label"></asp:Label> 
                    </div>
                    <small class="text-muted text-uppercase font-weight-bold">የትዕዛዝ/ሽያጭ ብዛት</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-4" style="width: 40%; height: 5px;"></div>
                </div>
            </div>
                        <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                  <i class="fa fa-minus-square"></i> 
                    </div>
                    <div class="h4 mb-0">
                        <span class="count"><asp:Label ID="Labeldayexpense" runat="server" Text="Label"></asp:Label></span>
                    </div>
                    <small class="text-muted text-uppercase font-weight-bold">የቀን ወጪ</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-2" style="width: 40%; height: 5px;"></div>
                </div>
            </div>
            <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                        <i class="fa fa-cart-plus"></i>
                    </div>
                    <div class="h4 mb-0">
                         <span class="count">  <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></span>
                      </div>
                        
                   
                    <small class="text-muted text-uppercase font-weight-bold">አጠቃላይ ሽያጭ</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-3" style="width: 40%; height: 5px;"></div>
                </div>
          </div>
          
            <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                        <i class="fa fa-clock-o"></i>
                    </div>
                    <div class="h4 mb-0">
                       <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                          </div>
                    <small class="text-muted text-uppercase font-weight-bold">የትዕዛዝ የገንዘብ መጠን</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-5" style="width: 40%; height: 5px;"></div>
                </div>
            </div>
            <div class="card col-md-6 no-padding ">
                <div class="card-body">
                    <div class="h1 text-muted text-right mb-4">
                     <i class="fa fa-money"></i> 
                    </div>
                    <div class="h4 mb-0">
                        <span class="count"><asp:Label ID="Labelcashathand" runat="server" Text="Label"></asp:Label></span>
                    </div>
                    <small class="text-muted text-uppercase font-weight-bold">አጠቃላይ የቀን ገቢ</small>
                    <div class="progress progress-xs mt-3 mb-0 bg-flat-color-1" style="width: 40%; height: 5px;"></div>
                </div>
            </div>
        </div>

            </div>
    


            <div class="col-xl-4 col-lg-6">
                <div class="card">
                    <div class="card-body">
                        <div class="stat-widget-one">
                            <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                            <div class="stat-content dib">
                                <div class="stat-text">የሽያጭ ዝርዝር</div>
                                 <small class="text-muted text-uppercase font-weight-bold">የዕጅ በዕጅ ሽያጭ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelsalecash" runat="server" Text="Label"></asp:Label></span>
                    </div>
                       <small class="text-muted text-uppercase font-weight-bold">የክሬዲት ሽያጭ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelsalecredit" runat="server" Text="Label"></asp:Label></span>
                    </div>
                                    <small class="text-muted text-uppercase font-weight-bold">የባንክ ዝውውር ሽያጭ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelsalebantrans" runat="server" Text="Label"></asp:Label></span>
                    </div>
                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-xl-4 col-lg-6">
                <div class="card">
                    <div class="card-body">
                        <div class="stat-widget-one">
                            <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                            <div class="stat-content dib">
                                <div class="stat-text">የትዕዛዝ ዝርዝር</div>
                                <small class="text-muted text-uppercase font-weight-bold">የዕጅ በዕጅ ቀብድ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelordppcash" runat="server" Text="Label"></asp:Label></span>
                    </div>
                       <small class="text-muted text-uppercase font-weight-bold">የክሬዲት ትዕዛዝ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelordppcredit" runat="server" Text="Label"></asp:Label></span>
                    </div>
                                    <small class="text-muted text-uppercase font-weight-bold">የባንክ ዝውውር ቀብድ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelordppbtrans" runat="server" Text="Label"></asp:Label></span>
                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-4 col-lg-6">
                <div class="card ">
                    <div class="card-body">
                        <div class="stat-widget-one">
                            <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                           <div class="stat-content dib">
                                <div class="stat-text">የገቢ ዝርዝር</div>
                                <small class="text-muted text-uppercase font-weight-bold">ካሽ</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelrevcash" runat="server" Text="Label"></asp:Label></span>
                    </div>
                       <small class="text-muted text-uppercase font-weight-bold">ክሬዲት</small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelrevcredit" runat="server" Text="Label"></asp:Label></span>
                    </div>
                                    <small class="text-muted text-uppercase font-weight-bold">በባንክ ዝውውር </small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelrevbanktrans" runat="server" Text="Label"></asp:Label></span>
                    </div>
                                   <small class="text-muted text-uppercase font-weight-bold">በእጅ የሚገኝ የገንዘብ መጠን </small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labelcasand" runat="server" Text="Label"></asp:Label></span>
                    </div>
                                  <small class="text-muted text-uppercase font-weight-bold">ተጨማሪ ገቢ </small>
                                  <div class="h4 mb-0">
                                                   <span class="count"><asp:Label ID="Labeladdval" runat="server" Text="Label"></asp:Label></span>
                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                    <div class="col-md-6 offset-md-6 col-sm-6 ml-auto">
                       
                                <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-3"></div>
                                                                       <div class="col col-md-8">
<asp:Button ID="Buttshowacctdetail" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ወደ አካውንት ማስተላለፊያ" OnClick="showctdtform" />

                                                                       </div>
                          <div class="col-1"></div>
                                                                       
                                                                      </div>
                                                                    </div>
                           
                    </div>
                </div>

	    <div id="accountdtail" runat="server" class="row" style="display:none; visibility:hidden">
            <div class="col-3"></div>
                    <div class="col-md-6">
                        <section class="card">
                            <div class="card-body text-secondary">
                  <div class="card">
                                                        <div class="card-header">የባንክ አካውንት መረጃ</div>
                                                        <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-6"><asp:Label ID="Label5" runat="server" Text="የደረሰኝ ቁጥር"></asp:Label></div>
                                                                       <div class="col col-md-6"> <asp:TextBox ID="TextBoxReceiptId"  CssClass="form-control-sm form-control" Placeholder="የደረሰኝ ቁጥር" runat="server"></asp:TextBox></div>
                          
                                                                       
                                                                      </div>
                                                                    </div>
                                                            <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label1" runat="server" Text="የባንክ ስም ምረጥ"></asp:Label>
                                                                    </div>
                                                                    <div class="col-6">
                                                                        <asp:DropDownList ID="DropDownListbankname" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadallholrname">
                                                                           
                                                                        </asp:DropDownList>

                                                                   </div></div>
                                                              
                                                            
                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label3" runat="server" Text="የአካውንት ባለቤት"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                                                              <asp:DropDownList ID="DropDownListholdrname" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadallaccountno"></asp:DropDownList>
                                                                           
                                                               </div>

                                                               </div>
                                                             <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label4" runat="server" Text="የአካውንት ቁጥር"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                                                              <asp:TextBox ID="TextBoxaccno" placeholder="የአካውንት ቁጥር" Cssclass="form-control-sm form-control" Enable= "false" runat="server"></asp:TextBox>
                                 
                                                               </div>

                                                               </div>
                                                            <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label6" runat="server" Text="የገንዘብ መጠን"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                  <asp:TextBox ID="TextBoxamount" placeholder="የገንዘብ መጠን" Cssclass="form-control-sm form-control" Enable= "false" runat="server"></asp:TextBox>
                                          <small class="form-text text-muted"><code>Amount of Payment</code>
                                                            </small>
                                                               </div>
                                                                

                                                               </div>
                                                         
                                                               
                                                              
                                                        
                                                                <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                               <div class="col-3"></div>
                                                               <div class="col-6"> 
                                                                   <asp:Button ID="Buttaddacct" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ወደ እካውንት አስገባ" OnClick="addaccountdailycash" />

                                                               </div>
                                                               <div class="col-3"></div>

                                                           
                                                               </div> 
                                                                   
                                                        </div>
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
                                                    </div>






                            </div>
                        </section>
                    </div>
            <div class="col-3"></div>
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
 

</body>

</html>
