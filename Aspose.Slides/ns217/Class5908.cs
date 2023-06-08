using System.Collections.Generic;

namespace ns217;

internal class Class5908
{
	private List<Class5781> list_0 = new List<Class5781>();

	public List<Class5781> List => list_0;

	public int Length => list_0.Count;

	public void method_0(Class5781 node)
	{
		list_0.Add(node);
	}

	public void Insert(Class5781 node, Class5781 nodeBefore)
	{
		list_0.Insert(list_0.IndexOf(nodeBefore), node);
	}

	public Class5781 method_1(int index)
	{
		return list_0[index];
	}

	public Class5781 method_2(string name)
	{
		foreach (Class5781 item in list_0)
		{
			if (item.Name == name)
			{
				return item;
			}
		}
		return null;
	}

	public Class5781 method_3(string name)
	{
		foreach (Class5781 item in list_0)
		{
			if (item.ClassName == name)
			{
				return item;
			}
		}
		return null;
	}

	public void Remove(Class5781 node)
	{
		list_0.Remove(node);
	}
}
