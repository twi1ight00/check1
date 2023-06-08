using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns56;

namespace ns8;

internal class Class123 : Class120
{
	private class Class844
	{
		private double double_0;

		private double double_1;

		private double double_2;

		public double Radius => double_0;

		public Class844(double maxWidth, double maxHeight, double startAngle, double sweepAngle, bool includeCenter)
		{
			double_1 = startAngle - 90.0;
			if (double_1 < 0.0)
			{
				double_1 += 360.0;
			}
			double_2 = sweepAngle;
			Struct47 @struct = smethod_0(smethod_1(double_1, double_2), includeCenter);
			double_0 = Math.Min(maxWidth / ((@struct.Width != 0.0) ? @struct.Width : 1.0), maxHeight / ((@struct.Height != 0.0) ? @struct.Height : 1.0));
		}

		public double[] method_0(int nodesCount, bool isFirstNodeInCenter, out double step)
		{
			double num = double_1;
			double num2;
			if (double_2 > 0.0)
			{
				num2 = num + double_2;
			}
			else
			{
				num = smethod_16(double_2 + num, allowLargeAngles: false);
				num2 = num - double_2;
			}
			int num3 = (isFirstNodeInCenter ? (nodesCount - 1) : nodesCount);
			List<double> list = new List<double>();
			if (isFirstNodeInCenter)
			{
				list.Add(double.NaN);
			}
			if (num3 > 0)
			{
				double num4 = num2 - num;
				step = ((Math.Abs(double_2) == 360.0 || num3 == 1) ? (num4 / (double)num3) : (num4 / (double)(num3 - 1)));
				for (int i = 0; i < num3; i++)
				{
					list.Add(smethod_16(num, allowLargeAngles: false));
					num += step;
				}
				if (double_2 < 0.0)
				{
					double[] array = new double[list.Count];
					int num5 = 0;
					if (isFirstNodeInCenter)
					{
						array[0] = list[0];
						num5++;
					}
					if (double_2 == -360.0)
					{
						array[num5] = list[num5];
						num5++;
					}
					int num6 = array.Length - 1;
					for (int j = num5; j < array.Length; j++)
					{
						array[j] = list[num6];
						num6--;
					}
					return array;
				}
			}
			else
			{
				step = 0.0;
			}
			return list.ToArray();
		}

		private static Struct47 smethod_0(double[] angles, bool includeCenter)
		{
			Struct47 @struct = new Struct47(0.0, 0.0, 0.0, 0.0);
			Struct50 struct2 = new Struct50(Math.Cos(smethod_15(angles[0])), Math.Sin(smethod_15(angles[0])));
			for (int i = 1; i < angles.Length; i++)
			{
				Struct50 struct3 = new Struct50(Math.Cos(smethod_15(angles[i])), Math.Sin(smethod_15(angles[i])));
				@struct = ((i != 1 || includeCenter) ? Struct47.smethod_1(@struct, new Struct47(struct2.Dx, struct2.Dy, struct3.Dx, struct3.Dy)) : new Struct47(struct2.Dx, struct2.Dy, struct3.Dx, struct3.Dy));
				struct2 = struct3;
			}
			return @struct;
		}

		private static double[] smethod_1(double startAgle, double sweep)
		{
			if (sweep == 360.0)
			{
				return new double[1] { startAgle };
			}
			List<double> list = new List<double>();
			double num;
			if (sweep > 0.0)
			{
				num = startAgle + sweep;
			}
			else
			{
				startAgle = smethod_16(sweep + startAgle, allowLargeAngles: false);
				num = startAgle - sweep;
			}
			list.Add(startAgle);
			while (startAgle < num)
			{
				double num2 = smethod_2(smethod_16(startAgle, allowLargeAngles: false));
				if ((double)((startAgle > 360.0) ? 360 : 0) + num2 < smethod_16(num, allowLargeAngles: true) && !list.Contains(num2))
				{
					list.Add(num2);
				}
				startAgle += 90.0;
			}
			num = smethod_16(num, allowLargeAngles: false);
			if (list.Contains(num))
			{
				list.Add(smethod_16(num, allowLargeAngles: false));
			}
			return list.ToArray();
		}

