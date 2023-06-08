using System;
using System.Collections;
using ns59;

namespace ns27;

internal class Class633 : Class538
{
	private short short_2;

	internal Class633()
	{
		method_2(255);
		short_2 = 8;
	}

	internal void method_4(Class1725 class1725_0, ArrayList arrayList_0)
	{
		int num = arrayList_0.Count * 8 + 2;
		int num2 = 0;
		if (num <= 8224)
		{
			byte_0 = new byte[num];
			byte_0[0] = (byte)short_2;
			num2 = 2;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Struct92 @struct = (Struct92)arrayList_0[i];
				Array.Copy(BitConverter.GetBytes(@struct.uint_0), 0, byte_0, num2, 4);
				Array.Copy(BitConverter.GetBytes(@struct.ushort_0), 0, byte_0, num2 + 4, 2);
				num2 += 8;
			}
			class1725_0.method_7(method_1());
			class1725_0.method_6((ushort)num);
			class1725_0.method_1(byte_0, byte_0.Length);
			return;
		}
		int num3 = 8222 / short_2;
		num = num3 * short_2;
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			if (j == 0)
			{
				byte_0 = new byte[num];
				byte_0[0] = (byte)short_2;
				num2 = 2;
			}
			else if (j % num3 == 0)
			{
				class1725_0.method_7(method_1());
				class1725_0.method_6((ushort)byte_0.Length);
				class1725_0.method_1(byte_0, byte_0.Length);
				int num4 = 2 + short_2 * (arrayList_0.Count - j);
				if (num4 <= 8224)
				{
					byte_0 = new byte[num4];
				}
				else
				{
					byte_0 = new byte[num];
				}
				byte_0[0] = (byte)short_2;
				num2 = 2;
			}
			Struct92 struct2 = (Struct92)arrayList_0[j];
			Array.Copy(BitConverter.GetBytes(struct2.uint_0), 0, byte_0, num2, 4);
			Array.Copy(BitConverter.GetBytes(struct2.ushort_0), 0, byte_0, num2 + 4, 2);
			num2 += 8;
		}
		if (num2 != 2)
		{
			class1725_0.method_7(method_1());
			class1725_0.method_6((ushort)byte_0.Length);
			class1725_0.method_1(byte_0, byte_0.Length);
		}
	}
}
