using Aspose.Slides;
using Aspose.Slides.Export;
using ns11;

namespace ns12;

internal class Class182 : Interface3
{
	private IHtmlFormattingController ihtmlFormattingController_0;

	private ISvgShapeFormattingController isvgShapeFormattingController_0;

	private Class163 class163_0;

	private HtmlGenerator htmlGenerator_0;

	public Class182(Class163 canvas, HtmlGenerator generator, IHtmlFormattingController htmlFormattingController, ISvgShapeFormattingController svgShapeFormattingController)
	{
		class163_0 = canvas;
		htmlGenerator_0 = generator;
		ihtmlFormattingController_0 = htmlFormattingController;
		isvgShapeFormattingController_0 = svgShapeFormattingController;
	}

	public void imethod_0(Shape shape)
	{
		ihtmlFormattingController_0.WriteShapeStart(htmlGenerator_0, shape);
		method_0();
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
		ihtmlFormattingController_0.WriteShapeEnd(htmlGenerator_0, shape);
		method_0();
	}

	private void method_0()
	{
		if (htmlGenerator_0.ContainsHtml)
		{
			if (class163_0.HasSomethingRendered)
			{
				class163_0.method_10(htmlGenerator_0.TextWriter, writingXml: false);
				class163_0.method_11();
			}
			htmlGenerator_0.Flush();
		}
	}
}
