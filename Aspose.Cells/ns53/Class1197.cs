using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns12;
using ns16;
using ns2;
using ns38;
using ns54;
using ns7;

namespace ns53;

internal class Class1197 : Interface45
{
	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private byte[] byte_0;

	private ArrayList arrayList_0;

	private Enum126 enum126_0;

	public bool IsVisible
	{
		get
		{
			if (byte_0 == null)
			{
				return true;
			}
			int num = 2;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			Cells cells = null;
			while (num < byte_0.Length)
			{
				switch (byte_0[num])
				{
				default:
					num++;
					break;
				case 41:
				case 73:
				case 105:
					num += 3;
					break;
				case 57:
				case 89:
				case 121:
					num4 = BitConverter.ToInt16(byte_0, num + 1);
					if (num3 == worksheetCollection_0.method_36())
					{
						num2 = worksheetCollection_0.method_32().method_13(num4);
						Name name = worksheetCollection_0.Names[BitConverter.ToInt16(byte_0, num + 3) - 1];
						if (name != null)
						{
							Range range = name.CreateRange();
							if (range == null)
							{
								return true;
							}
							cells = range.Worksheet.Cells;
							CellArea area = range.Area;
							int i = area.StartRow;
							int j = area.StartColumn;
							int num5 = area.EndRow;
							int num6 = area.EndColumn;
							if (i > num5)
							{
								int num7 = i;
								i = num5;
								num5 = num7;
							}
							if (j > num6)
							{
								int num8 = j;
								j = num6;
								num6 = num8;
							}
							if (i == num5)
							{
								if (cells.GetRowHeight(i) != 0.0)
								{
									for (; j <= num6; j++)
									{
										if (cells.GetColumnWidth(j) != 0.0)
										{
											return true;
										}
									}
								}
							}
							else if (cells.GetColumnWidth(j) != 0.0)
							{
								for (; i <= num5; i++)
								{
									if (cells.GetRowHeight(i) != 0.0)
									{
										return true;
									}
								}
							}
						}
						num += 7;
						break;
					}
					return true;
				case 58:
				case 90:
				case 122:
					num4 = BitConverter.ToUInt16(byte_0, num + 1);
					num3 = worksheetCollection_0.method_32().method_12(num4);
					if (num3 == worksheetCollection_0.method_36())
					{
						num2 = worksheetCollection_0.method_32().method_13(num4);
						if (num2 >= 0 && num2 < worksheetCollection_0.Count)
						{
							int row = BitConverter.ToUInt16(byte_0, num + 3);
							byte column = byte_0[num + 5];
							cells = worksheetCollection_0[num2].Cells;
							if (cells.GetRowHeight(row) != 0.0 && cells.GetColumnWidth(column) != 0.0)
							{
								return true;
							}
							num += 7;
						}
						else
						{
							num += 7;
							if (arrayList_0 != null && arrayList_0.Count > 0)
							{
								return true;
							}
						}
						break;
					}
					return true;
				case 59:
				case 91:
				case 123:
					num4 = BitConverter.ToUInt16(byte_0, num + 1);
					num3 = worksheetCollection_0.method_32().method_12(num4);
					if (num3 == worksheetCollection_0.method_36())
					{
						num2 = worksheetCollection_0.method_32().method_13(num4);
						if (num2 >= 0 && num2 < worksheetCollection_0.Count)
						{
							int k = BitConverter.ToUInt16(byte_0, num + 3);
							int num9 = BitConverter.ToUInt16(byte_0, num + 5);
							byte b = byte_0[num + 7];
							byte b2 = byte_0[num + 9];
							if (k > num9)
							{
								int num10 = k;
								k = num9;
								num9 = num10;
							}
							if (b > b2)
							{
								byte b3 = b;
								b = b2;
								b2 = b3;
							}
							cells = worksheetCollection_0[num2].Cells;
							if (k == num9)
							{
								if (cells.GetRowHeight(k) != 0.0)
								{
									while (b <= b2)
									{
										if (cells.GetColumnWidth(b) == 0.0)
										{
											b = (byte)(b + 1);
											continue;
										}
										return true;
									}
								}
							}
							else if (cells.GetColumnWidth(b) != 0.0)
							{
								for (; k <= num9; k++)
								{
									if (cells.GetRowHeight(k) != 0.0)
									{
										return true;
									}
								}
							}
							num += 11;
						}
						else
						{
							num += 11;
							if (arrayList_0 != null && arrayList_0.Count > 0)
							{
								return true;
							}
						}
						break;
					}
					return true;
				case 60:
				case 61:
				case 92:
				case 93:
				case 124:
				case 125:
					if (arrayList_0 != null)
					{
						return arrayList_0.Count > 0;
					}
					return false;
				}
			}
			return false;
		}
	}

	public string Values
	{
		get
		{
			switch (enum126_0)
			{
			default:
				return "";
			case Enum126.const_2:
			case Enum126.const_3:
			case Enum126.const_4:
				return worksheetCollection_0.method_4().method_4(-1, -1, byte_0, 0, 0, bool_0: false);
			case Enum126.const_5:
			{
				string text = worksheetCollection_0.method_4().method_4(-1, -1, byte_0, 0, 0, bool_0: false);
				return text.Substring(1, text.Length - 1);
			}
			case Enum126.const_1:
			case Enum126.const_6:
				return Class922.smethod_3(arrayList_0);
			}
		}
	}

	public int StartRow
	{
		get
		{
			if (byte_0 != null)
			{
				return BitConverter.ToUInt16(byte_0, 2 + 3);
			}
			return 0;
		}
	}

