using System;
using Aspose.Slides;
using ns56;

namespace ns8;

internal class Class127 : Class120
{
	private bool bool_0;

	private Class110 PyramidParameter => (Class110)base.Parameter;

	protected override void vmethod_1()
	{
		bool_0 = false;
	}

	public override bool vmethod_2(Class837 point)
	{
		Class110 pyramidParameter = PyramidParameter;
		int count = point.Children.Count;
		if (count > 0)
		{
			double num = point.method_30(Enum305.const_62);
			double num2 = point.method_30(Enum305.const_16);
			double num3 = point.method_30(Enum305.const_24);
			if (num3 > 1.0)
			{
				num3 = 1.0;
			}
			else if (num3 < 0.0)
			{
				num3 = 0.0;
			}
			double num4 = num - num * num3;
			double num5 = num - num4;
			double num6 = num2 / (double)count;
			double num7 = num4 / (double)(2 * count);
			double num8 = 0.0;
			double num9 = ((pyramidParameter.AccentPosition == Enum127.const_0) ? num5 : 0.0);
			if (pyramidParameter.Direction == Enum119.const_1)
			{
				num9 += num4 / 2.0 - num7;
			}
			double num10 = ((pyramidParameter.Direction == Enum119.const_1) ? (num7 * 2.0) : num4);
			for (int i = 0; i < count; i++)
			{
				Class837 @class = (Class837)point.Children[i];
				@class.method_28(Enum305.const_16, num6);
				double diffX = 0.0;
				Class837 class2 = method_9(pyramidParameter.AccentBackgroundNode, @class.Children);
				if (pyramidParameter.AccentPosition == Enum127.const_1 || (pyramidParameter.AccentPosition == Enum127.const_0 && class2 == null))
				{
					diffX = num9;
				}
				@class.ShapeContainer.method_6(diffX, num8);
				if (!bool_0)
				{
					Class837 class3 = method_9(pyramidParameter.LevelNode, @class.Children);
					Class837 class4 = method_9(pyramidParameter.ChildBackgroundNode, @class.Children);
					if (class3 != null)
					{
						if (pyramidParameter.Direction == Enum119.const_4)
						{
							class3.ShapeContainer.method_10(180.0);
						}
						AutoShape autoShapeInternal = class3.ShapeContainer.Shape.AutoShapeInternal;
						if (autoShapeInternal.ShapeType == ShapeType.Trapezoid)
						{
							autoShapeInternal.Adjustments[0].RawValue = (long)(100000.0 * num7 / Math.Min(num6, num10));
						}
						double num11 = num10 / 2.0;
						if (pyramidParameter.AccentPosition == Enum127.const_0 && class2 != null)
						{
							num11 += num9;
						}
						method_8(class3, num10, num6, num11);
					}
					double num12 = num5 + (num4 - num10) / 2.0 + num7;
					if (class2 != null)
					{
						if (pyramidParameter.Direction == Enum119.const_1)
						{
							class2.ShapeContainer.method_10(180.0);
						}
						AutoShape autoShapeInternal2 = class2.ShapeContainer.Shape.AutoShapeInternal;
						if (autoShapeInternal2.ShapeType == ShapeType.NonIsoscelesTrapezoid)
						{
							int index;
							int index2;
							if (pyramidParameter.Direction == Enum119.const_4)
							{
								index = ((pyramidParameter.AccentPosition != 0) ? 1 : 0);
								index2 = ((pyramidParameter.AccentPosition == Enum127.const_0) ? 1 : 0);
							}
							else
							{
								index = ((pyramidParameter.AccentPosition == Enum127.const_0) ? 1 : 0);
								index2 = ((pyramidParameter.AccentPosition != 0) ? 1 : 0);
							}
							autoShapeInternal2.Adjustments[index2].RawValue = (long)(100000.0 * num7 / Math.Min(num6, num12));
							autoShapeInternal2.Adjustments[index].RawValue = 0L;
						}
						double num13 = num12 / 2.0;
						if (pyramidParameter.AccentPosition == Enum127.const_1)
						{
							num13 += num10 - num7;
						}
						method_8(class2, num12, num6, num13);
					}
					if (class4 != null)
					{
						AutoShape autoShapeInternal3 = class4.ShapeContainer.Shape.AutoShapeInternal;
						if (autoShapeInternal3.ShapeType == ShapeType.NonIsoscelesTrapezoid)
						{
							autoShapeInternal3.Adjustments[0].RawValue = 0L;
							autoShapeInternal3.Adjustments[1].RawValue = 0L;
						}
						double num14 = ((pyramidParameter.AccentTextMargin == Enum128.const_0) ? (num12 - num7) : num5);
						double num15 = num14 / 2.0;
						if (pyramidParameter.AccentPosition == Enum127.const_1)
						{
							num15 += num10;
						}
						if (pyramidParameter.AccentTextMargin == Enum128.const_1 && pyramidParameter.AccentPosition == Enum127.const_1)
						{
							num15 += num12 - num7 - num14;
						}
						method_8(class4, num14, num6, num15);
					}
				}
				num8 += num6;
				num10 += (double)((pyramidParameter.Direction == Enum119.const_1) ? 2 : (-2)) * num7;
				num9 += (double)((pyramidParameter.Direction != Enum119.const_1) ? 1 : (-1)) * num7;
			}
		}
		if (!bool_0)
		{
			bool_0 = true;
			return false;
		}
		return true;
	}

	private void method_8(Class837 point, double width, double height, double centerX)
	{
		point.method_28(Enum305.const_62, width);
		point.method_28(Enum305.const_16, height);
		point.method_28(Enum305.const_9, centerX);
		point.method_28(Enum305.const_11, height / 2.0);
	}

	private Class837 method_9(string layoutName, Class838 collection)
	{
		foreach (Class837 item in collection)
		{
			if (item.LayoutNode.Name == layoutName)
			{
				return item;
			}
		}
		return null;
	}
}
