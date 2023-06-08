using System.Xml.Schema;
using ns53;

namespace ns55;

internal class Class1238 : Class1225
{
	public const string string_1 = "application/xml";

	public static readonly string[] string_2 = new string[1] { "" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public override string ContentType => "application/xml";

	public sealed override string RootNamespace
	{
		get
		{
			throw new Exception4("Root Namespace is not applicable for UnknownContentPartType.");
		}
	}

	public override Class1338 TypeAttributeOfSourceRelationship => null;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_2;
}
