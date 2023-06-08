using System;
using System.Collections.Generic;

namespace ns305;

internal class Class7062
{
	private const string string_0 = "*";

	private Class6976 class6976_0;

	private List<Class6976> list_0;

	internal List<Class6976> Nodes
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6976>();
			}
			return list_0;
		}
	}

	public int Length
	{
		get
		{
			if (list_0 != null)
			{
				return list_0.Count;
			}
			return 0;
		}
	}

	internal Class7062(Class6976 parent)
	{
		class6976_0 = parent;
	}

	internal int method_0(string name)
	{
		int length = Length;
		int num = 0;
		while (true)
		{
			if (num < length)
			{
				Class6976 @class = Nodes[num];
				if (@class.NodeName.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal int method_1(string localName, string namespaceURI)
	{
		int length = Length;
		int num = 0;
		while (true)
		{
			if (num < length)
			{
				Class6976 @class = Nodes[num];
				if (@class.LocalName.Equals(localName, StringComparison.OrdinalIgnoreCase) && (namespaceURI == "*" || @class.NamespaceURI.Equals(namespaceURI, StringComparison.OrdinalIgnoreCase)))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal Class6976 AddNode(Class6976 node)
	{
		Nodes.Add(node);
		node.vmethod_4(class6976_0);
		return node;
	}

	internal Class6976 method_2(int index)
	{
		Class6976 @class = Nodes[index];
		Nodes.RemoveAt(index);
		@class.vmethod_4(null);
		return @class;
	}

	internal Class6976 method_3(int index, Class6976 node)
	{
		Class6976 result = method_2(index);
		vmethod_0(index, node);
		return result;
	}

	internal virtual Class6976 vmethod_0(int index, Class6976 node)
	{
		Nodes.Insert(index, node);
		node.vmethod_4(class6976_0);
		return node;
	}

	public Class6976 method_4(string name)
	{
		int num = method_0(name);
		if (num >= 0)
		{
			return Nodes[num];
		}
		return null;
	}

	public Class6976 method_5(Class6976 node)
	{
		if (node == null)
		{
			return null;
		}
		int num = method_0(node.NodeName);
		if (num == -1)
		{
			AddNode(node);
			return null;
		}
		return method_3(num, node);
	}

	public Class6976 method_6(string name)
	{
		int num = method_0(name);
		if (num >= 0)
		{
			return method_2(num);
		}
		return null;
	}

	public Class6976 method_7(int index)
	{
		if (index >= 0 && index < Nodes.Count)
		{
			return Nodes[index];
		}
		return null;
	}

	public Class6976 method_8(string namespaceURI, string localName)
	{
		int num = method_1(localName, namespaceURI);
		if (num >= 0)
		{
			return Nodes[num];
		}
		return null;
	}

	public Class6976 method_9(Class6976 node)
	{
		if (node == null)
		{
			return null;
		}
		int num = method_1(node.LocalName, node.NamespaceURI);
		if (num == -1)
		{
			AddNode(node);
			return null;
		}
		return method_3(num, node);
	}

	public Class6976 method_10(string namespaceURI, string localName)
	{
		int num = method_1(localName, namespaceURI);
		if (num >= 0)
		{
			return method_2(num);
		}
		return null;
	}
}
