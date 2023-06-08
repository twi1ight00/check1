using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6934 : Class6927
{
	public override void imethod_0(Class6844 box)
	{
		Class6854 @class = smethod_4(box);
		Class6852 table = @class.Table;
		float num = 0f;
		float num2 = 0f;
		if (table.Style.BorderCollapse == Enum933.const_0)
		{
			num2 = Class6969.smethod_10(table.Style.BorderSpacingHorisontal);
		}
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6853 class2 = (Class6853)@class.InnerBoxes[i];
			float num3 = 0f;
			float num4 = class2.Location.Y;
			for (int j = 0; j < class2.ColumnIndex; j++)
			{
				num3 += (float)table.ColumnsWidths[j] + num2;
			}
			float num5 = class2.BorderBound.Height;
			if (class2.Style.BorderCollapse == Enum933.const_1)
			{
				num3 -= (Class6969.smethod_10(class2.Style.BorderWidthLeft) + Class6969.smethod_10(table.Style.BorderWidthRight)) / 2f;
				num4 -= Class6969.smethod_10(class2.Style.BorderWidthTop) / 2f;
				float num6 = Class6969.smethod_10(class2.Style.MarginBottom) + Class6969.smethod_10(class2.Style.MarginTop);
				float num7 = (Class6969.smethod_10(class2.Style.BorderWidthBottom) + Class6969.smethod_10(class2.Style.BorderWidthTop)) / 2f;
				num5 -= num6 + num7;
			}
			class2.Location = new PointF(num3, num4);
			if (num5 > num && class2.Rowspan == 1)
			{
				num = num5;
				@class.MinHeight = num5;
			}
		}
		Interface354 @interface = Class6927.smethod_0(this);
		@interface.imethod_0(@class);
		smethod_5(@class);
	}

	private static float smethod_1(Class6853 cell)
	{
		return Class6969.smethod_10(cell.Style.PaddingBottom) + Class6969.smethod_10(cell.Style.PaddingTop) + Class6969.smethod_10(cell.Style.BorderWidthBottom) + Class6969.smethod_10(cell.Style.BorderWidthTop);
	}

	private static void smethod_2(Class6853 cell, float delta)
	{
		if (cell.InnerBoxes != null && delta > 3f)
		{
			for (int i = 0; i < cell.InnerBoxes.Count; i++)
			{
				Class6844 @class = cell.InnerBoxes[i];
				@class.Location = new PointF(@class.Location.X, @class.Location.Y + delta);
			}
		}
	}

	private static float smethod_3(Class6853 cell)
	{
		float num = 0f;
		float num2 = 0f;
		if (cell.InnerBoxes.Count > 0)
		{
			Class6844 @class = cell.InnerBoxes[0];
			Class6844 class2 = cell.InnerBoxes[cell.InnerBoxes.Count - 1];
			num = @class.Location.Y;
			num2 = class2.Location.Y + class2.OuterBound.Height;
		}
		return num2 - num;
	}

	private static Class6854 smethod_4(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6854 result))
		{
			throw new ArgumentException("container should have a TableRowBox type");
		}
		return result;
	}

	private static void smethod_5(Class6854 row)
	{
		for (int i = 0; i < row.InnerBoxes.Count; i++)
		{
			Class6853 @class = (Class6853)row.InnerBoxes[i];
			switch (@class.Style.TextVAlign)
			{
			case Enum958.const_1:
			{
				float delta = row.Size.Height - smethod_3(@class) - smethod_1(@class);
				smethod_2(@class, delta);
				break;
			}
			case Enum958.const_2:
			{
				float delta = (row.Size.Height - smethod_3(@class) - smethod_1(@class)) / 2f;
				smethod_2(@class, delta);
				break;
			}
			}
		}
	}
}
