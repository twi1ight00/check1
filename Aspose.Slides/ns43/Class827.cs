using ns42;

namespace ns43;

internal class Class827 : Class822
{
	internal static Class1096 class1096_0;

	internal static readonly string string_12;

	protected override Class1096 ElementsFactory => class1096_0;

	internal Class819 WorkSheetElement => (Class819)method_1("worksheet", string_12);

	static Class827()
	{
		string_12 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		class1096_0 = new Class1096(string_12, typeof(Class810));
		class1096_0.Add(Class819.string_1, typeof(Class819));
		class1096_0.Add(string_12, Class815.string_1, typeof(Class815));
		class1096_0.Add(string_12, Class811.string_1, typeof(Class811));
		class1096_0.Add(string_12, Class812.string_1, typeof(Class812));
	}

	public Class827(Class834 package)
		: base(package)
	{
	}
}
