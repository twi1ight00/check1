using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns33;
using ns4;

namespace ns11;

internal class Class162 : Class161
{
	private List<GraphicsPath> list_0;

	private List<RectangleF> list_1;

	private List<Class151> list_2;

	public List<GraphicsPath> CharPaths => list_0;

	public List<RectangleF> CharCoordinates => list_1;

	public List<Class151> CharParameters => list_2;

	public Class162(int canvasWidth, int canvasHeight, float dpiX, float dpiY)
		: base(canvasWidth, canvasHeight, dpiX, dpiY)
	{
		list_0 = new List<GraphicsPath>();
		list_1 = new List<RectangleF>();
		list_2 = new List<Class151>();
	}

	public override void vmethod_5(GraphicsPath graphicsPath, Class66 lineParam, Class63 fillParam)
	{
		throw new NotImplementedException();
	}

	public override void vmethod_6(Image img, int x, int y)
	{
		throw new NotImplementedException();
	}

	public override void vmethod_13(string text, RectangleF rect, Class151 textParam)
	{
		Font font = textParam.method_1().Font;
		FontStyle style = font.Style;
		FontFamily fontFamily = font.FontFamily;
		float num = textParam.FFontHeight;
		float num2 = (float)fontFamily.GetCellAscent(style) / (float)fontFamily.GetLineSpacing(style) * font.GetHeight(graphics_0);
		rect.Y -= num2 + num * (float)textParam.Escapement / 100f;
		if (textParam.Escapement != 0)
		{
			num *= 0.66f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(text, font.FontFamily, (int)style, num, rect.Location, stringFormat_0);
		if (class6002_1 != null)
		{
			graphicsPath.Transform(Class1170.smethod_3(class6002_1));
			rect = class6002_1.method_4(rect);
		}
		list_0.Add(graphicsPath);
		list_1.Add(rect);
		list_2.Add(textParam);
	}

	public override void vmethod_20(IPPImage image, RectangleF rectangle, RectangleF sourceRectangle, Class65 imageParam)
	{
		throw new NotImplementedException();
	}
}
