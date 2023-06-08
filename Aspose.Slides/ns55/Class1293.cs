using System.Xml.Schema;

namespace ns55;

internal class Class1293 : Class1225
{
	public const string string_1 = "application/vnd.ms-office.drawingml.diagramDrawing+xml";

	public const string string_2 = "http://schemas.microsoft.com/office/drawing/2008/diagram";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.microsoft.com/office/2007/relationships/diagramDrawing");

	public static readonly string[] string_3 = new string[1] { "" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_3);

	public override string ContentType => "application/vnd.ms-office.drawingml.diagramDrawing+xml";

	public sealed override string RootNamespace => "http://schemas.microsoft.com/office/drawing/2008/diagram";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_3;
}
