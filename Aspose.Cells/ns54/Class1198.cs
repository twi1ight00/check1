using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns12;
using ns16;
using ns2;
using ns51;
using ns53;
using ns7;

namespace ns54;

internal class Class1198 : Interface45
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
			int num = 4;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			Cells cells = null;
			while (num < byte_0.Length - 4)
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
							int k = area.StartRow;
							int l = area.StartColumn;
							int num9 = area.EndRow;
							int num10 = area.EndColumn;
							if (k > num9)
							{
								int num11 = k;
								k = num9;
								num9 = num11;
							}
							if (l > num10)
							{
								int num12 = l;
								l = num10;
								num10 = num12;
							}
							if (k == num9)
							{
								if (cells.GetRowHeight(k) != 0.0)
								{
									for (; l <= num10; l++)
									{
										if (cells.GetColumnWidth(l) != 0.0)
										{
											return true;
										}
									}
								}
							}
							else if (cells.GetColumnWidth(l) != 0.0)
							{
								for (; k <= num9; k++)
								{
									if (cells.GetRowHeight(k) != 0.0)
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
							int row = BitConverter.ToInt32(byte_0, num + 3);
							int column = Class1268.smethod_1(byte_0, num + 7);
							cells = worksheetCollection_0[num2].Cells;
							if (cells.GetRowHeight(row) != 0.0 && cells.GetColumnWidth(column) != 0.0)
							{
								return true;
							}
							num += 9;
						}
						else
						{
							num += 9;
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
							int i = BitConverter.ToInt32(byte_0, num + 3);
							int num5 = BitConverter.ToInt32(byte_0, num + 7);
							int j = Class1268.smethod_1(byte_0, num + 11);
							int num6 = Class1268.smethod_1(byte_0, num + 13);
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
							cells = worksheetCollection_0[num2].Cells;
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
							num += 15;
						}
						else
						{
							num += 15;
						}
						break;
					}
					return true;
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
				return BitConverter.ToInt32(byte_0, 4 + 3);
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
				int num = 4;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return Class1268.smethod_1(byte_0, num + 7);
				case Enum126.const_3:
					return Class1268.smethod_1(byte_0, num + 11);
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
				int num = 4;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return BitConverter.ToInt32(byte_0, num + 3);
				case Enum126.const_3:
					return BitConverter.ToInt32(byte_0, num + 7);
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
				int num = 4;
				switch (enum126_0)
				{
				case Enum126.const_2:
					return Class1268.smethod_1(byte_0, num + 7);
				case Enum126.const_3:
					return Class1268.smethod_1(byte_0, num + 13);
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

	internal Class1198(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, string string_0)
	{
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
		arrayList_0 = method_8(string_0);
	}

	internal Class1198(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1)
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
		int num = 4;
		Class1246 @class = null;
		int num2 = -1;
		while (num < byte_0.Length - 4)
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
					num += 9;
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
					num += 15;
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
			switch (byte_0[4])
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

	private int method_1(bool bool_0)
	{
		int num = 4;
		int num2 = 1;
		while (num < byte_0.Length - 4)
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
				num += 7;
				break;
			case 58:
			case 90:
			case 122:
				num += 9;
				break;
			case 59:
			case 91:
			case 123:
			{
				int num3 = BitConverter.ToInt32(byte_0, num + 3);
				int num4 = BitConverter.ToInt32(byte_0, num + 7);
				int num5 = Class1268.smethod_1(byte_0, num + 11);
				int num6 = Class1268.smethod_1(byte_0, num + 13);
				if (num3 > num4)
				{
					int num7 = num3;
					num3 = num4;
					num4 = num7;
				}
				if (num5 > num6)
				{
					int num8 = num5;
					num5 = num6;
					num6 = num8;
				}
				if (num3 != num4 && num5 != num6)
				{
					int num9 = 0;
					num9 = ((!bool_0) ? (num4 - num3 + 1) : (num6 - num5 + 1));
					if (num9 > num2)
					{
						num2 = num9;
					}
				}
				num += 15;
				break;
			}
			case 60:
			case 92:
			case 124:
				num += 9;
				break;
			case 61:
			case 93:
			case 125:
				num += 15;
				break;
			}
		}
		return num2;
	}

	internal ArrayList method_2(bool bool_0, ref int int_0)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 4;
		bool flag = false;
		bool[] array = new bool[int_0];
		for (int i = 0; i < int_0; i++)
		{
			arrayList.Add(new ArrayList());
		}
		while (num4 < byte_0.Length - 4)
		{
			switch (byte_0[num4])
			{
			default:
				num4++;
				break;
			case 41:
			case 73:
			case 105:
				num4 += 3;
				break;
			case 57:
			case 89:
			case 121:
				num4 += 7;
				break;
			case 58:
			case 90:
			case 122:
				num4 += 9;
				break;
			case 59:
			case 91:
			case 123:
			{
				num2 = BitConverter.ToUInt16(byte_0, num4 + 1);
				num = worksheetCollection_0.method_32().method_12(num2);
				num3 = worksheetCollection_0.method_32().method_13(num2);
				int num5 = BitConverter.ToInt32(byte_0, num4 + 3);
				int num6 = BitConverter.ToInt32(byte_0, num4 + 7);
				int num7 = Class1268.smethod_1(byte_0, num4 + 11);
				int num8 = Class1268.smethod_1(byte_0, num4 + 13);
				if (num5 > num6)
				{
					int num9 = num5;
					num5 = num6;
					num6 = num9;
				}
				if (num7 > num8)
				{
					int num10 = num7;
					num7 = num8;
					num8 = num10;
				}
				if (num == worksheetCollection_0.method_36())
				{
					if (num3 >= 0 && num3 < worksheetCollection_0.Count)
					{
						if (num7 != num8 && num5 != num6)
						{
							Cells cells = worksheetCollection_0[num3].Cells;
							if (num6 > cells.method_20(0))
							{
								num6 = cells.method_20(0);
							}
							Class1196 @class = null;
							if (bool_0)
							{
								for (int j = num5; j <= num6; j++)
								{
									for (int k = 0; k < int_0; k++)
									{
										@class = vmethod_0((ArrayList)arrayList[k], cells, j, num7 + k, bool_0: false);
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
								for (int l = num7; l <= num8; l++)
								{
									for (int m = 0; m < int_0; m++)
									{
										@class = vmethod_0((ArrayList)arrayList[m], cells, num5 + m, l, bool_0: false);
										if (!@class.bool_1)
										{
											array[m] = true;
											flag = true;
										}
									}
								}
							}
						}
						num4 += 15;
						break;
					}
					int_0 = 1;
					if (arrayList_0 != null && arrayList_0.Count != 0)
					{
						ArrayList arrayList2 = new ArrayList();
						{
							foreach (object item in arrayList_0)
							{
								arrayList2.Add(new Class1196(item, 0, null));
							}
							return arrayList2;
						}
					}
					return null;
				}
				if (arrayList_0 != null && arrayList_0.Count != 0)
				{
					int_0 = 1;
					ArrayList arrayList3 = new ArrayList();
					{
						foreach (object item2 in arrayList_0)
						{
							arrayList3.Add(new Class1196(item2, 0, null));
						}
						return arrayList3;
					}
				}
				int_0 = 1;
				ArrayList arrayList4 = new ArrayList();
				method_3(arrayList4, bool_0: false, num5, num7, num6, num8, num, num3);
				return arrayList4;
			}
			case 60:
			case 92:
			case 124:
				num4 += 9;
				break;
			case 61:
			case 93:
			case 125:
				num4 += 15;
				break;
			}
		}
		if (flag)
		{
			int num11 = 0;
			int num12 = 0;
			while (num12 < array.Length)
			{
				if (!array[num12])
				{
					arrayList.RemoveAt(num11--);
					int_0--;
				}
				num12++;
				num11++;
			}
			if (arrayList.Count == 1)
			{
				int_0 = 1;
				return (ArrayList)arrayList[0];
			}
			return arrayList;
		}
		int_0 = 1;
		return (ArrayList)arrayList[0];
	}

	public ArrayList imethod_7(bool bool_0, bool bool_1, ref int int_0)
	{
		if (bool_1 && arrayList_0 != null && arrayList_0.Count > 0)
		{
			return Class922.smethod_5(arrayList_0, bool_0, bool_1, ref int_0);
		}
		bool bool_2 = false;
		if (byte_0 != null)
		{
			int_0 = method_1(bool_0);
			if (int_0 > 1)
			{
				return method_2(bool_0, ref int_0);
			}
		}
		int_0 = 1;
		return imethod_8(bool_0: false, bool_1, ref bool_2);
	}

	private void method_3(ArrayList arrayList_1, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		Class1718 @class = worksheetCollection_0.method_39()[int_4];
		if (int_5 >= 0 && @class.method_4() != null && int_5 <= @class.method_4().Length)
		{
			Class1373 class2 = @class.method_10(int_5);
			class2?.method_1();
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
		int num = 4;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Cells cells = null;
		while (num < byte_0.Length - 4)
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
							for (int k = 0; k < array.Length; k++)
							{
								Array array2 = (Array)array.GetValue(k);
								if (array2 != null)
								{
									for (int l = 0; l < array2.Length; l++)
									{
										arrayList.Add(new Class1196(array2.GetValue(l), 0, null));
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
					int m = area.StartRow;
					int n = area.StartColumn;
					int num10 = area.EndRow;
					int num11 = area.EndColumn;
					if (m > num10)
					{
						int num12 = m;
						m = num10;
						num10 = num12;
					}
					if (n > num11)
					{
						int num13 = n;
						n = num11;
						num11 = num13;
					}
					if (m == num10)
					{
						for (; n <= num11; n++)
						{
							vmethod_0(arrayList, cells, m, n, bool_0);
						}
					}
					else
					{
						for (; m <= num10; m++)
						{
							vmethod_0(arrayList, cells, m, n, bool_0);
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
				int num14 = BitConverter.ToInt32(byte_0, num + 3);
				int num15 = Class1268.smethod_1(byte_0, num + 7);
				if (num3 != worksheetCollection_0.method_36())
				{
					method_3(arrayList, bool_0, num14, num15, num14, num15, num3, num4);
					num += 9;
				}
				else if (num4 >= 0 && num4 < worksheetCollection_0.Count)
				{
					cells = worksheetCollection_0[num4].Cells;
					vmethod_0(arrayList, cells, num14, num15, bool_0);
					num += 9;
				}
				else
				{
					bool_2 = true;
					arrayList.Add(new Class1196(0.0, 0, null));
					num += 9;
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
				int i = BitConverter.ToInt32(byte_0, num + 3);
				int num5 = BitConverter.ToInt32(byte_0, num + 7);
				int j = Class1268.smethod_1(byte_0, num + 11);
				int num6 = Class1268.smethod_1(byte_0, num + 13);
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
				if (num3 != worksheetCollection_0.method_36())
				{
					method_3(arrayList, bool_0, i, j, num5, num6, num3, num4);
					num += 15;
				}
				else if (num4 >= 0 && num4 < worksheetCollection_0.Count)
				{
					cells = worksheetCollection_0[num4].Cells;
					if (i == num5)
					{
						for (; j <= num6; j++)
						{
							vmethod_0(arrayList, cells, i, j, bool_0);
						}
					}
					else
					{
						int num9 = cells.method_20(0);
						for (; i <= num5; i++)
						{
							if (i > num9)
							{
								Style style = null;
								Class1196 @class = new Class1196();
								arrayList.Add(@class);
								if (cells.GetRowHeight(i) == 0.0 || cells.GetColumnWidth(j) == 0.0)
								{
									@class.bool_0 = false;
								}
								@class.bool_1 = true;
								@class.cellValueType_0 = CellValueType.IsNull;
								style = Class922.smethod_2(cells, i, j);
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
								vmethod_0(arrayList, cells, i, j, bool_0);
							}
						}
					}
					num += 15;
				}
				else
				{
					bool_2 = true;
					arrayList.Add(new Class1196(0.0, 0, null));
					num += 15;
				}
				break;
			}
			case 60:
			case 92:
			case 124:
				num += 9;
				break;
			case 61:
			case 93:
			case 125:
				num += 15;
				break;
			}
		}
		if (bool_2)
		{
			arrayList = new ArrayList();
			if (arrayList_0 != null)
			{
				Class922.smethod_1(arrayList_0, arrayList, bool_0);
				return arrayList;
			}
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
				@class.object_0 = method_4(cell);
			}
			else
			{
				@class.object_0 = method_4(cell);
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

	private object method_4(Cell cell_0)
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
			int int_ = BitConverter.ToUInt16(byte_0, 4 + 1);
			sheetIndex = worksheetCollection_0.method_32().method_13(int_);
			supbook = worksheetCollection_0.method_32().method_12(int_);
		}
	}

	private void method_5(string[] string_0)
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
			byte[] array = method_11(string_);
			byte[] array2 = new byte[array.Length - 8];
			Array.Copy(array, 4, array2, 0, array2.Length);
			arrayList.Add(array2);
			num += array2.Length;
		}
		byte[] array3 = new byte[num + 8];
		Array.Copy(BitConverter.GetBytes(num), 0, array3, 0, 4);
		int num2 = 4;
		array3[4] = 41;
		Array.Copy(BitConverter.GetBytes((ushort)(num - 4)), 0, array3, 4 + 1, 2);
		num2 = 4 + 3;
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

	internal int method_6(int int_0)
	{
		return worksheetCollection_0.method_32().method_8(worksheetCollection_0.method_36(), int_0);
	}

	internal int method_7(string string_0)
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

	private ArrayList method_8(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			arrayList_0 = method_9(string_0);
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
			int num9 = EndRow - StartRow + 1;
			if (num9 == 1)
			{
				return EndColumn - StartColumn + 1;
			}
			return num9;
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
			int num2 = 4;
			while (num2 < byte_0.Length - 4)
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
					num2 += 9;
					break;
				case 59:
				case 91:
				case 123:
				{
					int num3 = BitConverter.ToInt32(byte_0, num2 + 3);
					int num4 = BitConverter.ToInt32(byte_0, num2 + 7);
					int num5 = Class1268.smethod_1(byte_0, num2 + 11);
					int num6 = Class1268.smethod_1(byte_0, num2 + 13);
					if (num3 > num4)
					{
						int num7 = num3;
						num3 = num4;
						num4 = num7;
					}
					if (num5 > num6)
					{
						int num8 = num5;
						num5 = num6;
						num6 = num8;
					}
					num = ((num3 != num4) ? (num + (num4 - num3 + 1)) : (num + (num6 - num5 + 1)));
					num2 += 15;
					break;
				}
				case 60:
				case 92:
				case 124:
					num2 += 9;
					break;
				case 61:
				case 93:
				case 125:
					num2 += 15;
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

	private ArrayList method_9(string string_0)
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
				string[] array = Class1660.Split(text, ',');
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
				method_5(array2);
				return null;
			}
		}
		if (string_0[0] == '(' && string_0[string_0.Length - 1] == ')')
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
		}
		byte_0 = method_11(string_0);
		if (enum126_0 != Enum126.const_4 && byte_0 != null)
		{
			enum126_0 = ((byte_0.Length == 17) ? Enum126.const_2 : Enum126.const_3);
		}
		return null;
	}

	private byte[] method_10(string string_0, string string_1)
	{
		int num = 0;
		int num2 = 0;
		int[] array = Class1660.smethod_3(worksheetCollection_0, string_0);
		num2 = array[0];
		num = array[1];
		int num3 = string_1.IndexOf(':');
		int row = 0;
		int column = 0;
		byte[] array2 = null;
		int num4 = 0;
		if (num3 != -1)
		{
			enum126_0 = Enum126.const_3;
			array2 = new byte[23];
			array2[num4] = 15;
			num4 = 4;
			array2[4] = 59;
			string refString = string_1.Substring(0, num3).Trim();
			CellNameToIndex(refString, isInArea: true, out row, out column);
			Class1268.smethod_3(array2, 4 + 3, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array2, 4 + 11, column, 0, bool_0: true, bool_1: false);
			string refString2 = string_1.Substring(num3 + 1).Trim();
			CellNameToIndex(refString2, isInArea: true, out row, out column);
			Class1268.smethod_3(array2, 4 + 7, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array2, 4 + 13, column, 0, bool_0: true, bool_1: false);
		}
		else if (CellNameToIndex(string_1, isInArea: false, out row, out column))
		{
			array2 = new byte[17];
			array2[num4] = 9;
			num4 = 4;
			array2[4] = 58;
			enum126_0 = Enum126.const_2;
			Class1268.smethod_3(array2, 4 + 3, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array2, 4 + 7, column, 0, bool_0: true, bool_1: false);
		}
		else
		{
			Class1718 @class = worksheetCollection_0.method_39()[num];
			int num5 = -1;
			for (int i = 0; i < @class.method_0().Count; i++)
			{
				Class1653 class2 = (Class1653)@class.method_0()[i];
				if (class2.Name.ToUpper() == string_1.ToUpper())
				{
					num5 = i;
					break;
				}
			}
			if (num5 == -1)
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula:");
			}
			array2 = new byte[15]
			{
				7, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0
			};
			num4 = 4;
			array2[4] = 57;
			Array.Copy(BitConverter.GetBytes((ushort)num5 + 1), 0, array2, 4 + 3, 2);
			enum126_0 = Enum126.const_4;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, 5, 2);
		return array2;
	}

	private byte[] method_11(string string_0)
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
			num = method_7(text);
			string_0 = string_0.Substring(match.Index + 1).Trim();
			if (num == -1)
			{
				return method_10(text, string_0);
			}
		}
		regex = new Regex(":");
		int num2 = method_6(num);
		Match match2 = regex.Match(string_0);
		int row = 0;
		int column = 0;
		byte[] array = null;
		int num3 = 0;
		if (match2.Success)
		{
			enum126_0 = Enum126.const_3;
			array = new byte[23];
			array[0] = 15;
			num3 = 4;
			array[4] = 59;
			string refString = string_0.Substring(0, match2.Index).Trim();
			CellNameToIndex(refString, isInArea: true, out row, out column);
			Class1268.smethod_3(array, 4 + 3, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 4 + 11, column, 0, bool_0: true, bool_1: false);
			string refString2 = string_0.Substring(match2.Index + 1).Trim();
			CellNameToIndex(refString2, isInArea: true, out row, out column);
			Class1268.smethod_3(array, 4 + 7, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 4 + 13, column, 0, bool_0: true, bool_1: false);
		}
		else if (string_0.ToUpper() == "#REF!")
		{
			array = new byte[17];
			array[num3] = 9;
			num3 = 4;
			array[4] = 60;
		}
		else if (CellNameToIndex(string_0, isInArea: false, out row, out column))
		{
			array = new byte[17];
			array[num3] = 9;
			num3 = 4;
			array[4] = 58;
			enum126_0 = Enum126.const_2;
			Class1268.smethod_3(array, 4 + 3, row, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 4 + 7, column, 0, bool_0: true, bool_1: false);
		}
		else
		{
			num = (flag ? num : (-1));
			bool flag2 = false;
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
					flag2 = true;
					num2 = worksheetCollection_0.method_32().method_8(worksheetCollection_0.method_36(), 65535);
				}
			}
			if (num4 == -1)
			{
				throw new CellsException(ExceptionType.Chart, "Invalid data source.");
			}
			Name name = worksheetCollection_0.Names[num4];
			if (!flag && !flag2)
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
			array = new byte[15];
			array[num3] = 7;
			num3 = 4;
			array[4] = 57;
			Array.Copy(BitConverter.GetBytes((ushort)num4 + 1), 0, array, 4 + 3, 2);
			enum126_0 = Enum126.const_4;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 5, 2);
		return array;
	}

	private bool CellNameToIndex(string refString, bool isInArea, out int row, out int column)
	{
		bool isRowAbsolute = false;
		bool isColumnAbsolute = false;
		bool isRowOnly = false;
		bool isColumnOnly = false;
		return Class1272.CellNameToIndex(refString, out row, out column, isInArea, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
	}

	[SpecialName]
	public bool imethod_1()
	{
		if (byte_0 != null && byte_0.Length == 23)
		{
			return BitConverter.ToInt32(byte_0, 4 + 3) != BitConverter.ToInt32(byte_0, 4 + 7);
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
		int num = 4;
		switch (byte_0[4])
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
		Class1198 @class = null;
		@class = ((!(interface45_0 is Class1198)) ? ((Class1197)interface45_0).method_11() : ((Class1198)interface45_0));
		enum126_0 = @class.enum126_0;
		if (@class.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList(@class.arrayList_0.Count);
			arrayList_0.AddRange(@class.arrayList_0);
		}
		if (@class.byte_0 != null)
		{
			byte_0 = new byte[@class.byte_0.Length];
			Array.Copy(@class.byte_0, byte_0, byte_0.Length);
			if (copyOptions_0.bool_0)
			{
				return;
			}
			bool flag = @class.worksheetCollection_0 == worksheetCollection_0;
			if (copyOptions_0.enum173_0 == Enum173.const_5 && flag)
			{
				return;
			}
			int num = worksheetCollection_0.method_32().method_10(worksheetCollection_0.method_36(), 65535, 65535);
			if (num == -1)
			{
				num = worksheetCollection_0.method_32().method_3((ushort)worksheetCollection_0.method_36(), ushort.MaxValue, ushort.MaxValue);
			}
			byte[] array = byte_0;
			int num2 = 4;
			while (num2 < array.Length - 4)
			{
				switch (array[num2])
				{
				case 35:
				case 67:
				case 99:
				{
					int num4 = BitConverter.ToUInt16(byte_0, num2 + 1) - 1;
					if (copyOptions_0.hashtable_1[num4] != null)
					{
						num4 = (int)copyOptions_0.hashtable_1[num4];
						Array.Copy(BitConverter.GetBytes(num4 + 1), 0, array, num2 + 1, 2);
					}
					num2 += 5;
					break;
				}
				default:
					num2++;
					break;
				case 57:
				case 89:
				case 121:
				{
					int num3 = BitConverter.ToUInt16(byte_0, num2 + 1);
					Class1246 class2 = @class.worksheetCollection_0.method_32()[num3];
					if (copyOptions_0.hashtable_4[num3] != null)
					{
						num3 = (int)copyOptions_0.hashtable_4[num3];
						Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, num2 + 1, 2);
					}
					if (class2.ushort_0 == @class.worksheetCollection_0.method_36())
					{
						int num5 = BitConverter.ToUInt16(byte_0, num2 + 3) - 1;
						if (copyOptions_0.hashtable_1[num5] != null)
						{
							num5 = (int)copyOptions_0.hashtable_1[num5];
							Array.Copy(BitConverter.GetBytes(num5 + 1), 0, array, num2 + 3, 2);
						}
					}
					num2 += 7;
					break;
				}
				case 58:
				case 59:
				case 90:
				case 91:
				case 122:
				case 123:
				{
					int num3 = BitConverter.ToUInt16(byte_0, num2 + 1);
					if (copyOptions_0.hashtable_4[num3] == null)
					{
						if (!flag)
						{
							num3 = Class1377.smethod_0(num3, @class.worksheetCollection_0, worksheetCollection_0, copyOptions_0.hashtable_4, copyOptions_0.hashtable_5);
							if (num3 == -1)
							{
								num3 = num;
							}
							Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, num2 + 1, 2);
						}
					}
					else
					{
						num3 = (int)copyOptions_0.hashtable_4[num3];
						Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, num2 + 1, 2);
					}
					byte b = array[num2];
					num2 = ((b == 58 || b == 90 || b == 122) ? (num2 + 9) : (num2 + 15));
					break;
				}
				case 60:
				case 92:
				case 124:
					num2 += 9;
					break;
				case 61:
				case 93:
				case 125:
					num2 += 15;
					break;
				case 41:
				case 73:
				case 105:
					num2 += 3;
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

	internal Class1197 method_12()
	{
		Class1197 @class = new Class1197(worksheetCollection_0, worksheet_0);
		if (arrayList_0 != null)
		{
			@class.imethod_3(new ArrayList());
			@class.imethod_2().AddRange(arrayList_0);
		}
		if (byte_0 != null)
		{
			@class.imethod_5(Class1248.smethod_1(byte_0, -1));
		}
		@class.imethod_14(enum126_0);
		return @class;
	}
}
