using System;
using System.Collections;
using ns227;
using ns229;
using ns230;
using ns231;

namespace ns232;

internal class Class6132
{
	private static ArrayList arrayList_0 = smethod_0();

	private static ArrayList smethod_0()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(Class6116.int_30);
		arrayList.Add(Class6116.int_11);
		arrayList.Add(Class6116.int_9);
		arrayList.Add(Class6116.int_12);
		arrayList.Add(Class6116.int_26);
		arrayList.Add(Class6116.int_2);
		return arrayList;
	}

	public byte[] method_0(Class6020 sfntlyFont)
	{
		Class6130 @class = new Class6130();
		foreach (DictionaryEntry item in sfntlyFont.method_7())
		{
			int num = (int)item.Key;
			if (!arrayList_0.Contains(num))
			{
				@class.AddTable(num, ((Class6026)item.Value).method_0());
			}
		}
		Class6031 src = (Class6031)sfntlyFont.method_6(Class6116.int_2);
		@class.method_0().method_0(src);
		Class6123 class2 = new Class6123();
		class2.method_0(sfntlyFont);
		@class.method_1(Class6116.int_11, class2.method_8());
		@class.AddTable(Class6116.int_12, null);
		Class6039 class3 = (Class6039)sfntlyFont.method_6(Class6116.int_9);
		if (class3 != null)
		{
			Class6120 class4 = new Class6120();
			class4.method_0(class3);
			@class.method_1(Class6116.int_9, class4.method_1());
		}
		Class6032 class5 = (Class6032)sfntlyFont.method_6(Class6116.int_26);
		if (class5 != null)
		{
			@class.AddTable(Class6116.int_26, new Class6124().method_0(sfntlyFont));
		}
		byte[] block = @class.method_2();
		byte[] block2 = class2.method_9();
		byte[] block3 = class2.method_10();
		return smethod_2(block, block2, block3);
	}

	private static void smethod_1(byte[] data, int value, int off)
	{
		data[off] = (byte)((uint)(value >> 16) & 0xFFu);
		data[off + 1] = (byte)((uint)(value >> 8) & 0xFFu);
		data[off + 2] = (byte)((uint)value & 0xFFu);
	}

	private static byte[] smethod_2(byte[] block1, byte[] block2, byte[] block3)
	{
		int value = Math.Max(block1.Length, Math.Max(block2.Length, block3.Length)) + Class6127.smethod_2();
		byte[] array = Class6127.smethod_1(block1);
		byte[] array2 = Class6127.smethod_1(block2);
		byte[] array3 = Class6127.smethod_1(block3);
		int num = 10 + array.Length + array2.Length + array3.Length;
		byte[] array4 = new byte[num];
		array4[0] = 3;
		smethod_1(array4, value, 1);
		int num2 = 10 + array.Length;
		int num3 = num2 + array2.Length;
		smethod_1(array4, num2, 4);
		smethod_1(array4, num3, 7);
		Array.Copy(array, 0, array4, 10, array.Length);
		Array.Copy(array2, 0, array4, num2, array2.Length);
		Array.Copy(array3, 0, array4, num3, array3.Length);
		return array4;
	}
}
