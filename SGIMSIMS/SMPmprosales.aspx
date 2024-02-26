<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMPmprosales.aspx.cs" Inherits="SGIMSIMS.SMPmprosales" %>


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
				
					
					
                    <li class="fa fa-table">
                        <a href="SMrecieveproduct.aspx" > <i class="menu-icon fa fa-table"></i>Manage Recieve Products</a>
                        
                    </li>
                    <li class="fa fa-table">
                        <a href="SMorderedproduct.aspx" > <i class="menu-icon fa fa-table"></i>Manage Ordered Products</a>
                       
                    </li>
                    <li class="fa fa-table">
                        <a href="SMsales.aspx"> <i class="menu-icon fa fa-th"></i>Manage Sales</a>
                        
                    </li>

                    <h3 class="menu-title">Reports</h3><!-- /.menu-title -->

                    <li class="fa fa-table">
                        <a href="SMreports.aspx" > <i class="menu-icon fa fa-bar-chart"></i>Manage Reports</a>
                        
                    </li>
                   
                                       
                    <h3 class="menu-title">Extras</h3><!-- /.menu-title -->
                    <li class="fa fa-table">
                        <a href="SMnotification.aspx" > <i class="menu-icon fa fa-bar-chart"></i>Notifications</a>
                        
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

                            <a class="nav-link" href="#"><i class="fa fa-power-off"></i> Logout</a>
                        </div>
                    </div>

                    <div class="language-select dropdown" id="language-select">
                        <a class="dropdown-toggle" href="#" data-toggle="dropdown"  id="language" aria-haspopup="true" aria-expanded="true">
                            <i class="flag-icon flag-icon-us"></i>
                        </a>
                        <div class="dropdown-menu" aria-labelledby="language">
                            <div class="dropdown-item">
                                <span class="flag-icon flag-icon-fr"></span>
                            </div>
                            <div class="dropdown-item">
                                <i class="flag-icon flag-icon-es"></i>
                            </div>
                            <div class="dropdown-item">
                                <i class="flag-icon flag-icon-us"></i>
                            </div>
                            <div class="dropdown-item">
                                <i class="flag-icon flag-icon-it"></i>
                            </div>
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
                        <h1>Dashboard</h1>
                    </div>
                </div>
            </div>
			
		
            <div class="col-sm-8">
                <div class="page-header float-right">
                    	<div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li>Sales Admin</li>
							<li class="active">Sale Products</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">

			<div class="card">
            <div class="card-body">
                               
                
                                  
                                     <div class="row">
                                           
                    <div class="col-md-8 offset-md-2 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-header">
                                <strong class="card-title pl-2">Select Sale Type</strong> To Sell
                            </div>
                            <div class="card-body text-secondary">
                                <div class="row form-group">

                                                             <div class="col col-md-3">  
                                                                 </div>
                                                                <div class="col col-md-6">
                                                                         <asp:DropDownList ID="DropDownListProType" cssclass="form-control" runat="server">
                                                                              <asp:ListItem Text="PreManufuctured Product" Value="1"></asp:ListItem>
                                 <asp:ListItem Text="RowMaterial" Value="2"></asp:ListItem>
                                 <asp:ListItem Text="Service" Value="3"></asp:ListItem>

                                                                         </asp:DropDownList>
                                                           
                                                                </div>
                                                             <div class="col col-md-3">
                                                                 <asp:Button ID="Button1" runat="server" Text="Button" OnClick="viewpanel" /> 
                                                                </div>
                                                         
                                                        </div>
                                                       </div>
                        </section>
                    </div>
                
                    <div class="col-lg-12">
                        
                      <div class="card">
                            <div class="card-header">
                                  <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Sales Catagory</strong>
                             
                            </div>
                      
                              <div class="row">
                       <div class="col-md-4">
                        <div class="card">
                            <div class="card-header bg-secondary">
                                <strong class="card-title text-light">Pre-Man Product</strong>
                            </div>
                            <div class="card-body ">
                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                    <div class="form-group">
                                  <asp:DropDownList ID="DropDownList1"  cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                    <div class="form-group">
                                  <asp:DropDownList ID="DropDownList2" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                        <div class="form-group">
                                  <asp:DropDownList ID="DropDownList3" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                         


                                </asp:Panel>
                               
                                   </div>
                        </div>
                    </div>
                             <div class="col-md-4">
                        <div class="card">
                            <div class="card-header bg-secondary">
                                <strong class="card-title text-light">Row-Material</strong>
                            </div>
                            <div class="card-body text-white bg-primary">
                                <div class="form-group">
                                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                                    <div class="form-group">
                              <asp:DropDownList ID="DropDownList10"  cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                    <div class="form-group">
                                  <asp:DropDownList ID="DropDownList11" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                        <div class="form-group">
                                  <asp:DropDownList ID="DropDownList12" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                            <div class="form-group">
                                  <asp:DropDownList ID="DropDownList13" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList> </div>
                                                <div class="form-group">
                                  <asp:DropDownList ID="DropDownList14" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList>
                                </div>


                                </asp:Panel>
                                    </div>
                            </div>
                        </div>
                    </div>
                              <div class="col-md-4">
                        <div class="card">
                            <div class="card-header bg-secondary">
                                <strong class="card-title text-light">Service</strong>
                            </div>
                            <div class="card-body text-white bg-primary">
                               
                                 <asp:Panel ID="Panel3" runat="server" Visible="False"><div class="form-group">
                             
                                  <div class="form-group">
                                   <asp:DropDownList ID="DropDownList8" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList></div>
                                  <div class="form-group">
                                  <asp:DropDownList ID="DropDownList9" cssclass="form-control" runat="server">                                                                            

                                                                         </asp:DropDownList></div>

                              </asp:Panel>
                               
                                    </div>
                            </div>
                        </div>
                   
                              </div> 

                    
                        </div>
                              </div>
                          
                   
                            </div>
                      
                                        <div class="row">
                                            <div class="col-md-6 offset-md-2 mr-auto ml-auto">
                        <section class="c ard">
                            <div class="card-header">
                                <strong class="card-title pl-2">Sales </strong> Info
                            </div>
                            <div class="card-body text-secondary">
                                <div class="row form-group">

                                                             <div class="col col-md-4">  <label for="input-small" class="form-control-label">Sales ID</label>
                                                                
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                     <asp:TextBox ID="TextBoxSalesID" class="form-control-sm is-invalid form-control" placeholder="SalesID" runat="server" Enabled="False"></asp:TextBox>
                                                            
                                                                          </div>
                                                         
                                                        </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">Sales Date</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxSalesDate" class="form-control-sm is-invalid form-control"  runat="server" TextMode="DateTime"></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>

                                                            </div>
                        </section>
                    </div>

                                        </div>

                                            <div class="row">
                    <div class="col-md-6 offset-md-3 mr-auto ml-auto">
                        <section class="card">

                            <div class="card-body text-secondary">
                                <div class="row form-group">  
                                                                <div class="col col-md-4"><label for="input-small" class="form-control-label">Pre-Paid Amount</label></div>
                                                                <div class="col col-md-8">
                                                                    <asp:TextBox ID="TextBoxPrePaid" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                                                    
                                                                </div>
                                                            </div>
                                <div class="row form-group">  
                                                                <div class="col col-md-4"><label for="input-small" class="form-control-label">Remaining</label></div>
                                                                <div class="col col-md-8">
                                                                    <asp:TextBox ID="TextBoxremainpr" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                               
                              
                            </div>
                        </section>
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
