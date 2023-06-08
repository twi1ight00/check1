using System;
using System.Collections;
using ns2;
using ns22;
using ns59;

namespace ns27;

internal class Class709 : Class538
{
	private ArrayList arrayList_0;

	internal Class709()
	{
		method_2(430);
	}

	internal void method_4(Class1718 class1718_0, int int_0)
	{
		switch (class1718_0.Type)
		{
		case Enum194.const_0:
			method_7(class1718_0.method_16(), class1718_0.method_4());
			break;
		case Enum194.const_1:
			method_5((ushort)int_0);
			break;
		case Enum194.const_2:
			method_6();
			break;
		case Enum194.const_3:
		case Enum194.const_4:
			SetLink(class1718_0.method_16());
			break;
		}
	}

	internal void method_5(ushort ushort_0)
	{
		method_0(4);
		byte_0 = new byte[4];
		byte_0[0] = BitConverter.GetBytes(ushort_0)[0];
		byte_0[1] = BitConverter.GetBytes(ushort_0)[1];
		byte_0[2] = 1;
		byte_0[3] = 4;
	}

	internal void method_6()
	{
		method_0(4);
		byte_0 = new byte[4];
		byte_0[0] = 1;
		byte_0[2] = 1;
		byte_0[3] = 58;
	}

	[Attribute0(true)]
	internal void SetLink(string string_0)
	{
		byte[] array = Class1677.smethod_15(string_0);
		method_0((short)(5 + array.Length));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_0, 2, 2);
		byte_0[4] = (byte)((string_0.Length != array.Length) ? 1u : 0u);
		Array.Copy(array, 0, byte_0, 5, array.Length);
	}

	[Attribute0(true)]
	internal void method_7(string string_0, string[] string_1)
	{
		byte[] array = Class1677.smethod_15(string_0);
		method_0((short)(5 + array.Length));
		byte[][] array2 = new byte[string_1.Length][];
		int i = -1;
		for (int j = 0; j < string_1.Length; j++)
		{
			array2[j] = Class1677.smethod_15(string_1[j]);
			if (i == -1)
			{
				int num = 3 + ((array2[j] != null) ? array2[j].Length : 0);
				if (base.Length + num > 8224)
				{
					i = j;
				}
				else
				{
					method_0((short)(base.Length + (short)num));
				}
			}
		}
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((ushort)string_1.Length), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, 2, 2);
		byte_0[4] = (byte)((string_0.Length != array.Length) ? 1u : 0u);
		Array.Copy(array, 0, byte_0, 5, array.Length);
		int num2 = 5 + array.Length;
		int num3 = ((i == -1) ? string_1.Length : i);
		for (int k = 0; k < num3; k++)
		{
			Array.Copy(BitConverter.GetBytes((ushort)string_1[k].Length), 0, byte_0, num2, 2);
			if (array2[k] == null)
			{
				byte_0[num2 + 2] = 0;
				num2 += 3;
			}
			else
			{
				byte_0[num2 + 2] = (byte)((string_1[k].Length != array2[k].Length) ? 1u : 0u);
				Array.Copy(array2[k], 0, byte_0, num2 + 3, array2[k].Length);
				num2 += 3 + array2[k].Length;
			}
		}
		if (i == -1)
		{
			return;
		}
		int num4 = 0;
		arrayList_0 = new ArrayList();
		for (int l = i; l < string_1.Length; l++)
		{
			int num5 = 3 + ((array2[l] != null) ? array2[l].Length : 0);
			if (num4 + num5 > 8224)
			{
				byte[] array3 = new byte[num4];
				num2 = 0;
				for (; i < l; i++)
				{
					Array.Copy(BitConverter.GetBytes((ushort)string_1[i].Length), 0, array3, num2, 2);
					if (array2[i] == null)
					{
						array3[num2 + 2] = 0;
						num2 += 3;
					}
					else
					{
						array3[num2 + 2] = (byte)((string_1[i].Length != array2[i].Length) ? 1u : 0u);
						Array.Copy(array2[i], 0, array3, num2 + 3, array2[i].Length);
						num2 += 3 + array2[i].Length;
					}
				}
				Class619 @class = new Class619();
				@class.method_3(array3);
				arrayList_0.Add(@class);
				num4 = 0;
			}
			num4 += num5;
		}
		if (num4 == 0)
		{
			return;
		}
		num2 = 0;
		byte[] array4 = new byte[num4];
		for (; i < string_1.Length; i++)
		{
			Array.Copy(BitConverter.GetBytes((ushort)string_1[i].Length), 0, array4, num2, 2);
			if (string_1[i] == null)
			{
				array4[num2 + 2] = 0;
				num2 += 3;
			}
			else
			{
				array4[num2 + 2] = (byte)((string_1[i].Length != array2[i].Length) ? 1u : 0u);
				Array.Copy(array2[i], 0, array4, num2 + 3, array2[i].Length);
				num2 += 3 + array2[i].Length;
			}
		}
		Class619 class2 = new Class619();
		class2.method_3(array4);
		arrayList_0.Add(class2);
	}

	internal void method_8(Class1725 class1725_0)
	{
		byte[] array = null;
		array = new byte[byte_0.Length + 4];
		Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes(base.Length), 0, array, 2, 2);
		Array.Copy(byte_0, 0, array, 4, byte_0.Length);
		class1725_0.method_3(array);
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class619 @class = (Class619)arrayList_0[i];
				@class.vmethod_0(class1725_0);
			}
		}
	}
}
