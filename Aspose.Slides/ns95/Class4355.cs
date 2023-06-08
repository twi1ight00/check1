using System;
using System.Collections;
using System.Collections.Generic;
using ns305;
using ns73;

namespace ns95;

internal class Class4355 : IEnumerable, IEnumerable<Interface75>, Interface95
{
	private List<Interface75> list_0;

	public long Length => list_0.Count;

	Interface76 Interface95.this[int index]
	{
		get
		{
			return (Interface76)list_0[index];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Interface76 this[int index] => (Interface76)list_0[index];

	public Class4355(Class7075 nodes)
	{
		list_0 = new List<Interface75>();
		IEnumerator<Class6976> enumerator = nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Interface92 @interface = (Interface92)enumerator.Current;
			if (@interface.CSSStyleSheet != null)
			{
				list_0.Add(@interface.CSSStyleSheet);
			}
		}
	}

	public IEnumerator<Interface75> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(Interface76 styleSheet)
	{
		throw new NotImplementedException();
	}
}
