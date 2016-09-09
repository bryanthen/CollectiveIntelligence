<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayPage.aspx.cs" Inherits="CI_Gwap.PlayPages.PlayPage" %>

<%@ Register Assembly="ASPNetVideo.NET4" Namespace="ASPNetVideo" TagPrefix="ASPNetVideo" %>

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

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="../js/countdown/countdown.js"></script>
    <script src="../js/countdown/countdown.min.js"></script>
    <script src="../js/countdown/jquery.countdown.js"></script>
    <script src="../js/countdown/jquery.countdown.min.js"></script>
    <%--<link rel="stylesheet" type="text/css" href="../css/countdown_style.css" />--%>

    <script type="text/javascript">
        $(function () {
        var v_time = <%=v_timerCount %>;
            $('.countdown.styled').countdown({
                date: +(new Date) + v_time,
                render: function (data) {
                    //$(this.el).text(this.leadingZeros(data.sec, 2) + " sec");
                    $(this.el).html("<div><div>" + this.leadingZeros(data.hours, 2) + "<span>hrs</span></div><div>" + this.leadingZeros(data.min, 2) + " <span>min</span></div><div>" + this.leadingZeros(data.sec, 2) + " <span>sec</span></div><span>Timer</span><div>");
                },
                onEnd: function () {
//                    document.getElementById('<%=cmdCompleteGameField.ClientID%>').click();
                }
            })
        });
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
					    <h1>Crime Scene Investigation, The game</h1>
                        <asp:Label ID="headerLabel" runat="server"></asp:Label>
                        
                        <%--<h1>Crime Solving In Process</h1>--%>          
                    </header>
					<div class="main clearfix">
						<div class="column">
                            <span>Image</span>
                                <asp:Image ID="questionImage" class="questionImage" runat="server" />
						</div>
						<div class="column">
                            <div class="column2">
                                <div class="countdown styled"></div>
                            </div>
                            <div class="column3">
                                <div class="styled">
                                    <div>
                                        <asp:TextBox class="scoreBox" ID="txtboxScore" runat="server" Width="250px" 
                                            ReadOnly="true" BorderStyle="None"></asp:TextBox>
                                        <span>Score</span>
                                    </div>
                                </div>
                            </div>

                            <asp:TextBox ID="txtQuestion" class="questionText" runat="server" ReadOnly="True" 
                                BorderStyle="Dotted" TextMode="MultiLine" Width="450px" Height="150px"></asp:TextBox>
                            
                            <p></p>

                                <div class="column2">
                                    <span>Crime Type :</span>
                                </div>
                                <div class="column3">
                                    <asp:Label ID="lblCrimeType" class="crimeLabel" runat="server" Width="400px"></asp:Label>
                                </div>

                                <div class="column2">
                                    <span>Crime Location :</span>
                                </div>
                                <div class="column3">
                                    <asp:Label ID="lblCrimeCountry" class="crimeLabel" runat="server" Width="450px"></asp:Label>
                                </div>
						</div>
						<div class="related">
                            <p><asp:LinkButton ID="linkButton" Text="Give Up" runat="server" 
                                    onclick="linkButton_Click"></asp:LinkButton></p>
                            <div class="answerColumn">
                                <asp:ImageButton ID="imageOptionOne" class="answerImage" runat="server" 
                                    onclick="imageOptionOne_Click"/>
                                <p></p>
                            </div>
                            <div class="answerColumn">
                                <asp:ImageButton ID="imageOptionTwo" class="answerImage" runat="server" 
                                    onclick="imageOptionTwo_Click" />
                            </div>
                            <div class="answerColumn">
                                <asp:ImageButton ID="imageOptionThree" class="answerImage" runat="server" 
                                    onclick="imageOptionThree_Click" />
                            </div>
                            <div class="answerColumn">
                                <asp:ImageButton ID="imageOptionFour" class="answerImage" runat="server" 
                                    onclick="imageOptionFour_Click" />
                            </div>

                            <div>
                             <asp:Label ID="hiddenLabel" runat="server" Visible="false"></asp:Label>
                                <asp:ScriptManager ID="SM1" runat="server" />
                                <asp:UpdatePanel ID="UP_Timer" runat="server" RenderMode="Inline" UpdateMode="Always">
                                    <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick"/>
                                        <asp:Literal ID="lit_Timer" runat="server" Visible="false"/><br />
                                        <asp:HiddenField ID="hid_Ticker" runat="server" Value="0"  Visible="false"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
						</div>
					</div><!-- /main -->
				</div><!-- wrapper -->
			</div><!-- /container -->
			<nav class="outer-nav left vertical">
				<a href="#" class="icon-home">Home</a>
                <a href="#" class="icon-star">Profile</a>
				<a href="#" class="icon-image">Play</a>
                <a href="#" class="icon-news">Leaderboard</a>
				<a href="#" class="icon-upload">Uploads</a>
				<a href="#" class="icon-mail">Contact Us</a>
			</nav>
            <asp:LinkButton ID="cmdCompleteGameField" runat="server" onclick="cmdCompleteGameField_Click" Visible="true"></asp:LinkButton>
		</div>
		<script src="../js/classie.js"></script>
		<script src="../js/menu.js"></script>
    </form>
</body>
</html>
