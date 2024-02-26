<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SGIMSIMS.login" %>

<!DOCTYPE html>


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

    <link rel="stylesheet" href="assets/css/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>



</head>

<body class="bg-dark">


    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <a href="index.html">
					  <img src="images/logo2.png" width = "70px" height="70px" alt=""/>
<label>WelCome To SGIMIMS</label>
                    </a>
                </div>
                <div class="login-form">
                    <form runat="server">
                        <div class="row form-group">
                            <div class="col col-md-3"><label>User Name</label></div>    
                     
                         <div class="col-12 col-md-9" >  <asp:TextBox ID="TextBoxun" runat="server" cssclass="form-control-sm form-control" AutoCompleteType="Disabled"></asp:TextBox></div>
                     
                         
                            </div>
                            <div class="row form-group">
                               <div class="col col-md-3">  <label>Password</label></div>
                             <div class="col-12 col-md-9" > <asp:TextBox ID="TextBoxpass"  runat="server" textmode="password" cssclass="form-control-sm form-control" ></asp:TextBox></div>
                        </div>
						 <div class="row form-group">
                               <div class="col col-md-3">  <label>User Roll</label></div>
                              
                       <div class="col-12 col-md-9" >       <asp:DropDownList runat="server" ID="DropDownListur"  cssclass="form-control-sm form-control" >

                                 <asp:ListItem Value="0">--Select UserRoll--</asp:ListItem>
                                 <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                 <asp:ListItem Text="Sales Manager" Value="2"></asp:ListItem>

                                 <asp:ListItem Text="Inventory Manager" Value="3"></asp:ListItem>
                             </asp:DropDownList></div>
                        </div>
                         <div class="row form-group">
                             <div class="col col-md-3">    <label>User Shop</label></div>
                              
                                <div class="col-12 col-md-9" >    <asp:DropDownList runat="server" ID="DropDownListas"  cssclass="form-control-sm form-control" >

                             </asp:DropDownList></div>
                        </div>
                                <div class="checkbox">
                                    <label>
                               
                                        <asp:CheckBox  runat="server" ID="CheckBoxrembrme"  Text=" Remember Me" />
                            </label>
                                   

                                </div>
                      
                        <asp:Button ID="Buttonsignin"  runat="server" cssclass="btn btn-success btn-flat m-b-30 m-t-30" Text="Sign In" OnClick="Buttonsignin_Click" />
                                
                    </form>
                </div>
            </div>
        </div>
    </div>


    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>


</body>

</html>
