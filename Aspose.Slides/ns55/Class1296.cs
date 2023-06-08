using System;
using System.Xml.Schema;

namespace ns55;

internal class Class1296 : Class1224
{
	public const string string_1 = "application/vnd.openxmlformats-package.relationships+xml";

	public static readonly string[] string_2 = new string[1] { "opc-relationships.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public override string ContentType => "application/vnd.openxmlformats-package.relationships+xml";

	public override Class1338 TypeAttributeOfSourceRelationship
	{
		get
		{
			throw new InvalidOperationException("not applicable");
		}
	}

	public override XmlSchemaCollection SchemaCollection => xmlSchemaCollection_0;

	public override string[] SchemaCollectionNames => string_2;
}
