using System;
using ns33;
using ns4;

namespace ns62;

internal class Class2619
{
	private class Class2620
	{
		internal char[] char_0;

		internal int int_0;

		internal short short_0;

		internal short short_1;

		internal int int_1;

		internal int method_0()
		{
			return ((char_0 != null) ? char_0.Length : 0) + 12;
		}

		internal void method_1(byte[] bmpBytes, int offset)
		{
			if (bmpBytes.Length >= method_0() + offset)
			{
				for (int i = 0; i < char_0.Length; i++)
				{
					bmpBytes[offset++] = (byte)char_0[i];
				}
				Class1162.smethod_16(bmpBytes, offset, int_0);
				Class1162.smethod_12(bmpBytes, offset + 4, short_0);
				Class1162.smethod_12(bmpBytes, offset + 6, short_1);
				Class1162.smethod_16(bmpBytes, offset + 8, int_1);
			}
		}
	}

	private class Class2621
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal short short_0;

		internal short short_1;

		internal int int_3;

		internal int int_4;

		internal int int_5;

		internal int int_6;

		internal int int_7;

		internal int int_8;

		internal Class2621(byte[] dibBytes, int offset)
		{
			int_0 = Class1162.smethod_6(dibBytes, offset);
			int_1 = Class1162.smethod_6(dibBytes, offset + 4);
			int_2 = Class1162.smethod_6(dibBytes, offset + 8);
			short_0 = Class1162.smethod_0(dibBytes, offset + 12);
			short_1 = Class1162.smethod_0(dibBytes, offset + 14);
			int_3 = Class1162.smethod_6(dibBytes, offset + 16);
			int_4 = Class1162.smethod_6(dibBytes, offset + 20);
			int_5 = Class1162.smethod_6(dibBytes, offset + 24);
			int_6 = Class1162.smethod_6(dibBytes, offset + 28);
			int_7 = Class1162.smethod_6(dibBytes, offset + 32);
			int_8 = Class1162.smethod_6(dibBytes, offset + 36);
		}
	}

	internal static byte[] smethod_0(byte[] dib)
	{
		try
		{
			Class2621 @class = new Class2621(dib, 0);
			if (@class.int_4 == 0)
			{
				@class.int_4 = (((@class.int_1 * @class.short_1 + 31) & -32) >> 3) * Math.Abs(@class.int_2);
			}
			if (@class.int_7 == 0 && @class.short_1 < 16)
			{
				@class.int_7 = 1 << (int)@class.short_1;
			}
			Class2620 class2 = new Class2620();
			int num = @class.int_0 + @class.int_7 * 4 + @class.int_4;
			class2.char_0 = new char[2] { 'B', 'M' };
			class2.int_0 = 14 + num;
			class2.int_1 = 14 + @class.int_0 + @class.int_7 * 4;
			byte[] array = new byte[class2.int_0];
			class2.method_1(array, 0);
			Array.Copy(dib, 0, array, 14, num);
			return array;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return null;
		}
	}
}
