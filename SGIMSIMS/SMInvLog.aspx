<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMInvLog.aspx.cs" Inherits="SGIMSIMS.SMInvLog" %>


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
                            <li><a href="#">Sales Manager</a></li>
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
                                <strong class="card-title">Select RowMatrial Type <small><span class="badge badge-success float-right mt-1">Add Here</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                               
                                               

                                                            <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">የጥሬ እቃ አይነት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                    <asp:DropDownList runat="server" ID="DropDownListprobrand"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadbrandgages">
                                                                        </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">የጥሬ እቃ ጌጅ</label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:DropDownList runat="server" ID="DropDownListprogage"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                        </asp:DropDownList>
                              
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">የጥሬ እቃ ስፋት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                   <asp:TextBox ID="TextBoxmatwidth" runat="server" placeholder="የጥሬ እቃ ስፋት" class="form-control-sm form-control"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpreprosize" runat="server" ControlToValidate="TextBoxmatwidth" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ።" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>

                                                         
                                                           <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-password" class=" form-control-label">የጥሬ እቃ ርዝመት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                      <asp:TextBox ID="TextBoxmatlength" runat="server" placeholder="የጥሬ እቃ ርዝመት" class="form-control-sm form-control"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxmatlength" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ።" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                              
                                                                </div>
                                                            </div>

                                                           <div class="row form-group">
                                                                <div class="col col-md-6">
                                                         <asp:Button ID="Buttaddpmat"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ጨምር" OnClick="addmatlst"  />        
                                                             
                                                                    </div>
                                                              
                                                               <div class="col-12 col-md-6">
                                                             <asp:Button ID="Buttdltmatdata"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="አዲስ ቆጠራ አስጀምር" OnClick="dltmatdatalst"  />        
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
                                <strong class="card-title">የጥሬ ዕቃ አይነት ዝርዝር <small><span class="badge badge-success float-right mt-1">የጥሬ ዕቃ አይነት ብዛት:
                                    <asp:Label ID="Labeltotalprodt" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block">
                               
                                <asp:GridView ID="GridViewmatlst" runat="server" Cssclass="table table-striped" PageSize="10" OnPageIndexChanging="Loadmatlstpage" OnSelectedIndexChanged="Loadmatlst" AllowPaging="True"></asp:GridView>
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

</body>

</html>


