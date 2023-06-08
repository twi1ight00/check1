using ns235;

namespace ns267;

internal class Class6602 : Class6601
{
	protected override string RootNodeName => "RadioButton";

	public Class6602(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6208;
	}

	protected override Class6205 vmethod_6()
	{
		return new Class6208();
	}
}
