using ns305;

namespace ns81;

internal class Class4047 : Class4021
{
	public Class4047()
		: base("last-of-type")
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
					if (nextSibling.NodeType == Enum969.const_0 && ((Class6981)nextSibling).TagName == e.TagName)
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
