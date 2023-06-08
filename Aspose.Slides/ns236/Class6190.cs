using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns218;
using ns224;
using ns233;
using ns234;
using ns235;

namespace ns236;

internal class Class6190 : Class6176
{
	private Graphics graphics_0;

	private readonly Class6188 class6188_0 = new Class6188();

	private readonly Stack stack_0 = new Stack();

	private readonly Stack stack_1 = new Stack();

	private static readonly StringFormat stringFormat_0;

	private Class6163 class6163_0;

	public void method_0(Class6204 node, Graphics graphics)
	{
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		if (graphics == null)
		{
			throw new ArgumentNullException("graphics");
		}
		GraphicsUnit pageUnit = graphics.PageUnit;
		graphics.PageUnit = GraphicsUnit.Point;
		float pageScale = graphics.PageScale;
		graphics.PageScale = 1f;
		graphics_0 = graphics;
		using (class6163_0 = new Class6163())
		{
			node.vmethod_0(this);
		}
		graphics.PageScale = pageScale;
		graphics.PageUnit = pageUnit;
	}

	public SizeF method_1(Class6204 aps, SizeF sizeInPoints, Graphics graphics, float x, float y, float scale)
	{
		if (aps == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (graphics == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (scale <= 0f)
		{
			throw new ArgumentOutOfRangeException("scale");
		}
		Matrix matrix = smethod_0(graphics, x, y);
		matrix.Scale(scale, scale, MatrixOrder.Prepend);
		Matrix transform = graphics.Transform;
		graphics.Transform = matrix;
		method_0(aps, graphics);
		graphics.Transform = transform;
		PointF pointF = smethod_2(sizeInPoints.ToPointF(), graphics);
		return new SizeF(pointF.X * scale, pointF.Y * scale);
	}

	public float method_2(Class6204 aps, SizeF sizeInPoints, Graphics graphics, float x, float y, float width, float height)
	{
		if (aps == null)
		{
			throw new ArgumentNullException("aps");
		}
		if (graphics == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (width <= 0f)
		{
			throw new ArgumentOutOfRangeException("width");
		}
		if (height <= 0f)
		{
			throw new ArgumentOutOfRangeException("height");
		}
		Matrix matrix = smethod_0(graphics, x, y);
		PointF pointF = smethod_1(new PointF(width, height), graphics);
		float val = pointF.X / sizeInPoints.Width;
		float val2 = pointF.Y / sizeInPoints.Height;
		float num = Math.Min(val, val2);
		matrix.Scale(num, num, MatrixOrder.Prepend);
		Matrix transform = graphics.Transform;
		graphics.Transform = matrix;
		method_0(aps, graphics);
		graphics.Transform = transform;
		return num;
	}

	private static Matrix smethod_0(Graphics graphics, float x, float y)
	{
		Matrix transform = graphics.Transform;
		PointF pointF = smethod_1(new PointF(transform.OffsetX, transform.OffsetY), graphics);
		float[] elements = transform.Elements;
		Matrix matrix = new Matrix(elements[0], elements[1], elements[2], elements[3], pointF.X, pointF.Y);
		PointF pointF2 = smethod_1(new PointF(x, y), graphics);
		matrix.Translate(pointF2.X, pointF2.Y, MatrixOrder.Prepend);
		return matrix;
	}

	private static PointF smethod_1(PointF point, Graphics gr)
	{
		switch (gr.PageUnit)
		{
		default:
			throw new InvalidOperationException("Unknown graphics unit.");
		case GraphicsUnit.Display:
			if (gr.DpiX >= 300f && gr.DpiY >= 300f)
			{
				point.X = (float)Class5955.smethod_10(point.X, 100.0);
				point.Y = (float)Class5955.smethod_10(point.Y, 100.0);
			}
			else
			{
				point.X = (float)Class5955.smethod_10(point.X, gr.DpiX);
				point.Y = (float)Class5955.smethod_10(point.Y, gr.DpiY);
			}
			break;
		case GraphicsUnit.Pixel:
			point.X = (float)Class5955.smethod_10(point.X, gr.DpiX);
			point.Y = (float)Class5955.smethod_10(point.Y, gr.DpiY);
			break;
		case GraphicsUnit.Inch:
			point.X = (float)Class5955.smethod_13(point.X);
			point.Y = (float)Class5955.smethod_13(point.Y);
			break;
		case GraphicsUnit.Document:
			point.X = (float)Class5955.smethod_10(point.X, 300.0);
			point.Y = (float)Class5955.smethod_10(point.Y, 300.0);
			break;
		case GraphicsUnit.Millimeter:
			point.X = (float)Class5955.smethod_15(point.X);
			point.Y = (float)Class5955.smethod_15(point.Y);
			break;
		case GraphicsUnit.World:
		case GraphicsUnit.Point:
			break;
		}
		return new PointF(point.X * gr.PageScale, point.Y * gr.PageScale);
	}

	private static PointF smethod_2(PointF point, Graphics graphics)
	{
		PointF pointF = smethod_1(new PointF(1f, 1f), graphics);
		return new PointF(point.X / pointF.X, point.Y / pointF.Y);
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		if (glyphs.Font.SizePoints < 0.1f)
		{
			return;
		}
		method_4(glyphs);
		PointF pointF = new PointF(glyphs.Left, glyphs.Top);
		if (glyphs.Brush != null && (glyphs.Brush.BrushType != 0 || ((Class5997)glyphs.Brush).Color != Class5998.class5998_141))
		{
			using Brush brush = Class6151.smethod_0(glyphs.Brush);
			using Font font = Class6158.smethod_0(glyphs.Font, class6163_0);
			graphics_0.DrawString(glyphs.Text, font, brush, pointF, stringFormat_0);
		}
		if (glyphs.Outline != null && glyphs.Outline.Brush != null && (glyphs.Outline.Brush.BrushType != 0 || ((Class5997)glyphs.Outline.Brush).Color != Class5998.class5998_141))
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			using (Font font2 = Class6158.smethod_0(glyphs.Font, class6163_0))
			{
				graphicsPath.AddString(glyphs.Text, font2.FontFamily, (int)font2.Style, glyphs.Font.SizePoints, pointF, stringFormat_0);
			}
			using Pen pen = Class6162.smethod_0(glyphs.Outline);
			graphics_0.DrawPath(pen, graphicsPath);
		}
		method_5(glyphs);
	}

	public override void vmethod_2(Class6213 canvas)
	{
		method_4(canvas);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		method_5(canvas);
	}

	public override void vmethod_5(Class6217 path)
	{
		method_4(path);
		class6188_0.vmethod_5(path);
	}

	public override void vmethod_6(Class6217 path)
	{
		class6188_0.vmethod_6(path);
		if (path.Brush != null)
		{
			using Brush brush = Class6151.smethod_0(path.Brush);
			graphics_0.FillPath(brush, class6188_0.GraphicsPath);
		}
		if (path.Pen != null)
		{
			using Pen pen = Class6162.smethod_0(path.Pen);
			graphics_0.DrawPath(pen, class6188_0.GraphicsPath);
		}
		method_5(path);
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		class6188_0.vmethod_7(pathFigure);
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		class6188_0.vmethod_8(pathFigure);
	}

	public override void vmethod_9(Class6223 segment)
	{
		class6188_0.vmethod_9(segment);
	}

	public override void vmethod_10(Class6222 segment)
	{
		class6188_0.vmethod_10(segment);
	}

	public override void vmethod_11(Class6220 imageNode)
	{
		try
		{
			method_3(imageNode);
		}
		catch
		{
			method_3(Class6220.smethod_0(imageNode));
		}
	}

	private void method_3(Class6220 imageNode)
	{
		using Image image = Image.FromStream(new MemoryStream(imageNode.ImageBytes));
		Class6145 crop = imageNode.Crop;
		ImageAttributes imageAttributes = null;
		if (imageNode.ChromaKey != null)
		{
			imageAttributes = new ImageAttributes();
			imageAttributes.SetColorKey(imageNode.ChromaKey.LowColor.method_0(), imageNode.ChromaKey.HighColor.method_0());
		}
		GraphicsUnit pageUnit = GraphicsUnit.Pixel;
		RectangleF srcRect = image.GetBounds(ref pageUnit);
		RectangleF bounds = imageNode.Bounds;
		PointF[] destPoints = new PointF[3]
		{
			bounds.Location,
			new PointF(bounds.X + bounds.Width, bounds.Y),
			new PointF(bounds.X, bounds.Y + bounds.Height)
		};
		if (!Class6145.smethod_0(crop))
		{
			srcRect = crop.method_0(srcRect);
		}
		graphics_0.DrawImage(image, destPoints, srcRect, pageUnit, imageAttributes);
	}

	private void method_4(Interface261 node)
	{
		if (Class6224.smethod_1(node))
		{
			stack_0.Push(graphics_0.Transform.Clone());
			using Matrix matrix = Class6161.smethod_0(node.RenderTransform);
			graphics_0.MultiplyTransform(matrix, MatrixOrder.Prepend);
		}
		if (Class6224.smethod_2(node))
		{
			stack_1.Push(graphics_0.Clip.Clone());
			Class6189 @class = new Class6189();
			node.Clip.vmethod_0(@class);
			graphics_0.SetClip(@class.Region, CombineMode.Intersect);
		}
	}

	private void method_5(Interface261 node)
	{
		if (Class6224.smethod_2(node))
		{
			graphics_0.Clip = (Region)stack_1.Pop();
		}
		if (Class6224.smethod_1(node))
		{
			graphics_0.Transform = (Matrix)stack_0.Pop();
		}
	}

	static Class6190()
	{
		stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
		stringFormat_0.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
	}
}
