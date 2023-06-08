using ns235;

namespace ns267;

internal class Class6606 : Class6598
{
	protected override string RootNodeName => "Canvas";

	public Class6606(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6213;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6213 @class = node as Class6213;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		if (@class.RenderTransform != null)
		{
			base.Context.Writer.method_26("RenderTransform", @class.RenderTransform);
		}
		if (@class.Clip != null)
		{
			base.Context.Writer.method_8("Clip", @class.Clip);
		}
		if (@class.Hyperlink != null)
		{
			base.Context.Writer.method_12("Hyperlink", @class.Hyperlink);
		}
	}

	protected override Class6204 vmethod_2()
	{
		Class6213 @class = new Class6213();
		if (base.Context.Reader.method_9("RenderTransform", out var value))
		{
			@class.RenderTransform = value;
		}
		if (base.Context.Reader.method_22("Clip", out var value2))
		{
			@class.Clip = value2;
		}
		if (base.Context.Reader.method_19("Hyperlink", out var value3))
		{
			@class.Hyperlink = value3;
		}
		return @class;
	}
}
