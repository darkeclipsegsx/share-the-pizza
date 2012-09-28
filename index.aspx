<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShareThePizza.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Oo that looks good, share the pizza man!</title>
	<link href="Styles/index.css" rel="stylesheet" />
	<link href="Styles/carousel.css" rel="stylesheet" />
	<script src="JavaScript/jQuery/jquery-1.8.0.min.js"></script>
	<script src="JavaScript/jQuery/jquery-ui-1.8.23.custom.min.js"></script>
	<script src="JavaScript/across/main.js"></script>
	<script src="JavaScript/index/main.js"></script>
</head>
<body>
	<form id="form1" runat="server">
		<div id="main">
			<div id="topBar">
				<div id="title"><span id="innerTitle">Share the Pizza!</span></div>
				<div id="links">
					<ul id="topBarLinks">
						<li><span id="loginLink">Log in</span></li>
						<li><span id="signUpLink">Sign Up</span></li>
					</ul>
				</div>
			</div>
			<div id="bodyDiv">
			<div id="siteShortInfo"><div id="infoInnerText1">Keep the secrets to your favorite recipes in the family.</div></div>
				<div id="imageScroller">
				<div id="slides">
            <div class="slides_container">
                <div>
                    <img src="Styles/Images/veggiepizza.jpg" />
                </div>
                <div>
									<img src="Styles/Images/chanamasala.jpg" />                    
                </div>
                <div>
									<img src="Styles/Images/mexicannachos.jpg" />
                </div>                
            </div>						
        </div>
					
				</div>				
			</div>
			<div id="footer">
				<ul id="footerLinks">
					<li><span>About</span></li>
					<li><span>Conact Us</span></li>
				</ul>
			</div>
		</div>
		<div id="popUpBackGround"></div>
		<div id="logInDiv">
			<div id="logInCloseButton">
				<p id="logInCloseButtonText">X</p>
			</div>
			<div id="logInContents">
				<h1>Log in to Share the Pizza</h1>
				<span>
					<input type="text" id="userNameTextInput" title="Enter Username" runat="server" /></span>
				<span>
					<input id="passwordTextInput" type="password" title="Enter Password" runat="server"/></span>
					<span>
					<label id="failedLoginLabel" runat="server"></label>
					</span>
				<div id="loginLinks">
					<a href="#" id="forgotPasswordLink">Forgot your password?</a>
					<asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="loginButton_Click" UseSubmitBehavior="false" />
				</div>
			</div>
		</div>
		<div id="signUpDiv">
			<div id="signUpCloseButton">
				<p id="signUpCloseButtonText">X</p>
			</div>
			<div id="signUpContents">
				<h1>Sorry! Share the Pizza is an invite only site, please contact us to request access</h1>
			</div>
		</div>
	</form>
</body>
</html>