	public int StartColumn
	{
		get
		{
			if (byte_0 != null)
			{
				int num = 2;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return byte_0[num + 5] & 0xFF;
				case Enum126.const_3:
					return byte_0[num + 7] & 0xFF;
				}
			}
			return 0;
		}
	}

	public int EndRow
	{
		get
		{
			if (byte_0 != null)
			{
				int num = 2;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return BitConverter.ToUInt16(byte_0, num + 3);
				case Enum126.const_3:
					return BitConverter.ToUInt16(byte_0, num + 5);
				}
			}
			return 0;
		}
	}

	public int EndColumn
	{
		get
		{
			if (byte_0 != null)
			{
				int num = 2;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return byte_0[num + 5] & 0xFF;
				case Enum126.const_3:
					return byte_0[num + 9] & 0xFF;
				}
			}
			return 0;
		}
	}

	[SpecialName]
	private int method_0()
	{
		return worksheet_0.SheetIndex;
	}

	[SpecialName]
	internal Worksheet method_1()
	{
		return worksheet_0;
	}

	internal Class1197(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, string string_0)
	{
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
		arrayList_0 = method_7(string_0);
	}

	internal Class1197(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	public bool imethod_0()
	{
		if (byte_0 == null)
		{
			return false;
		}
		int num = 2;
		Class1246 @class = null;
		int num2 = -1;
		while (num < byte_0.Length)
		{
			switch (byte_0[num])
			{
			case 21:
				num++;
				break;
			default:
				num++;
				break;
			case 57:
			case 89:
			case 121:
				num2 = BitConverter.ToInt16(byte_0, num + 1);
				@class = worksheetCollection_0.method_32()[num2];
				if (@class.ushort_0 == worksheetCollection_0.method_36())
				{
					Name name = worksheetCollection_0.Names[BitConverter.ToInt16(byte_0, num + 3) - 1];
					if (name != null)
					{
						Range range = name.CreateRange();
						if (range == null)
						{
							return false;
						}
					}
					num += 7;
					break;
				}
				return false;
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				@class = worksheetCollection_0.method_32()[num2];
				if (@class.ushort_0 == worksheetCollection_0.method_36() && @class.ushort_1 >= 0 && @class.ushort_1 < worksheetCollection_0.Count && @class.ushort_2 >= 0 && @class.ushort_2 < worksheetCollection_0.Count)
				{
					num += 7;
					break;
				}
				return false;
			case 59:
			case 91:
			case 123:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				@class = worksheetCollection_0.method_32()[num2];
				if (@class.ushort_0 == worksheetCollection_0.method_36() && @class.ushort_1 >= 0 && @class.ushort_1 < worksheetCollection_0.Count && @class.ushort_2 >= 0 && @class.ushort_2 < worksheetCollection_0.Count)
				{
					num += 11;
					break;
				}
				return false;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 60:
			case 61:
			case 92:
			case 93:
			case 124:
			case 125:
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public ArrayList imethod_2()
	{
		return arrayList_0;
	}

	[SpecialName]
	public void imethod_3(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	public byte[] imethod_4()
	{
		return byte_0;
	}

	[SpecialName]
	public void imethod_5(byte[] byte_1)
	{
		byte_0 = byte_1;
	}

	[SpecialName]
	public bool imethod_6()
	{
		if (byte_0 != null)
		{
			switch (byte_0[2])
			{
			case 42:
			case 43:
			case 60:
			case 61:
			case 74:
			case 75:
			case 92:
			case 93:
			case 106:
			case 107:
			case 124:
			case 125:
				return true;
			}
		}
		return false;
	}

	public ArrayList imethod_7(bool bool_0, bool bool_1, ref int int_0)
	{
		if (bool_1 && arrayList_0 != null && arrayList_0.Count > 0)
		{
			return Class922.smethod_5(arrayList_0, bool_0, bool_1, ref int_0);
		}
		int_0 = 1;
		bool bool_2 = false;
		int num = 0;
		int num2 = 2;
		if (byte_0 != null && byte_0.Length == 13)
		{
			byte b = byte_0[num2];
			if (b == 59 || b == 91 || b == 123)
			{
				int int_ = BitConverter.ToUInt16(byte_0, num2 + 1);
				num = worksheetCollection_0.method_32().method_12(int_);
				int num3 = worksheetCollection_0.method_32().method_13(int_);
				int num4 = BitConverter.ToUInt16(byte_0, num2 + 3);
				int num5 = BitConverter.ToUInt16(byte_0, num2 + 5);
				byte b2 = byte_0[num2 + 7];
				byte b3 = byte_0[num2 + 9];
				if (num4 > num5)
				{
					int num6 = num4;
					num4 = num5;
					num5 = num6;
				}
				if (b2 > b3)
				{
					byte b4 = b2;
					b2 = b3;
					b3 = b4;
				}
				if (num != worksheetCollection_0.method_36())
				{
					if (arrayList_0 != null && arrayList_0.Count != 0)
					{
						ArrayList arrayList = new ArrayList();
						{
							foreach (object item in arrayList_0)
							{
								arrayList.Add(new Class1196(item, 0, null));
							}
							return arrayList;
						}
					}
					ArrayList arrayList2 = new ArrayList();
					method_2(arrayList2, bool_0: false, num4, b2, num5, b3, num, num3, ref bool_2);
					return arrayList2;
				}
				if (num3 < 0 || num3 >= worksheetCollection_0.Count)
				{
					if (arrayList_0 != null && arrayList_0.Count != 0)
					{
						ArrayList arrayList3 = new ArrayList();
						{
							foreach (object item2 in arrayList_0)
							{
								arrayList3.Add(new Class1196(item2, 0, null));
							}
							return arrayList3;
						}
					}
					return null;
				}
				if (b2 != b3 && num4 != num5)
				{
					ArrayList arrayList4 = new ArrayList();
					Cells cells = worksheetCollection_0[num3].Cells;
					if (num5 > cells.method_20(0))
					{
						num5 = cells.method_20(0);
					}
					bool flag = false;
					Class1196 @class = null;
					bool[] array = null;
					if (bool_0)
					{
						int_0 = b3 - b2 + 1;
						array = new bool[int_0];
						for (int i = 0; i < int_0; i++)
						{
							arrayList4.Add(new ArrayList());
						}
						for (int j = num4; j <= num5; j++)
						{
							for (int k = 0; k < int_0; k++)
							{
								@class = vmethod_0((ArrayList)arrayList4[k], cells, j, b2 + k, bool_0: false);
								if (!@class.bool_1)
								{
									array[k] = true;
									flag = true;
								}
							}
						}
					}
					else
					{
						int_0 = num5 - num4 + 1;
						array = new bool[int_0];
						for (int l = 0; l < int_0; l++)
						{
							arrayList4.Add(new ArrayList());
						}
						for (int m = b2; m <= b3; m++)
						{
							for (int n = 0; n < int_0; n++)
							{
								@class = vmethod_0((ArrayList)arrayList4[n], cells, num4 + n, m, bool_0: false);
								if (!@class.bool_1)
								{
									array[n] = true;
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						int num7 = 0;
						int num8 = 0;
						while (num8 < array.Length)
						{
							if (!array[num8])
							{
								arrayList4.RemoveAt(num7--);
								int_0--;
							}
							num8++;
							num7++;
						}
						if (arrayList4.Count == 1)
						{
							int_0 = 1;
							return (ArrayList)arrayList4[0];
						}
						return arrayList4;
					}
					int_0 = 1;
					return (ArrayList)arrayList4[0];
				}
			}
		}
		return imethod_8(bool_0: false, bool_1, ref bool_2);
	}

	private void method_2(ArrayList arrayList_1, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, ref bool bool_1)
	{
		Class1718 @class = worksheetCollection_0.method_39()[int_4];
		if (int_5 >= 0 && @class.method_4() != null && int_5 <= @class.method_4().Length)
		{
			Class1373 class2 = @class.method_10(int_5);
			if (class2 == null || !class2.method_1())
			{
				if (arrayList_0 != null && arrayList_0.Count > 0)
				{
					Class922.smethod_1(arrayList_0, arrayList_1, bool_0);
				}
				else
				{
					bool_1 = true;
				}
				return;
			}
			object[][] array = Class1377.smethod_5(class2, int_0, int_1, int_2, int_3);
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
				{
					if (array[i][j] == null)
					{
						if (bool_0)
						{
							arrayList_1.Add(new Class1196(0.0, 0, null));
						}
						else
						{
							arrayList_1.Add(new Class1196(null, 0, null));
						}
					}
					else if (bool_0)
					{
						if (array[i][j] is double)
						{
							arrayList_1.Add(new Class1196(array[i][j], 0, null));
						}
						else
						{
							arrayList_1.Add(new Class1196(0.0, 0, null));
						}
					}
					else
					{
						arrayList_1.Add(new Class1196(array[i][j].ToString(), 0, null));
					}
				}
			}
		}
		else if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			Class922.smethod_1(arrayList_0, arrayList_1, bool_0);
		}
		else if (bool_0)
		{
			arrayList_1.Add(new Class1196(0.0, 0, null));
		}
		else
		{
			arrayList_1.Add(new Class1196(null, 0, null));
		}
	}

	public string imethod_9()
	{
		bool bool_ = false;
		ArrayList arrayList = imethod_8(bool_0: false, bool_1: false, ref bool_);
		if (!bool_ && arrayList != null && arrayList.Count != 0)
		{
			Class1196 @class = (Class1196)arrayList[0];
			return @class.StringValue;
		}
		return "";
	}

	public ArrayList imethod_8(bool bool_0, bool bool_1, ref bool bool_2)
	{
		bool_2 = false;
		ArrayList arrayList = new ArrayList();
		if (bool_1 && arrayList_0 != null && arrayList_0.Count != 0)
		{
			Class922.smethod_1(arrayList_0, arrayList, bool_0);
			return arrayList;
		}
		if ((enum126_0 == Enum126.const_1 || enum126_0 == Enum126.const_6) && arrayList_0 != null)
		{
			Class922.smethod_1(arrayList_0, arrayList, bool_0);
			return arrayList;
		}
		if (byte_0 == null)
		{
			return null;
		}
		int num = 2;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Cells cells = null;
		while (num < byte_0.Length)
		{
			switch (byte_0[num])
			{
			default:
				num++;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 57:
			case 89:
			case 121:
			{
				num2 = BitConverter.ToInt16(byte_0, num + 1);
				num4 = worksheetCollection_0.method_32().method_15(worksheetCollection_0, num2);
				if (num4 >= 0)
				{
					_ = worksheetCollection_0.Count;
				}
				Name name = worksheetCollection_0.Names[BitConverter.ToInt16(byte_0, num + 3) - 1];
				if (name != null)
				{
					Range range = name.CreateRange();
					if (range == null)
					{
						Class1658 class2 = new Class1658(worksheetCollection_0.Workbook);
						Class1661 class1661_ = worksheetCollection_0.Formula.method_9(name, null);
						object obj = class2.method_2(class1661_, null);
						if (obj is Array)
						{
							Array array = (Array)obj;
							for (int j = 0; j < array.Length; j++)
							{
								Array array2 = (Array)array.GetValue(j);
								if (array2 != null)
								{
									for (int k = 0; k < array2.Length; k++)
									{
										arrayList.Add(new Class1196(array2.GetValue(k), 0, null));
									}
								}
							}
							num += 7;
							break;
						}
						if (obj is Struct87 @struct)
						{
							num4 = @struct.int_1;
							if (num4 >= 0 && num4 < worksheetCollection_0.Count)
							{
								range = new Range(@struct.cellArea_0.StartRow, @struct.cellArea_0.StartColumn, @struct.cellArea_0.EndRow - @struct.cellArea_0.StartRow + 1, @struct.cellArea_0.EndColumn - @struct.cellArea_0.StartColumn + 1, worksheetCollection_0[@struct.int_1].Cells);
							}
						}
					}
					if (range == null)
					{
						if (arrayList_0 == null)
						{
							if (num4 > worksheetCollection_0.Count)
							{
								bool_2 = true;
								arrayList.Add(new Class1196(0.0, 0, null));
								num += 7;
							}
							break;
						}
						{
							foreach (object item in arrayList_0)
							{
								arrayList.Add(new Class1196(item, 0, null));
							}
							return arrayList;
						}
					}
					cells = range.Worksheet.Cells;
					CellArea area = range.Area;
					int l = area.StartRow;
					int m = area.StartColumn;
					int num8 = area.EndRow;
					int num9 = area.EndColumn;
					if (l > num8)
					{
						int num10 = l;
						l = num8;
						num8 = num10;
					}
					if (m > num9)
					{
						int num11 = m;
						m = num9;
						num9 = num11;
					}
					if (l == num8)
					{
						for (; m <= num9; m++)
						{
							vmethod_0(arrayList, cells, l, m, bool_0);
						}
					}
					else
					{
						for (; l <= num8; l++)
						{
							vmethod_0(arrayList, cells, l, m, bool_0);
						}
					}
				}
				num += 7;
				break;
			}
			case 58:
			case 90:
			case 122:
			{
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num3 = worksheetCollection_0.method_32().method_12(num2);
				num4 = worksheetCollection_0.method_32().method_13(num2);
				int num12 = BitConverter.ToUInt16(byte_0, num + 3);
				byte b4 = byte_0[num + 5];
				if (num3 != worksheetCollection_0.method_36())
				{
					method_2(arrayList, bool_0, num12, b4, num12, b4, num3, num4, ref bool_2);
					num += 7;
				}
				else if (num4 >= 0 && num4 < worksheetCollection_0.Count)
				{
					cells = worksheetCollection_0[num4].Cells;
					vmethod_0(arrayList, cells, num12, b4, bool_0);
					num += 7;
				}
				else
				{
					bool_2 = true;
					arrayList.Add(new Class1196(0.0, 0, null));
					num += 7;
				}
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num3 = worksheetCollection_0.method_32().method_12(num2);
				num4 = worksheetCollection_0.method_32().method_13(num2);
				int i = BitConverter.ToUInt16(byte_0, num + 3);
				int num5 = BitConverter.ToUInt16(byte_0, num + 5);
				byte b = byte_0[num + 7];
				byte b2 = byte_0[num + 9];
				if (i > num5)
				{
					int num6 = i;
					i = num5;
					num5 = num6;
				}
				if (b > b2)
				{
					byte b3 = b;
					b = b2;
					b2 = b3;
				}
				if (num3 != worksheetCollection_0.method_36())
				{
					method_2(arrayList, bool_0, i, b, num5, b2, num3, num4, ref bool_2);
					num += 11;
				}
				else if (num4 >= 0 && num4 < worksheetCollection_0.Count)
				{
					cells = worksheetCollection_0[num4].Cells;
					if (i == num5)
					{
						while (b <= b2)
						{
							vmethod_0(arrayList, cells, i, b, bool_0);
							b = (byte)(b + 1);
						}
					}
					else
					{
						int num7 = cells.method_20(0);
						for (; i <= num5; i++)
						{
							if (i > num7)
							{
								Style style = null;
								Class1196 @class = new Class1196();
								arrayList.Add(@class);
								if (cells.GetRowHeight(i) == 0.0 || cells.GetColumnWidth(b) == 0.0)
								{
									@class.bool_0 = false;
								}
								@class.bool_1 = true;
								@class.cellValueType_0 = CellValueType.IsNull;
								style = Class922.smethod_2(cells, i, b);
								if (bool_0)
								{
									@class.object_0 = 0.0;
								}
								else
								{
									@class.object_0 = "";
								}
								if (style != null)
								{
									@class.int_0 = style.Number;
									@class.string_0 = style.Custom;
									@class.bool_2 = style.IsDateTime;
								}
							}
							else
							{
								vmethod_0(arrayList, cells, i, b, bool_0);
							}
						}
					}
					num += 11;
				}
				else
				{
					bool_2 = true;
					arrayList.Add(new Class1196(0.0, 0, null));
					num += 11;
				}
				break;
			}
			case 60:
			case 92:
			case 124:
				bool_2 = true;
				num += 7;
				break;
			case 61:
			case 93:
			case 125:
				bool_2 = true;
				num += 11;
				break;
			}
		}
		if (bool_2 && arrayList_0 != null)
		{
			arrayList = new ArrayList();
			Class922.smethod_1(arrayList_0, arrayList, bool_0);
			return arrayList;
		}
		return arrayList;
	}

	public Class1196 vmethod_0(ArrayList arrayList_1, Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		Style style = null;
		Cell cell = null;
		Class1196 @class = new Class1196();
		if (cells_0.GetRowHeight(int_0) == 0.0 || cells_0.GetColumnWidth(int_1) == 0.0)
		{
			@class.bool_0 = false;
		}
		cell = cells_0.CheckCell(int_0, int_1);
		if (cell == null)
		{
			@class.bool_1 = true;
			@class.cellValueType_0 = CellValueType.IsNull;
			style = Class922.smethod_2(cells_0, int_0, int_1);
			if (bool_0)
			{
				@class.object_0 = 0.0;
			}
			else
			{
				@class.object_0 = "";
			}
			if (style != null)
			{
				@class.int_0 = style.Number;
				@class.string_0 = style.Custom;
				@class.bool_2 = style.IsDateTime;
			}
		}
		else
		{
			@class.bool_1 = false;
			@class.cellValueType_0 = cell.Type;
			CellValueType type = cell.Type;
			if (type == CellValueType.IsNull)
			{
				@class.bool_1 = true;
				if (bool_0)
				{
					@class.object_0 = 0.0;
				}
				else
				{
					@class.object_0 = "";
				}
			}
			else if (bool_0)
			{
				@class.object_0 = method_3(cell);
			}
			else
			{
				@class.object_0 = method_3(cell);
			}
			if (cell.method_34())
			{
				style = cell.method_32();
			}
			if (style != null)
			{
				@class.string_0 = style.Custom;
				@class.int_0 = style.Number;
				@class.bool_2 = style.IsDateTime;
			}
			else
			{
				@class.string_0 = "";
				@class.int_0 = 0;
			}
		}
		arrayList_1.Add(@class);
		return @class;
	}

	private object method_3(Cell cell_0)
	{
		try
		{
			switch (cell_0.Type)
			{
			default:
				return 0;
			case CellValueType.IsBool:
				return cell_0.Value;
			case CellValueType.IsDateTime:
			case CellValueType.IsNumeric:
				return cell_0.DoubleValue;
			case CellValueType.IsError:
			case CellValueType.IsNull:
			case CellValueType.IsString:
			case CellValueType.IsUnknown:
				return cell_0.StringValue;
			}
		}
		catch
		{
			return 0;
		}
	}

	public void imethod_10(out int supbook, out int sheetIndex)
	{
		if (byte_0 == null)
		{
			supbook = worksheetCollection_0.method_36();
			sheetIndex = method_0();
		}
		else
		{
			int int_ = BitConverter.ToUInt16(byte_0, 2 + 1);
			sheetIndex = worksheetCollection_0.method_32().method_13(int_);
			supbook = worksheetCollection_0.method_32().method_12(int_);
		}
	}

	private void method_4(string[] string_0)
	{
		if (string_0[0][0] == '(')
		{
			string_0[0] = string_0[0].Substring(1);
			string text = string_0[string_0.Length - 1];
			string_0[string_0.Length - 1] = text.Substring(0, text.Length - 1);
		}
		worksheetCollection_0.method_36();
		for (int i = 0; i < string_0.Length; i++)
		{
			string_0[i] = string_0[i].Trim();
		}
		if (string_0.Length > 0 && string_0[0][0] == '=')
		{
			string_0[0] = string_0[0].Substring(1);
		}
		ArrayList arrayList = new ArrayList(string_0.Length);
		int num = 3 + string_0.Length - 1 + 1;
		foreach (string string_ in string_0)
		{
			byte[] array = method_10(string_);
			byte[] array2 = new byte[array.Length - 2];
			Array.Copy(array, 2, array2, 0, array2.Length);
			arrayList.Add(array2);
			num += array2.Length;
		}
		byte[] array3 = new byte[num + 2];
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, array3, 0, 2);
		int num2 = 2;
		array3[2] = 41;
		Array.Copy(BitConverter.GetBytes((ushort)(num - 4)), 0, array3, 2 + 1, 2);
		num2 = 2 + 3;
		for (int k = 0; k < arrayList.Count; k++)
		{
			byte[] array4 = (byte[])arrayList[k];
			Array.Copy(array4, 0, array3, num2, array4.Length);
			num2 += array4.Length;
			if (k > 0)
			{
				array3[num2] = 16;
				num2++;
			}
		}
		array3[num2++] = 21;
		byte_0 = array3;
		enum126_0 = Enum126.const_5;
	}

	internal int method_5(int int_0)
	{
		return worksheetCollection_0.method_32().method_8(worksheetCollection_0.method_36(), int_0);
	}

	internal int method_6(string string_0)
	{
		int result = -1;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			if (string_0.ToUpper() == worksheetCollection_0[i].Name.ToUpper())
			{
				result = i;
				break;
			}
		}
		return result;
	}

	private ArrayList method_7(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			arrayList_0 = method_8(string_0);
			return arrayList_0;
		}
		return null;
	}

	[SpecialName]
	public int imethod_11()
	{
		if (arrayList_0 != null && !imethod_0())
		{
			return arrayList_0.Count;
		}
		switch (enum126_0)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid series values.");
		case Enum126.const_0:
			return 0;
		case Enum126.const_2:
			return 1;
		case Enum126.const_3:
		{
			int num6 = EndRow - StartRow + 1;
			if (num6 == 1)
			{
				return EndColumn - StartColumn + 1;
			}
			return num6;
		}
		case Enum126.const_4:
		{
			Range range = imethod_12();
			if (range == null)
			{
				return 0;
			}
			if (range.RowCount != 1)
			{
				return range.RowCount;
			}
			return range.ColumnCount;
		}
		case Enum126.const_5:
		{
			if (byte_0 == null)
			{
				return 0;
			}
			int num = 0;
			int num2 = 2;
			while (num2 < byte_0.Length)
			{
				switch (byte_0[num2])
				{
				default:
					num2++;
					break;
				case 41:
				case 73:
				case 105:
					num2 += 3;
					break;
				case 58:
				case 90:
				case 122:
					num++;
					num2 += 7;
					break;
				case 59:
				case 91:
				case 123:
				{
					int num3 = BitConverter.ToUInt16(byte_0, num2 + 3);
					int num4 = BitConverter.ToUInt16(byte_0, num2 + 5);
					byte b = byte_0[num2 + 7];
					byte b2 = byte_0[num2 + 9];
					if (num3 > num4)
					{
						int num5 = num3;
						num3 = num4;
						num4 = num5;
					}
					if (b > b2)
					{
						byte b3 = b;
						b = b2;
						b2 = b3;
					}
					num = ((num3 != num4) ? (num + (num4 - num3 + 1)) : (num + (b2 - b + 1)));
					num2 += 11;
					break;
				}
				case 60:
				case 92:
				case 124:
					num2 += 7;
					break;
				case 61:
				case 93:
				case 125:
					num2 += 11;
					break;
				}
			}
			return num;
		}
		case Enum126.const_1:
		case Enum126.const_6:
			if (arrayList_0 != null)
			{
				return arrayList_0.Count;
			}
			return 0;
		}
	}

	private ArrayList method_8(string string_0)
	{
		if (string_0[0] == '{')
		{
			if (string_0[string_0.Length - 1] == '}')
			{
				string text = string_0.Substring(1, string_0.Length - 2).Trim();
				if (text == "")
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid Chart data.");
				}
				ArrayList arrayList = new ArrayList();
				string[] array = text.Split(',');
				enum126_0 = Enum126.const_1;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].Trim();
					try
					{
						if (Class1677.smethod_19(array[i]))
						{
							double num = Class1618.smethod_85(array[i]);
							arrayList.Add(num);
							continue;
						}
						if (Class1673.smethod_8(array[i]))
						{
							arrayList.Add(array[i]);
							continue;
						}
						if (array[i].ToUpper() == "TRUE")
						{
							arrayList.Add(1.0);
							continue;
						}
						if (array[i].ToUpper() == "FALSE")
						{
							arrayList.Add(0.0);
							continue;
						}
						enum126_0 = Enum126.const_6;
						break;
					}
					catch (Exception)
					{
						throw new CellsException(ExceptionType.InvalidData, "Invalid Chart data.");
					}
				}
				if (enum126_0 == Enum126.const_6)
				{
					arrayList.Clear();
					for (int j = 0; j < array.Length; j++)
					{
						string text2 = array[j].Trim();
						if (text2 != null && text2 != "" && text2[0] == '"')
						{
							text2 = text2.Substring(1, text2.Length - 2).Trim();
						}
						arrayList.Add(text2);
					}
				}
				return arrayList;
			}
			throw new CellsException(ExceptionType.InvalidData, "Invalide Chart data format.");
		}
		if (string_0.IndexOf(',') != -1)
		{
			string[] array2 = Class922.smethod_4(string_0);
			if (array2.Length > 1)
			{
				method_4(array2);
				return null;
			}
		}
		if (string_0[0] == '(' && string_0[string_0.Length - 1] == ')')
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
		}
		byte_0 = method_10(string_0);
		if (enum126_0 != Enum126.const_4 && byte_0 != null)
		{
			enum126_0 = ((byte_0.Length == 9) ? Enum126.const_2 : Enum126.const_3);
		}
		return null;
	}

	private byte[] method_9(string string_0, string string_1)
	{
		Regex regex = new Regex(":");
		int num = 0;
		int[] array = Class1660.smethod_3(worksheetCollection_0, string_0);
		int num2 = array[0];
		num = array[1];
		Match match = regex.Match(string_1);
		int row = 0;
		int column = 0;
		byte[] array2 = null;
		int num3 = 0;
		if (match.Success)
		{
			enum126_0 = Enum126.const_3;
			array2 = new byte[13];
			array2[num3] = 11;
			num3 = 2;
			array2[2] = 59;
			string refString = string_1.Substring(0, match.Index).Trim();
			CellNameToIndex(refString, isInArea: true, out row, out column);
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array2, 2 + 3, 2);
			array2[2 + 7] = (byte)column;
			string refString2 = string_1.Substring(match.Index + 1).Trim();
			CellNameToIndex(refString2, isInArea: true, out row, out column);
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array2, 2 + 5, 2);
			array2[2 + 9] = (byte)column;
		}
		else if (CellNameToIndex(string_1, isInArea: false, out row, out column))
		{
			array2 = new byte[9];
			array2[num3] = 7;
			num3 = 2;
			array2[2] = 58;
			enum126_0 = Enum126.const_2;
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array2, 2 + 3, 2);
			array2[2 + 5] = (byte)column;
		}
		else
		{
			Class1718 @class = worksheetCollection_0.method_39()[num];
			int num4 = -1;
			for (int i = 0; i < @class.method_0().Count; i++)
			{
				Class1653 class2 = (Class1653)@class.method_0()[i];
				if (class2.Name.ToUpper() == string_1.ToUpper())
				{
					num4 = i;
					break;
				}
			}
			if (num4 == -1)
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula:");
			}
			array2 = new byte[9] { 7, 0, 0, 0, 0, 0, 0, 0, 0 };
			num3 = 2;
			array2[2] = 57;
			Array.Copy(BitConverter.GetBytes((ushort)num4 + 1), 0, array2, 2 + 3, 2);
			enum126_0 = Enum126.const_4;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, 3, 2);
		return array2;
	}

	private byte[] method_10(string string_0)
	{
		string_0 = ((string_0[0] != '=') ? string_0.ToUpper() : string_0.Substring(1).ToUpper());
		Regex regex = new Regex("!");
		Match match = regex.Match(string_0);
		int num = method_0();
		bool flag = false;
		if (match.Success)
		{
			flag = true;
			enum126_0 = Enum126.const_2;
			string text = string_0.Substring(0, match.Index).Trim();
			if (text[0] == '\'' && text[text.Length - 1] == '\'')
			{
				text = text.Substring(1, text.Length - 2);
				text = text.Replace("''", "'");
				if (text == null || text == "")
				{
					throw new CellsException(ExceptionType.SheetName, "Invalid worksheet name.");
				}
			}
			num = method_6(text);
			string_0 = string_0.Substring(match.Index + 1).Trim();
			if (num == -1)
			{
				return method_9(text, string_0);
			}
		}
		regex = new Regex(":");
		int num2 = method_5(num);
		Match match2 = regex.Match(string_0);
		int row = 0;
		int column = 0;
		byte[] array = null;
		int num3 = 0;
		if (match2.Success)
		{
			enum126_0 = Enum126.const_3;
			array = new byte[13]
			{
				11, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0
			};
			num3 = 2;
			array[2] = 59;
			string refString = string_0.Substring(0, match2.Index).Trim();
			CellNameToIndex(refString, isInArea: true, out row, out column);
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array, 2 + 3, 2);
			array[2 + 7] = (byte)column;
			string refString2 = string_0.Substring(match2.Index + 1).Trim();
			CellNameToIndex(refString2, isInArea: true, out row, out column);
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array, 2 + 5, 2);
			array[2 + 9] = (byte)column;
		}
		else if (string_0.ToUpper() == "#REF!")
		{
			array = new byte[9];
			array[num3] = 7;
			num3 = 2;
			array[2] = 60;
		}
		else if (CellNameToIndex(string_0, isInArea: false, out row, out column))
		{
			array = new byte[9];
			array[num3] = 7;
			num3 = 2;
			array[2] = 58;
			enum126_0 = Enum126.const_2;
			Array.Copy(BitConverter.GetBytes((ushort)row), 0, array, 2 + 3, 2);
			array[2 + 5] = (byte)column;
		}
		else
		{
			num = (flag ? num : (-1));
			int num4 = -1;
			if (flag)
			{
				num4 = worksheetCollection_0.Names.method_9(string_0, num);
			}
			else
			{
				num4 = worksheetCollection_0.Names.method_9(string_0, worksheet_0.Index);
				if (num4 == -1)
				{
					num4 = worksheetCollection_0.Names.method_9(string_0, -1);
				}
			}
			if (num4 == -1)
			{
				throw new CellsException(ExceptionType.Chart, "Invalid data source.");
			}
			Name name = worksheetCollection_0.Names[num4];
			if (!flag)
			{
				byte[] array2 = name.method_2();
				array = array2;
				if (array2 != null)
				{
					array = new byte[array2.Length];
					Array.Copy(array2, array, array2.Length);
				}
				return array;
			}
			array = new byte[9];
			array[num3] = 7;
			num3 = 2;
			array[2] = 57;
			Array.Copy(BitConverter.GetBytes((ushort)num4 + 1), 0, array, 2 + 3, 2);
			enum126_0 = Enum126.const_4;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 3, 2);
		return array;
	}

	private bool CellNameToIndex(string refString, bool isInArea, out int row, out int column)
	{
		bool isRowAbsolute = false;
		bool isColumnAbsolute = false;
		bool isRowOnly = false;
		bool isColumnOnly = false;
		return Class1263.CellNameToIndex(refString, out row, out column, isInArea, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
	}

	[SpecialName]
	public bool imethod_1()
	{
		if (byte_0 != null && byte_0.Length == 13)
		{
			return BitConverter.ToUInt16(byte_0, 2 + 3) != BitConverter.ToUInt16(byte_0, 2 + 5);
		}
		return false;
	}

	[SpecialName]
	public Range imethod_12()
	{
		if (enum126_0 != Enum126.const_4)
		{
			return null;
		}
		Name name = null;
		int num = 2;
		switch (byte_0[2])
		{
		case 35:
		case 67:
		case 99:
			name = worksheetCollection_0.Names[BitConverter.ToInt16(byte_0, num + 1) - 1];
			break;
		case 57:
		case 89:
		case 105:
		{
			int int_ = BitConverter.ToInt16(byte_0, num + 1);
			int num2 = worksheetCollection_0.method_32().method_15(worksheetCollection_0, int_);
			if (num2 != -1)
			{
				name = worksheetCollection_0.Names[BitConverter.ToInt16(byte_0, num + 3) - 1];
			}
			break;
		}
		}
		return name?.CreateRange();
	}

	[SpecialName]
	public Enum126 imethod_13()
	{
		return enum126_0;
	}

	[SpecialName]
	public void imethod_14(Enum126 enum126_1)
	{
		enum126_0 = enum126_1;
	}

	public void Copy(Interface45 interface45_0, int int_0, CopyOptions copyOptions_0)
	{
		Class1197 @class = null;
		@class = ((!(interface45_0 is Class1197)) ? ((Class1198)interface45_0).method_12() : ((Class1197)interface45_0));
		enum126_0 = @class.enum126_0;
		if (@class.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList(@class.arrayList_0.Count);
			for (int i = 0; i < @class.arrayList_0.Count; i++)
			{
				arrayList_0.Add(@class.arrayList_0[i]);
			}
		}
		if (@class.byte_0 != null)
		{
			int num = 0;
			byte_0 = new byte[@class.byte_0.Length];
			Array.Copy(@class.byte_0, 0, byte_0, 0, byte_0.Length);
			if (copyOptions_0.bool_0)
			{
				return;
			}
			bool flag = @class.worksheetCollection_0 == worksheetCollection_0;
			if (copyOptions_0.enum173_0 == Enum173.const_5 && flag)
			{
				return;
			}
			int num2 = worksheetCollection_0.method_32().method_10(worksheetCollection_0.method_36(), 65535, 65535);
			if (num2 == -1)
			{
				num2 = worksheetCollection_0.method_32().method_3((ushort)worksheetCollection_0.method_36(), ushort.MaxValue, ushort.MaxValue);
			}
			byte[] array = byte_0;
			int num3 = 2;
			while (num3 < array.Length)
			{
				switch (array[num3])
				{
				case 35:
				case 67:
				case 99:
				{
					int num4 = BitConverter.ToUInt16(byte_0, num3 + 1) - 1;
					if (copyOptions_0.hashtable_1[num4] != null)
					{
						num4 = (int)copyOptions_0.hashtable_1[num4];
						Array.Copy(BitConverter.GetBytes(num4 + 1), 0, array, num3 + 1, 2);
					}
					num3 += 5;
					break;
				}
				default:
					num3++;
					break;
				case 57:
				case 89:
				case 121:
				{
					num = BitConverter.ToUInt16(byte_0, num3 + 1);
					Class1246 class2 = @class.worksheetCollection_0.method_32()[num];
					if (copyOptions_0.hashtable_4[num] != null)
					{
						num = (int)copyOptions_0.hashtable_4[num];
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, num3 + 1, 2);
					}
					if (class2.ushort_0 == @class.worksheetCollection_0.method_36())
					{
						int num5 = BitConverter.ToUInt16(byte_0, num3 + 3) - 1;
						if (copyOptions_0.hashtable_1[num5] != null)
						{
							num5 = (int)copyOptions_0.hashtable_1[num5];
							Array.Copy(BitConverter.GetBytes(num5 + 1), 0, array, num3 + 3, 2);
						}
					}
					num3 += 7;
					break;
				}
				case 58:
				case 59:
				case 90:
				case 91:
				case 122:
				case 123:
				{
					num = BitConverter.ToUInt16(byte_0, num3 + 1);
					if (copyOptions_0.hashtable_4[num] == null)
					{
						if (!flag)
						{
							num = Class1377.smethod_0(num, @class.worksheetCollection_0, worksheetCollection_0, copyOptions_0.hashtable_4, copyOptions_0.hashtable_5);
							if (num == -1)
							{
								num = num2;
							}
							Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, num3 + 1, 2);
						}
					}
					else
					{
						num = (int)copyOptions_0.hashtable_4[num];
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, num3 + 1, 2);
					}
					byte b = array[num3];
					num3 = ((b == 58 || b == 90 || b == 122) ? (num3 + 7) : (num3 + 11));
					break;
				}
				case 60:
				case 92:
				case 124:
					num = method_1().method_2().method_32().method_2((ushort)method_1().method_2().method_36(), 65534, 65534);
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, num3 + 1, 2);
					num3 += 7;
					break;
				case 61:
				case 93:
				case 125:
					num = method_1().method_2().method_32().method_2((ushort)method_1().method_2().method_36(), 65534, 65534);
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, num3 + 1, 2);
					num3 += 11;
					break;
				case 41:
				case 73:
				case 105:
					num3 += 3;
					break;
				}
			}
		}
		else
		{
			byte_0 = null;
		}
	}

	public void RemoveExternalLinks()
	{
		if (byte_0 == null || !Class1674.smethod_12(byte_0, -1, -1, worksheetCollection_0))
		{
			return;
		}
		byte_0 = null;
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
			arrayList_0.Add(0.0);
			enum126_0 = Enum126.const_1;
			return;
		}
		switch (enum126_0)
		{
		case Enum126.const_0:
		case Enum126.const_2:
		case Enum126.const_3:
		case Enum126.const_4:
		case Enum126.const_5:
			foreach (object item in arrayList_0)
			{
				if (item != null && (item is string || item is bool))
				{
					enum126_0 = Enum126.const_6;
					return;
				}
			}
			enum126_0 = Enum126.const_1;
			break;
		case Enum126.const_1:
			break;
		}
	}

	internal Class1198 method_11()
	{
		Class1198 @class = new Class1198(worksheetCollection_0, worksheet_0);
		if (arrayList_0 != null)
		{
			@class.imethod_3(new ArrayList());
			@class.imethod_2().AddRange(arrayList_0);
		}
		if (byte_0 != null)
		{
			@class.imethod_5(Class1247.smethod_1(byte_0, -1, 0, 0, bool_0: false));
		}
		@class.imethod_14(enum126_0);
		return @class;
	}
}
