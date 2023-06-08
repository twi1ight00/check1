using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns73;

namespace ns76;

internal class Class3732 : IEnumerable, IEnumerable<Interface59>, Interface73
{
	private List<Interface59> list_0 = new List<Interface59>();

	private Class3735 class3735_0;

	public long Length => list_0.Count;

	public Interface59 this[int index]
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

	public Class3732(Class3735 styleSheet)
	{
		class3735_0 = styleSheet;
	}

	public IEnumerator<Interface59> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(Interface59 rule)
	{
		list_0.Add(rule);
	}

	public void Insert(int index, Interface59 item)
	{
		list_0.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void Remove(Interface59 rule)
	{
		list_0.Remove(rule as Class3706);
	}

	public override string ToString()
	{
		if (Length == 0L)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(this[0].CSSText);
		for (int i = 1; i < Length; i++)
		{
			stringBuilder.Append(", ");
			stringBuilder.Append(this[i].CSSText);
		}
		return stringBuilder.ToString();
	}
}
