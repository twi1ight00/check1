using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5802 : Class5783, Interface250, Interface251, Interface252
{
	internal static string Tag => "contentArea";

	float Interface250.Y => Y;

	float Interface250.H => H;

	float Interface250.W => W;

	public float MinH => 0f;

	public float MaxH => 0f;

	public float MinW => 0f;

	public float MaxW => 0f;

	public int ColSpan => 0;

	internal float H => (float)method_5("h").Value;

	internal float W => (float)method_5("w").Value;

	public Class5829 Margin => null;

	public XfaEnums.Enum702 AnchorType => XfaEnums.Enum702.const_0;

	float Interface250.X => X;

	internal float X => (float)method_5("x").Value;

	internal float Y => (float)method_5("y").Value;

	public Class5802()
	{
		Class5906.smethod_1(this, "h", 0f);
		Class5906.smethod_1(this, "w", 0f);
		Class5906.smethod_1(this, "x", 0f);
		Class5906.smethod_1(this, "y", 0f);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_40(this);
		base.vmethod_4(visitor);
		visitor.vmethod_41(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5802();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5807.Tag,
			Class5816.Tag
		};
	}

	public SizeF imethod_2()
	{
		return vmethod_9(new SizeF(W, H));
	}

	public void imethod_3(SizeF size)
	{
	}

	public void imethod_4(Class5912 builder, PointF pos, SizeF size)
	{
	}
}
