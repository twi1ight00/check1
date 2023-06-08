using System.Xml.Schema;

namespace ns55;

internal class Class1228 : Class1226
{
	public const string string_1 = "application/vnd.openxmlformats-officedocument.drawingml.chart+xml";

	public const string string_2 = "http://schemas.openxmlformats.org/drawingml/2006/chart";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/chart");

	public static readonly string[] string_3 = new string[1] { "" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_3);

	public override string ContentType => "application/vnd.openxmlformats-officedocument.drawingml.chart+xml";

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/drawingml/2006/chart";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_3;

	public override bool NoIndentation => true;
}
