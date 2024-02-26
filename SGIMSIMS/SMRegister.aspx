<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMRegister.aspx.cs" Inherits="SGIMSIMS.SMRegister" %>



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
                        <h1>Dashboard/ <asp:Label ID="Labelsession" runat="server"  Text="Label"></asp:Label> </h1>
                    </div>
                </div>
            </div>
			
		
            <div class="col-sm-8">
                <div class="page-header float-right">
                    	<div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li >Sales Manager Admin</li>
                            <li class="active">Pre-Manufucure Register</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
             <div class="animated fadeIn">
           <div class="col-sm-12">
                <div class="alert  alert-success alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-success">Success</span> ያለ ትዕዛዝ የተፈበረኩ ምርቶች መጠየቂያና መቀበያ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
           <div class="col-sm-12">
              <div class="card bg-secondary">
                            <div class="card-body">
                                <div class="row">
                                          <div class="col-lg-3"> </div>
                                    <div class="col-lg-3">
                       
                       <asp:Button ID="Buttpremanreq" runat="server" class="btn btn-secondary btn-sm btn-block" Text="ያለ ትዕዛዝ የተፈበረኩ ምርቶች መጠየቂያ" OnClick="showpremanreq" />
                    </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butrecpreman" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የተላኩ ምርቶች መቀበያ" OnClick="showrecpreman" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
            
                       <div class="row">
            
            <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                 <div class="card" id="premanreq" runat="server" style="display:none; visibility:hidden">
                            <div class="card-header">
                                <strong class="card-title">ያለ ትዕዛዝ የተፈበረኩ ምርቶች መጠየቂያ ፎርም <small><span class="badge badge-success float-right mt-1"></span></small></strong>
                            </div>
                           <div class="card-body card-block" >
                                 
                                                           <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">የተፈበረኩ ምርቶች መጠየቂያ መለያ</label></div>
                                                                <div class="col-12 col-md-5">
                                                                     <asp:TextBox ID="TextBoxproid" runat="server" placeholder="ምርት መጠየቂያ መለያ" class="form-control-sm form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12 col-md-4">
                                                                    <asp:Button ID="Buttpmprpreqid"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ምርት መጠየቂያ መለያ ፍጠር" OnClick="genpmproreqid"  />        
                                                        
                                                                 </div>
                                                            </div>
                                                           
                                                             <div class="row form-group">
                                                                <div class="col col-md-3"><label for="hf-email" class=" form-control-label">የምርት ስም ምረጥ</label></div>
                                                                <div class="col-12 col-md-9">
                                                                  <asp:DropDownList runat="server" ID="DropDownListproname"  cssclass="form-control-sm is-invalid form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                 
                                                                </div></div>
                               <div class="row form-group">
                                                                  <div class="col col-md-3"><label for="hf-email" class=" form-control-label">የምርት ስፋት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:TextBox ID="TextBoxwidth" runat="server" placeholder="የምርት ስፋት" class="form-control-sm form-control"></asp:TextBox>
                                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxwidth" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                 
                                                                    </div>
                                                            </div>
                                <div class="row form-group">
                                                                  <div class="col col-md-3"><label for="hf-email" class=" form-control-label">የምርት ርዝመት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:TextBox ID="TextBoxlen" runat="server" placeholder="የምርት ርዝመት" class="form-control-sm form-control"></asp:TextBox>
                                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxlen" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                 
                                                                    </div>
                                                            </div>
                                                               <div class="row form-group">
                                                                  <div class="col col-md-3"><label for="hf-email" class=" form-control-label">የምርት ብዛት</label></div>
                                                                <div class="col-12 col-md-9">
                                                                     <asp:TextBox ID="TextBoxqty" runat="server" placeholder="የምርት ብዛት" class="form-control-sm form-control"></asp:TextBox>
                                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxqty" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                 
                                                                    </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <div class="col col-md-3"></div>
                                                                <div class="col-12 col-md-6">
                                                                    <asp:Button ID="Buttsendreqst"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="የምርት መጠየቂያ ላክ" OnClick="sendpmprorqst"  />        
                                                          <small> <code>
                                                                <asp:Label ID="Labelmessage" runat="server" Text="Label" Visible="False"></asp:Label> </code></small>
                              
                                                                </div>
                                                                  <div class="col col-md-3"></div>
                                                            </div>
                                                            
                                                   
                               
                                                    </div>
                           
                        </div>

</div></section></div>
                       
                 
            
            </div>

               
     
  
            <div class="col-lg-12">
                        
                        <section  class="card">
                            <div class="card-header">
                                <strong class="card-title"><small>የተላኩ ያለ ትዕዛዝ የተፈበረኩ ምርቶች ዝርዝር<span class="badge badge-success float-right mt-1">የተላኩ  ምርቶች ብዛት
                                    <asp:Label ID="Labeltotalprodt" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block" id="sendpremanpro" runat="server" style="display:none; visibility:hidden">
                               
                                <asp:GridView ID="GridViewprolst" runat="server" Cssclass="table table-striped" PageSize="4" OnPageIndexChanging="Loadprodpage" OnSelectedIndexChanged="Loadproductlst" AllowPaging="True">
                                    <Columns>
                                        <asp:CommandField SelectText="Accept" ShowSelectButton="True"></asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                                    
                            </div>
                        </section>
                    </div>


           

            </div>
             

            </div>
        <!-- .content -->
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
