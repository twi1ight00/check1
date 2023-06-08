using System;
using System.Xml.Schema;

namespace ns55;

internal class Class1295 : Class1224
{
	public const string string_1 = "not applicable";

	public static readonly string[] string_2 = new string[1] { "opc-contentTypes.xsd" };

	public static readonly XmlSchemaCollection xmlSchemaCollection_0 = Class1224.smethod_1(string_2);

	public override string ContentType => "not applicable";

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
