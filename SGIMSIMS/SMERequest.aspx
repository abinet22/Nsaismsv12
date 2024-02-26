<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMERequest.aspx.cs" Inherits="SGIMSIMS.SMERequest" %>



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
                        <h1>Dashboard/ <asp:Label ID="Labelsession" runat="server" Text="Label"></asp:Label> </h1>
                    </div>
                </div>
            </div>
			
		
            <div class="col-sm-8">
                <div class="page-header float-right">
                    	<div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                             <li><a href="#">Sales Manager Admin</a></li>
                            <li class="active">Expense Request</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
            
           <div class="col-sm-12">
                <div class="alert  alert-success alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-success">Success</span>የወጪ መጠየቂያ ፎርም በመላክ ፍቃድ ያገኙ ወጪዎችን ክፍያ መጨረስ ይችላሉ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
      
          
            <div class="row">
                    <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                  <div class="card">
                                                        <div class="card-header">የወጪ መጠየቂያ ፎርም</div>
                                                        <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-4"><asp:Label ID="Label5" runat="server" Text="የመጠይቅ መለያ"></asp:Label></div>
                                                                       <div class="col col-md-4"> <asp:TextBox ID="TextBoxexprecId" enabled= "false" CssClass="form-control-sm form-control" Placeholder="የመጠይቅ መለያ" runat="server"></asp:TextBox></div>
                                                                        <div class="col col-md-4">
                                                                             <asp:Button ID="Buttongenexrecid" runat="server"  class="btn btn-primary btn-sm btn-block" Text="መለያ ፍጠር" OnClick="generateexrectid" />

                                                                        </div>
                                                                       
                                                                      </div>
                                                                    </div>
                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label4" runat="server" Text="የወጪ ምክንያት"></asp:Label>
                                                                    </div>
                                                                    <div class="col-6">
                                                                        <asp:DropDownList ID="DropDownexpreason" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="expensereaselchg">
                                                                            <asp:ListItem Value="0">--የወጪ ምክንያት ምረጥ--</asp:ListItem>
                                                                            <asp:ListItem>Employee Salary</asp:ListItem>
                                                                             <asp:ListItem>AdvancePayment</asp:ListItem>
                                                                            <asp:ListItem>Other</asp:ListItem>
                                                                            <asp:ListItem>All Daily Salary</asp:ListItem>
                                                                            <asp:ListItem>All Weekly Salary</asp:ListItem>
                                                                            <asp:ListItem>All Monthly Salary</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                   </div></div>
                                                                <div class="row form-group">
                                                                    <div class="col-6">
                                                                       
                                                                    </div>
                                                                         <div class="col-6">
                                    <asp:DropDownList ID="DropDownListpaymentlst" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  Visible="False" OnSelectedIndexChanged="Isynexpense"></asp:DropDownList>

                                                               </div>
                                                                     </div>





                                                            <div id="empslaexp" runat="server">
                                                             
                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label3" runat="server" Text="የሰራተኛ ስም ምረጥ"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                                                              <asp:DropDownList ID="DropDownListemplst" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadempsaldetail"></asp:DropDownList>

                                                               </div>

                                                               </div>
                                                            <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label6" runat="server" Text="የደምዝ አከፋፈል ሁኔታ"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                  <asp:TextBox ID="TextBoxsaltype" placeholder="የደምዝ አከፋፈል ሁኔታ" Cssclass="form-control-sm form-control" Enable= "false" runat="server"></asp:TextBox>
                                        
                                                               </div>
                                                                

                                                               </div>
                                                            <div class="row form-group">
                                                                    <div class="col-4">
                                                                          <asp:TextBox ID="TextBoxnxtsalarydt" placeholder="የቀጣይ ደሞዝ ቀን" Cssclass="form-control-sm form-control" Enable= "false"  runat="server"></asp:TextBox>
                                     
                                                                       <small class="form-text text-muted"><code>የቀጣይ ደሞዝ ቀን</code></small>
                                                                    </div>
                                                                         <div class="col-4">
                                                                              <asp:TextBox ID="TextBoxlastaydt" placeholder="የመጨረሻ ክፍያ የወሰደበት ቀን" Cssclass="form-control-sm form-control" Enable= "false"  runat="server"></asp:TextBox>
                                         <small class="form-text text-muted"><code>የመጨረሻ ክፍያ የወሰደበት ቀን</code>
                                                            </small>
                                                                         </div>
                                                                <div class="col-4">
                                                                              <asp:TextBox ID="TextBoxadvanceay" placeholder="Advance Payment" Cssclass="form-control-sm form-control" Enable= "false"  runat="server"></asp:TextBox>
                                         <small class="form-text text-muted"><code>ቅድመ ክፍያ ካለ?</code>
                                                            </small>
                                                                         </div>
                                                               
                                                                   
                                                               </div>

                                                                  </div>




                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label1" runat="server" Text="የሚከፈል ገንዘብ"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                                                             <asp:TextBox ID="TextBoxayamnt" placeholder="የሚከፈል ገንዘብ" Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>

                                                                         </div>
                                                                   
                                                               </div>
                                                              <div class="row form-group">
                                                                    <div class="col-6">
                                                                        <asp:Label ID="Label2" runat="server" Text="ተጨማሪ ማብራሪያ"></asp:Label>
                                                                    </div>
                                                                         <div class="col-6">
                                                                             <asp:TextBox ID="TextBoxnote" placeholder="ተጨማሪ ማብራሪያና ማስታዎሻ እዚህ ያስቀምጡ።"  Cssclass="form-control-sm form-control" runat="server" TextMode="MultiLine"></asp:TextBox></div>
                                                                   
                                                               </div>
                                                              
                                                        
                                                                <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-8"> 
                                                                   <asp:Button ID="Buttonsendexprequest" class="btn btn-secondary btn-sm btn-block" runat="server" Text="የወጪ ፎርም ይላኩ" OnClick="sendexprequest" />

                                                               </div>
                                                               <div class="col-2"></div>

                                                           
                                                               </div> 
                                                                   
                                                        </div>
                                                                                             <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                                                                                    <div class="col-4"> 
                                                                   <asp:Button ID="Buttdaily" class="btn btn-secondary btn-sm btn-block" runat="server" Text="የቀን ደምዝ ወጪ" OnClick="senddaysalrec" />

                                                               </div>
                                                               <div class="col-4"> 
                                                                   <asp:Button ID="Buttweek" class="btn btn-secondary btn-sm btn-block" runat="server" Text="የሳምንታዊ ወጪ " OnClick="sendweeksalrec" />

                                                               </div>
                                                                                                           <div class="col-4"> 
                                                                   <asp:Button ID="Buttmonthly" class="btn btn-secondary btn-sm btn-block" runat="server" Text="የወርሃዊ ደምዝ ወጪ" OnClick="sendmonthsalrec" />

                                                               </div>

                                                           
                                                               </div> 
                                                                   
                                                        </div>
                                                            </div>
                                                    </div>






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
 

</body>

</html>
