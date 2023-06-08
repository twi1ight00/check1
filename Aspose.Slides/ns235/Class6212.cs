using System.Collections;
using System.Collections.Generic;

namespace ns235;

internal abstract class Class6212 : Class6204
{
	private readonly List<Class6204> list_0 = new List<Class6204>();

	public Class6204 this[int index] => list_0[index];

	public int Count => list_0.Count;

	public override void vmethod_0(Class6176 visitor)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			Class6204 @class = list_0[i];
			@class.vmethod_0(visitor);
		}
	}

	public void Insert(int index, Class6204 node)
	{
		node.Parent = this;
		list_0.Insert(index, node);
	}

	public int Add(Class6204 node)
	{
		node.Parent = this;
		return ((IList)list_0).Add((object)node);
	}

	public void Remove(Class6204 node)
	{
		int num = list_0.IndexOf(node);
		if (num != -1)
		{
			node.Parent = null;
			list_0.RemoveAt(num);
		}
	}

	public void method_0(Class6204[] nodes)
	{
		for (int i = 0; i < nodes.Length; i++)
		{
			Add(nodes[i]);
		}
	}

	public void Clear()
	{
		list_0.Clear();
	}

	internal int IndexOf(Class6204 value)
	{
		return list_0.IndexOf(value);
	}
}
