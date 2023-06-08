using System.Collections;
using System.Collections.Specialized;

namespace ns18;

internal class Class1438
{
	internal ArrayList arrayList_0;

	internal Hashtable hashtable_0;

	internal Class1438()
	{
		arrayList_0 = new ArrayList();
		hashtable_0 = CollectionsUtil.CreateCaseInsensitiveHashtable();
	}

	internal void method_0(Class950 class950_0)
	{
		try
		{
			arrayList_0.Add(class950_0);
		}
		catch
		{
		}
	}

	internal void method_1(string string_0, Class1441 class1441_0)
	{
		try
		{
			hashtable_0[string_0] = class1441_0;
		}
		catch
		{
		}
	}

	internal void method_2(Class1447 class1447_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class950 @class = (Class950)arrayList_0[i];
			if (@class.method_6())
			{
				@class.Destination = (Class1441)hashtable_0[@class.method_4()];
			}
			@class.vmethod_1(class1447_0);
		}
	}
}
