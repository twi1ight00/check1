using ns42;

namespace ns43;

internal class Class826 : Class822
{
	internal static Class1096 class1096_0;

	internal static readonly string string_12;

	protected override Class1096 ElementsFactory => class1096_0;

	internal Class818 WorkbookElement => (Class818)method_1("workbook", string_12);

	static Class826()
	{
		string_12 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		class1096_0 = new Class1096(string_12, typeof(Class810));
		class1096_0.Add(Class818.string_1, typeof(Class818));
		class1096_0.Add(Class813.string_1, typeof(Class813));
	}

	public Class826(Class834 package)
		: base(package)
	{
	}
}
