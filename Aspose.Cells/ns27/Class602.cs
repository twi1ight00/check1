using System;
using System.Collections;
using System.Drawing;
using System.IO;
using ns59;

namespace ns27;

internal class Class602 : Class538
{
	private ArrayList arrayList_0;

	internal Class602()
	{
		method_2(233);
	}

	internal static byte[] smethod_0(int int_0, ushort ushort_0, ushort ushort_1)
	{
		byte[] array = new byte[20]
		{
			9, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0
		};
		Array.Copy(BitConverter.GetBytes(int_0), 0, array, 4, 4);
		array[8] = 12;
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, array, 12, 2);
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, array, 12 + 2, 2);
		array[16] = 1;
		array[16 + 2] = 24;
		return array;
	}

	internal void method_4(byte[] byte_1)
	{
		MemoryStream stream = new MemoryStream(byte_1);
		Bitmap bitmap = new Bitmap(Image.FromStream(stream));
		ushort num = (ushort)bitmap.Width;
		ushort num2 = (ushort)bitmap.Height;
		int num3 = num * 3;
		int num4 = num3 % 4;
		if (num4 != 0)
		{
			num4 = 4 - num4;
			num3 += num4;
		}
		int num5 = num3 * num2 + 12;
		int num6 = 8212;
		int num7 = 20;
		if (num5 < 8212)
		{
			byte_0 = new byte[num5 + 8];
			method_0((short)byte_0.Length);
			Array.Copy(smethod_0(num5, num, num2), 0, byte_0, 0, 20);
			for (int num8 = num2 - 1; num8 >= 0; num8--)
			{
				for (int i = 0; i < num; i++)
				{
					Color color = bitmap.GetPixel(i, num8);
					if (color.ToArgb() == 0)
					{
						color = Color.White;
					}
					byte_0[num7++] = color.B;
					byte_0[num7++] = color.G;
					byte_0[num7++] = color.R;
				}
				if (num4 != 0)
				{
					for (int j = 0; j < num4; j++)
					{
						byte_0[num7++] = 0;
					}
				}
			}
			return;
		}
		byte_0 = smethod_0(num5, num, num2);
		method_0(20);
		arrayList_0 = new ArrayList();
		byte[] array = new byte[num6 - 12];
		num5 -= 12;
		num7 = 0;
		for (int num9 = num2 - 1; num9 >= 0; num9--)
		{
			for (int k = 0; k < num; k++)
			{
				Color color = bitmap.GetPixel(k, num9);
				if (color.ToArgb() == 0)
				{
					color = Color.White;
				}
				array[num7++] = color.B;
				if (num7 == array.Length)
				{
					arrayList_0.Add(array);
					num5 -= array.Length;
					array = new byte[(num5 > num6) ? num6 : num5];
					num7 = 0;
				}
				array[num7++] = color.G;
				if (num7 == array.Length)
				{
					arrayList_0.Add(array);
					num5 -= array.Length;
					array = new byte[(num5 > num6) ? num6 : num5];
					num7 = 0;
				}
				array[num7++] = color.R;
				if (num7 == array.Length)
				{
					arrayList_0.Add(array);
					num5 -= array.Length;
					array = new byte[(num5 > num6) ? num6 : num5];
					num7 = 0;
				}
			}
			if (num4 != 0)
			{
				for (int l = 0; l < num4; l++)
				{
					array[num7++] = 0;
					if (num7 == array.Length)
					{
						arrayList_0.Add(array);
						num5 -= array.Length;
						array = new byte[(num5 > num6) ? num6 : num5];
						num7 = 0;
					}
				}
			}
		}
		arrayList_0.Add(array);
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		class1725_0.method_7(method_1());
		if (arrayList_0 == null)
		{
			class1725_0.method_7(base.Length);
			class1725_0.method_3(byte_0);
			return;
		}
		byte[] array = (byte[])arrayList_0[0];
		class1725_0.method_7((short)(base.Length + array.Length));
		class1725_0.method_3(byte_0);
		class1725_0.method_3(array);
		for (int i = 1; i < arrayList_0.Count; i++)
		{
			class1725_0.method_7(60);
			array = (byte[])arrayList_0[i];
			class1725_0.method_7((short)array.Length);
			class1725_0.method_3(array);
		}
	}
}
