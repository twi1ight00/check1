using System.Drawing;
using ns171;
using ns176;

namespace ns190;

internal class Class5139 : Class5137
{
	public Class5139(Class5088 parent)
		: base(parent)
	{
	}

	internal override string vmethod_33()
	{
		return "xsl-region-before";
	}

	public override RectangleF vmethod_32(Class5728 reldims)
	{
		Interface172 @interface = method_49(0);
		Interface172 interface2 = method_50(0);
		Interface172 siblingContext;
		RectangleF rectangleF;
		switch ((Enum679)method_57().method_1())
		{
		default:
			siblingContext = @interface;
			rectangleF = new RectangleF(0f, 0f, reldims.int_0, method_58().imethod_6(interface2));
			break;
		case Enum679.const_227:
		case Enum679.const_292:
			siblingContext = interface2;
			rectangleF = new RectangleF(0f, 0f, method_58().imethod_6(@interface), reldims.int_0);
			break;
		}
		if (method_59() == 48)
		{
			method_60(rectangleF, class5171_0.method_59(), siblingContext);
		}
		return rectangleF;
	}

	public override string vmethod_21()
	{
		return "region-before";
	}

	public override int vmethod_24()
	{
		return 57;
	}
}
