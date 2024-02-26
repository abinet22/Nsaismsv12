<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMsales.aspx.cs" Inherits="SGIMSIMS.SMsales" %>


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

                            <a class="nav-link" href="#"><i class="fa fa-power-off"></i> <asp:Button ID="Buttonlogout" class="btn btn-link btn-sm" runat="server" Text="Logout" OnClick="Logout" /></a>
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
							<li class="active">Sale Products</li>
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
                                        
                                    <div class="col-lg-4">
                       
                       <asp:Button ID="Buttempreg" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የቀን ሽያጭ ማከናዎኛ" OnClick="showdailysale" />
                    </div>
                           <div class="col-lg-4">
                       
                            <asp:Button ID="Butempteam" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የክሬዲት ሽያጭ መመልከቻ " OnClick="showtcreditsale" />
                    </div>
                                 <div class="col-lg-4"> 
   <asp:Button ID="Buttosalelist" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የቀን ሽያጭ ዝርዝር" OnClick="showdailylist" />
                 
                                 </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
            <div id ="creditsale" runat="server">
     <div class="row">
       <div class="col-3"></div>
                                            <div class="col-6">
                                                 <section class="card">
                            <div class="card-header">
                                <strong class="card-title pl-2"> የክሬዲት ሽያጭ ማወራረጃ ፎርም </strong> Info 
                            </div>
                            <div class="card-body text-secondary">
                          
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የደንበኛ ስም</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcrdcusname" class="form-control-sm is-invalid form-control"  runat="server" Enable="false"></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የደንበኛ ስልክ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcrdphono" class="form-control-sm is-invalid form-control"  runat="server" Enable="false"></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                              
                                  <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የሽያጭ መለያ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcerdsaleid" class="form-control-sm is-invalid form-control"  runat="server" Enable="false" ></asp:TextBox>
                                                        
                                                                          </div>
                                 

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የሽያጭ ቀን</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcdtsaledt" class="form-control-sm is-invalid form-control"  runat="server" Enable="false" ></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የክፍያ ሁኔታ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                   <asp:DropDownList ID="DropDownListnewpaytype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showcrdbanktrans" >
                                                                    <asp:ListItem Value="0">--የክፍያ ሁኔታ ምረጥ--</asp:ListItem>
                                                                    <asp:ListItem>Cash</asp:ListItem>
                                                                    <asp:ListItem>Bank Transfer</asp:ListItem>
                                                                      
                                                                </asp:DropDownList>
                                                                          </div>

                                    </div>
                                <div id="crbanktrans" runat="server">

                                      <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የባንክ ስም</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                    <asp:DropDownList ID="DropDownListcrdbankname" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showcreditbaccthoder" >
                                                                   
                                                                      
                                                                </asp:DropDownList>
                                                                          </div>

                                    </div>
                                      <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የባለቤት ስም</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                    <asp:DropDownList ID="DropDownLiholrname" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showcreditbankacct" >
                                                                   
                                                                      
                                                                </asp:DropDownList>
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የአካውንት ቁጥር</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcrdeditbankno" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                </div>
                              


                                 <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">አጠቃላይ ዋጋ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcrdtamount" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                 <div class="row form-group">
                                     <div class="col col-md-4"></div>
                                     <div class="col col-md-6">
                                          <label>
                               
                                        <asp:CheckBox  runat="server" ID="CheckBoxcrdtsale"  Text="With Attachement" />
                            </label>
                                   
                                     </div>
                                     <div class="col col-md-2"></div>
                                   

                                </div>
                                  <div class="row form-group">
                                   <div class="col col-md-2"></div>
                                                                <div class="col col-md-8">
                                                                   <asp:Button ID="Buttoncrdsale" class="btn btn-primary btn-sm btn-block" runat="server" Text="የሽያጩን መረጃ ጨምር" OnClick="UpdateSaleCredit" />
                                                               
                                                                          </div>
                                      <div class="col col-md-2"></div>
                                    </div>
                             
                                </div>
                                   </section>
                                                            </div>
                   
                                           
                      <div class="col-3"></div>                    
                                         

                                        </div>

                 
                   <div class="col-lg-12">
                        
                        <section  class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">በክሬዲት የተከናወነ ሽያጭ ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">የሽያጭ ብዛት: <asp:Label ID="totalcrdtsale" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            
                                 <div class="card-body card-block">
                                    
                                     <asp:GridView ID="GridViewcrdsaleList" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="4"  AllowPaging="True" OnSelectedIndexChanged="viewdtlsaledtal" OnPageIndexChanging="newcreditsalelist"  >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ዝርዝር አውጣ">
                                                 <ItemStyle CssClass="btn btn-default btn-xs "></ItemStyle>
                                             </asp:CommandField>

                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                    
                                </div>
                        </section>
                   
                            </div>






            </div>
            <div id ="dailysale" runat="server">
                   <div  class="row">
                <div class="col-4">
                    <div class="accordion" id="accordionExample">
  <div class="card z-depth-0 bordered">
    <div class="card-header" id="headingOne">
      <h5 class="mb-0">
        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne"
          aria-expanded="false" aria-controls="collapseOne">
          የትዕዛዝ ሽያጭ ማከናወኛ</button>
      </h5>
    </div>
    <div id="collapseOne" class="collapse" aria-labelledby="headingOne"
      data-parent="#accordionExample">
      <div class="card-body">
          
          <div class=" row form-group">
              <div class="col col-12">  
                                                                 <asp:TextBox ID="TextBoxorderid" class="form-control-sm is-invalid form-control" placeholder="Search By Order ID" runat="server"></asp:TextBox>
                                                            
                                                                 </div>
          </div>
                                                             <div class="row form-group">
  <div class="col col-12">
                                                                    <asp:Button ID="Butsrchorder" class="btn btn-primary btn-sm btn-block" runat="server" Text="Add To Cart" OnClick="orderselladd" />
                                                                </div>
                                                             </div>
                                                              
                                                         
                                                        
      </div>
        </div>
    </div>
  </div>
  <div class="card z-depth-0 bordered">
    <div class="card-header" id="headingTwo">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse"
          data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
          ያለ ትዕዛዝ ለተመረቱ ሽያጭ ማከናወኛ
        </button>
      </h5>
    </div>
    <div id="collapseTwo" runat="server" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
      <div class="card-body">
    <div class="form-group" >

                                                             <div class="col col-md-12 form-group">  
                                                                 
                                                                 <asp:DropDownList ID="DropDownListpreman" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showproductprice" ></asp:DropDownList>
                                                                 
                                                                 </div>
            <div class="col col-md-12 form-group">  
                                                                 
                                                                 <asp:DropDownList ID="DropDownListpmbrand" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showpmgage" ></asp:DropDownList>
                                                                 
                                                                 </div>
            <div class="col col-md-12 form-group">  
                                                                 
                                                                 <asp:DropDownList ID="DropDownListpmgage" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showpmmatprice" ></asp:DropDownList>
                                                                 
                                                                 </div>

        <div class="row form-group"> 
             <div class="col col-md-6 form-group">  
                                                                 <asp:TextBox ID="TextBoxpmwidth" class="form-control-sm is-invalid form-control" placeholder="የምርት ስፋት" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxpmwidth" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                 </div>
            <div class="col col-md-6 form-group">  
                                                               <asp:Button ID="Buttshowpmppr" class="btn btn-primary btn-sm btn-block" runat="server" Text="ዋጋ እሳይ" OnClick="showpmproprice" />
                                                               
                                                                 </div>

        </div>
                                    
              <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxpmlength" class="form-control-sm is-invalid form-control" placeholder="የምርት ርዝመት" runat="server"></asp:TextBox>
                                                           
                                                                 </div>
                                       <div class="row form-group"> 
             <div class="col col-md-6 form-group">  
                                                                  <asp:TextBox ID="TextBoxunitprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server" Enabled="false"></asp:TextBox>
                                                                  
                                                                 </div>
            <div class="col col-md-6 form-group">  
                                                                <asp:TextBox ID="TextBoxnewpmprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server" OnTextChanged="TextBoxnewpmprice_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExprepmup" runat="server" ControlToValidate="TextBoxnewpmprice" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                               
                                                                 </div>

        </div>
                                   
       
                                     <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxpreproqty" class="form-control-sm is-invalid form-control" placeholder="ብዛት" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExprepmqty" runat="server" ControlToValidate="TextBoxpreproqty" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                
                                                                 </div>
                                 
                                                                <div class="col col-md-12 form-group">
                                                                    <asp:Button ID="Buttaddprepro" class="btn btn-primary btn-sm btn-block" runat="server" Text="Add To Cart" OnClick="addpremanprosale" />
                                                               
                                                                    </div>
                                                         
                                                        </div>
      </div>
    </div>
  </div>
  <div class="card z-depth-0 bordered">
    <div class="card-header" id="headingThree">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse"
          data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
          የጥሬ ዕቃ ሽያጭ ማከናወኛ</button>
      </h5>
    </div>
    <div id="collapseThree" runat="server" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
      <div class="card-body">
        <div class="form-group" >

                                                             <div class="col col-md-12 form-group">  
                                                                 
                                                                 <asp:DropDownList ID="DropDownListbrand" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showrmgage" ></asp:DropDownList>
                                                                 
                                                                 </div>
            <div class="col col-md-12 form-group">  
                                                                 
                                                                 <asp:DropDownList ID="DropDownListgage" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showmaterialprice" ></asp:DropDownList>
                                                                 
                                                                 </div>
              <div class="row form-group"> 
             <div class="col col-md-6 form-group">  
                                                                 <asp:TextBox ID="TextBoxrmunitprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server" Enabled="false"></asp:TextBox>
                                                           
                                                                 </div>
            <div class="col col-md-6 form-group">  
                                                                <asp:TextBox ID="TextBoxnewrmuprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server"></asp:TextBox>
                                                                  <asp:RegularExpressionValidator ID="RegularExpressionrmp" runat="server" ControlToValidate="TextBoxnewrmuprice" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                 </div>

        </div>
                                   
                                     <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxrmwidth" class="form-control-sm is-invalid form-control" placeholder="የጥሬ ዕቃ ስፋት" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxrmwidth" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                 </div>
              <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxrmlength" class="form-control-sm is-invalid form-control" placeholder="የጥሬ ዕቃ ርዝመት" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxrmlength" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                 </div>
            <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxrmqty" class="form-control-sm is-invalid form-control" placeholder="ብዛት" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxrmqty" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                        
                                                                 </div>

                                 
                                                                <div class="col col-md-12 form-group">
                                                                    <asp:Button ID="Butaddrmsale" class="btn btn-primary btn-sm btn-block" runat="server" Text="Add To Cart" OnClick="addrowmatsale" />
                                                               
                                                                    </div>
                                                         
                                                        </div>
      </div>
    </div>
  </div>
                         <div class="card z-depth-0 bordered">
    <div class="card-header" id="headingFour">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse"
          data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
         የግዢ ዕቃዎች ሽያጭ ማከናወኛ</button>
      </h5>
    </div>
    <div id="collapseFour" runat= "server" class="collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
      <div class="card-body">
        
                                <div class="form-group" >

                                                             <div class="col col-md-12 form-group">  
                                                                <asp:DropDownList ID="DropDownListpurprolst" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="stayonpprosale"   ></asp:DropDownList>
                                                                 
                                                                 </div>
                                    <div class="col col-md-12 form-group">  
                                                                <asp:DropDownList ID="DropDownListselltype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="showpurproprice"  >
                                                                     <asp:ListItem Value="0">--Select Sell Type--</asp:ListItem>
                                                                         <asp:ListItem>Unit</asp:ListItem>
                                                                         <asp:ListItem>Packed</asp:ListItem>
                                                                </asp:DropDownList>
                                                                 
                                                                 </div>
                                     <div class="row form-group"> 
             <div class="col col-md-6 form-group">  
                                                                 <asp:TextBox ID="TextBoxpurunitprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server" Enabled="false"></asp:TextBox>
                                                            
                                                                 </div>
            <div class="col col-md-6 form-group">  
                                                                <asp:TextBox ID="TextBoxnewpuruprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxnewpuruprice" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                 </div>

        </div>
                                   
                                    
                                     <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxpurqty" class="form-control-sm is-invalid form-control" placeholder="ብዛት" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxpurqty" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                 </div>
                                   
                                                                <div class="col col-md-12 form-group">
                                                                    <asp:Button ID="Buttpurpro" class="btn btn-primary btn-sm btn-block" runat="server" Text="Add To Cart" OnClick="addpurchasesale" />
                                                                </div>
                                                         
                                                        </div>
      </div>
    </div>
  </div>
             <div class="card z-depth-0 bordered">
    <div class="card-header" id="headingFive">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse"
          data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
        የሰርቪስ ሽያጭ ማከናወኛ</button>
      </h5>
    </div>
    <div id="collapseFive" runat="server" class="collapse" aria-labelledby="headingFive" data-parent="#accordionExample">
      <div class="card-body">
         <div class="form-group" id="service"  runat="server">

                                                             <div class="col col-md-12 form-group">  
                                                                <asp:DropDownList ID="DropDownListser" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="showsersale"   ></asp:DropDownList>
                                                                 
                                                                 </div>
                                    <div class="col col-md-12 form-group">  
                                                                <asp:DropDownList ID="DropDownListsertype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showserviceprice" >
                                                                    <asp:ListItem Value="0">--Select Service Type--</asp:ListItem>
                                                                    <asp:ListItem>WithMaterial</asp:ListItem>
                                                                    <asp:ListItem>WithOutMaterial</asp:ListItem>
                                                                </asp:DropDownList>
                                                                 
                                                                 </div>
                 <div class="row form-group"> 
             <div class="col col-md-6 form-group">  
                                                                 <asp:TextBox ID="TextBoxserviceprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server" Enabled="false"></asp:TextBox>
                                                            
                                                                 </div>
            <div class="col col-md-6 form-group">  
                                                                <asp:TextBox ID="TextBoxnewseruprice" class="form-control-sm is-invalid form-control" placeholder="ዋጋ" runat="server"></asp:TextBox>
                                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxnewseruprice" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                 </div>

        </div>
                                    <div class="col col-md-12 form-group">  
                                                                
                                                                 </div>
                                    
                                     <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxlength" class="form-control-sm is-invalid form-control" placeholder="ርዝመት" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBoxlength" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                 </div>
                                     <div class="col col-md-12 form-group">  
                                                                 <asp:TextBox ID="TextBoxqty" class="form-control-sm is-invalid form-control" placeholder="ብዛት" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxqty" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                 </div>
                                                                <div class="col col-md-12 form-group">
                                                                    <asp:Button ID="Butaddser" class="btn btn-primary btn-sm btn-block" runat="server" Text="Add To Cart" OnClick="addsersale" />
                                                                </div>
                                                         
                                                        </div>
      </div>
    </div>
  </div>

