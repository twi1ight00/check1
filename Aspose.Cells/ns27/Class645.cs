using System;
using System.Text;
using ns59;

namespace ns27;

internal class Class645 : Class538
{
	internal Class645(bool bool_0)
	{
		if (bool_0)
		{
			method_2(20);
		}
		else
		{
			method_2(21);
		}
	}

	internal void method_4(string[] string_0)
	{
		byte[][] array = new byte[3][];
		method_0(3);
		int num = 0;
		if (string_0 == null)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			string text = string_0[i];
			if (text == null || !(text != ""))
			{
				continue;
			}
			switch (i)
			{
			case 0:
				if (!text.StartsWith("&L"))
				{
					text = "&L" + text;
				}
				break;
			case 1:
				if (!text.StartsWith("&C"))
				{
					text = "&C" + text;
				}
				break;
			case 2:
				if (!text.StartsWith("&R"))
				{
					text = "&R" + text;
				}
				break;
			}
			array[i] = Encoding.Unicode.GetBytes(text);
			method_0((short)(base.Length + (short)array[i].Length));
			num += text.Length;
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((short)num), 0, byte_0, 0, 2);
		byte_0[2] = 1;
		int num2 = 3;
		for (int j = 0; j < 3; j++)
		{
			if (array[j] != null)
			{
				Array.Copy(array[j], 0, byte_0, num2, array[j].Length);
				num2 += array[j].Length;
			}
		}
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		if (byte_0 == null)
		{
			class1725_0.method_7(method_1());
			class1725_0.method_8(0);
		}
		else
		{
			base.vmethod_0(class1725_0);
		}
	}
}
