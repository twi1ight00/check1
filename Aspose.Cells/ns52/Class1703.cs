using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns52;

internal class Class1703
{
	private WorksheetCollection worksheetCollection_0;

	private Class1697 class1697_0;

	private Class1702 class1702_0;

	private ArrayList arrayList_0;

	private Enum181 enum181_0;

	internal Enum181 Type => enum181_0;

	internal uint Length
	{
		get
		{
			long num = method_6();
			if (class1697_0 != null && class1697_0.Count != 0)
			{
				num += class1697_0.Length + 8;
			}
			return (uint)num;
		}
	}

	internal Class1703(WorksheetCollection worksheetCollection_1, Enum181 enum181_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		class1702_0 = new Class1702(this);
		enum181_0 = enum181_1;
	}

	internal void Copy(Class1703 class1703_0)
	{
		if (class1703_0.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList();
			foreach (byte[] item in class1703_0.arrayList_0)
			{
				byte[] array2 = new byte[item.Length];
				Array.Copy(item, 0, array2, 0, item.Length);
				arrayList_0.Add(array2);
			}
		}
		else
		{
			arrayList_0 = null;
		}
		if (class1703_0.class1697_0 != null)
		{
			class1697_0 = new Class1697(this);
			class1697_0.Copy(class1703_0.class1697_0);
		}
		else
		{
			class1697_0 = null;
		}
	}

	[SpecialName]
	internal Class1697 method_0()
	{
		if (class1697_0 == null)
		{
			class1697_0 = new Class1697(this);
		}
		return class1697_0;
	}

	internal Class1697 method_1()
	{
		return class1697_0;
	}

	[SpecialName]
	internal Class1702 method_2()
	{
		return class1702_0;
	}

	internal Class1701 method_3(ShapeCollection shapeCollection_0, Class1703 class1703_0)
	{
		return method_2().method_4(shapeCollection_0, class1703_0);
	}

	[SpecialName]
	internal ArrayList method_4()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		return arrayList_0;
	}

	internal ArrayList method_5()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal int method_6()
	{
		int num = 8 + method_2().Length;
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			foreach (byte[] item in arrayList_0)
			{
				num += item.Length;
			}
		}
		else
		{
			num += 50;
		}
		return num;
	}

	internal int method_7(Stream stream_0)
	{
		return method_0().Add(stream_0) + 1;
	}

	[SpecialName]
	internal WorksheetCollection method_8()
	{
		return worksheetCollection_0;
	}
}
