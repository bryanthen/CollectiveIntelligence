<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrimeSolvedStatistics.aspx.cs" Inherits="CI_Gwap.ResolvePages.CrimeSolvedStatistics" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
	<script>
	    $(function () {
	        $(".meter > span").each(function () {
	            $(this)
					.data("origWidth", $(this).width())
					.width(0)
					.animate({
					    width: $(this).data("origWidth")
					}, 1200);
	        });
	    });
	</script>

	<style>
	    @import url(http://fonts.googleapis.com/css?family=Lato:300,400,700);
        @font-face {
	        font-weight: normal;
	        font-style: normal;
	        font-family: 'codropsicons';
	        src:url('../fonts/codropsicons/codropsicons.eot');
	        src:url('../fonts/codropsicons/codropsicons.eot?#iefix') format('embedded-opentype'),
		        url('../fonts/codropsicons/codropsicons.woff') format('woff'),
		        url('../fonts/codropsicons/codropsicons.ttf') format('truetype'),
		        url('../fonts/codropsicons/codropsicons.svg#codropsicons') format('svg');
        }
        
        body {
	        color: #5a5350;
	        font-weight: 300;
	        font-family: 'Lato', Calibri, Arial, sans-serif;
	        overflow-y: scroll;
	        overflow-x: hidden;
	        text-align:center;
        }
        
        .codrops-header {
	        margin: 0 auto;
	        padding: 3em;
	        text-align: center;
        }

        .codrops-header h1 {
	        margin: 0;
	        font-weight: 300;
	        font-size: 2.625em;
	        line-height: 1.3;
        }

        .codrops-header span {
	        display: block;
	        padding: 0 0 0.6em 0.1em;
	        font-size: 60%;
	        color: #aca89a;
        }
        
        .container {
	        font-weight: 300;
	        font-size: 2em;
	        padding: 0 0 0.5em;
	        margin: 0;
	        height:100%;
        }
        
        .accordionCss
        {
	        font-size: 0.8em;
	        width:70%;
        }
        
        /* Demo Buttons Style */
        .codrops-demos {
	        padding-top: 1em;
	        font-size: 0.8em;
        }

        .codrops-demos a 
        {
            color:Black;
	        display: inline-block;
	        margin: 0.35em 0.1em;
	        padding: 0.5em 1.2em;
	        outline: none;
	        text-decoration: none;
	        text-transform: uppercase;
	        letter-spacing: 1px;
	        font-weight: 700;
	        border-radius: 2px;
	        font-size: 110%;
	        border: 2px solid transparent;
        }

        .codrops-demos a:hover,
        .codrops-demos a.current-demo {
	        border-color: #383a3c;
        }

        .codrops-demos h3 {
	        margin: 0;
	        padding: 1em 0 0.5em 0;
	        font-size: 0.9em;
	        float: left;
	        min-width: 90px;
	        clear: left;
        }

        .codrops-demos div:not(:first-child) h3 {
	        padding-top: 2em;
        }

        .codrops-demos a:hover,
        .codrops-demos a.current-demo {
	        color: inherit;
	        border-color: initial;
        }
        
		.meter {
			height: 20px;  /* Can be anything */
			position: relative;
			background: #555;
			-moz-border-radius: 25px;
			-webkit-border-radius: 25px;
			border-radius: 25px;
			padding: 10px;
			-webkit-box-shadow: inset 0 -1px 1px rgba(255,255,255,0.3);
			-moz-box-shadow   : inset 0 -1px 1px rgba(255,255,255,0.3);
			box-shadow        : inset 0 -1px 1px rgba(255,255,255,0.3);
		}
		.meter > span {
			display: block;
			height: 100%;
			   -webkit-border-top-right-radius: 8px;
			-webkit-border-bottom-right-radius: 8px;
			       -moz-border-radius-topright: 8px;
			    -moz-border-radius-bottomright: 8px;
			           border-top-right-radius: 8px;
			        border-bottom-right-radius: 8px;
			    -webkit-border-top-left-radius: 20px;
			 -webkit-border-bottom-left-radius: 20px;
			        -moz-border-radius-topleft: 20px;
			     -moz-border-radius-bottomleft: 20px;
			            border-top-left-radius: 20px;
			         border-bottom-left-radius: 20px;
			background-color: rgb(43,194,83);
			background-image: -webkit-gradient(
			  linear,
			  left bottom,
			  left top,
			  color-stop(0, rgb(43,194,83)),
			  color-stop(1, rgb(84,240,84))
			 );
			background-image: -moz-linear-gradient(
			  center bottom,
			  rgb(43,194,83) 37%,
			  rgb(84,240,84) 69%
			 );
			-webkit-box-shadow:
			  inset 0 2px 9px  rgba(255,255,255,0.3),
			  inset 0 -2px 6px rgba(0,0,0,0.4);
			-moz-box-shadow:
			  inset 0 2px 9px  rgba(255,255,255,0.3),
			  inset 0 -2px 6px rgba(0,0,0,0.4);
			box-shadow:
			  inset 0 2px 9px  rgba(255,255,255,0.3),
			  inset 0 -2px 6px rgba(0,0,0,0.4);
			position: relative;
			overflow: hidden;
		}
		.meter > span:after, .animate > span > span {
			content: "";
			position: absolute;
			top: 0; left: 0; bottom: 0; right: 0;
			background-image:
			   -webkit-gradient(linear, 0 0, 100% 100%,
			      color-stop(.25, rgba(255, 255, 255, .2)),
			      color-stop(.25, transparent), color-stop(.5, transparent),
			      color-stop(.5, rgba(255, 255, 255, .2)),
			      color-stop(.75, rgba(255, 255, 255, .2)),
			      color-stop(.75, transparent), to(transparent)
			   );
			background-image:
				-moz-linear-gradient(
				  -45deg,
			      rgba(255, 255, 255, .2) 25%,
			      transparent 25%,
			      transparent 50%,
			      rgba(255, 255, 255, .2) 50%,
			      rgba(255, 255, 255, .2) 75%,
			      transparent 75%,
			      transparent
			   );
			z-index: 1;
			-webkit-background-size: 50px 50px;
			-moz-background-size: 50px 50px;
			background-size: 50px 50px;
			-webkit-animation: move 2s linear infinite;
			-moz-animation: move 2s linear infinite;
			   -webkit-border-top-right-radius: 8px;
			-webkit-border-bottom-right-radius: 8px;
			       -moz-border-radius-topright: 8px;
			    -moz-border-radius-bottomright: 8px;
			           border-top-right-radius: 8px;
			        border-bottom-right-radius: 8px;
			    -webkit-border-top-left-radius: 20px;
			 -webkit-border-bottom-left-radius: 20px;
			        -moz-border-radius-topleft: 20px;
			     -moz-border-radius-bottomleft: 20px;
			            border-top-left-radius: 20px;
			         border-bottom-left-radius: 20px;
			overflow: hidden;
		}

		.animate > span:after {
			display: none;
		}

		@-webkit-keyframes move {
		    0% {
		       background-position: 0 0;
		    }
		    100% {
		       background-position: 50px 50px;
		    }
		}

		@-moz-keyframes move {
		    0% {
		       background-position: 0 0;
		    }
		    100% {
		       background-position: 50px 50px;
		    }
		}

		.orange > span {
			background-color: #f1a165;
			background-image: -moz-linear-gradient(top, #f1a165, #f36d0a);
			background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #f1a165),color-stop(1, #f36d0a));
			background-image: -webkit-linear-gradient(#f1a165, #f36d0a);
		}

		.red > span {
			background-color: #f0a3a3;
			background-image: -moz-linear-gradient(top, #f0a3a3, #f42323);
			background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #f0a3a3),color-stop(1, #f42323));
			background-image: -webkit-linear-gradient(#f0a3a3, #f42323);
		}

		.nostripes > span > span, .nostripes > span:after {
			-webkit-animation: none;
			-moz-animation: none;
			background-image: none;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
        <div>
            <header class="codrops-header">
		        <h1>Crime Scene Investigation, The game <span>Collective Intelligence Project- Game With A Purpose (GWAP)</span></h1>	
                <nav class="codrops-demos">
					<a class="current-demo" href="#">Game Play Statistics</a>
					<a href="../MainPage.aspx">Back To Main Page</a>
				</nav>
            </header>
        </div>
        <div class="container">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:Accordion ID="Accordion1" runat="server">
                <Panes>
                    <cc1:AccordionPane ID="AccordionPane1" runat="server" CssClass="accordionCss">
                        <Header>Questions' Database</Header>
                        <Content>
                            <div id="questionDiv" style="float:none; padding-left:50px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" AllowPaging="true"
                                        CellPadding="4" ForeColor="#333333" GridLines="None"
                                        OnSelectedIndexChanged="YourGridView_SelectedIndexChanged" Font-Size="Large">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                        </Content>
                    </cc1:AccordionPane>
                </Panes>
                <Panes>
                    <cc1:AccordionPane ID="AccordionPane2" runat="server" CssClass="accordionCss" Visible="false">
                        <Header>Question's Image</Header>
                        <Content>
                            <asp:Image ID="questionImage" runat="server" Width="60%"/>
                        </Content>
                    </cc1:AccordionPane>
                </Panes>
            </cc1:Accordion>
            
            <div id="statisticDiv">
                <p>Answers' Statistics</p>
                <asp:Label ID="notificationlbl" runat="server"></asp:Label>
                <div id="imagestatDiv" runat="server" visible="false">
                    <p><asp:Image ID="Image1" runat="server" Width="25%"/>Number of Person Selected: <asp:Label ID="image1lbl" runat="server"></asp:Label></p>
                    <p></p>
                    <div class="meter">
                        <span id="image1span" runat="server" style="width: 0%"></span>
                    </div>

                    <p><asp:Image ID="Image2" runat="server" Width="25%"/>Number of Person Selected: <asp:Label ID="image2lbl" runat="server"></asp:Label></p>
                    <p></p>
                    <div class="meter">
                        <span id="image2span" runat="server" style="width: 0%"></span>
                    </div>

                    <p><asp:Image ID="Image3" runat="server" Width="25%"/>Number of Person Selected: <asp:Label ID="image3lbl" runat="server"></asp:Label></p>
                    <p></p>
                    <div class="meter">
                        <span id="image3span" runat="server" style="width: 0%"></span>
                    </div>

                    <p><asp:Image ID="Image4" runat="server" Width="25%"/>Number of Person Selected: <asp:Label ID="image4lbl" runat="server"></asp:Label></p>
                    <p></p>
                    <div class="meter">
                        <span id="image4span" runat="server" style="width: 0%"></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
