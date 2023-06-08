using ns235;

namespace ns267;

internal class Class6613 : Class6598
{
	protected override string RootNodeName => "OutlineItem";

	public Class6613(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6221;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6221 @class = node as Class6221;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_25("Title", @class.Title);
		base.Context.Writer.method_23("Level", @class.Level);
		base.Context.Writer.method_14("Origin", @class.Origin);
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_11("Title", out var value) && base.Context.Reader.method_14("Origin", out var value2) && base.Context.Reader.method_5("Level", out var value3))
		{
			return new Class6221(value2, value3, value);
		}
		return null;
	}
}
