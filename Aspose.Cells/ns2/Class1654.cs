using System;
using System.Data;
using System.Text;
using Aspose.Cells;

namespace ns2;

internal class Class1654
{
	private WorksheetCollection worksheetCollection_0;

	private ReplaceOptions replaceOptions_0;

	internal Class1654(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		replaceOptions_0 = new ReplaceOptions();
		replaceOptions_0.CaseSensitive = true;
	}

	internal Class1654(WorksheetCollection worksheetCollection_1, ReplaceOptions replaceOptions_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		replaceOptions_0 = replaceOptions_1;
	}

	internal int Replace(bool bool_0, object object_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() == Enum199.const_0 && cellByIndex.BoolValue == bool_0)
					{
						cellByIndex.PutValue(object_0);
						num++;
					}
				}
			}
		}
		return num;
	}

	internal int Replace(int int_0, object object_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if ((cellByIndex.method_20() == Enum199.const_3 || cellByIndex.method_20() == Enum199.const_2) && cellByIndex.IntValue == int_0)
					{
						num++;
						cellByIndex.PutValue(object_0);
					}
				}
			}
		}
		return num;
	}

	internal int Replace(string string_0, string string_1)
	{
		if (!replaceOptions_0.CaseSensitive)
		{
			string_0 = string_0.ToUpper();
		}
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() != Enum199.const_6)
					{
						continue;
					}
					string stringValue = cellByIndex.StringValue;
					if (replaceOptions_0.MatchEntireCellContents)
					{
						if (replaceOptions_0.CaseSensitive)
						{
							if (stringValue == string_0)
							{
								cellByIndex.PutValue(string_1);
								num++;
							}
						}
						else if (stringValue.ToUpper() == string_0)
						{
							cellByIndex.PutValue(string_1);
							num++;
						}
						continue;
					}
					if (replaceOptions_0.CaseSensitive)
					{
						if (stringValue.IndexOf(string_0) != -1)
						{
							cellByIndex.PutValue(stringValue.Replace(string_0, string_1));
							num++;
						}
						continue;
					}
					string text = stringValue.ToUpper();
					if (text.IndexOf(string_0) == -1)
					{
						continue;
					}
					StringBuilder stringBuilder = new StringBuilder();
					int num2 = 0;
					while (true)
					{
						int num3 = text.IndexOf(string_0, num2);
						if (num3 == -1)
						{
							break;
						}
						stringBuilder.Append(stringValue.Substring(num2, num3 - num2));
						stringBuilder.Append(string_1);
						num2 = num3 + string_0.Length;
					}
					stringBuilder.Append(stringValue.Substring(num2));
					num++;
					cellByIndex.PutValue(stringBuilder.ToString());
				}
			}
		}
		return num;
	}

	internal int Replace(string string_0, int int_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() == Enum199.const_6 && cellByIndex.StringValue == string_0)
					{
						num++;
						cellByIndex.PutValue(int_0);
					}
				}
			}
		}
		return num;
	}

	internal int Replace(string string_0, double double_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() == Enum199.const_6 && cellByIndex.StringValue == string_0)
					{
						num++;
						cellByIndex.PutValue(double_0);
					}
				}
			}
		}
		return num;
	}

	public int Replace(string string_0, double[] double_0, bool bool_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			Cells cells = worksheetCollection_0[i].Cells;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() != Enum199.const_6 || !(cellByIndex.StringValue == string_0))
					{
						continue;
					}
					num++;
					cellByIndex.PutValue(double_0[0]);
					int int_ = cellByIndex.method_36();
					int num2;
					int column;
					if (bool_0)
					{
						num2 = cellByIndex.Row + 1;
						column = cellByIndex.Column;
						for (int l = num2; l < num2 + double_0.Length - 1; l++)
						{
							if (l <= 16384)
							{
								cellByIndex = cells.GetCell(l, column, bool_2: false);
								cellByIndex.PutValue(double_0[l - num2 + 1]);
								if (cellByIndex.method_36() == -1)
								{
									cellByIndex.method_37(int_);
								}
							}
						}
						continue;
					}
					num2 = cellByIndex.Row;
					if (cellByIndex.Column >= 255)
					{
						continue;
					}
					column = (byte)(cellByIndex.Column + 1);
					for (int m = column; m < column + double_0.Length - 1; m++)
					{
						if (m <= 255)
						{
							cellByIndex = cells.GetCell(num2, m, bool_2: false);
							cellByIndex.PutValue(double_0[m - column + 1]);
							if (cellByIndex.method_36() == -1)
							{
								cellByIndex.method_37(int_);
							}
						}
					}
				}
			}
		}
		return num;
	}

	public int Replace(string string_0, int[] int_0, bool bool_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			Cells cells = worksheetCollection_0[i].Cells;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() != Enum199.const_6 || !(cellByIndex.StringValue == string_0))
					{
						continue;
					}
					num++;
					cellByIndex.PutValue(int_0[0]);
					int int_ = cellByIndex.method_36();
					int num2;
					int column;
					if (bool_0)
					{
						num2 = cellByIndex.Row + 1;
						column = cellByIndex.Column;
						for (int l = num2; l < num2 + int_0.Length - 1; l++)
						{
							if (l <= 16384)
							{
								cellByIndex = cells.GetCell(l, column, bool_2: false);
								cellByIndex.PutValue(int_0[l - num2 + 1]);
								if (cellByIndex.method_36() == -1)
								{
									cellByIndex.method_37(int_);
								}
							}
						}
						continue;
					}
					num2 = cellByIndex.Row;
					if (cellByIndex.Column >= 255)
					{
						continue;
					}
					column = (byte)(cellByIndex.Column + 1);
					for (int m = column; m < column + int_0.Length - 1; m++)
					{
						if (m <= 255)
						{
							cellByIndex = cells.GetCell(num2, m, bool_2: false);
							cellByIndex.PutValue(int_0[m - column + 1]);
							if (cellByIndex.method_36() == -1)
							{
								cellByIndex.method_37(int_);
							}
						}
					}
				}
			}
		}
		return num;
	}

	internal int Replace(string string_0, string[] string_1, bool bool_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			Cells cells = worksheetCollection_0[i].Cells;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() != Enum199.const_6 || !(cellByIndex.StringValue == string_0))
					{
						continue;
					}
					num++;
					if (string_1[0] != null)
					{
						cellByIndex.PutValue(string_1[0]);
						int int_ = cellByIndex.method_36();
						int num2;
						int column;
						if (bool_0)
						{
							num2 = cellByIndex.Row + 1;
							column = cellByIndex.Column;
							for (int l = num2; l < num2 + string_1.Length - 1; l++)
							{
								if (l <= 16384)
								{
									cellByIndex = cells.GetCell(l, column, bool_2: false);
									if (string_1[l - num2 + 1] == null)
									{
										return 0;
									}
									cellByIndex.PutValue(string_1[l - num2 + 1]);
									if (cellByIndex.method_36() == -1)
									{
										cellByIndex.method_37(int_);
									}
								}
							}
							continue;
						}
						num2 = cellByIndex.Row;
						if (cellByIndex.Column >= 255)
						{
							continue;
						}
						column = (byte)(cellByIndex.Column + 1);
						for (int m = column; m < column + string_1.Length - 1; m++)
						{
							if (m <= 255)
							{
								cellByIndex = cells.GetCell(num2, m, bool_2: false);
								if (string_1[m - column + 1] == null)
								{
									return 0;
								}
								cellByIndex.PutValue(string_1[m - column + 1]);
								if (cellByIndex.method_36() == -1)
								{
									cellByIndex.method_37(int_);
								}
							}
						}
						continue;
					}
					return 0;
				}
			}
		}
		return num;
	}

	internal int Replace(string string_0, DataTable dataTable_0)
	{
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.method_20() == Enum199.const_6 && cellByIndex.StringValue == string_0)
					{
						method_0(cellByIndex, dataTable_0);
						num++;
					}
				}
			}
		}
		return num;
	}

	private void method_0(Cell cell_0, DataTable dataTable_0)
	{
		int row = cell_0.Row;
		int column = cell_0.Column;
		int num = ((dataTable_0.Rows.Count + row > 65535) ? 65535 : dataTable_0.Rows.Count);
		int num2 = ((dataTable_0.Columns.Count + column > 255) ? 255 : dataTable_0.Columns.Count);
		Cells cells = cell_0.method_4();
		for (int i = 0; i < num; i++)
		{
			DataRow dataRow = dataTable_0.Rows[i];
			for (int j = 0; j < num2; j++)
			{
				DataColumn column2 = dataTable_0.Columns[j];
				if (dataRow.IsNull(column2))
				{
					continue;
				}
				Cell cell = cells.GetCell(row + i, column + j, bool_2: false);
				object obj = dataRow[column2];
				Type type = obj.GetType();
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.Boolean:
					cell.PutValue((bool)obj);
					break;
				case TypeCode.Char:
					cell.PutValue((char)obj);
					break;
				case TypeCode.SByte:
					cell.PutValue((sbyte)obj);
					break;
				case TypeCode.Byte:
					cell.PutValue((byte)obj);
					break;
				case TypeCode.Int16:
					cell.PutValue((short)obj);
					break;
				case TypeCode.UInt16:
					cell.PutValue((ushort)obj);
					break;
				case TypeCode.Int32:
					cell.PutValue((int)obj);
					break;
				case TypeCode.UInt32:
					if ((uint)obj > 536870911)
					{
						cell.PutValue((uint)obj);
					}
					else
					{
						cell.PutValue((int)(uint)obj);
					}
					break;
				case TypeCode.Int64:
					if ((long)obj > 536870911)
					{
						cell.PutValue((long)obj);
					}
					else
					{
						cell.PutValue((int)(long)obj);
					}
					break;
				case TypeCode.UInt64:
					if ((ulong)obj > 536870911)
					{
						cell.PutValue((ulong)obj);
					}
					else
					{
						cell.PutValue((int)(ulong)obj);
					}
					break;
				case TypeCode.Single:
					cell.PutValue((float)obj);
					break;
				case TypeCode.Double:
					cell.PutValue((double)obj);
					break;
				case TypeCode.Decimal:
					cell.PutValue((double)(decimal)obj);
					break;
				case TypeCode.DateTime:
				{
					cell.PutValue((DateTime)obj);
					Style style = cell.method_28();
					if (style.Number == 0 && (style.Custom == null || style.Custom == ""))
					{
						style.Number = 14;
					}
					else
					{
						style.Number = 14;
					}
					cell.method_30(style);
					break;
				}
				default:
					cell.PutValue(obj.ToString());
					break;
				case TypeCode.String:
					cell.PutValue((string)obj);
					break;
				case TypeCode.Empty:
				case TypeCode.DBNull:
					break;
				}
			}
		}
	}
}
