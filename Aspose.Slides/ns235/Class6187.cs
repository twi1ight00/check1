using System.Drawing;
using ns224;

namespace ns235;

internal class Class6187 : Class6176
{
	private bool bool_0;

	private float float_0;

	private float float_1;

	public float MaxFloatValue => float_0;

	public float MinFloatValue => float_1;

	public bool AreStatisticsCalculated => bool_0;

	public void method_0(Class6204 node)
	{
		float_1 = 0f;
		float_0 = 0f;
		bool_0 = false;
		node.vmethod_0(this);
	}

	public override void vmethod_2(Class6213 canvas)
	{
		if (canvas.RenderTransform != null)
		{
			smethod_0(canvas.RenderTransform);
		}
		if (canvas.Hyperlink != null)
		{
			method_1(canvas.Hyperlink);
		}
		if (canvas.Clip != null)
		{
			canvas.Clip.vmethod_0(this);
		}
	}

	private void method_1(Class6270 hyperlink)
	{
		method_3(hyperlink.ActiveRect);
	}

	private void method_2(float value)
	{
		if (!AreStatisticsCalculated)
		{
			bool_0 = true;
			float_1 = value;
			float_0 = value;
			return;
		}
		if (value < MinFloatValue)
		{
			float_1 = value;
		}
		if (value > MaxFloatValue)
		{
			float_0 = value;
		}
	}

	public void method_3(RectangleF rect)
	{
		method_2(rect.Top);
		method_2(rect.Left);
		method_2(rect.Right);
		method_2(rect.Bottom);
	}

	private static void smethod_0(Class6002 matrix)
	{
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		if (glyphs.Clip != null)
		{
			glyphs.Clip.vmethod_0(this);
		}
		if (glyphs.RenderTransform != null)
		{
			smethod_0(glyphs.RenderTransform);
		}
		if (glyphs.Font != null)
		{
			smethod_1(glyphs.Font);
		}
		method_6(glyphs.Origin);
		method_7(glyphs.Size);
	}

	private static void smethod_1(Class5999 font)
	{
	}

	public override void vmethod_5(Class6217 path)
	{
		if (path.RenderTransform != null)
		{
			smethod_0(path.RenderTransform);
		}
		if (path.Pen != null)
		{
			method_5(path.Pen);
		}
		if (path.Brush != null)
		{
			method_4(path.Brush);
		}
		if (path.Clip != null)
		{
			path.Clip.vmethod_0(this);
		}
	}

	private void method_4(Class5990 brush)
	{
		if (brush is Class5991 @class)
		{
			smethod_0(@class.Transform);
			switch (brush.BrushType)
			{
			case Enum746.const_3:
			{
				Class5993 class3 = (Class5993)brush;
				method_3(class3.Rectangle);
				break;
			}
			case Enum746.const_4:
			{
				Class5994 class2 = (Class5994)brush;
				method_6(class2.CenterPoint);
				class2.Path.vmethod_0(this);
				break;
			}
			}
		}
	}

	private void method_5(Class6003 pen)
	{
		method_2(pen.Width);
	}

	public override void vmethod_9(Class6223 segment)
	{
		for (int i = 0; i < segment.Points.Count; i++)
		{
			method_6(segment.Points[i]);
		}
	}

	private void method_6(PointF point)
	{
		method_2(point.X);
		method_2(point.Y);
	}

	public override void vmethod_10(Class6222 segment)
	{
		method_6(segment.Curve.ControlPoint1);
		method_6(segment.Curve.ControlPoint2);
		method_6(segment.Curve.EndPoint);
		method_6(segment.Curve.StartPoint);
	}

	public override void vmethod_11(Class6220 image)
	{
		if (image.Hyperlink != null)
		{
			method_1(image.Hyperlink);
		}
		method_6(image.Origin);
		method_7(image.Size);
	}

	private void method_7(SizeF size)
	{
		method_2(size.Width);
		method_2(size.Height);
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		method_6(bookmark.Origin);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		method_6(outlineItem.Origin);
	}

	public override void vmethod_14(Class6210 field)
	{
		method_6(field.Origin);
		method_7(field.Size);
	}

	public override void vmethod_15(Class6207 field)
	{
		method_6(field.Origin);
		method_2(field.Size);
	}

	public override void vmethod_16(Class6209 field)
	{
		method_6(field.Origin);
	}

	public override bool vmethod_19(Class6215 group)
	{
		return true;
	}
}
