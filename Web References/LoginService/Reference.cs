﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace ShareThePizza.LoginService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="LoginServiceSoap", Namespace="http://tempuri.org/")]
    public partial class LoginService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LoginUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddNewUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsLoggedInOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangeEmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogoutOperationCompleted;
        
        private System.Threading.SendOrPostCallback RemoveUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback ForgotPasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback UsernameAvailableOperationCompleted;
        
        private System.Threading.SendOrPostCallback superSecretSurpriseOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LoginService() {
            this.Url = global::ShareThePizza.Properties.Settings.Default.ShareThePizza_LoginService_LoginService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event LoginUserCompletedEventHandler LoginUserCompleted;
        
        /// <remarks/>
        public event AddNewUserCompletedEventHandler AddNewUserCompleted;
        
        /// <remarks/>
        public event IsLoggedInCompletedEventHandler IsLoggedInCompleted;
        
        /// <remarks/>
        public event ChangeEmailCompletedEventHandler ChangeEmailCompleted;
        
        /// <remarks/>
        public event ChangePasswordCompletedEventHandler ChangePasswordCompleted;
        
        /// <remarks/>
        public event LogoutCompletedEventHandler LogoutCompleted;
        
        /// <remarks/>
        public event RemoveUserCompletedEventHandler RemoveUserCompleted;
        
        /// <remarks/>
        public event ForgotPasswordCompletedEventHandler ForgotPasswordCompleted;
        
        /// <remarks/>
        public event UsernameAvailableCompletedEventHandler UsernameAvailableCompleted;
        
        /// <remarks/>
        public event superSecretSurpriseCompletedEventHandler superSecretSurpriseCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LoginUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LoginUser(string username, string password) {
            object[] results = this.Invoke("LoginUser", new object[] {
                        username,
                        password});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void LoginUserAsync(string username, string password) {
            this.LoginUserAsync(username, password, null);
        }
        
        /// <remarks/>
        public void LoginUserAsync(string username, string password, object userState) {
            if ((this.LoginUserOperationCompleted == null)) {
                this.LoginUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginUserOperationCompleted);
            }
            this.InvokeAsync("LoginUser", new object[] {
                        username,
                        password}, this.LoginUserOperationCompleted, userState);
        }
        
        private void OnLoginUserOperationCompleted(object arg) {
            if ((this.LoginUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginUserCompleted(this, new LoginUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddNewUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddNewUser(string username, string password, string email) {
            object[] results = this.Invoke("AddNewUser", new object[] {
                        username,
                        password,
                        email});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddNewUserAsync(string username, string password, string email) {
            this.AddNewUserAsync(username, password, email, null);
        }
        
        /// <remarks/>
        public void AddNewUserAsync(string username, string password, string email, object userState) {
            if ((this.AddNewUserOperationCompleted == null)) {
                this.AddNewUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddNewUserOperationCompleted);
            }
            this.InvokeAsync("AddNewUser", new object[] {
                        username,
                        password,
                        email}, this.AddNewUserOperationCompleted, userState);
        }
        
        private void OnAddNewUserOperationCompleted(object arg) {
            if ((this.AddNewUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddNewUserCompleted(this, new AddNewUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsLoggedIn", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsLoggedIn(string username) {
            object[] results = this.Invoke("IsLoggedIn", new object[] {
                        username});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsLoggedInAsync(string username) {
            this.IsLoggedInAsync(username, null);
        }
        
        /// <remarks/>
        public void IsLoggedInAsync(string username, object userState) {
            if ((this.IsLoggedInOperationCompleted == null)) {
                this.IsLoggedInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsLoggedInOperationCompleted);
            }
            this.InvokeAsync("IsLoggedIn", new object[] {
                        username}, this.IsLoggedInOperationCompleted, userState);
        }
        
        private void OnIsLoggedInOperationCompleted(object arg) {
            if ((this.IsLoggedInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsLoggedInCompleted(this, new IsLoggedInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ChangeEmail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ChangeEmail(string username, string newEmail) {
            object[] results = this.Invoke("ChangeEmail", new object[] {
                        username,
                        newEmail});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void ChangeEmailAsync(string username, string newEmail) {
            this.ChangeEmailAsync(username, newEmail, null);
        }
        
        /// <remarks/>
        public void ChangeEmailAsync(string username, string newEmail, object userState) {
            if ((this.ChangeEmailOperationCompleted == null)) {
                this.ChangeEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangeEmailOperationCompleted);
            }
            this.InvokeAsync("ChangeEmail", new object[] {
                        username,
                        newEmail}, this.ChangeEmailOperationCompleted, userState);
        }
        
        private void OnChangeEmailOperationCompleted(object arg) {
            if ((this.ChangeEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangeEmailCompleted(this, new ChangeEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ChangePassword", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ChangePassword(string username, string oldPassword, string newPassword) {
            object[] results = this.Invoke("ChangePassword", new object[] {
                        username,
                        oldPassword,
                        newPassword});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(string username, string oldPassword, string newPassword) {
            this.ChangePasswordAsync(username, oldPassword, newPassword, null);
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(string username, string oldPassword, string newPassword, object userState) {
            if ((this.ChangePasswordOperationCompleted == null)) {
                this.ChangePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangePasswordOperationCompleted);
            }
            this.InvokeAsync("ChangePassword", new object[] {
                        username,
                        oldPassword,
                        newPassword}, this.ChangePasswordOperationCompleted, userState);
        }
        
        private void OnChangePasswordOperationCompleted(object arg) {
            if ((this.ChangePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangePasswordCompleted(this, new ChangePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Logout", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Logout(string username) {
            this.Invoke("Logout", new object[] {
                        username});
        }
        
        /// <remarks/>
        public void LogoutAsync(string username) {
            this.LogoutAsync(username, null);
        }
        
        /// <remarks/>
        public void LogoutAsync(string username, object userState) {
            if ((this.LogoutOperationCompleted == null)) {
                this.LogoutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogoutOperationCompleted);
            }
            this.InvokeAsync("Logout", new object[] {
                        username}, this.LogoutOperationCompleted, userState);
        }
        
        private void OnLogoutOperationCompleted(object arg) {
            if ((this.LogoutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RemoveUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RemoveUser(string username) {
            object[] results = this.Invoke("RemoveUser", new object[] {
                        username});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RemoveUserAsync(string username) {
            this.RemoveUserAsync(username, null);
        }
        
        /// <remarks/>
        public void RemoveUserAsync(string username, object userState) {
            if ((this.RemoveUserOperationCompleted == null)) {
                this.RemoveUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemoveUserOperationCompleted);
            }
            this.InvokeAsync("RemoveUser", new object[] {
                        username}, this.RemoveUserOperationCompleted, userState);
        }
        
        private void OnRemoveUserOperationCompleted(object arg) {
            if ((this.RemoveUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemoveUserCompleted(this, new RemoveUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ForgotPassword", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ForgotPassword(string usernameOrEmail, out string email, out string outToken) {
            object[] results = this.Invoke("ForgotPassword", new object[] {
                        usernameOrEmail});
            email = ((string)(results[1]));
            outToken = ((string)(results[2]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ForgotPasswordAsync(string usernameOrEmail) {
            this.ForgotPasswordAsync(usernameOrEmail, null);
        }
        
        /// <remarks/>
        public void ForgotPasswordAsync(string usernameOrEmail, object userState) {
            if ((this.ForgotPasswordOperationCompleted == null)) {
                this.ForgotPasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnForgotPasswordOperationCompleted);
            }
            this.InvokeAsync("ForgotPassword", new object[] {
                        usernameOrEmail}, this.ForgotPasswordOperationCompleted, userState);
        }
        
        private void OnForgotPasswordOperationCompleted(object arg) {
            if ((this.ForgotPasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ForgotPasswordCompleted(this, new ForgotPasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UsernameAvailable", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UsernameAvailable(string username) {
            object[] results = this.Invoke("UsernameAvailable", new object[] {
                        username});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UsernameAvailableAsync(string username) {
            this.UsernameAvailableAsync(username, null);
        }
        
        /// <remarks/>
        public void UsernameAvailableAsync(string username, object userState) {
            if ((this.UsernameAvailableOperationCompleted == null)) {
                this.UsernameAvailableOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUsernameAvailableOperationCompleted);
            }
            this.InvokeAsync("UsernameAvailable", new object[] {
                        username}, this.UsernameAvailableOperationCompleted, userState);
        }
        
        private void OnUsernameAvailableOperationCompleted(object arg) {
            if ((this.UsernameAvailableCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UsernameAvailableCompleted(this, new UsernameAvailableCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/superSecretSurprise", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string superSecretSurprise(string input) {
            object[] results = this.Invoke("superSecretSurprise", new object[] {
                        input});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void superSecretSurpriseAsync(string input) {
            this.superSecretSurpriseAsync(input, null);
        }
        
        /// <remarks/>
        public void superSecretSurpriseAsync(string input, object userState) {
            if ((this.superSecretSurpriseOperationCompleted == null)) {
                this.superSecretSurpriseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsuperSecretSurpriseOperationCompleted);
            }
            this.InvokeAsync("superSecretSurprise", new object[] {
                        input}, this.superSecretSurpriseOperationCompleted, userState);
        }
        
        private void OnsuperSecretSurpriseOperationCompleted(object arg) {
            if ((this.superSecretSurpriseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.superSecretSurpriseCompleted(this, new superSecretSurpriseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void LoginUserCompletedEventHandler(object sender, LoginUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void AddNewUserCompletedEventHandler(object sender, AddNewUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddNewUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddNewUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void IsLoggedInCompletedEventHandler(object sender, IsLoggedInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsLoggedInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsLoggedInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ChangeEmailCompletedEventHandler(object sender, ChangeEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangeEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangeEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ChangePasswordCompletedEventHandler(object sender, ChangePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void LogoutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void RemoveUserCompletedEventHandler(object sender, RemoveUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RemoveUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RemoveUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ForgotPasswordCompletedEventHandler(object sender, ForgotPasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ForgotPasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ForgotPasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string outToken {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void UsernameAvailableCompletedEventHandler(object sender, UsernameAvailableCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UsernameAvailableCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UsernameAvailableCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void superSecretSurpriseCompletedEventHandler(object sender, superSecretSurpriseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class superSecretSurpriseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal superSecretSurpriseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591