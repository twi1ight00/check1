using System.Drawing;
using ns235;

namespace ns267;

internal class Class6605 : Class6598
{
	protected override string RootNodeName => "Page";

	public Class6605(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6216;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6216 @class = node as Class6216;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_22("Width", @class.Size.Width);
		base.Context.Writer.method_22("Height", @class.Size.Height);
		base.Context.Writer.method_23("PaperTray", @class.PaperTray);
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_3("Width", out var value) && base.Context.Reader.method_3("Height", out var value2))
		{
			if (base.Context.Reader.method_5("PaperTray", out var value3))
			{
				return new Class6216(new SizeF(value, value2), value3);
			}
			return new Class6216(value, value2);
		}
		return null;
	}
}
