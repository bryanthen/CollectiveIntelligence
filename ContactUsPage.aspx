<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUsPage.aspx.cs" Inherits="CI_Gwap.ContactUsPage" %>

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
                    
                    <p>Please feel free to email to us</p>
                    <p>Email Address: bryanthen92@gmail.com</p>
                    <p></p>

                    <p>I would Love to hear feedbacks from you!</p>
                    <asp:TextBox ID="TextBox1" runat="server" Width="75%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        <nav class="codrops-demos">
                            <a class="current-demo" href="#">Send Feedback</a>
                        </nav>

                    <nav class="codrops-demos">
						<a class="current-demo" href="#">Contact Us</a>
                        <a href="MainPage.aspx">Home Page</a>
						<a href="HomePage.aspx">User Login</a>
						<a href="RegistrationPage.aspx">User Registration</a>
                        <a href="../ResolvePages/CrimeSolvedStatistics.aspx">Game Play Statistics</a>
					</nav>

                    </div>
				</div>
			</div>
			<!-- Related demos -->
			<section class="related">
			</section>

		</div><!-- /container -->
		<script src="js/mainPage/TweenLite.min.js"></script>
		<script src="js/mainPage/EasePack.min.js"></script>
		<script src="js/mainPage/rAF.js"></script>
		<script src="js/mainPage/demo-1.js"></script>
    </form>
</body>
</html>
