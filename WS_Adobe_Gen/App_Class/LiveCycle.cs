using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Adobe_Gen.App_Class
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.apache.org/xml-soap")]
    public partial class mapItem
    {

        private object keyField;

        private object valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/servicesX")]
    public partial class AssemblerResult
    {

        private mapItem[] documentsField;

        private object[] failedBlockNamesField;

        private BLOB jobLogField;

        private mapItem[] multipleResultsBlocksField;

        private int numRequestedBlocksField;

        private object[] successfulBlockNamesField;

        private object[] successfulDocumentNamesField;

        private mapItem[] throwablesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "http://xml.apache.org/xml-soap", IsNullable = false)]
        public mapItem[] documents
        {
            get
            {
                return this.documentsField;
            }
            set
            {
                this.documentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public object[] failedBlockNames
        {
            get
            {
                return this.failedBlockNamesField;
            }
            set
            {
                this.failedBlockNamesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public BLOB jobLog
        {
            get
            {
                return this.jobLogField;
            }
            set
            {
                this.jobLogField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "http://xml.apache.org/xml-soap", IsNullable = false)]
        public mapItem[] multipleResultsBlocks
        {
            get
            {
                return this.multipleResultsBlocksField;
            }
            set
            {
                this.multipleResultsBlocksField = value;
            }
        }

        /// <remarks/>
        public int numRequestedBlocks
        {
            get
            {
                return this.numRequestedBlocksField;
            }
            set
            {
                this.numRequestedBlocksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public object[] successfulBlockNames
        {
            get
            {
                return this.successfulBlockNamesField;
            }
            set
            {
                this.successfulBlockNamesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public object[] successfulDocumentNames
        {
            get
            {
                return this.successfulDocumentNamesField;
            }
            set
            {
                this.successfulDocumentNamesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "http://xml.apache.org/xml-soap", IsNullable = false)]
        public mapItem[] throwables
        {
            get
            {
                return this.throwablesField;
            }
            set
            {
                this.throwablesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/services")]
    public partial class BLOB
    {

        private string contentTypeField;

        private byte[] binaryDataField;

        private string attachmentIDField;

        private string remoteURLField;

        private mapItem[] atributesField;

        /// <remarks/>
        public string contentType
        {
            get
            {
                return this.contentTypeField;
            }
            set
            {
                this.contentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] binaryData
        {
            get
            {
                return this.binaryDataField;
            }
            set
            {
                this.binaryDataField = value;
            }
        }

        /// <remarks/>
        public string attachmentID
        {
            get
            {
                return this.attachmentIDField;
            }
            set
            {
                this.attachmentIDField = value;
            }
        }

        /// <remarks/>
        public string remoteURL
        {
            get
            {
                return this.remoteURLField;
            }
            set
            {
                this.remoteURLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "http://xml.apache.org/xml-soap", IsNullable = false)]
        public mapItem[] attributes
        {
            get
            {
                return this.atributesField;
            }
            set
            {
                this.atributesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/services")]
    public partial class TSPOptionSpec
    {

        private System.Nullable<HashAlgorithm> tspHashAlgorithmField;

        private System.Nullable<RevocationCheckStyle> tspRevocationCheckStyleField;

        private bool tspSendNonceField;

        private string tspServerPasswordField;

        private string tspServerURLField;

        private string tspServerUsernameField;

        private System.Nullable<int> tspSizeField;

        private bool useExpiredTimestampsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<HashAlgorithm> tspHashAlgorithm
        {
            get
            {
                return this.tspHashAlgorithmField;
            }
            set
            {
                this.tspHashAlgorithmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<RevocationCheckStyle> tspRevocationCheckStyle
        {
            get
            {
                return this.tspRevocationCheckStyleField;
            }
            set
            {
                this.tspRevocationCheckStyleField = value;
            }
        }

        /// <remarks/>
        public bool tspSendNonce
        {
            get
            {
                return this.tspSendNonceField;
            }
            set
            {
                this.tspSendNonceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tspServerPassword
        {
            get
            {
                return this.tspServerPasswordField;
            }
            set
            {
                this.tspServerPasswordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tspServerURL
        {
            get
            {
                return this.tspServerURLField;
            }
            set
            {
                this.tspServerURLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tspServerUsername
        {
            get
            {
                return this.tspServerUsernameField;
            }
            set
            {
                this.tspServerUsernameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> tspSize
        {
            get
            {
                return this.tspSizeField;
            }
            set
            {
                this.tspSizeField = value;
            }
        }

        /// <remarks/>
        public bool useExpiredTimestamps
        {
            get
            {
                return this.useExpiredTimestampsField;
            }
            set
            {
                this.useExpiredTimestampsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/services")]
    public enum RevocationCheckStyle
    {

        /// <remarks/>
        NoCheck,

        /// <remarks/>
        BestEffort,

        /// <remarks/>
        CheckIfAvailable,

        /// <remarks/>
        AlwaysCheck,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/services")]
    public enum HashAlgorithm
    {

        /// <remarks/>
        MD5,

        /// <remarks/>
        SHA1,

        /// <remarks/>
        SHA256,

        /// <remarks/>
        SHA384,

        /// <remarks/>
        SHA512,

        /// <remarks/>
        RIPEMD160,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1085.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adobe.com/idp/services")]
    public partial class Credential
    {

        private string aliasField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string alias
        {
            get
            {
                return this.aliasField;
            }
            set
            {
                this.aliasField = value;
            }
        }
    }

}