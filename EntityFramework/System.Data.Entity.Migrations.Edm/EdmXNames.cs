using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Edm;

internal static class EdmXNames
{
	public static class Csdl
	{
		public static readonly XName Association = Name("Association");

		public static readonly XName ComplexType = Name("ComplexType");

		public static readonly XName End = Name("End");

		public static readonly XName EntityType = Name("EntityType");

		public static readonly XName Property = Name("Property");

		public static readonly XName Schema = Name("Schema");

		private static XName Name(string elementName)
		{
			return CsdlNamespace + elementName;
		}
	}

	public static class Msl
	{
		public static readonly XName AssociationSetMapping = Name("AssociationSetMapping");

		public static readonly XName ComplexProperty = Name("ComplexProperty");

		public static readonly XName Condition = Name("Condition");

		public static readonly XName EntityTypeMapping = Name("EntityTypeMapping");

		public static readonly XName Mapping = Name("Mapping");

		public static readonly XName MappingFragment = Name("MappingFragment");

		public static readonly XName ScalarProperty = Name("ScalarProperty");

		private static XName Name(string elementName)
		{
			return MslNamespace + elementName;
		}
	}

	public static class Ssdl
	{
		public static readonly XName Association = Name("Association");

		public static readonly XName Dependent = Name("Dependent");

		public static readonly XName End = Name("End");

		public static readonly XName EntitySet = Name("EntitySet");

		public static readonly XName EntityType = Name("EntityType");

		public static readonly XName Key = Name("Key");

		public static readonly XName OnDelete = Name("OnDelete");

		public static readonly XName Principal = Name("Principal");

		public static readonly XName Property = Name("Property");

		public static readonly XName PropertyRef = Name("PropertyRef");

		public static readonly XName Schema = Name("Schema");

		private static XName Name(string elementName)
		{
			return SsdlNamespace + elementName;
		}
	}

	private static readonly XNamespace CsdlNamespace = XNamespace.Get("http://schemas.microsoft.com/ado/2008/09/edm");

	private static readonly XNamespace MslNamespace = XNamespace.Get("http://schemas.microsoft.com/ado/2008/09/mapping/cs");

	private static readonly XNamespace SsdlNamespace = XNamespace.Get("http://schemas.microsoft.com/ado/2009/02/edm/ssdl");

	public static string ActionAttribute(this XElement element)
	{
		return (string)element.Attribute("Action");
	}

	public static string ColumnNameAttribute(this XElement element)
	{
		return (string)element.Attribute("ColumnName");
	}

	public static string EntitySetAttribute(this XElement element)
	{
		return (string)element.Attribute("EntitySet");
	}

	public static string NameAttribute(this XElement element)
	{
		return (string)element.Attribute("Name");
	}

	public static string EntityTypeAttribute(this XElement element)
	{
		return (string)element.Attribute("EntityType");
	}

	public static string NullableAttribute(this XElement element)
	{
		return (string)element.Attribute("Nullable");
	}

	public static string MaxLengthAttribute(this XElement element)
	{
		return (string)element.Attribute("MaxLength");
	}

	public static string FixedLengthAttribute(this XElement element)
	{
		return (string)element.Attribute("FixedLength");
	}

	public static string PrecisionAttribute(this XElement element)
	{
		return (string)element.Attribute("Precision");
	}

	public static string ProviderAttribute(this XElement element)
	{
		return (string)element.Attribute("Provider");
	}

	public static string ProviderManifestTokenAttribute(this XElement element)
	{
		return (string)element.Attribute("ProviderManifestToken");
	}

	public static string ScaleAttribute(this XElement element)
	{
		return (string)element.Attribute("Scale");
	}

	public static string StoreGeneratedPatternAttribute(this XElement element)
	{
		return (string)element.Attribute("StoreGeneratedPattern");
	}

	public static string UnicodeAttribute(this XElement element)
	{
		return (string)element.Attribute("Unicode");
	}

	public static string RoleAttribute(this XElement element)
	{
		return (string)element.Attribute("Role");
	}

	public static string SchemaAttribute(this XElement element)
	{
		return (string)element.Attribute("Schema");
	}

	public static string StoreEntitySetAttribute(this XElement element)
	{
		return (string)element.Attribute("StoreEntitySet");
	}

	public static string TableAttribute(this XElement element)
	{
		return (string)element.Attribute("Table");
	}

	public static string TypeAttribute(this XElement element)
	{
		return (string)element.Attribute("Type");
	}

	public static string TypeNameAttribute(this XElement element)
	{
		return (string)element.Attribute("TypeName");
	}

	public static string ValueAttribute(this XElement element)
	{
		return (string)element.Attribute("Value");
	}
}
