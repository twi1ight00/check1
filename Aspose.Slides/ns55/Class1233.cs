namespace ns55;

internal class Class1233 : Class1229
{
	public const string string_3 = "application/vnd.openxmlformats-officedocument.drawingml.diagramStyle+xml";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/diagramQuickStyle");

	public override string ContentType => "application/vnd.openxmlformats-officedocument.drawingml.diagramStyle+xml";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public static string smethod_3()
	{
		return "http://schemas.openxmlformats.org/drawingml/2006/diagram";
	}
}
