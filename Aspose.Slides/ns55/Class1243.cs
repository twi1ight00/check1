using System.Xml.Schema;

namespace ns55;

internal abstract class Class1243 : Class1239
{
	public static readonly string[] string_2 = new string[1] { "pml-slide.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public sealed override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public sealed override string[] SchemaCollectionNames => string_2;
}
