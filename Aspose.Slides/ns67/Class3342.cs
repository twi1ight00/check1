using System;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3342 : ICloneable
{
	private readonly List<Class3341> list_0;

	public Class3341 this[int i] => list_0[i];

	public int Count => list_0.Count;

	public void Add(Class3341 dashStop)
	{
		if (dashStop == null)
		{
			throw new ArgumentNullException("dashStop");
		}
		list_0.Add(dashStop);
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3342 method_0()
	{
		Class3342 @class = new Class3342();
		for (int i = 0; i < list_0.Count; i++)
		{
			@class.Add(this[i]);
		}
		return @class;
	}

	public void Insert(int index, Class3341 dashStop)
	{
		if (dashStop == null)
		{
			throw new ArgumentNullException("dashStop");
		}
		list_0.Insert(index, dashStop);
	}

	public void Remove(Class3341 dashStop)
	{
		list_0.Remove(dashStop);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	internal Class3342()
	{
		list_0 = new List<Class3341>();
	}
}
