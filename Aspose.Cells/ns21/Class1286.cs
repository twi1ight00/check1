using System.Collections;

namespace ns21;

internal class Class1286
{
	internal ArrayList arrayList_0;

	internal Class1112 class1112_0;

	internal Class1112 class1112_1;

	internal Class1112 class1112_2;

	internal void Copy(Class1286 class1286_0)
	{
		if (class1286_0.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList();
			arrayList_0.AddRange(class1286_0.arrayList_0);
		}
		if (class1286_0.class1112_0 != null)
		{
			class1112_0 = new Class1112();
			class1112_0.Copy(class1286_0.class1112_0);
		}
		if (class1286_0.class1112_1 != null)
		{
			class1112_1 = new Class1112();
			class1112_1.Copy(class1286_0.class1112_1);
		}
		if (class1286_0.class1112_2 != null)
		{
			class1112_2 = new Class1112();
			class1112_2.Copy(class1286_0.class1112_2);
		}
	}
}
