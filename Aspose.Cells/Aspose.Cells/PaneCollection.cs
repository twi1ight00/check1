using System;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Represents all Pane objects shown in the specified window.
///       </summary>
public class PaneCollection
{
	private Worksheet worksheet_0;

	private byte byte_0 = 3;

	private int int_0;

	private short short_0;

	private int int_1;

	private int int_2;

	/// <summary>
	///       Gets and sets the first visible row of the bottom pane.
	///       </summary>
	public int FirstVisibleRowOfBottomPane
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the first visible column of the right pane.
	///       </summary>
	public int FirstVisibleColumnOfRightPane
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = (short)value;
		}
	}

	/// <summary>
	///       Gets and sets the active pane.
	///       </summary>
	public RectangleAlignmentType AcitvePaneType
	{
		get
		{
			if (int_2 == 0)
			{
				if (int_1 == 0)
				{
					return RectangleAlignmentType.Center;
				}
				byte b = byte_0;
				if (b == 2)
				{
					return RectangleAlignmentType.Bottom;
				}
				return RectangleAlignmentType.Top;
			}
			if (int_1 == 0)
			{
				byte b2 = byte_0;
				if (b2 == 1)
				{
					return RectangleAlignmentType.Right;
				}
				return RectangleAlignmentType.Left;
			}
			return byte_0 switch
			{
				0 => RectangleAlignmentType.BottomRight, 
				1 => RectangleAlignmentType.TopRight, 
				2 => RectangleAlignmentType.BottomLeft, 
				_ => RectangleAlignmentType.TopLeft, 
			};
		}
		set
		{
			if (int_2 == 0)
			{
				if (int_1 == 0)
				{
					byte_0 = 3;
					return;
				}
				switch (value)
				{
				case RectangleAlignmentType.Top:
					byte_0 = 3;
					break;
				case RectangleAlignmentType.Bottom:
					byte_0 = 2;
					break;
				}
				return;
			}
			if (int_1 == 0)
			{
				switch (value)
				{
				case RectangleAlignmentType.Left:
					byte_0 = 3;
					break;
				case RectangleAlignmentType.Right:
					byte_0 = 1;
					break;
				}
				return;
			}
			switch (value)
			{
			case RectangleAlignmentType.TopLeft:
				byte_0 = 3;
				break;
			case RectangleAlignmentType.TopRight:
				byte_0 = 1;
				break;
			case RectangleAlignmentType.BottomLeft:
				byte_0 = 2;
				break;
			case RectangleAlignmentType.BottomRight:
				byte_0 = 0;
				break;
			}
		}
	}

	internal int Row => int_0;

	internal int Column => short_0;

	internal PaneCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal byte method_0()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_1(byte byte_1)
	{
		byte_0 = byte_1;
	}

	internal void InsertColumns(int int_3, int int_4)
	{
		if (short_0 <= int_3 || (int_2 <= 1 && int_4 < 0))
		{
			return;
		}
		int firstVisibleColumn = worksheet_0.FirstVisibleColumn;
		if (int_3 < firstVisibleColumn || int_3 >= firstVisibleColumn + int_2)
		{
			return;
		}
		int num = int_2 + int_4;
		if (num <= 0)
		{
			int_4 = -int_2 + 1;
			int_2 = 1;
		}
		else
		{
			int_2 = num;
		}
		Class1733 @class = worksheet_0.method_34();
		bool flag = false;
		short_0 += (short)int_4;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1732 class2 = (Class1732)@class[i];
			for (int j = 0; j < class2.method_3().Count; j++)
			{
				flag = false;
				CellArea cellArea_ = (CellArea)class2.method_3()[j];
				cellArea_ = Class1678.InsertColumns(cellArea_, int_3, int_4, ref flag);
				if (!flag)
				{
					class2.method_3()[j] = cellArea_;
				}
			}
			if (class2.method_7() >= int_3)
			{
				class2.method_8(class2.method_7() + int_4);
				if (class2.method_7() < 0)
				{
					class2.method_8(0);
				}
			}
		}
	}

	internal void InsertRows(int int_3, int int_4)
	{
		if (int_0 <= int_3 || (int_1 <= 1 && int_4 < 0))
		{
			return;
		}
		int firstVisibleRow = worksheet_0.FirstVisibleRow;
		if (int_3 < firstVisibleRow || int_3 >= firstVisibleRow + int_1)
		{
			return;
		}
		int num = int_1 + int_4;
		if (num <= 0)
		{
			int_4 = -int_1 + 1;
			int_1 = 1;
		}
		else
		{
			int_1 = num;
		}
		int_0 += int_4;
		Class1733 @class = worksheet_0.method_34();
		bool flag = false;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1732 class2 = (Class1732)@class[i];
			for (int j = 0; j < class2.method_3().Count; j++)
			{
				flag = false;
				CellArea cellArea_ = (CellArea)class2.method_3()[j];
				cellArea_ = Class1678.InsertRows(cellArea_, int_3, int_4, ref flag);
				if (!flag)
				{
					class2.method_3()[j] = cellArea_;
				}
			}
			if (class2.method_5() >= int_3)
			{
				class2.method_6(class2.method_5() + int_4);
				if (class2.method_5() < int_3)
				{
					class2.method_6(int_3);
				}
			}
		}
	}

	internal void Copy(PaneCollection paneCollection_0)
	{
		int_0 = paneCollection_0.int_0;
		short_0 = paneCollection_0.short_0;
		int_1 = paneCollection_0.int_1;
		int_2 = paneCollection_0.int_2;
		byte_0 = paneCollection_0.byte_0;
	}

	[SpecialName]
	internal void method_2(int int_3)
	{
		int_0 = int_3;
	}

	[SpecialName]
	internal void method_3(int int_3)
	{
		short_0 = (short)int_3;
	}

	[SpecialName]
	internal int method_4()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_5(int int_3)
	{
		int_1 = int_3;
	}

	[SpecialName]
	internal int method_6()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_7(int int_3)
	{
		int_2 = int_3;
	}

	internal void Split(string string_0)
	{
		CellsHelper.CellNameToIndex(string_0, out var row, out var column);
		if (row == 0)
		{
			if (column == 0)
			{
				int_2 = 8070;
				int_1 = 4275;
				int_0 = 15;
				short_0 = 8;
			}
			else
			{
				int_1 = 0;
				if (column < 8)
				{
					Cells cells = worksheet_0.Cells;
					for (int i = 0; i < column; i++)
					{
						int_2 += cells.GetColumnWidthPixel(i);
					}
					int_2 = (int)((double)((float)int_2 * 72f * 20f / (float)worksheet_0.method_2().method_75()) + 0.5);
				}
				short_0 = (short)column;
				int_0 = 0;
			}
		}
		else if (column == 0)
		{
			int_2 = 0;
			if (row < 15)
			{
				Cells cells2 = worksheet_0.Cells;
				for (int j = 0; j < row; j++)
				{
					int_1 += (int)(cells2.GetRowHeight(j) * 20.0 + 0.5);
				}
			}
			else
			{
				int_1 = 4275;
			}
			int_0 = row;
			short_0 = 0;
		}
		else
		{
			if (row < 15)
			{
				Cells cells3 = worksheet_0.Cells;
				for (int k = 0; k < row; k++)
				{
					int_1 += (int)(cells3.GetRowHeight(k) * 20.0 + 0.5);
				}
			}
			else
			{
				int_1 = 4275;
			}
			if (column < 8)
			{
				Cells cells4 = worksheet_0.Cells;
				for (int l = 0; l < column; l++)
				{
					int_2 += cells4.GetColumnWidthPixel(l);
				}
				int_2 = (int)((double)((float)int_2 * 72f * 20f / (float)worksheet_0.method_2().method_75()) + 0.5);
			}
			else
			{
				int_2 = 8070;
			}
			int_0 = row;
			short_0 = (short)column;
		}
		worksheet_0.FirstVisibleRow = ((row - 15 > 0) ? (row - 15) : 0);
		worksheet_0.FirstVisibleColumn = ((column - 8 > 0) ? (column - 8) : 0);
		method_8();
	}

	internal void method_8()
	{
		Class1733 @class = new Class1733(worksheet_0);
		worksheet_0.method_35(@class);
		Class1732 class2 = null;
		if (int_0 == 0)
		{
			class2 = new Class1732(3);
			class2.method_0(worksheet_0.FirstVisibleRow, worksheet_0.FirstVisibleColumn);
			@class.Add(class2);
			class2 = new Class1732(1);
			byte_0 = 1;
			class2.method_0(int_0, short_0);
			@class.Add(class2);
		}
		else if (short_0 == 0)
		{
			class2 = new Class1732(3);
			class2.method_0(worksheet_0.FirstVisibleRow, worksheet_0.FirstVisibleColumn);
			@class.Add(class2);
			class2 = new Class1732(2);
			byte_0 = 2;
			class2.method_0(int_0, short_0);
			@class.Add(class2);
		}
		else
		{
			class2 = new Class1732(3);
			class2.method_0(worksheet_0.FirstVisibleRow, worksheet_0.FirstVisibleColumn);
			@class.Add(class2);
			class2 = new Class1732(2);
			class2.method_0(int_0, worksheet_0.FirstVisibleColumn);
			@class.Add(class2);
			class2 = new Class1732(1);
			class2.method_0(worksheet_0.FirstVisibleRow, short_0);
			@class.Add(class2);
			class2 = new Class1732(0);
			byte_0 = 0;
			class2.method_0(int_0, short_0);
			@class.Add(class2);
		}
	}

	internal void Split(int int_3, int int_4, int int_5, int int_6)
	{
		int_1 = int_3;
		int_2 = int_4;
		int_0 = int_5;
		short_0 = (short)int_6;
	}

	internal void method_9(int int_3, int int_4, int int_5, int int_6)
	{
		int_1 = int_5;
		int_2 = int_6;
		int_0 = int_3;
		short_0 = (short)int_4;
	}

	internal void method_10(int int_3, int int_4, int int_5, int int_6)
	{
		if (int_5 == 0)
		{
			int_3 = 0;
		}
		if (int_6 == 0)
		{
			int_4 = 0;
		}
		if (int_3 == 0 && int_4 == 0)
		{
			throw new ArgumentException();
		}
		int_0 = int_3;
		short_0 = (short)int_4;
		int_1 = int_5;
		int_2 = int_6;
		int num = 0;
		int num2 = 0;
		if (int_3 == 0)
		{
			byte_0 = 1;
			int_1 = 0;
			num = 0;
			if (int_6 > int_4)
			{
				int_2 = int_4;
				num2 = 0;
			}
			else
			{
				num2 = int_4 - int_6;
			}
		}
		else if (int_4 == 0)
		{
			num2 = 0;
			byte_0 = 2;
			int_2 = 0;
			if (int_5 > int_3)
			{
				int_1 = int_3;
				num = 0;
			}
			else
			{
				num = int_3 - int_5;
			}
		}
		else
		{
			byte_0 = 0;
			if (int_6 > int_4)
			{
				int_2 = int_4;
				num2 = 0;
			}
			else
			{
				num2 = int_4 - int_6;
			}
			if (int_5 > int_3)
			{
				int_1 = int_3;
				num = 0;
			}
			else
			{
				num = int_3 - int_5;
			}
		}
		Cells cells = worksheet_0.Cells;
		if (num != 0)
		{
			for (int i = num; i < int_3; i++)
			{
				int num3 = cells.Rows.method_5(int_3);
				if (num3 != -1)
				{
					Row rowByIndex = cells.Rows.GetRowByIndex(num3);
					if (rowByIndex.IsHidden)
					{
						num--;
					}
				}
			}
		}
		if (num2 != 0)
		{
			for (int j = num2; j < int_4; j++)
			{
				int num4 = cells.Columns.method_7(j);
				if (num4 != -1)
				{
					Column columnByIndex = cells.Columns.GetColumnByIndex(num4);
					if (columnByIndex.IsHidden)
					{
						num2--;
					}
				}
			}
		}
		worksheet_0.FirstVisibleRow = num;
		worksheet_0.FirstVisibleColumn = num2;
		method_8();
	}
}
