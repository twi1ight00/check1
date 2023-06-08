using System.IO;
using ns226;
using ns227;
using ns230;

namespace ns232;

internal class Class6122
{
	private bool bool_0;

	private Class6022 class6022_0 = Class6022.smethod_0();

	private static long long_0 = 0L;

	private static short short_0 = 0;

	private static long long_1 = 131074L;

	private static short short_1 = 20556;

	private static long long_2 = 0L;

	private static long long_3 = 4L;

	private static byte byte_0 = 1;

	private static long long_4 = 1346851650L;

	public Class6122()
	{
		bool_0 = false;
	}

	public Class6122(bool compressed)
	{
		bool_0 = compressed;
	}

	public Class6017 method_0(Class6020 font, out Class6121 prefix)
	{
		prefix = new Class6121();
		StreamWriter streamWriter = new StreamWriter(new MemoryStream());
		streamWriter.AutoFlush = true;
		class6022_0.method_14(font, streamWriter);
		byte[] array = ((MemoryStream)streamWriter.BaseStream).ToArray();
		Class6029 @class = (Class6029)font.method_6(Class6116.int_6);
		byte[] array2 = smethod_7(@class.method_22(3, 1, 1033, 1));
		byte[] array3 = smethod_7(@class.method_22(3, 1, 1033, 2));
		byte[] array4 = smethod_7(@class.method_22(3, 1, 1033, 5));
		byte[] array5 = smethod_7(@class.method_22(3, 1, 1033, 4));
		long num = long_2;
		if (bool_0)
		{
			num |= long_3;
			Class6132 class2 = new Class6132();
			array = class2.method_0(font);
		}
		long num2 = smethod_0(array2.Length, array3.Length, array4.Length, array5.Length, array.Length);
		Class6017 class3 = smethod_8((int)num2);
		Class6036 class4 = (Class6036)font.method_6(Class6116.int_7);
		int num3 = 0;
		num3 = 0 + class3.method_42(0, num2);
		prefix.uint_0 = (uint)num2;
		num3 += class3.method_42(num3, array.Length);
		prefix.uint_1 = (uint)array.Length;
		num3 += class3.method_42(num3, long_1);
		prefix.uint_2 = (uint)long_1;
		num3 += class3.method_42(num3, num);
		prefix.uint_3 = (uint)num;
		num3 += smethod_1(num3, class4, class3);
		prefix.byte_0 = class4.method_29();
		num3 += class3.WriteByte(num3, byte_0);
		prefix.byte_1 = byte_0;
		num3 += class3.WriteByte(num3, (byte)((uint)class4.method_36() & 1u));
		prefix.byte_2 = (byte)((uint)class4.method_36() & 1u);
		num3 += class3.method_42(num3, class4.method_14());
		prefix.uint_4 = (uint)class4.method_14();
		num3 += class3.method_38(num3, (short)class4.method_17());
		prefix.ushort_0 = (ushort)class4.method_17();
		num3 += class3.method_38(num3, short_1);
		num3 += smethod_3(num3, class4, class3);
		prefix.uint_5 = new uint[4]
		{
			(uint)class4.method_30(),
			(uint)class4.method_31(),
			(uint)class4.method_32(),
			(uint)class4.method_33()
		};
		num3 += smethod_4(num3, class4, class3);
		prefix.uint_6 = new uint[2]
		{
			(uint)class4.method_45(),
			(uint)class4.method_46()
		};
		Class6031 class5 = (Class6031)font.method_6(Class6116.int_2);
		num3 += class3.method_42(num3, class5.method_14());
		prefix.uint_7 = (uint)class5.method_14();
		num3 += smethod_2(num3, class3);
		num3 += smethod_5(num3, class3);
		prefix.ushort_2 = (ushort)short_0;
		num3 += smethod_6(num3, array2, class3);
		prefix.ushort_3 = (ushort)array2.Length;
		prefix.byte_3 = array2;
		num3 += smethod_5(num3, class3);
		prefix.ushort_4 = (ushort)short_0;
		num3 += smethod_6(num3, array3, class3);
		prefix.ushort_5 = (ushort)array3.Length;
		prefix.byte_4 = array3;
		num3 += smethod_5(num3, class3);
		prefix.ushort_6 = (ushort)short_0;
		num3 += smethod_6(num3, array4, class3);
		prefix.ushort_7 = (ushort)array4.Length;
		prefix.byte_5 = array4;
		num3 += smethod_5(num3, class3);
		prefix.ushort_8 = (ushort)short_0;
		num3 += smethod_6(num3, array5, class3);
		prefix.ushort_9 = (ushort)array5.Length;
		prefix.byte_6 = array5;
		num3 += smethod_5(num3, class3);
		prefix.ushort_10 = (ushort)short_0;
		num3 += smethod_5(num3, class3);
		prefix.ushort_11 = (ushort)short_0;
		if (long_1 > 131073L)
		{
			num3 += class3.method_42(num3, long_4);
			num3 += class3.method_42(num3, 0L);
			num3 += smethod_5(num3, class3);
			num3 += smethod_5(num3, class3);
			num3 += class3.method_42(num3, 0L);
			num3 += class3.method_42(num3, 0L);
		}
		class3.method_31(num3, array, 0, array.Length);
		return class3;
	}

	private static long smethod_0(int familyNameSize, int styleNameSize, int versionNameSize, int fullNameSize, int fontDataSize)
	{
		return 100 + familyNameSize + styleNameSize + versionNameSize + fullNameSize + fontDataSize + ((long_1 > 131073L) ? 20 : 0);
	}

	private static int smethod_1(int index, Class6036 os2Table, Class6017 writableFontData)
	{
		byte[] array = os2Table.method_29();
		return writableFontData.method_31(index, array, 0, array.Length);
	}

	private static int smethod_2(int start, Class6017 writableFontData)
	{
		int num = start;
		for (int i = 0; i < 4; i++)
		{
			num += writableFontData.method_42(num, long_0);
		}
		return num - start;
	}

	private static int smethod_3(int start, Class6036 os2Table, Class6017 writableFontData)
	{
		int num = start;
		num += writableFontData.method_42(num, os2Table.method_30());
		num += writableFontData.method_42(num, os2Table.method_31());
		num += writableFontData.method_42(num, os2Table.method_32());
		num += writableFontData.method_42(num, os2Table.method_33());
		return num - start;
	}

	private static int smethod_4(int start, Class6036 os2Table, Class6017 writableFontData)
	{
		int num = start;
		num += writableFontData.method_42(num, os2Table.method_45());
		num += writableFontData.method_42(num, os2Table.method_46());
		return num - start;
	}

	private static int smethod_5(int index, Class6017 writableFontData)
	{
		return writableFontData.method_38(index, short_0);
	}

	private static int smethod_6(int start, byte[] str, Class6017 writableFontData)
	{
		int num = start;
		num += writableFontData.method_38(num, (short)str.Length);
		num += writableFontData.method_31(num, str, 0, str.Length);
		return num - start;
	}

	private static byte[] smethod_7(byte[] bytesString)
	{
		if (bytesString == null)
		{
			return new byte[0];
		}
		for (int i = 0; i < bytesString.Length; i += 2)
		{
			byte b = bytesString[i];
			bytesString[i] = bytesString[i + 1];
			bytesString[i + 1] = b;
		}
		return bytesString;
	}

	private static Class6017 smethod_8(int length)
	{
		return Class6017.smethod_1(length);
	}
}
