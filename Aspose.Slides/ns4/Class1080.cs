using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class1080
{
	internal static Slide smethod_0(Presentation pres)
	{
		Slide slide = new Slide(pres);
		slide.PPTXUnsupportedProps.SlideId = pres.PPTXUnsupportedProps.method_0();
		slide.Hidden = false;
		slide.groupShape_0.RawFrameImpl.vmethod_0(0.0, 0.0, 0.0, 0.0);
		slide.groupShape_0.RawFrameImpl.ChildRect = new RectangleF(0f, 0f, 0f, 0f);
		slide.groupShape_0.effectFormat_0 = new EffectFormat(slide.groupShape_0);
		slide.groupShape_0.AlternativeText = "";
		slide.groupShape_0.Name = "";
		return slide;
	}
}
