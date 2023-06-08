using ns305;

namespace ns81;

internal class Class4064 : Class4062
{
	public override int SelectorType => 13;

	public override string SelectorText => base.SiblingSelector.SelectorText + " ~ " + base.SimpleSelector.SelectorText;

	public Class4064(Interface83 sibling, Interface83 simple)
		: base(sibling, simple)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!base.SimpleSelector.imethod_0(e, pseudoElement))
		{
			return false;
		}
		Class6976 previousSibling = e.PreviousSibling;
		while (true)
		{
			if (previousSibling != null)
			{
				if (previousSibling.NodeType == Enum969.const_0 && base.SiblingSelector.imethod_0((Class6981)previousSibling, null))
				{
					break;
				}
				previousSibling = previousSibling.PreviousSibling;
				continue;
			}
			return false;
		}
		return true;
	}
}
