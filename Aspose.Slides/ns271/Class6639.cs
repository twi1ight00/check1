using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns218;

namespace ns271;

internal class Class6639 : Class6634
{
	internal const int int_0 = 65536;

	internal const int int_1 = 131072;

	internal const int int_2 = 151552;

	internal const int int_3 = 196608;

	private const int int_4 = 258;

	internal int int_5;

	internal int int_6;

	internal short short_0;

	internal short short_1;

	internal int int_7;

	internal int int_8;

	internal int int_9;

	internal int int_10;

	internal int int_11;

	internal int int_12;

	internal int[] int_13;

	internal List<string> list_0;

	internal Class6639(Class5950 reader)
	{
		int_5 = reader.method_0();
		int_6 = reader.method_0();
		short_0 = reader.method_2();
		short_1 = reader.method_2();
		int_7 = reader.method_0();
		int_8 = reader.method_0();
		int_9 = reader.method_0();
		int_10 = reader.method_0();
		int_11 = reader.method_0();
		switch (int_5)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
		{
			int_12 = reader.method_3();
			int_13 = new int[int_12];
			int num = 0;
			for (int i = 0; i < int_13.Length; i++)
			{
				ushort num2 = reader.method_3();
				int_13[i] = num2;
				if (num2 <= 32767)
				{
					num = Math.Max(num2, num);
				}
			}
			int num3 = num - 258 + 1;
			num3 = ((num3 >= 0) ? num3 : 0);
			list_0 = new List<string>(num3);
			for (int j = 0; j < num3; j++)
			{
				list_0.Add(smethod_0(reader));
			}
			break;
		}
		case 65536:
		case 196608:
			break;
		}
	}

	internal override void Write(Class5951 writer)
	{
		writer.method_0(int_5);
		writer.method_0(int_6);
		writer.method_3(short_0);
		writer.method_3(short_1);
		writer.method_0(int_7);
		writer.method_0(int_8);
		writer.method_0(int_9);
		writer.method_0(int_10);
		writer.method_0(int_11);
		switch (int_5)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
		{
			writer.method_3(int_12);
			int[] array = int_13;
			foreach (int value in array)
			{
				writer.method_3(value);
			}
			for (int j = 0; j < list_0.Count; j++)
			{
				smethod_1(list_0[j], writer);
			}
			break;
		}
		case 65536:
		case 196608:
			break;
		}
	}

	internal void method_1(Class5967 usedGlyphs)
	{
		int_8 = 0;
		int_9 = 0;
		int_10 = 0;
		int_11 = 0;
		switch (int_5)
		{
		default:
			throw new InvalidOperationException("Unexpected PostScript table version.");
		case 131072:
			method_2(usedGlyphs);
			break;
		case 65536:
		case 196608:
			break;
		}
	}

	private void method_2(Class5967 usedGlyphs)
	{
		int[] array = new int[usedGlyphs.Count];
		List<string> list = new List<string>();
		for (int i = 0; i < usedGlyphs.Count; i++)
		{
			int num = usedGlyphs.method_4(i);
			int num2 = (int)usedGlyphs.method_3(i);
			int num3 = int_13[num];
			if (num3 >= 258 && num3 <= 32767)
			{
				string value = list_0[num3 - 258];
				int num4 = ((IList)list).Add((object)value);
				array[num2] = (ushort)(num4 + 258);
			}
			else
			{
				array[num2] = (ushort)num3;
			}
		}
		int_12 = (ushort)usedGlyphs.Count;
		int_13 = array;
		list_0 = list;
	}

	private static string smethod_0(Class5950 reader)
	{
		int count = reader.ReadByte();
		byte[] bytes = reader.method_8(count);
		Encoding aSCII = Encoding.ASCII;
		return aSCII.GetString(bytes);
	}

	private static void smethod_1(string s, Class5951 writer)
	{
		if (s.Length > 255)
		{
			throw new InvalidOperationException("The PostScript glyph name is too long.");
		}
		Encoding aSCII = Encoding.ASCII;
		byte[] bytes = aSCII.GetBytes(s);
		writer.WriteByte((byte)bytes.Length);
		writer.method_4(bytes, 0, bytes.Length);
	}
}
