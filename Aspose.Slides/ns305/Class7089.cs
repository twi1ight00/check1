using System.Collections;
using System.Collections.Generic;

namespace ns305;

internal class Class7089 : IEnumerable, IEnumerable<Class7097>
{
	private List<Class7097> list_0;

	public int Length => list_0.Count;

	public Class7089()
	{
		list_0 = new List<Class7097>();
	}

	public Class7097 method_0(int index)
	{
		return list_0[index];
	}

	internal void Add(Class7097 implementation)
	{
		list_0.Add(implementation);
	}

	public IEnumerator<Class7097> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
