using ns235;

namespace ns267;

internal class Class6601 : Class6599
{
	protected override string RootNodeName => "CheckBox";

	public Class6601(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		if (node is Class6208)
		{
			return false;
		}
		return node is Class6207;
	}

	protected override void vmethod_3(Class6205 field)
	{
		Class6207 @class = field as Class6207;
		base.Context.Writer.method_24("Value", @class.Value);
		base.Context.Writer.method_22("Size", @class.Size);
	}

	protected override void vmethod_4(Class6205 field)
	{
	}

	protected override void vmethod_5(Class6205 field)
	{
		Class6207 @class = field as Class6207;
		if (base.Context.Reader.method_6("Value", out var value))
		{
			@class.Value = value;
		}
		if (base.Context.Reader.method_3("Size", out var value2))
		{
			@class.Size = value2;
		}
	}

	protected override Class6205 vmethod_6()
	{
		return new Class6207();
	}
}
