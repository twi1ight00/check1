using System;

namespace ns305;

internal class Class7095
{
	private Class6976 class6976_0;

	public string TypeName
	{
		get
		{
			if (class6976_0.NodeType == Enum969.const_1)
			{
				return "attribute";
			}
			if (class6976_0.NodeType == Enum969.const_0)
			{
				return "element";
			}
			return null;
		}
	}

	public string TypeNamespace
	{
		get
		{
			if (class6976_0.NodeType != Enum969.const_1 && class6976_0.NodeType != Enum969.const_0)
			{
				return null;
			}
			return class6976_0.NamespaceURI;
		}
	}

	internal Class7095(Class6976 node)
	{
		class6976_0 = node;
	}

	public bool method_0(string typeNamespaceArg, string typeNameArg, Enum966 derivationMethod)
	{
		throw new NotImplementedException();
	}
}
