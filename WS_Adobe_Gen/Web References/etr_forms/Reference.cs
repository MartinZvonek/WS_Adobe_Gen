﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WS_Adobe_Gen.etr_forms {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1085.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="etr_formsSoapBinding", Namespace="http://adobe.com/idp/services")]
    public partial class ETR_etr_formsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback invokeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ETR_etr_formsService() {
            this.Url = global::WS_Adobe_Gen.Properties.Settings.Default.WS_Adobe_Gen_etr_forms_ETR_etr_formsService;
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
        public event invokeCompletedEventHandler invokeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("invoke", RequestNamespace="http://adobe.com/idp/services", ResponseNamespace="http://adobe.com/idp/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("docOUT")]
        public BLOB invoke(bool Archive, string Author, string Creator, bool Nahled, string Producer, string Subject, string Title, string Type, BLOB docIN, out string error, out string stavOUT) {
            object[] results = this.Invoke("invoke", new object[] {
                        Archive,
                        Author,
                        Creator,
                        Nahled,
                        Producer,
                        Subject,
                        Title,
                        Type,
                        docIN});
            error = ((string)(results[1]));
            stavOUT = ((string)(results[2]));
            return ((BLOB)(results[0]));
        }
        
        /// <remarks/>
        public void invokeAsync(bool Archive, string Author, string Creator, bool Nahled, string Producer, string Subject, string Title, string Type, BLOB docIN) {
            this.invokeAsync(Archive, Author, Creator, Nahled, Producer, Subject, Title, Type, docIN, null);
        }
        
        /// <remarks/>
        public void invokeAsync(bool Archive, string Author, string Creator, bool Nahled, string Producer, string Subject, string Title, string Type, BLOB docIN, object userState) {
            if ((this.invokeOperationCompleted == null)) {
                this.invokeOperationCompleted = new System.Threading.SendOrPostCallback(this.OninvokeOperationCompleted);
            }
            this.InvokeAsync("invoke", new object[] {
                        Archive,
                        Author,
                        Creator,
                        Nahled,
                        Producer,
                        Subject,
                        Title,
                        Type,
                        docIN}, this.invokeOperationCompleted, userState);
        }
        
        private void OninvokeOperationCompleted(object arg) {
            if ((this.invokeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.invokeCompleted(this, new invokeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adobe.com/idp/services")]
    public partial class BLOB {
        
        private string contentTypeField;
        
        private byte[] binaryDataField;
        
        private string attachmentIDField;
        
        private string remoteURLField;
        
        /// <remarks/>
        public string contentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] binaryData {
            get {
                return this.binaryDataField;
            }
            set {
                this.binaryDataField = value;
            }
        }
        
        /// <remarks/>
        public string attachmentID {
            get {
                return this.attachmentIDField;
            }
            set {
                this.attachmentIDField = value;
            }
        }
        
        /// <remarks/>
        public string remoteURL {
            get {
                return this.remoteURLField;
            }
            set {
                this.remoteURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1085.0")]
    public delegate void invokeCompletedEventHandler(object sender, invokeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1085.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class invokeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal invokeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public BLOB Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((BLOB)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string stavOUT {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
}

#pragma warning restore 1591