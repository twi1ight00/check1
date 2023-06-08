using System.Xml.Schema;

namespace ns55;

internal abstract class Class1229 : Class1225
{
	public const string string_1 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public static readonly string[] string_2 = new string[1] { "" };

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/drawingml/2006/diagram";

	public sealed override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public sealed override string[] SchemaCollectionNames => string_2;
}
