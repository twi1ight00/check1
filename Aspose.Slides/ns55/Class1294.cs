using System.Collections.Generic;
using System.Xml.Schema;

namespace ns55;

internal class Class1294 : Class1225
{
	public const string string_1 = "application/vnd.openxmlformats-officedocument.vmlDrawing";

	public const string string_2 = "urn:schemas-microsoft-com:vml";

	public static readonly Class1338 class1338_0 = new Class1338("http://schemas.openxmlformats.org/officeDocument/2006/relationships/vmlDrawing");

	public static readonly string[] string_3 = new string[1] { "" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_3);

	public static readonly SortedList<string, string> sortedList_0 = new SortedList<string, string> { { "mv", "urn:schemas-microsoft-com:mac:vml" } };

	public override string ContentType => "application/vnd.openxmlformats-officedocument.vmlDrawing";

	public sealed override string RootNamespace => "urn:schemas-microsoft-com:vml";

	public override Class1338 TypeAttributeOfSourceRelationship => class1338_0;

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_3;

	public override SortedList<string, string> ImplicitNamespaces => sortedList_0;
}
