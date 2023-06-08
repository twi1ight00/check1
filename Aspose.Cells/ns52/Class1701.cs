using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;

namespace ns52;

internal class Class1701
{
	private Class1700 class1700_0;

	private Class1699 class1699_0;

	private Class1703 class1703_0;

	private ShapeCollection shapeCollection_0;

	private Class1712 class1712_0;

	internal Class1701(ShapeCollection shapeCollection_1, Class1703 class1703_1, int int_0)
	{
		class1703_0 = class1703_1;
		shapeCollection_0 = shapeCollection_1;
		class1700_0 = new Class1700(int_0);
	}

	internal Class1701(ShapeCollection shapeCollection_1, Class1703 class1703_1, int int_0, int int_1)
	{
		class1703_0 = class1703_1;
		shapeCollection_0 = shapeCollection_1;
		class1700_0 = new Class1700(int_0, int_1);
	}

	[SpecialName]
	internal Class1703 method_0()
	{
		return class1703_0;
	}

	[SpecialName]
	internal WorksheetCollection method_1()
	{
		return shapeCollection_0.method_36();
	}

	internal int AddShape(Shape shape_0, Stream stream_0)
	{
		method_2().AddShape(method_0(), 1);
		shape_0.method_27().method_9().method_3(method_2().method_3());
		if (stream_0 != null)
		{
			return class1703_0.method_7(stream_0);
		}
		return 0;
	}

	internal void AddShape(Shape shape_0)
	{
		method_2().AddShape(method_0(), 1);
		shape_0.method_27().method_9().method_3(method_2().method_3());
	}

	[SpecialName]
	internal Class1700 method_2()
	{
		return class1700_0;
	}

	[SpecialName]
	internal Class1699 method_3()
	{
		if (class1699_0 == null)
		{
			class1699_0 = new Class1699();
		}
		return class1699_0;
	}

	[SpecialName]
	internal uint method_4()
	{
		long num = 48L;
		foreach (Shape item in shapeCollection_0)
		{
			if (item.method_34())
			{
				MsoDrawingType msoDrawingType = item.MsoDrawingType;
				if (msoDrawingType == MsoDrawingType.ComboBox)
				{
					object obj = ((ComboBox)item).method_69();
					if (obj is AutoFilter)
					{
						num += ((AutoFilter)obj).Count * 90;
					}
					else if (obj is PivotTable)
					{
						PivotTable pivotTable = (PivotTable)obj;
						num += pivotTable.PageFields.Count * 90;
					}
					else
					{
						num += 90;
					}
				}
				else
				{
					num += 90;
				}
			}
			else
			{
				num += item.Length;
			}
		}
		return (uint)num;
	}

	[SpecialName]
	internal int method_5()
	{
		int num = method_2().Length + 8 + 8;
		if (class1699_0 != null)
		{
			num += class1699_0.Length;
		}
		return num;
	}

	[SpecialName]
	internal Class1712 method_6()
	{
		if (class1712_0 == null)
		{
			class1712_0 = new Class1712();
		}
		return class1712_0;
	}

	internal Class1712 method_7()
	{
		return class1712_0;
	}

	[SpecialName]
	internal int method_8()
	{
		ArrayList arrayList = class1703_0.method_2().method_1();
		int num = 0;
		while (true)
		{
			if (num < arrayList.Count)
			{
				Class1706 @class = (Class1706)arrayList[num];
				if (@class.int_0 == method_2().method_0())
				{
					break;
				}
				num++;
				continue;
			}
			return 1024;
		}
		return (num + 1) * 1024;
	}

	internal int SetHeader(byte[] byte_0, int int_0, int int_1, int int_2)
	{
		byte_0[int_0] = 15;
		byte_0[int_0 + 2] = 2;
		byte_0[int_0 + 3] = 240;
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, int_0 + 4, 4);
		int_0 += 8;
		ushort num = 0;
		num = (ushort)(0u | (ushort)(method_2().method_0() << 4));
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, int_0, 2);
		byte_0[int_0 + 2] = 8;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 8;
		int_0 += 8;
		Array.Copy(BitConverter.GetBytes(method_2().method_1()), 0, byte_0, int_0, 4);
		Array.Copy(BitConverter.GetBytes(method_2().method_3()), 0, byte_0, int_0 + 4, 4);
		int_0 += 8;
		byte_0[int_0] = 15;
		byte_0[int_0 + 2] = 3;
		byte_0[int_0 + 3] = 240;
		Array.Copy(BitConverter.GetBytes(int_2), 0, byte_0, int_0 + 4, 4);
		int_0 += 8;
		byte_0[int_0] = 15;
		byte_0[int_0 + 2] = 4;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 40;
		int_0 += 8;
		byte_0[int_0] = 1;
		byte_0[int_0 + 2] = 9;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 16;
		int_0 += 24;
		byte_0[int_0] = 2;
		byte_0[int_0 + 2] = 10;
		byte_0[int_0 + 3] = 240;
		byte_0[int_0 + 4] = 8;
		int_0 += 8;
		Array.Copy(BitConverter.GetBytes(method_8()), 0, byte_0, int_0, 4);
		byte_0[int_0 + 4] = 5;
		int_0 += 8;
		return int_0;
	}
}
