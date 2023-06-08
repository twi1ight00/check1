using System.Xml.Schema;

namespace ns55;

internal class Class1261 : Class1260
{
	public const string string_1 = "application/vnd.ms-office.activeX+xml";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/control");

	public static readonly string[] string_2 = new string[1] { "activeX.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public override string ContentType => "application/vnd.ms-office.activeX+xml";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_2;
}
