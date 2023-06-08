using System.Collections.Generic;

namespace ns55;

internal abstract class Class1239 : Class1225
{
	public const string string_1 = "http://schemas.openxmlformats.org/presentationml/2006/main";

	public static readonly SortedList<string, string> sortedList_0 = new SortedList<string, string>
	{
		{ "p14", "http://schemas.microsoft.com/office/powerpoint/2010/main" },
		{ "p15", "http://schemas.microsoft.com/office/powerpoint/2012/main" }
	};

	public sealed override string RootNamespace => "http://schemas.openxmlformats.org/presentationml/2006/main";

	public override SortedList<string, string> ImplicitNamespaces => sortedList_0;
}
