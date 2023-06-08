using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class352 : Class316
{
	internal Class352()
	{
		int_0 = 651;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		string codeName = worksheet_0.CodeName;
		int num = 14;
		if (codeName != null)
		{
			num += codeName.Length * 2;
		}
		byte_0 = new byte[num];
		method_2(byte_0, 2, worksheet_0.TabColor);
		int num2 = 10;
		Class1217.smethod_7(byte_0, ref num2, codeName);
	}
}
