using System;
using System.Collections;
using ns27;
using ns59;

namespace ns28;

internal class Class567 : Class538
{
	private ArrayList arrayList_0;

	internal Class567()
	{
		method_2(181);
	}

	internal void method_4(ArrayList arrayList_1)
	{
		arrayList_0 = null;
		if (arrayList_1 != null && arrayList_1.Count != 0)
		{
			int[] array = (int[])arrayList_1[0];
			int num = array.Length * 2;
			int num2 = 8224 / num;
			int num3 = 8224 % num;
			int num4 = 0;
			if (num2 >= arrayList_1.Count)
			{
				method_0((short)(num * arrayList_1.Count));
				byte_0 = new byte[base.Length];
				{
					foreach (int[] item in arrayList_1)
					{
						smethod_0(item, byte_0, num4);
						num4 += num;
					}
					return;
				}
			}
			if (num3 == 0)
			{
				arrayList_0 = new ArrayList();
				byte[] byte_ = null;
				for (int i = 0; i < arrayList_1.Count; i++)
				{
					if (i == 0)
					{
						method_0((short)(num2 * num));
						byte_0 = new byte[base.Length];
						byte_ = byte_0;
					}
					else if (i % num2 == 0)
					{
						Class619 @class = new Class619();
						int num5 = arrayList_1.Count - i;
						int num6 = ((num5 > num2) ? num2 : num5) * num;
						byte_ = new byte[num6];
						@class.method_3(byte_);
						arrayList_0.Add(@class);
						num4 = 0;
					}
					smethod_0((int[])arrayList_1[i], byte_, num4);
					num4 += num;
				}
				return;
			}
			arrayList_0 = new ArrayList();
			byte[] array2 = null;
			int j = 0;
			for (int k = 0; k < arrayList_1.Count; k++, j++)
			{
				if (k == 0)
				{
					method_0(8224);
					byte_0 = new byte[base.Length];
					array2 = byte_0;
				}
				else if (j == num2)
				{
					int[] array3 = (int[])arrayList_1[k];
					int l;
					for (l = 0; l < num3 / 2; l++)
					{
						Array.Copy(BitConverter.GetBytes((ushort)array3[l]), 0, array2, num4, 2);
						num4 += 2;
					}
					Class619 class2 = new Class619();
					int num7 = num - num3;
					j = -1;
					num2 = (8224 - num7) / num;
					num3 = (8224 - num7) % num;
					int num8 = arrayList_1.Count - k - 1;
					int num9 = ((num8 > num2) ? 8224 : (num8 * num + num7));
					array2 = new byte[num9];
					class2.method_3(array2);
					arrayList_0.Add(class2);
					num4 = 0;
					for (; l < array3.Length; l++)
					{
						Array.Copy(BitConverter.GetBytes((ushort)array3[l]), 0, array2, num4, 2);
						num4 += 2;
					}
					continue;
				}
				smethod_0((int[])arrayList_1[k], array2, num4);
				num4 += num;
			}
		}
		else
		{
			method_0(8);
			byte_0 = new byte[base.Length];
		}
	}

	internal static void smethod_0(int[] int_0, byte[] byte_1, int int_1)
	{
		for (int i = 0; i < int_0.Length; i++)
		{
			if (int_0[i] != 0)
			{
				Array.Copy(BitConverter.GetBytes((ushort)int_0[i]), 0, byte_1, int_1, 2);
			}
			int_1 += 2;
		}
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		base.vmethod_0(class1725_0);
		if (arrayList_0 == null)
		{
			return;
		}
		foreach (Class619 item in arrayList_0)
		{
			item.vmethod_0(class1725_0);
		}
	}
}
