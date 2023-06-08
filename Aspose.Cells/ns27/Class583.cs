using System;
using System.Text;
using Aspose.Cells;
using ns22;

namespace ns27;

internal class Class583 : Class538
{
	internal Class583()
	{
		method_2(2204);
	}

	[Attribute0(true)]
	internal void method_4(PageSetup pageSetup_0)
	{
		string text = method_6(pageSetup_0.string_4);
		string text2 = method_6(pageSetup_0.string_5);
		string text3 = method_6(pageSetup_0.string_7);
		string text4 = method_6(pageSetup_0.string_6);
		method_0(38);
		if (text != null)
		{
			method_0((short)(base.Length + (short)(3 + text.Length * 2)));
		}
		if (text2 != null)
		{
			method_0((short)(base.Length + (short)(3 + text2.Length * 2)));
		}
		if (text3 != null)
		{
			method_0((short)(base.Length + (short)(3 + text3.Length * 2)));
		}
		if (text4 != null)
		{
			method_0((short)(base.Length + (short)(3 + text4.Length * 2)));
		}
		byte_0 = new byte[base.Length];
		byte_0[0] = 156;
		byte_0[1] = 8;
		int num = 28;
		byte_0[28] = pageSetup_0.method_21();
		num = 28 + 2;
		if (text != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)text.Length), 0, byte_0, num, 2);
		}
		num += 2;
		if (text2 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)text2.Length), 0, byte_0, num, 2);
		}
		num += 2;
		if (text3 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)text3.Length), 0, byte_0, num, 2);
		}
		num += 2;
		if (text4 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)text4.Length), 0, byte_0, num, 2);
		}
		num += 2;
		if (text != null)
		{
			method_5(ref num, text);
		}
		if (text2 != null)
		{
			method_5(ref num, text2);
		}
		if (text3 != null)
		{
			method_5(ref num, text3);
		}
		if (text4 != null)
		{
			method_5(ref num, text4);
		}
	}

	[Attribute0(true)]
	internal void method_5(ref int int_0, string string_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, int_0, 2);
		int_0 += 2;
		byte_0[int_0++] = 1;
		Array.Copy(Encoding.Unicode.GetBytes(string_0), 0, byte_0, int_0, string_0.Length * 2);
		int_0 += string_0.Length * 2;
	}

	internal string method_6(string[] string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_0.Length; i++)
		{
			if (string_0[i] != null)
			{
				stringBuilder.Append(string_0[i]);
			}
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString();
	}
}
