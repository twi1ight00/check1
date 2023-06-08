using System.Xml.Schema;

namespace ns55;

internal abstract class Class1270 : Class1266
{
	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");

	public static readonly string[] string_2 = new string[1] { "sml-workbook.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public sealed override string[] SchemaCollectionNames => string_2;

	public sealed override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;
}