		private static double smethod_2(double angle)
		{
			if (angle == 0.0)
			{
				return angle;
			}
			if (angle > 0.0 && angle <= 90.0)
			{
				return 90.0;
			}
			if (angle > 90.0 && angle <= 180.0)
			{
				return 180.0;
			}
			if (angle > 180.0 && angle <= 270.0)
			{
				return 270.0;
			}
			return 360.0;
		}
	}

	public override bool HideLastTransition => true;

	private Class107 CycleParameter => (Class107)base.Parameter;

	public override bool vmethod_2(Class837 point)
	{
		Class107 cycleParameter = CycleParameter;
		List<Class837> list = point.method_39();
		int count = list.Count;
		if (count != 0)
		{
			double sweepAngle = ((cycleParameter.SpanAngle == 0.0) ? 360.0 : cycleParameter.SpanAngle);
			double startAngle = ((cycleParameter.StartAngle < 0.0) ? (360.0 + cycleParameter.StartAngle) : cycleParameter.StartAngle);
			double num = point.method_30(Enum305.const_62);
			double num2 = point.method_30(Enum305.const_16);
			Class844 @class = new Class844(num, num2, startAngle, sweepAngle, cycleParameter.IsFirstInCenter);
			double num3 = @class.Radius;
			double num4 = point.method_30(Enum305.const_30);
			double step;
			double[] array = @class.method_0(count, cycleParameter.IsFirstInCenter, out step);
			double[] array2 = new double[count];
			Struct47[] array3 = new Struct47[count];
			for (int i = 0; i < count; i++)
			{
				Class837 class2 = list[i];
				array2[i] = (class2.method_23(Enum305.const_30) ? class2.method_30(Enum305.const_30) : 0.0);
				if (array2[i] == 0.0 && class2.method_1(class2.AssociatedWith.Type, Enum332.const_3) && class2.ConnectedWith.Count > 0)
				{
					array2[i] = num4;
				}
				Struct48 @struct = smethod_10(class2);
				ref Struct47 reference = ref array3[i];
				reference = new Struct47(smethod_17(array[i]), num3, @struct.Width, @struct.Height);
			}
			if (cycleParameter.IsFirstInCenter)
			{
				Class837 class3 = list[0];
				array2[0] = (class3.method_23(Enum305.const_31) ? class3.method_30(Enum305.const_31) : point.method_30(Enum305.const_31));
			}
			if (count > 1)
			{
				bool isCircles = list[0].ShapeContainer.Shape != null && list[0].ShapeContainer.Shape.ShapeType == ShapeType.Ellipse && list[1].ShapeContainer.Shape != null && list[1].ShapeContainer.Shape.ShapeType == ShapeType.Ellipse;
				bool flag;
				num3 = ((!(flag = method_9(array3, array2, isCircles))) ? (num3 * 0.98) : (num3 * 1.02));
				while (!(num3 <= 1E-05) && Class120.smethod_4(smethod_14(new Struct47(array3), num, num2)))
				{
					for (int j = 0; j < count; j++)
					{
						Struct48 struct2 = smethod_10(list[j]);
						ref Struct47 reference2 = ref array3[j];
						reference2 = new Struct47(smethod_17(array[j]), num3, struct2.Width, struct2.Height);
					}
					bool flag2;
					if ((flag2 = method_9(array3, array2, isCircles)) != flag)
					{
						break;
					}
					num3 = ((!flag2) ? (num3 * 0.98) : (num3 * 1.02));
				}
			}
			Struct47 bounds = new Struct47(array3);
			double ratio = Math.Min(1.0, smethod_14(bounds, num, num2));
			for (int k = 0; k < count; k++)
			{
				Class837 class4 = list[k];
				Class851 shapeContainer = class4.ShapeContainer;
				double diffX = array3[k].X - shapeContainer.OffsetToParent.Dx - bounds.X;
				double diffY = array3[k].Y - shapeContainer.OffsetToParent.Dy - bounds.Y;
				if (cycleParameter.IsAlongPath)
				{
					shapeContainer.method_11(smethod_16(array[k] + 90.0, allowLargeAngles: false));
				}
				shapeContainer.method_6(diffX, diffY);
				class4.method_24(ratio, Enum305.const_16, Enum305.const_62);
				method_8(class4, array[k], step, num3, new Struct46(bounds.X, bounds.Y), (double)point.Children.Count / (double)count);
			}
			bounds = new Struct47(array3);
			point.method_24(ratio, Enum305.const_30, Enum305.const_31);
			point.method_26();
			point.ShapeContainer.Width = bounds.Width;
			point.ShapeContainer.Height = bounds.Height;
			if (Class120.smethod_4(ratio))
			{
				return false;
			}
			point.method_28(Enum305.const_13, num3 * 2.0);
			Class120.smethod_8(point, cycleParameter.HorizontalAlignment, cycleParameter.VerticalAlignment);
		}
		return true;
	}

