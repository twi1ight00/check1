using System;
using System.Collections;
using Aspose.Cells.Drawing;
using ns21;
using ns52;
using ns59;

namespace ns27;

internal class Class656 : Class538
{
	internal int int_0;

	internal Class656()
	{
		method_2(236);
	}

	internal void method_4(byte[] byte_1, int int_1, int int_2)
	{
		int_0 = int_2;
		byte_0 = new byte[int_0];
		Array.Copy(byte_1, int_1, byte_0, 0, int_2);
	}

	internal void method_5()
	{
		int_0 = 8;
		byte_0 = new byte[8];
		byte_0[2] = 13;
		byte_0[3] = 240;
	}

	internal void method_6(ShapeCollection shapeCollection_0)
	{
		Class1701 @class = shapeCollection_0.method_4();
		int num = @class.method_5();
		int num2 = 48;
		for (int i = 0; i < shapeCollection_0.Count; i++)
		{
			num2 += 48 + shapeCollection_0[i].method_27().method_2().Length;
		}
		int num3 = num + num2;
		if (@class.method_7() != null && @class.method_6().byte_0 != null)
		{
			num3 += @class.method_6().byte_0.Length;
		}
		int_0 = num3 + 8;
		byte_0 = new byte[int_0];
		int num4 = @class.SetHeader(byte_0, 0, num3, num2);
		foreach (Shape item in shapeCollection_0)
		{
			Picture picture = (Picture)item;
			byte_0[num4] = 15;
			byte_0[num4 + 2] = 4;
			byte_0[num4 + 3] = 240;
			Array.Copy(BitConverter.GetBytes(40 + picture.method_27().method_2().Length), 0, byte_0, num4 + 4, 4);
			num4 += 8;
			byte_0[num4] = 178;
			byte_0[num4 + 1] = 4;
			byte_0[num4 + 2] = 10;
			byte_0[num4 + 3] = 240;
			byte_0[num4 + 4] = 8;
			num4 += 8;
			Array.Copy(BitConverter.GetBytes(picture.method_27().method_9().method_2()), 0, byte_0, num4, 4);
			Array.Copy(BitConverter.GetBytes(picture.method_27().method_9().method_4()), 0, byte_0, num4 + 4, 4);
			num4 += 8;
			num4 += picture.method_27().method_2().method_11(item, byte_0, num4, bool_0: false);
			byte_0[num4 + 2] = 16;
			byte_0[num4 + 3] = 240;
			byte_0[num4 + 4] = 8;
			num4 += 8;
			Array.Copy(BitConverter.GetBytes(picture.Width), 0, byte_0, num4, 4);
			Array.Copy(BitConverter.GetBytes(picture.Height), 0, byte_0, num4 + 4, 4);
			num4 += 8;
		}
		if (@class.method_7() != null && @class.method_6().byte_0 != null)
		{
			Array.Copy(@class.method_6().byte_0, 0, byte_0, num4, @class.method_6().byte_0.Length);
		}
	}

	internal int method_7(ShapeCollection shapeCollection_0, Shape shape_0)
	{
		Class1701 @class = shapeCollection_0.method_4();
		int num = @class.method_5();
		int_0 = num + 8 + 48;
		if (shapeCollection_0.Count != 0)
		{
			int_0 += shape_0.Length;
			if (shape_0.method_11())
			{
				int_0 -= 8;
			}
		}
		byte_0 = new byte[int_0];
		int num2 = 0;
		int num3 = (int)@class.method_4();
		int num4 = num + num3;
		if (@class.method_7() != null && @class.method_6().byte_0 != null)
		{
			num4 += @class.method_6().byte_0.Length;
		}
		return @class.SetHeader(byte_0, num2, num4, num3);
	}

