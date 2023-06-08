using ns305;

namespace ns81;

internal class Class4054 : Class4052
{
	public override string SelectorText => base.AncestorSelector.SelectorText + " " + base.SimpleSelector.SelectorText;

	public Class4054(Interface83 ancestor, Interface83 simple)
		: base(ancestor, simple)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!base.SimpleSelector.imethod_0(e, pseudoElement))
		{
			return false;
		}
		Interface83 ancestorSelector = base.AncestorSelector;
		Class6976 parentNode = e.ParentNode;
		while (parentNode != null && parentNode.NodeType == Enum969.const_0)
		{
			if (!ancestorSelector.imethod_0((Class6981)parentNode, null))
			{
				parentNode = parentNode.ParentNode;
				continue;
			}
			return true;
		}
		return false;
	}
}
