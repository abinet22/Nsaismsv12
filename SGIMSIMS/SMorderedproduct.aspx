<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMorderedproduct.aspx.cs" Inherits="SGIMSIMS.SMorderedproduct" %>


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

<body >

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
							<li class="active">Order Products</li>
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
                       
                       <asp:Button ID="Buttaddbankacct" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የትዕዛዝ መቀበያ" OnClick="showorderform" />
                    </div>
                           <div class="col-lg-3">
                       
                            <asp:Button ID="Butushowacctrans" runat="server" class="btn btn-secondary btn-sm btn-block" Text="የትዕዛዞች መመልከቻ" OnClick="showorders" />
                    </div>
                                 <div class="col-lg-3"> </div>
                                     </div>
                                 
                            </div>
                        </div>
            </div>
            <div id ="addacct" runat="server">
			<div class="card">
                            
                            <div class="card-body">
           
                                    <div class="row">
                    <div class="col-lg-6">
                        
                            
                                                    <div class="card-header">
                                                <i class="fa fa-male"></i> <strong>የደንበኛ</strong> መረጃ
                                                    </div>
                                <section class="card">
                                 <div class="card-body card-block">
                                    <div class="row form-group">  
                                                                <div class="col col-md-5"><label for="input-small" class="form-control-label">የደንበኛ ስም  </label></div>
                                                                <div class="col col-md-7">
                                                                    <asp:TextBox ID="TextBoxcusname" placeholder="Name" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                                                  </div>
                                                            </div>
                                     <div class="row form-group">  
                                                                <div class="col col-md-4"><label for="input-small" class="form-control-label">የደንበኛ ስልክ ቁጥር  </label></div>
                                                                <div class="col col-md-8">
                                                                    <asp:TextBox ID="TextBoxcusphone" placeholder="Phone" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                                                      </div>
                                                            </div>
                                    
                                </div>
                        </section>
                    </div>
                    <div class="col-lg-6">
                        <section class="card">
                                

                                    <div class="card-header">
                                                    <i class="fa fa-calendar"></i>    <strong>የትዕዛዝና የመቀበያ ቀን</strong> 
                                                    </div>
                             <div class="card-body card-block">
                                    <div class="row form-group">  
                                                                <div class="col col-md-4"><label for="input-small" class="form-control-label">ትዕዛዝ የታዘዘበት ቀን </label></div>
                                                                <div class="col col-md-8">
                                        <asp:TextBox ID="TextBoxorderdt" runat="server" class="form-control-sm is-invalid form-control "  TextMode="DateTime" Enabled="false"></asp:TextBox>
                              
                                                                </div>
                                                            </div>
                                    <div class="row form-group">  
                                                                <div class="col col-md-4"><label for="input-small" class="form-control-label">የትዕዛዝ መቀበያ ቀን </label></div>
                                                          <div class="col col-md-8">      
                                       <asp:TextBox ID="TextBoxrecdate" runat="server" class="form-control-sm is-invalid form-control"  TextMode="Date"></asp:TextBox>
                                                        <small class="form-text text-muted"><code><asp:Label ID="Labelsugdeltydte" runat="server" Text="Estimated Delivery Time Suggestion"></asp:Label></code>
                                                            </small>
                                                              </div>
                              
                                        </div>
                                 <div class="row form-group">  
                                                                <div class="col col-md-4">
                                                                   <asp:TextBox ID="TextBoxresetordid" runat="server"  placeholder="የትዕዛዝ መላያ" class="form-control-sm is-invalid form-control"  ></asp:TextBox>
                                                        
                                                                </div>
                                                          <div class="col col-md-8">      
                                                         <asp:Button ID="Buttonreloadord" runat="server"  class="btn btn-primary btn-sm btn-block" Text="ነባር ትዕዛዝ ፈልግ" OnClick="loadunsentorder"  />
                                             
                                                              </div>
                              
                                        </div>
                                </div>
                        </section>
                        

                    </div>
                    <div class="col-lg-12">
                        
                        <div class="card-header">
                                                 <i class="fa fa-gears"></i>       <strong>የምርት</strong> መረጃ <span class="badge badge-danger float-right mt-1">
                                                                   
                                                       
                                                                                                                    </span>
                                
                                                    </div>
                       
                        <section class="card ">
                                                    <div class="card-body card-block">
                                                                <div class="row">    
                                                                     <div class="col-6">
                                                         <div class="row form-group">
                                                                    <div class="col col-md-4">
                                                                        <label for="selectSm" class=" form-control-label">የትዕዛዝ መላያ

                                                                        </label></div>
                                                                    <div class="col col-md-4">
                                                                        
                                                                    <asp:TextBox ID="TextBoxorderid" runat="server"  placeholder="የትዕዛዝ መላያ" class="form-control-sm is-invalid form-control" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                             <div class="col col-md-4">
                                                                           <asp:Button ID="Buttongenordrid" runat="server"  class="btn btn-primary btn-sm btn-block" Text="አዲስ የትዕዛዝ መላያ" OnClick="gnereateorderid" />
                                             
                                                                     </div>
                                                                </div>
                                                            </div>
                                                                     <div class="col-6">
                                                                <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የምርት አይነት </label></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                        <asp:DropDownList ID="DropDownListprotype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="enableprobrand" Enabled="False">
                                                                         <asp:ListItem Value="0">--የምርት አይነት ምረጥ--</asp:ListItem>
                                                                         <asp:ListItem>Ordered</asp:ListItem>
                                                                         
                                                                            
                                                                             <asp:ListItem>Service</asp:ListItem>
                                                                  
                                                                        </asp:DropDownList>
                                                                        
                                                                      
                                                                    </div>
                                                                </div>
                                                              </div>
                                                                           </div> <%--row 1--%>
                                                        <div class="row">

                                                             <div class="col-6">
                                                                <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የጥሬ ዕቃ ስም </label></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                        <asp:DropDownList ID="DropDownListprobrand" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="enableprogage" ></asp:DropDownList>
                                                                      
                                                                    </div>
                                                                </div>
                                                              </div>
                                                                     <div class="col-6">
                                                                <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የጥሬ ዕቃ ጌጅ </label></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                        <asp:DropDownList ID="DropDownListprogage" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="enableproname" Enabled="False"></asp:DropDownList>
                                                                      
                                                                    </div>
                                                                </div>
                                                              </div>
                                                        </div> <%--row 2--%>
                                                        <div class="row">

                                                            <div class="col-6">
                                                                 <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የምርት ስም </label></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                        <asp:DropDownList ID="DropDownListproname" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="enableproshape"></asp:DropDownList>
                                                                        
                                                                      
                                                                    </div>
                                                                </div>
                                                            </div>
                                                                    
                                                         
                                                        
                                                        <div class="col-6">
                                                         <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የምርት ስፋት </label></div>
                                                                    <div class="col-12 col-md-8">
                                                                       
                                                                         
                                                                       <asp:TextBox ID="TextBoxproductsize"  class="form-control-sm is-invalid form-control" runat="server"  Visible="False"></asp:TextBox>
                                                               
                                                                         <asp:RegularExpressionValidator ID="RegularExpreprosize" runat="server" ControlToValidate="TextBoxproductsize" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                   
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div> <%--row 3--%>
                                                                    
                                                                    <div class="row">
                                                                   <div class="col-6">
                                                                     <div class="row form-group">
                                                                    <div class="col col-md-4"><label  class=" form-control-label">የምርት መግለጫ</label><br>
                                                                         <small class="for-text text-muted"><code>ለአሸንዳና ኮፒንግ</code></small>
                                                                    </div>
                                                                    <div class="col-12 col-md-8">
                                                                         <div class="col col-md-3">
                                                                             <asp:DropDownList ID="DropDownList1" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True"  Visible="False">
                                                                                 <asp:ListItem Value="0">--ሆድ--</asp:ListItem>
                                                                                 <asp:ListItem Value="No">No</asp:ListItem>
                                                                                 <asp:ListItem>1</asp:ListItem>
                                                                                 <asp:ListItem>2</asp:ListItem>
                                                                                 <asp:ListItem>3</asp:ListItem>
                                                                                 <asp:ListItem>4</asp:ListItem>
                                                                                 <asp:ListItem>5</asp:ListItem>
                                                                                 <asp:ListItem>6</asp:ListItem>
                                                                                 <asp:ListItem>7</asp:ListItem>
                                                                                 <asp:ListItem>8</asp:ListItem>
                                                                                 <asp:ListItem>9</asp:ListItem>
                                                                                 <asp:ListItem>10</asp:ListItem>
                                                                                 <asp:ListItem>11</asp:ListItem>
                                                                                 <asp:ListItem>12</asp:ListItem>
                                                                                 <asp:ListItem>13</asp:ListItem>
                                                                                 <asp:ListItem>14</asp:ListItem>
                                                                                 <asp:ListItem>15</asp:ListItem>
                                                                                 <asp:ListItem>16</asp:ListItem>
                                                                                 <asp:ListItem>17</asp:ListItem>
                                                                                 <asp:ListItem>18</asp:ListItem>
                                                                                 <asp:ListItem>19</asp:ListItem>
                                                                                 <asp:ListItem>20</asp:ListItem>
                                                                                 <asp:ListItem>21</asp:ListItem>
                                                                                 <asp:ListItem>22</asp:ListItem>
                                                                                 <asp:ListItem>23</asp:ListItem>
                                                                                 <asp:ListItem>24</asp:ListItem>
                                                                                 <asp:ListItem>25</asp:ListItem>
                                                                                 <asp:ListItem>26</asp:ListItem>
                                                                                 <asp:ListItem>27</asp:ListItem>
                                                                                 <asp:ListItem>28</asp:ListItem>
                                                                                 <asp:ListItem>29</asp:ListItem>
                                                                                 <asp:ListItem>30</asp:ListItem>
                                                                                  <asp:ListItem>31</asp:ListItem>
                                                                                 <asp:ListItem>32</asp:ListItem>
                                                                                 <asp:ListItem>33</asp:ListItem>
                                                                                 <asp:ListItem>34</asp:ListItem>
                                                                                 <asp:ListItem>35</asp:ListItem>
                                                                                 <asp:ListItem>36</asp:ListItem>
                                                                                 <asp:ListItem>37</asp:ListItem>
                                                                                 <asp:ListItem>38</asp:ListItem>
                                                                                 <asp:ListItem>39</asp:ListItem>
                                                                                 <asp:ListItem>40</asp:ListItem>
                                                                                 <asp:ListItem>41</asp:ListItem>
                                                                                 <asp:ListItem>42</asp:ListItem>
                                                                                 <asp:ListItem>43</asp:ListItem>
                                                                                 <asp:ListItem>44</asp:ListItem>
                                                                                 <asp:ListItem>45</asp:ListItem>
                                                                                 <asp:ListItem>46</asp:ListItem>
                                                                                  <asp:ListItem>47</asp:ListItem>
                                                                                 <asp:ListItem>48</asp:ListItem>
                                                                                 <asp:ListItem>49</asp:ListItem>
                                                                                 <asp:ListItem>50</asp:ListItem>
                                                                             </asp:DropDownList>
                                                                         <small class="for-text text-muted"><code>ሆድ</code></small>
                                                                        </div>
                                                                          <div class="col col-md-3">
                                                                                       <asp:DropDownList ID="DropDownList2" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True" Visible="False" >
                                                                                 <asp:ListItem Value="0">--ቋሚ--</asp:ListItem>
                                                                                           <asp:ListItem Value="No">No</asp:ListItem>
                                                                                 <asp:ListItem>1</asp:ListItem>
                                                                                 <asp:ListItem>2</asp:ListItem>
                                                                                 <asp:ListItem>3</asp:ListItem>
                                                                                 <asp:ListItem>4</asp:ListItem>
                                                                                 <asp:ListItem>5</asp:ListItem>
                                                                                 <asp:ListItem>6</asp:ListItem>
                                                                                 <asp:ListItem>7</asp:ListItem>
                                                                                 <asp:ListItem>8</asp:ListItem>
                                                                                 <asp:ListItem>9</asp:ListItem>
                                                                                 <asp:ListItem>10</asp:ListItem>
                                                                                 <asp:ListItem>11</asp:ListItem>
                                                                                 <asp:ListItem>12</asp:ListItem>
                                                                                 <asp:ListItem>13</asp:ListItem>
                                                                                 <asp:ListItem>14</asp:ListItem>
                                                                                 <asp:ListItem>15</asp:ListItem>
                                                                                 <asp:ListItem>16</asp:ListItem>
                                                                                 <asp:ListItem>17</asp:ListItem>
                                                                                 <asp:ListItem>18</asp:ListItem>
                                                                                 <asp:ListItem>19</asp:ListItem>
                                                                                 <asp:ListItem>20</asp:ListItem>
                                                                                 <asp:ListItem>21</asp:ListItem>
                                                                                 <asp:ListItem>22</asp:ListItem>
                                                                                 <asp:ListItem>23</asp:ListItem>
                                                                                 <asp:ListItem>24</asp:ListItem>
                                                                                 <asp:ListItem>25</asp:ListItem>
                                                                                 <asp:ListItem>26</asp:ListItem>
                                                                                 <asp:ListItem>27</asp:ListItem>
                                                                                 <asp:ListItem>28</asp:ListItem>
                                                                                 <asp:ListItem>29</asp:ListItem>
                                                                                 <asp:ListItem>30</asp:ListItem>
                                                                                            <asp:ListItem>31</asp:ListItem>
                                                                                 <asp:ListItem>32</asp:ListItem>
                                                                                 <asp:ListItem>33</asp:ListItem>
                                                                                 <asp:ListItem>34</asp:ListItem>
                                                                                 <asp:ListItem>35</asp:ListItem>
                                                                                 <asp:ListItem>36</asp:ListItem>
                                                                                 <asp:ListItem>37</asp:ListItem>
                                                                                 <asp:ListItem>38</asp:ListItem>
                                                                                 <asp:ListItem>39</asp:ListItem>
                                                                                 <asp:ListItem>40</asp:ListItem>
                                                                                 <asp:ListItem>41</asp:ListItem>
                                                                                 <asp:ListItem>42</asp:ListItem>
                                                                                 <asp:ListItem>43</asp:ListItem>
                                                                                 <asp:ListItem>44</asp:ListItem>
                                                                                 <asp:ListItem>45</asp:ListItem>
                                                                                 <asp:ListItem>46</asp:ListItem>
                                                                                  <asp:ListItem>47</asp:ListItem>
                                                                                 <asp:ListItem>48</asp:ListItem>
                                                                                 <asp:ListItem>49</asp:ListItem>
                                                                                 <asp:ListItem>50</asp:ListItem>
                                                                             </asp:DropDownList>
                                                                      <small class="for-text text-muted"><code>ቋሚ</code></small>
                                                                          </div>
                                                                          <div class="col col-md-3">
                                                                                      <asp:DropDownList ID="DropDownList3" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True" Visible="False" >
                                                                                 <asp:ListItem Value="0">--ቀሪ--</asp:ListItem>
                                                                                          <asp:ListItem Value="No">No</asp:ListItem>
                                                                                 <asp:ListItem>1</asp:ListItem>
                                                                                 <asp:ListItem>2</asp:ListItem>
                                                                                 <asp:ListItem>3</asp:ListItem>
                                                                                 <asp:ListItem>4</asp:ListItem>
                                                                                 <asp:ListItem>5</asp:ListItem>
                                                                                 <asp:ListItem>6</asp:ListItem>
                                                                                 <asp:ListItem>7</asp:ListItem>
                                                                                 <asp:ListItem>8</asp:ListItem>
                                                                                 <asp:ListItem>9</asp:ListItem>
                                                                                 <asp:ListItem>10</asp:ListItem>
                                                                                 <asp:ListItem>11</asp:ListItem>
                                                                                 <asp:ListItem>12</asp:ListItem>
                                                                                 <asp:ListItem>13</asp:ListItem>
                                                                                 <asp:ListItem>14</asp:ListItem>
                                                                                 <asp:ListItem>15</asp:ListItem>
                                                                                 <asp:ListItem>16</asp:ListItem>
                                                                                 <asp:ListItem>17</asp:ListItem>
                                                                                 <asp:ListItem>18</asp:ListItem>
                                                                                 <asp:ListItem>19</asp:ListItem>
                                                                                 <asp:ListItem>20</asp:ListItem>
                                                                                 <asp:ListItem>21</asp:ListItem>
                                                                                 <asp:ListItem>22</asp:ListItem>
                                                                                 <asp:ListItem>23</asp:ListItem>
                                                                                 <asp:ListItem>24</asp:ListItem>
                                                                                 <asp:ListItem>25</asp:ListItem>
                                                                                 <asp:ListItem>26</asp:ListItem>
                                                                                 <asp:ListItem>27</asp:ListItem>
                                                                                 <asp:ListItem>28</asp:ListItem>
                                                                                 <asp:ListItem>29</asp:ListItem>
                                                                                 <asp:ListItem>30</asp:ListItem>
                                                                                           <asp:ListItem>31</asp:ListItem>
                                                                                 <asp:ListItem>32</asp:ListItem>
                                                                                 <asp:ListItem>33</asp:ListItem>
                                                                                 <asp:ListItem>34</asp:ListItem>
                                                                                 <asp:ListItem>35</asp:ListItem>
                                                                                 <asp:ListItem>36</asp:ListItem>
                                                                                 <asp:ListItem>37</asp:ListItem>
                                                                                 <asp:ListItem>38</asp:ListItem>
                                                                                 <asp:ListItem>39</asp:ListItem>
                                                                                 <asp:ListItem>40</asp:ListItem>
                                                                                 <asp:ListItem>41</asp:ListItem>
                                                                                 <asp:ListItem>42</asp:ListItem>
                                                                                 <asp:ListItem>43</asp:ListItem>
                                                                                 <asp:ListItem>44</asp:ListItem>
                                                                                 <asp:ListItem>45</asp:ListItem>
                                                                                 <asp:ListItem>46</asp:ListItem>
                                                                                  <asp:ListItem>47</asp:ListItem>
                                                                                 <asp:ListItem>48</asp:ListItem>
                                                                                 <asp:ListItem>49</asp:ListItem>
                                                                                 <asp:ListItem>50</asp:ListItem>
                                                                             </asp:DropDownList>
                                                                      <small class="for-text text-muted"><code>ቀሪ</code></small>
                                                                          </div>
                                                                          <div class="col col-md-3">
                                                                                      <asp:DropDownList ID="DropDownList4" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True" Visible="False"  >
                                                                                 <asp:ListItem Value="0">--ጭራ--</asp:ListItem>
                                                                                          <asp:ListItem Value="No">No</asp:ListItem>
                                                                                 <asp:ListItem>1</asp:ListItem>
                                                                                 <asp:ListItem>2</asp:ListItem>
                                                                                 <asp:ListItem>3</asp:ListItem>
                                                                                 <asp:ListItem>4</asp:ListItem>
                                                                                 <asp:ListItem>5</asp:ListItem>
                                                                                 <asp:ListItem>6</asp:ListItem>
                                                                                 <asp:ListItem>7</asp:ListItem>
                                                                                 <asp:ListItem>8</asp:ListItem>
                                                                                 <asp:ListItem>9</asp:ListItem>
                                                                                 <asp:ListItem>10</asp:ListItem>
                                                                                 <asp:ListItem>11</asp:ListItem>
                                                                                 <asp:ListItem>12</asp:ListItem>
                                                                                 <asp:ListItem>13</asp:ListItem>
                                                                                 <asp:ListItem>14</asp:ListItem>
                                                                                 <asp:ListItem>15</asp:ListItem>
                                                                                 <asp:ListItem>16</asp:ListItem>
                                                                                 <asp:ListItem>17</asp:ListItem>
                                                                                 <asp:ListItem>18</asp:ListItem>
                                                                                 <asp:ListItem>19</asp:ListItem>
                                                                                 <asp:ListItem>20</asp:ListItem>
                                                                                 <asp:ListItem>21</asp:ListItem>
                                                                                 <asp:ListItem>22</asp:ListItem>
                                                                                 <asp:ListItem>23</asp:ListItem>
                                                                                 <asp:ListItem>24</asp:ListItem>
                                                                                 <asp:ListItem>25</asp:ListItem>
                                                                                 <asp:ListItem>26</asp:ListItem>
                                                                                 <asp:ListItem>27</asp:ListItem>
                                                                                 <asp:ListItem>28</asp:ListItem>
                                                                                 <asp:ListItem>29</asp:ListItem>
                                                                                 <asp:ListItem>30</asp:ListItem>
                                                                                           <asp:ListItem>31</asp:ListItem>
                                                                                 <asp:ListItem>32</asp:ListItem>
                                                                                 <asp:ListItem>33</asp:ListItem>
                                                                                 <asp:ListItem>34</asp:ListItem>
                                                                                 <asp:ListItem>35</asp:ListItem>
                                                                                 <asp:ListItem>36</asp:ListItem>
                                                                                 <asp:ListItem>37</asp:ListItem>
                                                                                 <asp:ListItem>38</asp:ListItem>
                                                                                 <asp:ListItem>39</asp:ListItem>
                                                                                 <asp:ListItem>40</asp:ListItem>
                                                                                 <asp:ListItem>41</asp:ListItem>
                                                                                 <asp:ListItem>42</asp:ListItem>
                                                                                 <asp:ListItem>43</asp:ListItem>
                                                                                 <asp:ListItem>44</asp:ListItem>
                                                                                 <asp:ListItem>45</asp:ListItem>
                                                                                 <asp:ListItem>46</asp:ListItem>
                                                                                  <asp:ListItem>47</asp:ListItem>
                                                                                 <asp:ListItem>48</asp:ListItem>
                                                                                 <asp:ListItem>49</asp:ListItem>
                                                                                 <asp:ListItem>50</asp:ListItem>
                                                                             </asp:DropDownList>
                                                                      <small class="for-text text-muted"><code>ጭራ</code></small>
                                                                          </div>
                                                                      
                                                                        </div>
                                                              
                                                                </div>

                                                                    </div>

                                                               <div class="col-6">
                                                                   <div class="row form-group">
                                                                    <div class="col col-md-4"><label  class=" form-control-label">የምርት ርዝመት</label></div>
                                                                    <div class="col-12 col-md-8">
                                                                    <asp:TextBox ID="TextBoxlen" runat="server"  class="form-control-sm is-invalid form-control" Visible="false"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExprelength" runat="server" ControlToValidate="TextBoxlen" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                     
                                                                    </div>
                                                                </div>
                                                       
                                                            </div>

                                                                    </div> <%--row 4--%>
                                                          
                                                              <div class="row">
                                              <div class="col-6">
                                                        <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የምርት ቅርፅ</label></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                        <asp:DropDownList ID="DropDownListproshape" class="form-control-sm is-invalid form-control" runat="server"  AppendDataBoundItems="True"  ViewStateMode="Enabled" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="enableshapespecific"></asp:DropDownList>
                                                                        
                                                                      
                                                                    </div>
                                                                </div>
                                                          </div>
                                                         <div class="col-6">

                                                         <div class="row form-group">
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">የቅርፅ መግለጫ</label></div>
                                                                    <div class="col-12 col-md-8">
                                                                    <asp:TextBox ID="TextBoxshpspecic" runat="server"  class="form-control-sm is-invalid form-control" ></asp:TextBox>
                                                                       
                                                                       
                                                                      
                                                                    </div>
                                                                </div>


                                                         </div>

                                                              </div>
                                                          

                                                             <%--row 5--%>
                                                         <div class="col-2"></div>                                                     
                                                         <div id="divMessage" class="col-8 alert with-close alert-danger alert-dismissible fade show" runat="server" style="display:none; visibility:hidden">
                                        <span class="badge badge-pill badge-danger">Alert</span>
                                         <asp:Label ID="Labelalertonbtntopr" runat="server"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                    </div>
                                                      
                                                          
                                                        <div class="col-2"></div>
                                                         </div>
                                   </section>
                                                               
                        <section class="card">
                            <div class="card-header">
                                                 <i class="fa fa-gears"></i>       <strong>የትዕዛዝ ብዛትና የቀን ዋጋ </strong> መረጃ
                                                    </div>
                            <div class="card-body text-secondary">

                                <div class="row">
                                    
                                      <div class="col-4">
                                                    <div class="row form-group">
                                                                   
                                                              <div class="col col-md-6 form-group">
                                                                    <asp:Button ID="Buttsowtdtprice" runat="server"  class="btn btn-primary btn-sm btn-block" Text="የቀኑ የምርት ዋጋ" OnClick="calculatetodayprice" />

                                                              </div>
                                                        <div class="col col-md-3 form-group">
                                                                        
                                                                       <asp:TextBox ID="TextBoxuprice"  class="form-control-sm is-invalid form-control" runat="server" enabled="false"></asp:TextBox>
                                                                 
                                                                    </div>
                                                                  <div class="col col-md-3 form-group">
                                                                       <asp:TextBox ID="TextBoxnewpriceunit"  class="form-control-sm is-invalid form-control" runat="server" ></asp:TextBox>
                                                           <asp:RegularExpressionValidator ID="Regularupr" runat="server" ControlToValidate="TextBoxnewpriceunit" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                

                                                                  </div>
                                                                </div>                  


                                                            </div>
                                    <div class="col-4">
                                         <div class="row form-group">
                                              <div class="col-2"></div>
                                                                    <div class="col-4"><label for="selectSm" class=" form-control-label">የትዕዛዝ ብዛት</label></div>
                                                                    
                                                                  
                                                                 <div class="col-6">
                                                                        
                                                                          <asp:TextBox ID="TextBoxqty" runat="server" placeholder="የትዕዛዝ ብዛት" class="form-control-sm is-invalid form-control"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExprqty" runat="server" ControlToValidate="TextBoxqty" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                 
                                                                     </div>
                                                                </div>
                                        </div>
                                    <div class="col-4">
                                         <div class="row form-group">
                                                                    <div class="col col-md-4">
                                                                         <asp:Button ID="Buttoncalcprice" runat="server"  class="btn btn-primary btn-sm btn-block" Text="ጠቅላላ ዋጋ " OnClick="calculatepriceqty" />

                                                                    </div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                     <asp:TextBox ID="TextBoxcurntprice" runat="server" placeholder="" class= "form-control-sm is-invalid form-control" Enabled="False"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                        </div>

                                     </div>
                                <div class="row">
                                      <div class="col col-md-12">
                                    <div class="col col-md-2"></div>
                                     <div class="col col-md-8">
                                             <asp:Button ID="Buttonaddorder" runat="server"  class="btn btn-primary btn-sm btn-block" Text="የምርት ዝርዝር ትዕዛዝ  ጨምር " OnClick="Addorder" visible="false"/>
                                                               </div>
                                        </div>

                                </div>
                                   
                                
                              
                           </div>
                        </section>
                
                         <section class="card">

                             
                            <div class="card-header">
                                <i class="fa fa-shopping-cart"></i><strong class="card-title pl-2">ትዕዛዝ ዝርዝር</strong> <small><span class="badge badge-danger float-right mt-1">የትዕዛዝ ጠቅላላ ዋጋ: <asp:Label ID="Labeltotalorderprice" runat="server" Text=" "></asp:Label></span></small>
                                
                            </div>
                            
                                 <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                    
                                     <asp:GridView ID="GridView3" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="6" OnPageIndexChanging="neworderlistpage" OnSelectedIndexChanged="selectandeditorder" AllowPaging="True" >


                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True" SelectText="ትዕዛዙን ሰርዝ"></asp:CommandField>
                                            
                                         </Columns>

                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                                    
                                </div>
                        </section>
                        <section class="card">
                            <div class="card-header">
                                                 <i class="fa fa-money"></i> <strong> አጠቃላይ የሂሳብ</strong> መረጃ
                                                   </div>
                            <div class="card-body text-secondary">

                                <div class="row">
                                     <div class="col-4">
                                                    <div class="row form-group">
                                                                   
                                                              <div class="col-4">
                                                                   <label for="selectSm" class=" form-control-label">የክፍያ አይነት</label>
                                                              </div>
                                                        <div class="col-8">
                                                                        
                                                                 <asp:DropDownList ID="DropDownListtransfertype" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="claculateandshowppaid" >
                                                                         <asp:ListItem Value="0">--የክፍያ አይነት ምረጥ--</asp:ListItem>
                                                                         <asp:ListItem>Cash</asp:ListItem>
                                                                         <asp:ListItem>Bank Transfer</asp:ListItem>
                                                                      <asp:ListItem>Credit</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                              
                                                                </div>                  


                                                            </div>
                                    <div class="col-4">
                                         <div class="row form-group">
                                              
                                                                    <div class="col col-md-4"><label for="selectSm" class=" form-control-label">ቀብድ መጠን</label></div>
                                                                    <div class="col col-md-8">
                                                                        
                                                                        <asp:TextBox ID="TextBoxprepaid" class="form-control-sm is-invalid form-control" runat="server"></asp:TextBox>
                                                                         <asp:RegularExpressionValidator ID="RegularExprpaid" runat="server" ControlToValidate="TextBoxprepaid" ErrorMessage="ትክክለኛ ቁጥር ያስገቡ" ValidationExpression="^\d+([,\.]\d{1,2})?$"></asp:RegularExpressionValidator>   
                                                                 
                                                                    </div>
                                               
                                                                </div>
                                        </div>
                                    <div class="col-4">
                                         <div class="row form-group">
                                                                    <div class="col col-md-4"><asp:Button ID="Buttoncalcremainpri" runat="server"  class="btn btn-primary btn-sm btn-block" Text="ቀሪ አሳይ" OnClick="calculatetotaloprice" /></div>
                                                                    <div class="col-12 col-md-8">
                                                                        
                                                                       <asp:TextBox ID="TextBoxremainprice" class="form-control-sm is-invalid form-control" runat="server" Enabled="False"></asp:TextBox>
                                                                    </div>
                                             
                                             
                                                                </div>
                                        </div>

  
                                </div>
                              
                                    
                             
                                </div>
                             <div class="row">
                           <div class="col-2"></div>
  <div class="col-8" id="banktransfer" runat="server" style="display:none; visibility:hidden">
                                                    <div class="row form-group">
                                                                   
                                                              <div class="col-6">
                                                                  <asp:DropDownList ID="DropDownListbankname" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="LoadBanacctno" >
                                                                         
                                                                        </asp:DropDownList>
                                                              </div>
                                                        <div class="col-6">
                                                                        
                                                                 <asp:DropDownList ID="DropDownListaccountno" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True"  >
                                                                         
                                                                        </asp:DropDownList>
                                                                    </div>
                                                              
                                                                </div>                  


                                                            </div>
                                    <div class="col-2"></div>
                              </div>
                                <div class="row">
                                    <div class="col-1"></div>
    <div class="col col-md-5">
                                         <div class="row form-group">
                                                                    <div class="col col-md-6">
                                                                       <label for="selectSm" class=" form-control-label">ስራው የሚሰራበት ወርክ ሾፕ አስገባ</label>
                                                                    </div>
                                                                    <div class="col col-md-6">
                                                                        
                                                                     <asp:DropDownList ID="DropDownLisinventmanlst" class="form-control-sm is-invalid form-control" runat="server" AppendDataBoundItems="True" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="loadinventoryman">
                                                                        
                                                                        </asp:DropDownList>
                                                                        </div>
                                             <div class="col col-md-2"></div>
                                             
                                                                </div>
                                        </div>
                                    <div class="col col-md-5">
                                         <div class="row form-group">
                                              <div class="col col-md-2">
                                                  
                                              </div>
                                             <div class="col col-md-5"> 
                                                
                                                 <asp:Button ID="Buttsendorder" runat="server"  class="btn btn-primary btn-sm btn-block" Text="ትዕዛዝ ላክ" OnClick="sendordertoinvent" />
                                            </div>
                                             <div class="col col-md-5">
                                                                        
                                                                       <asp:Button ID="Buttcrtneword" runat="server"  class="btn btn-primary btn-sm btn-block" Text="አዲስ ትዕዛዝ ጀምር" OnClick="CreatenewOrder" />
                                             
                                                                    </div>
                                                               </div>
                                        </div>
                                    <div class="col-1"></div>
                                </div>
                        </section>
                    </div>
                                        

                </div>
                                      
                
              
                    </div>
                             
			</div>
			</div>
             <div id ="showaccttrans" runat="server">
                       <div class="row">
                    <div class="col-md-8 offset-md-3 mr-auto ml-auto">
                        <section class="card">
                            <div class="card-body text-secondary">
                                  <div class="card">
                                                        <div class="card-header">የቀን ትዕዛዝ ዝርዝር</div>
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
                                                                    <asp:Button ID="Buttonsrchordlst"  runat="server" cssclass="btn btn-sm btn-info btn-block" Text="ትዕዛዞችን አሳይ" OnClick="searchordlst"  />        
                                                             
                                                                </div>
                                                                 <div class="col-12 col-md-4">
                                                                 
                                                                                  <asp:Button ID="btnPrintAll" runat="server" cssclass="btn btn-sm btn-info btn-block"  Text="የትዕዛዝ ዝርዝር ወደ Excel ላክ" OnClick="print"  />
                                                                     
                          
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
                                <strong class="card-title"> የትዕዛዝ ዝርዝር<small><span class="badge badge-success float-right mt-1"> አጠቃላይ የትዕዛዝ ብዛት
                                    <asp:Label ID="Labeltotalorder" runat="server" Text="Label"></asp:Label> </span></small></strong>
                          
                                </div>
                            <div class="card-body card-block" style="overflow:auto; width:1000px; height:auto">
                                <asp:GridView ID="GridVieworderlst" Cssclass="table table-striped" runat="server" ShowFooter="True" FooterStyle-BackColor="#3399FF" Font-Bold="True" HeaderStyle-BackColor="#3399FF" PageSize="20" OnPageIndexChanging="newserlistpage" AllowPaging="True" >



                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                                     </asp:GridView>
                               
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