	internal void method_8(int int_1, Shape shape_0)
	{
		byte[] array = new byte[90]
		{
			15, 0, 4, 240, 82, 0, 0, 0, 146, 12,
			10, 240, 8, 0, 0, 0, 5, 8, 0, 0,
			0, 10, 0, 0, 67, 0, 11, 240, 24, 0,
			0, 0, 127, 0, 4, 1, 4, 1, 191, 0,
			8, 0, 8, 0, 255, 1, 0, 0, 8, 0,
			191, 3, 0, 0, 2, 0, 0, 0, 16, 240,
			18, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 17, 240, 0, 0, 0, 0
		};
		Array.Copy(BitConverter.GetBytes(shape_0.method_27().method_9().method_2()), 0, array, 16, 4);
		if (int_1 == 0)
		{
			int_0 = array.Length;
			byte_0 = array;
		}
		else
		{
			Array.Copy(array, 0, byte_0, int_1, array.Length);
		}
	}

	internal void method_9(Shape shape_0, int int_1, ushort ushort_0, int int_2, int int_3)
	{
		if (int_1 != 0)
		{
			method_8(int_1, shape_0);
		}
		else if (int_0 <= 90 && byte_0 != null)
		{
			Array.Copy(BitConverter.GetBytes(shape_0.method_27().method_9().method_2()), 0, byte_0, 16, 4);
		}
		else
		{
			method_8(0, shape_0);
		}
		int_1 = int_0 - 24;
		byte_0[int_1] = (byte)int_2;
		if (int_3 > 255)
		{
			byte_0[9] = 1;
		}
		else
		{
			byte_0[int_1 + 8] = (byte)int_3;
		}
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, int_1 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)(ushort_0 + 1)), 0, byte_0, int_1 + 12, 2);
	}

	internal void method_10(Shape shape_0, int int_1, int int_2, byte byte_1)
	{
		method_8(int_1, shape_0);
		int_1 = int_0 - 24;
		byte_0[int_1] = byte_1;
		byte_0[int_1 + 8] = (byte)(byte_1 + 1);
		byte_0[int_1 + 11] = 1;
		Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_0, int_1 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)(int_2 + 1)), 0, byte_0, int_1 + 12, 2);
	}

	internal void method_11(Shape shape_0, int int_1, ArrayList arrayList_0)
	{
		if (byte_0 == null)
		{
			int_0 = shape_0.Length;
			if (shape_0.method_11())
			{
				int_0 -= 8;
			}
			byte_0 = new byte[int_0];
			int_1 = 0;
		}
		Class1114 @class = null;
		if (shape_0.IsGroup)
		{
			byte_0[int_1] = 15;
			byte_0[int_1 + 2] = 3;
			byte_0[int_1 + 3] = 240;
			Array.Copy(BitConverter.GetBytes(((GroupShape)shape_0).method_72()), 0, byte_0, int_1 + 4, 4);
			int_1 += 8;
			@class = ((GroupShape)shape_0).method_69();
			arrayList_0.Add(@class);
		}
		int_1 = shape_0.method_27().method_15(byte_0, int_1, @class);
		int_1 = ((!shape_0.method_33()) ? (int_1 + shape_0.method_54(byte_0, int_1)) : (int_1 + shape_0.method_53(class1114_0: (!shape_0.IsGroup) ? ((Class1114)arrayList_0[arrayList_0.Count - 1]) : ((Class1114)arrayList_0[arrayList_0.Count - 2]), byte_0: byte_0, int_0: int_1)));
	}

	internal void method_12(Class1725 class1725_0)
	{
		byte[] array = new byte[4];
		Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
		if (int_0 < 8224)
		{
			Array.Copy(BitConverter.GetBytes(int_0), 0, array, 2, 2);
			class1725_0.method_3(array);
			if (byte_0 != null && byte_0.Length != 0)
			{
				class1725_0.method_3(byte_0);
			}
			return;
		}
		Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, 0, 8224);
		int num = int_0 - 8224;
		int num2 = 8224;
		Array.Copy(BitConverter.GetBytes(60), 0, array, 0, 2);
		while (num >= 8224)
		{
			class1725_0.method_3(array);
			class1725_0.method_2(byte_0, num2, 8224);
			num2 += 8224;
			num -= 8224;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, array, 2, 2);
		class1725_0.method_3(array);
		class1725_0.method_2(byte_0, num2, num);
	}
}
