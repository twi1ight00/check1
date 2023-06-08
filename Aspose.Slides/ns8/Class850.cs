using System.Collections;
using System.Collections.Generic;

namespace ns8;

internal class Class850 : IEnumerable, IEnumerable<Class116>
{
	private List<Class116> list_0 = new List<Class116>();

	public Class116 this[int index]
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

	public int Count => list_0.Count;

	public void Add(Class116 value)
	{
		list_0.Add(value);
	}

	public void method_0(IEnumerable<Class116> value)
	{
		list_0.AddRange(value);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<Class116> IEnumerable<Class116>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
