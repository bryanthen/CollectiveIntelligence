<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchPlayer.aspx.cs" Inherits="CI_Gwap.PlayPages.MatchPlayer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../favicon.ico">
	<link rel="stylesheet" type="text/css" href="../css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="../css/demo.css" />
	<link rel="stylesheet" type="text/css" href="../css/component.css" />
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
                            <asp:Label ID="lblMatchingText" runat="server" class="columnText"></asp:Label>
                            <p></p>
                            <asp:Image ID="loadingImage" runat="server" ImageUrl="~/images/loading.gif" Visible="false" />
						    <p></p>
                            <asp:Button ID="btnSearch" class="aspButton" runat="server" Text="Search" Width="500px" Height="50px" onclick="btnSearch_Click"/>
                             <p></p>
                             <asp:Button ID="btnReady" class="aspButton" runat="server" Text="Ready and Start" Width="500px" Height="50px" onclick="btnReady_Click" Visible="false"/>
                        </div>
						
						<div class="related">
                            <asp:GridView ID="gridViewOnlineUsers" runat="server" Visible="false">
                            </asp:GridView>
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
		</div>
    </form>
</body>
</html>
