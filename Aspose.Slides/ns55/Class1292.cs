using System.Xml.Schema;

namespace ns55;

internal class Class1292 : Class1225
{
	public const string string_1 = "application/vnd.openxmlformats-officedocument.drawing+xml";

	public const string string_2 = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/drawing");

	public static readonly string[] string_3 = new string[1] { "dml-spreadsheetDrawing.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_3);

	public override string ContentType => "application/vnd.openxmlformats-officedocument.drawing+xml";

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public sealed override string[] SchemaCollectionNames => string_3;

	public sealed override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;
}
