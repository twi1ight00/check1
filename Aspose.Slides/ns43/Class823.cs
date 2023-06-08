using ns42;

namespace ns43;

internal class Class823 : Class822
{
	internal static Class1096 class1096_0;

	internal static readonly string string_12;

	protected override Class1096 ElementsFactory => class1096_0;

	internal Class816 SStElement => (Class816)method_1("sst", string_12);

	static Class823()
	{
		string_12 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		class1096_0 = new Class1096(string_12, typeof(Class810));
		class1096_0.Add(string_12, Class816.string_1, typeof(Class816));
	}

	public Class823(Class834 package)
		: base(package)
	{
	}
}
