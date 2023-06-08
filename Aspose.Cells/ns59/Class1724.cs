using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Cells;
using ns11;
using ns12;
using ns2;
using ns22;
using ns27;
using ns29;
using ns57;

namespace ns59;

internal class Class1724
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Cells cells_0;

	private Worksheet worksheet_0;

	private FileFormatType fileFormatType_0 = FileFormatType.Default;

	private ushort ushort_0;

	private ushort ushort_1;

	private byte[] byte_0;

	private byte[] byte_1;

	private LoadDataOption loadDataOption_0;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private Class1647 class1647_0;

	internal Class1724(Workbook workbook_1, LoadDataOption loadDataOption_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_0.Worksheets;
		worksheetCollection_0.Clear();
		byte_0 = new byte[2];
		loadDataOption_0 = loadDataOption_1;
	}

	private void method_0(Class1723 class1723_0)
	{
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 2057)
		{
			throw new Exception("Bad Workbook file format.");
		}
		ushort_1 = class1723_0.method_2(byte_0);
		byte_1 = new byte[ushort_1];
		class1723_0.method_1(byte_1);
		if (byte_1[1] != 6)
		{
			throw new Exception("Bad Workbook file format.");
		}
		fileFormatType_0 = FileFormatType.Default;
	}

	private void method_1(Class1723 class1723_0)
	{
		method_2(class1723_0);
		Class639 @class = new Class639();
		@class.method_3(byte_1);
		worksheetCollection_0.method_55().Add(@class);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		if (num > worksheetCollection_0.method_41())
		{
			worksheetCollection_0.method_42(num);
		}
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 1054)
			{
				break;
			}
			method_2(class1723_0);
			@class = new Class639();
			@class.method_3(byte_1);
			worksheetCollection_0.method_55().Add(@class);
			num = BitConverter.ToUInt16(byte_1, 0);
			if (num > worksheetCollection_0.method_41())
			{
				worksheetCollection_0.method_42(num);
			}
		}
		class1723_0.method_3(-2);
	}

	private int method_2(Class1723 class1723_0)
	{
		ushort_1 = class1723_0.method_2(byte_0);
		if (ushort_1 != 0)
		{
			byte_1 = new byte[ushort_1];
			class1723_0.method_1(byte_1);
			method_13(class1723_0);
		}
		else
		{
			byte_1 = null;
		}
		return ushort_1;
	}

	private void method_3(Class1723 class1723_0)
	{
		arrayList_0 = new ArrayList();
		method_2(class1723_0);
		arrayList_0.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 224)
			{
				break;
			}
			method_2(class1723_0);
			arrayList_0.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void CreateStyle(byte[] byte_2)
	{
		Style style = new Style(worksheetCollection_0);
		style.GetStyle(byte_2);
		worksheetCollection_0.method_58().method_0(style);
	}

	private void method_4(Class1723 class1723_0)
	{
		try
		{
			int index;
			if (byte_1[7] == 0)
			{
				byte[] array = new byte[2 * byte_1.Length - 16];
				for (int i = 0; i < byte_1.Length - 8; i++)
				{
					array[2 * i] = byte_1[8 + i];
				}
				string @string = Encoding.Unicode.GetString(array);
				index = worksheetCollection_0.method_38(@string);
				if (byte_1[5] == 0)
				{
					worksheetCollection_0[index].Type = SheetType.Worksheet;
				}
				else if (byte_1[5] == 2)
				{
					worksheetCollection_0[index].Type = SheetType.Chart;
				}
				else if (byte_1[5] == 6)
				{
					worksheetCollection_0[index].Type = SheetType.VB;
				}
				else
				{
					worksheetCollection_0[index].Type = SheetType.Other;
				}
			}
			else
			{
				string @string = Encoding.Unicode.GetString(byte_1, 8, byte_1.Length - 8);
				index = worksheetCollection_0.method_38(@string);
				if (byte_1[5] == 0)
				{
					worksheetCollection_0[index].Type = SheetType.Worksheet;
				}
				else if (byte_1[5] == 2)
				{
					worksheetCollection_0[index].Type = SheetType.Chart;
				}
				else
				{
					worksheetCollection_0[index].Type = SheetType.Other;
				}
			}
			worksheetCollection_0[index].method_27(byte_1[4]);
		}
		catch
		{
			throw new CellsException(ExceptionType.InvalidData, "Incalid sheet name info");
		}
	}

	private void method_5(Class1723 class1723_0)
	{
		ArrayList arrayList = new ArrayList();
		method_2(class1723_0);
		arrayList.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 60)
			{
				break;
			}
			method_2(class1723_0);
			arrayList.Add(byte_1);
		}
		class1723_0.method_3(-2);
		Class1729.smethod_0(arrayList, worksheetCollection_0);
	}

	private void method_6(Class1723 class1723_0)
	{
		method_0(class1723_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 252:
				method_5(class1723_0);
				break;
			case 224:
				method_3(class1723_0);
				break;
			case 146:
				method_41(class1723_0);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 1054:
				method_1(class1723_0);
				break;
			case 659:
				method_10(class1723_0);
				break;
			case 430:
				method_8(class1723_0);
				break;
			case 23:
				method_7(class1723_0);
				break;
			case 24:
				method_17(class1723_0);
				break;
			case 133:
				method_11(class1723_0);
				break;
			case 61:
				method_16(class1723_0);
				break;
			case 47:
				ushort_1 = class1723_0.method_2(byte_0);
				byte_1 = new byte[ushort_1];
				class1723_0.method_1(byte_1);
				if (byte_1[0] != 0 || byte_1[1] != 0)
				{
					if (byte_1[4] == 1)
					{
						byte[] array = new byte[16];
						byte[] array2 = new byte[16];
						byte[] array3 = new byte[16];
						Array.Copy(byte_1, 6, array, 0, 16);
						Array.Copy(byte_1, 22, array2, 0, 16);
						Array.Copy(byte_1, 38, array3, 0, 16);
						try
						{
							if (workbook_0.Settings.Password != null && !(workbook_0.Settings.Password == ""))
							{
								class1647_0 = new Class1647(workbook_0.Settings.Password, array, array2, array3);
							}
							else
							{
								class1647_0 = new Class1647("VelvetSweatshop", array, array2, array3);
							}
							worksheetCollection_0.method_29(class1647_0);
						}
						catch
						{
							if (workbook_0.Settings.Password != null && !(workbook_0.Settings.Password == ""))
							{
								throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
							}
							throw new CellsException(ExceptionType.IncorrectPassword, "Please provide password for the Workbook file.");
						}
						break;
					}
					throw new CellsException(ExceptionType.UnsupportedFeature, "Strong Workbook Encryption is not supported.");
				}
				throw new CellsException(ExceptionType.UnsupportedFeature, "BIFF7 Encryption is not supported.");
			case 49:
				method_14(class1723_0);
				break;
			case 10:
			{
				class1723_0.method_3(2);
				int num = ((worksheetCollection_0.method_72() * 8 + worksheetCollection_0.method_73()) / 8 + 1) * 8;
				double double_ = (double)(num - worksheetCollection_0.method_73()) / (double)worksheetCollection_0.method_72();
				for (int i = 0; i < worksheetCollection_0.Count; i++)
				{
					Cells cells = worksheetCollection_0[i].Cells;
					cells.method_8(double_);
				}
				Class1129.smethod_1();
				return;
			}
			}
		}
	}

	private void method_7(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		worksheetCollection_0.method_32().Clear();
		if (num * 6 + 2 > 8224)
		{
			int num2 = (byte_1.Length - 2) / 6;
			for (int i = 0; i < num2; i++)
			{
				ushort num3 = BitConverter.ToUInt16(byte_1, 6 * i + 2);
				ushort num4 = BitConverter.ToUInt16(byte_1, 6 * i + 4);
				ushort ushort_ = BitConverter.ToUInt16(byte_1, 6 * i + 6);
				worksheetCollection_0.method_32().method_3(num3, num4, ushort_);
			}
			while (true)
			{
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 60)
				{
					break;
				}
				method_2(class1723_0);
				num2 = byte_1.Length / 6;
				for (int j = 0; j < num2; j++)
				{
					ushort num5 = BitConverter.ToUInt16(byte_1, 6 * j);
					ushort num6 = BitConverter.ToUInt16(byte_1, 6 * j + 2);
					ushort ushort_2 = BitConverter.ToUInt16(byte_1, 6 * j + 4);
					worksheetCollection_0.method_32().method_3(num5, num6, ushort_2);
				}
			}
			class1723_0.method_3(-2);
		}
		else
		{
			for (int k = 0; k < num; k++)
			{
				ushort num7 = BitConverter.ToUInt16(byte_1, 6 * k + 2);
				ushort num8 = BitConverter.ToUInt16(byte_1, 6 * k + 4);
				ushort ushort_3 = BitConverter.ToUInt16(byte_1, 6 * k + 6);
				worksheetCollection_0.method_32().method_3(num7, num8, ushort_3);
			}
		}
	}

	private void method_8(Class1723 class1723_0)
	{
		method_2(class1723_0);
		if (worksheetCollection_0.method_39() == null)
		{
			worksheetCollection_0.method_40(new Class1303());
		}
		Class1718 @class = new Class1718();
		if (byte_1.Length == 4)
		{
			if (byte_1[2] == 1 && byte_1[3] == 4)
			{
				@class.Type = Enum194.const_1;
				worksheetCollection_0.method_37(worksheetCollection_0.method_39().Count);
			}
			else if (byte_1[0] == 1 && byte_1[2] == 1 && byte_1[3] == 58)
			{
				@class.Type = Enum194.const_2;
			}
		}
		else
		{
			int num = BitConverter.ToUInt16(byte_1, 0);
			@class.Type = ((num == 0) ? Enum194.const_3 : Enum194.const_0);
			int num2 = 2;
			int num3 = BitConverter.ToUInt16(byte_1, 2);
			if (byte_1[2 + 2] == 1)
			{
				@class.method_17(Encoding.Unicode.GetString(byte_1, num2 + 3, num3 * 2));
				num2 += 3 + num3 * 2;
			}
			else
			{
				@class.method_17(Encoding.ASCII.GetString(byte_1, num2 + 3, num3));
				num2 += 3 + num3;
			}
			if (num != 0)
			{
				string[] array = new string[num];
				for (int i = 0; i < num; i++)
				{
					num3 = BitConverter.ToUInt16(byte_1, num2);
					if (byte_1[num2 + 2] == 1)
					{
						array[i] = Encoding.Unicode.GetString(byte_1, num2 + 3, num3 * 2);
						num2 += 3 + num3 * 2;
					}
					else
					{
						array[i] = Encoding.ASCII.GetString(byte_1, num2 + 3, num3);
						num2 += 3 + num3;
					}
					if (num2 >= ushort_1 && i != num - 1)
					{
						ushort_0 = class1723_0.method_2(byte_0);
						if (ushort_0 != 60)
						{
							class1723_0.method_3(-2);
							break;
						}
						method_2(class1723_0);
						num2 = 0;
					}
				}
				@class.method_5(array);
			}
		}
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 35)
			{
				break;
			}
			method_2(class1723_0);
			Class1653 class2 = new Class1653(@class);
			class2.method_11(BitConverter.ToUInt16(byte_1, 0));
			class2.method_2(BitConverter.ToInt32(byte_1, 2));
			int num4 = 8;
			if (byte_1[7] == 0)
			{
				class2.Name = Encoding.ASCII.GetString(byte_1, 8, byte_1[6]);
				num4 += byte_1[6];
			}
			else
			{
				class2.Name = Encoding.Unicode.GetString(byte_1, 8, byte_1[6] * 2);
				num4 += byte_1[6] * 2;
			}
			if (byte_1.Length - num4 > 0)
			{
				byte[] array2 = new byte[byte_1.Length - num4];
				Array.Copy(byte_1, num4, array2, 0, array2.Length);
				class2.method_13(array2);
			}
			if (@class.Type == Enum194.const_3 && @class.method_0().Count == 0 && byte_1.Length == 9)
			{
				@class.Type = Enum194.const_4;
			}
			@class.method_0().Add(class2);
		}
		class1723_0.method_3(-2);
		worksheetCollection_0.method_39().Add(@class);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 89)
			{
				break;
			}
			method_9(class1723_0, @class);
		}
		class1723_0.method_3(-2);
	}

	private void method_9(Class1723 class1723_0, Class1718 class1718_0)
	{
		method_2(class1723_0);
		int num = BitConverter.ToUInt16(byte_1, 0);
		int int_ = BitConverter.ToUInt16(byte_1, 2);
		if (num == 0)
		{
			return;
		}
		Class1373 @class = class1718_0.method_9(int_);
		int num2 = 0;
		while (true)
		{
			if (num2 >= num)
			{
				return;
			}
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 90 && ushort_0 != 60)
			{
				break;
			}
			method_2(class1723_0);
			int num3 = byte_1[1];
			int num4 = byte_1[0];
			int int_2 = BitConverter.ToUInt16(byte_1, 2);
			Class1117 row = @class.GetRow(int_2);
			int num5 = 4;
			for (int i = num3; i <= num4; i++)
			{
				if (num5 >= byte_1.Length)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 60)
					{
						class1723_0.method_3(-2);
						break;
					}
					method_2(class1723_0);
					num5 = 0;
				}
				if (byte_1[num5] != 2 && num5 + 9 > byte_1.Length)
				{
					byte[] array = byte_1;
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 60)
					{
						class1723_0.method_3(-2);
						break;
					}
					method_2(class1723_0);
					byte[] array2 = byte_1;
					byte_1 = new byte[byte_1.Length + array.Length - num5];
					Array.Copy(array, num5, byte_1, 0, array.Length - num5);
					Array.Copy(array2, array.Length - num5, byte_1, 0, array2.Length);
					num5 = 0;
				}
				switch (byte_1[num5])
				{
				case 16:
					row.Add(i, Class1673.smethod_5(byte_1[num5 + 1]));
					num5 += 9;
					break;
				case 0:
					num5 += 9;
					break;
				case 1:
					row.Add(i, BitConverter.ToDouble(byte_1, num5 + 1));
					num5 += 9;
					break;
				case 2:
				{
					int num6 = BitConverter.ToUInt16(byte_1, num5 + 1);
					if (byte_1[num5 + 3] == 0)
					{
						row.Add(i, Encoding.ASCII.GetString(byte_1, num5 + 4, num6));
						num5 += 4 + num6;
					}
					else
					{
						row.Add(i, Encoding.Unicode.GetString(byte_1, num5 + 4, num6 * 2));
						num5 += 4 + num6 * 2;
					}
					break;
				}
				case 4:
					row.Add(i, byte_1[num5 + 1] == 1);
					num5 += 9;
					break;
				default:
					return;
				}
			}
			num2++;
		}
		class1723_0.method_3(-2);
	}

	private void method_10(Class1723 class1723_0)
	{
		method_2(class1723_0);
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 659)
			{
				break;
			}
			method_2(class1723_0);
			arrayList_1.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_11(Class1723 class1723_0)
	{
		for (int i = 0; i < arrayList_2.Count; i++)
		{
			byte[] byte_ = (byte[])arrayList_2[i];
			method_15(byte_);
		}
		arrayList_2 = null;
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			byte[] byte_2 = (byte[])arrayList_0[j];
			CreateStyle(byte_2);
		}
		if (arrayList_1 != null)
		{
			for (int k = 0; k < arrayList_1.Count; k++)
			{
				byte[] byte_3 = (byte[])arrayList_1[k];
				method_12(byte_3);
			}
		}
		worksheetCollection_0.method_74();
		arrayList_0 = null;
		ushort_1 = class1723_0.method_2(byte_0);
		byte_1 = new byte[ushort_1];
		class1723_0.method_1(byte_1);
		if (class1647_0 != null)
		{
			uint uint_ = (uint)(class1723_0.Position - byte_1.Length + 4);
			byte[] array = class1647_0.method_0(byte_1, 4, (ushort)(byte_1.Length - 4), uint_);
			Array.Copy(array, 0, byte_1, 4, array.Length);
		}
		method_4(class1723_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 133)
			{
				break;
			}
			ushort_1 = class1723_0.method_2(byte_0);
			byte_1 = new byte[ushort_1];
			class1723_0.method_1(byte_1);
			if (class1647_0 != null)
			{
				uint uint_2 = (uint)(class1723_0.Position - byte_1.Length + 4);
				byte[] array2 = class1647_0.method_0(byte_1, 4, (ushort)(byte_1.Length - 4), uint_2);
				Array.Copy(array2, 0, byte_1, 4, array2.Length);
			}
			method_4(class1723_0);
		}
		class1723_0.method_3(-2);
	}

	[Attribute0(true)]
	private void method_12(byte[] byte_2)
	{
		int num = BitConverter.ToUInt16(byte_2, 0);
		int num2 = num & 0x8000;
		num &= 0xFFF;
		string text = "";
		if (num2 == 0)
		{
			if (byte_2[2] == 0)
			{
				return;
			}
			if (byte_2[4] == 0)
			{
				byte[] array = new byte[2 * byte_2.Length - 10];
				for (int i = 0; i < byte_2.Length - 5; i++)
				{
					array[2 * i] = byte_2[i + 5];
				}
				text = Encoding.Unicode.GetString(array);
			}
			else
			{
				text = Encoding.Unicode.GetString(byte_2, 5, byte_2.Length - 5);
			}
		}
		else
		{
			switch (byte_2[2])
			{
			case 0:
				text = "Normal";
				break;
			case 1:
				text = "RowLevel_" + byte_2[3];
				break;
			case 2:
				text = "ColLevel_" + byte_2[3];
				break;
			case 3:
				text = "Comma";
				break;
			case 4:
				text = "Currency";
				break;
			case 5:
				text = "Percent";
				break;
			case 6:
				text = "Comma [0]";
				break;
			case 7:
				text = "Currency [0]";
				break;
			case 8:
				text = "Hyperlink";
				break;
			case 9:
				text = "Followed Hyperlink";
				break;
			}
		}
		if (text != null && text != "")
		{
			Style style = worksheetCollection_0.method_58()[num];
			worksheetCollection_0.Styles.Add(style);
			style.method_3(text);
		}
	}

	private void method_13(Class1723 class1723_0)
	{
		if (class1647_0 != null)
		{
			uint uint_ = (uint)(class1723_0.Position - byte_1.Length);
			byte_1 = class1647_0.method_0(byte_1, 0, (ushort)byte_1.Length, uint_);
		}
	}

	private void method_14(Class1723 class1723_0)
	{
		arrayList_2 = new ArrayList();
		method_2(class1723_0);
		arrayList_2.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 49)
			{
				break;
			}
			method_2(class1723_0);
			arrayList_2.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private void method_15(byte[] byte_2)
	{
		Font font = new Font(worksheetCollection_0, null, bool_0: false);
		font.method_28(byte_2);
		if (worksheetCollection_0.method_52().Count > 3)
		{
			font.method_22(worksheetCollection_0.method_52().Count + 1);
		}
		else
		{
			font.method_22(worksheetCollection_0.method_52().Count);
		}
		worksheetCollection_0.method_52().Add(font);
	}

	private void method_16(Class1723 class1723_0)
	{
		method_2(class1723_0);
		byte b = byte_1[8];
		if ((byte)(b & 8) == 0)
		{
			worksheetCollection_0.Workbook.Settings.IsHScrollBarVisible = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.IsHScrollBarVisible = true;
		}
		if ((byte)(b & 0x10) == 0)
		{
			worksheetCollection_0.Workbook.Settings.IsVScrollBarVisible = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.IsVScrollBarVisible = true;
		}
		if ((byte)(b & 0x20) == 0)
		{
			worksheetCollection_0.Workbook.Settings.ShowTabs = false;
		}
		else
		{
			worksheetCollection_0.Workbook.Settings.ShowTabs = true;
		}
		worksheetCollection_0.method_34(BitConverter.ToUInt16(byte_1, 10));
		worksheetCollection_0.FirstVisibleTab = BitConverter.ToUInt16(byte_1, 12);
	}

	private void method_17(Class1723 class1723_0)
	{
		method_2(class1723_0);
		method_18();
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 24)
			{
				break;
			}
			method_2(class1723_0);
			method_18();
		}
		class1723_0.method_3(-2);
	}

	private void method_18()
	{
		Name name = new Name(worksheetCollection_0);
		name.method_27(byte_1);
		worksheetCollection_0.Names.method_3(name, bool_0: false);
		string first;
		string second;
		switch (name.Text)
		{
		case "PRINT_TITLES":
			if (name.SheetIndex > 0 && !name.IsHidden)
			{
				Class1279.smethod_3(name, isPrintArea: false, out first, out second);
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleRows = first;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintTitleColumns = second;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.method_3(bool_14: false);
			}
			break;
		case "PRINT_AREA":
			if (name.SheetIndex > 0 && !name.IsHidden)
			{
				Class1279.smethod_3(name, isPrintArea: true, out first, out second);
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.PrintArea = first;
				worksheetCollection_0[name.SheetIndex - 1].PageSetup.method_30(bool_14: false);
			}
			break;
		}
	}

	private void method_19(Class1723 class1723_0)
	{
		method_2(class1723_0);
		byte_1[14] |= 2;
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		ushort int_2 = BitConverter.ToUInt16(byte_1, 2);
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		object object_ = null;
		if (byte_1[12] == byte.MaxValue && byte_1[13] == byte.MaxValue)
		{
			switch (byte_1[6])
			{
			default:
			{
				double num = BitConverter.ToDouble(byte_1, 6);
				object_ = ((num == 0.0) ? Class1391.object_2 : ((object)num));
				break;
			}
			case 1:
				object_ = ((byte_1[8] == 0) ? Class1391.object_1 : Class1391.object_0);
				break;
			case 2:
				object_ = Class1673.smethod_6(byte_1[8]);
				break;
			case 3:
				object_ = null;
				break;
			case 0:
				break;
			}
		}
		else
		{
			double num2 = BitConverter.ToDouble(byte_1, 6);
			object_ = ((num2 == 0.0) ? Class1391.object_2 : ((object)num2));
		}
		cell.method_65(object_);
		ushort_0 = class1723_0.method_2(byte_0);
		switch (ushort_0)
		{
		default:
			class1723_0.method_3(-2);
			break;
		case 545:
		case 1212:
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 519)
			{
				method_2(class1723_0);
				string @string = ((byte_1[2] != 0) ? Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3) : Encoding.ASCII.GetString(byte_1, 3, byte_1.Length - 3));
				cell.PutValue(@string);
			}
			else
			{
				class1723_0.method_3(-2);
			}
			break;
		case 519:
		{
			method_2(class1723_0);
			string @string;
			if (byte_1[2] == 0)
			{
				byte[] array = new byte[2 * byte_1.Length - 6];
				for (int i = 0; i < byte_1.Length - 3; i++)
				{
					array[2 * i] = byte_1[i + 3];
				}
				@string = Encoding.Unicode.GetString(array);
			}
			else
			{
				@string = Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3);
			}
			cell.PutValue(@string);
			break;
		}
		}
	}

	private void method_20(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		ushort int_2 = BitConverter.ToUInt16(byte_1, 2);
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		cell.SetFormula(byte_1, fileFormatType_0);
		ushort_0 = class1723_0.method_2(byte_0);
		switch (ushort_0)
		{
		default:
			class1723_0.method_3(-2);
			break;
		case 1212:
			method_22(cell, class1723_0);
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				class1723_0.method_3(-2);
				break;
			case 545:
				method_21(cell, class1723_0);
				break;
			case 519:
			{
				method_2(class1723_0);
				string @string = ((byte_1[2] != 0) ? Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3) : Class937.smethod_3(byte_1, 3, byte_1.Length - 3));
				cell.method_65(@string);
				break;
			}
			}
			break;
		case 545:
			method_21(cell, class1723_0);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 519)
			{
				method_2(class1723_0);
				string @string = ((byte_1[2] != 0) ? Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3) : Encoding.ASCII.GetString(byte_1, 3, byte_1.Length - 3));
				cell.method_65(@string);
			}
			else
			{
				class1723_0.method_3(-2);
			}
			break;
		case 519:
		{
			method_2(class1723_0);
			string @string;
			if (byte_1[2] == 0)
			{
				byte[] array = new byte[2 * byte_1.Length - 6];
				for (int i = 0; i < byte_1.Length - 3; i++)
				{
					array[2 * i] = byte_1[i + 3];
				}
				@string = Encoding.Unicode.GetString(array);
			}
			else
			{
				@string = Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3);
			}
			cell.method_65(@string);
			break;
		}
		}
	}

	private void method_21(Cell cell_0, Class1723 class1723_0)
	{
		method_2(class1723_0);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 0);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 2);
		cellArea_.StartColumn = byte_1[4];
		cellArea_.EndColumn = byte_1[5];
		byte[] array = new byte[ushort_1 - 12];
		Array.Copy(byte_1, 12, array, 0, array.Length);
		cell_0.method_51(new Class1348(cellArea_, bool_0: true, array));
		cell_0.method_17().method_8(bool_0: true);
	}

	private void method_22(Cell cell_0, Class1723 class1723_0)
	{
		method_2(class1723_0);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = BitConverter.ToUInt16(byte_1, 0);
		cellArea_.EndRow = BitConverter.ToUInt16(byte_1, 2);
		cellArea_.StartColumn = byte_1[4];
		cellArea_.EndColumn = byte_1[5];
		byte[] array = new byte[ushort_1 - 8];
		Array.Copy(byte_1, 8, array, 0, array.Length);
		cell_0.method_51(new Class1348(cellArea_, bool_0: false, array));
	}

	private void method_23(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		byte b = byte_1[6];
		if (byte_1[7] == 0)
		{
			Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
			cell.method_37(int_3);
			bool boolValue = ((b != 0) ? true : false);
			cell.PutValue(boolValue);
		}
		else
		{
			Cell cell2 = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
			cell2.method_37(int_3);
			cell2.method_65(Class1673.smethod_6(b));
		}
	}

	private void method_24(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
	}

	private void method_25(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte b = byte_1[2];
		for (int i = 0; i < byte_1.Length / 2 - 3; i++)
		{
			ushort int_2 = BitConverter.ToUInt16(byte_1, 4 + 2 * i);
			Cell cell = cells_0.Rows.GetCell(int_, b + i, bool_0: false, bool_1: false, bool_2: false);
			cell.method_37(int_2);
		}
	}

	private void method_26(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		double doubleValue = BitConverter.ToDouble(byte_1, 6);
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		cell.PutValue(doubleValue);
	}

	private void method_27(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		int num = BitConverter.ToInt32(byte_1, 6);
		double num2 = 0.0;
		if (((uint)num & 2u) != 0)
		{
			num2 = num >> 2;
		}
		else
		{
			int value = num - (num & 3);
			byte[] array = new byte[8];
			Array.Copy(BitConverter.GetBytes(value), 0, array, 4, 4);
			num2 = BitConverter.ToDouble(array, 0);
		}
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			num2 /= 100.0;
		}
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		cell.PutValue(num2);
	}

	private void method_28(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		ushort num = BitConverter.ToUInt16(byte_1, 2);
		int num2 = (ushort_1 - 6) / 6;
		for (int i = 0; i < num2; i++)
		{
			ushort int_2 = BitConverter.ToUInt16(byte_1, 4 + 6 * i);
			int num3 = BitConverter.ToInt32(byte_1, 6 + 6 * i);
			double num4 = 0.0;
			if (((uint)num3 & 2u) != 0)
			{
				num4 = num3 >> 2;
			}
			else
			{
				int value = num3 - (num3 & 3);
				byte[] array = new byte[8];
				Array.Copy(BitConverter.GetBytes(value), 0, array, 4, 4);
				num4 = BitConverter.ToDouble(array, 0);
			}
			if (((uint)num3 & (true ? 1u : 0u)) != 0)
			{
				num4 /= 100.0;
			}
			Cell cell = cells_0.Rows.GetCell(int_, num + i, bool_0: false, bool_1: false, bool_2: false);
			cell.method_37(int_2);
			cell.method_5(num4);
		}
	}

	private void method_29(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		byte int_2 = byte_1[2];
		ushort int_3 = BitConverter.ToUInt16(byte_1, 4);
		int int_4 = BitConverter.ToInt32(byte_1, 6);
		Cell cell = cells_0.Rows.GetCell(int_, int_2, bool_0: false, bool_1: false, bool_2: false);
		cell.method_37(int_3);
		cells_0.method_2().method_5(cell, int_4);
	}

	private void method_30(Class1723 class1723_0)
	{
		ushort_1 = class1723_0.method_2(byte_0);
		class1723_0.method_3(ushort_1);
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 93)
		{
			class1723_0.method_3(-2);
			return;
		}
		method_2(class1723_0);
		if (byte_1[4] != 5)
		{
			return;
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 2057)
		{
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
			return;
		}
		class1723_0.method_3(18);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			ushort num = ushort_0;
			if (num == 10)
			{
				break;
			}
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
		}
		class1723_0.method_3(2);
	}

	private void method_31(Class1723 class1723_0)
	{
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 10:
				class1723_0.method_3(2);
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			case 2057:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				num++;
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			}
		}
	}

	private void method_32(Class1723 class1723_0)
	{
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 520:
				method_33(class1723_0);
				break;
			case 513:
				method_24(class1723_0);
				break;
			case 515:
				method_26(class1723_0);
				break;
			case 517:
				method_23(class1723_0);
				break;
			case 253:
				method_29(class1723_0);
				break;
			case 574:
				method_37(class1723_0);
				break;
			case 549:
				method_34(class1723_0);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 6:
			case 1030:
				if (loadDataOption_0 != null && !loadDataOption_0.ImportFormula)
				{
					method_19(class1723_0);
				}
				else
				{
					method_20(class1723_0);
				}
				break;
			case 638:
				method_27(class1723_0);
				break;
			case 85:
				method_35(class1723_0);
				break;
			case 236:
				method_30(class1723_0);
				break;
			case 189:
				method_28(class1723_0);
				break;
			case 190:
				method_25(class1723_0);
				break;
			case 125:
				method_36(class1723_0);
				break;
			case 10:
				class1723_0.method_3(2);
				return;
			}
		}
	}

	private void method_33(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort int_ = BitConverter.ToUInt16(byte_1, 0);
		BitConverter.ToInt16(byte_1, 2);
		BitConverter.ToInt16(byte_1, 4);
		ushort num = (ushort)cells_0.method_0();
		if ((byte_1[7] & 0x80) == 0)
		{
			num = BitConverter.ToUInt16(byte_1, 6);
		}
		Row row = cells_0.Rows.GetRow(int_, bool_0: false, bool_1: false);
		row.method_12(num);
		uint num2 = BitConverter.ToUInt32(byte_1, 12);
		if ((num2 & 0xF0000000u) != 0)
		{
			num2 = ((num2 & 0xF0000000u) >> 16) | (num2 & 0xFFFFFFFu);
		}
		if ((num2 & 0x100) == 0)
		{
			num2 &= 0xFFFFFFF0u;
			num2 |= 0x100u;
		}
		if ((num2 & 0xFFF0000) == 0)
		{
			num2 |= 0xF0000u;
		}
		if (num <= 0)
		{
			num2 |= 0x20u;
		}
		row.method_9((int)num2);
		if (row.method_24() > cells_0.method_29())
		{
			cells_0.method_30(row.method_24());
		}
	}

	private void method_34(Class1723 class1723_0)
	{
		method_2(class1723_0);
		byte byte_ = byte_1[0];
		ushort num = BitConverter.ToUInt16(byte_1, 2);
		ushort num2 = class1723_0.method_2(byte_0);
		if (num2 != 128)
		{
			cells_0.method_24(byte_);
			cells_0.double_0 = (int)num;
		}
		class1723_0.method_3(-2);
	}

	private void method_35(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		if (num != 8)
		{
			int num2 = num * 8;
			double num3 = 0.0;
			num3 = ((num2 < 12) ? ((double)num2 / 12.0) : ((double)(num2 - 5) / 7.0));
			cells_0.method_8(num3);
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 512)
		{
			method_2(class1723_0);
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_36(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		ushort num2 = BitConverter.ToUInt16(byte_1, 2);
		for (int i = num; i <= num2 && i <= 255; i++)
		{
			Column column = cells_0.Columns[i];
			column.method_12(byte_1);
			if (column.method_3() > cells_0.method_27())
			{
				cells_0.method_28(column.method_3());
			}
		}
	}

	private void method_37(Class1723 class1723_0)
	{
		method_2(class1723_0);
		worksheet_0.method_10((ushort)(BitConverter.ToUInt16(byte_1, 0) & 0x3FFu));
		if ((byte_1[1] & 8u) != 0)
		{
			worksheet_0.ViewType = ViewType.PageBreakPreview;
		}
		worksheet_0.FirstVisibleRow = BitConverter.ToUInt16(byte_1, 2);
		worksheet_0.FirstVisibleColumn = byte_1[4] & 0xFF;
		worksheet_0.method_45(byte_1[6]);
		if (ushort_1 > 10)
		{
			int num = BitConverter.ToUInt16(byte_1, 10);
			if (num != 0)
			{
				worksheet_0.method_39()[1] = num;
			}
			num = BitConverter.ToUInt16(byte_1, 12);
			if (num != 0)
			{
				worksheet_0.method_39()[0] = num;
			}
		}
	}

	private void method_38(Class1723 class1723_0)
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			if (loadDataOption_0 != null)
			{
				bool flag = false;
				if (loadDataOption_0.SheetNames != null)
				{
					for (int j = 0; j < loadDataOption_0.SheetNames.Length; j++)
					{
						if (worksheetCollection_0[i].Name.ToUpper() == loadDataOption_0.SheetNames[j].ToUpper())
						{
							flag = true;
							break;
						}
					}
				}
				else if (loadDataOption_0.SheetIndexes != null)
				{
					for (int k = 0; k < loadDataOption_0.SheetIndexes.Length; k++)
					{
						if (i == loadDataOption_0.SheetIndexes[k])
						{
							flag = true;
							break;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					method_31(class1723_0);
					continue;
				}
			}
			worksheet_0 = worksheetCollection_0[i];
			cells_0 = worksheet_0.Cells;
			if (worksheet_0.Type == SheetType.Chart)
			{
				worksheet_0.Type = SheetType.Worksheet;
				for (ushort_0 = class1723_0.method_2(byte_0); ushort_0 != 10; ushort_0 = class1723_0.method_2(byte_0))
				{
					ushort_1 = class1723_0.method_2(byte_0);
					class1723_0.method_3(ushort_1);
				}
				class1723_0.method_3(2);
			}
			else
			{
				method_32(class1723_0);
			}
		}
	}

	internal void method_39(Class1317 class1317_0)
	{
		MemoryStream stream = class1317_0.method_9().GetStream("Workbook");
		if (stream == null)
		{
			stream = class1317_0.method_9().GetStream("WORKBOOK");
		}
		if (stream == null)
		{
			throw new CellsException(ExceptionType.FileFormat, "Invalid BIFF8 file.");
		}
		method_40(stream);
	}

	private void method_40(MemoryStream memoryStream_0)
	{
		Class1723 class1723_ = new Class1723(memoryStream_0);
		worksheetCollection_0.method_35();
		method_6(class1723_);
		if (loadDataOption_0.OnlyCreateWorksheet)
		{
			return;
		}
		int num = 0;
		if (worksheetCollection_0.method_39() != null && worksheetCollection_0.method_39().Count != 0)
		{
			for (int i = 0; i < worksheetCollection_0.method_39().Count; i++)
			{
				Class1718 @class = worksheetCollection_0.method_39()[i];
				if (@class.method_12())
				{
					num = i;
					break;
				}
			}
		}
		for (int j = 0; j < worksheetCollection_0.Count; j++)
		{
			worksheetCollection_0.method_32().method_2((ushort)num, (ushort)j, (ushort)j);
		}
		worksheetCollection_0.ExternalLinks.method_1(worksheetCollection_0.method_39());
		method_38(class1723_);
		worksheetCollection_0.class1301_0.Clear();
	}

	private void method_41(Class1723 class1723_0)
	{
		method_2(class1723_0);
		ushort num = BitConverter.ToUInt16(byte_1, 0);
		for (int i = 0; i < num; i++)
		{
			int int_ = BitConverter.ToInt32(byte_1, 4 * i + 2);
			worksheetCollection_0.method_24().SetColor(int_, i + 8);
		}
	}
}