	public override Struct50 vmethod_5(Class837 childNode)
	{
		Class851 shapeContainer = childNode.ShapeContainer;
		Struct50 result = new Struct50(shapeContainer.method_13(Enum135.const_2), shapeContainer.method_13(Enum135.const_3));
		if (result.Length == 0.0)
		{
			return base.vmethod_5(childNode);
		}
		return result;
	}

	private void method_8(Class837 nonConnector, double angle, double step, double radius, Struct46 center, double allChildrenToNonEmptyRatio)
	{
		Class851 shapeContainer = nonConnector.ShapeContainer;
		int custRadScaleRad = nonConnector.DataPoint.PropertySet.CustRadScaleRad;
		int custRadScaleInc = nonConnector.DataPoint.PropertySet.CustRadScaleInc;
		if (custRadScaleRad != 0 || custRadScaleInc != 0)
		{
			Struct48 @struct = smethod_10(nonConnector);
			double num = ((custRadScaleRad != 0) ? ((double)custRadScaleRad / 100000.0) : 1.0);
			if (custRadScaleInc != 0)
			{
				double num2 = (double)custRadScaleInc / 100000.0;
				angle += step * (num2 / allChildrenToNonEmptyRatio);
			}
			Struct47 struct2 = new Struct47(smethod_17(angle), radius * num, @struct.Width, @struct.Height);
			nonConnector.ShapeContainer.method_14(Enum135.const_2, struct2.X - center.X - shapeContainer.OffsetToParent.Dx);
			nonConnector.ShapeContainer.method_14(Enum135.const_3, struct2.Y - center.Y - shapeContainer.OffsetToParent.Dy);
		}
	}

