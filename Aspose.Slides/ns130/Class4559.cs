using System;
using System.Collections;

namespace ns130;

internal class Class4559
{
	private byte[] byte_0;

	private byte[] byte_1;

	private byte[] byte_2;

	public Class4559(Class4583 font)
	{
		byte_0 = Class4597.smethod_0(font.byte_0);
		byte_1 = Class4597.smethod_0(font.byte_1);
		byte_2 = Class4597.smethod_0(font.byte_2);
	}

	public byte[] method_0()
	{
		Class4591 header = new Class4591(byte_0);
		Class4585[] tables = method_1(header);
		return method_2(tables);
	}

	private Class4585[] method_1(Class4591 header)
	{
		Class4589 @class = null;
		Class4586 class2 = null;
		Class4587 class3 = null;
		Class4590 class4 = null;
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		Class4585[] array = new Class4585[header.ushort_0];
		bool flag2 = false;
		Class4592[] class4592_ = header.class4592_0;
		foreach (Class4592 class5 in class4592_)
		{
			int uint_ = (int)class5.uint_2;
			byte[] array2 = new byte[uint_];
			Buffer.BlockCopy(byte_0, (int)class5.uint_1, array2, 0, array2.Length);
			if (class5.string_0 == Class4593.string_2)
			{
				class2 = (Class4586)(array[num5] = new Class4586(array2));
			}
			else if (class5.string_0 == Class4593.string_12)
			{
				num4 = num5;
			}
			else if (class5.string_0 == Class4593.string_9)
			{
				array[num5] = new Class4585(class5.string_0, Class4560.smethod_0(array2));
			}
			else if (class5.string_0 == Class4593.string_5)
			{
				@class = (Class4589)(array[num5] = new Class4589(array2));
			}
			else if (class5.string_0 == Class4593.string_26)
			{
				num = num5;
				flag = true;
			}
			else if (class5.string_0 == Class4593.string_3)
			{
				class3 = (Class4587)(array[num5] = new Class4587(array2));
			}
			else if (class5.string_0 == Class4593.string_4)
			{
				num2 = num5;
			}
			else if (class5.string_0 == Class4593.string_11)
			{
				flag2 = true;
				num3 = num5;
			}
			else if (class5.string_0 == Class4593.string_30)
			{
				array[num5] = new Class4585(class5.string_0, Class4570.smethod_0(array2));
			}
			else if (class5.string_0 == Class4593.string_7)
			{
				class4 = (Class4590)(array[num5] = new Class4590(array2));
			}
			if (array[num5] == null)
			{
				array[num5] = new Class4585(class5.string_0, array2);
			}
			num5++;
		}
		array[num2] = new Class4588(class3.ushort_0, array[num2].byte_0);
		if (flag)
		{
			array[num] = new Class4585(Class4593.string_26, Class4568.smethod_0((Class4588)array[num2], array[num].byte_0, @class.ushort_2, class2.ushort_0));
		}
		class2.HasNonLinearScaling = flag;
		if (flag2)
		{
			Class4561 class6 = new Class4561(array[num3].byte_0, byte_1, byte_2);
			Class4561.Class4562 class7 = class6.method_0(@class.ushort_2, (Class4588)array[num2]);
			array[num4] = new Class4585(Class4593.string_12, class7.byte_1);
			array[num3] = new Class4585(Class4593.string_11, class7.byte_0);
			class2.IndexToLocFormat = (short)(class7.bool_0 ? 1 : 0);
			class2.XMax = class7.short_0;
			class2.YMax = class7.short_1;
			class2.XMin = class7.short_2;
			class2.YMin = class7.short_3;
			@class.MaxComponentElements = class7.ushort_1;
			@class.MaxSizeOfInstructions = class7.ushort_0;
			class3.AdvanceWidthMax = class7.ushort_2;
			class3.MinLeftSideBearing = class7.short_4;
			class3.MinRightSideBearing = class7.short_5;
			class3.XMaxExtent = class7.short_6;
			if (class3.Ascender > class7.short_1)
			{
				class3.Ascender = class7.short_1;
			}
			if (class3.Descender < class7.short_3)
			{
				class3.Descender = class7.short_3;
			}
		}
		if (class4.STypoDescender > 0)
		{
			class4.STypoDescender = class2.YMin;
		}
		return smethod_0(array);
	}

