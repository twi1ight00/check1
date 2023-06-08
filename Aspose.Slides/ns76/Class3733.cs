using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns81;

namespace ns76;

internal class Class3733 : IEnumerable, IEnumerable<Interface83>
{
	private List<Interface83> list_0 = new List<Interface83>();

	private Class3707 class3707_0;

	public int Length => list_0.Count;

	public Interface83 this[int index]
	{
		get
		{
			if (index >= 0 && index <= list_0.Count - 1)
			{
				return list_0[index];
			}
			return null;
		}
	}

	public Class3733(Class3707 rule)
	{
		class3707_0 = rule;
	}

	public IEnumerator<Interface83> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal void Add(Class4051 selector)
	{
		selector.vmethod_0(class3707_0);
		list_0.Add(selector);
	}

	public override string ToString()
	{
		if (Length == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(this[0].SelectorText);
		for (int i = 1; i < Length; i++)
		{
			stringBuilder.Append(", ");
			stringBuilder.Append(this[i].SelectorText);
		}
		return stringBuilder.ToString();
	}
}
