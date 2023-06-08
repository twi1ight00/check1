using ns82;

namespace ns83;

internal class Class7227 : Class7226
{
	public const int int_5 = 2;

	public const int int_6 = 3;

	protected internal Interface389 interface389_0;

	private Interface389 TreeNodeStream
	{
		get
		{
			return interface389_0;
		}
		set
		{
			interface389_0 = value;
		}
	}

	public override string SourceName => interface389_0.SourceName;

	public override Interface388 Input => interface389_0;

	public Class7227(Interface389 input)
	{
		TreeNodeStream = input;
	}

	public Class7227(Interface389 input, Class7345 state)
		: base(state)
	{
		TreeNodeStream = input;
	}

	protected override object vmethod_28(Interface388 input)
	{
		return ((Interface389)input).imethod_9(1);
	}

	protected override object vmethod_29(Interface388 input, Exception77 e, int expectedTokenType, Class7332 follow)
	{
		string text = "<missing " + TokenNames[expectedTokenType] + ">";
		return new Class7211(new Class7335(expectedTokenType, text));
	}

	public override void Reset()
	{
		base.Reset();
		if (interface389_0 != null)
		{
			interface389_0.Seek(0);
		}
	}

	public override void vmethod_3(Interface388 ignore)
	{
		class7345_0.bool_0 = false;
		class7345_0.bool_1 = false;
		object t = interface389_0.imethod_9(1);
		if (interface389_0.TreeAdaptor.imethod_25(t) == 0)
		{
			interface389_0.imethod_0();
			return;
		}
		int num = 0;
		int num2 = interface389_0.TreeAdaptor.imethod_14(t);
		while (num2 != Class7346.int_7 && (num2 != 3 || num != 0))
		{
			interface389_0.imethod_0();
			t = interface389_0.imethod_9(1);
			num2 = interface389_0.TreeAdaptor.imethod_14(t);
			switch (num2)
			{
			case 2:
				num++;
				break;
			case 3:
				num--;
				break;
			}
		}
		interface389_0.imethod_0();
	}

	protected internal override void vmethod_24(Interface388 input, int ttype, Class7332 follow)
	{
		throw new Exception86(ttype, (Interface389)input);
	}

	public override string vmethod_7(Exception77 e)
	{
		return GrammarFileName + ": node from " + (e.bool_0 ? "after " : string.Empty) + "line " + e.Line + ":" + e.CharPositionInLine;
	}

	public override string vmethod_6(Exception77 e, string[] tokenNames)
	{
		if (this != null)
		{
			Interface387 treeAdaptor = ((Interface389)e.Input).TreeAdaptor;
			e.Token = treeAdaptor.imethod_18(e.Node);
			if (e.Token == null)
			{
				e.Token = new Class7335(treeAdaptor.imethod_14(e.Node), treeAdaptor.imethod_16(e.Node));
			}
		}
		return base.vmethod_6(e, tokenNames);
	}

	public virtual void vmethod_30(string ruleName, int ruleIndex)
	{
		base.vmethod_22(ruleName, ruleIndex, interface389_0.imethod_9(1));
	}

	public virtual void vmethod_31(string ruleName, int ruleIndex)
	{
		base.vmethod_23(ruleName, ruleIndex, interface389_0.imethod_9(1));
	}
}
