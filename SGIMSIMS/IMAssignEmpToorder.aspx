<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IMAssignEmpToorder.aspx.cs" Inherits="SGIMSIMS.IMAssignEmpToorder" %>




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
                            <li class="active">Assign Employee To Order</li>
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
                       
                       <asp:Button ID="Buttassignords" runat="server" class="btn btn-secondary btn-sm btn-block" Text="አዲስ ስራ ደልድል " OnClick="showassignwork" />
                   
                                        </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butwiplst" runat="server" class="btn btn-secondary btn-sm btn-block" Text="በስራ ላይ ያሉ ትዕዛዞች ዝርዘር" OnClick="showwiplist" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
 <div class="col-sm-12">
                <div class="sufee-alert alert with-close alert-danger alert-dismissible fade show" role="alert">
                    <span class="badge badge-pill badge-danger">Alert</span>  
                     <asp:Label ID="Labelrecorder" class="card-title" runat="server" Text=" "></asp:Label>
                     
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
            </div>
              <div id="assignemp" runat="server" style="display:none; visibility:hidden">
            <div class="row">
                    <div class="col-md-9 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                              
                  <div class="card">
                         <div id="printDiv" runat="server">  
                                                        <div class="card-header">ሰራተኛ መመደቢያ ፎርም (በመጀመሪያ ስራውን ይምረጡ።)</div>
                                                        <div class="card-body card-block">
                                                          
                                                            <div class="row form-group">
                                                                    <div class="input-group">
                                                                        <div class="col-2"></div>
                                                                       <div class="col col-md-4"> <asp:TextBox ID="TextBoxMWorkId" enabled= "false" CssClass="form-control-sm form-control" Placeholder=" የስራ መለያ" runat="server"></asp:TextBox>
                                                                           <small class="for-text text-muted"><code> የስራ መለያ</code></small>
                                                                       </div>
                                                                        <div class="col col-md-4">
                                                                             <asp:Button ID="ButtongenMworkid" runat="server"  class="btn btn-primary btn-sm btn-block" Text="ኣዲስ የስራ መለያ ፍጠር" OnClick="generateMWorkid" Enabled="False" />
                                                                           
                                                                        </div>
                                                                       <div class="col-2"></div>
                                                                      </div>
                                                                    </div>
                                                               <div class="row form-group">
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxorderid" placeholder="የትዕዛዝ መለያ" enabled= "false"  CssClass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>የትዕዛዝ መለያ</code></small>
                                                                    </div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxorderdt" placeholder="ስራ የታዘዘበት ቀን" enabled= "false"  Cssclass="form-control-sm form-control " runat="server"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>ስራ የታዘዘበት ቀን</code></small>
                                                                    </div>
                                                                <div class="col-4"><asp:TextBox ID="TextBoxdelvrydt" placeholder="ስራ ማስረከቢያ ቀን" enabled= "false" Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                    <small class="for-text text-muted"><code>ስራ ማስረከቢያ ቀን</code></small>
                                                                </div>
                                                                   
                                                                   </div>
                                                               <div class="row form-group">
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxproname" placeholder="የምርት ስም" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>የምርት ስም</code></small>
                                                                    </div>
                                                                         <div class="col-4"><asp:TextBox ID="TextBoxprosize" placeholder="የምርት ስፋት" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                             <small class="for-text text-muted"><code>የምርት ስፋት</code></small>
                                                                         </div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxproshape" placeholder="የምርት ቅርጽ" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>የምርት ቅርጽ</code></small>
                                                                    </div>
                                                           
                                                               </div>
                                                               
                                                                <div class="row form-group">
                                                                     <div class="input-group">
                                                                    
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxproqty" placeholder="የምርት ብዛት" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>የምርት ብዛት</code></small>
                                                                    </div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxworkstrtdt" Cssclass="form-control-sm form-control" runat="server" TextMode="DateTime"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>ስራ የተጀመረበት ቀን</code></small>
                                                                    </div>
                                                                    <div class="col-4"><asp:TextBox ID="TextBoxspecificid" Cssclass="form-control-sm form-control" runat="server" enabled="false"></asp:TextBox>
                                                                        <small class="for-text text-muted"><code>ID</code></small>
                                                                    </div>
                                                                         </div>
                                                                </div>
                                                            <div class="row form-group">
                                                                     <div class="input-group">
                                                                    <div class="col-3">
                                                                        <asp:TextBox ID="TextBoxprobrand"  enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የእቃ ኣይነት</code></small>
                                                                    </div>
                                                                    <div class="col-3">
                                                                        <asp:TextBox ID="TextBoxprogage"  enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የእቃ ጌጅ</code></small>
                                                                    </div>
                                                                    <div class="col-3">
                                                                        <asp:TextBox ID="TextBoxprolen" placeholder="የምርት ርዝመት" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የምርት ርዝመት</code></small>
                                                                    </div>
                                                                    <div class="col-3">
                                                                        <asp:TextBox ID="TextBoxprocopsize" placeholder="የኮፒንግ ሆድ ስፋት" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የኮፒንግ ሆድ ስፋት</code></small>
                                                                    </div>
                                                                         </div>
                                                                </div>
                                                            <div class="row form-group">
                                                                     <div class="input-group">
                                                                   
                                                                    <div class="col-4">
                                                                        <asp:TextBox ID="TextBoxcusname"   placeholder="የደንበኛ ስም"  enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የደንበኛ ስም</code></small>
                                                                    </div>
                                                                    <div class="col-4">
                                                                        <asp:TextBox ID="TextBoxcusphone" placeholder="የደንበኛ ስልክ" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የደንበኛ ስልክ</code></small>
                                                                    </div>
                                                                    <div class="col-4">
                                                                   <asp:TextBox ID="TextBoxordtype" placeholder="የትዕዛዝ አይነት" enabled= "false"  Cssclass="form-control-sm form-control" runat="server"></asp:TextBox>
                                                                          <small class="for-text text-muted"><code>የትዕዛዝ አይነት</code></small>
                                                                 
                                                                    </div>
                                                                         </div>
                                                                </div>
                                                       <div class="row form-group">
                                                           <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-8"><asp:DropDownList ID="DropDownListemplist" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"></asp:DropDownList>
                                                                    <small class="for-text text-muted"><code>የሰራተኛ ስም ዝርዝር </code></small>
                                                               </div>
                                                               <div class="col-2"></div>

                                                           
                                                               </div>
                                                       </div>
                                                             <div class="row form-group">
                                                           <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-8"><asp:DropDownList ID="DropDownListbrand" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="enableloagages" Visible="False"></asp:DropDownList>
                                                                   <%-- <small class="for-text text-muted"><code>የእቃ ኣይነት ምረጥ</code></small>--%>
                                                               </div>
                                                               <div class="col-2"></div>

                                                           
                                                               </div>
                                                       </div>
                                                             <div class="row form-group">
                                                           <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-8"><asp:DropDownList ID="DropDownListgage" class="form-control-sm form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" Visible="False"></asp:DropDownList>
                                                                   <%-- <small class="for-text text-muted"><code>የእቃ ጌጅ ምረጥ</code></small>--%>
                                                               </div>
                                                               <div class="col-2"></div>

                                                           
                                                               </div>
                                                       </div>
                                                                 </div>
                                                          </div>
                                                                <div class="form-actions form-group">
                                                                   <div class="input-group">
                                                               <div class="col-2"></div>
                                                               <div class="col-5"> <asp:Button ID="Buttonassignemptowork" class="btn btn-secondary btn-sm btn-block" runat="server" Text="ትዕዛዝ ወደ ስራ አስግባ" OnClick="assignemptowork" /></div>
                                                              <div class="col-5">    <input id="Button1" type="button" value="Print" lang="javascript" onclick="printDiv('printDiv')" class="btn btn-secondary btn-sm btn-block"/></div>

                                                           
                                                               </div> 
                                                                   
                                                        </div>
                                                           

