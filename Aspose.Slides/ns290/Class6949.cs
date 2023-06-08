using System;
using System.Collections;
using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6949 : Interface354
{
	public void imethod_0(Class6845 container)
	{
		Class6854 @class = smethod_2(container);
		@class.Size = new SizeF(@class.Size.Width, @class.MinHeight);
	}

	public void imethod_1(Class6844 box)
	{
		Class6854 @class = smethod_2(box);
		if (!(@class.Parent is Class6852 class2))
		{
			throw new Exception70();
		}
		@class.ColumnWidths = class2.ColumnsWidths;
		@class.Style = Class6960.smethod_6(@class.Style);
	}

	public void imethod_2(Class6844 box, SizeF size)
	{
		imethod_1(box);
	}

	public void imethod_3(Class6844 box)
	{
		Class6854 @class = smethod_2(box);
		Class6852 table = @class.Table;
		int num = table.InnerBoxes.IndexOf(@class);
		bool flag;
		bool flag2 = ((flag = table.Style.TableLayout == Enum939.const_1 && !table.Style.Width.IsAuto) && num == 0) || !flag;
		int num2 = 0;
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6853 class2 = (Class6853)@class.InnerBoxes[i];
			if (class2.Rowspan > 1)
			{
				for (int j = 1; j < class2.Rowspan; j++)
				{
					table.method_0(num + j, i);
				}
			}
			int num3 = smethod_1(i, num, table);
			if (num3 - i > 0)
			{
				num2 += num3 - i;
			}
			class2.ColumnIndex = i + num2;
			num2 += class2.Colspan - 1;
			float num4 = class2.MaxWidth / (float)class2.Colspan;
			float num5 = class2.MinWidth / (float)class2.Colspan;
			if (!class2.Style.Width.IsAuto && flag2)
			{
				smethod_0(class2, table);
			}
			int num6 = class2.ColumnIndex;
			int num7 = 0;
			while (num7 < class2.Colspan)
			{
				if (table.MaxColumnsWidths.Count > num6)
				{
					if (num4 > (float)table.MaxColumnsWidths[num6])
					{
						table.MaxColumnsWidths[num6] = num4;
					}
					if (num5 > (float)table.MinColumnsWidths[num6])
					{
						table.MinColumnsWidths[num6] = num5;
					}
				}
				else
				{
					table.MaxColumnsWidths.Add(num4);
					table.MinColumnsWidths.Add(num5);
				}
				num7++;
				num6++;
			}
		}
	}

	private static void smethod_0(Class6853 cell, Class6852 table)
	{
		Class6959 @class = new Class6959(cell.Style.Width.Value / (float)cell.Colspan, cell.Style.Width.Unit);
		for (int i = 0; i < cell.Colspan; i++)
		{
			int num = i + cell.ColumnIndex;
			if (table.ColumnsWidths.Count > num)
			{
				if (table.ColumnsWidths[num] != null)
				{
					Class6959 num2 = ((!(table.ColumnsWidths[num].GetType() == typeof(Class6959))) ? new Class6959((float)table.ColumnsWidths[num]) : ((Class6959)table.ColumnsWidths[num]));
					table.ColumnsWidths[num] = Class6959.smethod_0(num2, @class);
				}
				else
				{
					table.ColumnsWidths[num] = @class;
				}
			}
			else
			{
				for (int j = table.ColumnsWidths.Count; j < num; j++)
				{
					table.ColumnsWidths.Add(null);
				}
				table.ColumnsWidths.Add(@class);
			}
		}
	}

	private static int smethod_1(int cellIndex, int rowIndex, Class6852 table)
	{
		if (table.RowsSpaned.Contains(rowIndex))
		{
			IDictionary dictionary = table.RowsSpaned[rowIndex] as IDictionary;
			if (dictionary.Contains(cellIndex))
			{
				return smethod_1(cellIndex + 1, rowIndex, table);
			}
		}
		return cellIndex;
	}

	private static Class6854 smethod_2(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6854 result))
		{
			throw new ArgumentException("container should have a TableRowBox type");
		}
		return result;
	}
}
