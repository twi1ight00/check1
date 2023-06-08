using System;
using System.Collections;
using System.Collections.Generic;

namespace ns67;

internal class Class3330 : IEnumerable, IEnumerable<Class3329>
{
	private readonly List<Class3329> list_0;

	public int Count => list_0.Count;

	public Class3329 this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	public Class3330()
	{
		list_0 = new List<Class3329>();
	}

	public void Add(Class3329 value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		list_0.Add(value);
	}

	public bool Contains(Class3329 value)
	{
		return list_0.Contains(value);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public int IndexOf(Class3329 value)
	{
		return list_0.IndexOf(value);
	}

	public void Insert(int index, Class3329 value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		list_0.Insert(index, value);
	}

	public void Remove(Class3329 value)
	{
		list_0.Remove(value);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public IEnumerator<Class3329> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
