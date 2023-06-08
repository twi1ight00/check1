using System.Xml.Schema;

namespace ns55;

internal class Class1237 : Class1234
{
	public const string string_2 = "application/vnd.openxmlformats-officedocument.theme+xml";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");

	public static readonly string[] string_3 = new string[1] { "dml-stylesheet.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_3);

	public override string ContentType => "application/vnd.openxmlformats-officedocument.theme+xml";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_3;

	public static string smethod_3()
	{
		return "http://schemas.openxmlformats.org/drawingml/2006/main";
	}
}
