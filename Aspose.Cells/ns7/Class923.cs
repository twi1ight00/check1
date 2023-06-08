using System.Collections;

namespace ns7;

internal class Class923 : CollectionBase
{
	internal void method_0(Enum230 enum230_0, object object_0)
	{
		if (base.InnerList.Count > 0)
		{
			foreach (Class1691 inner in base.InnerList)
			{
				if (inner.enum230_0 == enum230_0)
				{
					inner.object_0 = object_0;
					return;
				}
			}
		}
		Class1691 class2 = new Class1691();
		class2.enum230_0 = enum230_0;
		class2.object_0 = object_0;
		base.InnerList.Add(class2);
	}

	internal object method_1(Enum230 enum230_0)
	{
		if (base.InnerList.Count > 0)
		{
			foreach (Class1691 inner in base.InnerList)
			{
				if (inner.enum230_0 == enum230_0)
				{
					return inner.object_0;
				}
			}
		}
		return null;
	}

	internal Class1691 method_2(Enum230 enum230_0)
	{
		if (base.InnerList.Count > 0)
		{
			foreach (Class1691 inner in base.InnerList)
			{
				if (inner.enum230_0 == enum230_0)
				{
					return inner;
				}
			}
		}
		return null;
	}

	internal void Copy(Class923 class923_0)
	{
		foreach (Class1691 item in class923_0)
		{
			method_0(item.enum230_0, item.object_0);
		}
	}
}
