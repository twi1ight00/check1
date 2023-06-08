using System.Drawing;
using ns171;
using ns176;

namespace ns190;

internal class Class5142 : Class5140
{
	public Class5142(Class5088 parent)
		: base(parent)
	{
	}

	public override RectangleF vmethod_32(Class5728 reldims)
	{
		Interface172 @interface = method_49(0);
		Interface172 interface2 = method_50(0);
		Interface172 siblingContext;
		RectangleF rectangleF;
		switch ((Enum679)method_57().method_1())
		{
		case Enum679.const_208:
			siblingContext = interface2;
			rectangleF = new RectangleF(reldims.int_0 - method_58().imethod_6(@interface), 0f, method_58().imethod_6(@interface), reldims.int_1);
			break;
		default:
			siblingContext = interface2;
			rectangleF = new RectangleF(0f, 0f, method_58().imethod_6(@interface), reldims.int_1);
			break;
		case Enum679.const_227:
		case Enum679.const_292:
			siblingContext = @interface;
			rectangleF = new RectangleF(0f, 0f, reldims.int_1, method_58().imethod_6(interface2));
			break;
		}
		method_59(rectangleF, class5171_0.method_59(), siblingContext);
		return rectangleF;
	}

	internal override string vmethod_33()
	{
		return "xsl-region-start";
	}

	public override string vmethod_21()
	{
		return "region-start";
	}

	public override int vmethod_24()
	{
		return 61;
	}
}
