using ns42;

namespace ns43;

internal class Class824 : Class822
{
	internal static Class1096 class1096_0;

	internal static readonly string string_12;

	protected override Class1096 ElementsFactory => class1096_0;

	internal Class810 CellXfsElement => method_1("cellXfs", string_12);

	internal Class810 NumFmtsElement => method_1("numFmts", string_12);

	static Class824()
	{
		string_12 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		class1096_0 = new Class1096(string_12, typeof(Class810));
		class1096_0.Add(string_12, Class820.string_1, typeof(Class820));
		class1096_0.Add(string_12, Class814.string_1, typeof(Class814));
		class1096_0.Add(string_12, "cellXfs", typeof(Class810));
		class1096_0.Add(string_12, "numFmts", typeof(Class810));
	}

	public Class824()
		: base(null)
	{
	}
}
