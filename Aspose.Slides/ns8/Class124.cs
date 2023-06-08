using System;
using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class124 : Class120
{
	private Class108 HierarchyParameter => (Class108)base.Parameter;

	public override bool vmethod_6(Enum305 type)
	{
		if (type != Enum305.const_30)
		{
			return type == Enum305.const_31;
		}
		return true;
	}

	public override bool vmethod_4(Class837 rootPresOf, Struct48 canvasSize)
	{
		double val = canvasSize.Width / rootPresOf.ShapeContainer.Width;
		double val2 = canvasSize.Height / rootPresOf.ShapeContainer.Height;
		double ratio = Math.Min(val, val2);
		if (Class120.smethod_4(ratio))
		{
			foreach (Class837 child in rootPresOf.Children)
			{
				child.method_24(ratio, Enum305.const_62, Enum305.const_16);
			}
			rootPresOf.method_24(ratio, Enum305.const_31, Enum305.const_30, Enum305.const_29, Enum305.const_5);
			return true;
		}
		return false;
	}

	public override bool vmethod_2(Class837 point)
	{
		if (HierarchyParameter.LinearDirection != 0)
		{
			List<Class837> list = point.method_39();
			if (list.Count > 0)
			{
				double primarySpace = point.method_30(Enum305.const_30);
				bool flag = HierarchyParameter.LinearDirection == Enum119.const_4 || HierarchyParameter.LinearDirection == Enum119.const_1;
				bool flag2 = HierarchyParameter.SecondaryLinearDirection == Enum119.const_4 || HierarchyParameter.SecondaryLinearDirection == Enum119.const_1;
				if (HierarchyParameter.SecondaryLinearDirection != 0 && flag != flag2)
				{
					double secondarySpace = point.method_30(Enum305.const_29);
					Struct50 @struct = method_8(list, primarySpace, secondarySpace);
					point.ShapeContainer.method_14(Enum135.const_4, @struct.Dx);
					point.ShapeContainer.method_14(Enum135.const_5, @struct.Dy);
				}
				else
				{
					Enum134 @enum = point.method_48(base.LayoutNode);
					bool flag3 = @enum == Enum134.const_3 || @enum == Enum134.const_4;
					Struct48 struct2 = point.ShapeContainer.method_2();
					smethod_10(list, HierarchyParameter.LinearDirection, HierarchyParameter.ChildAlignment, struct2.Width, struct2.Height);
					if (flag3)
					{
						method_10(list, primarySpace);
					}
					else
					{
						method_9(list, primarySpace);
					}
				}
				point.ShapeContainer.method_12();
				Class120.smethod_8(point, HierarchyParameter.HorizontalAlignment, HierarchyParameter.VerticalAlignment);
			}
		}
		return true;
	}

	private Struct50 method_8(IList<Class837> children, double primarySpace, double secondarySpace)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int count = children.Count;
		int capacity = (int)Math.Ceiling((double)children.Count / 2.0);
		List<Class837> list = new List<Class837>(capacity);
		List<Class837> list2 = new List<Class837>(capacity);
		for (int i = 0; i < count; i++)
		{
			Class837 @class = children[i];
			double width = @class.ShapeContainer.Width;
			double height = @class.ShapeContainer.Height;
			if (i % 2 == 0)
			{
				if (num < width)
				{
					num = width;
				}
				if (num2 < height)
				{
					num2 = height;
				}
				list.Add(@class);
			}
			else
			{
				if (num3 < width)
				{
					num3 = width;
				}
				if (num4 < height)
				{
					num4 = height;
				}
				list2.Add(@class);
			}
		}
		int num5 = 0;
		double num6 = 0.0;
		double num7 = 0.0;
		Struct46[] array = new Struct46[count];
		while (num5 < count)
		{
			double num8 = 0.0;
			double num9 = 0.0;
			int num10 = num5;
			int num11 = 0;
			while (num11 < 2 && num10 < count)
			{
				Class851 shapeContainer = children[num10].ShapeContainer;
				if (num9 < shapeContainer.Width)
				{
					num9 = shapeContainer.Width;
				}
				if (num8 < shapeContainer.Height)
				{
					num8 = shapeContainer.Height;
				}
				num11++;
				num10++;
			}
			for (int j = 0; j < 2; j++)
			{
				if (num5 >= count)
				{
					break;
				}
				_ = children[num5].ShapeContainer;
				double num12 = ((j == 0) ? num : num3);
				double num13 = ((j == 0) ? num2 : num4);
				switch (HierarchyParameter.LinearDirection)
				{
				case Enum119.const_1:
				{
					num7 -= num13;
					ref Struct46 reference4 = ref array[num5];
					reference4 = new Struct46(num6, num7);
					num7 -= secondarySpace;
					break;
				}
				case Enum119.const_2:
				{
					ref Struct46 reference3 = ref array[num5];
					reference3 = new Struct46(num6, num7);
					num6 += num12 + secondarySpace;
					break;
				}
				case Enum119.const_3:
				{
					num6 -= num12;
					ref Struct46 reference2 = ref array[num5];
					reference2 = new Struct46(num6, num7);
					num6 -= secondarySpace;
					break;
				}
				case Enum119.const_4:
				{
					ref Struct46 reference = ref array[num5];
					reference = new Struct46(num6, num7);
					num7 += num13 + secondarySpace;
					break;
				}
				}
				num5++;
			}
			switch (HierarchyParameter.SecondaryLinearDirection)
			{
			case Enum119.const_1:
				num6 = 0.0;
				num7 -= primarySpace + num8;
				break;
			case Enum119.const_2:
				num7 = 0.0;
				num6 += primarySpace + num9;
				break;
			case Enum119.const_3:
				num7 = 0.0;
				num6 -= primarySpace + num9;
				break;
			case Enum119.const_4:
				num6 = 0.0;
				num7 += primarySpace + num8;
				break;
			}
		}
		Struct47 @struct = Class843.smethod_4(array);
		for (int k = 0; k < count; k++)
		{
			Struct46 struct2 = array[k];
			children[k].ShapeContainer.method_6(struct2.X - @struct.X, struct2.Y - @struct.Y);
		}
		smethod_10(list, HierarchyParameter.SecondaryLinearDirection, HierarchyParameter.ChildAlignment, num, num2);
		smethod_10(list2, HierarchyParameter.SecondaryLinearDirection, HierarchyParameter.ChildAlignment, num3, num4);
		List<Class837> list3 = new List<Class837>();
		for (int l = 0; l + 1 < count; l += 2)
		{
			Class837 class2 = children[l];
			Class837 class3 = children[l + 1];
			list3.Clear();
			list3.Add(class2);
			list3.Add(class3);
			double boundsWidth = Math.Max(class2.ShapeContainer.Width, class3.ShapeContainer.Width);
			double boundsHeight = Math.Max(class2.ShapeContainer.Height, class3.ShapeContainer.Height);
			smethod_10(list3, HierarchyParameter.LinearDirection, HierarchyParameter.SecondaryChildAlignment, boundsWidth, boundsHeight);
		}
		return HierarchyParameter.LinearDirection switch
		{
			Enum119.const_1 => new Struct50(0.0, num4 + secondarySpace / 2.0), 
			Enum119.const_2 => new Struct50(num + secondarySpace / 2.0, 0.0), 
			Enum119.const_3 => new Struct50(num3 + secondarySpace / 2.0, 0.0), 
			Enum119.const_4 => new Struct50(0.0, num2 + secondarySpace / 2.0), 
			_ => default(Struct50), 
		};
	}

	private void method_9(IList<Class837> children, double primarySpace)
	{
		Enum119 linearDirection = HierarchyParameter.LinearDirection;
		double num = 0.0;
		double num2 = 0.0;
		bool flag;
		for (int i = ((flag = linearDirection == Enum119.const_1 || linearDirection == Enum119.const_3) ? (children.Count - 1) : 0); (!flag) ? (i < children.Count) : (i >= 0); i += ((!flag) ? 1 : (-1)))
		{
			Class851 shapeContainer = children[i].ShapeContainer;
			switch (linearDirection)
			{
			case Enum119.const_2:
			case Enum119.const_3:
				shapeContainer.method_6(num, num2);
				num += shapeContainer.Width + primarySpace;
				break;
			case Enum119.const_1:
			case Enum119.const_4:
				shapeContainer.method_6(num, num2);
				num2 += shapeContainer.Height + primarySpace;
				break;
			}
		}
	}

	private void method_10(IList<Class837> children, double primarySpace)
	{
		List<Struct47> list = new List<Struct47>();
		double diffX = 0.0;
		double diffY = 0.0;
		Enum119 linearDirection = HierarchyParameter.LinearDirection;
		bool flag = linearDirection == Enum119.const_4 || linearDirection == Enum119.const_1;
		bool flag2;
		int num = ((!(flag2 = linearDirection == Enum119.const_1 || linearDirection == Enum119.const_3)) ? 1 : (-1));
		for (int i = (flag2 ? (children.Count - 1) : 0); (!flag2) ? (i < children.Count) : (i >= 0); i += num)
		{
			Class837 @class = children[i];
			@class.ShapeContainer.method_6(diffX, diffY);
			if (flag2 ? (i + num >= 0) : (i + num < children.Count))
			{
				list.AddRange(@class.ShapeContainer.method_4());
				if (flag)
				{
					diffY = primarySpace + smethod_11(list, children[i + num].ShapeContainer.method_4());
				}
				else
				{
					diffX = primarySpace + smethod_12(list, children[i + num].ShapeContainer.method_4());
				}
			}
		}
	}

	private static void smethod_10(IList<Class837> children, Enum119 direction, Enum132 childAlignment, double boundsWidth, double boundsHeight)
	{
		bool flag = direction == Enum119.const_4 || direction == Enum119.const_1;
		bool flag2 = direction == Enum119.const_2 || direction == Enum119.const_3;
		if (flag && childAlignment == Enum132.const_4)
		{
			foreach (Class837 child in children)
			{
				child.ShapeContainer.method_6(boundsWidth - child.ShapeContainer.Width, 0.0);
			}
			return;
		}
		if (!flag2 || childAlignment != Enum132.const_2)
		{
			return;
		}
		foreach (Class837 child2 in children)
		{
			child2.ShapeContainer.method_6(0.0, boundsHeight - child2.ShapeContainer.Height);
		}
	}

	private static double smethod_11(IEnumerable<Struct47> first, IEnumerable<Struct47> second)
	{
		double num = double.MinValue;
		bool flag = false;
		foreach (Struct47 item in second)
		{
			foreach (Struct47 item2 in first)
			{
				if ((item.X >= item2.X && item.X <= item2.Right) || (item.Right >= item2.X && item.Right <= item2.Right))
				{
					double val = item2.Bottom - item.Y;
					num = Math.Max(num, val);
					flag = true;
				}
			}
		}
		if (!flag)
		{
			return 0.0;
		}
		return num;
	}

	private static double smethod_12(IEnumerable<Struct47> first, IEnumerable<Struct47> second)
	{
		double num = double.MinValue;
		bool flag = false;
		foreach (Struct47 item in second)
		{
			foreach (Struct47 item2 in first)
			{
				if ((item.Y >= item2.Y && item.Y <= item2.Bottom) || (item.Bottom >= item2.Y && item.Bottom <= item2.Bottom))
				{
					double val = item2.Right - item.X;
					num = Math.Max(num, val);
					flag = true;
				}
			}
		}
		if (!flag)
		{
			return 0.0;
		}
		return num;
	}
}