<div class="form-actions form-group">
        <div id="divMessage" class="alert with-close alert-danger alert-dismissible fade show" runat="server" style="display:none; visibility:hidden">
                                        <span class="badge badge-pill badge-danger">Alert</span>
                                         <asp:Label ID="Labelalertonbtntopr" runat="server"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                    </div>


</div>

                                                            
                                                    </div>

                                

                                  
                            </div>
                        </section>
                    </div>
                </div>

                          <div class="col-lg-12" >
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">የተቀበልናቸው ስራዎች ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">አጠቃላይ የስራዎች ብዛት: <asp:Label ID="LabeltotalrecOrders" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            
                                 <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                    
                                     <asp:GridView ID="GridViewRecAssignOrder" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="4" OnPageIndexChanging="LoadRecivedorderpage" OnSelectedIndexChanged="AssignEmpmakewip" AllowPaging="True" OnRowDataBound="width"  width="1750px"  >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ስራ ምረጥ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>


                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                    
                                </div>
                        </section>
                   
                            </div>

              </div>
            <div id="wip" runat="server"  style="display:none; visibility:hidden">
              <div class="col-lg-12" >
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">የተቀበልናቸው ስራዎች ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">አጠቃላይ የስራዎች ብዛት: <asp:Label ID="Labelwip" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            
                                 <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                    
                                     <asp:GridView ID="GridViewwip" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="4" OnPageIndexChanging="Loadwippage" OnSelectedIndexChanged="wipnxtpage" AllowPaging="True" OnRowDataBound="width"  width="1750px"  >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ትዕዛዝ ሰርዝ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>


                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                    
                                </div>
                        </section>
                   
                            </div>

            </div>
       

        </div>
        </div> <!-- .content -->
    <!-- /#right-panel -->
    </form>
    <!-- Right Panel -->

    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>


    <script src="vendors/chart.js/dist/Chart.bundle.min.js"></script>
    <script src="assets/js/dashboard.js"></script>
    <script src="assets/js/widgets.js"></script>
  
    <script lang="javascript" type="text/javascript">

