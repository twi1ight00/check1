using Aspose.Slides;
using Aspose.Slides.Export;
using ns11;

namespace ns12;

internal class Class184 : Interface3
{
	private ISvgShapeFormattingController isvgShapeFormattingController_0;

	private Class163 class163_0;

	public Class184(Class163 canvas, ISvgShapeFormattingController svgShapeFormattingController)
	{
		class163_0 = canvas;
		isvgShapeFormattingController_0 = svgShapeFormattingController;
	}

	public void imethod_0(Shape shape)
	{
		SvgShape svgShape = new SvgShape();
		if (isvgShapeFormattingController_0 != null)
		{
			isvgShapeFormattingController_0.FormatShape(svgShape, shape);
		}
		class163_0.method_46(shape, svgShape);
	}

	public void imethod_1(Shape shape)
	{
		class163_0.method_47(shape);
	}
}
