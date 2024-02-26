 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IAddPreMan.aspx.cs" Inherits="SGIMSIMS.AAddPrice" %>

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
                            <li class="active">Dashboard</li>
                             <li >Inventory Manager Admin</li>
                             <li >Manage Product</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <div class="content mt-3">
            <div class="animated fadeIn">
              <div class="col-sm-12">
                 <div class="col-sm-12">
                <div class="alert  alert-success alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-success">Success</span>
                     ያለ ትዕዛዝ የተፈበረኩ ምርቶች መመዝገቢያ እና ያሉ ምርቶች ብዛት መረጃ መመልከቻ።
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>
                  <div class="col-sm-12">
              <div class="card bg-secondary">
                            <div class="card-body">
                                <div class="row">
                                          <div class="col-lg-3"> </div>
                                    <div class="col-lg-3">
                       
                       <asp:Button ID="Buttpremanreq" runat="server" class="btn btn-secondary btn-sm btn-block" Text="ያለ ትዕዛዝ የተፈበረኩ ምርቶች መመዝገቢያ " OnClick="showaddpreman" />
                    </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butrecpreman" runat="server" class="btn btn-secondary btn-sm btn-block" Text="ያለ ትዕዛዝ የተፈበረኩ ምርቶች መላኪያ" OnClick="showtranspreman" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
        <div class="row col-sm-12">
            
        
            <div class="col-md-9 offset-md-3 mr-auto ml-auto">

                 
                        <div class="card">
                            <div class="card" id="premanreg" runat="server" style="display:none; visibility:hidden">
                            <div class="card-header">
                                <strong class="card-title">የምርቶች መመዝገቢያ <small><span class="badge badge-success float-right mt-1">እዚህ ጨምር</span></small></strong>
                            </div>
                           <div class="card-body card-block">
                                                            
                                                            <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ስም ምረጥ</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListproname" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የጥሬ ዕቃ ስም</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListbrand" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="enableddlgage"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የጥሬ ዕቃ ጌጅ</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListgage" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                                                                                      <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ስፋት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxwidth" runat="server"  placeholder="የምርት ስፋት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxwidth" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                                     <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ርዝመት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxlength" runat="server"  placeholder="የምርት ርዝመት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxlength" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                           <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ብዛት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxqtyforprodu" runat="server"  placeholder="የምርት ብዛት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpcopingsize" runat="server" ControlToValidate="TextBoxqtyforprodu" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                           <div class="row form-group">
                                                                 <div class="col col-md-2">
                                                        
                                                                    </div>
                                                                <div class="col col-md-4">
                                                          <asp:Button ID="Buttudtqty"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ምርቱን ብዛት ኣሻሽል" OnClick="udtproqty"  />        
                                                    
                                                                    </div>
                                                                <div class="col col-md-4">
                                                             <asp:Button ID="Butadd"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ምርቱን መዝግብ" OnClick="addproprice"  />        
                                                            <small> <code>
                                                                <asp:Label ID="Labelmessage" runat="server" Text="Label" Visible="False"></asp:Label> </code></small>
                                                                    </div>
                                                               <div class="col col-md-2">
                                                            </div>
                                                            </div>
                                                    </div>
                           </div>
                        </div>
                    </div>
           <div class="col-md-9 offset-md-3 mr-auto ml-auto">

                 
                        <div class="card">
                            <div class="card" id="premantransfer" runat="server" style="display:none; visibility:hidden">
                            <div class="card-header">
                                <strong class="card-title">ምርት መላኪያ ፎርም(በመጀመሪያ ትዕዛዝ ይምረጡ።) <small><span class="badge badge-success float-right mt-1"></span></small></strong>
                            </div>
                           <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የመጠየቂያ መለያ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxreqid" runat="server"  placeholder="የመጠየቂያ መለያ" class="form-control-sm form-control" Enabled="False"></asp:TextBox>
                                                                  
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ስም ምረጥ</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListtranproname" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                                                 <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የጥሬ ዕቃ ስም</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListtranbrand" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="enableddlgage"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የጥሬ ዕቃ ጌጅ</label></div>
                                                                <div class="col-12 col-md-7">
                                                                 <asp:DropDownList ID="DropDownListtrangage" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"></asp:DropDownList>
                                                                
                                                                </div>
                                                            </div>
                                                                                                      <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ስፋት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxtranwidth" runat="server"  placeholder="የምርት ስፋት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxwidth" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                                     <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ርዝመት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxtranlen" runat="server"  placeholder="የምርት ርዝመት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxlength" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                        
                                                          <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">ምርት የሚላክለት ሰም ምረጥ </label></div>
                                                                <div class="col-12 col-md-7">
                                                                    <asp:DropDownList ID="DropDownListtranware" Cssclass="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" ></asp:DropDownList>
                                                               
                                                                </div>
                                                            </div>
                                                            
                                                           <div class="row form-group">
                                                                <div class="col col-md-5"><label for="hf-password" class=" form-control-label">የምርት ብዛት አስገባ</label></div>

                                                                <div class="col-12 col-md-7">
                                                                         <asp:TextBox ID="TextBoxtransqty" runat="server"  placeholder="የምርት ብዛት አስገባ"  class="form-control-sm form-control"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxtransqty" ErrorMessage="Enter Correct amount" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                </div>
                                                            </div>
                                                           <div class="row form-group">
                                                                <div class="col col-md-3">
                                                        
                                                                    </div>
                                                                <div class="col col-md-6">
                                                             <asp:Button ID="Buttontansprempro"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ምርቱን ላክ " OnClick="transproprice"  />        
                                                             <small> <code>
                                                                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label> </code></small>
                                                                    </div>
                                                               <div class="col col-md-3">
                                                            </div>
                                                            </div>
                                                    </div>
                           </div>
                        </div>
                    </div>
        
        
            
            </div>

                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-title">
                                    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label> <small><span class="badge badge-success float-right mt-1"></span></small></strong>
                            </div>
                            <div class="card-body">
                               
              <asp:GridView ID="GridViewpreprolst" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6"  OnPageIndexChanging="newpricelistpage" OnSelectedIndexChanged="selectandeditpricelst" AllowPaging="True" ViewStateMode="Enabled" OnRowDataBound="width" >


                                      
                  <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="የምርት መጠይቅ ምረጥ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>

                                            
                                         </Columns>
                

<FooterStyle BackColor="#3399FF"></FooterStyle>

<HeaderStyle BackColor="#3399FF"></HeaderStyle>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>                   
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




