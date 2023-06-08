namespace ns28;

internal class Class464 : Class461
{
	internal static Class482 class482_0;

	internal static readonly string string_0;

	internal static readonly string string_1;

	internal static readonly string string_2;

	internal static readonly string string_3;

	internal static readonly string string_4;

	internal static readonly string string_5;

	internal static readonly string string_6;

	protected override Class482 ElementsFactory => class482_0;

	static Class464()
	{
		string_0 = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";
		string_1 = "http://www.w3.org/1999/xlink";
		string_2 = "urn:oasis:names:tc:opendocument:xmlns:config:1.0";
		string_3 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";
		string_4 = "http://openoffice.org/2004/office";
		string_5 = "urn:oasis:names:tc:opendocument:xmlns:smil-compatible:1.0";
		string_6 = "urn:oasis:names:tc:opendocument:xmlns:animation:1.0";
		class482_0 = new Class482(string_0);
		class482_0.Add(string_0, "document-settings", typeof(Class434));
		class482_0.Add(string_0, "settings", typeof(Class434));
		class482_0.Add(string_2, Class379.string_0, typeof(Class379));
		class482_0.Add(string_2, Class378.string_0, typeof(Class378));
	}

	public Class464(Class476 package)
		: base(package)
	{
	}
}
