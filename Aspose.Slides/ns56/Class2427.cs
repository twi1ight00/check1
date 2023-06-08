using ns33;

namespace ns56;

internal class Class2427
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "string", "normalizedString", "token", "byte", "unsignedByte", "base64Binary", "hexBinary", "integer", "positiveInteger", "negativeInteger", "nonPositiveInteger", "nonNegativeInteger", "int", "unsignedInt", "long", "unsignedLong", "short", "unsignedShort", "decimal", "float", "double", "boolean", "time", "dateTime", "duration", "date", "gMonth", "gYear", "gYearMonth", "gDay", "gMonthDay", "Name", "QName", "NCName", "anyURI", "language", "ID", "IDREF", "IDREFS", "ENTITY", "ENTITIES", "NOTATION", "NMTOKEN", "NMTOKENS", "anyType");

	public static Enum260 smethod_0(string xmlValue)
	{
		return (Enum260)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum260 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
