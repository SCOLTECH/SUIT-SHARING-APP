<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Pageaspx.aspx.cs" Inherits="FinalFYP.BootstrapCSS_Login.Login_Pageaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
<!--===============================================================================================-->	
   <link rel="icon" type="image/png" href="BootstrapCSS_Login/images/icons/favicon.ico"/>
<!--===============================================================================================-->
    <link href="BootstrapCSS_Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<!--===============================================================================================-->
   
     <link href="BootstrapCSS_Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
<!--===============================================================================================-->
   
     <link href="BootstrapCSS_Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css" rel="stylesheet" type="text/css" />
<!--===============================================================================================-->
    
    <link href="BootstrapCSS_Login/vendor/animate/animate.css" rel="stylesheet" type="text/css" />
<!--===============================================================================================-->	
	
    <link href="BootstrapCSS_Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
<!--===============================================================================================-->
	 <link href="BootstrapCSS_Login/vendor/select2/select2.min.css" rel="stylesheet" />
<!--===============================================================================================-->
	<link href="BootstrapCSS_Login/css/util.css" rel="stylesheet" />
    <link href="BootstrapCSS_Login/css/main.css" rel="stylesheet" />
  
<!--===============================================================================================-->


    <title>Suit Sharing</title>
   


 
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100 pt-0" >
                <div class="wrap-login100 pt-0" >
                    
                        <div class="login100-form-avatar">
                            <img src="BootstrapCSS_Login/images/avatar-01.jpg" alt="LOGO" />
                        </div>

                        <span class="login100-form-title p-t-20 p-b-20">LOGIN
                        <h6>SUIT SHARING</h6>
                        </span>

                        <asp:ScriptManager ID="Scrip1" runat="server"></asp:ScriptManager>
                           <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>

                        <div class="wrap-input100 validate-input m-b-10" data-validate="Username is required">
                           
                            <asp:DropDownList ID="combo_UserType" AutoPostBack="True" runat="server" AppendDataBoundItems="True"
                                CssClass="input100" Width="100%" Height="40px">
                                <asp:ListItem Value="0" Text="Select User Type"></asp:ListItem>
                                <asp:ListItem>Coordinator</asp:ListItem>
                                <asp:ListItem>Teacher</asp:ListItem>
                            </asp:DropDownList>
                            
                            <%--<input class="" type="text" name="username" placeholder="Username" />--%>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-user"></i>
                            </span>
                        </div>

                        
                        <div class="wrap-input100 validate-input m-b-10" data-validate="Username is required">

                            <asp:TextBox ID="txtUserName" runat="server" class="input100" placeholder="example@suit.net" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-user"></i>
                            </span>
                        </div>
                        
                        <div class="wrap-input100 validate-input m-b-10" data-validate="Password is required">

                            <asp:TextBox ID="txtPassword" runat="server" type="password" class="input100" placeholder="Password" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-lock"></i>
                            </span>
                        </div>
                               </ContentTemplate></asp:UpdatePanel>
                        <div class="container-login100-form-btn p-t-10">
                            <button class="login100-form-btn">
                                <asp:Button ID="btnLogin" runat="server" Text="Login"  OnClick="btnLogin_Click" CssClass="login100-form-btn" />
                            </button>
                            </div></div>
                        </div>
                        
                       </div>
            </div>
        </div>





    </form>
                            <!--Scripts-->
<!--===============================================================================================-->	
	<script src="BootstrapCSS_Login/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="BootstrapCSS_Login/vendor/bootstrap/js/popper.js"></script>
	<script src="BootstrapCSS_Login/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="BootstrapCSS_Login/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="BootstrapCSS_Login/js/main.js"></script>
</body>
</html>
