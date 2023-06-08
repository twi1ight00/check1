using ns82;

namespace ns83;

internal class Class7217 : Class7216
{
	public override object imethod_1(object t)
	{
		if (t == null)
		{
			return null;
		}
		return ((Interface386)t).imethod_6();
	}

	public override object imethod_0(Interface392 payload)
	{
		return new Class7211(payload);
	}

	public override Interface392 vmethod_1(int tokenType, string text)
	{
		return new Class7335(tokenType, text);
	}

	public override Interface392 vmethod_2(Interface392 fromToken)
	{
		return new Class7335(fromToken);
	}

	public override void imethod_19(object t, Interface392 startToken, Interface392 stopToken)
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
			Interface386 @interface = t as Interface386;
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
		return ((Interface386)t).TokenStartIndex;
	}

	public override int imethod_21(object t)
	{
		if (t == null)
		{
			return -1;
		}
		return ((Interface386)t).TokenStopIndex;
	}

	public override string imethod_16(object t)
	{
		if (t == null)
		{
			return null;
		}
		return ((Interface386)t).Text;
	}

	public override int imethod_14(object t)
	{
		if (t == null)
		{
			return 0;
		}
		return ((Interface386)t).Type;
	}

	public override Interface392 imethod_18(object treeNode)
	{
		if (treeNode is Class7211 @class)
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
		return ((Interface386)t).imethod_1(i);
	}

	public override int imethod_25(object t)
	{
		if (t == null)
		{
			return 0;
		}
		return ((Interface386)t).ChildCount;
	}

	public override object imethod_26(object t)
	{
		return ((Interface386)t).Parent;
	}

	public override void imethod_27(object t, object parent)
	{
		((Interface386)t).Parent = (Interface386)parent;
	}

	public override int imethod_28(object t)
	{
		return ((Interface386)t).ChildIndex;
	}

	public override void imethod_29(object t, int index)
	{
		((Interface386)t).ChildIndex = index;
	}

	public override void imethod_30(object parent, int startChildIndex, int stopChildIndex, object t)
	{
		if (parent != null)
		{
			((Interface386)parent).imethod_5(startChildIndex, stopChildIndex, t);
		}
	}
}
