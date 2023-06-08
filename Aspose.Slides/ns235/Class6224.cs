namespace ns235;

internal class Class6224
{
	public static bool smethod_0(Interface261 node)
	{
		if (!smethod_1(node))
		{
			return smethod_2(node);
		}
		return true;
	}

	public static bool smethod_1(Interface261 node)
	{
		if (node.RenderTransform != null)
		{
			return !node.RenderTransform.IsIdentity;
		}
		return false;
	}

	public static bool smethod_2(Interface261 node)
	{
		if (node.Clip != null)
		{
			return node.Clip.Count != 0;
		}
		return false;
	}

	public static bool smethod_3(Class6217 path)
	{
		if (path.Pen == null)
		{
			return path.Brush != null;
		}
		return true;
	}
}
