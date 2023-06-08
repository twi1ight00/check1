using ns235;

namespace ns267;

internal class Class6603 : Class6599
{
	protected override string RootNodeName => "TextField";

	public Class6603(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6210;
	}

	protected override void vmethod_3(Class6205 field)
	{
		Class6210 @class = field as Class6210;
		base.Context.Writer.method_24("IsRichText", @class.IsRichText);
		base.Context.Writer.method_23("MaxLength", @class.MaxLength);
		base.Context.Writer.method_28("FontColor", @class.FontColor);
		base.Context.Writer.method_24("IsMultiline", @class.IsMultiline);
		base.Context.Writer.method_22("LineHeight", @class.LineHeight);
	}

	protected override void vmethod_4(Class6205 field)
	{
		Class6210 @class = field as Class6210;
		base.Context.Writer.method_15("Size", @class.Size);
		base.Context.Writer.method_19("Value", @class.Value);
		base.Context.Writer.method_19("PlainText", @class.PlainText);
		base.Context.Writer.method_17("DefaultFont", @class.DefaultFont);
	}

	protected override void vmethod_5(Class6205 field)
	{
		Class6210 @class = field as Class6210;
		if (base.Context.Reader.method_6("IsRichText", out var value))
		{
			@class.IsRichText = value;
		}
		if (base.Context.Reader.method_5("MaxLength", out var value2))
		{
			@class.MaxLength = value2;
		}
		if (base.Context.Reader.method_10("FontColor", out var value3))
		{
			@class.FontColor = value3;
		}
		if (base.Context.Reader.method_6("IsMultiline", out var value4))
		{
			@class.IsMultiline = value4;
		}
		if (base.Context.Reader.method_3("LineHeight", out var value5))
		{
			@class.LineHeight = value5;
		}
		if (base.Context.Reader.method_15("Size", out var value6))
		{
			@class.Size = value6;
		}
		if (base.Context.Reader.method_12("Value", out var value7))
		{
			@class.Value = value7;
		}
		if (base.Context.Reader.method_12("PlainText", out var value8))
		{
			@class.PlainText = value8;
		}
		if (base.Context.Reader.method_25("DefaultFont", out var value9))
		{
			@class.DefaultFont = value9;
		}
	}

	protected override Class6205 vmethod_6()
	{
		return new Class6210();
	}
}
