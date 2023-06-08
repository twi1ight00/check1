using ns82;

namespace ns83;

internal class Class4080 : Class4075
{
	public const int int_5 = 2;

	public const int int_6 = 3;

	protected internal Interface108 interface108_0;

	private Interface108 TreeNodeStream
	{
		get
		{
			return interface108_0;
		}
		set
		{
			interface108_0 = value;
		}
	}

	public override string SourceName => interface108_0.SourceName;

	public override Interface107 Input => interface108_0;

	public Class4080(Interface108 input)
	{
		TreeNodeStream = input;
	}

	public Class4080(Interface108 input, Class4397 state)
		: base(state)
	{
		TreeNodeStream = input;
	}

	protected override object vmethod_28(Interface107 input)
	{
		return ((Interface108)input).imethod_9(1);
	}

	protected override object vmethod_29(Interface107 input, Exception17 e, int expectedTokenType, Class4391 follow)
	{
		string text = "<missing " + TokenNames[expectedTokenType] + ">";
		return new Class4363(new Class4093(expectedTokenType, text));
	}

	public override void Reset()
	{
		base.Reset();
		if (interface108_0 != null)
		{
			interface108_0.Seek(0);
		}
	}

	public override void vmethod_3(Interface107 ignore)
	{
		class4397_0.bool_0 = false;
		class4397_0.bool_1 = false;
		object t = interface108_0.imethod_9(1);
		if (interface108_0.TreeAdaptor.imethod_25(t) == 0)
		{
			interface108_0.imethod_0();
			return;
		}
		int num = 0;
		int num2 = interface108_0.TreeAdaptor.imethod_14(t);
		while (num2 != Class4398.int_7 && (num2 != 3 || num != 0))
		{
			interface108_0.imethod_0();
			t = interface108_0.imethod_9(1);
			num2 = interface108_0.TreeAdaptor.imethod_14(t);
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
		interface108_0.imethod_0();
	}

	protected internal override void vmethod_24(Interface107 input, int ttype, Class4391 follow)
	{
		throw new Exception26(ttype, (Interface108)input);
	}

	public override string vmethod_7(Exception17 e)
	{
		return GrammarFileName + ": node from " + (e.bool_0 ? "after " : string.Empty) + "line " + e.Line + ":" + e.CharPositionInLine;
	}

	public override string vmethod_6(Exception17 e, string[] tokenNames)
	{
		if (this != null)
		{
			Interface106 treeAdaptor = ((Interface108)e.Input).TreeAdaptor;
			e.Token = treeAdaptor.imethod_18(e.Node);
			if (e.Token == null)
			{
				e.Token = new Class4093(treeAdaptor.imethod_14(e.Node), treeAdaptor.imethod_16(e.Node));
			}
		}
		return base.vmethod_6(e, tokenNames);
	}

	public virtual void vmethod_30(string ruleName, int ruleIndex)
	{
		base.vmethod_22(ruleName, ruleIndex, interface108_0.imethod_9(1));
	}

	public virtual void vmethod_31(string ruleName, int ruleIndex)
	{
		base.vmethod_23(ruleName, ruleIndex, interface108_0.imethod_9(1));
	}
}
