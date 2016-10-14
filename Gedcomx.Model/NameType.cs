// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Types {

  /// <remarks>
  ///  Enumeration of standard name types.
  /// </remarks>
  /// <summary>
  ///  Enumeration of standard name types.
  /// </summary>
  public enum NameType {

    /// <summary>
    ///  Unspecified enum value.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="__NULL__")]
    NULL,

    /// <summary>
    ///   Name given at birth.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/BirthName")]
    BirthName,

    /// <summary>
    ///   Name used at the time of death.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/DeathName")]
    DeathName,

    /// <summary>
    ///   Name accepted at marriage.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/MarriedName")]
    MarriedName,

    /// <summary>
    ///   &quot;Also known as&quot; name.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/AlsoKnownAs")]
    AlsoKnownAs,

    /// <summary>
    ///   Nickname.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Nickname")]
    Nickname,

    /// <summary>
    ///   Name given at adoption.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/AdoptiveName")]
    AdoptiveName,

    /// <summary>
    ///   A formal name, usually given to distinguish it from a name more commonly used.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/FormalName")]
    FormalName,

    /// <summary>
    ///   A name given at a religious rite or ceremony.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/ReligiousName")]
    ReligiousName,

    /// <summary>
    ///  (no documentation provided)
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/OTHER")]
    OTHER
  }
}
