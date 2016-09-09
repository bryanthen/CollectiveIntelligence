<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="CI_Gwap.ProfilePages.ProfilePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../favicon.ico">
	<link rel="stylesheet" type="text/css" href="../css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="../css/demo.css" />
	<link rel="stylesheet" type="text/css" href="../css/component.css" />
    <script src="../js/modernizr.custom.25376.js"></script>

    <style type="text/css">
        #showMenu
        {
            width: 313px;
        }
    </style>

	<style>
		.meter {
			height: 30px;  /* Can be anything */
			position:relative;
			float:right;
			background: #555;
			-moz-border-radius: 25px;
			-webkit-border-radius: 25px;
			border-radius: 25px;
			padding: 10px;
			-webkit-box-shadow: inset 0 -1px 1px rgba(255,255,255,0.3);
			-moz-box-shadow   : inset 0 -1px 1px rgba(255,255,255,0.3);
			box-shadow        : inset 0 -1px 1px rgba(255,255,255,0.3);
		}
		.meter span
		{
		    color:White;
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
                        <div class="fullcolumn">
                            <p id="menuButtonP" runat="server" class="columnText">
                         <button id="showMenu" style="width:400px" onclick="return showMenu_onclick()">Menu</button></p>
                        </div>
						<div class="column">
                            <p>
                                <asp:Label ID="lblLevel" runat="server"></asp:Label>
                            </p>

                            <p>User Experience Points
                                <div class="meter" id="userExperienceMeter" style="width:50%" runat="server">
                                    <span>
                                        <asp:Label ID="lblUserExperienceMeter" runat="server"></asp:Label>
                                    </span>
                                </div>
                            </p>
                            <p></p>
						</div>

						<div class="column">
                            <p>
                                <asp:Label ID="lblStatusLevel" runat="server"></asp:Label>
                            </p>

                            <p>Status Experience Points
                                <div class="meter" id="userStatusExperienceMeter" style="width:30%" runat="server">
                                    <span>
                                        <asp:Label ID="lblUserStatusExperienceMeter" runat="server"></asp:Label>
                                    </span>
                                </div>
                            </p>
                            <p></p>
						</div>
						<div class="related">
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
			<nav class="outer-nav left vertical">
				<a href="../HomePage.aspx" class="icon-home">Home</a>
                <a href="#" class="icon-lock">Profile</a>
				<a href="../PlayPages/MatchPlayer.aspx" class="icon-image">Play</a>
                <a href="../LeaderboardPages/LeaderboardPage.aspx?UserCheck=true" class="icon-star">Leaderboard</a>
                <a href="../LogOutPage.aspx" class="icon-upload">User Log Out</a>
			</nav>
		</div>
		<script src="../js/classie.js"></script>
		<script src="../js/menu.js"></script>
    </form>
</body>
</html>
