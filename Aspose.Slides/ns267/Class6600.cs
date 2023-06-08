using ns235;

namespace ns267;

internal class Class6600 : Class6599
{
	protected override string RootNodeName => "Button";

	public Class6600(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6206;
	}

	protected override void vmethod_3(Class6205 field)
	{
		base.Context.Writer.method_25("Caption", ((Class6206)field).Caption);
	}

	protected override void vmethod_4(Class6205 field)
	{
		base.Context.Writer.method_15("Size", ((Class6206)field).Size);
	}

	protected override void vmethod_5(Class6205 field)
	{
		Class6206 @class = field as Class6206;
		if (base.Context.Reader.method_11("Caption", out var value))
		{
			@class.Caption = value;
		}
		if (base.Context.Reader.method_15("Size", out var value2))
		{
			@class.Size = value2;
		}
	}

	protected override Class6205 vmethod_6()
	{
		return new Class6206();
	}
}
