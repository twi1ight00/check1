using System.Collections;
using System.Collections.Generic;

namespace ns8;

internal class Class838 : IEnumerable, IEnumerable<Class836>
{
	private List<Class836> list_0 = new List<Class836>();

	public Class836 this[int index] => list_0[index];

	public int Count => list_0.Count;

	public void Add(Class836 obj)
	{
		list_0.Add(obj);
	}

	public void method_0(IEnumerable<Class836> collection)
	{
		list_0.AddRange(collection);
	}

	internal bool Contains(Class836 item)
	{
		return list_0.Contains(item);
	}

	public IEnumerator<Class836> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
