using System.Xml;

namespace ns28;

internal class Class462 : Class461
{
	internal static Class482 class482_0;

	internal static readonly string string_0;

	internal static readonly string string_1;

	internal static readonly string string_2;

	internal static readonly string string_3;

	internal static readonly string string_4;

	internal static readonly string string_5;

	internal static readonly string string_6;

	internal static readonly string string_7;

	internal static readonly string string_8;

	internal static readonly string string_9;

	internal static readonly string string_10;

	internal static readonly string string_11;

	internal static readonly string string_12;

	internal static readonly string string_13;

	internal static readonly string string_14;

	internal static readonly string string_15;

	internal static readonly string string_16;

	internal static readonly string string_17;

	internal static readonly string string_18;

	internal static readonly string string_19;

	internal static readonly string string_20;

	internal static readonly string string_21;

	internal static readonly string string_22;

	internal static readonly string string_23;

	internal static readonly string string_24;

	internal static readonly string string_25;

	public Class416[] Pages
	{
		get
		{
			XmlNodeList elementsByTagName = GetElementsByTagName("page", string_9);
			Class416[] array = new Class416[elementsByTagName.Count];
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				array[i] = (Class416)elementsByTagName.Item(i);
			}
			return array;
		}
	}

	protected override Class482 ElementsFactory => class482_0;

	internal Class369 Presentation => method_0("presentation", string_0);

	internal Class369 AutomaticStyles => method_0("automatic-styles", string_0);

	static Class462()
	{
		string_0 = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";
		string_1 = "http://www.w3.org/1999/xlink";
		string_2 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";
		string_3 = "http://openoffice.org/2004/office";
		string_4 = "urn:oasis:names:tc:opendocument:xmlns:smil-compatible:1.0";
		string_5 = "urn:oasis:names:tc:opendocument:xmlns:animation:1.0";
		string_6 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";
		string_7 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
		string_8 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";
		string_9 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		string_10 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";
		string_11 = "http://purl.org/dc/elements/1.1/";
		string_12 = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0";
		string_13 = "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0";
		string_14 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";
		string_15 = "urn:oasis:names:tc:opendocument:xmlns:chart:1.0";
		string_16 = "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0";
		string_17 = "http://www.w3.org/1998/Math/MathML";
		string_18 = "urn:oasis:names:tc:opendocument:xmlns:form:1.0";
		string_19 = "urn:oasis:names:tc:opendocument:xmlns:script:1.0";
		string_20 = "http://openoffice.org/2004/writer";
		string_21 = "http://openoffice.org/2004/calc";
		string_22 = "http://www.w3.org/2001/xml-events";
		string_23 = "http://www.w3.org/2002/xforms";
		string_24 = "http://www.w3.org/2001/XMLSchema";
		string_25 = "http://www.w3.org/2001/XMLSchema-instance";
		class482_0 = new Class482(string_0);
		class482_0.Add(string_0, Class438.string_0[1], typeof(Class438));
		class482_0.Add(string_0, Class372.string_0, typeof(Class372));
		class482_0.Add(string_0, Class423.string_0, typeof(Class423));
		class482_0.Add(string_9, Class416.string_0, typeof(Class416));
		class482_0.Add(string_6, Class437.string_0, typeof(Class437));
		class482_0.Add(string_6, Class457.string_1, typeof(Class457));
		class482_0.Add(string_6, Class418.string_0, typeof(Class418));
		class482_0.Add(string_6, Class397.string_3, typeof(Class397));
		class482_0.Add(string_7, Class406.string_1, typeof(Class406));
		class482_0.Add(string_7, Class404.string_0, typeof(Class404));
		class482_0.Add(string_6, Class403.string_1, typeof(Class403));
		class482_0.Add(string_6, Class387.string_0, typeof(Class387));
		class482_0.Add(string_2, Class427.string_0, typeof(Class427));
		class482_0.Add(string_9, Class382.string_0, typeof(Class382));
		class482_0.Add(string_9, Class393.string_0, typeof(Class393));
		class482_0.Add(string_9, Class392.string_1, typeof(Class392));
		class482_0.Add(string_9, Class384.string_0, typeof(Class384));
		class482_0.Add(string_7, Class456.string_1, typeof(Class456));
		class482_0.Add(string_9, Class389.string_0, typeof(Class389));
		class482_0.Add(string_9, Class386.string_0, typeof(Class386));
		class482_0.Add(string_2, Class429.string_0, typeof(Class429));
		class482_0.Add(string_9, Class380.string_0, typeof(Class380));
		class482_0.Add(string_9, Class402.string_0, typeof(Class402));
		class482_0.Add(string_9, Class411.string_0, typeof(Class411));
		class482_0.Add(string_9, Class430.string_0, typeof(Class430));
		class482_0.Add(string_9, Class391.string_0, typeof(Class391));
		class482_0.Add(string_9, Class374.string_0, typeof(Class374));
		class482_0.Add(string_9, Class431.string_0, typeof(Class431));
		class482_0.Add(string_9, Class373.string_0, typeof(Class373));
		class482_0.Add(string_9, Class381.string_0, typeof(Class381));
		class482_0.Add(string_9, Class417.string_0, typeof(Class417));
		class482_0.Add(string_9, Class422.string_0, typeof(Class422));
		class482_0.Add(string_9, Class421.string_0, typeof(Class421));
		class482_0.Add(string_9, Class419.string_0, typeof(Class419));
		class482_0.Add(string_9, Class395.string_1, typeof(Class395));
		class482_0.Add(string_7, Class455.string_0, typeof(Class455));
		class482_0.Add(string_7, Class458.string_1, typeof(Class458));
		class482_0.Add(string_7, Class405.string_0, typeof(Class405));
		class482_0.Add(string_7, Class435.string_0, typeof(Class435));
	}

	public Class462(Class476 package)
		: base(package)
	{
	}

	internal Class416 method_2(string name)
	{
		return (Class416)Presentation.method_35("page", string_9);
	}
}
