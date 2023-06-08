using System.Collections.Generic;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5809 : Class5783, Interface246, Interface250, Interface251, Interface252
{
	internal const string string_4 = "draw";

	private Class5926 class5926_0;

	private List<Class5783> list_0 = new List<Class5783>();

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

	public XfaEnums.Enum687 Presence => (XfaEnums.Enum687)method_5("presence").Value;

	public float X => (float)method_5("x").Value;

	public float Y => (float)method_5("y").Value;

	public float H => (float)method_5("h").Value;

	public float W => (float)method_5("w").Value;

	public float MinH => (float)method_5("minH").Value;

	public float MaxH => (float)method_5("maxH").Value;

	public float MinW => (float)method_5("minW").Value;

	public float MaxW => (float)method_5("maxW").Value;

	public int ColSpan => (int)method_5("colSpan").Value;

	internal string Value
	{
		get
		{
			if (!(base.Nodes.method_3("value") is Class5893 @class))
			{
				return string.Empty;
			}
			return @class.method_6();
		}
		set
		{
			if (base.Nodes.method_3("value") is Class5893 @class)
			{
				@class.method_8(value);
				Class5817.smethod_2(list_0);
			}
		}
	}

	internal Class5809()
	{
		Class5906.smethod_6(this, "anchorType", XfaEnums.Enum702.const_0);
		Class5906.smethod_2(this, "colSpan", 1);
		Class5906.smethod_1(this, "h", 0f);
		Class5906.smethod_4(this, "locale", string.Empty);
		Class5906.smethod_1(this, "maxH", 0f);
		Class5906.smethod_1(this, "maxW", 0f);
		Class5906.smethod_1(this, "minH", 0f);
		Class5906.smethod_1(this, "minW", 0f);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_1(this, "rotate", 0f);
		Class5906.smethod_1(this, "w", 0f);
		Class5906.smethod_1(this, "x", 0f);
		Class5906.smethod_1(this, "y", 0f);
		class5926_0 = new Class5926(this);
	}

	public override object Clone()
	{
		Class5809 @class = (Class5809)base.Clone();
		@class.class5926_0 = new Class5926(@class);
		return @class;
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_56(this);
		base.vmethod_4(visitor);
		visitor.vmethod_57(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5809();
	}

	internal override string vmethod_8()
	{
		return "draw";
	}

	internal override string[] vmethod_10()
	{
		return new string[13]
		{
			Class5787.Tag,
			Class5790.Tag,
			Class5796.Tag,
			Class5807.Tag,
			Class5816.Tag,
			Class5820.Tag,
			Class5825.Tag,
			Class5829.Tag,
			Class5836.Tag,
			Class5853.Tag,
			Class5855.Tag,
			Class5893.Tag,
			Class5886.Tag
		};
	}

	public void imethod_0(Class5783 element)
	{
		if (!list_0.Contains(element))
		{
			list_0.Add(element);
		}
	}

	public string imethod_1()
	{
		return Value;
	}

	public SizeF imethod_2()
	{
		return class5926_0.method_2();
	}

	public SizeF method_8()
	{
		class5926_0.method_0();
		return class5926_0.method_2();
	}

	public void imethod_3(SizeF size)
	{
		method_5("w").Value = size.Width;
		method_5("h").Value = size.Height;
		class5926_0.method_0();
		imethod_2();
	}

	public void imethod_4(Class5912 builder, PointF pos, SizeF size)
	{
		class5926_0.method_3(builder, pos, size);
	}
}
