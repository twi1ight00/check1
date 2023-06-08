using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns29;

namespace ns2;

internal class Class1133 : CollectionBase
{
	public CellArea this[int int_0] => (CellArea)base.InnerList[int_0];

	internal void Add(CellArea cellArea_0)
	{
		base.InnerList.Add(cellArea_0);
	}

	internal void method_0(int int_0, CellArea cellArea_0)
	{
		base.InnerList[int_0] = cellArea_0;
	}

	internal void InsertRows(int int_0, int int_1)
	{
		if (base.InnerList.Count == 0)
		{
			return;
		}
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea_ = (CellArea)base.InnerList[i];
			bool bool_ = false;
			cellArea_ = Class1678.InsertRows(cellArea_, int_0, int_1, ref bool_);
			if (bool_)
			{
				base.InnerList.RemoveAt(i);
				i--;
			}
			else
			{
				base.InnerList[i] = cellArea_;
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		if (base.InnerList.Count == 0)
		{
			return;
		}
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea_ = (CellArea)base.InnerList[i];
			bool bool_ = false;
			cellArea_ = Class1678.InsertColumns(cellArea_, int_0, int_1, ref bool_);
			if (bool_)
			{
				base.InnerList.RemoveAt(i);
				i--;
			}
			else
			{
				base.InnerList[i] = cellArea_;
			}
		}
	}

