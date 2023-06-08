using ns305;

namespace ns81;

internal class Class4053 : Class4052
{
	public override int SelectorType => 11;

	public override string SelectorText => base.AncestorSelector.SelectorText + " > " + base.SimpleSelector.SelectorText;

	public Class4053(Interface83 ancestor, Interface83 simple)
		: base(ancestor, simple)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (e.ParentNode is Class6981 @class && @class.NodeType == Enum969.const_0)
		{
			if (base.AncestorSelector.imethod_0(@class, null))
			{
				return base.SimpleSelector.imethod_0(e, pseudoElement);
			}
			return false;
		}
		return false;
	}
}
