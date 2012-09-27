<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ShareThePizza.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link href="Styles/body.css" rel="stylesheet" />
	<link href="Styles/customMenu.css" rel="stylesheet" />
	<script src="JavaScript/jQuery/jquery-1.8.0.min.js"></script>
	<script src="JavaScript/jQuery/jquery-ui-1.8.23.custom.min.js"></script>
	<script src="JavaScript/jQuery/customMenu.js"></script>
	<script>
		$(function () {
			var arrowBorders = new Object();
			var childItemsBorder = '1px solid white';
			arrowBorders.borderTop = '5px solid white';
			arrowBorders.borderLeft = '5px solid transparent';
			arrowBorders.borderRight = '5px solid transparent';

			setUpMenu("#CAA149", 'white', childItemsBorder, arrowBorders);
		});
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
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
		</div>
	</form>
</body>
</html>
