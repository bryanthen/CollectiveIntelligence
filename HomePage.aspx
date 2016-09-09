<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CI_Gwap.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../favicon.ico">
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
    <script language="javascript" type="text/javascript"></script>
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
							
							<p>This is a Game With A Purpose for Collective Intelligence Project.</p>
                            <p>Designed by Bryan Then</p>
                            <p>Supervised by Dr. Michael</p>
						</div>
						<div class="column">
                        <p id="menuButtonP" runat="server" visible="false"><button id="showMenu" 
                                    style="width:400px" onclick="return showMenu_onclick()">Menu</button></p>

                            <p ID="usernameP" runat="server">Username:</p><p><asp:TextBox ID="txtboxUsername" runat="server" Width="400"></asp:TextBox></p>
                            <p ID="passwordP" runat="server">Password:</p><p><asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password" Width="400"></asp:TextBox></p>
                            <p><asp:Button ID="btnLogin" runat="server" Text="Log In" Width="400" class="aspButton" Visible="true" onclick="btnLogin_Click"/></p>
						</div>
						<div class="related">
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
			<nav class="outer-nav left vertical">
				<a href="HomePage.aspx" class="icon-home">Home</a>
                <a href="ProfilePages/ProfilePage.aspx" class="icon-lock">Profile</a>
				<a href="PlayPages/MatchPlayer.aspx" class="icon-image">Play</a>
                <a href="LeaderboardPages/LeaderboardPage.aspx?UserCheck=true" class="icon-star">Leaderboard</a>
                <a href="LogOutPage.aspx" class="icon-upload">User Log Out</a>
			</nav>
		</div>
		<script src="js/classie.js"></script>
		<script src="js/menu.js"></script>
    </form>
</body>
</html>
