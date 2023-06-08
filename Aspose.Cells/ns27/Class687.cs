using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns52;
using ns59;

namespace ns27;

internal class Class687 : Class538
{
	private short short_2;

	private Class655 class655_0;

	private Class656 class656_0;

	public Class687()
	{
		method_2(2150);
		short_2 = 14;
	}

	internal void method_4(WorksheetCollection worksheetCollection_0, Class1703 class1703_0)
	{
		class655_0 = new Class655(worksheetCollection_0, short_2);
		class655_0.method_5(class1703_0);
	}

	internal void method_5(Class1725 class1725_0)
	{
		int num = ((class655_0.arrayList_1 == null) ? class655_0.Length : ((int)class655_0.arrayList_1[0]));
		class1725_0.method_7(method_1());
		class1725_0.method_7((short)(num + short_2));
		byte[] array = new byte[short_2];
		array[0] = 102;
		array[1] = 8;
		array[12] = 2;
		class1725_0.method_3(array);
		class1725_0.method_1(class655_0.Data, num);
		ArrayList arrayList = class655_0.method_4();
		if (arrayList != null)
		{
			array[12] = 6;
			for (int i = 0; i < arrayList.Count; i++)
			{
				byte[] array2 = (byte[])arrayList[i];
				num = ((i + 1 >= class655_0.arrayList_1.Count) ? array2.Length : ((int)class655_0.arrayList_1[i + 1]));
				class1725_0.method_7(method_1());
				class1725_0.method_7((short)(num + short_2));
				class1725_0.method_3(array);
				class1725_0.method_3(array2);
			}
		}
	}

	internal void method_6(ShapeCollection shapeCollection_0)
	{
		class656_0 = new Class656();
		class656_0.method_6(shapeCollection_0);
	}

	internal void method_7(Class1725 class1725_0)
	{
		class1725_0.method_7(method_1());
		class1725_0.method_7((short)(class656_0.int_0 + short_2));
		byte[] array = new byte[short_2];
		array[0] = 102;
		array[1] = 8;
		array[12] = 1;
		class1725_0.method_3(array);
		class1725_0.method_3(class656_0.Data);
	}
}
