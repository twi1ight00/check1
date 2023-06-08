using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns224;
using ns234;
using ns235;

namespace ns168;

internal class Class4797 : Class4792
{
	private class Class4800 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4797 @class = a as Class4797;
			Class4797 class2 = b as Class4797;
			if (!(@class == null) && !(class2 == null))
			{
				if (@class.Start.X == class2.Start.X)
				{
					if (@class.TopVertex.Y < class2.TopVertex.Y)
					{
						return -1;
					}
					if (@class.TopVertex.Y < class2.TopVertex.Y)
					{
						return 1;
					}
					return 0;
				}
				if (@class.Start.X < class2.Start.X)
				{
					return -1;
				}
				return 1;
			}
			throw new ArgumentException("Please report exception. Could not sort SegmentCollection.");
		}
	}

	internal class Class4801 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4797 @class = a as Class4797;
			Class4797 class2 = b as Class4797;
			if (!(@class == null) && !(class2 == null))
			{
				if (@class.Start.Y == class2.Start.Y)
				{
					if (@class.LeftVertex.X < class2.LeftVertex.X)
					{
						return -1;
					}
					if (@class.LeftVertex.X < class2.LeftVertex.X)
					{
						return 1;
					}
					return 0;
				}
				if (@class.Start.Y < class2.Start.Y)
				{
					return -1;
				}
				return 1;
			}
			throw new ArgumentException("Please report exception. Could not sort SegmentCollection.");
		}
	}

	private const float float_0 = 0.01f;

	private PointF pointF_0;

	private PointF pointF_1;

	private Color color_0;

	private float float_1 = 0.01f;

	private static readonly IComparer icomparer_0 = new Class4800();

	private static readonly IComparer icomparer_1 = new Class4801();

	internal Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	internal PointF Start => pointF_0;

	internal PointF End => pointF_1;

	internal bool IsVertical => smethod_4(pointF_0, pointF_1);

	internal bool IsHorizontal => smethod_5(pointF_0, pointF_1);

	internal PointF TopVertex => smethod_6(pointF_0, pointF_1);

	internal PointF BottomVertex => smethod_7(pointF_0, pointF_1);

	internal PointF LeftVertex => smethod_8(pointF_0, pointF_1);

	internal PointF RightVertex => smethod_9(pointF_0, pointF_1);

	internal static IComparer HorizontalComparer => icomparer_0;

	internal static IComparer VerticalComparer => icomparer_1;

	internal float Thickness
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal Class4797(Class6217 source)
	{
		if (source != null && source.Pen != null && source.Count != 0)
		{
			if (source.Pen.Brush.BrushType == Enum746.const_0)
			{
				color_0 = Class6153.smethod_0(((Class5997)source.Pen.Brush).Color);
			}
			float_1 = source.Pen.Width;
			Class6218 @class = source[0] as Class6218;
			if (@class[0] is Class6223 class2 && class2.Points.Count == 2)
			{
				pointF_0 = class2.Points[0];
				pointF_1 = class2.Points[1];
			}
			return;
		}
		throw new ArgumentException();
	}

	internal Class4797(PointF start, PointF end)
	{
		pointF_0 = start;
		pointF_1 = end;
		color_0 = Color.Empty;
	}

	public override bool Equals(object obj)
	{
		bool result = false;
		Class4797 @class = obj as Class4797;
		if (@class != null)
		{
			float tolerance = Math.Max(Thickness, @class.Thickness);
			result = (result = (smethod_1(Start, @class.Start, tolerance) && smethod_1(End, @class.End, tolerance)) || (smethod_1(End, @class.Start, tolerance) && smethod_1(Start, @class.End, tolerance))) & (Color == @class.Color);
		}
		return result;
	}

	public static bool operator ==(Class4797 left, Class4797 right)
	{
		return left?.Equals(right) ?? ((object)right == null);
	}

	public static bool operator !=(Class4797 left, Class4797 right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return pointF_0.GetHashCode() ^ pointF_1.GetHashCode() ^ color_0.GetHashCode();
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		using Pen pen = new Pen(Color, Thickness);
		PointF pt = new PointF(Start.X - topLeft.X, Start.Y - topLeft.Y);
		PointF pt2 = new PointF(End.X - topLeft.X, End.Y - topLeft.Y);
		canvas.DrawLine(pen, pt, pt2);
	}

	internal bool method_0(Class4797 segm)
	{
		PointF intersection;
		return method_5(segm, out intersection);
	}

	internal bool method_1(RectangleF bbox)
	{
		RectangleF rectangleF = RectangleF.Intersect(bbox, method_2());
		if (rectangleF.Width == 0f)
		{
			return rectangleF.Height != 0f;
		}
		return true;
	}

	internal RectangleF method_2()
	{
		float num = Thickness / 2f;
		return RectangleF.FromLTRB(LeftVertex.X - num, TopVertex.Y - num, RightVertex.X + num, BottomVertex.Y + num);
	}

	internal bool method_3(PointF point)
	{
		if (!IsVertical)
		{
			return smethod_3(point.Y, End.Y, float_1);
		}
		return smethod_3(point.X, End.X, float_1);
	}

	internal void method_4()
	{
		PointF pointF = pointF_0;
		pointF_0 = pointF_1;
		pointF_1 = pointF;
	}

	internal static Class4797 smethod_0(Class4797 s1, Class4797 s2)
	{
		if (!(s1 == null) && !(s2 == null))
		{
			Class4797 @class;
			if (s1.IsVertical && s2.IsVertical)
			{
				float y = Math.Min(s1.TopVertex.Y, s2.TopVertex.Y);
				float y2 = Math.Max(s1.BottomVertex.Y, s2.BottomVertex.Y);
				@class = new Class4797(new PointF(s1.Start.X, y), new PointF(s1.Start.X, y2));
			}
			else
			{
				if (!s1.IsHorizontal || !s2.IsHorizontal)
				{
					throw new ArgumentException("Please report exception.");
				}
				float x = Math.Min(s1.LeftVertex.X, s2.LeftVertex.X);
				float x2 = Math.Max(s1.RightVertex.X, s2.RightVertex.X);
				@class = new Class4797(new PointF(x, s1.Start.Y), new PointF(x2, s1.Start.Y));
			}
			@class.Thickness = Math.Max(s1.Thickness, s2.Thickness);
			@class.PageOrder = Math.Min(s1.PageOrder, s2.PageOrder);
			@class.Color = s1.Color;
			return @class;
		}
		return null;
	}

	internal bool method_5(Class4797 segm, out PointF intersection)
	{
		bool result = false;
		intersection = PointF.Empty;
		float num = Thickness + segm.Thickness;
		if (IsHorizontal)
		{
			if (segm.IsVertical)
			{
				if (result = Start.Y >= segm.TopVertex.Y - num && Start.Y <= segm.BottomVertex.Y + num && segm.Start.X >= LeftVertex.X - num && segm.Start.X <= RightVertex.X + num)
				{
					intersection = new PointF(segm.Start.X, Start.Y);
				}
			}
			else if (segm.IsHorizontal)
			{
				if (result = Class4778.smethod_2(LeftVertex, segm.RightVertex) <= (double)num)
				{
					intersection = LeftVertex;
				}
				else
				{
					result = Class4778.smethod_2(RightVertex, segm.LeftVertex) <= (double)num;
					intersection = segm.RightVertex;
				}
			}
		}
		else if (IsVertical)
		{
			if (segm.IsHorizontal)
			{
				if (result = segm.Start.Y >= TopVertex.Y - num && segm.Start.Y <= BottomVertex.Y + num && Start.X >= segm.LeftVertex.X - num && Start.X <= segm.RightVertex.X + num)
				{
					intersection = new PointF(Start.X, segm.Start.Y);
				}
			}
			else if (segm.IsVertical)
			{
				if (result = Class4778.smethod_2(TopVertex, segm.BottomVertex) <= (double)num)
				{
					intersection = TopVertex;
				}
				else
				{
					result = Class4778.smethod_2(BottomVertex, segm.TopVertex) <= (double)num;
					intersection = BottomVertex;
				}
			}
		}
		return result;
	}

	internal static bool smethod_1(PointF p1, PointF p2, float tolerance)
	{
		if (smethod_3(p1.X, p2.X, tolerance))
		{
			return smethod_3(p1.Y, p2.Y, tolerance);
		}
		return false;
	}

	internal static bool smethod_2(double c1, double c2)
	{
		return smethod_3(c1, c2, 0.009999999776482582);
	}

	internal static bool smethod_3(double c1, double c2, double tolerance)
	{
		return Class4778.smethod_1(c1, c2, tolerance);
	}

	internal static bool smethod_4(PointF start, PointF end)
	{
		if (smethod_2(start.X, end.X))
		{
			return !smethod_2(start.Y, end.Y);
		}
		return false;
	}

	internal static bool smethod_5(PointF start, PointF end)
	{
		if (smethod_2(start.Y, end.Y))
		{
			return !smethod_2(start.X, end.X);
		}
		return false;
	}

	internal static PointF smethod_6(PointF start, PointF end)
	{
		if (!(start.Y < end.Y))
		{
			return end;
		}
		return start;
	}

	internal static PointF smethod_7(PointF start, PointF end)
	{
		if (!(end.Y > start.Y))
		{
			return start;
		}
		return end;
	}

	internal static PointF smethod_8(PointF start, PointF end)
	{
		if (!(end.X < start.X))
		{
			return start;
		}
		return end;
	}

	internal static PointF smethod_9(PointF start, PointF end)
	{
		if (!(start.X > end.X))
		{
			return end;
		}
		return start;
	}
}
