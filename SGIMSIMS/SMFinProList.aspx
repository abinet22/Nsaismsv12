<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMFinProList.aspx.cs" Inherits="SGIMSIMS.SMFinProList" %>



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

<form  runat="server">
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

        </header> <!-- /header -->
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
							<li class="active">Finished Order Products </li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">

           
                          
					<div class="card">
                            <%--<div class="card-header">
                                <h4>Product Recieve Form</h4>
                            </div>--%>
                            <div class="card-body">
                               

                                       <div class="row">
                                           
                    <div class="col-md-8 offset-md-2 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-header">
                                <strong class="card-title pl-2">ስራቸው ያለቀ ትእዛዞች መፈለጊያ</strong>
                            </div>
                            <div class="card-body text-secondary">
                                <div class="row form-group">

                                                             <div class="col col-md-7">  
                                                                 <asp:TextBox ID="TextBoxsearchkey" class="form-control-sm is-invalid form-control" placeholder="የትእዛዝ መለያ አስገባ" runat="server"></asp:TextBox>
                                         
                                                             </div>
                                                                <div class="col col-md-5">
                                                              <asp:Button ID="Buttsrchfinshorder" runat="server" class="btn btn-primary btn-sm btn-block" Text="ፈልግ" OnClick="Buttsrchfinshorder_Click" />
                                                         
                                                                </div>
                                     
                                                         
                                                        </div>
                                <div class="col col-md-3">  
                                  </div>  
                                    <div class="col col-md-6"> <asp:Button ID="Buttloadallfinprolst" runat="server" class="btn btn-primary btn-sm btn-block" Text="ሁሉንም ያለቁ ትዕዛዞች አሳይ" OnClick="loadallfinprolst" /></div>
                                     <div class="col col-md-3"> </div>


                            </div>
                        </section>
                    </div>
                
                    <div class="col-lg-12">
                        
                      <div class="card">
                            <div class="card-header">
                                <strong class="card-title">ስራቸው ያለቀ ትእዛዞች ዝርዝር</strong><small><span class="badge badge-danger float-right mt-1"> ስራቸው ያለቀ ትእዛዞች ብዛት: <asp:Label ID="Labeltotalfinpro" runat="server" Text=" "></asp:Label></span></small>
                            </div>
                          <div class="card-body"  style="overflow:auto; width:1000px; height:auto">
                           <asp:GridView ID="GridViewFinOrdList" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="4" OnPageIndexChanging="LoadFinordLstpage"  AllowPaging="True"  >


                                        

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                        </div>
                              </div>
                          
                   
                            </div>
                      </div>
                                   


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


</body>

</html>

