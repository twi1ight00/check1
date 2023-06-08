using System.Collections.Generic;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;

namespace ns216;

internal class Class5817 : Class5783, Interface246, Interface250, Interface251, Interface252
{
	internal const string string_4 = "field";

	private Class5926 class5926_0;

	private List<Class5783> list_0 = new List<Class5783>();

	public XfaEnums.Enum705 Access => (XfaEnums.Enum705)method_5("access").Value;

	public XfaEnums.Enum687 Presence => (XfaEnums.Enum687)method_5("presence").Value;

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

	internal string Value
	{
		get
		{
			if (base.Nodes.method_3("value") is Class5893 @class)
			{
				return @class.method_6();
			}
			if (base.Nodes.method_3("items") is Class5824 class2 && class2.Nodes.Length > 0)
			{
				return class2.method_8();
			}
			return null;
		}
		set
		{
			Class5893 @class = base.Nodes.method_3("value") as Class5893;
			if (@class == null)
			{
				Class5782 class2 = Class5929.Instance.CreateElement(Class5893.Tag);
				@class = (Class5893)class2.vmethod_7();
				@class.Parent = this;
				@class.method_7();
				base.Nodes.method_0(@class);
			}
			@class.method_8(value);
			smethod_2(list_0);
		}
	}

	public override object Clone()
	{
		Class5817 @class = (Class5817)base.Clone();
		@class.class5926_0 = new Class5926(@class);
		return @class;
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_75(this);
		base.vmethod_4(visitor);
		visitor.vmethod_76(this);
	}

	internal Class5817()
	{
		class5926_0 = new Class5926(this);
		Class5906.smethod_6(this, "access", XfaEnums.Enum705.const_0);
		Class5906.smethod_4(this, "accessKey", string.Empty);
		Class5906.smethod_6(this, "anchorType", XfaEnums.Enum702.const_0);
		Class5906.smethod_2(this, "colSpan", 1);
		Class5906.smethod_1(this, "h", 0f);
		Class5906.smethod_1(this, "w", 0f);
		Class5906.smethod_1(this, "x", 0f);
		Class5906.smethod_1(this, "y", 0f);
		Class5906.smethod_1(this, "maxH", 0f);
		Class5906.smethod_1(this, "maxW", 0f);
		Class5906.smethod_1(this, "minH", 0f);
		Class5906.smethod_1(this, "minW", 0f);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_1(this, "rotate", 0f);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5817();
	}

	internal override string vmethod_8()
	{
		return "field";
	}

	internal override string[] vmethod_10()
	{
		return new string[21]
		{
			Class5787.Tag,
			Class5789.Tag,
			Class5790.Tag,
			Class5795.Tag,
			Class5796.Tag,
			Class5807.Tag,
			Class5816.Tag,
			Class5820.Tag,
			Class5821.Tag,
			Class5824.Tag,
			Class5825.Tag,
			Class5829.Tag,
			Class5836.Tag,
			Class5853.Tag,
			Class5855.Tag,
			Class5856.Tag,
			Class5859.Tag,
			Class5801.Tag,
			Class5813.Tag,
			Class5886.Tag,
			Class5893.Tag
		};
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
		if (Presence != XfaEnums.Enum687.const_3)
		{
			class5926_0.method_3(builder, pos, size);
		}
	}

	internal static void smethod_2(List<Class5783> embededRefereces)
	{
		foreach (Class5783 embededReferece in embededRefereces)
		{
			if (embededReferece is Class5817 @class)
			{
				@class.method_8();
			}
			else if (embededReferece is Class5809 class2)
			{
				class2.method_8();
			}
		}
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

	internal Class5848 method_9()
	{
		Class5781 parent = base.Parent;
		while (true)
		{
			if (parent != null)
			{
				if (parent is Class5848)
				{
					break;
				}
				parent = parent.Parent;
				continue;
			}
			return null;
		}
		return (Class5848)parent;
	}
}
