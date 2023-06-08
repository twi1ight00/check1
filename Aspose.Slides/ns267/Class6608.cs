using ns235;

namespace ns267;

internal class Class6608 : Class6598
{
	protected override string RootNodeName => "PathFigure";

	public Class6608(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6218;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6218 @class = node as Class6218;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_24("IsClosed", @class.IsClosed);
	}

	protected override Class6204 vmethod_2()
	{
		Class6218 @class = new Class6218();
		if (base.Context.Reader.method_6("IsClosed", out var value))
		{
			@class.IsClosed = value;
		}
		return @class;
	}
}