	internal bool method_1(int int_0, int int_1)
	{
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				CellArea cellArea = (CellArea)base.InnerList[num];
				if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0 && cellArea.StartColumn <= int_1 && cellArea.EndColumn >= int_1)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public Range GetMergedRange(Cells cells_0, int int_0, int int_1)
	{
		int num = 0;
		CellArea cellArea;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				cellArea = (CellArea)base.InnerList[num];
				if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0 && cellArea.StartColumn <= int_1 && cellArea.EndColumn >= int_1)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return cells_0.CreateRange(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1);
	}

	public void UnMerge(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_2 != 0 && int_3 != 0)
		{
			Class1677.smethod_26(int_0, int_1, int_0 + int_2 - 1, int_1 + int_3 - 1);
			if (int_2 == 1 && int_3 == 1)
			{
				int num = 0;
				while (true)
				{
					if (num < base.InnerList.Count)
					{
						CellArea cellArea = (CellArea)base.InnerList[num];
						if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0 && cellArea.StartColumn <= int_1 && cellArea.EndColumn >= int_1)
						{
							break;
						}
						num++;
						continue;
					}
					return;
				}
				base.InnerList.RemoveAt(num);
				return;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < base.InnerList.Count)
				{
					CellArea cellArea2 = (CellArea)base.InnerList[num2];
					if (cellArea2.StartRow == int_0 && cellArea2.EndRow == int_0 + int_2 - 1 && cellArea2.StartColumn == int_1 && cellArea2.EndColumn == int_1 + int_3 - 1)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			base.InnerList.RemoveAt(num2);
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	public void Merge(Cells cells_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (int_2 != 0 && int_3 != 0)
		{
			Class1677.smethod_26(int_0, int_1, int_0 + int_2 - 1, int_1 + int_3 - 1);
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = int_0;
			cellArea.StartColumn = int_1;
			cellArea.EndRow = int_0 + int_2 - 1;
			cellArea.EndColumn = int_1 + int_3 - 1;
			int num = 0;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					CellArea cellArea_ = (CellArea)base.InnerList[num];
					object obj = Class1678.Intersect(cellArea, cellArea_);
					if (obj != null)
					{
						CellArea cellArea2 = (CellArea)obj;
						if (cellArea2.StartRow != cellArea_.StartRow || cellArea2.StartColumn != cellArea_.StartColumn || cellArea2.EndRow != cellArea_.EndRow || cellArea2.EndColumn != cellArea_.EndColumn)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append("Cells in range ");
							stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn));
							stringBuilder.Append(':');
							stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn));
							stringBuilder.Append(" cannot be merged because cells in range ");
							stringBuilder.Append(CellsHelper.CellIndexToName(cellArea_.StartRow, cellArea_.StartColumn));
							stringBuilder.Append(':');
							stringBuilder.Append(CellsHelper.CellIndexToName(cellArea_.EndRow, cellArea_.EndColumn));
							stringBuilder.Append(" have already been merged.");
							throw new CellsException(ExceptionType.Limitation, stringBuilder.ToString());
						}
						base.InnerList.RemoveAt(num--);
					}
					num++;
					continue;
				}
				bool flag = false;
				Cell cell = cells_0.GetCell(int_0, int_1, bool_2: false);
				for (int i = int_0; i < int_0 + int_2; i++)
				{
					Row row = cells_0.Rows.GetRow(i, bool_0: true, bool_1: false);
					if (row == null)
					{
						continue;
					}
					for (int j = int_1; j < int_1 + int_3; j++)
					{
						Cell cellOrNull = row.GetCellOrNull(j);
						if (cellOrNull == null || cellOrNull.method_20() == Enum199.const_7)
						{
							continue;
						}
						if (!flag)
						{
							if (cellOrNull != cell)
							{
								switch (cellOrNull.method_20())
								{
								case Enum199.const_2:
									cell.PutValue(cellOrNull.IntValue);
									break;
								case Enum199.const_3:
									cell.PutValue(cellOrNull.DoubleValue);
									break;
								case Enum199.const_6:
									if (cellOrNull.IsRichText())
									{
										cell.method_55(cellOrNull, null);
									}
									else
									{
										cell.PutValue(cellOrNull.StringValue);
									}
									break;
								}
								cell.method_37(cellOrNull.method_35());
							}
							flag = true;
						}
						if (i != int_0 || j != int_1)
						{
							cellOrNull.PutValue(null);
						}
					}
				}
				break;
			}
			base.InnerList.Add(cellArea);
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	public void Merge(Cells cells_0, int int_0, int int_1, int int_2, int int_3, bool bool_0, bool bool_1)
	{
		if (int_2 != 0 && int_3 != 0)
		{
			Class1677.smethod_26(int_0, int_1, int_0 + int_2 - 1, int_1 + int_3 - 1);
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = int_0;
			cellArea.StartColumn = int_1;
			cellArea.EndRow = int_0 + int_2 - 1;
			cellArea.EndColumn = int_1 + int_3 - 1;
			if (bool_0)
			{
				for (int i = 0; i < base.InnerList.Count; i++)
				{
					CellArea cellArea_ = (CellArea)base.InnerList[i];
					object obj = Class1678.Intersect(cellArea, cellArea_);
					if (obj == null)
					{
						continue;
					}
					CellArea cellArea2 = (CellArea)obj;
					if (cellArea2.StartRow == cellArea_.StartRow && cellArea2.StartColumn == cellArea_.StartColumn && cellArea2.EndRow == cellArea_.EndRow && cellArea2.EndColumn == cellArea_.EndColumn)
					{
						base.InnerList.RemoveAt(i--);
						continue;
					}
					if (bool_1)
					{
						if (cellArea.StartRow > cellArea_.StartRow)
						{
							cellArea.StartRow = cellArea_.StartRow;
						}
						if (cellArea.StartColumn > cellArea_.StartColumn)
						{
							cellArea.StartColumn = cellArea_.StartColumn;
						}
						if (cellArea.EndColumn < cellArea_.EndColumn)
						{
							cellArea.EndColumn = cellArea_.EndColumn;
						}
						if (cellArea.EndRow < cellArea_.EndRow)
						{
							cellArea.EndRow = cellArea_.EndRow;
						}
						base.InnerList.RemoveAt(i--);
						continue;
					}
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("Cells in range ");
					stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn));
					stringBuilder.Append(':');
					stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn));
					stringBuilder.Append(" cannot be merged because cells in range ");
					stringBuilder.Append(CellsHelper.CellIndexToName(cellArea_.StartRow, cellArea_.StartColumn));
					stringBuilder.Append(':');
					stringBuilder.Append(CellsHelper.CellIndexToName(cellArea_.EndRow, cellArea_.EndColumn));
					stringBuilder.Append(" have already been merged.");
					throw new CellsException(ExceptionType.Limitation, stringBuilder.ToString());
				}
			}
			bool flag = false;
			for (int j = int_0; j < int_0 + int_2; j++)
			{
				Row row = cells_0.Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = int_1; k < int_1 + int_3; k++)
				{
					Cell cellOrNull = row.GetCellOrNull(k);
					if (cellOrNull == null || cellOrNull.method_20() == Enum199.const_7)
					{
						continue;
					}
					if (!flag)
					{
						if (j != int_0 || k != int_1)
						{
							Cell cell = cells_0.GetCell(int_0, int_1, bool_2: false);
							switch (cellOrNull.method_20())
							{
							case Enum199.const_2:
								cell.PutValue(cellOrNull.IntValue);
								break;
							case Enum199.const_3:
								cell.PutValue(cellOrNull.DoubleValue);
								break;
							case Enum199.const_6:
								if (cellOrNull.IsRichText())
								{
									cell.method_55(cellOrNull, null);
								}
								else
								{
									cell.PutValue(cellOrNull.StringValue);
								}
								break;
							}
							cell.method_37(cellOrNull.method_35());
						}
						flag = true;
					}
					if (j != int_0 || k != int_1)
					{
						cellOrNull.PutValue(null);
					}
				}
			}
			base.InnerList.Add(cellArea);
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	internal ArrayList method_2()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(base.InnerList);
		return arrayList;
	}

	internal void method_3()
	{
		for (int num = base.InnerList.Count - 1; num >= 0; num--)
		{
			CellArea cellArea = (CellArea)base.InnerList[num];
			if (cellArea.StartRow <= 65535 && cellArea.StartColumn <= 255)
			{
				if (cellArea.EndRow > 65535)
				{
					cellArea.EndRow = 65535;
					if (cellArea.EndColumn > 255)
					{
						cellArea.EndColumn = 255;
					}
					base.InnerList[num] = cellArea;
				}
				else if (cellArea.EndColumn > 255)
				{
					cellArea.EndColumn = 255;
					base.InnerList[num] = cellArea;
				}
			}
			else
			{
				base.InnerList.RemoveAt(num);
			}
		}
	}

	internal void method_4(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea = (CellArea)base.InnerList[i];
			if (cellArea.StartColumn > cellArea_0.EndColumn)
			{
				if (cellArea.StartRow >= cellArea_0.StartRow && cellArea.EndRow <= cellArea_0.EndRow)
				{
					cellArea.StartColumn -= int_0;
					cellArea.EndColumn -= int_0;
					base.InnerList[i] = cellArea;
				}
			}
			else if (cellArea.StartRow >= cellArea_0.StartRow && cellArea.EndRow <= cellArea_0.EndRow && cellArea.StartColumn >= cellArea_0.StartColumn && cellArea.EndColumn <= cellArea_0.EndColumn)
			{
				base.InnerList.RemoveAt(i);
				i--;
			}
		}
	}

	internal void method_5(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea = (CellArea)base.InnerList[i];
			if (cellArea.StartRow > cellArea_0.EndRow)
			{
				if (cellArea.StartColumn >= cellArea_0.StartColumn && cellArea.EndColumn <= cellArea_0.EndColumn)
				{
					cellArea.StartRow -= int_0;
					cellArea.EndRow -= int_0;
					base.InnerList[i] = cellArea;
				}
			}
			else if (cellArea.StartRow >= cellArea_0.StartRow && cellArea.EndRow <= cellArea_0.EndRow && cellArea.StartColumn >= cellArea_0.StartColumn && cellArea.EndColumn <= cellArea_0.EndColumn)
			{
				base.InnerList.RemoveAt(i);
				i--;
			}
		}
	}

	internal void method_6(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea = (CellArea)base.InnerList[i];
			if (cellArea_0.EndColumn <= cellArea.StartColumn && cellArea.StartRow >= cellArea_0.StartRow && cellArea.EndRow <= cellArea_0.EndRow)
			{
				cellArea.StartColumn += int_0;
				cellArea.EndColumn += int_0;
				base.InnerList[i] = cellArea;
			}
		}
	}

	internal void method_7(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			CellArea cellArea = (CellArea)base.InnerList[i];
			if (cellArea_0.EndRow <= cellArea.StartRow && cellArea.StartColumn >= cellArea_0.StartColumn && cellArea.EndColumn <= cellArea_0.EndColumn)
			{
				cellArea.StartRow += int_0;
				cellArea.EndRow += int_0;
				base.InnerList[i] = cellArea;
			}
		}
	}

	internal void CopyColumns(Class1133 class1133_0, int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < class1133_0.Count; i++)
		{
			CellArea cellArea = class1133_0[i];
			if (cellArea.StartColumn >= int_0 && cellArea.EndColumn <= int_0 + int_2 - 1)
			{
				CellArea cellArea2 = default(CellArea);
				cellArea2.StartRow = cellArea.StartRow;
				cellArea2.EndRow = cellArea.EndRow;
				cellArea2.StartColumn = int_1 + cellArea.StartColumn - int_0;
				cellArea2.EndColumn = cellArea2.StartColumn + cellArea.EndColumn - cellArea.StartColumn;
				base.InnerList.Add(cellArea2);
			}
		}
	}

	internal void Copy(Class1133 class1133_0)
	{
		for (int i = 0; i < class1133_0.Count; i++)
		{
			CellArea cellArea_ = class1133_0[i];
			CellArea cellArea = CellArea.CreateCellArea(cellArea_);
			base.InnerList.Add(cellArea);
		}
	}

	internal void CopyRows(Class1133 class1133_0, int int_0, int int_1, int int_2)
	{
		int count = class1133_0.Count;
		CellArea cellArea = default(CellArea);
		for (int i = 0; i < count; i++)
		{
			CellArea cellArea2 = class1133_0[i];
			if ((cellArea.StartRow > 0 || cellArea.EndRow > 0 || cellArea.StartColumn > 0 || cellArea.EndColumn > 0) && cellArea2.StartRow >= cellArea.StartRow && cellArea2.EndRow <= cellArea.EndRow)
			{
				base.InnerList.Remove(cellArea2);
			}
			if (cellArea2.StartRow >= int_0 && cellArea2.EndRow < int_0 + int_2)
			{
				CellArea cellArea3 = default(CellArea);
				int num = cellArea2.StartRow - int_0;
				int num2 = cellArea2.EndRow - cellArea2.StartRow;
				cellArea3.StartRow = int_1 + num;
				cellArea3.EndRow = cellArea3.StartRow + num2;
				cellArea3.StartColumn = cellArea2.StartColumn;
				cellArea3.EndColumn = cellArea2.EndColumn;
				base.InnerList.Add(cellArea3);
				cellArea = cellArea3;
			}
		}
	}

	internal void method_8(CellArea cellArea_0, int int_0, int int_1, int int_2, int int_3)
	{
		for (int i = 0; i < base.Count; i++)
		{
			CellArea cellArea = this[i];
			if (cellArea_0.StartRow <= cellArea.StartRow && cellArea_0.EndRow >= cellArea.EndRow && cellArea_0.StartColumn <= cellArea.StartColumn && cellArea_0.EndColumn >= cellArea.EndColumn)
			{
				cellArea.StartRow += int_2 - cellArea_0.StartRow;
				cellArea.EndRow += int_2 - cellArea_0.StartRow;
				cellArea.StartColumn += int_3 - cellArea_0.StartColumn;
				cellArea.EndColumn += int_3 - cellArea_0.StartColumn;
				base.InnerList[i] = cellArea;
			}
			else if (int_2 <= cellArea.StartRow && int_2 + int_0 - 1 >= cellArea.EndRow && int_3 <= cellArea.StartColumn && int_3 + int_1 - 1 >= cellArea.EndColumn)
			{
				base.InnerList.RemoveAt(i--);
			}
		}
	}
}
