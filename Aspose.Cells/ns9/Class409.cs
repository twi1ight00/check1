using System;
using ns10;
using ns16;
using ns2;

namespace ns9;

internal class Class409 : Class316
{
	internal Class409()
	{
		int_0 = 48;
	}

	internal void SetStyle(Class1529 class1529_0)
	{
		string text = class1529_0.string_0;
		byte_0 = new byte[12 + text.Length * 2];
		int num = 0;
		int num2 = text.LastIndexOf('_');
		if (num2 != -1 && num2 != 0)
		{
			string text2 = text.Substring(num2 + 1);
			if (Class1677.smethod_19(text2) && text2.IndexOf('.') == -1)
			{
				num = int.Parse(text2);
				text = text.Substring(0, num2);
			}
		}
		int num3 = Class1224.smethod_3(text);
		Array.Copy(BitConverter.GetBytes(class1529_0.int_0), 0, byte_0, 0, 4);
		int num4 = 0;
		if (num3 != -1)
		{
			num4 |= 1;
		}
		byte_0[4] = (byte)num4;
		if (num3 != -1)
		{
			byte_0[6] = (byte)num3;
		}
		byte_0[7] = (byte)num;
		int num5 = 8;
		Class1217.smethod_7(byte_0, ref num5, class1529_0.string_0);
	}
}
