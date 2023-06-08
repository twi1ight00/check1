using ns235;

namespace ns267;

internal class Class6612 : Class6598
{
	protected override string RootNodeName => "Bookmark";

	public Class6612(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6211;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6211 @class = node as Class6211;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_25("Name", @class.Name);
		base.Context.Writer.method_14("Origin", @class.Origin);
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_11("Name", out var value) && base.Context.Reader.method_14("Origin", out var value2))
		{
			return new Class6211(value2, value);
		}
		return null;
	}
}
