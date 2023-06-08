using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace ns19;

internal abstract class Class1039 : Interface42
{
	protected Graphics graphics_0;

	protected Interface43 interface43_0;

	public Class1039()
	{
	}

	public Class1039(Graphics graphics_1)
	{
		graphics_0 = graphics_1;
	}

	[SpecialName]
	public Interface43 imethod_0()
	{
		return interface43_0;
	}

	[SpecialName]
	public void imethod_1(Interface43 interface43_1)
	{
		interface43_0 = interface43_1;
	}

	public abstract void imethod_2();

	public abstract Bitmap imethod_3();

	public abstract void vmethod_0();

	public abstract void Dispose();

	public void imethod_4(Pen pen_0, RectangleF rectangleF_0, float float_0, float float_1)
	{
		graphics_0.DrawArc(pen_0, rectangleF_0, float_0, float_1);
	}

	public void imethod_5(Pen pen_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		graphics_0.DrawArc(pen_0, float_0, float_1, float_2, float_3, float_4, float_5);
	}

	public void imethod_6(Pen pen_0, PointF[] pointF_0)
	{
		graphics_0.DrawCurve(pen_0, pointF_0);
	}

	public void imethod_7(Pen pen_0, PointF[] pointF_0, float float_0)
	{
		graphics_0.DrawCurve(pen_0, pointF_0, float_0);
	}

	public void imethod_8(Pen pen_0, PointF[] pointF_0, int int_0, int int_1, float float_0)
	{
		graphics_0.DrawCurve(pen_0, pointF_0, int_0, int_1, float_0);
	}

	public void imethod_9(Pen pen_0, RectangleF rectangleF_0)
	{
		graphics_0.DrawEllipse(pen_0, rectangleF_0);
	}

	public void imethod_10(Pen pen_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.DrawEllipse(pen_0, float_0, float_1, float_2, float_3);
	}

	public void imethod_11(Image image_0, int int_0, int int_1, int int_2, int int_3)
	{
		graphics_0.DrawImage(image_0, int_0, int_1, int_2, int_3);
	}

	public void imethod_12(Image image_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.DrawImage(image_0, float_0, float_1, float_2, float_3);
	}

	public void imethod_13(Image image_0, Rectangle rectangle_0, float float_0, float float_1, float float_2, float float_3, GraphicsUnit graphicsUnit_0)
	{
		graphics_0.DrawImage(image_0, rectangle_0, float_0, float_1, float_2, float_3, graphicsUnit_0);
	}

	public void imethod_14(Image image_0, RectangleF rectangleF_0, RectangleF rectangleF_1, GraphicsUnit graphicsUnit_0)
	{
		graphics_0.DrawImage(image_0, rectangleF_0, rectangleF_1, graphicsUnit_0);
	}

	public void imethod_15(Pen pen_0, PointF pointF_0, PointF pointF_1)
	{
		graphics_0.DrawLine(pen_0, pointF_0, pointF_1);
	}

	public void imethod_16(Pen pen_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.DrawLine(pen_0, float_0, float_1, float_2, float_3);
	}

	public void imethod_17(Pen pen_0, PointF[] pointF_0)
	{
		graphics_0.DrawLines(pen_0, pointF_0);
	}

	public void imethod_18(Pen pen_0, GraphicsPath graphicsPath_0)
	{
		graphics_0.DrawPath(pen_0, graphicsPath_0);
	}

	public void imethod_19(Pen pen_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		graphics_0.DrawPie(pen_0, float_0, float_1, float_2, float_3, float_4, float_5);
	}

	public void imethod_20(Pen pen_0, PointF[] pointF_0)
	{
		graphics_0.DrawPolygon(pen_0, pointF_0);
	}

	public void imethod_21(Pen pen_0, Rectangle rectangle_0)
	{
		graphics_0.DrawRectangle(pen_0, rectangle_0);
	}

	public void imethod_22(Pen pen_0, int int_0, int int_1, int int_2, int int_3)
	{
		graphics_0.DrawRectangle(pen_0, int_0, int_1, int_2, int_3);
	}

	public void imethod_23(Pen pen_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.DrawRectangle(pen_0, float_0, float_1, float_2, float_3);
	}

