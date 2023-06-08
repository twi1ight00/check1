using Aspose.Cells;

namespace ns21;

internal class Class1111
{
	internal string string_0;

	internal InternalColor internalColor_0;

	internal Class1111(string string_1)
	{
		string_0 = string_1;
		internalColor_0 = new InternalColor(bool_0: true);
	}

	internal void Copy(Class1111 class1111_0)
	{
		string_0 = class1111_0.string_0;
		internalColor_0.method_19(class1111_0.internalColor_0);
	}
}