	private bool method_9(Struct47[] shapes, double[] margins, bool isCircles)
	{
		bool isFirstInCenter;
		if (isFirstInCenter = CycleParameter.IsFirstInCenter)
		{
			double margin = margins[0];
			Struct47 first = shapes[0];
			for (int i = 1; i < shapes.Length; i++)
			{
				Struct47 second = shapes[i];
				if (isCircles ? method_10(first, second, margin) : method_11(first, second, margin))
				{
					return true;
				}
			}
		}
		int num = (isFirstInCenter ? 1 : 0);
		for (int j = num; j < shapes.Length; j++)
		{
			Struct47 first2 = shapes[j];
			for (int k = num; k < shapes.Length; k++)
			{
				Struct47 second2 = shapes[k];
				if (k != j && (isCircles ? method_10(first2, second2, margins[j]) : method_11(first2, second2, margins[j])))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool method_10(Struct47 first, Struct47 second, double margin)
	{
		double num = smethod_11(first.Center, Math.Max(first.Width, first.Height) / 2.0, second.Center, Math.Max(second.Width, second.Height) / 2.0);
		return num - margin < 0.0;
	}

	private bool method_11(Struct47 first, Struct47 second, double margin)
	{
		if (margin >= 0.0)
		{
			Struct47 @struct = Struct47.smethod_0(first, second);
			if (@struct.Width != 0.0 && @struct.Height != 0.0)
			{
				return true;
			}
			if (margin > 0.0 && smethod_12(first, second) <= margin)
			{
				return true;
			}
		}
		else
		{
			Struct47 struct2 = Struct47.smethod_0(first.method_4(margin), second);
			if (struct2.Width != 0.0 && struct2.Height != 0.0)
			{
				return true;
			}
		}
		return false;
	}

	private static Struct48 smethod_10(Class837 point)
	{
		double num = Class102.smethod_9(100.0);
		double width = ((point.ShapeContainer.Width != 0.0 || !(point.Algorithm is Class129)) ? (point.ShapeContainer.Width / point.CustomScale.Dx) : num);
		double height = ((point.ShapeContainer.Height != 0.0 || !(point.Algorithm is Class129)) ? (point.ShapeContainer.Height / point.CustomScale.Dy) : num);
		return new Struct48(width, height);
	}

	private static double smethod_11(Struct46 firstCenter, double firstRadius, Struct46 secondCenter, double secondRadius)
	{
		double num = Class102.smethod_1(firstCenter, secondCenter);
		return num - (firstRadius + secondRadius);
	}

	private static double smethod_12(Struct47 first, Struct47 second)
	{
		Struct46[] array = first.method_1();
		Struct46[] array2 = second.method_1();
		double num = double.MaxValue;
		Struct46[] array3 = array;
		foreach (Struct46 start in array3)
		{
			Struct46[] array4 = array2;
			foreach (Struct46 end in array4)
			{
				Struct47 @struct = new Struct47(start, end);
				if (num > @struct.Distance)
				{
					num = @struct.Distance;
				}
			}
		}
		Struct46[] array5 = array2;
		foreach (Struct46 sourcePoint in array5)
		{
			double num2 = smethod_13(second, sourcePoint, array);
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	private static double smethod_13(Struct47 sourceRect, Struct46 sourcePoint, Struct46[] targetPoints)
	{
		List<Struct49> list = sourceRect.method_0(sourcePoint.X, sourcePoint.Y);
		Struct46[] array = new Struct46[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			ref Struct46 reference = ref array[i];
			reference = new Struct46(sourcePoint.X + (double)list[i].Dx, sourcePoint.Y + (double)list[i].Dy);
		}
		double num = double.MaxValue;
		Struct46 segmentB = targetPoints[0];
		for (int j = 1; j <= targetPoints.Length; j++)
		{
			Struct46 @struct = ((j < targetPoints.Length) ? targetPoints[j] : targetPoints[0]);
			Struct46[] array2 = array;
			foreach (Struct46 rayB in array2)
			{
				if (Class102.smethod_2(@struct, segmentB, sourcePoint, rayB, out var intrsct) == 1)
				{
					double num2 = Class102.smethod_1(sourcePoint, intrsct);
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			segmentB = @struct;
		}
		return num;
	}

	private static double smethod_14(Struct47 bounds, double canvasWidth, double canvasHeight)
	{
		double val = Math.Min(1.0, canvasWidth / bounds.Width);
		double val2 = Math.Min(1.0, canvasHeight / bounds.Height);
		return Math.Min(val, val2);
	}

	private static double smethod_15(double degree)
	{
		return smethod_16(degree, allowLargeAngles: false) * (Math.PI / 180.0);
	}

	private static double smethod_16(double angle, bool allowLargeAngles)
	{
		if (!allowLargeAngles)
		{
			angle %= 360.0;
		}
		if (!(angle < 0.0))
		{
			return angle;
		}
		return 360.0 + angle;
	}

	private static Struct50 smethod_17(double angle)
	{
		if (double.IsNaN(angle))
		{
			return default(Struct50);
		}
		double num = smethod_15(angle);
		return new Struct50(Math.Cos(num), Math.Sin(num));
	}
}
