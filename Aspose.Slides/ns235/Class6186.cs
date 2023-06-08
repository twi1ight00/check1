using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;

namespace ns235;

internal class Class6186 : Class6176
{
	private Hashtable hashtable_0 = new Hashtable();

	private float float_0;

	private bool bool_0;

	public bool ScaleFontSize
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private float ScaleFactor
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public override void vmethod_0(Class6216 page)
	{
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
	}

	public void method_0(Class6204 node, Enum805 from, Enum805 to)
	{
		method_1(node, (double)to / (double)from);
	}

	public void method_1(Class6204 node, double scaleFactor)
	{
		ScaleFactor = (float)scaleFactor;
		node.vmethod_0(this);
	}

	public override void vmethod_2(Class6213 canvas)
	{
		if (canvas.RenderTransform != null)
		{
			method_4(canvas.RenderTransform);
		}
		if (canvas.Hyperlink != null)
		{
			canvas.Hyperlink = method_3(canvas.Hyperlink);
		}
		if (canvas.Clip != null)
		{
			canvas.Clip.vmethod_0(this);
		}
	}

	public RectangleF method_2(RectangleF rect)
	{
		return new RectangleF(rect.X * ScaleFactor, rect.Y * ScaleFactor, rect.Width * ScaleFactor, rect.Height * ScaleFactor);
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		if (glyphs.Clip != null)
		{
			glyphs.Clip.vmethod_0(this);
		}
		if (glyphs.RenderTransform != null)
		{
			method_4(glyphs.RenderTransform);
		}
		if (glyphs.Font != null)
		{
			method_5(glyphs.Font);
		}
		glyphs.Origin = method_8(glyphs.Origin);
		glyphs.Size = method_9(glyphs.Size);
	}

	public override void vmethod_5(Class6217 path)
	{
		if (path.RenderTransform != null)
		{
			method_4(path.RenderTransform);
		}
		if (path.Pen != null)
		{
			method_7(path.Pen);
		}
		if (path.Brush != null)
		{
			method_6(path.Brush);
		}
		if (path.Clip != null)
		{
			path.Clip.vmethod_0(this);
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		for (int i = 0; i < segment.Points.Count; i++)
		{
			segment.Points[i] = method_8(segment.Points[i]);
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		Struct219 curve = default(Struct219);
		curve.ControlPoint1 = method_8(segment.Curve.ControlPoint1);
		curve.ControlPoint2 = method_8(segment.Curve.ControlPoint2);
		curve.EndPoint = method_8(segment.Curve.EndPoint);
		curve.StartPoint = method_8(segment.Curve.StartPoint);
		segment.Curve = curve;
	}

	public override void vmethod_11(Class6220 image)
	{
		if (image.Hyperlink != null)
		{
			image.Hyperlink = method_3(image.Hyperlink);
		}
		image.Origin = method_8(image.Origin);
		image.Size = method_9(image.Size);
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		bookmark.Origin = method_8(bookmark.Origin);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		outlineItem.Origin = method_8(outlineItem.Origin);
	}

	public override void vmethod_14(Class6210 field)
	{
		field.Origin = method_8(field.Origin);
		field.Size = method_9(field.Size);
	}

	public override void vmethod_15(Class6207 field)
	{
		field.Origin = method_8(field.Origin);
		field.Size *= ScaleFactor;
	}

	public override void vmethod_16(Class6209 field)
	{
		field.Origin = method_8(field.Origin);
	}

	public override bool vmethod_19(Class6215 group)
	{
		return true;
	}

	private Class6270 method_3(Class6270 hyperlink)
	{
		return new Class6270(method_2(hyperlink.ActiveRect), hyperlink.Target);
	}

	private void method_4(Class6002 matrix)
	{
		matrix.method_5(ScaleFactor, ScaleFactor, MatrixOrder.Append);
		matrix.method_5((float)(1.0 / (double)ScaleFactor), (float)(1.0 / (double)ScaleFactor), MatrixOrder.Prepend);
	}

	private void method_5(Class5999 font)
	{
		if (!hashtable_0.Contains(font))
		{
			hashtable_0.Add(font, font);
			if (bool_0)
			{
				font.SizePoints *= ScaleFactor;
			}
		}
	}

	private void method_6(Class5990 brush)
	{
		if (brush is Class5991 @class)
		{
			method_4(@class.Transform);
			switch (brush.BrushType)
			{
			case Enum746.const_3:
			{
				Class5993 class3 = (Class5993)brush;
				class3.Rectangle = method_2(class3.Rectangle);
				break;
			}
			case Enum746.const_4:
			{
				Class5994 class2 = (Class5994)brush;
				class2.CenterPoint = method_8(class2.CenterPoint);
				class2.Path.vmethod_0(this);
				break;
			}
			}
		}
	}

	private void method_7(Class6003 pen)
	{
		pen.Width *= ScaleFactor;
	}

	private PointF method_8(PointF point)
	{
		return new PointF(point.X * ScaleFactor, point.Y * ScaleFactor);
	}

	private SizeF method_9(SizeF size)
	{
		return new SizeF(size.Width * ScaleFactor, size.Height * ScaleFactor);
	}
}