	public void imethod_24(string string_0, Font font_0, Brush brush_0, PointF pointF_0)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, pointF_0);
	}

	public void imethod_25(string string_0, Font font_0, Brush brush_0, RectangleF rectangleF_0)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, rectangleF_0);
	}

	public void imethod_26(string string_0, Font font_0, Brush brush_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, pointF_0, stringFormat_0);
	}

	public void imethod_27(string string_0, Font font_0, Brush brush_0, RectangleF rectangleF_0, StringFormat stringFormat_0)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, rectangleF_0, stringFormat_0);
	}

	public void imethod_29(string string_0, Font font_0, Brush brush_0, float float_0, float float_1)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, float_0, float_1);
	}

	public void imethod_30(string string_0, Font font_0, Brush brush_0, float float_0, float float_1, StringFormat stringFormat_0)
	{
		graphics_0.DrawString(string_0, font_0, brush_0, float_0, float_1, stringFormat_0);
	}

	public void imethod_28(string string_0, Font font_0, Brush brush_0, Rectangle rectangle_0, StringFormat stringFormat_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		imethod_27(string_0, font_0, brush_0, rectangleF_, stringFormat_0);
	}

	public void imethod_31(Brush brush_0, RectangleF rectangleF_0)
	{
		graphics_0.FillEllipse(brush_0, rectangleF_0);
	}

	public void imethod_32(Brush brush_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.FillEllipse(brush_0, float_0, float_1, float_2, float_3);
	}

	public void imethod_33(Brush brush_0, GraphicsPath graphicsPath_0)
	{
		graphics_0.FillPath(brush_0, graphicsPath_0);
	}

	public void imethod_34(Brush brush_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
	{
		graphics_0.FillPie(brush_0, float_0, float_1, float_2, float_3, float_4, float_5);
	}

	public void imethod_35(Brush brush_0, PointF[] pointF_0)
	{
		graphics_0.FillPolygon(brush_0, pointF_0);
	}

	public void imethod_36(Brush brush_0, Rectangle rectangle_0)
	{
		graphics_0.FillRectangle(brush_0, rectangle_0);
	}

	public void imethod_37(Brush brush_0, RectangleF rectangleF_0)
	{
		graphics_0.FillRectangle(brush_0, rectangleF_0);
	}

	public void imethod_38(Brush brush_0, float float_0, float float_1, float float_2, float float_3)
	{
		graphics_0.FillRectangle(brush_0, float_0, float_1, float_2, float_3);
	}

	public SizeF imethod_39(string string_0, Font font_0)
	{
		return graphics_0.MeasureString(string_0, font_0);
	}

	public SizeF imethod_40(string string_0, Font font_0, SizeF sizeF_0)
	{
		return graphics_0.MeasureString(string_0, font_0, sizeF_0);
	}

	public SizeF imethod_41(string string_0, Font font_0, PointF pointF_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, pointF_0, stringFormat_0);
	}

	public SizeF imethod_42(string string_0, Font font_0, SizeF sizeF_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, sizeF_0, stringFormat_0);
	}

	public SizeF imethod_43(string string_0, Font font_0, int int_0, StringFormat stringFormat_0)
	{
		return graphics_0.MeasureString(string_0, font_0, int_0, stringFormat_0);
	}

	public void ResetClip()
	{
		graphics_0.ResetClip();
	}

	public void ResetTransform()
	{
		graphics_0.ResetTransform();
	}

	public void imethod_44(GraphicsState graphicsState_0)
	{
		graphics_0.Restore(graphicsState_0);
	}

	public void imethod_45(float float_0)
	{
		graphics_0.RotateTransform(float_0);
	}

	public GraphicsState Save()
	{
		return graphics_0.Save();
	}

	public void imethod_46(float float_0, float float_1)
	{
		graphics_0.ScaleTransform(float_0, float_1);
	}

	public void imethod_47(Rectangle rectangle_0)
	{
		graphics_0.SetClip(rectangle_0);
	}

	public void imethod_48(RectangleF rectangleF_0)
	{
		graphics_0.SetClip(rectangleF_0);
	}

	public void imethod_49(float float_0, float float_1)
	{
		graphics_0.TranslateTransform(float_0, float_1);
	}

	[SpecialName]
	public RectangleF imethod_50()
	{
		return graphics_0.ClipBounds;
	}

	[SpecialName]
	public float imethod_51()
	{
		return graphics_0.DpiX;
	}

	[SpecialName]
	public float imethod_52()
	{
		return graphics_0.DpiY;
	}

	[SpecialName]
	public GraphicsUnit imethod_53()
	{
		return graphics_0.PageUnit;
	}

	[SpecialName]
	public SmoothingMode imethod_54()
	{
		return graphics_0.SmoothingMode;
	}

	[SpecialName]
	public void imethod_55(SmoothingMode smoothingMode_0)
	{
		graphics_0.SmoothingMode = smoothingMode_0;
	}

	[SpecialName]
	public TextRenderingHint imethod_56()
	{
		return graphics_0.TextRenderingHint;
	}

	[SpecialName]
	public void imethod_57(TextRenderingHint textRenderingHint_0)
	{
		graphics_0.TextRenderingHint = textRenderingHint_0;
	}

	[SpecialName]
	public void imethod_58(Matrix matrix_0)
	{
		graphics_0.Transform = matrix_0;
	}

	[SpecialName]
	public CompositingQuality imethod_59()
	{
		return graphics_0.CompositingQuality;
	}

	[SpecialName]
	public void imethod_60(CompositingQuality compositingQuality_0)
	{
		graphics_0.CompositingQuality = compositingQuality_0;
	}

	[SpecialName]
	public int imethod_61()
	{
		return graphics_0.TextContrast;
	}

	[SpecialName]
	public void imethod_62(int int_0)
	{
		graphics_0.TextContrast = int_0;
	}
}
