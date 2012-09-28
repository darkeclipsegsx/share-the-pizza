$(document).ready(function () {
	$('#logoArea span').click(function () { //Logo click
		window.location.href = "home.aspx";
	});

	var fontColorToSet = $("#mainLI").css("color");
	var backgroundColorToSet = $("#mainLI").css("background-color");
	var windowHeight = $(window).height();
	var windowWidth = $(window).width();

	$('#logoArea span').css("color", fontColorToSet);
	$('#logoArea span').css("background", backgroundColorToSet);
	$('#constantLinksArea ul').css("background", backgroundColorToSet);
	$('#constantLinksArea ul li a').css("color", fontColorToSet);
	$('#horizontalScrollerDiv').css("width", windowWidth);
	$('#horizontalScrollerDiv').css("height", windowHeight);
	$('#recipeNameSection').css("background", backgroundColorToSet);
	$('#recipeNameSection').css("color", fontColorToSet);

	$('#ingredientsDiv').css("height", (($('#recipeNameSection').position().top - $('#menu').position().top) - 10));
	$('#ingredientsDiv').css("top", $('#menu').position().top);
	$('#ingredientsDiv').css("width", windowWidth*.2);
	$('#ingredientsDiv').css("background", backgroundColorToSet);
});