using System.Collections.Generic;

namespace ns67;

internal abstract class Class3073 : Class3072
{
	private readonly List<Class3072> list_0;

	protected Class3073()
	{
		list_0 = new List<Class3072>();
	}

	public Class3072[] method_0()
	{
		return list_0.ToArray();
	}

	protected int GetCount()
	{
		return list_0.Count;
	}

	protected void method_1(Class3072 builder)
	{
		list_0.Add(builder);
	}

	protected Class3072 method_2()
	{
		Class3072 result = null;
		if (list_0.Count > 0)
		{
			result = list_0[list_0.Count - 1];
			list_0.RemoveAt(list_0.Count - 1);
		}
		return result;
	}
}
