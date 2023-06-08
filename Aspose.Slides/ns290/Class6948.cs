using System;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6948 : Interface354
{
	private readonly Interface351 interface351_0;

	public Class6948()
	{
		interface351_0 = new Class6942();
	}

	public void imethod_0(Class6845 container)
	{
	}

	public void imethod_1(Class6844 box)
	{
		Class6853 @class = smethod_1(box);
		float num = 0f;
		for (int i = 0; i < @class.Colspan; i++)
		{
			num += (float)@class.Row.ColumnWidths[@class.ColumnIndex + i];
		}
		num = method_0(num, @class);
		@class.Size = new SizeF(num, @class.Size.Height);
	}

	public void imethod_2(Class6844 box, SizeF size)
	{
		imethod_1(box);
	}

	public void imethod_3(Class6844 box)
	{
		Class6853 @class = smethod_1(box);
		Enum946 @enum = interface351_0.imethod_0(@class);
		smethod_0(@class);
		float num = method_1(@class);
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			if (@class.InnerBoxes[i] is Class6845 class2)
			{
				if (@class.MinWidth < class2.MinWidth + num)
				{
					@class.MinWidth = class2.MinWidth + num;
				}
				float num2 = ((@enum == Enum946.const_0) ? class2.OuterBound.Width : class2.MaxWidth);
				if (@class.MaxWidth < num2 + num)
				{
					@class.MaxWidth = num2 + num;
				}
			}
		}
	}

	private static void smethod_0(Class6853 cell)
	{
		if (!cell.Table.Style.CellPadding.IsAuto)
		{
			if (cell.Style.PaddingBottom.IsAuto)
			{
				cell.Style.PaddingBottom = cell.Table.Style.CellPadding;
			}
			if (cell.Style.PaddingTop.IsAuto)
			{
				cell.Style.PaddingTop = cell.Table.Style.CellPadding;
			}
			if (cell.Style.PaddingRight.IsAuto)
			{
				cell.Style.PaddingRight = cell.Table.Style.CellPadding;
			}
			if (cell.Style.PaddingLeft.IsAuto)
			{
				cell.Style.PaddingLeft = cell.Table.Style.CellPadding;
			}
		}
	}

	private float method_0(float width, Class6853 cell)
	{
		float num = method_1(cell);
		if (cell.Row.Style.BorderCollapse == Enum933.const_0)
		{
			float num2 = Class6969.smethod_10(cell.Table.Style.BorderSpacingHorisontal);
			width += num2 * (float)(cell.Colspan - 1);
		}
		width -= num;
		return width;
	}

	private static Class6853 smethod_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6853 result))
		{
			throw new ArgumentException("box should have a TableCellBox type");
		}
		return result;
	}

	private float method_1(Class6853 cell)
	{
		if (cell.Style.BorderCollapse == Enum933.const_0)
		{
			return interface351_0.imethod_15(cell) + interface351_0.imethod_16(cell);
		}
		float num = Class6969.smethod_10(cell.Style.PaddingLeft) + Class6969.smethod_10(cell.Style.PaddingRight);
		float num2 = (Class6969.smethod_10(cell.Style.BorderWidthLeft) + Class6969.smethod_10(cell.Style.BorderWidthRight)) / 2f;
		return num + num2;
	}
}
