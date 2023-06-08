using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;

namespace ns235;

internal class Class6185 : Class6176
{
	private Class6175 class6175_0;

	private RectangleF rectangleF_0;

	private Stack stack_0 = new Stack();

	private bool bool_0;

	private Stack stack_1 = new Stack();

	private Class6175 BezierBoundingBoxCalculator
	{
		get
		{
			if (class6175_0 == null)
			{
				class6175_0 = new Class6175();
			}
			return class6175_0;
		}
	}

	public override void vmethod_0(Class6216 page)
	{
	}

	public override void vmethod_1(Class6216 page)
	{
	}

	public override void vmethod_2(Class6213 canvas)
	{
		method_0(canvas);
	}

	private void method_0(Interface261 renderTransformProvider)
	{
		Class6002 @class = renderTransformProvider.RenderTransform;
		if (@class == null)
		{
			@class = new Class6002();
		}
		if (stack_1.Count > 0)
		{
			Class6002 tx = (Class6002)stack_1.Peek();
			Class6002 class2 = @class.Clone();
			class2.method_9(tx, MatrixOrder.Append);
			stack_1.Push(class2);
		}
		else
		{
			stack_1.Push(@class);
		}
	}

	public override void vmethod_3(Class6213 canvas)
	{
		method_1();
	}

	private void method_1()
	{
		stack_1.Pop();
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		method_0(glyphs);
		method_3(glyphs.Bounds);
		method_1();
	}

	public override void vmethod_5(Class6217 path)
	{
		method_0(path);
		if (path.Pen != null)
		{
			stack_0.Push(path.Pen.Width / 2f);
		}
		else
		{
			stack_0.Push(0f);
		}
	}

	public override void vmethod_6(Class6217 path)
	{
		stack_0.Pop();
		method_1();
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
	}

	public override void vmethod_9(Class6223 segment)
	{
		foreach (PointF point in segment.Points)
		{
			method_4(point);
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		RectangleF bounds = BezierBoundingBoxCalculator.method_0(segment);
		method_3(bounds);
	}

	public override void vmethod_11(Class6220 image)
	{
		method_3(image.Bounds);
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		method_4(bookmark.Origin);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		method_4(outlineItem.Origin);
	}

	public override void vmethod_14(Class6210 field)
	{
		method_3(field.BoundingBox);
	}

	public override void vmethod_15(Class6207 field)
	{
		method_3(field.BoundingBox);
	}

	public override void vmethod_16(Class6209 field)
	{
		method_3(field.BoundingBox);
	}

	public override void vmethod_17(Class6208 field)
	{
		method_3(field.BoundingBox);
	}

	public override void vmethod_18(Class6206 field)
	{
		method_3(field.BoundingBox);
	}

	public override bool vmethod_19(Class6215 group)
	{
		return true;
	}

	public RectangleF method_2(Class6204 apsNode)
	{
		rectangleF_0 = RectangleF.Empty;
		bool_0 = false;
		if (apsNode == null)
		{
			return RectangleF.Empty;
		}
		apsNode.vmethod_0(this);
		return rectangleF_0;
	}

	private void method_3(RectangleF bounds)
	{
		if (stack_0.Count > 0)
		{
			float num = (float)stack_0.Peek();
			bounds = RectangleF.Inflate(bounds, num, num);
		}
		if (stack_1.Count > 0)
		{
			Class6002 @class = (Class6002)stack_1.Peek();
			bounds = @class.method_4(bounds);
		}
		if (bool_0)
		{
			rectangleF_0 = RectangleF.Union(rectangleF_0, bounds);
			return;
		}
		rectangleF_0 = bounds;
		bool_0 = true;
	}

	private void method_4(PointF p)
	{
		method_3(new RectangleF(p, SizeF.Empty));
	}
}
