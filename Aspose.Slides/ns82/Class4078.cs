namespace ns82;

internal class Class4078 : Class4075
{
	protected internal Interface111 interface111_0;

	public virtual Interface111 TokenStream
	{
		get
		{
			return interface111_0;
		}
		set
		{
			interface111_0 = null;
			Reset();
			interface111_0 = value;
		}
	}

	public override string SourceName => interface111_0.SourceName;

	public override Interface107 Input => interface111_0;

	public Class4078(Interface111 input)
	{
		TokenStream = input;
	}

	public Class4078(Interface111 input, Class4397 state)
		: base(state)
	{
		TokenStream = input;
	}

	public override void Reset()
	{
		base.Reset();
		if (interface111_0 != null)
		{
			interface111_0.Seek(0);
		}
	}

	protected override object vmethod_28(Interface107 input)
	{
		return ((Interface111)input).imethod_8(1);
	}

	protected override object vmethod_29(Interface107 input, Exception17 e, int expectedTokenType, Class4391 follow)
	{
		string text = null;
		text = ((expectedTokenType != Class4398.int_7) ? ("<missing " + TokenNames[expectedTokenType] + ">") : "<missing EOF>");
		Class4093 @class = new Class4093(expectedTokenType, text);
		Interface86 @interface = ((Interface111)input).imethod_8(1);
		if (@interface.Type == Class4398.int_7)
		{
			@interface = ((Interface111)input).imethod_8(-1);
		}
		@class.int_1 = @interface.Line;
		@class.CharPositionInLine = @interface.CharPositionInLine;
		@class.Channel = 0;
		return @class;
	}

	public virtual void vmethod_30(string ruleName, int ruleIndex)
	{
		base.vmethod_22(ruleName, ruleIndex, interface111_0.imethod_8(1));
	}

	public virtual void vmethod_31(string ruleName, int ruleIndex)
	{
		base.vmethod_23(ruleName, ruleIndex, interface111_0.imethod_8(1));
	}
}
