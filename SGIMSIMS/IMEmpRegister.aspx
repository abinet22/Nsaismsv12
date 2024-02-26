<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IMEmpRegister.aspx.cs" Inherits="SGIMSIMS.IMEmpRegister" %>



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
                            <li><a href="#">Inventory Manager Admin</a></li>
                            <li class="active">Employee Registration</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
 
              <div class="col-sm-12">
              <div class="card bg-secondary">
                            <div class="card-body">
                                <div class="row">
                                          <div class="col-lg-3"> </div>
                                    <div class="col-lg-3">
                       
                       <asp:Button ID="Buttempreg" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የሰራተኞች መመዝገቢያ ፎርም" OnClick="showempregistry" />
                    </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butempteam" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የሰራተኞች ቡድን መምስረቻ " OnClick="showtempteamcreatn" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
            <div class="row">
                    <div class="col-md-9 offset-md-3 mr-auto ml-auto" runat="server" id="empreg" style="display:none; visibility:hidden" >
                        <section class="card">
                            <div class="card-body text-secondary">
                  <div class="card">
                                                        <div class="card-header">የሰራተኞች መመዝገቢያ ፎርም</div>
                                                        <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-2"></div>
                                                                       <div class="col col-md-4"> <asp:TextBox ID="TextBoxEmpId" enabled= "false" CssClass="form-control-sm form-control" Placeholder="የሰራተኛ መለያ ቁጥር" runat="server"></asp:TextBox></div>
                                                                        <div class="col col-md-4">
                                                                             <asp:Button ID="ButtongenEmpid" runat="server"  class="btn btn-primary btn-sm btn-block" Text="የሰራተኛ መለያ ፍጠር" OnClick="generateEmpid" />

                                                                        </div>
                                                                       <div class="col-2"></div>
                                                                      </div>
                                                                    </div>
                                                               <div class="row form-group">
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxEmpname" placeholder="የሰራተኛ ስም"  CssClass="form-control-sm form-control" runat="server"></asp:TextBox></div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxEmpPhone" placeholder="የሰራተኛ ስልክ"   Cssclass="form-control-sm form-control " runat="server"></asp:TextBox></div>
                                                                <div class="col-4"><asp:TextBox ID="TextBoxEmpAddress" placeholder="የሰራተኛ ኣድራሻ"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox></div>
                                                                   
                                                                   </div>
                                                               <div class="row form-group">
                                                                    <div class="col-4">
                                                                          <asp:DropDownList ID="DropDownListemtype" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                              <asp:ListItem Value="0">--የቅጥር ሁኔታ ምረጥ--</asp:ListItem>
                                                                              <asp:ListItem>Permanent</asp:ListItem>
                                                                              <asp:ListItem>Temporary</asp:ListItem>
                                                                          </asp:DropDownList>
                                                                         <small class="for-text text-muted"><code>የሰራተኛ ቅጥር ሁኔታ ምረጥ</code></small>
                                                                    </div>
                                                                         <div class="col-4"><asp:TextBox ID="TextBoxEmpPosition" placeholder="የሰራተኛ የስራ መደብ"   Cssclass="form-control-sm form-control" runat="server"></asp:TextBox></div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxEmpSalary" placeholder="የሰራተኛ ደሞዝ"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox></div>
                                                           
                                                               </div>
                                                               
                                                                <div class="row form-group">
                                                                     <div class="input-group">
                                                                    <div class="col-2"></div>
                                                                    <div class="col-4">
                                                                          <asp:DropDownList ID="DropDownListsalarytype" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True">
                                                                              <asp:ListItem Value="0">--የደሞዝ አከፋፈል ሁኔታ--</asp:ListItem>
                                                                              <asp:ListItem>Daily</asp:ListItem>
                                                                              <asp:ListItem>Weekly</asp:ListItem>
                                                                              <asp:ListItem>Monthly</asp:ListItem>
                                                                          </asp:DropDownList>
                                                                         <small class="for-text text-muted"><code>የሰራተኛ ያከፋፈል ሁኔታ</code></small>
                                                                    </div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxEmpworkstrtdt" Cssclass="form-control-sm form-control" runat="server" TextMode="DateTime"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>ሰራተኛ ስራ የጀመረበት ቀን</code></small>
                                                                    </div>
                                                                    <div class="col-2"></div>
                                                                         </div>
                                                                </div>
                                                       <%--<div class="row form-group">
                                                           <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-8"><asp:DropDownList ID="DropDownListemplist" class="form-control-sm form-control" runat="server"></asp:DropDownList></div>
                                                               <div class="col-2"></div>
                                                            </div>
                                                            </div>--%>
                                                                <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                               <div class="col-4"> <asp:Button ID="ButtonAddEmp" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ኣዲስ ሰራተኛ መዝግብ" OnClick="AddnwEmp" /></div>
                                                               <div class="col-4"> <asp:Button ID="ButtonUdtEmp" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ሰራተኛ መረጃ ኣሻሽል" OnClick="UpdateEmp" /></div>
                                                               <div class="col-4"> <asp:Button ID="ButtonDltEmp" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ሰራተኛ ሰርዝ" OnClick="DeleteEmp" /></div>

                                                           
                                                               </div> 
                                                                   
                                                        </div>
                                                            </div>
                                                    </div>






                            </div>
                        </section>
                    </div>
                   <div class="col-md-9 offset-md-3 mr-auto ml-auto" runat="server" id="empteam" style="display:none; visibility:hidden" >
                        <section class="card">
                            <div class="card-body text-secondary">
                  <div class="card">
                                                        <div class="card-header">የሰራተኞች ቡድን መመዝገቢያ </div>
                                                        <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-2"></div>
                                                                       <div class="col col-md-4"> <asp:TextBox ID="TextBoxteamid" enabled= "false" CssClass="form-control-sm form-control" Placeholder="የቡድን መለያ ቁጥር" runat="server"></asp:TextBox></div>
                                                                        <div class="col col-md-4">
                                                                             <asp:Button ID="Buttonteamid" runat="server"  class="btn btn-primary btn-sm btn-block" Text="አዲስ የቡድን መለያ ፍጠር" OnClick="generateteamid" />

                                                                        </div>
                                                                       <div class="col-2"></div>
                                                                      </div>
                                                                    </div>
                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                       <label for="hf-password" class=" form-control-label">አዲስ የቡድን ስም አስገባ</label>
                                                                    </div>
                                                                    <div class="col-6"><asp:TextBox ID="TextBoxteamname" placeholder="አዲስ የቡድኑ ስም"   Cssclass="form-control-sm form-control " runat="server"></asp:TextBox></div>
                                                  
                                                                   </div>
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-2"></div>
                                                                       <div class="col col-md-4"> 
                                                                               <label for="hf-password" class=" form-control-label">ነባር የቡድን ስም ምረጥ</label>
                                                                
                                                                       </div>
                                                                        <div class="col col-md-4">
                                                                             <asp:DropDownList ID="DropDownListteamname" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadteamleader">
                                                                                 
                                                                          </asp:DropDownList>
                                                                           
                                                                         <small class="for-text text-muted">የቡድን ስም ምረጥ</small>
                                                                        </div>
                                                                       <div class="col-2"></div>
                                                                      </div>
                                                                    </div>
                                                               <div class="row form-group">
                                                                    <div class="col-6">
                                                                         <asp:ListBox ID="ListBoxteam" runat="server" class="form-control-sm form-control" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" SelectionMode="multiple"></asp:ListBox>
                                                                         
                                                                         <small class="for-text text-muted">የሰራተኛ ስም ምረጥ</small>
                                                                    </div>
                                                                         <div class="col-6"><asp:TextBox ID="TextBoxteamhead" placeholder="የቡድን ሃላፊ ስም"   Cssclass="form-control-sm form-control" runat="server"></asp:TextBox></div>
                                                                  
                                                               </div>
                                                               
                                                               
                                                                <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                               <div class="col-6">
                                                                   <asp:Button ID="Butaddteam" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ኣዲስ ቡድን ስራ" OnClick="Addnewteam" /></div>
                                                               <div class="col-6"> <asp:Button ID="Buttonudtteam" class="btn btn-secondary btn-sm btn-block" runat="server" Text="የቡድን መረጃ ኣሻሽል" OnClick="Updateteammemeber" /></div>
                                  
                                                           
                                                               </div> 
                                                                   
                                                        </div>
                                                            </div>
                                                    </div>






                            </div>
                        </section>
                    </div>
                </div>


         <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">የሰራተኛ ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">አጠኣላይ የሰራተኛ ብዛት: <asp:Label ID="LabeltotalnoEmp" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            
                                 <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                    
                                     <asp:GridView ID="GridViewEmpList" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="4" OnPageIndexChanging="LoadNxtEmpList" OnSelectedIndexChanged="SelectEMpLoadTxtbox" AllowPaging="True" width="1250px" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ሰራተኛ ምረጥ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>

                                            
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


