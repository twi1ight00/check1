using ns235;

namespace ns267;

internal class Class6604 : Class6599
{
	protected override string RootNodeName => "ComboBox";

	public Class6604(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6209;
	}

	protected override void vmethod_3(Class6205 field)
	{
		base.Context.Writer.method_23("Value", ((Class6209)field).Value);
	}

	protected override void vmethod_4(Class6205 field)
	{
		Class6209 @class = field as Class6209;
		base.Context.Writer.method_17("DefaultFont", @class.DefaultFont);
		string[] array = new string[@class.Items.Count];
		@class.Items.CopyTo(array);
		base.Context.Writer.method_20("Items", array);
		base.Context.Writer.method_15("Size", @class.Size);
	}

	protected override void vmethod_5(Class6205 field)
	{
		Class6209 @class = field as Class6209;
		if (base.Context.Reader.method_5("Value", out var value))
		{
			@class.Value = value;
		}
		if (base.Context.Reader.method_27("Items", out var value2))
		{
			@class.Items = value2;
		}
		if (base.Context.Reader.method_15("Size", out var value3))
		{
			@class.Size = value3;
		}
		if (base.Context.Reader.method_25("DefaultFont", out var value4))
		{
			@class.DefaultFont = value4;
		}
	}

	protected override Class6205 vmethod_6()
	{
		return new Class6209();
	}
}