</div>
                
                <div class="col-8">

                                          <div class="card">
                            <div class="card-header">
                                  <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2"> የሽያጭ ትዕዛዝ ዝርዝር</strong><small><span class="badge badge-danger float-right mt-1">
                                Total Prepaid If Any: <asp:Label ID="Labelprepaid" runat="server" Text=" "></asp:Label></span></small> <small> <span class="badge badge-danger float-right mt-1">
                                Total Sale Price: <asp:Label ID="LabelSaleprice" runat="server" Text=" "></asp:Label></span></small>
                             
                            </div>
                          <div class="card-body" style="overflow:auto; width:670px; height:auto">
                        <asp:GridView ID="GridViewSaleitemlst" Cssclass="table table-bordered" runat="server" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="15" OnPageIndexChanging="newsaleslistpage"  ShowFooter="True" OnRowDataBound="HideOneColumn" OnSelectedIndexChanged="deletewrongsell" >

                            <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ሰርዝ"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                        </asp:GridView>

                        </div>
                              </div>
                          
                   

                </div>
                </div>
            
			<div class="card">
            <div class="card-body">
                               
                
                                  
                                  
                                        <div class="row">
                                            <div class="col-6">
                                                 <section class="card">
                            <div class="card-header">
                                <strong class="card-title pl-2">የደንበኛና የአከፋፈል ሁኔታ </strong> Info 
                            </div>
                            <div class="card-body text-secondary">
                          
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የደንበኛ ስም</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcusname" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የደንበኛ ስልክ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxcusphone" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                              <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የአከፋፈል ሁኔታ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                   <asp:DropDownList ID="DropDownListpaymenttype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showbanktrans" >
                                                                    <asp:ListItem Value="0">--የአከፋፈል ሁኔታ ምረጥ--</asp:ListItem>
                                                                    <asp:ListItem>Cash</asp:ListItem>
                                                                    <asp:ListItem>Bank Transfer</asp:ListItem>
                                                                        <asp:ListItem>Credit</asp:ListItem>
                                                                </asp:DropDownList>
                                                                          </div>

                                    </div>
                                <div id="banktrans" runat="server" style="display:none; visibility:hidden">
                                 <div class="row form-group">
                                    <div class="col col-md-6">   <asp:DropDownList ID="DropDownListbankname" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="loadacctholdersale" >
                                                                    
                                                                </asp:DropDownList>
                                                                 </div>
                                                                <div class="col col-md-6">
                                                                  <asp:DropDownList ID="DropDownLisalebkhona" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  OnSelectedIndexChanged="showacctno" >
                                                                    
                                                                </asp:DropDownList>
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-6"> 
                                                                 <asp:TextBox ID="TextBoxacctno" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                 </div>
                                                                <div class="col col-md-6">
                                                                  <asp:TextBox ID="TextBoxpayamount" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextBoxpayamount" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                           
                                                                          </div>

                                    </div></div>

                               


                                </div>
                                   </section>
                                                            </div>
                     
                                           
                                            <div class="col-6">
                                                       <section class="card">
                            <div class="card-header">
                                <strong class="card-title pl-2">የሽያጭ መረጃ </strong> Info <small><span class="badge badge-danger float-right mt-1">
                                Total Amount ToBe Paid: <asp:Label ID="Labelamount" runat="server" Text=" "></asp:Label></span></small> 
                            </div>
                            <div class="card-body text-secondary">
                            <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የሽያጭ መለያ</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-4">
                                                                  <asp:TextBox ID="TextBoxSalesID" class="form-control-sm is-invalid form-control"  runat="server" ></asp:TextBox>
                                                        
                                                                          </div>
                                 <div class="col col-md-4">
                                                                    <asp:Button ID="Buttgenid" class="btn btn-primary btn-sm btn-block" runat="server" Text="የሽያጭ መለያ ጨምር" OnClick="generatesaleid" />
                                                               
                                                                          </div>

                                    </div>
                                <div class="row form-group">
                                    <div class="col col-md-4">  <label for="input-small" class="form-control-label">የሽያጭ ቀን</label>
                                                               
                                                                 </div>
                                                                <div class="col col-md-8">
                                                                  <asp:TextBox ID="TextBoxSalesDate" class="form-control-sm is-invalid form-control"  runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox>
                                                        
                                                                          </div>

                                    </div>
                                
                                 <div class="row form-group">
                                     <div class="col col-md-4"></div>
                                     <div class="col col-md-6">
                                          <label>
                               
                                        <asp:CheckBox  runat="server" ID="CheckBoxattach"  Text="With Attachement" />
                            </label>
                                   
                                     </div>
                                     <div class="col col-md-2"></div>
                                   

                                </div>
                                  <div class="row form-group">
                                   <div class="col col-md-2"></div>
                                                                <div class="col col-md-8">
                                                                   <asp:Button ID="Buttsale" class="btn btn-primary btn-sm btn-block" runat="server" Text="ሽያጭ አከናውን" OnClick="createsale" />
                                                               
                                                                          </div>
                                      <div class="col col-md-2"></div>
                                    </div>

                                                            </div>
                        </section>
                                            </div>

                                         

                                        </div>

                                  
                                    


                </div>
                            </div>
			

            </div>
         
			  <div id ="showsalelist" runat="server">
                       <div class="row">
                    <div class="col-md-8 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                  <div class="card">
                                                        <div class="card-header">የቀን ሽያጭ ዝርዝር</div>
                                                        <div class="card-body card-block">
                                                            <div class="row form-group">
                                                                <div class="col col-md-6">
                                                                         <asp:TextBox ID="TextBoxfromdt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>

                                                          <small class="text-muted text-uppercase font-weight-bold">የመጀመሪያ ቀን</small>                                                                </div>
                                                                <div class="col-12 col-md-6">
                                                                    <asp:TextBox ID="TextBoxtodt" runat="server"  class="form-control-sm form-control" TextMode="Date"></asp:TextBox>
                    <small class="text-muted text-uppercase font-weight-bold">የመጨረሻ ቀን</small> 
                                                                </div>
                                                            </div>

                                                          
                                                          
                                   
                                
                                                           <div class="row form-group">
                                                               
                                                                <div class="col-12 col-md-4">
                                                                
                                                                </div>
                                                               
                                                              
                                                               <div class="col-12 col-md-4">
                                                                    <asp:Button ID="Buttonsrcsalelst"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ሽያጮችን አሳይ" OnClick="searchsalelst"  />        
                                                             
                                                                </div>
                                                                 <div class="col-12 col-md-4">
                                                                 
                                                                                  <asp:Button ID="btnPrintAll" runat="server" cssclass="btn btn-sm btn-info btn-block"  Text="የሽያጭ ዝርዝር ወደ Excel ላክ" OnClick="print"  />
                                                                     
                          
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
                                <strong class="card-title"> የቀን ሽያጭ ዝርዝር<small><span class="badge badge-success float-right mt-1"> አጠቃላይ የሽያጭ ብዛት
                                    <asp:Label ID="Labeltotalorder" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                <asp:GridView ID="GridViewsalelst" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="20" OnPageIndexChanging="newsalelistpage" AllowPaging="True" >



                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                               
                                </div>
                        </section>
                    </div>

                 </div>
			
			
    </div>  <!-- .content -->
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
