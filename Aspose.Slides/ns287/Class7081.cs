using System;
using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7081 : Class7078
{
	private Class7075 class7075_0;

	public override int Length => class7075_0.Length;

	public override Class6976 this[int index] => class7075_0[index];

	public Class7081(Class7075 list)
	{
		class7075_0 = list;
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return class7075_0.GetEnumerator();
	}

	public override Class6976 vmethod_0(string name)
	{
		return smethod_0(name, class7075_0);
	}

	public static Class6976 smethod_0(string name, Class7075 nodes)
	{
		foreach (Class6976 node in nodes)
		{
			Class7045 @class = node.Attributes.method_11("ID");
			if (@class != null && @class.Value != null && @class.Value.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return node;
			}
		}
		foreach (Class6976 node2 in nodes)
		{
			Class7045 class2 = node2.Attributes.method_11("NAME");
			if (class2 != null && class2.Value != null && class2.Value.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return node2;
			}
		}
		return null;
	}
}
