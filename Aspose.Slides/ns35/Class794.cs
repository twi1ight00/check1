using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using ns33;

namespace ns35;

internal abstract class Class794 : Interface32
{
	protected Graphics graphics_0;

	protected Interface34 interface34_0;

	public Interface34 GraphicsTools
	{
		get
		{
			return interface34_0;
		}
		set
		{
			interface34_0 = value;
		}
	}

	public Region Clip
	{
		get
		{
			return graphics_0.Clip;
		}
		set
		{
			graphics_0.Clip = value;
		}
	}

	public RectangleF ClipBounds => graphics_0.ClipBounds;

	public float DpiX => graphics_0.DpiX;

	public float DpiY => graphics_0.DpiY;

	public bool IsClipEmpty => graphics_0.IsClipEmpty;

	public bool IsVisibleClipEmpty => graphics_0.IsVisibleClipEmpty;

	public GraphicsUnit PageUnit
	{
		get
		{
			return graphics_0.PageUnit;
		}
		set
		{
			graphics_0.PageUnit = value;
		}
	}

	public float PageScale
	{
		get
		{
			return graphics_0.PageScale;
		}
		set
		{
			graphics_0.PageScale = value;
		}
	}

	public Point RenderingOrigin
	{
		get
		{
			return graphics_0.RenderingOrigin;
		}
		set
		{
			graphics_0.RenderingOrigin = value;
		}
	}

	public SmoothingMode SmoothingMode
	{
		get
		{
			return graphics_0.SmoothingMode;
		}
		set
		{
			graphics_0.SmoothingMode = value;
		}
	}

	public TextRenderingHint TextRenderingHint
	{
		get
		{
			return graphics_0.TextRenderingHint;
		}
		set
		{
			graphics_0.TextRenderingHint = value;
		}
	}

	public Matrix Transform
	{
		get
		{
			return graphics_0.Transform;
		}
		set
		{
			graphics_0.Transform = value;
		}
	}

	public RectangleF VisibleClipBounds => graphics_0.VisibleClipBounds;

	public CompositingQuality CompositingQuality
	{
		get
		{
			return graphics_0.CompositingQuality;
		}
		set
		{
			graphics_0.CompositingQuality = value;
		}
	}

	public int TextContrast
	{
		get
		{
			return graphics_0.TextContrast;
		}
		set
		{
			graphics_0.TextContrast = value;
		}
	}

	public Class794()
	{
	}

	public Class794(Graphics g)
	{
		graphics_0 = g;
	}

	public Graphics method_0()
	{
		return graphics_0;
	}

	public abstract void imethod_0();

	public abstract Bitmap imethod_1();

	public void Clear(Color color)
	{
		graphics_0.Clear(color);
	}

	public abstract void imethod_2();

	public abstract void Dispose();

