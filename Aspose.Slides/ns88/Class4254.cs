using System;
using System.Collections;
using System.Collections.Generic;
using ns83;

namespace ns88;

internal class Class4254 : IDisposable, IEnumerator, IEnumerator<Interface105>
{
	private Interface105 interface105_0;

	private int int_0;

	private Class4255 class4255_0;

	private Interface105 interface105_1;

	public Interface105 Current => interface105_1;

	object IEnumerator.Current => Current;

	public Class4254(Interface105 owner)
		: this(owner, null)
	{
	}

	public Class4254(Interface105 owner, Class4255 skipNodes)
	{
		interface105_0 = owner;
		class4255_0 = skipNodes;
	}

	public void Dispose()
	{
		interface105_0 = null;
	}

	public bool MoveNext()
	{
		if (int_0 >= interface105_0.ChildCount)
		{
			return false;
		}
		Interface105 node;
		while (true)
		{
			if (int_0 < interface105_0.ChildCount)
			{
				node = interface105_0.imethod_1(int_0++);
				if (class4255_0 == null)
				{
					break;
				}
				if (!class4255_0.vmethod_0(node))
				{
					interface105_1 = node;
					return true;
				}
				continue;
			}
			return false;
		}
		interface105_1 = node;
		return true;
	}

	public void Reset()
	{
		int_0 = 0;
	}
}
