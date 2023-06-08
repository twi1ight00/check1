using ns305;

namespace ns81;

internal class Class4046 : Class4021
{
	public Class4046()
		: base("last-child")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (e.ParentNode != null && e.ParentNode.NodeType == Enum969.const_0)
		{
			Class6976 nextSibling = e.NextSibling;
			while (true)
			{
				if (nextSibling != null)
				{
					if (nextSibling.NodeType == Enum969.const_0)
					{
						break;
					}
					nextSibling = nextSibling.NextSibling;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
