using System;
using System.Drawing.Drawing2D;
using ns235;

namespace ns267;

internal class Class6607 : Class6598
{
	protected override string RootNodeName => "Path";

	public Class6607(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6217;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6217 @class = node as Class6217;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_27("FillMode", @class.FillMode);
		if (@class.RenderTransform != null)
		{
			base.Context.Writer.method_26("RenderTransform", @class.RenderTransform);
		}
		if (@class.Brush != null)
		{
			base.Context.Writer.method_9("Brush", @class.Brush);
		}
		if (@class.Clip != null)
		{
			base.Context.Writer.method_8("Clip", @class.Clip);
		}
		if (@class.Pen != null)
		{
			base.Context.Writer.method_16("Pen", @class.Pen);
		}
		if (@class.Hyperlink != null)
		{
			base.Context.Writer.method_12("Hyperlink", @class.Hyperlink);
		}
	}

	protected override Class6204 vmethod_2()
	{
		Class6217 @class = new Class6217();
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
		if (base.Context.Reader.method_23("Pen", out var value4))
		{
			@class.Pen = value4;
		}
		if (base.Context.Reader.method_24("Brush", out var value5))
		{
			@class.Brush = value5;
		}
		Enum value6 = FillMode.Alternate;
		if (base.Context.Reader.method_7("FillMode", ref value6))
		{
			@class.FillMode = (FillMode)(object)value6;
		}
		return @class;
	}
}
