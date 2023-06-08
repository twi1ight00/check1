using System;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3064 : Class3063
{
	private readonly Class3331 class3331_0;

	private readonly Class3453 class3453_0;

	private readonly Class3441 class3441_0;

	private readonly List<Struct159> list_0;

	public Class3064(Class3068 renderingAttributes)
		: base(renderingAttributes)
	{
		list_0 = new List<Struct159>();
		class3331_0 = renderingAttributes.Attributes.LineFillMode.vmethod_0();
		if (class3331_0 is Class3339 @class)
		{
			class3453_0 = @class.FillColor;
		}
		else
		{
			Class3336 class2 = class3331_0 as Class3336;
			if (class2 == null)
			{
				throw new NotImplementedException();
			}
		}
		class3441_0 = renderingAttributes.Attributes.LineStyle;
	}

	public void method_1(Class3031 contour)
	{
		list_0.Clear();
		method_12(contour);
	}

	public override void vmethod_0(Interface53 device)
	{
		int num = list_0.Count / 3;
		if (class3331_0 is Class3336)
		{
			return;
		}
		device.imethod_6();
		try
		{
			device.imethod_7(class3453_0);
			for (int i = 0; i < num; i++)
			{
				int num2 = i * 3;
				Struct159 point2D = list_0[num2];
				Struct159 point2D2 = list_0[num2 + 1];
				Struct159 point2D3 = list_0[num2 + 2];
				Class3427 @class = method_0(point2D);
				Class3427 class2 = method_0(point2D2);
				Class3427 class3 = method_0(point2D3);
				device.imethod_8(@class.X, @class.Y, @class.Z);
				device.imethod_8(class2.X, class2.Y, class2.Z);
				device.imethod_8(class3.X, class3.Y, class3.Z);
			}
		}
		finally
		{
			device.imethod_9();
		}
	}

	private double method_2(Class3440 endstyle, Class3441 olstyle)
	{
		switch (endstyle.Kind)
		{
		default:
			return 0.0;
		case Enum487.const_2:
			return endstyle.Length switch
			{
				Enum488.const_1 => (0.0 - olstyle.LineWidth) * 2.0, 
				Enum488.const_3 => (0.0 - olstyle.LineWidth) * 5.0, 
				_ => (0.0 - olstyle.LineWidth) * 3.0, 
			};
		case Enum487.const_3:
			return endstyle.Length switch
			{
				Enum488.const_1 => 0.0 - olstyle.LineWidth, 
				Enum488.const_3 => (0.0 - olstyle.LineWidth) * 3.0, 
				_ => (0.0 - olstyle.LineWidth) * 2.0, 
			};
		case Enum487.const_4:
		case Enum487.const_5:
			return endstyle.Length switch
			{
				Enum488.const_1 => 0.0 - olstyle.LineWidth, 
				Enum488.const_3 => (0.0 - olstyle.LineWidth) * 2.5, 
				_ => (0.0 - olstyle.LineWidth) * 1.5, 
			};
		}
	}

	private Struct159 method_3(Struct159 lp1, Struct159 lp2, Struct159 cp, double r)
	{
		Struct159[] array = new Struct159[2];
		if (lp1.X - lp2.X == 0.0)
		{
			if (Math.Abs(lp1.X - cp.X) > r)
			{
				return cp;
			}
			double num = Math.Sqrt(r * r - (lp1.X - cp.X) * (lp1.X - cp.X));
			ref Struct159 reference = ref array[0];
			reference = new Struct159(lp1.X, cp.Y - num);
			ref Struct159 reference2 = ref array[1];
			reference2 = new Struct159(lp1.X, cp.Y + num);
		}
		else
		{
			double num2 = (lp1.Y - lp2.Y) / (lp1.X - lp2.X);
			double num3 = lp1.Y - num2 * lp1.X;
			double num4 = Math.Pow(2.0 * num2 * num3 - 2.0 * cp.X - 2.0 * cp.Y * num2, 2.0) - (4.0 + 4.0 * num2 * num2) * (num3 * num3 - r * r + cp.X * cp.X + cp.Y * cp.Y - 2.0 * cp.Y * num3);
			if (num4 < 0.0)
			{
				return cp;
			}
			num4 = Math.Sqrt(num4);
			double num5 = (0.0 - (2.0 * num2 * num3 - 2.0 * cp.X - 2.0 * cp.Y * num2) + num4) / (2.0 + 2.0 * num2 * num2);
			double num = num2 * num5 + num3;
			if (num4 == 0.0)
			{
				return new Struct159(num5, num);
			}
			ref Struct159 reference3 = ref array[0];
			reference3 = new Struct159(num5, num);
			num5 = (0.0 - (2.0 * num2 * num3 - 2.0 * cp.X - 2.0 * cp.Y * num2) - num4) / (2.0 + 2.0 * num2 * num2);
			num = num2 * num5 + num3;
			ref Struct159 reference4 = ref array[1];
			reference4 = new Struct159(num5, num);
		}
		double num6 = Math.Pow(array[0].X - lp1.X, 2.0) + Math.Pow(array[0].Y - lp1.Y, 2.0) + Math.Pow(array[0].X - lp2.X, 2.0) + Math.Pow(array[0].Y - lp2.Y, 2.0);
		double num7 = Math.Pow(array[1].X - lp1.X, 2.0) + Math.Pow(array[1].Y - lp1.Y, 2.0) + Math.Pow(array[1].X - lp2.X, 2.0) + Math.Pow(array[1].Y - lp2.Y, 2.0);
		if (num6 < num7)
		{
			return array[0];
		}
		return array[1];
	}

	private void method_4(ref List<Struct159> points, double delta, bool side)
	{
		int count = points.Count;
		if (count < 2 || delta <= 0.0)
		{
			return;
		}
		double num = delta * delta;
		if (side)
		{
			int num2 = count - 1;
			Struct159 cp = points[num2];
			while (num2 > 0)
			{
				num2--;
				Struct159 lp = points[num2];
				double num3 = Math.Pow(lp.X - cp.X, 2.0) + Math.Pow(lp.Y - cp.Y, 2.0);
				if (num3 <= num)
				{
					if (num3 == num)
					{
						if (num2 + 2 < points.Count)
						{
							points.RemoveRange(num2 + 1, points.Count - 2 - num2);
						}
						return;
					}
					continue;
				}
				Struct159 item = method_3(lp, points[num2 + 1], cp, delta);
				if (num2 + 2 < points.Count)
				{
					points.RemoveRange(num2 + 1, points.Count - 2 - num2);
				}
				points.Insert(points.Count - 1, item);
				return;
			}
		}
		else
		{
			int num2 = 0;
			Struct159 cp = points[0];
			while (num2 < count - 1)
			{
				num2++;
				Struct159 lp = points[num2];
				double num3 = Math.Pow(lp.X - cp.X, 2.0) + Math.Pow(lp.Y - cp.Y, 2.0);
				if (num3 <= num)
				{
					if (num3 == num)
					{
						if (num2 > 1)
						{
							points.RemoveRange(1, num2 - 1);
						}
						return;
					}
					continue;
				}
				Struct159 item = method_3(lp, points[num2 - 1], cp, delta);
				if (num2 > 1)
				{
					points.RemoveRange(1, num2 - 1);
				}
				points.Insert(1, item);
				return;
			}
		}
		points.RemoveRange(1, points.Count - 2);
	}

	private Struct159 method_5(Struct159 sharp, Struct159 bold, double width, double length)
	{
		Struct158 a = Struct158.smethod_0(bold, sharp).method_1();
		Struct158 right = Struct158.smethod_5(new Struct158(0.0 - a.Dy, a.Dx), width / 2.0);
		Struct159 @struct = Struct158.smethod_4(sharp, Struct158.smethod_5(a, length));
		method_16(sharp, Struct158.smethod_3(@struct, right), Struct158.smethod_4(@struct, right));
		return Struct158.smethod_3(@struct, Struct158.smethod_5(Struct159.smethod_0(sharp, @struct), 0.05));
	}

	private Struct159 method_6(Struct159 sharp, Struct159 bold, double width, double length)
	{
		Struct158 a = Struct158.smethod_0(bold, sharp).method_1();
		Struct158 right = Struct158.smethod_5(new Struct158(0.0 - a.Dy, a.Dx), width / 2.0);
		Struct159 left = Struct158.smethod_4(sharp, Struct158.smethod_5(a, length));
		method_16(sharp, bold, Struct158.smethod_3(left, right));
		method_16(sharp, bold, Struct158.smethod_4(left, right));
		return Struct158.smethod_3(bold, Struct158.smethod_5(Struct159.smethod_0(sharp, bold), 0.01));
	}

	private Struct159 method_7(Struct159 end, Struct159 control, double width, double length)
	{
		Struct158 a = Struct158.smethod_0(control, end).method_1();
		Struct158 right = Struct158.smethod_5(new Struct158(0.0 - a.Dy, a.Dx), width / 2.0);
		a = Struct158.smethod_6(Struct158.smethod_5(a, length), 2.0);
		method_16(Struct158.smethod_3(end, right), Struct158.smethod_3(end, a), Struct158.smethod_4(end, right));
		method_16(Struct158.smethod_3(end, right), Struct158.smethod_4(end, a), Struct158.smethod_4(end, right));
		return end;
	}

	private void method_8(Struct159 end, Struct159 control, double width, double length)
	{
		Struct158 @struct = Struct158.smethod_0(control, end);
		double num = @struct.Dx / @struct.Norm;
		double num2 = @struct.Dy / @struct.Norm;
		double num3 = Math.PI / 36.0;
		for (double num4 = num3; num4 < 6.284185307179587; num4 += num3)
		{
			double num5 = Math.Cos(num4 - num3) * (length / 2.0);
			double num6 = Math.Sin(num4 - num3) * (width / 2.0);
			double x = num5 * num - num6 * num2;
			double y = num5 * num2 + num6 * num;
			Struct159 struct2 = new Struct159(x, y);
			num5 = Math.Cos(num4) * (length / 2.0);
			num6 = Math.Sin(num4) * (width / 2.0);
			x = num5 * num - num6 * num2;
			y = num5 * num2 + num6 * num;
			Struct159 struct3 = new Struct159(x, y);
			method_16(end, new Struct159(end.X + struct2.X, end.Y + struct2.Y), new Struct159(end.X + struct3.X, end.Y + struct3.Y));
		}
	}

	private Struct159 method_9(Struct159 sharp, Struct159 bold, double width, double length)
	{
		Struct158 a = Struct158.smethod_0(bold, sharp).method_1();
		Struct158 right = Struct158.smethod_5(a, length);
		Struct158 right2 = Struct158.smethod_5(new Struct158(0.0 - a.Dy, a.Dx), width / 2.0);
		Struct159 @struct = Struct158.smethod_4(Struct158.smethod_4(bold, right), right2);
		Struct159 struct2 = Struct158.smethod_3(Struct158.smethod_4(bold, right), right2);
		method_15(@struct, bold, class3441_0.LineWidth);
		method_15(struct2, bold, class3441_0.LineWidth);
		method_22(@struct, bold, struct2, class3441_0.LineWidth);
		method_8(@struct, bold, class3441_0.LineWidth, class3441_0.LineWidth);
		method_8(struct2, bold, class3441_0.LineWidth, class3441_0.LineWidth);
		return Struct158.smethod_3(bold, Struct158.smethod_5(Struct159.smethod_0(sharp, bold), 0.01));
	}

	private Struct159 method_10(Struct159 end, Struct159 control, double width)
	{
		Struct158 right = Struct158.smethod_6(Struct158.smethod_5(Struct158.smethod_0(control, end).method_1(), width), 2.0);
		return Struct158.smethod_3(end, right);
	}

	private void method_11(ref List<Struct159> points, Class3441 olstyle)
	{
		if (points.Count < 2)
		{
			return;
		}
		double num = 0.0;
		for (int i = 0; i < 2; i++)
		{
			bool flag;
			Class3440 @class = ((!(flag = i > 0)) ? olstyle.HeadEnd : olstyle.TailEnd);
			double num2 = 2.0;
			double num3 = 3.0;
			double num4 = 5.0;
			double num5 = 2.0;
			double num6 = 3.0;
			double num7 = 5.0;
			if (@class.Kind == Enum487.const_6)
			{
				num4 = 4.5;
				num5 = 2.5;
				num6 = 3.5;
			}
			double num8 = @class.Length switch
			{
				Enum488.const_1 => olstyle.LineWidth * num2, 
				Enum488.const_2 => olstyle.LineWidth * num3, 
				Enum488.const_3 => olstyle.LineWidth * num4, 
				_ => olstyle.LineWidth * num3, 
			};
			double num9 = @class.Width switch
			{
				Enum489.const_1 => olstyle.LineWidth * num5, 
				Enum489.const_2 => olstyle.LineWidth * num6, 
				Enum489.const_3 => olstyle.LineWidth * num7, 
				_ => olstyle.LineWidth * num6, 
			};
			if (@class.Kind == Enum487.const_6)
			{
				double num10 = Math.Sqrt(Math.Pow(num8, 2.0) + Math.Pow(num9 / 2.0, 2.0));
				double num11 = num9 / 2.0;
				double num12 = num11 / num10;
				num = (0.0 - olstyle.LineWidth) / 2.0 / num12;
			}
			else
			{
				num = method_2(@class, olstyle);
			}
			if (num < 0.0)
			{
				method_4(ref points, 0.0 - num, flag);
			}
			int num13;
			int index;
			if (flag)
			{
				num13 = points.Count - 1;
				index = num13 - 1;
			}
			else
			{
				num13 = 0;
				index = 1;
			}
			switch (@class.Kind)
			{
			case Enum487.const_2:
			{
				Struct159 value = method_5(points[num13], points[index], num9, num8);
				points[num13] = value;
				break;
			}
			case Enum487.const_3:
			{
				Struct159 value = method_6(points[num13], points[index], num9, num8);
				points[num13] = value;
				break;
			}
			case Enum487.const_4:
				method_7(points[num13], points[index], num9, num8);
				break;
			case Enum487.const_5:
				method_8(points[num13], points[index], num9, num8);
				break;
			case Enum487.const_6:
			{
				Struct159 value = method_9(points[num13], points[index], num9, num8);
				points[num13] = value;
				break;
			}
			}
		}
	}

	private void method_12(Class3031 contour)
	{
		List<Struct159> points = smethod_0(contour);
		if (points.Count <= 1)
		{
			return;
		}
		if (!contour.IsClosed)
		{
			method_11(ref points, class3441_0);
		}
		Class3067 @class = new Class3067(points.ToArray(), contour.IsClosed);
		Class3438 class2 = ((class3441_0.LineDash != null) ? (class3441_0.LineDash as Class3438) : new Class3438());
		if (class2 == null)
		{
			Class3439 class3 = (Class3439)class3441_0.LineDash;
			class2 = class3.method_0();
		}
		Class3067 class4 = @class.method_1(class2, class3441_0.LineWidth);
		switch (class3441_0.LineEndingCapType)
		{
		case Enum486.const_1:
			class4 = class4.method_3(class3441_0.LineWidth);
			method_25(class4);
			break;
		case Enum486.const_2:
			class4 = class4.method_2(class3441_0.LineWidth, class3441_0.HeadEnd.Kind, class3441_0.TailEnd.Kind);
			break;
		}
		double[] array = smethod_2(class3441_0.CompoundLineType);
		for (int i = 0; i < array.Length / 2; i++)
		{
			Class3067 class5 = class4.method_4(class3441_0.LineWidth, array[i * 2], array[i * 2 + 1]);
			double width = (array[i * 2 + 1] - array[i * 2]) * class3441_0.LineWidth;
			foreach (Class3066 item in class5)
			{
				method_14(item, width);
				if (item.Prev != null)
				{
					method_18(item, width);
				}
			}
		}
	}

	private static List<Struct159> smethod_0(Class3031 src)
	{
		int num = src.PointsCount;
		int num2 = src.PointsCount - 1;
		if (src.IsClosed)
		{
			num2++;
		}
		for (int i = 0; i < num2; i++)
		{
			Struct159 @struct = src[i];
			Struct159 point = src[(i + 1) % src.PointsCount];
			if (@struct.method_0(point))
			{
				num--;
			}
		}
		List<Struct159> list = new List<Struct159>(num);
		for (int j = 0; j < src.PointsCount; j++)
		{
			Struct159 item = src[j];
			Struct159 point2 = src[(j + 1) % src.PointsCount];
			if ((num2 == j && !src.IsClosed) || !item.method_0(point2))
			{
				list.Add(item);
			}
		}
		return list;
	}

	private Struct158 method_13(Struct159 begin, Struct159 end, double width)
	{
		if (class3441_0.StrokeAlignment != 0)
		{
			throw new NotImplementedException();
		}
		Struct158 @struct = Struct158.smethod_0(end, begin).method_1();
		Struct158 a = new Struct158(0.0 - @struct.Dy, @struct.Dx);
		return Struct158.smethod_5(a, width / 2.0);
	}

	private void method_14(Class3066 segment, double width)
	{
		Struct159 begin = segment.Begin;
		Struct159 end = segment.End;
		if (segment.Prev != null && segment.method_0(segment.Prev))
		{
			Struct159 @struct = segment.method_1(segment.Prev);
			Struct158 vector = Struct158.smethod_0(segment.Begin, @struct);
			if (vector.Norm > 1E-06 && Math.Abs(segment.method_2().method_0(vector)) < 1E-06 && segment.method_2().Norm > vector.Norm)
			{
				begin = @struct;
			}
		}
		if (segment.Next != null && segment.method_0(segment.Next))
		{
			Struct159 struct2 = segment.method_1(segment.Next);
			Struct158 vector2 = Struct158.smethod_0(segment.End, struct2);
			if (vector2.Norm > 1E-06 && Math.Abs(segment.method_2().method_0(vector2) - Math.PI) < 1E-06 && segment.method_2().Norm > vector2.Norm)
			{
				end = struct2;
			}
		}
		method_15(begin, end, width);
	}

	private void method_15(Struct159 begin, Struct159 end, double width)
	{
		Struct158 right = method_13(begin, end, width);
		Struct159 p = Struct158.smethod_3(begin, right);
		Struct159 @struct = Struct158.smethod_4(begin, right);
		Struct159 struct2 = Struct158.smethod_3(end, right);
		Struct159 p2 = Struct158.smethod_4(end, right);
		method_16(@struct, p, struct2);
		method_16(struct2, p2, @struct);
	}

	private void method_16(Struct159 p0, Struct159 p1, Struct159 p2)
	{
		list_0.Add(p0);
		list_0.Add(p1);
		list_0.Add(p2);
	}

	private void method_17(Class3067 list)
	{
		_ = class3441_0.LineEndingCapType;
	}

	private void method_18(Class3066 segment, double width)
	{
		switch (class3441_0.LineJoinType)
		{
		default:
			throw new NotImplementedException();
		case Enum490.const_1:
			method_23(segment, width);
			break;
		case Enum490.const_2:
			method_19(segment, width);
			break;
		case Enum490.const_3:
			method_21(segment, width);
			break;
		}
	}

	private void method_19(Class3066 segment, double width)
	{
		if (segment.Prev != null && segment.method_0(segment.Prev))
		{
			Struct159 @struct = segment.method_1(segment.Prev);
			Struct158 vector = Struct158.smethod_0(segment.Prev.End, @struct);
			if (!(vector.Norm < 1E-06) && Math.Abs(segment.Prev.method_2().method_0(vector) - Math.PI) >= 1E-06)
			{
				method_15(segment.Prev.End, segment.Begin, width);
				method_20(segment.Prev.Begin, segment.Prev.End, segment.Begin, width);
				method_20(segment.Prev.End, segment.Begin, segment.End, width);
			}
			else
			{
				method_20(segment.Prev.Begin, @struct, segment.End, width);
			}
		}
	}

	private void method_20(Struct159 begin, Struct159 middle, Struct159 end, double width)
	{
		if (smethod_1(begin, middle, end))
		{
			method_20(end, middle, begin, width);
		}
		Struct158 @struct = method_13(begin, middle, width);
		Struct158 right = method_13(middle, end, width);
		if (!(Struct158.smethod_1(@struct, right).Norm < 1E-06))
		{
			Struct159 p = Struct158.smethod_3(middle, @struct);
			Struct159 p2 = Struct158.smethod_3(middle, right);
			method_16(p, middle, p2);
		}
	}

	private void method_21(Class3066 segment, double width)
	{
		if (segment.Prev == null || !segment.method_0(segment.Prev))
		{
			return;
		}
		Struct159 @struct = segment.method_1(segment.Prev);
		if (Math.Abs(segment.method_2().method_0(segment.Prev.method_2()) - Math.PI) > Math.PI / 180.0)
		{
			Struct158 vector = Struct158.smethod_0(segment.Prev.End, @struct);
			if (vector.Norm > 1E-06 && Math.Abs(segment.Prev.method_2().method_0(vector)) < 0.001)
			{
				method_15(segment.Prev.End, @struct, width);
			}
			vector = Struct158.smethod_0(segment.Begin, @struct);
			if (vector.Norm > 1E-06 && Math.Abs(segment.method_2().method_0(vector) - Math.PI) < 0.001)
			{
				method_15(@struct, segment.Begin, width);
			}
		}
		method_22(segment.Prev.Begin, @struct, segment.End, width);
	}

	private void method_22(Struct159 begin, Struct159 middle, Struct159 end, double width)
	{
		if (smethod_1(begin, middle, end))
		{
			method_22(end, middle, begin, width);
			return;
		}
		Struct158 @struct = method_13(begin, middle, width);
		Struct158 right = method_13(middle, end, width);
		Struct158 struct2 = Struct158.smethod_1(@struct, right);
		if (Math.Abs(struct2.Norm) < 1E-06)
		{
			return;
		}
		struct2 = struct2.method_1();
		double num = Struct158.smethod_8(@struct.method_1(), struct2);
		if (Math.Abs(num) < 1E-06)
		{
			return;
		}
		Struct158 right2 = Struct158.smethod_5(struct2, @struct.Norm / num);
		Struct159 struct3 = Struct158.smethod_3(middle, @struct);
		Struct159 struct4 = Struct158.smethod_3(middle, right);
		if (class3441_0.MeterJoinLimit <= 100000.0)
		{
			method_16(struct3, struct4, middle);
			return;
		}
		Struct159 p = Struct158.smethod_3(middle, right2);
		double num2 = class3441_0.MeterJoinLimit * width / 200000.0;
		if (right2.Norm > num2)
		{
			double num3 = Math.Sqrt(Math.Pow(num2, 2.0) - Math.Pow(width / 2.0, 2.0));
			Struct158 a = Struct158.smethod_0(begin, middle);
			Struct158 a2 = Struct158.smethod_0(end, middle);
			a = Struct158.smethod_5(a, num3 / a.Norm);
			a2 = Struct158.smethod_5(a2, num3 / a2.Norm);
			Struct159 p2 = Struct158.smethod_3(struct3, a);
			Struct159 struct5 = Struct158.smethod_3(struct4, a2);
			method_16(struct3, p2, middle);
			method_16(middle, p2, struct5);
			method_16(middle, struct5, struct4);
		}
		else
		{
			method_16(struct3, p, middle);
			method_16(struct4, p, middle);
		}
	}

	private void method_23(Class3066 segment, double width)
	{
		if (segment.Prev != null && segment.method_0(segment.Prev))
		{
			Struct159 @struct = segment.method_1(segment.Prev);
			Class3066 @class = segment.Prev;
			Class3066 class2 = segment;
			if (!smethod_1(@class.Begin, @struct, class2.End))
			{
				@class = new Class3066(segment.End, segment.Begin);
				class2 = new Class3066(segment.Prev.End, segment.Prev.Begin);
			}
			Struct158 right = @class.method_2().method_2();
			Struct158 right2 = class2.method_2().method_2();
			double num = Math.Atan2(right.Dy, right.Dx);
			num = ((num < 0.0) ? (num + Math.PI * 2.0) : num);
			double num2 = Math.Atan2(right2.Dy, right2.Dx);
			num2 = ((num2 < 0.0) ? (num2 + Math.PI * 2.0) : num2);
			num = ((num < num2) ? (num + Math.PI * 2.0) : num);
			Struct158 vector = Struct158.smethod_0(@class.End, @struct);
			if (!(vector.Norm < 1E-06) && Math.Abs(@class.method_2().method_0(vector) - Math.PI) >= 1E-06)
			{
				Class3066 class3 = new Class3066(@class.End, Struct158.smethod_3(@class.End, right));
				Class3066 segment2 = new Class3066(class2.Begin, Struct158.smethod_3(class2.Begin, right2));
				Struct159 struct2 = class3.method_1(segment2);
				Struct158 struct3 = Struct158.smethod_0(struct2, segment.Begin);
				double radius = struct3.Norm - width / 2.0;
				double radius2 = struct3.Norm + width / 2.0;
				method_24(struct2, num2, num, radius, radius2);
			}
			else
			{
				Struct159 center = @struct;
				double radius3 = width / 2.0;
				method_24(center, num2, num, 0.0, radius3);
			}
		}
	}

	private void method_24(Struct159 center, double angle1, double angle2, double radius1, double radius2)
	{
		double num = 36.0;
		double num2 = (angle2 - angle1) / num;
		for (double num3 = angle1; angle2 - num3 > num2; num3 += num2)
		{
			double num4 = Math.Cos(num3);
			double num5 = Math.Sin(num3);
			double num6 = Math.Cos(num3 + num2);
			double num7 = Math.Sin(num3 + num2);
			double num8 = num4 * radius1;
			double num9 = num5 * radius1;
			double num10 = num4 * radius2;
			double num11 = num5 * radius2;
			double num12 = num6 * radius1;
			double num13 = num7 * radius1;
			double num14 = num6 * radius2;
			double num15 = num7 * radius2;
			method_16(new Struct159(center.X + num8, center.Y + num9), new Struct159(center.X + num10, center.Y + num11), new Struct159(center.X + num12, center.Y + num13));
			method_16(new Struct159(center.X + num12, center.Y + num13), new Struct159(center.X + num14, center.Y + num15), new Struct159(center.X + num10, center.Y + num11));
		}
	}

	private void method_25(Class3067 list)
	{
		foreach (Class3066 item in list)
		{
			Struct158 @struct = item.method_2();
			double num = Math.Atan2(@struct.Dy, @struct.Dx);
			num = ((num < 0.0) ? (Math.PI * 2.0 + num) : num);
			if (item.Prev == null)
			{
				method_24(item.Begin, num + Math.PI / 2.0, num + 4.71238898038469, 0.0, class3441_0.LineWidth / 2.0);
			}
			if (item.Next == null)
			{
				method_24(item.End, num + 4.71238898038469, num + 7.853981633974483, 0.0, class3441_0.LineWidth / 2.0);
			}
		}
	}

	private static bool smethod_1(Struct159 a, Struct159 b, Struct159 c)
	{
		double num = b.X - a.X;
		double num2 = b.Y - a.Y;
		double num3 = c.X - b.X;
		double num4 = c.Y - b.Y;
		return num * num4 - num3 * num2 < 0.0;
	}

	private static double[] smethod_2(Enum485 type)
	{
		switch (type)
		{
		default:
			throw new NotImplementedException();
		case Enum485.const_0:
		case Enum485.const_1:
			return new double[2] { 0.0, 1.0 };
		case Enum485.const_2:
			return new double[4]
			{
				0.0,
				1.0 / 3.0,
				2.0 / 3.0,
				1.0
			};
		case Enum485.const_3:
			return new double[4] { 0.0, 0.6, 0.8, 1.0 };
		case Enum485.const_4:
			return new double[4] { 0.0, 0.2, 0.4, 1.0 };
		case Enum485.const_5:
			return new double[6]
			{
				0.0,
				1.0 / 6.0,
				1.0 / 3.0,
				2.0 / 3.0,
				5.0 / 6.0,
				1.0
			};
		}
	}
}
