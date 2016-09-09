<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaderboardPage.aspx.cs" Inherits="CI_Gwap.LeaderboardPages.LeaderboardPage" %>

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
                            <p><asp:Label ID="userRankinglbl" runat="server" CssClass="columnText"></asp:Label></p>
                            <p id="menuButtonP" runat="server" class="columnText">
                            <button id="showMenu" style="width:400px" onclick="return showMenu_onclick()">Menu</button></p>
                        </div>
						<div class="column">
                            <p>All Time Leaderboard</p>
                            <asp:GridView ID="alltimeGridView" runat="server" CellPadding="4" 
                                ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>

                            <asp:GridView ID="hiddenUserGridView" runat="server" Visible="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
						</div>

						<div class="column">
                            <p style="float:left">Weekly Leaderboard</p>
                            <asp:Label ID="lblWeekly" runat="server" Width="400px" Font-Size="2em"></asp:Label>
                            <asp:GridView ID="weeklyGridView" runat="server" CellPadding="4" 
                                ForeColor="#333333" GridLines="None" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
						</div>
						<div class="related">
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
			<nav class="outer-nav left vertical">
				<a href="../HomePage.aspx" class="icon-home">Home</a>
                <a href="../ProfilePages/ProfilePage.aspx" class="icon-lock">Profile</a>
				<a href="../PlayPages/MatchPlayer.aspx" class="icon-image">Play</a>
                <a href="#" class="icon-star">Leaderboard</a>
                <a href="../LogOutPage.aspx" class="icon-upload">User Log Out</a>
			</nav>
		</div>
		<script src="../js/classie.js"></script>
		<script src="../js/menu.js"></script>
    </form>
</body>
</html>
