<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="CI_Gwap.RegistrationPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="css/demo.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
    <script src="js/modernizr.custom.25376.js"></script>
    <style type="text/css">
        #showMenu
        {
            width: 313px;
        }
    </style>
    <script language="javascript" type="text/javascript">        function showMenu_onclick() {

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="perspective" class="perspective effect-airbnb">
			<div class="container">
				<div class="wrapper"><!-- wrapper needed for scroll -->
					<!-- Top Navigation -->
					<div class="codrops-top clearfix">
					</div>
					<header class="codrops-header">
						<h1>Crime Scene Investigation, The game <span>Collective Intelligence Project- Game With A Purpose (GWAP)</span></h1>	
					</header>
					<div class="main clearfix">
						<div class="column">
                            <p>User Registration</p>
                            <p><asp:Button ID="btnComplete" runat="server" Text="Complete Registration" 
                                    Width="400" class="aspButton" onclick="btnComplete_Click"/></p>
                            <p><asp:Button ID="btnBack" runat="server" Text="Back to Main Page" 
                                    Width="400" class="aspButton" onclick="btnBack_Click"/></p>
                        </div>
						<div class="column">
                        <p id="menuButtonP" runat="server" visible="false"><button id="showMenu" 
                                    style="width:400px" onclick="return showMenu_onclick()" onclick="return showMenu_onclick()">Menu</button></p>
						
                        <p ID="usernameP" runat="server">Username:</p><p><asp:TextBox ID="txtboxUsername" runat="server" Width="400"></asp:TextBox></p>
                        <p ID="emailAddressP" runat="server">Email Address:</p><p><asp:TextBox ID="txtemailAddress" runat="server" Width="400"></asp:TextBox></p>
                        <p ID="passwordP" runat="server">Password:</p><p><asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password" Width="400"></asp:TextBox></p>
                        <p ID="countryListP" runat="server">Country:</p>
                            <p><asp:TextBox ID="txtCountry" runat="server" Width="400"></asp:TextBox></p>
                        </div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
		</div>
		<script src="js/classie.js"></script>
		<script src="js/menu.js"></script>
    </form>
</body>
</html>
