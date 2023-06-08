using System.IO;
using ns235;

namespace ns267;

internal class Class6614 : Class6598
{
	protected override string RootNodeName => "Glyphs";

	public Class6614(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6219;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6219 @class = node as Class6219;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		base.Context.Writer.method_28("Color", @class.Color);
		base.Context.Writer.method_28("OutlineColor", @class.OutlineColor);
		base.Context.Writer.method_22("OutlineWidth", @class.OutlineWidth);
		base.Context.Writer.method_22("CharSpace", @class.CharSpace);
		if (@class.RenderTransform != null)
		{
			base.Context.Writer.method_26("RenderTransform", @class.RenderTransform);
		}
		base.Context.Writer.method_17("Font", @class.Font);
		base.Context.Writer.method_14("Origin", @class.Origin);
		base.Context.Writer.method_19("Text", @class.Text);
		base.Context.Writer.method_15("Size", @class.Size);
		if (@class.Clip != null)
		{
			base.Context.Writer.method_8("Clip", @class.Clip);
		}
		if (@class.Hyperlink != null)
		{
			base.Context.Writer.method_12("Hyperlink", @class.Hyperlink);
		}
		if (@class.Indices != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			@class.Indices.method_0(memoryStream);
			base.Context.Writer.method_18("Indices", memoryStream.ToArray());
		}
		if (@class.Tag != null && @class.Tag is string)
		{
			base.Context.Writer.method_19("Tag", (string)@class.Tag);
		}
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_25("Font", out var value) && base.Context.Reader.method_10("Color", out var value2) && base.Context.Reader.method_10("OutlineColor", out var value3) && base.Context.Reader.method_14("Origin", out var value4) && base.Context.Reader.method_12("Text", out var value5) && base.Context.Reader.method_15("Size", out var value6) && base.Context.Reader.method_3("CharSpace", out var value7))
		{
			Class6219 @class = new Class6219(value, value2, value3, value4, value5, value6, value7);
			if (base.Context.Reader.method_9("RenderTransform", out var value8))
			{
				@class.RenderTransform = value8;
			}
			if (base.Context.Reader.method_22("Clip", out var value9))
			{
				@class.Clip = value9;
			}
			if (base.Context.Reader.method_19("Hyperlink", out var value10))
			{
				@class.Hyperlink = value10;
			}
			if (base.Context.Reader.method_26("Indices", out var value11))
			{
				Class6265 class2 = new Class6265();
				class2.method_2(new MemoryStream(value11));
				if (!class2.method_1())
				{
					@class.Indices = class2;
				}
			}
			if (base.Context.Reader.method_12("Tag", out var value12))
			{
				@class.Tag = value12;
			}
			return @class;
		}
		return null;
	}
}