//function Button1_onclick() {
////open new window set the height and width =0,set windows position at bottom
//var a = window.open ('','','left =' + screen.width + ',top=' + screen.height + ',width=0,height=0,toolbar=0,scrollbars=0,status=0');
////write gridview data into newly open window
//a.document.write(document.getElementById('assignemp').innerHTML);
//a.document.close();
//a.focus();
////call print
//a.print();
//a.close();
//return false;

//}
          function printDiv(divName) {
        var printContents = document.getElementById(divName).innerHTML;
        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;

        window.print();

        document.body.innerHTML = originalContents;
    }

        //function printDiv() {
        //    var divContents = document.getElementById("printDiv").innerHTML;

        //    var printWindow = window.open('', '', 'height=200,width=400');

        //    printWindow.document.write('<html><head><title>Print DIV Content</title>');

        //    printWindow.document.write('</head><body >');

        //    printWindow.document.write(divContents);

        //    printWindow.document.write('</body></html>');

        //    printWindow.document.close();

        //    printWindow.print();
        //}
    //    //var printContents = document.getElementById("printDiv").innerHTML;
    //    //var originalContents = document.body.innerHTML;

    //    //document.body.innerHTML = printContents;

    //    //window.print();

    //    //document.body.innerHTML = originalContents;
    //}

    // function printDiv(elemetntid1,elemetntid2,elemetntid3) {
    //     var printContents1 = document.getElementById(elemetntid1).value;
    //     var printContents2 = document.getElementById(elemetntid2).value;
    //     var printContents3 = document.getElementById(elemetntid3).value;
    //     printWindow.document.write(printContents1);
    //    printWindow.document.write(printContents2);
    //    printWindow.document.write(printContents3);
       
    //    window.print();

    //}

</script>
</body>
       
</html>

