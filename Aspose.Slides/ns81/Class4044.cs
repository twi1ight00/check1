using ns305;

namespace ns81;

internal class Class4044 : Class4021
{
	public Class4044()
		: base("first-of-type")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (e.ParentNode != null && e.ParentNode.NodeType == Enum969.const_0)
		{
			Class6976 previousSibling = e.PreviousSibling;
			while (true)
			{
				if (previousSibling != null)
				{
					if (previousSibling.NodeType == Enum969.const_0 && ((Class6981)previousSibling).TagName == e.TagName)
					{
						break;
					}
					previousSibling = previousSibling.PreviousSibling;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
