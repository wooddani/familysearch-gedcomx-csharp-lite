// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Links
{

    /// <remarks>
    ///  A hypermedia link, used to drive the state of a hypermedia-enabled genealogical data application.
    /// </remarks>
    /// <summary>
    ///  A hypermedia link, used to drive the state of a hypermedia-enabled genealogical data application.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://gedcomx.org/v1/", TypeName = "Link")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://gedcomx.org/v1/", ElementName = "link")]
    public partial class Link
    {

        private string _template;
        private string _allow;
        private int? _count;
        private bool _countSpecified;
        private string _accept;
        private string _type;
        private string _hreflang;
        private string _title;
        private int? _results;
        private bool _resultsSpecified;
        private string _rel;
        private int? _offset;
        private bool _offsetSpecified;
        private String _href;

        public Link()
        {
        }

        public Link(String rel, String href)
            : this()
        {
            this.Rel = rel;
            this.Href = href;
        }

        /// <summary>
        ///  A URI template per &lt;a href=&quot;http://tools.ietf.org/html/rfc6570&quot;&gt;RFC 6570&lt;/a&gt;, used to link to a range of
        ///  URIs, such as for the purpose of linking to a query.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "template")]
        [Newtonsoft.Json.JsonProperty("template")]
        public string Template
        {
            get
            {
                return this._template;
            }
            set
            {
                this._template = value;
            }
        }
        /// <summary>
        ///  Metadata about the available media type(s) of the resource being linked to.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "allow")]
        [Newtonsoft.Json.JsonProperty("allow")]
        public string Allow
        {
            get
            {
                return this._allow;
            }
            set
            {
                this._allow = value;
            }
        }
        /// <summary>
        ///  The number of elements in the page, if this link refers to a page of resources.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "count")]
        [Newtonsoft.Json.JsonProperty("count")]
        public int Count
        {
            get
            {
                return this._count.GetValueOrDefault();
            }
            set
            {
                this._count = value;
                this._countSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Count" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Newtonsoft.Json.JsonIgnore]
        public bool CountSpecified
        {
            get
            {
                return this._countSpecified;
            }
            set
            {
                this._countSpecified = value;
            }
        }

        /// <summary>
        ///  Metadata about the available media type(s) of the resource being linked to.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "accept")]
        [Newtonsoft.Json.JsonProperty("accept")]
        public string Accept
        {
            get
            {
                return this._accept;
            }
            set
            {
                this._accept = value;
            }
        }
        /// <summary>
        ///  Metadata about the available media type(s) of the resource being linked to.
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
        ///  The language of the resource being linked to.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "hreflang")]
        [Newtonsoft.Json.JsonProperty("hreflang")]
        public string Hreflang
        {
            get
            {
                return this._hreflang;
            }
            set
            {
                this._hreflang = value;
            }
        }
        /// <summary>
        ///  Human-readable information about the link.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "title")]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
        /// <summary>
        ///  The total number of results in the page to which this links, if this link refers to a page of resources.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "results")]
        [Newtonsoft.Json.JsonProperty("results")]
        public int Results
        {
            get
            {
                return this._results.GetValueOrDefault();
            }
            set
            {
                this._results = value;
                this._resultsSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Results" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Newtonsoft.Json.JsonIgnore]
        public bool ResultsSpecified
        {
            get
            {
                return this._resultsSpecified;
            }
            set
            {
                this._resultsSpecified = value;
            }
        }

        /// <summary>
        ///  The link relationship.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "rel")]
        [Newtonsoft.Json.JsonProperty("rel")]
        public string Rel
        {
            get
            {
                return this._rel;
            }
            set
            {
                this._rel = value;
            }
        }
        /// <summary>
        ///  The index of the offset of the page, if this link refers to a page of resources.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "offset")]
        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset
        {
            get
            {
                return this._offset.GetValueOrDefault();
            }
            set
            {
                this._offset = value;
                this._offsetSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Offset" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Newtonsoft.Json.JsonIgnore]
        public bool OffsetSpecified
        {
            get
            {
                return this._offsetSpecified;
            }
            set
            {
                this._offsetSpecified = value;
            }
        }

        /// <summary>
        ///  The target IRI of the link.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "href")]
        [Newtonsoft.Json.JsonProperty("href")]
        public String Href
        {
            get
            {
                return this._href;
            }
            set
            {
                this._href = value;
            }
        }

        /**
         * Build out this link with a rel.
         *
         * @param rel The rel.
         * @return this.
         */
        public Link SetRel(String rel)
        {
            Rel = rel;
            return this;
        }

        /**
         * Build out this link with an href.
         *
         * @param href The href.
         * @return this.
         */
        public Link SetHref(String href)
        {
            Href = href;
            return this;
        }

        /**
         * Build out this link with a template.
         * @param template The template
         * @return this.
         */
        public Link SetTemplate(String template)
        {
            Template = template;
            return this;
        }

        /**
         * Build out this link with a type.
         * @param type The type.
         * @return this.
         */
        public Link SetType(String type)
        {
            Type = type;
            return this;
        }

        /**
         * Build out this link with an accept.
         *
         * @param accept The accept.
         * @return this.
         */
        public Link SetAccept(String accept)
        {
            Accept = accept;
            return this;
        }

        /**
         * Build out this link with an 'allow'.
         *
         * @param allow The allow.
         * @return this.
         */
        public Link SetAllow(String allow)
        {
            Allow = allow;
            return this;
        }

        /**
         * Build out this link with an href lang.
         * @param hreflang The hreflang.
         * @return this.
         */
        public Link SetHreflang(String hreflang)
        {
            Hreflang = hreflang;
            return this;
        }

        /**
         * Build out this link with a title.
         *
         * @param title The title.
         * @return this.
         */
        public Link SetTitle(String title)
        {
            Title = title;
            return this;
        }

        /**
         * Build out this link with a count.
         *
         * @param count The count.
         * @return this.
         */
        public Link SetCount(Int32 count)
        {
            Count = count;
            return this;
        }

        /**
         * Build out this link with an offset.
         *
         * @param offset The offset.
         * @return this.
         */
        public Link SetOffset(Int32 offset)
        {
            Offset = offset;
            return this;
        }

        /**
         * Build out this link with total results.
         *
         * @param results The total results count.
         * @return this.
         */
        public Link SetResults(Int32 results)
        {
            Results = results;
            return this;
        }
    }
}
