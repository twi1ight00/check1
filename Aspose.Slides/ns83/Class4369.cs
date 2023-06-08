using ns82;

namespace ns83;

internal class Class4369 : Class4368
{
	public override object imethod_1(object t)
	{
		if (t == null)
		{
			return null;
		}
		return ((Interface105)t).imethod_6();
	}

	public override object imethod_0(Interface86 payload)
	{
		return new Class4363(payload);
	}

	public override Interface86 vmethod_1(int tokenType, string text)
	{
		return new Class4093(tokenType, text);
	}

	public override Interface86 vmethod_2(Interface86 fromToken)
	{
		return new Class4093(fromToken);
	}

	public override void imethod_19(object t, Interface86 startToken, Interface86 stopToken)
	{
		if (t != null)
		{
			int tokenStartIndex = 0;
			int tokenStopIndex = 0;
			if (startToken != null)
			{
				tokenStartIndex = startToken.TokenIndex;
			}
			if (stopToken != null)
			{
				tokenStopIndex = stopToken.TokenIndex;
			}
			Interface105 @interface = t as Interface105;
			@interface.TokenStartIndex = tokenStartIndex;
			@interface.TokenStopIndex = tokenStopIndex;
		}
	}

	public override int imethod_20(object t)
	{
		if (t == null)
		{
			return -1;
		}
		return ((Interface105)t).TokenStartIndex;
	}

	public override int imethod_21(object t)
	{
		if (t == null)
		{
			return -1;
		}
		return ((Interface105)t).TokenStopIndex;
	}

	public override string imethod_16(object t)
	{
		if (t == null)
		{
			return null;
		}
		return ((Interface105)t).Text;
	}

	public override int imethod_14(object t)
	{
		if (t == null)
		{
			return 0;
		}
		return ((Interface105)t).Type;
	}

	public override Interface86 imethod_18(object treeNode)
	{
		if (treeNode is Class4363 @class)
		{
			return @class.Token;
		}
		return null;
	}

	public override object imethod_22(object t, int i)
	{
		if (t == null)
		{
			return null;
		}
		return ((Interface105)t).imethod_1(i);
	}

	public override int imethod_25(object t)
	{
		if (t == null)
		{
			return 0;
		}
		return ((Interface105)t).ChildCount;
	}

	public override object imethod_26(object t)
	{
		return ((Interface105)t).Parent;
	}

	public override void imethod_27(object t, object parent)
	{
		((Interface105)t).Parent = (Interface105)parent;
	}

	public override int imethod_28(object t)
	{
		return ((Interface105)t).ChildIndex;
	}

	public override void imethod_29(object t, int index)
	{
		((Interface105)t).ChildIndex = index;
	}

	public override void imethod_30(object parent, int startChildIndex, int stopChildIndex, object t)
	{
		if (parent != null)
		{
			((Interface105)parent).imethod_5(startChildIndex, stopChildIndex, t);
		}
	}
}
