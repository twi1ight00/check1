using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Cells;
using ns12;
using ns16;
using ns2;
using ns22;
using ns29;

namespace ns10;

internal class Class1225
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private int int_0;

	private int int_1;

	private byte[] byte_0;

	private Class1218 class1218_0;

	private Class1212 class1212_0;

	private Class746 class746_0;

	internal Class1225(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		worksheetCollection_0 = workbook_0.Worksheets;
	}

	internal void Read(Class1212 class1212_1, Class746 class746_1)
	{
		class746_0 = class746_1;
		class1212_0 = class1212_1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 353:
				method_4();
				continue;
			case 153:
				method_6();
				continue;
			case 549:
				method_2();
				continue;
			case 534:
				method_0();
				continue;
			case 386:
				method_1();
				continue;
			case 39:
				method_3();
				continue;
			case 143:
				method_8();
				continue;
			case 135:
				method_7();
				continue;
			case 132:
				class1212_0.Seek(1L);
				return;
			}
			int_1 = class1212_0.method_1();
			if (int_1 != 0)
			{
				class1212_0.Seek(int_1);
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		WorksheetCollection worksheets = workbook_0.Worksheets;
		worksheets.method_82(BitConverter.ToUInt16(byte_0, 0));
		bool bool_ = ((((uint)byte_0[4] & (true ? 1u : 0u)) != 0) ? true : false);
		bool bool_2 = (((byte_0[4] & 2u) != 0) ? true : false);
		worksheets.method_80(bool_);
		worksheets.method_78(bool_2);
	}

	private void method_1()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1562 @class = new Class1562();
		int num = BitConverter.ToInt32(byte_0, 0);
		@class.string_0 = Class1618.smethod_80(num);
		int num2 = 4;
		string text = Class1217.smethod_5(byte_0, ref num2);
		Hashtable hashtable = class1218_0.class1547_0.method_3();
		if (!hashtable.ContainsKey(text))
		{
			throw new CellsException(ExceptionType.InvalidData, "pivotCache rid " + text + " not found in workbook rels file");
		}
		@class.string_2 = text;
		class1218_0.class1547_0.arrayList_0.Add(@class);
	}

	private void method_2()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		worksheetCollection_0.OleSize = Class1217.smethod_1(byte_0, 0);
	}

	private void method_3()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Name name = new Name(worksheetCollection_0);
		name.method_1((ushort)BitConverter.ToInt32(byte_0, 0));
		name.method_13(byte_0[4]);
		name.SheetIndex = BitConverter.ToInt32(byte_0, 5) + 1;
		int num = 9;
		if (name.Type == Enum184.const_0)
		{
			name.method_15(Class1217.smethod_5(byte_0, ref num));
		}
		else
		{
			name.method_17(Class1217.smethod_5(byte_0, ref num));
		}
		byte[] array = new byte[byte_0.Length - num];
		Array.Copy(byte_0, num, array, 0, array.Length);
		int num2 = BitConverter.ToInt32(byte_0, num);
		int num3 = BitConverter.ToInt32(byte_0, num + 4 + num2);
		name.method_3(new byte[num2 + 8 + num3]);
		Array.Copy(byte_0, num, name.method_2(), 0, num2 + 8 + num3);
		num += num2 + 8 + num3;
		name.Comment = Class1217.smethod_5(byte_0, ref num);
		if (name.method_21() && !name.method_20())
		{
			name.method_5(Class1217.smethod_5(byte_0, ref num));
			name.method_7(Class1217.smethod_5(byte_0, ref num));
			name.method_9(Class1217.smethod_5(byte_0, ref num));
			name.method_11(Class1217.smethod_5(byte_0, ref num));
		}
		worksheetCollection_0.Names.method_3(name, bool_0: false);
		if (name.Type != 0)
		{
			return;
		}
		string first;
		string second;
		switch (name.Text)
		{
		case "PRINT_TITLES":
			if (name.SheetIndex > 0 && !name.IsHidden)
			{
				PageSetup pageSetup2 = worksheetCollection_0[name.SheetIndex - 1].PageSetup;
				Class1279.smethod_3(name, isPrintArea: false, out first, out second);
				pageSetup2.PrintTitleRows = first;
				pageSetup2.PrintTitleColumns = second;
				pageSetup2.method_3(bool_14: false);
			}
			break;
		case "PRINT_AREA":
			if (name.SheetIndex > 0 && !name.IsHidden)
			{
				PageSetup pageSetup = worksheetCollection_0[name.SheetIndex - 1].PageSetup;
				Class1279.smethod_3(name, isPrintArea: true, out first, out second);
				pageSetup.PrintArea = first;
				pageSetup.method_30(bool_14: false);
			}
			break;
		}
	}

	private void method_4()
	{
		class1212_0.Seek(1L);
		Class1303 @class = new Class1303();
		workbook_0.Worksheets.method_40(@class);
		Class1718 class2 = null;
		bool flag = false;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 362:
				method_5();
				break;
			case 361:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string name = Class1217.smethod_8(byte_0, 0);
				Class1653 class5 = new Class1653(class2);
				class5.Name = name;
				class2.method_0().Add(class5);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 358:
				class1212_0.Seek(1L);
				class2 = new Class1718(Enum194.const_5);
				@class.Add(class2);
				break;
			case 357:
				class1212_0.Seek(1L);
				flag = true;
				class2 = new Class1718(Enum194.const_1);
				@class.Add(class2);
				worksheetCollection_0.method_37(@class.Count - 1);
				break;
			case 355:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string key = Class1217.smethod_8(byte_0, 0);
				Class1564 class3 = (Class1564)class1218_0.class1547_0.method_4()[key];
				Hashtable hashtable_ = null;
				string fileName = Path.GetFileName(class3.string_3);
				string text = "xl/externalLinks/_rels/" + fileName + ".rels";
				if (class746_0.method_40(text, bool_18: false) != -1)
				{
					XmlTextReader xmlTextReader = Class1218.smethod_0(class746_0, text);
					hashtable_ = Class1608.Read(xmlTextReader);
					xmlTextReader.Close();
				}
				string string_ = "xl/" + class3.string_3;
				class2 = new Class1718(Enum194.const_0);
				Class1210 class4 = new Class1210(class1218_0, class2);
				class4.Read(Class1218.smethod_1(class746_0, string_), hashtable_);
				@class.Add(class2);
				break;
			}
			case 667:
				class1212_0.Seek(1L);
				class2 = new Class1718(Enum194.const_2);
				@class.Add(class2);
				break;
			case 354:
				class1212_0.Seek(1L);
				if (!flag)
				{
					class2 = new Class1718(Enum194.const_1);
					@class.Add(class2);
					worksheetCollection_0.method_37(@class.Count - 1);
				}
				return;
			}
		}
	}

	[Attribute0(true)]
	private void method_5()
	{
		worksheetCollection_0.method_32().Clear();
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		for (int i = 0; i < num; i++)
		{
			int num2 = BitConverter.ToInt32(byte_0, 4 + i * 12);
			int num3 = BitConverter.ToInt32(byte_0, 8 + i * 12);
			int num4 = BitConverter.ToInt32(byte_0, 12 + i * 12);
			worksheetCollection_0.method_32().method_3((ushort)num2, (ushort)num3, (ushort)num4);
		}
	}

	internal void method_6()
	{
		Class1364 class1364_ = workbook_0.class1558_0.class1364_0;
		byte_0 = class1218_0.method_0(class1212_0);
		if (((uint)byte_0[0] & (true ? 1u : 0u)) != 0)
		{
			workbook_0.Settings.Date1904 = true;
		}
		class1364_.string_1 = ((byte_0[0] & 8) >> 3).ToString();
		class1364_.string_3 = ((BitConverter.ToInt16(byte_0, 0) & 0x180) >> 7).ToString();
		class1364_.string_2 = ((byte_0[1] & 4) >> 2).ToString();
		class1364_.string_4 = ((byte_0[1] & 8) >> 3).ToString();
		class1364_.string_0 = BitConverter.ToInt32(byte_0, 4).ToString();
		int num = 8;
		string text = Class1217.smethod_5(byte_0, ref num);
		if (text.Length > 0)
		{
			workbook_0.Worksheets.method_17(text);
		}
	}

	internal void method_7()
	{
		class1212_0.Seek(1L);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 158:
				break;
			default:
				throw new CellsException(ExceptionType.InvalidData, "Invalid workbook setting in the xlsb workbook.");
			case 136:
				class1212_0.Seek(1L);
				return;
			}
			byte_0 = class1218_0.method_0(class1212_0);
			worksheetCollection_0.Workbook.Settings.method_13(BitConverter.ToInt32(byte_0, 0));
			worksheetCollection_0.Workbook.Settings.method_15(BitConverter.ToInt32(byte_0, 4));
			worksheetCollection_0.Workbook.Settings.method_17(BitConverter.ToInt32(byte_0, 8));
			worksheetCollection_0.Workbook.Settings.method_19(BitConverter.ToInt32(byte_0, 12));
			worksheetCollection_0.Workbook.Settings.SheetTabBarWidth = BitConverter.ToInt32(byte_0, 16);
			worksheetCollection_0.FirstVisibleTab = BitConverter.ToInt32(byte_0, 20);
			worksheetCollection_0.method_33(BitConverter.ToInt32(byte_0, 24));
			worksheetCollection_0.Workbook.Settings.IsHidden = (byte_0[28] & 1) != 0;
			worksheetCollection_0.Workbook.Settings.IsMinimized = (byte_0[28] & 4) != 0;
			worksheetCollection_0.Workbook.Settings.IsHScrollBarVisible = (byte_0[28] & 8) != 0;
			worksheetCollection_0.Workbook.Settings.IsVScrollBarVisible = (byte_0[28] & 0x10) != 0;
			worksheetCollection_0.Workbook.Settings.ShowTabs = (byte_0[28] & 0x20) != 0;
		}
	}

	internal void method_8()
	{
		class1212_0.Seek(1L);
		Class1129.smethod_1();
		workbook_0.Worksheets.Clear();
		int num = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			int num3;
			string string_;
			Worksheet worksheet;
			switch (int_0)
			{
			case 156:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num2 = 4;
				num3 = BitConverter.ToInt32(byte_0, 4);
				num2 = 4 + 4;
				string_ = Class1217.smethod_5(byte_0, ref num2);
				string sheetName = Class1217.smethod_5(byte_0, ref num2);
				worksheet = workbook_0.Worksheets.Add(sheetName);
				worksheet.class1557_0 = new Class1557(worksheet);
				if (byte_0[0] == 1)
				{
					worksheet.method_28(bool_1: false, bool_2: false);
				}
				else if (byte_0[0] == 2)
				{
					worksheet.method_28(bool_1: false, bool_2: true);
				}
				break;
			}
			default:
				throw new CellsException(ExceptionType.InvalidData, "Invalid workbook setting in the xlsb workbook.");
			case 144:
				class1212_0.Seek(1L);
				return;
			}
			Class1547 class1547_ = null;
			Class1548 @class = new Class1548(class1547_, worksheet);
			@class.worksheet_0 = worksheet;
			@class.int_0 = num;
			@class.string_0 = num3.ToString();
			@class.string_1 = string_;
			class1218_0.class1547_0.method_8().Add(num, @class);
			num++;
		}
	}
}
