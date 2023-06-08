using System;
using ns10;
using ns16;

namespace ns9;

internal class Class345 : Class316
{
	internal Class345()
	{
		int_0 = 156;
	}

	internal void method_6(Class1541 class1541_0)
	{
		int num = 8;
		string text = "rId" + class1541_0.int_0;
		num = 8 + (4 + text.Length * 2);
		num += 4 + class1541_0.worksheet_0.Name.Length * 2;
		byte_0 = new byte[num];
		if (!class1541_0.worksheet_0.IsVisible)
		{
			byte_0[0] = 1;
			if (class1541_0.worksheet_0.method_29())
			{
				byte_0[0] = 2;
			}
		}
		Array.Copy(BitConverter.GetBytes(class1541_0.int_0), 0, byte_0, 4, 4);
		int num2 = 8;
		Class1217.smethod_7(byte_0, ref num2, text);
		Class1217.smethod_7(byte_0, ref num2, class1541_0.worksheet_0.Name);
	}
}
