using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2569
{
	private static readonly Class1151 class1151_0 = new Class1151("textNoShape", "textPlain", "textStop", "textTriangle", "textTriangleInverted", "textChevron", "textChevronInverted", "textRingInside", "textRingOutside", "textArchUp", "textArchDown", "textCircle", "textButton", "textArchUpPour", "textArchDownPour", "textCirclePour", "textButtonPour", "textCurveUp", "textCurveDown", "textCanUp", "textCanDown", "textWave1", "textWave2", "textDoubleWave1", "textWave4", "textInflate", "textDeflate", "textInflateBottom", "textDeflateBottom", "textInflateTop", "textDeflateTop", "textDeflateInflate", "textDeflateInflateDeflate", "textFadeRight", "textFadeLeft", "textFadeUp", "textFadeDown", "textSlantUp", "textSlantDown", "textCascadeUp", "textCascadeDown");

	public static TextShapeType smethod_0(string xmlValue)
	{
		return (TextShapeType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextShapeType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
