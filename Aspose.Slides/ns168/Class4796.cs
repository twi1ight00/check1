using System.Drawing;

namespace ns168;

internal class Class4796 : Class4792
{
	internal Color color_0 = Color.OrangeRed;

	private RectangleF rectangleF_0;

	private readonly Class4798 class4798_0;

	private readonly Class4798 class4798_1;

	private readonly Class4798 class4798_2;

	internal Class4798 VerticalSegments => class4798_0;

	internal Class4798 HorizontalSegments => class4798_1;

	internal Class4798 OtherSegments => class4798_2;

	internal RectangleF BoundingBox => rectangleF_0;

	internal Class4796()
	{
		rectangleF_0 = RectangleF.Empty;
		class4798_0 = new Class4798(this);
		class4798_1 = new Class4798(this);
		class4798_2 = new Class4798(this);
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		VerticalSegments.vmethod_0(canvas, topLeft);
		HorizontalSegments.vmethod_0(canvas, topLeft);
		OtherSegments.vmethod_0(canvas, topLeft);
	}

	internal void method_0(Class4796 ga)
	{
		method_1(ga.HorizontalSegments);
		method_1(ga.VerticalSegments);
		method_1(ga.OtherSegments);
	}

	internal void method_1(Class4798 c)
	{
		for (int i = 0; i < c.Count; i++)
		{
			Add(c[i]);
		}
	}

	internal bool method_2(Class4797 s)
	{
		if (BoundingBox.Width == 0f && BoundingBox.Height == 0f)
		{
			return true;
		}
		return s.method_1(BoundingBox);
	}

	internal void Add(Class4797 s)
	{
		if (s.IsHorizontal)
		{
			HorizontalSegments.Add(s);
		}
		else if (s.IsVertical)
		{
			VerticalSegments.Add(s);
		}
		else
		{
			OtherSegments.Add(s);
		}
		method_3(s);
	}

	internal void method_3(Class4797 s)
	{
		RectangleF rectangleF = (s.IsHorizontal ? new RectangleF(s.LeftVertex.X - s.Thickness, s.TopVertex.Y - s.Thickness, s.RightVertex.X - s.LeftVertex.X + s.Thickness, s.Thickness) : ((!s.IsVertical) ? RectangleF.FromLTRB(s.LeftVertex.X - s.Thickness, s.TopVertex.Y - s.Thickness, s.RightVertex.X + s.Thickness, s.BottomVertex.Y + s.Thickness) : new RectangleF(s.LeftVertex.X - s.Thickness, s.TopVertex.Y - s.Thickness, s.Thickness, s.BottomVertex.Y - s.TopVertex.Y + s.Thickness)));
		rectangleF_0 = ((rectangleF_0.Width != 0f || rectangleF_0.Height != 0f) ? RectangleF.Union(rectangleF_0, rectangleF) : rectangleF);
	}

	internal void method_4()
	{
		class4798_1.method_0(isHorizontal: true, class4798_0);
		class4798_0.method_0(isHorizontal: false, class4798_1);
	}

	internal void method_5()
	{
		class4798_1.method_4(isHorizontal: true);
		class4798_0.method_4(isHorizontal: false);
	}
}
