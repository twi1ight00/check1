using ns235;

namespace ns267;

internal class Class6611 : Class6598
{
	protected override string RootNodeName => "Group";

	public Class6611(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6215;
	}

	public override void vmethod_1(Class6204 node)
	{
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
	}

	protected override Class6204 vmethod_2()
	{
		return new Class6215();
	}
}