	public void imethod_3(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
	{
		graphics_0.DrawArc(pen, rect, startAngle, sweepAngle);
	}

	public void imethod_4(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
	{
		graphics_0.DrawArc(pen, rect, startAngle, sweepAngle);
	}

	public void imethod_5(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
	{
		graphics_0.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_6(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		graphics_0.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_7(Pen pen, Point pt1, Point pt2, Point pt3, Point pt4)
	{
		graphics_0.DrawBezier(pen, pt1, pt2, pt3, pt4);
	}

	public void imethod_8(Pen pen, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
	{
		graphics_0.DrawBezier(pen, pt1, pt2, pt3, pt4);
	}

	public void imethod_9(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	{
		graphics_0.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
	}

	public void imethod_10(Pen pen, Point[] points)
	{
		graphics_0.DrawBeziers(pen, points);
	}

	public void imethod_11(Pen pen, PointF[] points)
	{
		graphics_0.DrawBeziers(pen, points);
	}

	public void imethod_12(Pen pen, Point[] points)
	{
		graphics_0.DrawClosedCurve(pen, points);
	}

	public void imethod_13(Pen pen, PointF[] points)
	{
		graphics_0.DrawClosedCurve(pen, points);
	}

	public void imethod_14(Pen pen, Point[] points, float tension, FillMode fillmode)
	{
		graphics_0.DrawClosedCurve(pen, points, tension, fillmode);
	}

	public void imethod_15(Pen pen, PointF[] points, float tension, FillMode fillmode)
	{
		graphics_0.DrawClosedCurve(pen, points, tension, fillmode);
	}

	public void imethod_16(Pen pen, Point[] points)
	{
		graphics_0.DrawCurve(pen, points);
	}

	public void imethod_17(Pen pen, PointF[] points)
	{
		graphics_0.DrawCurve(pen, points);
	}

	public void imethod_18(Pen pen, Point[] points, float tension)
	{
		graphics_0.DrawCurve(pen, points, tension);
	}

	public void imethod_19(Pen pen, PointF[] points, float tension)
	{
		graphics_0.DrawCurve(pen, points, tension);
	}

	public void imethod_20(Pen pen, PointF[] points, int offset, int numberOfSegments)
	{
		graphics_0.DrawCurve(pen, points, offset, numberOfSegments);
	}

	public void imethod_21(Pen pen, Point[] points, int offset, int numberOfSegments, float tension)
	{
		graphics_0.DrawCurve(pen, points, offset, numberOfSegments, tension);
	}

	public void imethod_22(Pen pen, PointF[] points, int offset, int numberOfSegments, float tension)
	{
		graphics_0.DrawCurve(pen, points, offset, numberOfSegments, tension);
	}

	public void imethod_23(Pen pen, Rectangle rect)
	{
		graphics_0.DrawEllipse(pen, rect);
	}

	public void imethod_24(Pen pen, RectangleF rect)
	{
		graphics_0.DrawEllipse(pen, rect);
	}

	public void imethod_25(Pen pen, int x, int y, int width, int height)
	{
		graphics_0.DrawEllipse(pen, x, y, width, height);
	}

	public void imethod_26(Pen pen, float x, float y, float width, float height)
	{
		graphics_0.DrawEllipse(pen, x, y, width, height);
	}

	public void imethod_27(Image image, Point point)
	{
		graphics_0.DrawImage(image, point);
	}

	public void imethod_28(Image image, PointF point)
	{
		graphics_0.DrawImage(image, point);
	}

	public void imethod_29(Image image, Rectangle rect)
	{
		graphics_0.DrawImage(image, rect);
	}

	public void imethod_30(Image image, RectangleF rect)
	{
		graphics_0.DrawImage(image, rect);
	}

	public void imethod_31(Image image, int x, int y)
	{
		graphics_0.DrawImage(image, x, y);
	}

	public void imethod_32(Image image, float x, float y)
	{
		graphics_0.DrawImage(image, x, y);
	}

	public void imethod_33(Image image, int x, int y, int width, int height)
	{
		graphics_0.DrawImage(image, x, y, width, height);
	}

	public void imethod_34(Image image, float x, float y, float width, float height)
	{
		graphics_0.DrawImage(image, x, y, width, height);
	}

	public void imethod_35(Image image, Rectangle destRect, float srcX, float srcY, float srcWidth, float srcHeight, GraphicsUnit srcUnit)
	{
		graphics_0.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
	}

	public void imethod_36(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight, GraphicsUnit srcUnit)
	{
		graphics_0.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
	}

	public void imethod_37(Image image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
	{
		graphics_0.DrawImage(image, destRect, srcRect, srcUnit);
	}

	public void imethod_38(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
	{
		graphics_0.DrawImage(image, destRect, srcRect, srcUnit);
	}

	public void imethod_39(Pen pen, Point pt1, Point pt2)
	{
		graphics_0.DrawLine(pen, pt1, pt2);
	}

	public void imethod_40(Pen pen, PointF pt1, PointF pt2)
	{
		graphics_0.DrawLine(pen, pt1, pt2);
	}

	public void imethod_41(Pen pen, int x1, int y1, int x2, int y2)
	{
		graphics_0.DrawLine(pen, x1, y1, x2, y2);
	}

	public void imethod_42(Pen pen, float x1, float y1, float x2, float y2)
	{
		graphics_0.DrawLine(pen, x1, y1, x2, y2);
	}

	public void imethod_43(Pen pen, Point[] points)
	{
		graphics_0.DrawLines(pen, points);
	}

	public void imethod_44(Pen pen, PointF[] points)
	{
		graphics_0.DrawLines(pen, points);
	}

	public void imethod_45(Pen pen, GraphicsPath path)
	{
		graphics_0.DrawPath(pen, path);
	}

	public void imethod_46(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
	{
		graphics_0.DrawPie(pen, rect, startAngle, sweepAngle);
	}

	public void imethod_47(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
	{
		graphics_0.DrawPie(pen, rect, startAngle, sweepAngle);
	}

	public void imethod_48(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
	{
		graphics_0.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_49(Pen pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		graphics_0.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_50(Pen pen, Point[] points)
	{
		graphics_0.DrawPolygon(pen, points);
	}

	public void imethod_51(Pen pen, PointF[] points)
	{
		graphics_0.DrawPolygon(pen, points);
	}

	public void imethod_52(Pen pen, Rectangle rect)
	{
		graphics_0.DrawRectangle(pen, rect);
	}

	public void imethod_53(Pen pen, int x, int y, int width, int height)
	{
		graphics_0.DrawRectangle(pen, x, y, width, height);
	}

	public void imethod_54(Pen pen, float x, float y, float width, float height)
	{
		graphics_0.DrawRectangle(pen, x, y, width, height);
	}

	public void imethod_55(Pen pen, Rectangle[] rects)
	{
		graphics_0.DrawRectangles(pen, rects);
	}

	public void imethod_56(Pen pen, RectangleF[] rects)
	{
		graphics_0.DrawRectangles(pen, rects);
	}

	public void imethod_57(string s, Font font, Brush brush, PointF point)
	{
		graphics_0.DrawString(s, font, brush, point);
	}

	public void imethod_58(string s, Font font, Brush brush, RectangleF layoutRectangle)
	{
		graphics_0.DrawString(s, font, brush, layoutRectangle);
	}

	public void imethod_60(string s, Font font, Brush brush, PointF point, StringFormat format)
	{
		graphics_0.DrawString(s, font, brush, point, format);
	}

	public void imethod_61(string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
	{
		graphics_0.DrawString(s, font, brush, layoutRectangle, format);
	}

	public void imethod_63(string s, Font font, Brush brush, float x, float y)
	{
		graphics_0.DrawString(s, font, brush, x, y);
	}

	public void imethod_64(string s, Font font, Brush brush, float x, float y, StringFormat format)
	{
		graphics_0.DrawString(s, font, brush, x, y, format);
	}

	public void imethod_59(string s, Font font, Brush brush, Rectangle layoutRectangle)
	{
		RectangleF layoutRectangle2 = new RectangleF(layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, layoutRectangle.Height);
		imethod_58(s, font, brush, layoutRectangle2);
	}

	public void imethod_62(string s, Font font, Brush brush, Rectangle layoutRectangle, StringFormat format)
	{
		RectangleF layoutRectangle2 = new RectangleF(layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, layoutRectangle.Height);
		imethod_61(s, font, brush, layoutRectangle2, format);
	}

	public void imethod_65(Rectangle rect)
	{
		graphics_0.ExcludeClip(rect);
	}

	public void imethod_66(Region region)
	{
		graphics_0.ExcludeClip(region);
	}

	public void imethod_67(Brush brush, Point[] points)
	{
		graphics_0.FillClosedCurve(brush, points);
	}

	public void imethod_68(Brush brush, PointF[] points)
	{
		graphics_0.FillClosedCurve(brush, points);
	}

	public void imethod_69(Brush brush, Point[] points, FillMode fillmode)
	{
		graphics_0.FillClosedCurve(brush, points, fillmode);
	}

	public void imethod_70(Brush brush, PointF[] points, FillMode fillmode)
	{
		graphics_0.FillClosedCurve(brush, points, fillmode);
	}

	public void imethod_71(Brush brush, Point[] points, FillMode fillmode, float tension)
	{
		graphics_0.FillClosedCurve(brush, points, fillmode, tension);
	}

	public void imethod_72(Brush brush, PointF[] points, FillMode fillmode, float tension)
	{
		graphics_0.FillClosedCurve(brush, points, fillmode, tension);
	}

	public void imethod_73(Brush brush, Rectangle rect)
	{
		graphics_0.FillEllipse(brush, rect);
	}

	public void imethod_74(Brush brush, RectangleF rect)
	{
		graphics_0.FillEllipse(brush, rect);
	}

	public void imethod_75(Brush brush, int x, int y, int width, int height)
	{
		graphics_0.FillEllipse(brush, x, y, width, height);
	}

	public void imethod_76(Brush brush, float x, float y, float width, float height)
	{
		graphics_0.FillEllipse(brush, x, y, width, height);
	}

	public void imethod_77(Brush brush, GraphicsPath path)
	{
		graphics_0.FillPath(brush, path);
	}

	public void imethod_78(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
	{
		graphics_0.FillPie(brush, rect, startAngle, sweepAngle);
	}

	public void imethod_79(Brush brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
	{
		graphics_0.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_80(Brush brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		graphics_0.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_81(Brush brush, Point[] points)
	{
		graphics_0.FillPolygon(brush, points);
	}

	public void imethod_82(Brush brush, PointF[] points)
	{
		graphics_0.FillPolygon(brush, points);
	}

	public void imethod_83(Brush brush, Point[] points, FillMode fillMode)
	{
		graphics_0.FillPolygon(brush, points, fillMode);
	}

	public void imethod_84(Brush brush, PointF[] points, FillMode fillMode)
	{
		graphics_0.FillPolygon(brush, points, fillMode);
	}

	public void imethod_85(Brush brush, Rectangle rect)
	{
		graphics_0.FillRectangle(brush, rect);
	}

	public void imethod_86(Brush brush, RectangleF rect)
	{
		graphics_0.FillRectangle(brush, rect);
	}

	public void imethod_87(Brush brush, int x, int y, int width, int height)
	{
		graphics_0.FillRectangle(brush, x, y, width, height);
	}

	public void imethod_88(Brush brush, float x, float y, float width, float height)
	{
		graphics_0.FillRectangle(brush, x, y, width, height);
	}

	public void imethod_89(Brush brush, Rectangle[] rects)
	{
		graphics_0.FillRectangles(brush, rects);
	}

	public void imethod_90(Brush brush, RectangleF[] rects)
	{
		graphics_0.FillRectangles(brush, rects);
	}

	public void imethod_91(Brush brush, Region region)
	{
		graphics_0.FillRegion(brush, region);
	}

	public void Flush()
	{
		graphics_0.Flush();
	}

	public void Flush(FlushIntention intention)
	{
		graphics_0.Flush(intention);
	}

	public Color imethod_92(Color color)
	{
		return graphics_0.GetNearestColor(color);
	}

	public void imethod_93(Rectangle rect)
	{
		graphics_0.IntersectClip(rect);
	}

	public void imethod_94(RectangleF rect)
	{
		graphics_0.IntersectClip(rect);
	}

	public void imethod_95(Region region)
	{
		graphics_0.IntersectClip(region);
	}

	public bool imethod_96(Point point)
	{
		return graphics_0.IsVisible(point);
	}

	public bool imethod_97(PointF point)
	{
		return graphics_0.IsVisible(point);
	}

	public bool imethod_98(Rectangle rect)
	{
		return graphics_0.IsVisible(rect);
	}

	public bool imethod_99(RectangleF rect)
	{
		return graphics_0.IsVisible(rect);
	}

	public bool imethod_100(int x, int y)
	{
		return graphics_0.IsVisible(x, y);
	}

	public bool imethod_101(float x, float y)
	{
		return graphics_0.IsVisible(x, y);
	}

	public bool imethod_102(int x, int y, int width, int height)
	{
		return graphics_0.IsVisible(x, y, width, height);
	}

	public bool imethod_103(float x, float y, float width, float height)
	{
		return graphics_0.IsVisible(x, y, width, height);
	}

	public Region[] imethod_104(string text, Font font, RectangleF layoutRect, StringFormat stringFormat)
	{
		return graphics_0.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
	}

	public SizeF imethod_105(string text, Font font)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_106(string text, Font font, SizeF layoutArea)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_107(string text, Font font, int width)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, width);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_108(string text, Font font, PointF origin, StringFormat stringFormat)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, origin, stringFormat);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_109(string text, Font font, SizeF layoutArea, StringFormat stringFormat)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea, stringFormat);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_110(string text, Font font, int width, StringFormat format)
	{
		SizeF result = default(SizeF);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, width, format);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public SizeF imethod_111(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
	{
		SizeF result = default(SizeF);
		charactersFitted = 0;
		linesFilled = 0;
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					result = graphics_0.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
					return result;
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	public void imethod_112(Matrix matrix)
	{
		graphics_0.MultiplyTransform(matrix);
	}

	public void imethod_113(Matrix matrix, MatrixOrder order)
	{
		graphics_0.MultiplyTransform(matrix, order);
	}

	public void ResetClip()
	{
		graphics_0.ResetClip();
	}

	public void ResetTransform()
	{
		graphics_0.ResetTransform();
	}

	public void imethod_114(GraphicsState state)
	{
		graphics_0.Restore(state);
	}

	public void imethod_115(float angle)
	{
		graphics_0.RotateTransform(angle);
	}

	public void imethod_116(float angle, MatrixOrder order)
	{
		graphics_0.RotateTransform(angle, order);
	}

	public GraphicsState Save()
	{
		return graphics_0.Save();
	}

	public void imethod_117(float sx, float sy)
	{
		graphics_0.ScaleTransform(sx, sy);
	}

	public void imethod_118(float sx, float sy, MatrixOrder order)
	{
		graphics_0.ScaleTransform(sx, sy, order);
	}

	public void imethod_119(GraphicsPath path)
	{
		graphics_0.SetClip(path);
	}

	public void imethod_120(Interface32 g)
	{
		if (!(g is Class794))
		{
			throw new InvalidOperationException();
		}
		graphics_0.SetClip(((Class794)g).method_0());
	}

	public void imethod_121(Rectangle rect)
	{
		graphics_0.SetClip(rect);
	}

	public void imethod_122(RectangleF rect)
	{
		graphics_0.SetClip(rect);
	}

	public void imethod_123(GraphicsPath path, CombineMode combineMode)
	{
		graphics_0.SetClip(path, combineMode);
	}

	public void imethod_124(Interface32 g, CombineMode combineMode)
	{
		if (!(g is Class794))
		{
			throw new InvalidOperationException();
		}
		graphics_0.SetClip(((Class794)g).method_0(), combineMode);
	}

	public void imethod_125(Rectangle rect, CombineMode combineMode)
	{
		graphics_0.SetClip(rect, combineMode);
	}

	public void imethod_126(RectangleF rect, CombineMode combineMode)
	{
		graphics_0.SetClip(rect, combineMode);
	}

	public void imethod_127(Region region, CombineMode combineMode)
	{
		graphics_0.SetClip(region, combineMode);
	}

	public void imethod_128(CoordinateSpace destSpace, CoordinateSpace srcSpace, Point[] pts)
	{
		graphics_0.TransformPoints(destSpace, srcSpace, pts);
	}

	public void imethod_129(CoordinateSpace destSpace, CoordinateSpace srcSpace, PointF[] pts)
	{
		graphics_0.TransformPoints(destSpace, srcSpace, pts);
	}

	public void imethod_130(int dx, int dy)
	{
		graphics_0.TranslateClip(dx, dy);
	}

	public void imethod_131(float dx, float dy)
	{
		graphics_0.TranslateClip(dx, dy);
	}

	public void imethod_132(float dx, float dy)
	{
		graphics_0.TranslateTransform(dx, dy);
	}

	public void imethod_133(float dx, float dy, MatrixOrder order)
	{
		graphics_0.TranslateTransform(dx, dy, order);
	}
}
