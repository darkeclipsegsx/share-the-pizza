using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShareThePizza
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{		
			if(IsPostBack) {
				string objectCausingPostBack = Request.Form["__EVENTTARGET"];
				if(objectCausingPostBack == "loginButton") {
					ClientScript.RegisterStartupScript(this.GetType(), "signUpErrorClick", "$('#popUpBackGround').fadeIn('slow'); $('#logInCloseButton').fadeIn('slow'); $('#logInDiv').fadeIn('slow'); isLoginPopUpVisible = true;", true);
				}
			} else {
				failedLoginLabel.InnerText = "";				
			}
		}

		protected void loginButton_Click(object sender, EventArgs e)
		{
			string userName = userNameTextInput.Value;
			string password = passwordTextInput.Value;
			LoginService.LoginService lis = new LoginService.LoginService();
			bool loggedInSucc = lis.LoginUser(userName, password);
			if(loggedInSucc) {
				ClientScript.RegisterStartupScript(this.GetType(), "alertLoggedInSucc", "alert('Logged in!');", true);				
			} else {
				failedLoginLabel.InnerText = "The User name or password inputted was incorrect.";
			}
		}
	}
}