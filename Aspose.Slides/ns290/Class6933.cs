using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6933 : Class6927
{
	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6852 @class))
		{
			throw new ArgumentException("box should be ContainerBox");
		}
		float num = 0f;
		float num2 = 0f;
		if (@class.Style.BorderCollapse == Enum933.const_0)
		{
			num2 = Class6969.smethod_10(@class.Style.BorderSpacingVertical);
		}
		else
		{
			num -= Class6969.smethod_10(@class.Style.BorderWidthTop) / 2f;
		}
		method_2(@class);
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			if (@class.InnerBoxes[i] is Class6845)
			{
				Class6845 class2 = (Class6845)@class.InnerBoxes[i];
				class2.Location = new PointF(class2.Location.X, num);
				num += class2.OuterBound.Height;
				if (@class.Style.BorderCollapse == Enum933.const_0)
				{
					num += num2;
				}
			}
		}
		Interface354 @interface = Class6927.smethod_0(this);
		@interface.imethod_0(@class);
	}

	private static void smethod_1(int startRowIndex, int rowsAmount, float additionalHeight, Class6852 table)
	{
		for (int i = 0; i < rowsAmount; i++)
		{
			((Class6854)table.InnerBoxes[startRowIndex + i]).MinHeight += additionalHeight;
		}
	}

	private static float smethod_2(int rows, int currentRowIndex, Class6852 table)
	{
		float num = 0f;
		if (table.Style.BorderCollapse == Enum933.const_0)
		{
			num = Class6969.smethod_9(table.Style.BorderSpacingVertical, 1000f);
		}
		float num2 = 0f;
		for (int i = 0; i < rows; i++)
		{
			Class6854 @class = (Class6854)table.InnerBoxes[currentRowIndex + i];
			num2 += @class.MinHeight;
		}
		return num2 + num * (float)(rows - 1);
	}

	private void method_2(Class6852 table)
	{
		for (int i = 0; i < table.InnerBoxes.Count; i++)
		{
			if (!(table.InnerBoxes[i] is Class6845))
			{
				continue;
			}
			Class6854 @class = (Class6854)table.InnerBoxes[i];
			for (int j = 0; j < @class.InnerBoxes.Count; j++)
			{
				Class6853 class2 = (Class6853)@class.InnerBoxes[j];
				if (class2.Rowspan > 1)
				{
					method_3(class2, i, table);
				}
			}
			for (int k = 0; k < @class.InnerBoxes.Count; k++)
			{
				Class6853 class3 = (Class6853)@class.InnerBoxes[k];
				if (class3.Rowspan == 1)
				{
					method_4(class3, @class.MinHeight);
				}
			}
			@class.Size = new SizeF(@class.Size.Width, @class.MinHeight);
		}
	}

	private void method_3(Class6853 cell, int cellRowIndex, Class6852 table)
	{
		float num = smethod_2(cell.Rowspan, cellRowIndex, table);
		if (num < cell.OuterBound.Height)
		{
			float additionalHeight = (cell.OuterBound.Height - num) / (float)cell.Rowspan;
			smethod_1(cellRowIndex, cell.Rowspan, additionalHeight, table);
		}
		else
		{
			method_4(cell, num);
		}
	}

	private void method_4(Class6853 cell, float height)
	{
		float num = height;
		if (cell.Style.BorderCollapse == Enum933.const_0)
		{
			num -= base.BoxInfo.imethod_18(cell) + base.BoxInfo.imethod_17(cell);
		}
		else
		{
			float num2 = Class6969.smethod_10(cell.Style.PaddingBottom) + Class6969.smethod_10(cell.Style.PaddingTop);
			float num3 = (Class6969.smethod_10(cell.Style.BorderWidthBottom) + Class6969.smethod_10(cell.Style.BorderWidthTop)) / 2f;
			num -= num2 + num3;
		}
		cell.Size = new SizeF(cell.Size.Width, num);
	}
}
