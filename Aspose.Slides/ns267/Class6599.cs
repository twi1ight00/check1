using ns235;

namespace ns267;

internal abstract class Class6599 : Class6598
{
	public Class6599(Class6616 context)
		: base(context)
	{
	}

	protected abstract void vmethod_3(Class6205 field);

	protected abstract void vmethod_4(Class6205 field);

	protected abstract void vmethod_5(Class6205 field);

	protected abstract Class6205 vmethod_6();

	public override void vmethod_1(Class6204 node)
	{
		Class6205 @class = node as Class6205;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_25("Name", @class.Name);
		base.Context.Writer.method_24("IsEnabled", @class.IsEnabled);
		base.Context.Writer.method_25("Action", @class.Action);
		base.Context.Writer.method_24("UseCustomDraw", @class.UseCustomDraw);
		vmethod_3(@class);
		if (@class.UseCustomDraw && @class.CustomDraw != null)
		{
			base.Context.Writer.method_0("CustomDraw");
			method_3(@class.CustomDraw);
		}
		base.Context.Writer.method_14("Origin", @class.Origin);
		vmethod_4(@class);
	}

	private void method_2(Class6204 node)
	{
		base.Context.method_2(node).vmethod_1(node);
		if (node is Class6212 node2)
		{
			method_3(node2);
		}
		base.Context.Writer.method_2();
	}

	private void method_3(Class6212 node)
	{
		for (int i = 0; i < node.Count; i++)
		{
			method_2(node[i]);
		}
	}

	internal void method_4(Class6205 field)
	{
		if (!base.Context.Reader.method_1())
		{
			return;
		}
		do
		{
			if (base.Context.Reader.CurrentElement.Name == "Canvas")
			{
				Class6598 @class = base.Context.method_3("Canvas");
				if (@class != null)
				{
					field.CustomDraw = @class.method_1() as Class6213;
				}
				break;
			}
		}
		while (base.Context.Reader.method_0());
		base.Context.Reader.method_2();
	}

	protected override Class6204 vmethod_2()
	{
		Class6205 @class = vmethod_6();
		if (base.Context.Reader.method_11("Name", out var value))
		{
			@class.method_0(value);
		}
		if (base.Context.Reader.method_6("IsEnabled", out var value2))
		{
			@class.IsEnabled = value2;
		}
		if (base.Context.Reader.method_11("Action", out var value3))
		{
			@class.Action = value3;
		}
		if (base.Context.Reader.method_14("Origin", out var value4))
		{
			@class.Origin = value4;
		}
		method_4(@class);
		vmethod_5(@class);
		return @class;
	}
}
