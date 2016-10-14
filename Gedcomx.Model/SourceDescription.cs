using Gedcomx.Model.Rt;
using Gedcomx.Model.Util;
using Gx.Common;
using Gx.Conclusion;
using Gx.Records;
using Gx.Types;
using Newtonsoft.Json;
// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;
using System.Collections.Generic;

namespace Gx.Source
{

    /// <remarks>
    ///  Represents a description of a source.
    /// </remarks>
    /// <summary>
    ///  Represents a description of a source.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://gedcomx.org/v1/", TypeName = "SourceDescription")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://gedcomx.org/v1/", ElementName = "sourceDescription")]
    public partial class SourceDescription : Gx.Links.HypermediaEnabledData, IAttributable
    {
        private string _about;
        private string _lang;
        private string _mediaType;
        private string _sortKey;
        private string _resourceType;
        private System.Collections.Generic.List<Gx.Source.SourceCitation> _citations;
        private Gx.Common.ResourceReference _mediator;
        private System.Collections.Generic.List<Gx.Source.SourceReference> _sources;
        private Gx.Common.ResourceReference _analysis;
        private Gx.Source.SourceReference _componentOf;
        private System.Collections.Generic.List<Gx.Common.TextValue> _titles;
        private Gx.Common.TextValue _titleLabel;
        private System.Collections.Generic.List<Gx.Common.Note> _notes;
        private Gx.Common.Attribution _attribution;
        private System.Collections.Generic.List<Gx.Common.TextValue> _descriptions;
        private System.Collections.Generic.List<Gx.Conclusion.Identifier> _identifiers;
        private DateTime? _created;
        private bool _createdSpecified;
        private DateTime? _modified;
        private bool _modifiedSpecified;
        private System.Collections.Generic.List<Gx.Source.Coverage> _coverage;
        private System.Collections.Generic.List<string> _rights;
        private System.Collections.Generic.List<Gx.Records.Field> _fields;
        private Gx.Common.ResourceReference _repository;
        private Gx.Common.ResourceReference _descriptorRef;
        /// <summary>
        ///  The URI (if applicable) of the actual source.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "about")]
        [Newtonsoft.Json.JsonProperty("about")]
        public string About
        {
            get
            {
                return this._about;
            }
            set
            {
                this._about = value;
            }
        }
        /// <summary>
        ///  The language of the genealogical data.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        [Newtonsoft.Json.JsonProperty("lang")]
        public string Lang
        {
            get
            {
                return this._lang;
            }
            set
            {
                this._lang = value;
            }
        }
        /// <summary>
        ///  Hint about the media (MIME) type of the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "mediaType")]
        [Newtonsoft.Json.JsonProperty("mediaType")]
        public string MediaType
        {
            get
            {
                return this._mediaType;
            }
            set
            {
                this._mediaType = value;
            }
        }
        /// <summary>
        ///  A sort key to be used in determining the position of this source relative to other sources in the same collection.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "sortKey")]
        [Newtonsoft.Json.JsonProperty("sortKey")]
        public string SortKey
        {
            get
            {
                return this._sortKey;
            }
            set
            {
                this._sortKey = value;
            }
        }
        /// <summary>
        ///  The type of the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "resourceType")]
        [Newtonsoft.Json.JsonProperty("resourceType")]
        public string ResourceType
        {
            get
            {
                return this._resourceType;
            }
            set
            {
                this._resourceType = value;
            }
        }

