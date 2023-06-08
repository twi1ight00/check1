using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns52;

namespace ns21;

internal class Class1245
{
	private Shape shape_0;

	private Class1711 class1711_0;

	internal ArrayList arrayList_0;

	[SpecialName]
	internal ArrayList method_0()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		return arrayList_0;
	}

	internal Class1245(Shape shape_1, Class1711 class1711_1)
	{
		class1711_0 = class1711_1;
		shape_0 = shape_1;
	}

	[SpecialName]
	internal Class1711 method_1()
	{
		return class1711_0;
	}

	internal int method_2(int int_0)
	{
		return method_1().method_4((ushort)int_0, 0);
	}

	internal int method_3(Enum182 enum182_0)
	{
		return method_1().method_4((ushort)enum182_0, 0);
	}

	internal bool method_4(Enum182 enum182_0)
	{
		return method_1()[(ushort)enum182_0] != null;
	}

	internal bool method_5(int int_0)
	{
		return method_1()[(ushort)int_0] != null;
	}

	internal int method_6()
	{
		int num = 0;
		for (int i = 327; i < 336; i++)
		{
			if (method_1()[(ushort)i] != null)
			{
				num++;
			}
		}
		return num;
	}
}
