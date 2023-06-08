using System;
using System.Collections;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6950 : Interface354
{
	public void imethod_0(Class6845 container)
	{
		Class6852 @class = smethod_6(container);
		float num = 0f;
		if (@class.InnerBoxes.Count > 0)
		{
			Class6844 class2 = @class.InnerBoxes[@class.InnerBoxes.Count - 1];
			if (class2 == null)
			{
				throw new Exception69();
			}
			num = class2.Location.Y + class2.OuterBound.Height;
			if (@class.Style.BorderCollapse == Enum933.const_1)
			{
				num -= Class6969.smethod_10(@class.Style.BorderTableWidthBottom) / 2f;
			}
		}
		@class.Size = new SizeF(@class.Size.Width, num);
	}

	public void imethod_2(Class6844 box, SizeF size)
	{
		imethod_1(box);
	}

	public void imethod_1(Class6844 box)
	{
		Class6852 @class = smethod_6(box);
		if (!(@class.Parent is Class6845 class2))
		{
			throw new Exception70();
		}
		float num = smethod_7(@class);
		if (@class.Style.Width.IsAuto)
		{
			for (int i = 0; i < @class.ColumnsWidths.Count; i++)
			{
				if (@class.ColumnsWidths[i] != null && ((Class6959)@class.ColumnsWidths[i]).Unit == Enum955.const_3)
				{
					@class.Style.Width = new Class6959(100f, Enum955.const_3);
					break;
				}
			}
		}
		float num2 = (@class.Style.Width.IsAuto ? class2.Size.Width : Class6969.smethod_9(@class.Style.Width, class2.InnerBound.Width));
		num2 -= (float)(@class.ColumnsCount + 1) * num;
		if (@class.Style.BorderTableWidthLeft != null)
		{
			num2 -= Class6969.smethod_10(@class.Style.BorderTableWidthLeft);
		}
		if (@class.Style.BorderTableWidthRight != null)
		{
			num2 -= Class6969.smethod_10(@class.Style.BorderTableWidthRight);
		}
		bool flag = @class.Style.TableLayout == Enum939.const_1 && !@class.Style.Width.IsAuto;
		int num3 = @class.ColumnsCount;
		float num4 = 0f;
		for (int j = 0; j < @class.ColumnsWidths.Count; j++)
		{
			if (@class.ColumnsWidths[j] != null)
			{
				Class6959 class3 = (Class6959)@class.ColumnsWidths[j];
				if (class3.Unit == Enum955.const_3)
				{
					num3--;
					num4 += class3.Value;
				}
			}
		}
		bool flag2 = num3 == 0 && num4 != 100f;
		int num5 = @class.ColumnsCount;
		float num6 = 0f;
		float num7 = smethod_5(@class.MinColumnsWidths);
		for (int k = 0; k < @class.ColumnsWidths.Count; k++)
		{
			if (@class.ColumnsWidths[k] == null)
			{
				continue;
			}
			Class6959 class4 = (Class6959)@class.ColumnsWidths[k];
			num5--;
			if (class4.Unit == Enum955.const_3 && flag2)
			{
				class4.Value = class4.Value / num4 * 100f;
			}
			float num8 = Class6969.smethod_9(class4, num2);
			if (flag)
			{
				smethod_3(num8, k, @class);
			}
			else
			{
				if (class4.Unit == Enum955.const_3 && num8 < (float)@class.MinColumnsWidths[k])
				{
					num8 = (float)@class.MinColumnsWidths[k];
				}
				if (class4.Unit == Enum955.const_3 && num8 > num2 - num6)
				{
					num8 = num2 - num6;
				}
				if (class4.Unit == Enum955.const_3 || (num8 > (float)@class.MaxColumnsWidths[k] && num2 > num7))
				{
					smethod_3(num8, k, @class);
				}
			}
			num6 += num8;
		}
		num7 = smethod_5(@class.MinColumnsWidths);
		float num9 = smethod_5(@class.MaxColumnsWidths);
		float autoWidthValue = 0f;
		if (!@class.Style.Width.IsAuto)
		{
			autoWidthValue = (num2 - num6) / (float)num5;
			autoWidthValue = Math.Max(autoWidthValue, 0f);
		}
		if (!(num7 >= num2) && num2 < num9)
		{
			float num10 = num2 - num7;
			float num11 = num9 - num7;
			float num12 = num10 / num11;
			for (int l = 0; l < @class.MinColumnsWidths.Count; l++)
			{
				float num13 = (float)@class.MinColumnsWidths[l];
				float num14 = (float)@class.MaxColumnsWidths[l];
				float num15 = num14 - num13;
				float width = num13 + num15 * num12;
				smethod_4(width, l, @class);
			}
		}
		else
		{
			IList widths = @class.MinColumnsWidths;
			if (num2 >= num9)
			{
				if (!@class.Style.Width.IsAuto && num5 == 0 && num2 > num9)
				{
					smethod_0(@class, num3, num4, num2, num9);
				}
				widths = @class.MaxColumnsWidths;
			}
			if (flag || (num2 > num9 && !@class.Style.Width.IsAuto))
			{
				smethod_1(autoWidthValue, widths, @class);
			}
			smethod_2(@class, widths);
		}
		smethod_8(@class);
	}

	public void imethod_3(Class6844 box)
	{
		Class6852 @class = smethod_6(box);
		Class6959 class2 = new Class6959(0f);
		Class6959 class3 = new Class6959(0f);
		if (@class.Style.BorderCollapse == Enum933.const_0)
		{
			class2 = @class.Style.BorderSpacingHorisontal;
			class3 = @class.Style.BorderSpacingVertical;
		}
		Interface329 style = @class.Style;
		Class6959 paddingLeft = (@class.Style.PaddingRight = class2);
		style.PaddingLeft = paddingLeft;
		Interface329 style2 = @class.Style;
		Class6959 paddingTop = (@class.Style.PaddingBottom = class3);
		style2.PaddingTop = paddingTop;
		float num = Class6969.smethod_10(class2);
		float num2 = num * (float)(@class.ColumnsCount + 1) + Class6969.smethod_10(@class.Style.BorderTableWidthLeft) + Class6969.smethod_10(@class.Style.BorderTableWidthRight);
		float num3 = num2;
		for (int i = 0; i < @class.MaxColumnsWidths.Count; i++)
		{
			num3 += (float)@class.MaxColumnsWidths[i];
			num2 += (float)@class.MinColumnsWidths[i];
		}
		@class.MaxWidth = num3;
		@class.MinWidth = num2;
	}

	private static void smethod_0(Class6852 table, int notPercentsColsAmount, float totalPercents, float contentWidth, float maxContentWidth)
	{
		float maxValue = contentWidth - maxContentWidth;
		int num = table.ColumnsCount - notPercentsColsAmount;
		if (num > 0)
		{
			for (int i = 0; i < table.ColumnsCount; i++)
			{
				if (table.ColumnsWidths.Count > i && table.ColumnsWidths[i] != null && ((Class6959)table.ColumnsWidths[i]).Unit == Enum955.const_3)
				{
					Class6959 @class = (Class6959)table.ColumnsWidths[i];
					@class.Value = @class.Value / totalPercents * 100f;
					table.MaxColumnsWidths[i] = (float)table.MaxColumnsWidths[i] + Class6969.smethod_9(@class, maxValue);
				}
			}
		}
		else
		{
			for (int j = 0; j < table.MaxColumnsWidths.Count; j++)
			{
				float num2 = (float)table.MaxColumnsWidths[j];
				table.MaxColumnsWidths[j] = num2 / maxContentWidth * contentWidth;
			}
		}
	}

	private static void smethod_1(float autoWidthValue, IList widths, Class6852 table)
	{
		for (int i = 0; i < table.ColumnsCount; i++)
		{
			if (table.ColumnsWidths.Count <= i || (table.ColumnsWidths.Count > i && table.ColumnsWidths[i] == null))
			{
				widths[i] = autoWidthValue;
			}
		}
	}

	private static void smethod_2(Class6852 table, IList widths)
	{
		for (int i = 0; i < widths.Count; i++)
		{
			float width = (float)widths[i];
			smethod_4(width, i, table);
		}
	}

	private static void smethod_3(float width, int colIndex, Class6852 table)
	{
		table.MinColumnsWidths[colIndex] = width;
		table.MaxColumnsWidths[colIndex] = width;
	}

	private static void smethod_4(float width, int colIndex, Class6852 table)
	{
		if (table.ColumnsWidths.Count > colIndex)
		{
			table.ColumnsWidths[colIndex] = width;
		}
		else
		{
			table.ColumnsWidths.Add(width);
		}
	}

	private static float smethod_5(IList widths)
	{
		float num = 0f;
		for (int i = 0; i < widths.Count; i++)
		{
			num += (float)widths[i];
		}
		return num;
	}

	private static Class6852 smethod_6(Class6844 container)
	{
		Class6892.smethod_0(container, "container");
		if (!(container is Class6852 result))
		{
			throw new ArgumentException("container should have type TableBox");
		}
		return result;
	}

	private static float smethod_7(Class6852 table)
	{
		float result = 0f;
		if (table.Style.BorderCollapse == Enum933.const_0)
		{
			result = Class6969.smethod_10(table.Style.BorderSpacingHorisontal);
		}
		return result;
	}

	private static void smethod_8(Class6852 table)
	{
		float num = smethod_5(table.ColumnsWidths);
		float num2 = smethod_7(table);
		num += num2 * (float)(table.ColumnsWidths.Count - 1);
		if (table.Style.BorderCollapse == Enum933.const_1)
		{
			num -= Class6969.smethod_10(table.Style.BorderTableWidthRight);
		}
		table.Size = new SizeF(num, table.Size.Height);
	}
}
