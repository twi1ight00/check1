using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ns93;

internal class Class4304 : IEnumerable, IEnumerable<Class4305>
{
	private List<Class4305> list_0 = new List<Class4305>();

	public int Count => list_0.Count;

	public bool None => list_0.Count == 0;

	public Class4305 this[int index] => list_0[index];

	internal void Add(Class4305 function)
	{
		list_0.Add(function);
	}

	public IEnumerator<Class4305> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public override string ToString()
	{
		if (list_0.Count == 0)
		{
			return "none";
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list_0.Count; i++)
		{
			stringBuilder.Append(list_0[i]);
			if (list_0.Count - 1 != i)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}
}
