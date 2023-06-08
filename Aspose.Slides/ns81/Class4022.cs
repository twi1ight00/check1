using ns305;
using ns89;

namespace ns81;

internal abstract class Class4022 : Class4021
{
	private Class4249 class4249_0;

	private bool bool_0;

	private bool bool_1;

	protected Class4249 Expression => class4249_0;

	public override string ConditionText => ':' + base.ClassName + class4249_0.ExpressionText + ")";

	protected Class4022(Class4249 expression, string className, bool isForwardDirection, bool anyType)
		: base(className)
	{
		class4249_0 = expression;
		bool_0 = isForwardDirection;
		bool_1 = anyType;
	}

	protected int method_0(Class6981 e)
	{
		if (bool_0)
		{
			return method_1(e);
		}
		return method_2(e);
	}

	private int method_1(Class6981 e)
	{
		string tagName = e.TagName;
		int num = 1;
		for (Class6976 previousSibling = e.PreviousSibling; previousSibling != null; previousSibling = previousSibling.PreviousSibling)
		{
			if (previousSibling.NodeType == Enum969.const_0)
			{
				if (bool_1)
				{
					num++;
				}
				else if (((Class6981)previousSibling).TagName == tagName)
				{
					num++;
				}
			}
		}
		return num;
	}

	private int method_2(Class6981 e)
	{
		int num = 1;
		string tagName = e.TagName;
		for (Class6976 nextSibling = e.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
		{
			if (nextSibling.NodeType == Enum969.const_0)
			{
				if (bool_1)
				{
					num++;
				}
				else if (((Class6981)nextSibling).TagName == tagName)
				{
					num++;
				}
			}
		}
		return num;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (e.ParentNode != null && e.ParentNode.NodeType == Enum969.const_0)
		{
			return Expression.method_0(method_0(e));
		}
		return false;
	}
}
