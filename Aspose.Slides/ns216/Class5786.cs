using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5786 : Class5783, Interface249, Interface250, Interface251, Interface252
{
	internal static string Tag => "area";

	public XfaEnums.Enum706 LayoutType => XfaEnums.Enum706.const_0;

	public Class5829 Margin => new Class5829();

	public XfaEnums.Enum702 AnchorType => XfaEnums.Enum702.const_0;

	public float X => (float)method_5("x").Value;

	public float Y => (float)method_5("y").Value;

	public float H
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float W
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float MinH => 0f;

	public float MaxH => 0f;

	public float MinW => 0f;

	public float MaxW => 0f;

	public int ColSpan => (int)method_5("colSpan").Value;

	public Class5786()
	{
		Class5906.smethod_2(this, "colSpan", 1);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_1(this, "x", 0f);
		Class5906.smethod_1(this, "y", 0f);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_3(this);
		base.vmethod_4(visitor);
		visitor.vmethod_4(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5786();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[9]
		{
			Class5807.Tag,
			Class5816.Tag,
			Tag,
			"draw",
			Class5815.Tag,
			"exclGroup",
			"field",
			"subform",
			Class5849.Tag
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
	}
}
