using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;

namespace ns2;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct30
{
	internal static void smethod_0(Class784 renderContext, Rectangle rect, IFormat format)
	{
		if (rect.Width <= 0 || rect.Height <= 0)
		{
			return;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
		if (format.Fill.FillType == FillType.Solid)
		{
			Color color;
			if (format.Fill.SolidFillColor.SchemeColor != SchemeColor.NotDefined)
			{
				ColorFormat colorFormat = ((Slide)renderContext.Chart.Slide).method_2(format.Fill.SolidFillColor.SchemeColor);
				((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)format.Fill.SolidFillColor.ColorTransform).list_0;
				color = colorFormat.Color;
			}
			else
			{
				color = format.Fill.SolidFillColor.Color;
			}
			Brush brush = new SolidBrush(color);
			renderContext.Graphics.imethod_77(brush, graphicsPath);
			brush.Dispose();
		}
		graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
		if (format.Line.FillFormat.FillType == FillType.Solid && format.Line.Width > 0.0)
		{
			GraphicsPath path = (GraphicsPath)graphicsPath.Clone();
			Color color2;
			if (format.Line.FillFormat.SolidFillColor.SchemeColor != SchemeColor.NotDefined)
			{
				ColorFormat colorFormat2 = ((Slide)renderContext.Chart.Slide).method_2(format.Line.FillFormat.SolidFillColor.SchemeColor);
				((ColorOperationCollection)colorFormat2.ColorTransform).list_0 = ((ColorOperationCollection)format.Line.FillFormat.SolidFillColor.ColorTransform).list_0;
				color2 = colorFormat2.Color;
			}
			else
			{
				color2 = format.Line.FillFormat.SolidFillColor.Color;
			}
			Pen pen = new Pen(color2, (float)format.Line.Width);
			smethod_1(pen, format.Line.DashStyle);
			renderContext.Graphics.imethod_45(pen, path);
			pen.Dispose();
		}
	}

	internal static void smethod_1(Pen pen, LineDashStyle dashStyle)
	{
		pen.DashCap = DashCap.Round;
		switch (dashStyle)
		{
		case LineDashStyle.Solid:
			pen.DashStyle = DashStyle.Solid;
			break;
		case LineDashStyle.Dash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 4f, 3f };
			break;
		case LineDashStyle.LargeDash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 8f, 3f };
			break;
		case LineDashStyle.DashDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDotDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		case LineDashStyle.Dot:
			break;
		case LineDashStyle.SystemDash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 3f, 1f };
			break;
		case LineDashStyle.SystemDot:
			pen.DashStyle = DashStyle.Dot;
			pen.DashCap = DashCap.Round;
			break;
		}
	}
}
