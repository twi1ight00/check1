using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class126 : Class120
{
	private Class113 LinearParameter => (Class113)base.Parameter;

	private bool IsVerticalArrangement
	{
		get
		{
			if (LinearParameter.LinearDirection != Enum119.const_1)
			{
				return LinearParameter.LinearDirection == Enum119.const_4;
			}
			return true;
		}
	}

	public override bool vmethod_2(Class837 point)
	{
		bool flag = true;
		Struct48 @struct = smethod_10(point);
		Struct48 struct2 = point.ShapeContainer.method_2();
		Struct48 struct3 = new Struct48(IsVerticalArrangement ? struct2.Width : @struct.Width, IsVerticalArrangement ? @struct.Height : struct2.Height);
		Struct48 struct4 = method_8(point);
		point.ShapeContainer.Width = struct3.Width;
		point.ShapeContainer.Height = struct3.Height;
		if (point.Parent != null)
		{
			point.method_27(Enum305.const_62, struct3.Width);
			point.method_27(Enum305.const_16, struct3.Height);
		}
		double num = ((struct3.Width == 0.0) ? 1.0 : (struct4.Width / struct3.Width));
		double num2 = ((struct3.Height == 0.0) ? 1.0 : (struct4.Height / struct3.Height));
		bool flag2;
		double ratio = ((!(flag2 = LinearParameter.Fallback == Enum122.const_1)) ? (IsVerticalArrangement ? num2 : num) : Math.Min(num, num2));
		if (Class120.smethod_4(ratio))
		{
			foreach (Class837 child in point.Children)
			{
				if (IsVerticalArrangement)
				{
					if (flag2)
					{
						child.method_25(ratio, Enum305.const_62);
					}
					child.method_25(ratio, Enum305.const_16);
				}
				else
				{
					if (flag2)
					{
						child.method_25(ratio, Enum305.const_16);
					}
					child.method_25(ratio, Enum305.const_62);
				}
			}
			flag = false;
			if (point.Rules != null)
			{
				Class118[] minValues = point.Rules.MinValues;
				foreach (Class118 class2 in minValues)
				{
					if (class2.ForRel == Enum329.const_1 || class2.Type != Enum305.const_23)
					{
						continue;
					}
					List<Class837> list = class2.method_5(point);
					foreach (Class837 item in list)
					{
						if (item.ShapeContainer.HasText)
						{
							item.method_24(ratio, Enum305.const_23, Enum305.const_28, Enum305.const_34, Enum305.const_6);
						}
					}
					break;
				}
			}
		}
		Class120.smethod_8(point, LinearParameter.HorizontalAlignment, LinearParameter.VerticalAlignment);
		method_9(point);
		if (!flag)
		{
			point.method_26();
		}
		return flag;
	}

	private Struct48 method_8(Class837 point)
	{
		double num = point.method_30(Enum305.const_62);
		double num2 = point.method_30(Enum305.const_16);
		if (num == 0.0)
		{
			num = double.PositiveInfinity;
		}
		if (num2 == 0.0)
		{
			num2 = double.PositiveInfinity;
		}
		double num3 = point.method_34(Enum305.const_62);
		double num4 = point.method_34(Enum305.const_16);
		if (!double.IsNaN(num3) && num3 > num)
		{
			num = num3;
		}
		if (!double.IsNaN(num4) && num4 > num2)
		{
			num2 = num4;
		}
		return new Struct48(num, num2);
	}

	private void method_9(Class837 container)
	{
		Enum119 linearDirection = LinearParameter.LinearDirection;
		bool flag = linearDirection == Enum119.const_1 || linearDirection == Enum119.const_3;
		int count = container.Children.Count;
		double num = 0.0;
		double num2 = 0.0;
		for (int i = (flag ? (count - 1) : 0); (!flag) ? (i < count) : (i >= 0); i += ((!flag) ? 1 : (-1)))
		{
			Class837 child = (Class837)container.Children[i];
			if (IsVerticalArrangement)
			{
				num2 += method_10(child, num2, container.ShapeContainer.Width, LinearParameter.NodeHorizontalAlignment);
			}
			else
			{
				num += method_11(child, num, container.ShapeContainer.Height, LinearParameter.NodeVerticalAlignment);
			}
		}
	}

	private double method_10(Class837 child, double diffY, double parentWidth, Enum120 alignment)
	{
		double diffX = 0.0;
		switch (alignment)
		{
		case Enum120.const_2:
			diffX = (parentWidth - child.ShapeContainer.Width) / 2.0;
			break;
		case Enum120.const_3:
			diffX = parentWidth - child.ShapeContainer.Width;
			break;
		}
		child.ShapeContainer.method_5(diffX, diffY);
		return child.ShapeContainer.Height;
	}

	private double method_11(Class837 child, double diffX, double parentHeight, Enum121 alignment)
	{
		double diffY = 0.0;
		switch (alignment)
		{
		case Enum121.const_2:
			diffY = (parentHeight - child.ShapeContainer.Height) / 2.0;
			break;
		case Enum121.const_3:
			diffY = parentHeight - child.ShapeContainer.Height;
			break;
		}
		child.ShapeContainer.method_5(diffX, diffY);
		return child.ShapeContainer.Width;
	}

	public override Struct50 vmethod_5(Class837 point)
	{
		double num = 0.0;
		double num2 = 0.0;
		Class837 @class = (Class837)point.Next;
		if (@class == null)
		{
			@class = (Class837)point.Previous;
			if (@class == null)
			{
				@class = point;
			}
		}
		if (IsVerticalArrangement)
		{
			num = point.CustomLinearFactor.Dx * point.ShapeContainer.Width + point.CustomNeighborLinearFactor.Dx * point.ShapeContainer.Width;
			num2 = point.CustomLinearFactor.Dy * point.ShapeContainer.Height + point.CustomNeighborLinearFactor.Dy * @class.ShapeContainer.Height;
		}
		else
		{
			num = point.CustomLinearFactor.Dx * point.ShapeContainer.Width + point.CustomNeighborLinearFactor.Dx * @class.ShapeContainer.Width;
			num2 = point.CustomLinearFactor.Dy * point.ShapeContainer.Height + point.CustomNeighborLinearFactor.Dy * point.ShapeContainer.Height;
		}
		return new Struct50(num, num2);
	}

	private static Struct48 smethod_10(Class837 point)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = double.MaxValue;
		double num4 = double.MaxValue;
		double num5 = double.MinValue;
		double num6 = double.MinValue;
		foreach (Class837 child in point.Children)
		{
			if (child.ShapeContainer.Height > 0.0)
			{
				num3 = Math.Min(num3, num);
				num5 = Math.Max(num5, num + child.ShapeContainer.Height);
			}
			num += child.ShapeContainer.Height;
			if (child.ShapeContainer.Width > 0.0)
			{
				num4 = Math.Min(num4, num2);
				num6 = Math.Max(num6, num2 + child.ShapeContainer.Width);
			}
			num2 += child.ShapeContainer.Width;
		}
		double height = ((num3 == double.MaxValue || num5 == double.MinValue) ? 0.0 : Math.Abs(num5 - num3));
		double width = ((num4 == double.MaxValue || num6 == double.MinValue) ? 0.0 : Math.Abs(num6 - num4));
		return new Struct48(width, height);
	}
}
