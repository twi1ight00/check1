using System.Collections;
using System.Runtime.CompilerServices;

namespace ns21;

internal class Class1295
{
	private object object_0;

	private Class1296 class1296_0;

	private Class1290 class1290_0;

	internal ArrayList arrayList_0;

	private Class1286 class1286_0;

	internal Class1295(object object_1)
	{
		object_0 = object_1;
	}

	[SpecialName]
	internal Class1296 method_0()
	{
		if (class1296_0 == null)
		{
			class1296_0 = new Class1296();
		}
		return class1296_0;
	}

	[SpecialName]
	internal Class1290 method_1()
	{
		if (class1290_0 == null)
		{
			class1290_0 = new Class1290();
		}
		return class1290_0;
	}

	internal Class1286 method_2()
	{
		return class1286_0;
	}

	[SpecialName]
	internal Class1286 method_3()
	{
		if (class1286_0 == null)
		{
			class1286_0 = new Class1286();
		}
		return class1286_0;
	}

	internal void Copy(Class1295 class1295_0)
	{
		if (class1295_0.class1286_0 != null)
		{
			class1286_0 = new Class1286();
			method_3().Copy(class1295_0.class1286_0);
		}
		if (class1295_0.class1290_0 != null)
		{
			class1290_0 = new Class1290();
			class1290_0.Copy(class1295_0.class1290_0);
		}
		if (class1295_0.class1296_0 != null)
		{
			class1296_0 = new Class1296();
			class1296_0.Copy(class1295_0.class1296_0);
		}
		if (class1295_0.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList();
			arrayList_0.AddRange(class1295_0.arrayList_0);
		}
	}
}
