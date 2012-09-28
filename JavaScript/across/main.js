$(document).ready(function () {
	$('#logoArea span').click(function () { //Logo click
		window.location.href = "home.aspx";
	});

	var fontColorToSet = $("#mainLI").css("color");
	var backgroundColorToSet = $("#mainLI").css("background-color");

	$('#logoArea span').css("color", fontColorToSet);
	$('#logoArea span').css("background", backgroundColorToSet);
	$('#constantLinksArea ul').css("background", backgroundColorToSet);
	$('#constantLinksArea ul li a').css("color", fontColorToSet);
});