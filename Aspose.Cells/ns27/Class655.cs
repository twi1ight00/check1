using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns52;
using ns59;

namespace ns27;

internal class Class655 : Class538
{
	private short short_2;

	private ArrayList arrayList_0;

	private WorksheetCollection worksheetCollection_0;

	private Class1703 class1703_0;

	private int int_0;

	private byte[] byte_1;

	private int int_1;

	internal ArrayList arrayList_1;

	internal Class655(WorksheetCollection worksheetCollection_1, int int_2)
	{
		method_2(235);
		worksheetCollection_0 = worksheetCollection_1;
		short_2 = (short)(8224 - int_2);
	}

	[SpecialName]
	internal ArrayList method_4()
	{
		return arrayList_0;
	}

	internal void method_5(Class1703 class1703_1)
	{
		class1703_0 = class1703_1;
		int length = (int)class1703_1.Length;
		int_0 = length + 8;
		int_1 = 0;
		if (length + 8 > short_2)
		{
			method_0(short_2);
			arrayList_0 = new ArrayList();
			int_0 -= base.Length;
		}
		else
		{
			method_0((short)(length + 8));
			int_0 = 0;
		}
		byte_0 = new byte[base.Length];
		byte_1 = byte_0;
		byte_1[int_1] = 15;
		byte_1[int_1 + 2] = 0;
		byte_1[int_1 + 3] = 240;
		Array.Copy(BitConverter.GetBytes(length), 0, byte_1, int_1 + 4, 4);
		int_1 += 8;
		method_8(class1703_1.method_2());
		method_6();
		ArrayList arrayList = class1703_0.method_5();
		if (arrayList != null && arrayList.Count != 0)
		{
			foreach (byte[] item in arrayList)
			{
				method_7(item);
			}
		}
		else
		{
			byte[] byte_2 = new byte[50]
			{
				51, 0, 11, 240, 18, 0, 0, 0, 191, 0,
				8, 0, 8, 0, 129, 1, 9, 0, 0, 8,
				192, 1, 64, 0, 0, 8, 64, 0, 30, 241,
				16, 0, 0, 0, 13, 0, 0, 8, 12, 0,
				0, 8, 23, 0, 0, 8, 247, 0, 0, 16
			};
			method_7(byte_2);
		}
		byte_1 = null;
	}

	internal void method_6()
	{
		Class1697 @class = class1703_0.method_1();
		if (@class == null || @class.Count == 0)
		{
			return;
		}
		byte[] array = new byte[8];
		ushort num = 15;
		num = (ushort)(0xFu | (ushort)(@class.Count << 4));
		Array.Copy(BitConverter.GetBytes(num), 0, array, 0, 2);
		array[2] = 1;
		array[3] = 240;
		Array.Copy(BitConverter.GetBytes(@class.Length), 0, array, 4, 4);
		method_7(array);
		foreach (Class1696 item in @class)
		{
			array = new byte[item.method_1() + 8];
			item.SetHeader(array);
			method_7(array);
			if (item.method_4().method_6() != null)
			{
				method_7(item.method_4().method_6());
			}
		}
	}

	internal void method_7(byte[] byte_2)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		while (true)
		{
			num2 = byte_2.Length - num;
			if (num2 <= byte_1.Length - int_1)
			{
				flag = false;
			}
			else
			{
				num2 = byte_1.Length - int_1;
				flag = true;
			}
			Array.Copy(byte_2, num, byte_1, int_1, num2);
			num += num2;
			if (!flag)
			{
				break;
			}
			int_1 = byte_1.Length;
			method_9();
		}
		int_1 += num2;
		if (int_1 == byte_1.Length)
		{
			method_9();
		}
	}

	internal void method_8(Class1702 class1702_0)
	{
		byte_1[int_1 + 2] = 6;
		byte_1[int_1 + 3] = 240;
		Array.Copy(BitConverter.GetBytes(class1702_0.Length), 0, byte_1, int_1 + 4, 4);
		int_1 += 8;
		Array.Copy(BitConverter.GetBytes(class1702_0.method_0().int_0), 0, byte_1, int_1, 4);
		int_1 += 4;
		Array.Copy(BitConverter.GetBytes(class1702_0.method_1().Count + 1), 0, byte_1, int_1, 4);
		int_1 += 4;
		Array.Copy(BitConverter.GetBytes(class1702_0.method_0().int_1), 0, byte_1, int_1, 4);
		int_1 += 4;
		Array.Copy(BitConverter.GetBytes(class1702_0.method_0().int_2), 0, byte_1, int_1, 4);
		int_1 += 4;
		foreach (Class1706 item in class1702_0.method_1())
		{
			Array.Copy(BitConverter.GetBytes(item.int_0), 0, byte_1, int_1, 4);
			Array.Copy(BitConverter.GetBytes(item.int_1), 0, byte_1, int_1 + 4, 4);
			int_1 += 8;
			if (int_1 == byte_1.Length || int_1 + 8 > byte_1.Length)
			{
				method_9();
			}
		}
	}

	internal void method_9()
	{
		if (int_1 < byte_1.Length)
		{
			int_0 += byte_1.Length - int_1;
		}
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(int_1);
		if (int_0 != 0)
		{
			if (int_0 <= short_2)
			{
				byte_1 = new byte[int_0];
				int_0 = 0;
			}
			else
			{
				byte_1 = new byte[short_2];
				int_0 -= short_2;
			}
			arrayList_0.Add(byte_1);
			int_1 = 0;
		}
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		int num = ((arrayList_1 == null) ? base.Length : ((int)arrayList_1[0]));
		class1725_0.method_7(method_1());
		class1725_0.method_7((short)num);
		class1725_0.method_3(byte_0);
		if (arrayList_0 == null)
		{
			return;
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			byte[] array = (byte[])arrayList_0[i];
			if (i + 1 < arrayList_1.Count)
			{
				num = (int)arrayList_1[i + 1];
			}
			else
			{
				num = array.Length;
			}
			class1725_0.method_8(60);
			class1725_0.method_7((short)array.Length);
			class1725_0.method_3(array);
		}
	}
}