	private static Class4585[] smethod_0(Class4585[] tables)
	{
		string[] array = new string[18]
		{
			Class4593.string_2,
			Class4593.string_3,
			Class4593.string_5,
			Class4593.string_7,
			Class4593.string_4,
			Class4593.string_28,
			Class4593.string_30,
			Class4593.string_26,
			Class4593.string_1,
			Class4593.string_10,
			Class4593.string_13,
			Class4593.string_9,
			Class4593.string_12,
			Class4593.string_11,
			Class4593.string_27,
			Class4593.string_6,
			Class4593.string_8,
			Class4593.string_25
		};
		Class4585[] array2 = new Class4585[tables.Length];
		int num = 0;
		foreach (string text in array)
		{
			for (int j = 0; j < tables.Length; j++)
			{
				if (tables[j].class4592_0.string_0 == text)
				{
					array2[num] = tables[j];
					num++;
					break;
				}
			}
		}
		for (int k = 0; k < tables.Length; k++)
		{
			string string_ = tables[k].class4592_0.string_0;
			bool flag = false;
			for (int l = 0; l < num; l++)
			{
				if (string_ == array2[l].class4592_0.string_0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array2[num] = tables[k];
				num++;
			}
		}
		return array2;
	}

	private byte[] method_2(Class4585[] tables)
	{
		int num = 12 + 16 * tables.Length;
		foreach (Class4585 @class in tables)
		{
			num += (int)((@class.class4592_0.uint_2 + 4 - 1) & -4L);
		}
		byte[] array = new byte[num];
		int num2 = 12 + 16 * tables.Length;
		Class4572 class2 = new Class4572(array);
		foreach (Class4585 class3 in tables)
		{
			class3.class4592_0.uint_1 = (uint)num2;
			class2.Position = num2;
			Buffer.BlockCopy(class3.byte_0, 0, array, num2, class3.byte_0.Length);
			class3.class4592_0.uint_0 = smethod_1(class2, (int)class3.class4592_0.uint_2);
			num2 += (int)((class3.class4592_0.uint_2 + 4 - 1) & -4L);
		}
		ushort num3 = (ushort)(Math.Log10(tables.Length) / Math.Log10(2.0));
		ushort num4 = (ushort)Math.Pow(2.0, (int)num3);
		Class4573 class4 = new Class4573(array);
		class4.Write(65536);
		class4.method_0((ushort)tables.Length);
		class4.method_0((ushort)(num4 * 16));
		class4.method_0(num3);
		class4.method_0((ushort)((tables.Length - num4) * 16));
		Class4586 class5 = null;
		SortedList sortedList = new SortedList();
		foreach (Class4585 class6 in tables)
		{
			sortedList.Add(Class4593.smethod_0(class6.class4592_0.string_0), class6);
		}
		foreach (uint key in sortedList.Keys)
		{
			Class4585 class7 = (Class4585)sortedList[key];
			class4.Write(Class4593.smethod_0(class7.class4592_0.string_0));
			class4.Write(class7.class4592_0.uint_0);
			class4.Write(class7.class4592_0.uint_1);
			class4.Write(class7.class4592_0.uint_2);
			if (class7.class4592_0.string_0 == Class4593.string_2)
			{
				class5 = (Class4586)class7;
			}
		}
		class4.Position = (int)(class5.class4592_0.uint_1 + 8);
		class2.Position = 0;
		class4.Write(2981146554u - smethod_1(class2, class2.InputLength));
		return array;
	}

	private static uint smethod_1(Class4572 reader, int length)
	{
		uint num = 0u;
		for (int i = 0; i < length; i += 4)
		{
			num += reader.method_1();
		}
		return num;
	}
}
