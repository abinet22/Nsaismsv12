<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASystemConfig.aspx.cs" Inherits="SGIMSIMS.ASystemConfig" %>



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
    <title>SGIMISMS</title>
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

                        <div class="dropdown for-message">
                            <button class="btn btn-secondary dropdown-toggle" type="button"
                                id="message"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="ti-email"></i>
                                <span class="count bg-primary">9</span>
                            </button>
                            <div class="dropdown-menu" aria-labelledby="message">
                                <p class="red">You have 4 Mails</p>
                                <a class="dropdown-item media bg-flat-color-1" href="#">
                                <span class="photo media-left"><img alt="avatar" src="images/avatar/1.jpg"></span>
                                <span class="message media-body">
                                    <span class="name float-left">Jonathan Smith</span>
                                    <span class="time float-right">Just now</span>
                                        <p>Hello, this is an example msg</p>
                                </span>
                            </a>
                                <a class="dropdown-item media bg-flat-color-4" href="#">
                                <span class="photo media-left"><img alt="avatar" src="images/avatar/2.jpg"></span>
                                <span class="message media-body">
                                    <span class="name float-left">Jack Sanders</span>
                                    <span class="time float-right">5 minutes ago</span>
                                        <p>Lorem ipsum dolor sit amet, consectetur</p>
                                </span>
                            </a>
                                <a class="dropdown-item media bg-flat-color-5" href="#">
                                <span class="photo media-left"><img alt="avatar" src="images/avatar/3.jpg"></span>
                                <span class="message media-body">
                                    <span class="name float-left">Cheryl Wheeler</span>
                                    <span class="time float-right">10 minutes ago</span>
                                        <p>Hello, this is an example msg</p>
                                </span>
                            </a>
                                <a class="dropdown-item media bg-flat-color-3" href="#">
                                <span class="photo media-left"><img alt="avatar" src="images/avatar/4.jpg"></span>
                                <span class="message media-body">
                                    <span class="name float-left">Rachel Santos</span>
                                    <span class="time float-right">15 minutes ago</span>
                                        <p>Lorem ipsum dolor sit amet, consectetur</p>
                                </span>
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

                            <a class="nav-link" href="#"><i class="fa fa-user"></i> Notifications <span class="count">13</span></a>

                            <a class="nav-link" href="#"><i class="fa fa-cog"></i> Settings</a>

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
                        <h1>Dashboard/ <asp:Label ID="Labelsession" runat="server" Cssclass="breadcrumb text-right" Text="Label"></asp:Label></h1>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="page-header float-right">
                    <div class="page-title">
                        <ol class="breadcrumb text-right">
                            <li><a href="#">Dashboard</a></li>
                            <li><a href="#">Create Classroom</a></li>
                            <li class="active">Add Classroms</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>



        <div class="content mt-3">
         


         <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Add Users</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">
                                    <div class="row">
                                        <div class="col col-lg-6">

                                            <asp:TextBox ID="TextBoxprepaid" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox1" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox2" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="TextBox3" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>

                                        </div>
                                        <div class="col col-lg-6">

                                            <asp:GridView ID="GridView3" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                        </div>

                                    </div>
                                   
                                </div>

                        </section>
                   
                            </div>
             <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Add Products</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">
                                     <div class="row">
                                         <div class="col col-lg-6">
                                             <asp:TextBox ID="TextBox4" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                             <asp:TextBox ID="TextBox5" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                             <asp:TextBox ID="TextBox6" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                             <asp:TextBox ID="TextBox7" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                             <asp:TextBox ID="TextBox8" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                             <asp:TextBox ID="TextBox9" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                         </div>
                                         <div class="col col-lg-6">

                                             <asp:GridView ID="GridView1" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                         </div>
                                    </div>
                                    
                                </div>
                        </section>
                   
                            </div>
             <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Add Service</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">

                                   <div class="row">

                                       <div class="col col-lg-6">
                                           <asp:TextBox ID="TextBox10" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="TextBox11" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="TextBox12" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="TextBox13" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="TextBox14" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                       </div>
                                       <div class="col col-lg-6">
                                           <asp:GridView ID="GridView2" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                       </div>
                                    </div>

                                    
                                </div>
                        </section>
                   
                            </div>
             <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Add Warehouse</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">
                                         
                                      <div class="row">
                                          <div class="col col-lg-6">
                                              <asp:TextBox ID="TextBox15" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox16" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox17" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox18" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox19" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                          </div>
                                          <div class="col col-lg-6">
                                              <asp:GridView ID="GridView4" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                          </div>

                                    </div>
                                        
                                    
                                </div>
                        </section>
                   
                            </div>
              <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Add Shops</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">
                                         
                                      <div class="row">
                                          <div class="col col-lg-6">
                                              <asp:TextBox ID="TextBox20" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox21" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox22" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox23" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                          </div>
                                          <div class="col col-lg-6">
                                              <asp:GridView ID="GridView5" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                          </div>

                                    </div>
                                        
                                    
                                </div>
                        </section>
                   
                            </div>
              <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">Employee</strong>
                                                           
                            </div>
                            
                                 <div class="card-body card-block">
                                         
                                      <div class="row">
                                          <div class="col col-lg-6">
                                              <asp:TextBox ID="TextBox24" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox25" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox26" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox27" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                              <asp:TextBox ID="TextBox28" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                          </div>
                                          <div class="col col-lg-6">
                                              <asp:GridView ID="GridView6" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="Delete"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                          </div>

                                    </div>
                                        
                                    
                                </div>
                        </section>
                   
                            </div>
					
						
                             </div>
				</div>
	
                                    
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
