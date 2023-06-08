using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class395 : Class316
{
	internal Class395()
	{
		int_0 = 147;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		string text = worksheet_0.method_47();
		int num = 23;
		if (text != null)
		{
			num += text.Length * 2;
		}
		byte_0 = new byte[num];
		int num2 = 0;
		if (!worksheet_0.PageSetup.IsPercentScale)
		{
			num2 |= 1;
		}
		if (worksheet_0.IsOutlineShown)
		{
			num2 |= 4;
		}
		byte_0[0] = 201;
		byte_0[1] = (byte)num2;
		method_2(byte_0, 3, worksheet_0.TabColor);
		for (int i = 11; i <= 18; i++)
		{
			byte_0[i] = byte.MaxValue;
		}
		int num3 = 19;
		Class1217.smethod_7(byte_0, ref num3, text);
	}
}
