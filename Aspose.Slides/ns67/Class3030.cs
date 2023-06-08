using System.Collections;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3030 : IEnumerable, IEnumerable<Class3031>
{
	private readonly List<Class3031> list_0 = new List<Class3031>();

	public int Count => list_0.Count;

	public Class3031[] method_0()
	{
		return list_0.ToArray();
	}

	public void Add(Class3031 contour)
	{
		list_0.Add(contour);
	}

	public IEnumerator<Class3031> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
