using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns161;
using ns166;
using ns224;
using ns235;

namespace ns168;

internal class Class4793 : Class4792
{
	private const float float_0 = 0.01f;

	internal const float float_1 = 3f;

	private Class4797[] class4797_0;

	private PointF[] pointF_0;

	private Class4794 class4794_0;

	private RectangleF rectangleF_0;

	private Color color_0 = Color.Empty;

	private Color color_1 = Color.Empty;

	private bool bool_0;

	private bool bool_1;

	private float float_2;

	internal RectangleF BoundingBox => rectangleF_0;

	internal Color BackgroundColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			bool_1 = true;
		}
	}

	internal Color BoundaryColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			bool_0 = true;
		}
	}

	internal bool IsBoundaryDefined => bool_0;

	internal bool IsBackgroundDefined => bool_1;

	internal virtual bool IsComposite => false;

	internal Class4794 Parent
	{
		get
		{
			return class4794_0;
		}
		set
		{
			class4794_0 = value;
		}
	}

	internal PointF[] VertexArray
	{
		get
		{
			if (pointF_0 == null)
			{
				pointF_0 = new PointF[4];
				pointF_0[0].X = BoundingBox.Left;
				pointF_0[0].Y = BoundingBox.Top;
				pointF_0[1].X = BoundingBox.Right;
				pointF_0[1].Y = BoundingBox.Top;
				pointF_0[2].X = BoundingBox.Right;
				pointF_0[2].Y = BoundingBox.Bottom;
				pointF_0[3].X = BoundingBox.Left;
				pointF_0[3].Y = BoundingBox.Bottom;
			}
			return pointF_0;
		}
	}

	internal bool CanConstructSegment
	{
		get
		{
			if (!IsComposite)
			{
				if (!(BoundingBox.Width <= 3f))
				{
					return BoundingBox.Height <= 3f;
				}
				return true;
			}
			return false;
		}
	}

	internal Class4797 AsSegment
	{
		get
		{
			PointF location = BoundingBox.Location;
			float num;
			PointF end;
			if (BoundingBox.Width > BoundingBox.Height)
			{
				num = BoundingBox.Height;
				location.Y += num / 2f;
				end = new PointF(BoundingBox.Right, location.Y);
			}
			else
			{
				num = BoundingBox.Width;
				location.X += num / 2f;
				end = new PointF(location.X, BoundingBox.Bottom);
			}
			Class4797 @class = new Class4797(location, end);
			@class.Color = BackgroundColor;
			@class.PageOrder = base.PageOrder;
			@class.Thickness = num;
			return @class;
		}
	}

	internal float BorderThickness => float_2;

	internal Class4797[] SideArray
	{
		get
		{
			if (class4797_0 == null)
			{
				int num = 4;
				class4797_0 = new Class4797[4];
				for (int i = 0; i < num; i++)
				{
					int num2 = ((i < num - 1) ? (i + 1) : 0);
					class4797_0[i] = new Class4797(VertexArray[i], VertexArray[num2]);
					class4797_0[i].Color = BoundaryColor;
					class4797_0[i].Thickness = BorderThickness;
					class4797_0[i].PageOrder = base.PageOrder;
				}
			}
			return class4797_0;
		}
	}

	internal Class4793(Class6217 source)
	{
		rectangleF_0 = smethod_8(source);
		color_1 = smethod_6(source);
		if (color_1 != Color.Empty)
		{
			bool_1 = true;
		}
	}

	internal Class4793(RectangleF rect)
	{
		rectangleF_0 = rect;
	}

	internal Class4793(Class6216 page)
	{
		rectangleF_0 = new RectangleF(0f, 0f, page.Width, page.Height);
		bool_1 = true;
		color_1 = Color.White;
	}

	internal Class4793(Class4793 source)
	{
		method_0(source);
		rectangleF_0 = source.rectangleF_0;
		class4794_0 = source.Parent;
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		RectangleF boundingBox = BoundingBox;
		boundingBox.X -= topLeft.X;
		boundingBox.Y -= topLeft.Y;
		if (IsBackgroundDefined)
		{
			using SolidBrush brush = new SolidBrush(BackgroundColor);
			canvas.FillRectangle(brush, boundingBox);
		}
		if (IsBoundaryDefined)
		{
			using (Pen pen = new Pen(BoundaryColor, BorderThickness))
			{
				Class4817.smethod_4(canvas, pen, boundingBox);
			}
		}
	}

	internal void method_0(Class4793 source)
	{
		color_1 = source.BackgroundColor;
		bool_1 = source.IsBackgroundDefined;
		color_0 = source.BoundaryColor;
		bool_0 = source.IsBoundaryDefined;
	}

	public override bool Equals(object obj)
	{
		bool result = false;
		Class4793 @class = obj as Class4793;
		if (@class != null)
		{
			result = smethod_15(BoundingBox.Left, @class.BoundingBox.Left) && smethod_15(BoundingBox.Right, @class.BoundingBox.Right) && smethod_15(BoundingBox.Top, @class.BoundingBox.Top) && smethod_15(BoundingBox.Bottom, @class.BoundingBox.Bottom) && Class4817.smethod_5(BoundaryColor, @class.BoundaryColor) && Class4817.smethod_5(BackgroundColor, @class.BackgroundColor);
		}
		return result;
	}

	public override int GetHashCode()
	{
		return rectangleF_0.GetHashCode() ^ BoundaryColor.GetHashCode() ^ BackgroundColor.GetHashCode();
	}

	public static bool operator ==(Class4793 left, Class4793 right)
	{
		return left?.Equals(right) ?? ((object)right == null);
	}

	public static bool operator !=(Class4793 left, Class4793 right)
	{
		return !(left == right);
	}

	internal bool method_1(out Class4793 box)
	{
		bool result = false;
		box = null;
		if (Parent != null && smethod_18(BoundingBox, Parent.BoundingBox, out var thickness))
		{
			box = new Class4793(Parent);
			box.float_2 = (float)thickness;
			box.BoundaryColor = Parent.BackgroundColor;
			box.BackgroundColor = BackgroundColor;
			result = true;
		}
		return result;
	}

	internal bool method_2(Class4793 possibleParent)
	{
		return RectangleF.Union(BoundingBox, possibleParent.BoundingBox) == possibleParent.BoundingBox;
	}

	internal bool method_3(PointF point)
	{
		if (point.X >= BoundingBox.Left && point.X <= BoundingBox.Right && point.Y >= BoundingBox.Top)
		{
			return point.Y <= BoundingBox.Bottom;
		}
		return false;
	}

	internal Class4798 method_4()
	{
		Class4798 @class = new Class4798();
		for (int i = 0; i < SideArray.Length; i++)
		{
			@class.Add(SideArray[i]);
		}
		return @class;
	}

	internal static Class4795 smethod_0(Class4793 top, Class4793 bottom)
	{
		Class4795 result = null;
		RectangleF rectangleF = RectangleF.Intersect(top.BoundingBox, bottom.BoundingBox);
		if (rectangleF.Width > 3f && rectangleF.Height > 3f)
		{
			result = new Class4795();
			ArrayList arrayList = new ArrayList(4);
			PointF[] vertexArray = bottom.VertexArray;
			for (int i = 0; i < 4; i++)
			{
				if (smethod_5(vertexArray[i], top))
				{
					arrayList.Add(vertexArray[i]);
				}
			}
			switch (arrayList.Count)
			{
			default:
				throw new ArgumentOutOfRangeException("Please report exception. Non-box object found.");
			case 0:
				result = smethod_9(top, bottom);
				break;
			case 1:
				result = smethod_16(top, bottom, (PointF)arrayList[0]);
				break;
			case 2:
				result = (top.method_5((PointF)arrayList[0]) ? smethod_2(top, bottom, (PointF)arrayList[0], (PointF)arrayList[1]) : smethod_17(top, bottom, (PointF)arrayList[0], (PointF)arrayList[1]));
				break;
			case 3:
				throw new ArgumentOutOfRangeException("Please report exception. Bad box rotation angle.");
			case 4:
				break;
			}
		}
		smethod_1(result);
		return result;
	}

	private static void smethod_1(Class4795 result)
	{
		if (result == null)
		{
			return;
		}
		for (int num = result.Count - 1; num >= 0; num--)
		{
			if (result[num].BoundingBox.Width == 0f || result[num].BoundingBox.Height == 0f)
			{
				result.RemoveAt(num);
			}
		}
	}

	private static Class4795 smethod_2(Class4793 top, Class4793 bottom, PointF pt1, PointF pt2)
	{
		Class4798 @class = bottom.method_4();
		@class.method_7(bottom.method_8(pt1));
		@class.method_7(bottom.method_8(pt2));
		if (@class.Count != 1)
		{
			throw new InvalidOperationException("Please report exception.");
		}
		PointF[] array = new PointF[4];
		int num = 0;
		for (int i = 0; i < top.SideArray.Length; i++)
		{
			if (@class[0].IsHorizontal != top.SideArray[i].IsHorizontal)
			{
				ref PointF reference = ref array[num++];
				reference = top.SideArray[i].Start;
				ref PointF reference2 = ref array[num++];
				reference2 = top.SideArray[i].End;
			}
		}
		Class4793 class2 = new Class4793(smethod_3(@class[0].End, @class[0].Start, smethod_14(@class[0].Start, array)));
		class2.method_0(bottom);
		Class4795 class3 = new Class4795(1);
		class3.Add(class2);
		return class3;
	}

	internal bool method_5(PointF point)
	{
		bool result = false;
		for (int i = 0; i < 4; i++)
		{
			if (SideArray[i].method_3(point))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal static RectangleF smethod_3(PointF pt1, PointF pt2, PointF pt3)
	{
		List<PointF> list = new List<PointF>(3);
		list.Add(pt1);
		list.Add(pt2);
		list.Add(pt3);
		return smethod_19(list);
	}

	internal static Class4795 smethod_4(Class4793 box, PointF point)
	{
		Class4795 @class = new Class4795(4);
		Class4797[] sideArray = box.SideArray;
		float[] array = new float[12];
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (sideArray[i].IsHorizontal)
			{
				array[num++] = sideArray[i].LeftVertex.Y;
				array[num++] = point.X;
				array[num++] = sideArray[i].RightVertex.Y;
			}
			else
			{
				array[num++] = sideArray[i].TopVertex.X;
				array[num++] = point.Y;
				array[num++] = sideArray[i].BottomVertex.X;
			}
		}
		@class.Add(new Class4793(RectangleF.FromLTRB(array[11], array[0], array[1], array[10])));
		@class.Add(new Class4793(RectangleF.FromLTRB(array[1], array[2], array[3], array[4])));
		@class.Add(new Class4793(RectangleF.FromLTRB(array[7], array[4], array[5], array[6])));
		@class.Add(new Class4793(RectangleF.FromLTRB(array[9], array[10], array[7], array[8])));
		for (int j = 0; j < @class.Count; j++)
		{
			@class[j].method_0(box);
		}
		return @class;
	}

	internal Class4798 method_6(Class4797 target, out PointF[] intersectionPoint)
	{
		Class4798 @class = new Class4798();
		for (int i = 0; i < 4; i++)
		{
			if (SideArray[i].method_0(target))
			{
				@class.Add(SideArray[i]);
			}
		}
		intersectionPoint = ((@class.Count > 0) ? new PointF[@class.Count] : null);
		for (int j = 0; j < @class.Count; j++)
		{
			if (target.IsVertical)
			{
				intersectionPoint[j].X = target.Start.X;
				intersectionPoint[j].Y = @class[j].Start.Y;
			}
			else
			{
				intersectionPoint[j].Y = target.Start.Y;
				intersectionPoint[j].X = @class[j].Start.X;
			}
		}
		return @class;
	}

	internal Class4797 method_7(Class4797 side)
	{
		if (side == null)
		{
			return null;
		}
		Class4797 result = null;
		for (int i = 0; i < 4; i++)
		{
			if (!(SideArray[i] == side) && SideArray[i].IsVertical == side.IsVertical)
			{
				result = SideArray[i];
				break;
			}
		}
		return result;
	}

	internal Class4798 method_8(PointF vertex)
	{
		Class4798 @class = new Class4798();
		method_9(vertex, out var s, out var s2);
		@class.Add(s);
		@class.Add(s2);
		return @class;
	}

	internal void method_9(PointF vertex, out Class4797 s1, out Class4797 s2)
	{
		s1 = null;
		s2 = null;
		for (int i = 0; i <= 1; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (i == 0)
				{
					if (SideArray[j].Start.Y == vertex.Y && SideArray[j].Start.X == vertex.X)
					{
						s1 = SideArray[j];
						break;
					}
				}
				else if (SideArray[j].End.Y == vertex.Y && SideArray[j].End.X == vertex.X)
				{
					s2 = SideArray[j];
					break;
				}
			}
		}
	}

	internal static bool smethod_5(PointF point, Class4793 box)
	{
		if (point.X >= box.BoundingBox.Left && point.X <= box.BoundingBox.Right && point.Y >= box.BoundingBox.Top)
		{
			return point.Y <= box.BoundingBox.Bottom;
		}
		return false;
	}

	internal static Color smethod_6(Class6217 source)
	{
		if (source.Brush.BrushType == Enum746.const_0)
		{
			return ((Class5997)source.Brush).Color.method_0();
		}
		return Color.Empty;
	}

	internal static bool smethod_7(Class6217 source)
	{
		if (source.Brush != null && source.Brush.BrushType == Enum746.const_0 && source.Pen == null && source.IsLastFigureClosed && source.Count == 1 && source[0] is Class6218 && ((Class6218)source[0])[0] is Class6223)
		{
			return ((Class6223)((Class6218)source[0])[0]).Points.Count == 4;
		}
		return false;
	}

	internal static RectangleF smethod_8(Class6217 source)
	{
		RectangleF result = RectangleF.Empty;
		Class6218 @class = source[0] as Class6218;
		if (@class[0] is Class6223 class2 && class2.Points.Count == 4)
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = false;
			bool flag4 = false;
			for (int i = 0; i < 4; i++)
			{
				int index = ((i != 3) ? (i + 1) : 0);
				bool flag5 = flag3;
				bool flag6 = flag4;
				flag3 = !Class4778.smethod_1(class2.Points[i].X, class2.Points[index].X, 0.009999999776482582);
				flag4 = !Class4778.smethod_1(class2.Points[i].Y, class2.Points[index].Y, 0.009999999776482582);
				if (flag3 != flag4 && (flag2 || ((!flag5 || !flag3) && (!flag6 || !flag4))))
				{
					flag2 = false;
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				result = smethod_19(class2.Points);
			}
		}
		return result;
	}

	private static Class4795 smethod_9(Class4793 top, Class4793 bottom)
	{
		if (top.method_2(bottom))
		{
			return new Class4795(0);
		}
		Class4798 topSides;
		Class4798 bottomSides;
		PointF[] points;
		byte nSidesOverlapped = smethod_10(top, bottom, out topSides, out bottomSides, out points);
		return smethod_11(nSidesOverlapped, bottom, topSides, bottomSides, points);
	}

	private static byte smethod_10(Class4793 top, Class4793 bottom, out Class4798 topSides, out Class4798 bottomSides, out PointF[] points)
	{
		topSides = new Class4798();
		bottomSides = new Class4798();
		points = new PointF[4];
		int num = 0;
		byte b = 0;
		for (int i = 0; i < bottom.SideArray.Length; i++)
		{
			PointF[] intersectionPoint;
			Class4798 @class = top.method_6(bottom.SideArray[i], out intersectionPoint);
			if (@class.Count != 0)
			{
				bottomSides.Add(bottom.SideArray[i]);
				b = (byte)(b + 1);
				for (int j = 0; j < @class.Count; j++)
				{
					topSides.Add(@class[j]);
					ref PointF reference = ref points[num++];
					reference = intersectionPoint[j];
				}
			}
		}
		return b;
	}

	private static Class4795 smethod_11(byte nSidesOverlapped, Class4793 bottom, Class4798 topSides, Class4798 bottomSides, PointF[] points)
	{
		return nSidesOverlapped switch
		{
			1 => smethod_12(bottom, topSides, bottomSides, points), 
			2 => smethod_13(bottom, bottomSides, points), 
			_ => throw new InvalidOperationException("Please report exception"), 
		};
	}

	private static Class4795 smethod_12(Class4793 bottom, Class4798 topSides, Class4798 bottomSide, PointF[] points)
	{
		if (topSides.Count == 2 && bottomSide.Count == 1)
		{
			Class4795 @class = new Class4795(3);
			PointF[] array = new PointF[2];
			PointF[] array2 = new PointF[2];
			for (int i = 0; i < 2; i++)
			{
				ref PointF reference = ref array2[i];
				reference = (bottom.method_3(topSides[i].Start) ? topSides[i].Start : topSides[i].End);
				ref PointF reference2 = ref array[i];
				reference2 = points[i];
			}
			for (int j = 0; j < 2; j++)
			{
				PointF pointF = ((j == 0) ? bottomSide[0].Start : bottomSide[0].End);
				PointF pointF2 = smethod_14(pointF, array);
				PointF pt = smethod_14(pointF2, array2);
				Class4793 class2 = new Class4793(smethod_3(pointF, pointF2, pt));
				class2.method_0(bottom);
				@class.Add(class2);
			}
			Class4797 class3 = bottom.method_7(bottomSide[0]);
			PointF start = class3.Start;
			if (class3.IsVertical)
			{
				start.X = array2[0].X;
			}
			else
			{
				start.Y = array2[0].Y;
			}
			Class4793 class4 = new Class4793(smethod_3(class3.Start, class3.End, start));
			class4.method_0(bottom);
			@class.Add(class4);
			return @class;
		}
		throw new ArgumentOutOfRangeException("Please report exception.");
	}

	private static Class4795 smethod_13(Class4793 bottom, Class4798 bottomSides, PointF[] points)
	{
		if (bottomSides.Count < 2)
		{
			throw new ArgumentOutOfRangeException("Please report exception.");
		}
		Class4795 @class = new Class4795();
		Class4798 class2 = bottom.method_4();
		class2.Remove(bottomSides[0]);
		class2.Remove(bottomSides[1]);
		for (int i = 0; i < 2; i++)
		{
			List<PointF> list = new List<PointF>(4);
			list.Add(class2[i].Start);
			list.Add(smethod_14(class2[i].Start, points));
			list.Add(class2[i].End);
			list.Add(smethod_14(class2[i].End, points));
			Class4793 class3 = new Class4793(smethod_19(list));
			class3.method_0(bottom);
			@class.Add(class3);
		}
		return @class;
	}

	private static PointF smethod_14(PointF target, PointF[] candidates)
	{
		PointF result = PointF.Empty;
		double num = double.PositiveInfinity;
		foreach (PointF pointF in candidates)
		{
			double num2 = Class4778.smethod_2(target, pointF);
			if (num2 < num)
			{
				result = pointF;
				num = num2;
			}
		}
		return result;
	}

	private static bool smethod_15(float side1, float side2)
	{
		return Class4778.smethod_1(side1, side2, 0.009999999776482582);
	}

	private static Class4795 smethod_16(Class4793 topRect, Class4793 bottomRect, PointF insidePt)
	{
		Class4795 @class = smethod_4(bottomRect, insidePt);
		int num = @class.Count - 1;
		while (num >= 0)
		{
			if (!@class[num].method_2(topRect))
			{
				num--;
				continue;
			}
			@class.RemoveAt(num);
			break;
		}
		return @class;
	}

	private static Class4795 smethod_17(Class4793 top, Class4793 bottom, PointF insidePt1, PointF insidePt2)
	{
		List<PointF> list = new List<PointF>(4);
		for (int i = 0; i <= 1; i++)
		{
			PointF pointF = ((i == 0) ? insidePt1 : insidePt2);
			bottom.method_9(pointF, out var s, out var s2);
			Class4798 @class = top.method_6(s, out var intersectionPoint);
			if (@class.Count >= 1)
			{
				list.Add((s.Start == pointF) ? s.End : s.Start);
				list.Add(intersectionPoint[0]);
			}
			else if (@class.Count == 0)
			{
				@class = top.method_6(s2, out intersectionPoint);
				if (@class.Count < 1)
				{
					throw new InvalidOperationException("Please report exception.");
				}
				list.Add((s2.Start == pointF) ? s2.End : s2.Start);
				list.Add(intersectionPoint[0]);
			}
		}
		Class4793 class2 = new Class4793(smethod_19(list));
		class2.method_0(bottom);
		Class4795 class3 = new Class4795();
		class3.Add(class2);
		return class3;
	}

	private static bool smethod_18(RectangleF r1, RectangleF r2, out double thickness)
	{
		ArrayList arrayList = new ArrayList(4);
		arrayList.Add((double)Math.Abs(r1.Left - r2.Left));
		arrayList.Add((double)Math.Abs(r1.Right - r2.Right));
		arrayList.Add((double)Math.Abs(r1.Top - r2.Top));
		arrayList.Add((double)Math.Abs(r1.Bottom - r2.Bottom));
		thickness = Class4816.smethod_0(arrayList);
		return thickness < 3.0;
	}

	private static RectangleF smethod_19(List<PointF> points)
	{
		if (points.Count < 3)
		{
			throw new ArgumentOutOfRangeException("At least 3 points required to define rectangle.");
		}
		float num = float.PositiveInfinity;
		float num2 = float.NegativeInfinity;
		float num3 = float.PositiveInfinity;
		float num4 = float.NegativeInfinity;
		for (int i = 0; i < points.Count; i++)
		{
			PointF pointF = points[i];
			if (pointF.X < num)
			{
				num = pointF.X;
			}
			if (pointF.X > num2)
			{
				num2 = pointF.X;
			}
			if (pointF.Y < num3)
			{
				num3 = pointF.Y;
			}
			if (pointF.Y > num4)
			{
				num4 = pointF.Y;
			}
		}
		return RectangleF.FromLTRB(num, num3, num2, num4);
	}
}
