using Gedcomx.Model.Util;
using Gx.Types;
using Newtonsoft.Json;
// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Conclusion
{

    /// <remarks>
    ///  An identifier for a resource.
    /// </remarks>
    /// <summary>
    ///  An identifier for a resource.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://gedcomx.org/v1/", TypeName = "Identifier")]
    [JsonConverter(typeof(JsonIdentifiersConverter))]
    public sealed partial class Identifier
    {

        private string _type;
        private string _value;
        /// <summary>
        ///  The type of the id.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "type")]
        [Newtonsoft.Json.JsonProperty("type")]
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        /// <summary>
        ///  Convenience property for treating Type as an enum. See Gx.Types.IdentifierTypeQNameUtil for details on getter/setter functionality.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Newtonsoft.Json.JsonIgnore]
        public Gx.Types.IdentifierType KnownType
        {
            get
            {
                return XmlQNameEnumUtil.GetEnumValue<IdentifierType>(this._type);
            }
            set
            {
                this._type = XmlQNameEnumUtil.GetNameValue(value);
            }
        }
        /// <summary>
        ///  The id value.
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        [Newtonsoft.Json.JsonProperty("value")]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        /**
         * Build up this identifier with a value.
         *
         * @param value The value.
         * @return this.
         */
        public Identifier SetValue(String value)
        {
            Value = value;
            return this;
        }

        /**
         * Build up this identifier with a type.
         * @param type The type.
         * @return this.
         */
        public Identifier SetType(String type)
        {
            Type = type;
            return this;
        }

        /**
         * Build up this identifier with a type.
         * @param type The type.
         * @return this.
         */
        public Identifier SetType(IdentifierType type)
        {
            KnownType = type;
            return this;
        }
    }
}
