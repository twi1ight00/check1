namespace ns82;

internal class Class7230 : Class7226
{
	protected internal Interface393 interface393_0;

	public virtual Interface393 TokenStream
	{
		get
		{
			return interface393_0;
		}
		set
		{
			interface393_0 = null;
			Reset();
			interface393_0 = value;
		}
	}

	public override string SourceName => interface393_0.SourceName;

	public override Interface388 Input => interface393_0;

	public Class7230(Interface393 input)
	{
		TokenStream = input;
	}

	public Class7230(Interface393 input, Class7345 state)
		: base(state)
	{
		TokenStream = input;
	}

	public override void Reset()
	{
		base.Reset();
		if (interface393_0 != null)
		{
			interface393_0.Seek(0);
		}
	}

	protected override object vmethod_28(Interface388 input)
	{
		return ((Interface393)input).imethod_8(1);
	}

	protected override object vmethod_29(Interface388 input, Exception77 e, int expectedTokenType, Class7332 follow)
	{
		string text = null;
		text = ((expectedTokenType != Class7346.int_7) ? ("<missing " + TokenNames[expectedTokenType] + ">") : "<missing EOF>");
		Class7335 @class = new Class7335(expectedTokenType, text);
		Interface392 @interface = ((Interface393)input).imethod_8(1);
		if (@interface.Type == Class7346.int_7)
		{
			@interface = ((Interface393)input).imethod_8(-1);
		}
		@class.int_1 = @interface.Line;
		@class.CharPositionInLine = @interface.CharPositionInLine;
		@class.Channel = 0;
		return @class;
	}

	public virtual void vmethod_30(string ruleName, int ruleIndex)
	{
		base.vmethod_22(ruleName, ruleIndex, interface393_0.imethod_8(1));
	}

	public virtual void vmethod_31(string ruleName, int ruleIndex)
	{
		base.vmethod_23(ruleName, ruleIndex, interface393_0.imethod_8(1));
	}
}
