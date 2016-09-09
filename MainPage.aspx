<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CI_Gwap.TestingWebform1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/mainPage/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/mainPage/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/mainPage/component.css" />
		<link href='http://fonts.googleapis.com/css?family=Raleway:200,400,800' rel='stylesheet' type='text/css'>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container demo-1">
			<div class="content">
				<div id="large-header" class="large-header">
					<canvas id="demo-canvas"></canvas>
					<h1 class="main-title">Connecting<span class="thin">Clues</span></h1>
				</div>
				<div class="codrops-top clearfix">
				
				</div>
				<div class="codrops-header">
					<h1>Crime Scene Investigation, The game <span>Collective Intelligence Project- Game With A Purpose (GWAP)</span></h1>	
                    
                    <nav class="codrops-demos">
						<a class="current-demo" href="#">Main Page</a>
						<a href="HomePage.aspx">User Login</a>
						<a href="RegistrationPage.aspx">User Registration</a>
                        <a href="../ResolvePages/CrimeSolvedStatistics.aspx">Game Play Statistics</a>
                        <a href="ContactUsPage.aspx">Contact Us</a>
                        <a href="PresentationPage.aspx">Presentation</a>
					</nav>

                    </div>
				</div>
			</div>
			<!-- Related demos -->
			<section class="related">
                <p>Leaderboard</p>
                <p>All Time Leaderboard</p>
                <div style="text-align:center; width:20%; margin-left:auto; margin-right:auto">
                   <asp:GridView ID="alltimeGridView" runat="server" CellPadding="4"
                    oreColor="#333333" GridLines="None">
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

                   <p>Weekly Leaderboard</p>
                    <p><asp:Label ID="lblWeekly" runat="server"></asp:Label></p>
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
			</section>

		</div><!-- /container -->
		<script src="js/mainPage/TweenLite.min.js"></script>
		<script src="js/mainPage/EasePack.min.js"></script>
		<script src="js/mainPage/rAF.js"></script>
		<script src="js/mainPage/demo-1.js"></script>
    </form>
</body>
</html>
