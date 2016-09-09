<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PresentationPage.aspx.cs" Inherits="CI_Gwap.PresentationPage" %>

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
				<div class="codrops-header">
                    <h1>Crime Scene Investigation, The game <span>Collective Intelligence Project- Game With A Purpose (GWAP)</span></h1>	
                    
                    <nav class="codrops-demos">
						<a class="current-demo" href="#">Presentation Page</a>
                        <a href="MainPage.aspx">Back to Main Page</a>
						<a href="HomePage.aspx">User Login</a>
						<a href="RegistrationPage.aspx">User Registration</a>
                        <a href="../ResolvePages/CrimeSolvedStatistics.aspx">Game Play Statistics</a>
                        <a href="ContactUsPage.aspx">Contact Us</a>
					</nav>
                </div>
			</div>
			<!-- Related demos -->
			<section class="related" style="padding-top:0px; margin-top:0px">
                <h1>Motivation</h1>
                <p style="width:80%; margin-left:auto; margin-right:auto">From the research of several countries including United State, Ireland and Malaysia based on criminal report, 
                    all countries are having the common statistical readings which are rapidly increases from year to year. With proper filed report, those reading are released to the public through media</p>
			    <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="10px"></asp:Image>

                <p>From Facebook Upload Videos, Caught On Camera Videos</p>
                <a href="https://www.facebook.com/252832871420923/videos/vb.252832871420923/817959628241575/?type=3&theater">Facebook Videos</a>
                <a href="http://edition.cnn.com/2015/04/13/us/airport-luggage-theft/index.html?sr=fb041415airportworkers2aVODtopLink">CNN Luggage Thief</a>
            
                <h1>Gwap Technical Description</h1>
                <p>1. ASP.NET, the library used for making website</p>
                <p>2. C# language, the programming language runs in backend</p>
                <p>3. SQL Database, retrieving and storing of records</p>
                <p>4. Answering Option Image Database, database on facial features</p>
                <asp:Image ID="Image2" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="10px"></asp:Image>
                <p></p>

                <h1>Challenges</h1>
                <p>1. The interactions between two users</p>
                <p>2. The selections of answering options</p>
                <asp:Image ID="Image3" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="10px"></asp:Image>
                <p></p>
                <asp:Image ID="Image4" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="10px"></asp:Image>

                <h1>Game Description</h1>
                <p>No of players: 2</p>
                <p>Symmetric vs Asymmetric: Symmetric</p>
                <p>Synchronous vs Asynchronous: Synchronous</p>
                <p>Competitive vs Collaborative: Collaborative</p>
                <p> </p>
                <p> </p>
                <p> </p>
                <p> </p>
            </section>

		</div><!-- /container -->
		<script src="js/mainPage/TweenLite.min.js"></script>
		<script src="js/mainPage/EasePack.min.js"></script>
		<script src="js/mainPage/rAF.js"></script>
		<script src="js/mainPage/demo-1.js"></script>
    </form>
</body>
</html>
