//Add Arrow To mainLI, set Colors, child borderColors
function setUpMenu(menuBKColor, liFontColor, childItemsBorder, arrowProperties) {
	$("#mainLI").html($("#mainLI").html() + '<span class="arrowDown"></span>');

	$("#mainLI").css("background-color", menuBKColor);
	$("#mainLI").css("color", liFontColor);
	$(".childMenuItems").css("color", liFontColor);
	$(".childMenuItems").css("background-color", menuBKColor);
	$(".childMenuItems").css("border-top", childItemsBorder);	
	$(".arrowDown").css("border-top", arrowProperties.borderTop);
	$(".arrowDown").css("border-left", arrowProperties.borderLeft);
	$(".arrowDown").css("border-right", arrowProperties.borderRight);
	
	$("#mainLI").css("width", $("#mainLI").width());
	$(".childMenuItems").css("width", $("#mainLI").width());
	setArrowTop();
	addEventToMainMenuItem();
};

//Set the arrows top css value
function setArrowTop() {
	var mainLIHeight = $("#mainLI").innerHeight();
	$(".arrowDown").css("top", mainLIHeight / 2);
}

//Add event listeners to show and hide the menu children
function addEventToMainMenuItem() {
	$("#mainLI").mouseenter(function () {
		if ($('#childrenMenuUL').is(':hidden')) {
			$("#childrenMenuUL").show();
		}
	});

	$("#mainLI").mouseleave(function () {
		$("#childrenMenuUL").hide();
	});

	$("#childrenMenuUL").mouseenter(function () {
		$("#childrenMenuUL").show();
	});

	$("#childrenMenuUL").mouseleave(function () {
		$("#childrenMenuUL").hide();
	});
}