        /// <summary>
        ///  Convenience property for treating ResourceType as an enum. See Gx.Types.ResourceTypeQNameUtil for details on getter/setter functionality.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Newtonsoft.Json.JsonIgnore]
        public Gx.Types.ResourceType KnownResourceType
        {
            get
            {
                return XmlQNameEnumUtil.GetEnumValue<ResourceType>(this._resourceType);
            }
            set
            {
                this._resourceType = XmlQNameEnumUtil.GetNameValue(value);
            }
        }
        /// <summary>
        ///  The bibliographic citations for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "citation", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("citations")]
        public System.Collections.Generic.List<Gx.Source.SourceCitation> Citations
        {
            get
            {
                return this._citations;
            }
            set
            {
                this._citations = value;
            }
        }
        /// <summary>
        ///  A reference to the entity that mediates access to the described source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "mediator", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("mediator")]
        public Gx.Common.ResourceReference Mediator
        {
            get
            {
                return this._mediator;
            }
            set
            {
                this._mediator = value;
            }
        }
        /// <summary>
        ///  References to any sources to which this source is related (usually applicable to sources that are derived from or contained in another source).
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "source", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("sources")]
        public System.Collections.Generic.List<Gx.Source.SourceReference> Sources
        {
            get
            {
                return this._sources;
            }
            set
            {
                this._sources = value;
            }
        }
        /// <summary>
        ///  A reference to the analysis document explaining the analysis that went into this description of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "analysis", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("analysis")]
        public Gx.Common.ResourceReference Analysis
        {
            get
            {
                return this._analysis;
            }
            set
            {
                this._analysis = value;
            }
        }
        /// <summary>
        ///  A reference to the source that contains this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "componentOf", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("componentOf")]
        public Gx.Source.SourceReference ComponentOf
        {
            get
            {
                return this._componentOf;
            }
            set
            {
                this._componentOf = value;
            }
        }
        /// <summary>
        ///  A list of titles for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "title", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("titles")]
        public System.Collections.Generic.List<Gx.Common.TextValue> Titles
        {
            get
            {
                return this._titles;
            }
            set
            {
                this._titles = value;
            }
        }
        /// <summary>
        ///  A label for the title of this description.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "titleLabel", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("titleLabel")]
        public Gx.Common.TextValue TitleLabel
        {
            get
            {
                return this._titleLabel;
            }
            set
            {
                this._titleLabel = value;
            }
        }
        /// <summary>
        ///  Notes about a source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "note", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("notes")]
        public System.Collections.Generic.List<Gx.Common.Note> Notes
        {
            get
            {
                return this._notes;
            }
            set
            {
                this._notes = value;
            }
        }
        /// <summary>
        ///  The attribution metadata for this source description.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "attribution", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("attribution")]
        public Gx.Common.Attribution Attribution
        {
            get
            {
                return this._attribution;
            }
            set
            {
                this._attribution = value;
            }
        }
        /// <summary>
        ///  Human-readable descriptions of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "description", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("descriptions")]
        public System.Collections.Generic.List<Gx.Common.TextValue> Descriptions
        {
            get
            {
                return this._descriptions;
            }
            set
            {
                this._descriptions = value;
            }
        }
        /// <summary>
        ///  The list of identifiers for the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "identifier", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("identifiers")]
        [JsonConverter(typeof(JsonIdentifiersConverter))]
        public System.Collections.Generic.List<Gx.Conclusion.Identifier> Identifiers
        {
            get
            {
                return this._identifiers;
            }
            set
            {
                this._identifiers = value;
            }
        }
        /// <summary>
        ///  The date the source was created.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "created", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("created")]
        [JsonConverter(typeof(JsonUnixTimestampConverter))]
        public DateTime Created
        {
            get
            {
                return this._created.GetValueOrDefault();
            }
            set
            {
                this._created = value;
                this._createdSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Created" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Newtonsoft.Json.JsonIgnore]
        public bool CreatedSpecified
        {
            get
            {
                return this._createdSpecified;
            }
            set
            {
                this._createdSpecified = value;
            }
        }

        /// <summary>
        ///  The date the source was last modified.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "modified", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("modified")]
        [JsonConverter(typeof(JsonUnixTimestampConverter))]
        public DateTime Modified
        {
            get
            {
                return this._modified.GetValueOrDefault();
            }
            set
            {
                this._modified = value;
                this._modifiedSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Modified" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Newtonsoft.Json.JsonIgnore]
        public bool ModifiedSpecified
        {
            get
            {
                return this._modifiedSpecified;
            }
            set
            {
                this._modifiedSpecified = value;
            }
        }

        /// <summary>
        ///  Declarations of the coverage of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "coverage", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("coverage")]
        public System.Collections.Generic.List<Gx.Source.Coverage> Coverage
        {
            get
            {
                return this._coverage;
            }
            set
            {
                this._coverage = value;
            }
        }
        /// <summary>
        ///  The rights for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "rights", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("rights")]
        public System.Collections.Generic.List<string> Rights
        {
            get
            {
                return this._rights;
            }
            set
            {
                this._rights = value;
            }
        }
        /// <summary>
        ///  The fields that are applicable to the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "field", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("fields")]
        public System.Collections.Generic.List<Gx.Records.Field> Fields
        {
            get
            {
                return this._fields;
            }
            set
            {
                this._fields = value;
            }
        }
        /// <summary>
        ///  Reference to an agent describing the repository in which the source is found.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "repository", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("repository")]
        public Gx.Common.ResourceReference Repository
        {
            get
            {
                return this._repository;
            }
            set
            {
                this._repository = value;
            }
        }
        /// <summary>
        ///  Reference to a descriptor of fields and type of data that can be expected to be extracted from the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "descriptor", Namespace = "http://gedcomx.org/v1/")]
        [Newtonsoft.Json.JsonProperty("descriptor")]
        public Gx.Common.ResourceReference DescriptorRef
        {
            get
            {
                return this._descriptorRef;
            }
            set
            {
                this._descriptorRef = value;
            }
        }

        /**
         * Accept a visitor.
         *
         * @param visitor The visitor.
         */
        public void Accept(IGedcomxModelVisitor visitor)
        {
            visitor.VisitSourceDescription(this);
        }

        /**
         * Build out this envelope with a lang.
         *
         * @param lang The lang.
         * @return this.
         */
        public SourceDescription SetLang(String lang)
        {
            Lang = lang;
            return this;
        }

        /**
         * Build of this source description with a resource type.
         * @param resourceType The resource type.
         * @return this.
         */
        public SourceDescription SetResourceType(String resourceType)
        {
            ResourceType = resourceType;
            return this;
        }

        /**
         * Build of this source description with a resource type.
         * @param resourceType The resource type.
         * @return this.
         */
        public SourceDescription SetResourceType(ResourceType resourceType)
        {
            KnownResourceType = resourceType;
            return this;
        }

        /**
         * Build out this source description with a rights.
         * @param rights The rights.
         * @return this.
         */
        public SourceDescription SetRights(String rights)
        {
            AddRights(rights);
            return this;
        }

        /**
         * Build out this source description with a citation.
         * @param citation The citation.
         * @return this.
         */
        public SourceDescription SetCitation(SourceCitation citation)
        {
            AddCitation(citation);
            return this;
        }

        /**
         * Build out this source description with a citation.
         * @param citation The citation.
         * @return this.
         */
        public SourceDescription SetCitation(String citation)
        {
            AddCitation(new SourceCitation().SetValue(citation));
            return this;
        }

        /**
         * Build out this source description with a media type.
         * @param mediaType The media type.
         * @return this.
         */
        public SourceDescription SetMediaType(String mediaType)
        {
            MediaType = mediaType;
            return this;
        }

        /**
         * Build out this source description with an about reference.
         * @param about the about.
         * @return this.
         */
        public SourceDescription SetAbout(String about)
        {
            About = about;
            return this;
        }

        /**
         * Build out this source description with a mediator.
         * 
         * @param mediator The mediator.
         * @return this.
         */
        public SourceDescription SetMediator(ResourceReference mediator)
        {
            Mediator = mediator;
            return this;
        }

        /**
         * Build out this source description by adding a source reference.
         * @param source The source reference.
         * @return this.
         */
        public SourceDescription SetSource(SourceReference source)
        {
            if (this._sources == null)
            {
                this._sources = new List<SourceReference>();
            }
            this._sources.Add(source);
            return this;
        }

        /**
         * Build out this source description with an analyis.
         * @param analysis The analysis.
         * @return this.
         */
        public SourceDescription AddAnalysis(ResourceReference analysis)
        {
            Analysis = analysis;
            return this;
        }

        /**
         * Build out this source description with a component of.
         * @param componentOf The component of.
         * @return this.
         */
        public SourceDescription SetComponentOf(SourceReference componentOf)
        {
            ComponentOf = componentOf;
            return this;
        }

        /**
         * Build out this source description with a component of.
         * @param componentOf The component of.
         * @return this.
         */
        public SourceDescription SetComponentOf(SourceDescription componentOf)
        {
            ComponentOf = new SourceReference().SetDescription(componentOf);
            return this;
        }

        public SourceDescription SetTitle(String title)
        {
            return SetTitle(new TextValue(title));
        }

        /**
         * Build out this source description with a title.
         * @param title The title. 
         * @return this.
         */
        public SourceDescription SetTitle(TextValue title)
        {
            if (this._titles == null)
            {
                this._titles = new List<TextValue>();
            }

            this._titles.Add(title);
            return this;
        }

        /**
         * Build this out by applying a label for the title of this description.
         * @param titleLabel The title label.
         * @return this.
         */
        public SourceDescription SetTitleLabel(TextValue titleLabel)
        {
            TitleLabel = titleLabel;
            return this;
        }

        public SourceDescription SetNote(String note)
        {
            return SetNote(new Note().SetText(note));
        }

        /**
         * Build out this source description with a note.
         * @param note the note.
         * @return this.
         */
        public SourceDescription SetNote(Note note)
        {
            if (this._notes == null)
            {
                this._notes = new List<Note>();
            }
            this._notes.Add(note);
            return this;
        }

        /**
         * Build out this source description with attribution.
         * @param attribution The attribution.
         * @return this.
         */
        public SourceDescription SetAttribution(Attribution attribution)
        {
            Attribution = attribution;
            return this;
        }

        /**
         * Build out this source description with an identifier.
         * @param identifier the identifier.
         * @return this.
         */
        public SourceDescription SetIdentifier(Identifier identifier)
        {
            if (this._identifiers == null)
            {
                this._identifiers = new List<Identifier>();
            }
            this._identifiers.Add(identifier);
            return this;
        }

        /**
         * Build out this source description with a sort key.
         * @param sortKey The sort key.
         * @return This.
         */
        public SourceDescription SetSortKey(String sortKey)
        {
            SortKey = sortKey;
            return this;
        }

        public SourceDescription SetDescription(String description)
        {
            return SetDescription(new TextValue(description));
        }

        /**
         * Build out this source description with a description.
         * @param description The description. 
         * @return this.
         */
        public SourceDescription SetDescription(TextValue description)
        {
            if (this._descriptions == null)
            {
                this._descriptions = new List<TextValue>();
            }

            this._descriptions.Add(description);
            return this;
        }

        /**
         * Build out this source description with a created date.
         *
         * @param created The created date.
         * @return this.
         */
        public SourceDescription SetCreated(DateTime created)
        {
            Created = created;
            return this;
        }

        /**
         * Build out this source description with a modified date.
         * @param modified the modified date.
         */
        public SourceDescription SetModified(DateTime modified)
        {
            Modified = modified;
            return this;
        }

        /**
         * Build out this source description with coverage.
         * @param coverage The coverage.
         * @return this.
         */
        public SourceDescription SetCoverage(Coverage coverage)
        {
            if (this._coverage == null)
            {
                this._coverage = new List<Coverage>();
            }

            this._coverage.Add(coverage);
            return this;
        }

        /**
         * Build this out with a field.
         * @param field The field.
         * @return this.
         */
        public SourceDescription SetField(Field field)
        {
            AddField(field);
            return this;
        }

        /**
         * Build out this source description with a repository.
         *
         * @param repository The repository.
         * @return this.
         */
        public SourceDescription SetRepository(Gx.Agent.Agent repository)
        {
            return SetRepository(new ResourceReference("#" + repository.Id));
        }

        /**
         * Build out this source description with a repository.
         *
         * @param repository The repository.
         * @return this.
         */
        public SourceDescription SetRepository(ResourceReference repository)
        {
            Repository = repository;
            return this;
        }

        /**
         * Build out this source description with a descriptor ref.
         *
         * @param descriptorRef The descriptor ref.
         * @return this.
         */
        public SourceDescription SetDescriptorRef(ResourceReference descriptorRef)
        {
            DescriptorRef = descriptorRef;
            return this;
        }

        /**
         * Add a rights.
         *
         * @param rights The rights to be added.
         */
        public void AddRights(String rights)
        {
            if (rights != null)
            {
                if (this._rights == null)
                {
                    this._rights = new List<String>();
                }
                this._rights.Add(rights);
            }
        }

        /**
         * Add a citation.
         *
         * @param citation The citation to be added.
         */
        public void AddCitation(SourceCitation citation)
        {
            if (citation != null)
            {
                if (_citations == null)
                {
                    _citations = new List<SourceCitation>();
                }
                _citations.Add(citation);
            }
        }

        /**
         * Add a field to the source description.
         *
         * @param field The field to be added.
         */
        public void AddField(Field field)
        {
            if (field != null)
            {
                if (_fields == null)
                    _fields = new List<Field>();
                _fields.Add(field);
            }
        }
    }
}