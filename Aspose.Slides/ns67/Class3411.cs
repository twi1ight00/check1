using System;
using System.Collections.Generic;
using DrawingMLRenderer;

namespace ns67;

internal sealed class Class3411 : ICloneable
{
	private readonly List<Class3410> list_0 = new List<Class3410>();

	public Class3410[] TabStops => list_0.ToArray();

	public void method_0(Class3410 tabStop)
	{
		if (tabStop == null)
		{
			throw new ArgumentNullException("tabStop");
		}
		if (list_0.Count == 32)
		{
			throw new DrawingMLRenderer.Exception("Too many tab stops");
		}
		list_0.Add(tabStop.method_0());
	}

	public object Clone()
	{
		return method_1();
	}

	public Class3411 method_1()
	{
		return new Class3411(this);
	}

	private Class3411(Class3411 src)
	{
		foreach (Class3410 item in src.list_0)
		{
			method_0(item);
		}
	}
}
