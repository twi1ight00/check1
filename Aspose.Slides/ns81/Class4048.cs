using ns305;

namespace ns81;

internal class Class4048 : Class4021
{
	public Class4048()
		: base("only-child")
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
					if (previousSibling.NodeType == Enum969.const_0)
					{
						break;
					}
					previousSibling = previousSibling.PreviousSibling;
					continue;
				}
				previousSibling = e.NextSibling;
				while (true)
				{
					if (previousSibling != null)
					{
						if (previousSibling.NodeType == Enum969.const_0)
						{
							break;
						}
						previousSibling = previousSibling.NextSibling;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}
}
