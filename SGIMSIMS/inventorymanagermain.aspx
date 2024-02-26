<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inventorymanagermain.aspx.cs" Inherits="SGIMSIMS.inventorymanagermain" %>


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
                        <a href="IMInvLog.aspx"> <i class="menu-icon fa fa-table"></i>Inventory Counter</a>
                       
                    </li>
                     <li class="fa fa-table">

 <a  href="#"><i class="fa fa-power-off"></i><asp:Button ID="Button1" class="btn btn-link  btn-sm" runat="server" Text="Logout" OnClick="Logout" /></a>
                     </li>
                      <li class="fa fa-table"><i class="fa fa-cog"></i> 
                           <button type="button" class="btn btn-link btn-sm" data-toggle="modal" data-target="#myModal">Change Password</button>                 
        
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

                         
                            <a class="nav-link" href="#"><i class="fa fa-cog"></i>   <button type="button" class="btn btn-link btn-sm" data-toggle="modal" data-target="#myModal">Change Password</button> </a>


                           <a class="nav-link" href="#"><i class="fa fa-power-off"></i><asp:Button ID="Buttonlogout" class="btn btn-link btn-sm" runat="server" Text="Logout" OnClick="Logout" /></a>
                           
                            <%--<button type="button" class="btn btn-link" disabled="">Link</button>--%>
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
                            <li class="active">Inventory Manager Admin</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
 <div class="col-sm-12">
                <div class="alert  alert-success alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-success">Success</span> የቀን መረጃዎችን እዚህ መመልከት ይችላሉ።
                 
                </div>
            </div>
         <div id="pmpnote" runat="server"  class="col-sm-12" style="display:none; visibility:hidden">
               <div class="sufee-alert alert with-close alert-danger alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-danger">Alert</span> ያለ ትዕዛዝ የሚመረቱ ምርቶች እያለቁ ነው። እባክዎት መረጃውን ይመልከቱ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
             <div id="newordnote" runat="server"  class="col-sm-12" style="display:none; visibility:hidden">
                <div class="sufee-alert alert with-close alert-danger alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-danger">Alert</span> አዲስ ትዕዛዝ አለዎት። እባክዎት ትዕዛዙን በመመልከት ወደ ስራ ያስገቡ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
             <div id="delordnote" runat="server" class="col-sm-12" style="display:none; visibility:hidden">
            <div class="sufee-alert alert with-close alert-danger alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-danger">Alert</span>ዛሬ መረከብ ያለባቸው ትዕዛዞች አሉ። እባክዎ መረጃውን ተመልክተው ምርቶችን ይላኩ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
            <div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
       Change Password
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
       
          <div class="form-group">
                            <label>መለያ አስገባ</label>
                     
                            <asp:TextBox ID="TextBoxprepass" runat="server" textmode="password" cssclass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
          <div class="form-group">
                            <label>አዲስ መለያ አስገባ</label>
                     
                            <asp:TextBox ID="TextBoxewpass" runat="server" textmode="password" cssclass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
          <div class="form-group">
                            <label>አዲስ መለያ መልሰህ አስገባ</label>
                     
                            <asp:TextBox ID="TextBoxretypenpass" runat="server" textmode="password" cssclass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
         
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
            <asp:Button ID="Buttonchgpass"  runat="server" cssclass="btn btn-success-sm btn-flat" Text="መለያ ቀይር" OnClick="changepassword" />
          <asp:Label ID="Labelmsg" runat="server" Visible="false" Text="Label"></asp:Label>
      
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
