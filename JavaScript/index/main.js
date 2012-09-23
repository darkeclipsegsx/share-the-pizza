var isLoginPopUpVisible = false; //Is the login form visible
var isSignUpPopUpVisible = false; //Is the sign up form visible

$(function () { //Make the pretty!
	$("#slides").slides({
		preload: true,
		preloadImage: 'Styles/Images/loading.gif',
		play: 5000,
		pause: 3000,
		hoverPause: true,
		pagination: true
	});
});

$(document).ready(function () {
	centerPopUp(); //Center all popups to the middle of the window
	setDefaultTextForInputs(); //Sets all the default text values in text inputs to be their title attr value
	rotateImagesAndInfo();

	$("#popUpBackGround").click(function () { //Clicking on the background pop up
		$('#popUpBackGround').fadeOut("slow"); //Fade out the background
		if (isLoginPopUpVisible) { //If login div is visible
			$('#logInDiv').fadeOut("slow");
			$('#logInCloseButton').fadeOut("slow");
		}
		if (isSignUpPopUpVisible) { //If signup div is visible
			$('#signUpDiv').fadeOut("slow");
			$('#signUpCloseButton').fadeOut("slow");
		}
	});

	$('#logInCloseButton').click(function () { //If the close button for the login div is clicked
		$('#popUpBackGround').fadeOut("slow");
		$('#logInDiv').fadeOut("slow");
		$('#logInCloseButton').fadeOut("slow");		
	});

	$('#loginLink').click(function () { //If the login link is clicked
		$('#popUpBackGround').fadeIn("slow");
		$('#logInCloseButton').fadeIn("slow");
		$('#logInDiv').fadeIn("slow");
		isLoginPopUpVisible = true;
	});

	$('#signUpLink').click(function () { //If the sign up link is clicked
		$('#popUpBackGround').fadeIn("slow");
		$('#signUpCloseButton').fadeIn("slow");
		$('#signUpDiv').fadeIn("slow");
		isSignUpPopUpVisible = true;
	});

	$('#signUpCloseButton').click(function () { //If the sign up close button is pressed
		$('#popUpBackGround').fadeOut("slow");
		$('#signUpDiv').fadeOut("slow");
		$('#signUpCloseButton').fadeOut("slow");		
	});

	$('#userNameTextInput, #passwordTextInput').keyup(function (event) {
		if (event.keyCode == 13) {
			$('#loginButton').click();
		}
	});	
});

$(document).keyup(function (event) {
	if ((event.keyCode == 27 && isLoginPopUpVisible) || (event.keyCode == 27 && isSignUpPopUpVisible)) {
		$('#popUpBackGround').fadeOut("slow");
		if (isLoginPopUpVisible) {
			$('#logInDiv').fadeOut("slow");
			$('#logInCloseButton').fadeOut("slow");
		}
		if (isSignUpPopUpVisible) {
			$('#signUpDiv').fadeOut("slow");
			$('#signUpCloseButton').fadeOut("slow");
		}
	}
});

function centerPopUp() {
	var windowWidth = document.documentElement.clientWidth;
	var windowHeight = document.documentElement.clientHeight;
	var loginPopupHeight = $("#logInDiv").height();
	var loginPopupWidth = $("#logInDiv").width();

	var signUpPopupHeight = $("#signUpDiv").height();
	var signUpPopupWidth = $("#signUpDiv").width();

	//centering  
	$("#logInDiv").css({
		"position": "absolute",
		"top": windowHeight / 2 - loginPopupHeight / 2,
		"left": windowWidth / 2 - loginPopupWidth / 2
	});

	$("#signUpDiv").css({
		"position": "absolute",
		"top": windowHeight / 2 - signUpPopupHeight / 2,
		"left": windowWidth / 2 - signUpPopupWidth / 2
	});
}

function setDefaultTextForInputs() {
	$('input[type="text"], input[type="password"]').each(function () {
		this.value = $(this).attr('title');
		$(this).addClass('text-label');

		$(this).focus(function () {
			if (this.value == $(this).attr('title')) {
				this.value = '';
				$(this).removeClass('text-label');
			}
		});

		$(this).blur(function () {
			if (this.value == '') {
				this.value = $(this).attr('title');
				$(this).addClass('text-label');
			}
		});
	});
}

function rotateImagesAndInfo() {
	
}