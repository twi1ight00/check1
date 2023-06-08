using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns235;

namespace ns216;

internal class Class5814 : Class5783, Interface249, Interface250, Interface251, Interface252
{
	internal const string string_4 = "exclGroup";

	internal string Value
	{
		get
		{
			if (base.Nodes.method_3("field") is Class5817 @class && @class.Value != null)
			{
				return @class.Value;
			}
			return string.Empty;
		}
		set
		{
			if (base.Nodes.method_3("field") is Class5817 @class && @class.Value != null)
			{
				@class.Value = value;
			}
		}
	}

	public XfaEnums.Enum706 LayoutType => (XfaEnums.Enum706)method_5("layout").Value;

	public Class5829 Margin
	{
		get
		{
			Class5829 @class = method_6(Class5829.Tag) as Class5829;
			if (@class == null)
			{
				@class = new Class5829();
			}
			return @class;
		}
	}

	public XfaEnums.Enum702 AnchorType => (XfaEnums.Enum702)method_5("anchorType").Value;

	public float X => (float)method_5("x").Value;

	public float Y => (float)method_5("y").Value;

	public float H => (float)method_5("h").Value;

	public float W => (float)method_5("w").Value;

	public float MinH => (float)method_5("minH").Value;

	public float MaxH => (float)method_5("maxH").Value;

	public float MinW => (float)method_5("minW").Value;

	public float MaxW => (float)method_5("maxW").Value;

	public int ColSpan => (int)method_5("colSpan").Value;

	public Class5814()
	{
		Class5906.smethod_6(this, "access", XfaEnums.Enum705.const_0);
		Class5906.smethod_4(this, "accessKey", string.Empty);
		Class5906.smethod_6(this, "anchorType", XfaEnums.Enum702.const_0);
		Class5906.smethod_2(this, "colSpan", 1);
		Class5906.smethod_6(this, "layout", XfaEnums.Enum706.const_0);
		Class5906.smethod_1(this, "maxH", 0f);
		Class5906.smethod_1(this, "maxW", 0f);
		Class5906.smethod_1(this, "minH", 0f);
		Class5906.smethod_1(this, "minW", 0f);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_1(this, "w", 0f);
		Class5906.smethod_1(this, "x", 0f);
		Class5906.smethod_1(this, "y", 0f);
		Class5906.smethod_1(this, "h", 0f);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_67(this);
		base.vmethod_4(visitor);
		visitor.vmethod_68(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5814();
	}

	internal override string vmethod_8()
	{
		return "exclGroup";
	}

	internal override string[] vmethod_10()
	{
		return new string[16]
		{
			Class5787.Tag,
			Class5789.Tag,
			Class5790.Tag,
			Class5795.Tag,
			Class5796.Tag,
			Class5807.Tag,
			Class5816.Tag,
			Class5829.Tag,
			Class5836.Tag,
			Class5853.Tag,
			Class5856.Tag,
			Class5801.Tag,
			Class5813.Tag,
			"field",
			Class5886.Tag,
			Class5893.Tag
		};
	}

	public SizeF imethod_2()
	{
		return SizeF.Empty;
	}

	public void imethod_3(SizeF size)
	{
	}

	public void imethod_4(Class5912 builder, PointF pos, SizeF size)
	{
		Class5842 @class = method_6(Class5842.Tag) as Class5842;
		Class6213 canvas = new Class6213();
		if (@class == null && method_6(Class5893.Tag) is Class5893 class2)
		{
			@class = class2.Nodes.method_3(Class5842.Tag) as Class5842;
		}
		@class?.method_8(canvas, pos, size);
		if (method_6(Class5790.Tag) is Class5790 class3)
		{
			class3.method_8(canvas, pos, size);
		}
		builder.method_5(canvas);
	}
}
