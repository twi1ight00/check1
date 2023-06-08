using ns42;

namespace ns43;

internal class Class825 : Class822
{
	internal static Class1096 class1096_0;

	internal static readonly string string_12;

	internal static readonly string string_13;

	protected override Class1096 ElementsFactory => class1096_0;

	internal Class817 TableElement => (Class817)method_1(Class817.string_1, string_13);

	static Class825()
	{
		string_12 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/table";
		string_13 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		class1096_0 = new Class1096(string_13, typeof(Class810));
		class1096_0.Add(string_13, Class817.string_1, typeof(Class817));
	}

	public Class825(Class834 package)
		: base(package)
	{
	}
}
