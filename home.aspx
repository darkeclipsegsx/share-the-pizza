<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ShareThePizza.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link href="Styles/body.css" rel="stylesheet" />
	<link href="Styles/customMenu.css" rel="stylesheet" />
	<link href="Styles/home.css" rel="stylesheet" />
	<script src="JavaScript/jQuery/jquery-1.8.0.min.js"></script>
	<script src="JavaScript/jQuery/jquery-ui-1.8.23.custom.min.js"></script>
	<script src="JavaScript/jQuery/customMenu.js"></script>
	<script src="JavaScript/home/main.js"></script>
	<script src="JavaScript/across/main.js"></script>
	
</head>
<body>
	<form id="form1" runat="server">
		<div id="backgroundDiv" runat="server">
			<img class="splash" src="Styles/Images/pizzaBG.jpg" />
			
			<div id="topBar"><div id="logoArea"><span title="Share the Pizza!">Share the Pizza!</span></div>
			<div id="constantLinksArea"><ul><li><a href="#"><span>About</span></a></li><li><a href="#"><span>Contact</span></a></li></ul></div>
			</div>
			<div id="menu">
				<ul id="menuTopLevelMenu">
					<li id="mainLI"><a href="#"><span>Recipe of the Day</span></a></li>
					<li>
						<ul id="childrenMenuUL">
							<li class="childMenuItems"><a href="#"><span>Search</span></a></li>
							<li class="childMenuItems"><a href="#"><span>My Recipes</span></a></li>
							<li class="childMenuItems"><a href="#"><span>Favorites</span></a></li>
							<li class="childMenuItems"><a href="#"><span>Logout</span></a></li>
						</ul>
					</li>
				</ul>
			</div>
			<div id="horizontalScrollerDiv">
				<div id="recipeNameSection">
				<div id="recipeNameDiv">Vegtable Pizza</div>
				<div id="recipeSubmittedByDiv">By: <a href="#">Nirav Patel</a></div>
				<div id="recipeRatingsDiv">5 Stars - actual starts should appear here</div>
				</div>
				<div id="ingredientsDiv"><h1>Ingredients</h1></div>
			</div>
		</div>
	</form>
</body>
</html>
