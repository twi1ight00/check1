using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class976 : Interface0
{
	private readonly int int_0;

	private readonly short short_0;

	private IEnumerator ienumerator_0;

	private IEnumerator ienumerator_1;

	private LightCellsDataProvider lightCellsDataProvider_0;

	private Class981 class981_0;

	private Class977 class977_0;

	private Row row_0;

	private Cell cell_0;

	private int int_1 = -1;

	private int int_2 = -1;

	private int int_3 = -1;

	private Class978 class978_0;

	private int int_4;

	internal Class976(Worksheet worksheet_0, LightCellsDataProvider lightCellsDataProvider_1, Class978 class978_1)
	{
		int_0 = class978_1.class521_0.int_0;
		short_0 = class978_1.class521_0.short_0;
		Cells cells = worksheet_0.Cells;
		lightCellsDataProvider_0 = lightCellsDataProvider_1;
		class978_0 = class978_1;
		class981_0 = new Class981(cells, class978_1);
		class977_0 = new Class977(cells, class978_1);
		ienumerator_0 = cells.Rows.GetEnumerator();
		if (ienumerator_0.MoveNext())
		{
			row_0 = (Row)ienumerator_0.Current;
		}
		else
		{
			ienumerator_0 = null;
		}
	}

	public Row NextRow()
	{
		int num = lightCellsDataProvider_0.NextRow();
		if (num >= 0 && num <= int_0)
		{
			if (num <= int_2)
			{
				throw new CellsException(ExceptionType.InvalidData, "Row index must be greater than prior one.");
			}
			Row row = null;
			if (row_0 != null)
			{
				if (num == row_0.Index)
				{
					row = row_0;
				}
				else if (num > row_0.Index)
				{
					while (ienumerator_0.MoveNext())
					{
						row_0 = (Row)ienumerator_0.Current;
						if (row_0.Index > num)
						{
							break;
						}
						if (row_0.Index == num)
						{
							row = row_0;
							break;
						}
					}
				}
				if (row != null)
				{
					if (ienumerator_0.MoveNext())
					{
						row_0 = (Row)ienumerator_0.Current;
					}
					else
					{
						row_0 = null;
					}
					ienumerator_1 = row.GetEnumerator();
					if (ienumerator_1.MoveNext())
					{
						cell_0 = (Cell)ienumerator_1.Current;
						int_1 = cell_0.Column;
					}
					else
					{
						ienumerator_1 = null;
						cell_0 = null;
						int_1 = -1;
					}
				}
			}
			if (row == null)
			{
				class981_0.method_22();
				class981_0.method_23(num);
				row = class981_0;
				ienumerator_1 = null;
				cell_0 = null;
				int_1 = -1;
			}
			int_3 = -1;
			int_4 = -1;
			class977_0.row_0 = row;
			class977_0.method_8((ushort)num);
			lightCellsDataProvider_0.StartRow(row);
			return row;
		}
		return null;
	}

	public Cell NextCell()
	{
		int num = lightCellsDataProvider_0.NextCell();
		if (num >= 0 && num <= short_0)
		{
			if (num <= int_3)
			{
				throw new CellsException(ExceptionType.InvalidData, "Cell's column index must be greater than prior one.");
			}
			Cell cell = null;
			if (int_1 > -1)
			{
				if (num == int_1)
				{
					cell = cell_0;
				}
				else if (num > int_1)
				{
					while (ienumerator_1.MoveNext())
					{
						cell_0 = (Cell)ienumerator_1.Current;
						int_1 = cell_0.Column;
						if (int_1 > num)
						{
							break;
						}
						if (int_1 == num)
						{
							cell = cell_0;
							break;
						}
					}
				}
				if (cell != null)
				{
					if (ienumerator_1.MoveNext())
					{
						cell_0 = (Cell)ienumerator_1.Current;
						int_1 = cell_0.Column;
					}
					else
					{
						cell_0 = null;
						int_1 = -1;
					}
				}
			}
			if (cell == null)
			{
				cell = class977_0;
				class977_0.vmethod_0(num);
				class977_0.bool_0 = lightCellsDataProvider_0.IsGatherString();
				if (int_4 < 0)
				{
					if (class977_0.row_0 is Class981)
					{
						int_4 = class977_0.row_0.method_10();
					}
					else
					{
						int_4 = class978_0.method_3(class977_0.row_0.method_10());
					}
				}
				class977_0.int_2 = int_4;
			}
			lightCellsDataProvider_0.StartCell(cell);
			return cell;
		}
		return null;
	}
}
