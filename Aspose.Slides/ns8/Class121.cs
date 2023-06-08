using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class121 : Class120
{
	private Class105 CompositeParameter => (Class105)base.Parameter;

	public void method_8(Class837 point)
	{
		Struct48 canvasSize = method_13(point);
		method_9(point, init: true, hidden: false);
		foreach (Class837 child in point.Children)
		{
			Struct48 @struct = smethod_10(child, canvasSize);
			child.ShapeContainer.Width = @struct.Width / child.CustomScale.Dx;
			child.ShapeContainer.Height = @struct.Height / child.CustomScale.Dy;
			double num = Math.Min(canvasSize.Width / child.ShapeContainer.Width, canvasSize.Height / child.ShapeContainer.Height);
			if (Class120.smethod_4(num))
			{
				if (child.method_23(Enum305.const_62))
				{
					child.method_21(Enum305.const_62, child.method_20(Enum305.const_62) * num);
				}
				if (child.method_23(Enum305.const_16))
				{
					child.method_21(Enum305.const_16, child.method_20(Enum305.const_16) * num);
				}
			}
			method_9(point, init: true, hidden: false);
		}
	}

	public override bool vmethod_9(Class837 parent)
	{
		method_9(parent, init: false, hidden: false);
		return true;
	}

	private void method_9(Class837 parent, bool init, bool hidden)
	{
		if (parent.Constraints == null)
		{
			return;
		}
		Class114 @class = new Class114();
		Class117[] forChildren = parent.Constraints.ForChildren;
		foreach (Class117 class2 in forChildren)
		{
			Class837 class3 = class2.method_6(parent);
			if (class3 == null)
			{
				continue;
			}
			List<Class837> list = class2.method_5(parent);
			foreach (Class837 item in list)
			{
				double num = class3.method_35(class2);
				double num2 = method_10(class3, item, class2, hidden) * num;
				if (num2 == 0.0 && Class102.smethod_12(class2.Type))
				{
					continue;
				}
				bool flag = false;
				double num3 = item.method_32(class2.Type);
				Class115 class4 = @class.method_0(item, class2.Type);
				if (Class120.smethod_5(num3, num2))
				{
					switch (class2.Operator)
					{
					case Enum326.const_0:
					case Enum326.const_1:
						class4.method_2(num2);
						flag = true;
						break;
					case Enum326.const_2:
					{
						class4.method_2(num2);
						flag = true;
						if (item != class3)
						{
							break;
						}
						Class115 class5 = @class.method_0(class3, class2.ReferencedType);
						if (Class120.smethod_5(class4.Value, class5.Value * num) && class4.Value < class5.Value * num)
						{
							class5.method_2(class4.Value / num);
							if (init)
							{
								class3.method_22(class2.ReferencedType, class5.Value);
							}
							else
							{
								class3.method_27(class2.ReferencedType, class5.Value);
							}
						}
						break;
					}
					case Enum326.const_3:
						if (num3 < num2)
						{
							class4.method_0(num2);
							flag = true;
						}
						break;
					case Enum326.const_4:
						if (num3 > num2)
						{
							class4.method_1(num2);
							flag = true;
						}
						break;
					}
				}
				if (flag)
				{
					if (init)
					{
						item.method_22(class2.Type, class4.Value);
					}
					else
					{
						item.method_27(class2.Type, class4.Value);
					}
				}
			}
		}
	}

	private double method_10(Class837 refPoint, Class837 targetPoint, Class117 constraint, bool hidden)
	{
		if (targetPoint.ShapeContainer.IsHidden && hidden)
		{
			if (constraint.ReferencedType == Enum305.const_62 && refPoint.ShapeContainer.Width != 0.0)
			{
				return refPoint.ShapeContainer.Width;
			}
			if (constraint.ReferencedType == Enum305.const_16 && refPoint.ShapeContainer.Height != 0.0)
			{
				return refPoint.ShapeContainer.Height;
			}
		}
		if (constraint.ReferencedForRel == Enum329.const_1)
		{
			return refPoint.method_33(constraint.ReferencedType);
		}
		return refPoint.method_32(constraint.ReferencedType);
	}

	public override bool vmethod_2(Class837 point)
	{
		Struct48 canvasSize = method_13(point);
		foreach (Class837 child in point.Children)
		{
			method_9(point, init: false, hidden: false);
			method_11(child, canvasSize);
		}
		Struct47 @struct = smethod_12(point);
		point.ShapeContainer.Width = @struct.Width;
		point.ShapeContainer.Height = @struct.Height;
		foreach (Class837 child2 in point.Children)
		{
			if (child2.ShapeContainer.IsHidden)
			{
				method_9(point, init: false, hidden: true);
				method_11(child2, canvasSize);
			}
		}
		@struct = smethod_12(point);
		point.ShapeContainer.Width = @struct.Width;
		point.ShapeContainer.Height = @struct.Height;
		Class120.smethod_8(point, CompositeParameter.HorizontalAlignment, CompositeParameter.VerticalAlignment);
		method_12(point, @struct);
		return true;
	}

	public override void vmethod_7(Class837 point)
	{
	}

	private void method_11(Class837 child, Struct48 canvasSize)
	{
		Struct48 @struct = smethod_10(child, canvasSize);
		child.ShapeContainer.AvailableHeight = @struct.Height;
		child.ShapeContainer.AvailableWidth = @struct.Width;
		bool flag = false;
		if (!(child.Algorithm is Class130) && !(child.Algorithm is Class129))
		{
			double ratio = ((child.ShapeContainer.Width != 0.0) ? (@struct.Width / child.ShapeContainer.Width) : 1.0);
			double ratio2 = ((child.ShapeContainer.Height != 0.0) ? (@struct.Height / child.ShapeContainer.Height) : 1.0);
			if (Class120.smethod_4(ratio))
			{
				child.method_25(ratio, Enum305.const_62);
				flag = true;
			}
			if (Class120.smethod_4(ratio2))
			{
				child.method_25(ratio2, Enum305.const_16);
				flag = true;
			}
		}
		else
		{
			if (child.ShapeContainer.Height != @struct.Height)
			{
				child.method_27(Enum305.const_16, @struct.Height);
				child.TextMaxHeight = @struct.Height;
				flag = true;
			}
			if (child.ShapeContainer.Width != @struct.Width)
			{
				child.method_27(Enum305.const_62, @struct.Width);
				child.TextMaxWidth = @struct.Width;
				flag = true;
			}
		}
		if (flag)
		{
			child.method_26();
			child.method_45();
		}
	}

	public override bool vmethod_4(Class837 rootPresOf, Struct48 canvasSize)
	{
		double num = canvasSize.Width / rootPresOf.ShapeContainer.Width;
		double num2 = canvasSize.Height / rootPresOf.ShapeContainer.Height;
		if (CompositeParameter.AspectRatio != 0.0)
		{
			double ratio = Math.Min(num, num2);
			if (Class120.smethod_4(ratio))
			{
				foreach (Class837 child in rootPresOf.Children)
				{
					child.method_24(ratio, Enum305.const_62, Enum305.const_16);
				}
				return true;
			}
		}
		else
		{
			if (Class120.smethod_4(num))
			{
				foreach (Class837 child2 in rootPresOf.Children)
				{
					child2.method_25(num, Enum305.const_62);
				}
				return true;
			}
			if (Class120.smethod_4(num2))
			{
				foreach (Class837 child3 in rootPresOf.Children)
				{
					child3.method_25(num2, Enum305.const_16);
				}
				return true;
			}
		}
		return false;
	}

	private void method_12(Class837 container, Struct47 actualBounds)
	{
		foreach (Class837 child in container.Children)
		{
			double num = child.ShapeContainer.method_13(Enum135.const_0);
			double num2 = child.ShapeContainer.method_13(Enum135.const_1);
			if (CompositeParameter.HorizontalAlignment != 0)
			{
				num -= actualBounds.X;
			}
			if (CompositeParameter.VerticalAlignment != 0)
			{
				num2 -= actualBounds.Y;
			}
			child.ShapeContainer.method_5(num, num2);
			child.ShapeContainer.AvailableWidth = Math.Min(child.ShapeContainer.AvailableWidth, container.ShapeContainer.Width);
			child.ShapeContainer.AvailableHeight = Math.Min(child.ShapeContainer.AvailableHeight, container.ShapeContainer.Height);
			Struct50 @struct = Class120.smethod_7(child, child.Algorithm.Parameter.HorizontalAlignment, child.Algorithm.Parameter.VerticalAlignment);
			child.ShapeContainer.method_6(@struct.Dx, @struct.Dy);
		}
	}

	private Struct48 method_13(Class837 container)
	{
		double num = container.method_30(Enum305.const_62);
		if (num == 0.0)
		{
			num = container.Root.method_30(Enum305.const_62);
		}
		double num2 = container.method_30(Enum305.const_16);
		if (num2 == 0.0)
		{
			num2 = container.Root.method_30(Enum305.const_16);
		}
		Struct48 result = new Struct48(num, num2);
		if (CompositeParameter.AspectRatio != 0.0)
		{
			return Class102.smethod_11(CompositeParameter.AspectRatio, result.Width, result.Height);
		}
		return result;
	}

	private static Struct48 smethod_10(Class837 child, Struct48 canvasSize)
	{
		double offset;
		double width = smethod_11(child, canvasSize.Width, Enum305.const_62, Enum305.const_64, Enum305.const_19, Enum305.const_21, Enum305.const_25, Enum305.const_27, Enum305.const_9, Enum305.const_10, out offset);
		child.ShapeContainer.method_14(Enum135.const_0, offset);
		double height = smethod_11(child, canvasSize.Height, Enum305.const_16, Enum305.const_18, Enum305.const_33, Enum305.const_35, Enum305.const_2, Enum305.const_7, Enum305.const_11, Enum305.const_12, out offset);
		child.ShapeContainer.method_14(Enum135.const_1, offset);
		return new Struct48(width, height);
	}

	private static double smethod_11(Class837 point, double canvasLength, Enum305 side, Enum305 sideOffset, Enum305 left, Enum305 leftOffset, Enum305 right, Enum305 rightOffset, Enum305 center, Enum305 centerOffset, out double offset)
	{
		offset = 0.0;
		double num = 0.0;
		if (point.method_23(side))
		{
			num = Math.Abs(point.method_30(sideOffset) + point.method_30(side));
			if ((point.method_23(left) && point.method_30(left) != 0.0) || point.method_30(leftOffset) != 0.0)
			{
				offset += point.method_30(leftOffset) + point.method_30(left);
			}
			else if (point.method_23(right) && point.method_30(right) != 0.0)
			{
				offset += point.method_30(rightOffset) + point.method_30(right) - num;
			}
			else if (point.method_23(center) && point.method_30(center) != 0.0)
			{
				offset += point.method_30(centerOffset) + point.method_30(center) - num / 2.0;
			}
		}
		else if ((point.method_23(left) && point.method_30(left) != 0.0) || point.method_30(leftOffset) != 0.0)
		{
			num = ((point.method_23(right) && point.method_30(right) != 0.0) ? Math.Abs(point.method_30(right) + point.method_30(rightOffset) - (point.method_30(left) + point.method_30(leftOffset))) : ((!point.method_23(center) || point.method_30(center) == 0.0) ? Math.Abs(canvasLength - (point.method_30(left) + point.method_30(leftOffset)) + point.method_30(rightOffset)) : Math.Abs((point.method_30(center) + point.method_30(centerOffset) - (point.method_30(left) + point.method_30(leftOffset))) * 2.0)));
			offset = point.method_30(leftOffset) + point.method_30(left);
		}
		else if (point.method_23(right) && point.method_30(right) != 0.0)
		{
			if (point.method_23(center) && point.method_30(center) != 0.0)
			{
				num = Math.Abs((point.method_30(center) + point.method_30(centerOffset) - (point.method_30(right) + point.method_30(rightOffset))) * 2.0);
				offset = Math.Abs((point.method_30(center) + point.method_30(centerOffset)) * 2.0 - (point.method_30(right) + point.method_30(rightOffset)));
			}
			else
			{
				num = Math.Abs(point.method_30(right) + point.method_30(rightOffset));
			}
		}
		else if (point.method_23(center) && point.method_30(center) != 0.0)
		{
			num = 0.0;
			offset = point.method_30(center);
		}
		else
		{
			num = canvasLength;
			point.method_22(side, num);
		}
		return num;
	}

	private static Struct47 smethod_12(Class837 parent)
	{
		if (parent.Children.Count == 0)
		{
			return default(Struct47);
		}
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		foreach (Class837 child in parent.Children)
		{
			num = Math.Min(num, child.ShapeContainer.method_13(Enum135.const_0));
			num2 = Math.Min(num2, child.ShapeContainer.method_13(Enum135.const_1));
		}
		double num3 = 0.0;
		double num4 = 0.0;
		foreach (Class837 child2 in parent.Children)
		{
			num3 = Math.Max(num3, child2.ShapeContainer.method_13(Enum135.const_0) - num + child2.ShapeContainer.Width);
			num4 = Math.Max(num4, child2.ShapeContainer.method_13(Enum135.const_1) - num2 + child2.ShapeContainer.Height);
		}
		return new Struct47(num, num2, num + num3, num2 + num4);
	}

	private static double smethod_13(double actual, double available, double max)
	{
		if (actual < 0.0)
		{
			return (0.0 - actual <= available) ? (-1) : 0;
		}
		if (!(available < max))
		{
			return 1.0;
		}
		return available / max;
	}
}
