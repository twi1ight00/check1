using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns16;
using ns2;
using ns45;

namespace ns10;

internal class Class411
{
	private Class1218 class1218_0;

	private Workbook workbook_0;

	private Class746 class746_0;

	private Class1547 class1547_0;

	private Class1212 class1212_0;

	private Class1141 class1141_0;

	private Class1142 class1142_0;

	private Worksheet worksheet_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	internal Class411(Class1218 class1218_1, Class1547 class1547_1, string string_4, string string_5, Class746 class746_1, string string_6)
	{
		class1218_0 = class1218_1;
		class1547_0 = class1547_1;
		string_0 = string_4;
		class1142_0 = class1547_1.workbook_0.Worksheets.method_89();
		workbook_0 = class1547_1.workbook_0;
		string_1 = string_5;
		class746_0 = class746_1;
		string_2 = string_6;
	}

	[SpecialName]
	internal Class1141 method_0()
	{
		return class1141_0;
	}

	internal void Read(Class1212 class1212_1)
	{
		class1212_0 = class1212_1;
		class1141_0 = new Class1141(class1142_0);
		class1141_0.int_6 = Class1618.smethod_87(string_1);
		class1141_0.int_7 = class1142_0.Count;
		class1141_0.string_4 = string_2;
		class1142_0.method_1(class1141_0);
		if (class1141_0.int_6 > class1142_0.int_0)
		{
			class1142_0.int_0 = class1141_0.int_6;
		}
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 185:
				method_2();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 183:
				method_9();
				break;
			case 179:
				method_1();
				break;
			case 245:
				method_15();
				break;
			case 180:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_1()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		byte b = byte_0[3];
		if ((b & 1) == 1)
		{
			class1141_0.method_14(bool_2: true, 1);
		}
		else
		{
			class1141_0.method_14(bool_2: false, 1);
		}
		if ((b & 4u) != 0)
		{
			class1141_0.method_13(bool_2: true);
		}
		else
		{
			class1141_0.method_13(bool_2: false);
		}
		class1141_0.int_9 = BitConverter.ToInt32(byte_0, 4);
		class1141_0.int_4 = BitConverter.ToInt32(byte_0, 17);
		int num = 21;
		Class1217.smethod_5(byte_0, ref num);
		string_3 = Class1217.smethod_5(byte_0, ref num);
	}

	private void method_2()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		class1141_0.pivotTableSourceType_0 = Class1224.smethod_33(num);
		if (class1141_0.pivotTableSourceType_0 != PivotTableSourceType.ListDatabase && class1141_0.pivotTableSourceType_0 != PivotTableSourceType.Consilidation)
		{
			Class1562 @class = new Class1562();
			@class.string_1 = string_0;
			@class.string_0 = string_1;
			workbook_0.class1558_0.class1364_0.arrayList_1.Add(@class);
			class1141_0.bool_1 = true;
			return;
		}
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 187:
				method_8();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 207:
				method_3();
				break;
			case 186:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_3()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 209:
				method_6();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 215:
				method_4();
				break;
			case 208:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_4()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = BitConverter.ToInt32(byte_0, 0);
		class1141_0.int_0 = new int[num2][];
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 217:
				method_5(arrayList, num);
				num++;
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 216:
				if (arrayList.Count != 0)
				{
					class1141_0.class1139_0 = new Class1139[arrayList.Count];
					for (int i = 0; i < arrayList.Count; i++)
					{
						class1141_0.class1139_0[i] = (Class1139)arrayList[i];
					}
				}
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_5(ArrayList arrayList_0, int int_2)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		class1141_0.int_0[int_2] = new int[4];
		class1141_0.int_0[int_2][0] = BitConverter.ToInt32(byte_0, 0);
		class1141_0.int_0[int_2][1] = BitConverter.ToInt32(byte_0, 4);
		class1141_0.int_0[int_2][2] = BitConverter.ToInt32(byte_0, 8);
		class1141_0.int_0[int_2][3] = BitConverter.ToInt32(byte_0, 12);
		byte b = byte_0[16];
		bool flag = (b & 1) == 1;
		byte b2 = byte_0[18];
		bool flag2 = (b2 & 1) == 1;
		bool flag3 = (((b2 & 2u) != 0) ? true : false);
		string text = null;
		string text2 = null;
		string text3 = null;
		Class1139 @class = null;
		CellArea cellArea = default(CellArea);
		int num = 19;
		if (flag3)
		{
			text3 = Class1217.smethod_5(byte_0, ref num);
		}
		if (flag2)
		{
			Class1217.smethod_5(byte_0, ref num);
		}
		if (!flag)
		{
			cellArea = Class1217.smethod_1(byte_0, num);
		}
		else
		{
			text2 = Class1217.smethod_5(byte_0, ref num);
		}
		if (text2 == null && text3 != null)
		{
			worksheet_0 = workbook_0.Worksheets[text3];
			if (worksheet_0 == null)
			{
				Class1562 class2 = new Class1562();
				class2.string_1 = string_0;
				class2.string_0 = string_1;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class2);
				class1141_0.bool_1 = true;
				return;
			}
			Range range = new Range(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, worksheet_0.Cells);
			@class = new Class1139(string_2: (!Class1677.smethod_21(worksheet_0.Name)) ? (worksheet_0.Name + "!" + range.method_1()) : ("'" + worksheet_0.Name + "'!" + range.method_1()), class1141_1: class1141_0, worksheet_1: worksheet_0);
			@class.range_0 = range;
			@class.range_1 = range;
			arrayList_0.Add(@class);
			@class.worksheet_0.Name = text3;
			class1141_0.int_2 = (class1141_0.int_1 = range.ColumnCount);
			class1141_0.int_3 = range.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			int num2 = Math.Max(class1141_0.int_3, class1141_0.int_4);
			class1141_0.class1144_0 = new Class1144(class1141_0, num2, class1141_0.int_1);
			return;
		}
		bool flag4;
		if (!(flag4 = text3 == null))
		{
			worksheet_0 = workbook_0.Worksheets[text3];
			if (worksheet_0 == null)
			{
				Class1562 class3 = new Class1562();
				class3.string_1 = string_0;
				class3.string_0 = string_1;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class3);
				class1141_0.bool_1 = true;
				return;
			}
		}
		bool flag5 = false;
		int num3 = (flag4 ? (-1) : worksheet_0.Index);
		Name name = workbook_0.Worksheets.Names[text2, num3];
		Range range2 = null;
		if (name == null)
		{
			flag5 = true;
			name = workbook_0.Worksheets.Names[text2];
		}
		if (name != null)
		{
			if (flag5)
			{
				worksheet_0 = name.GetRange().Worksheet;
			}
			range2 = name.CreateRange();
			if (range2 == null)
			{
				Class1562 class4 = new Class1562();
				class4.string_1 = string_0;
				class4.string_0 = string_1;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class4);
				class1141_0.bool_1 = true;
				return;
			}
			if (!flag4)
			{
				if (Class1677.smethod_21(worksheet_0.Name))
				{
					_ = "'" + worksheet_0.Name + "'!" + range2.method_1();
				}
				else
				{
					_ = worksheet_0.Name + "!" + range2.method_1();
				}
			}
			Class1139 class5 = new Class1139(class1141_0, worksheet_0, text2);
			class5.range_0 = range2;
			class5.range_1 = range2;
			arrayList_0.Add(class5);
			class1141_0.int_2 = (class1141_0.int_1 = range2.ColumnCount);
			class1141_0.int_3 = range2.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			class1141_0.class1144_0 = new Class1144(class1141_0, class1141_0.int_3, class1141_0.int_1);
		}
		else
		{
			Class1562 class6 = new Class1562();
			class6.string_1 = string_0;
			class6.string_0 = string_1;
			workbook_0.class1558_0.class1364_0.arrayList_1.Add(class6);
			class1141_0.bool_1 = true;
		}
	}

	private void method_6()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		if (!class1141_0.bool_0)
		{
			class1141_0.string_0 = new string[num][];
		}
		else
		{
			class1141_0.string_0 = new string[1][];
		}
		int num2 = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 211:
				method_7(num2);
				num2++;
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 210:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_7(int int_2)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		string[] array = (class1141_0.string_0[int_2] = new string[num]);
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 213:
				byte_0 = class1218_0.method_0(class1212_0);
				array[num2] = Class1217.smethod_5(byte_0, ref num3);
				num2++;
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 212:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_8()
	{
		ArrayList arrayList = new ArrayList();
		Class1139 @class = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		int num = 3;
		byte_0 = class1218_0.method_0(class1212_0);
		bool flag = false;
		if ((byte_0[0] & 1) == 0)
		{
			text3 = Class1217.smethod_5(byte_0, ref num);
			Worksheet worksheet = ((text3 == null || text3 == "") ? worksheet_0 : workbook_0.Worksheets[text3]);
			if (worksheet == null)
			{
				return;
			}
			CellArea cellArea = Class1217.smethod_1(byte_0, num);
			Range range = new Range(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, worksheet.Cells);
			@class = new Class1139(string_2: (!Class1677.smethod_21(worksheet.Name)) ? (worksheet.Name + "!" + range.method_1()) : ("'" + worksheet.Name + "'!" + range.method_1()), class1141_1: class1141_0, worksheet_1: worksheet);
			@class.range_0 = range;
			@class.range_1 = range;
			arrayList.Add(@class);
			@class.worksheet_0.Name = text3;
			class1141_0.int_2 = (class1141_0.int_1 = range.ColumnCount);
			class1141_0.int_3 = range.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			int num2 = Math.Max(class1141_0.int_3, class1141_0.int_4);
			class1141_0.class1144_0 = new Class1144(class1141_0, num2, class1141_0.int_1);
		}
		else
		{
			if (flag)
			{
				text3 = Class1217.smethod_5(byte_0, ref num);
			}
			text2 = Class1217.smethod_5(byte_0, ref num);
			if (text2.StartsWith("="))
			{
				text2 = text2.Substring(1);
			}
			bool flag2 = text3 == null || text3 == "";
			bool flag3 = false;
			int num3 = (flag2 ? (-1) : worksheet_0.Index);
			Name name = workbook_0.Worksheets.Names[text2, num3];
			Range range2 = null;
			if (name == null)
			{
				flag3 = true;
				name = workbook_0.Worksheets.Names[text2];
			}
			if (name == null)
			{
				class1141_0.string_3 = text2;
				return;
			}
			if (flag3 && name.GetRange() != null)
			{
				worksheet_0 = name.GetRange().Worksheet;
			}
			range2 = name.CreateRange();
			if (range2 == null)
			{
				class1141_0.string_3 = text2;
				return;
			}
			string text4 = text2;
			if (!flag2)
			{
				text4 = ((!Class1677.smethod_21(worksheet_0.Name)) ? (worksheet_0.Name + "!" + range2.method_1()) : ("'" + worksheet_0.Name + "'!" + range2.method_1()));
			}
			Class1139 class2 = new Class1139(class1141_0, worksheet_0, text4);
			class2.range_0 = range2;
			class2.range_1 = range2;
			arrayList.Add(class2);
			class1141_0.int_2 = (class1141_0.int_1 = range2.ColumnCount);
			class1141_0.int_3 = range2.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
		}
		class1141_0.arrayList_2 = null;
		if (arrayList.Count != 0)
		{
			class1141_0.class1139_0 = new Class1139[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				class1141_0.class1139_0[i] = (Class1139)arrayList[i];
			}
		}
	}

	private void method_9()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		byte b = byte_0[1];
		bool flag = false;
		bool flag2 = (b & 1) == 1;
		Class1161 @class = new Class1161(class1141_0);
		@class.method_3(bool_2: false);
		if (class1141_0.arrayList_0 == null)
		{
			class1141_0.arrayList_0 = new ArrayList();
		}
		class1141_0.arrayList_0.Add(@class);
		int num = 20;
		@class.string_0 = Class1217.smethod_5(byte_0, ref num);
		if (flag)
		{
			Class1217.smethod_5(byte_0, ref num);
		}
		if (flag2)
		{
			@class.method_19(bool_2: true);
			int num2 = BitConverter.ToInt32(byte_0, num);
			if (num2 > 0)
			{
				@class.byte_0 = new byte[num2];
				Array.Copy(byte_0, num + 4, @class.byte_0, 0, num2);
				@class.arrayList_1 = new ArrayList();
			}
		}
		@class.arrayList_0 = new ArrayList();
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 219:
				method_10(@class);
				break;
			case 189:
				method_14(@class);
				break;
			case 184:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_10(Class1161 class1161_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		SxRng sxRng = (class1161_0.sxRng_0 = new SxRng(class1161_0));
		class1161_0.method_21(bool_2: true);
		sxRng.int_1 = BitConverter.ToInt32(byte_0, 0);
		sxRng.int_0 = BitConverter.ToInt32(byte_0, 4);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 225:
				method_12(sxRng);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 223:
				method_11(sxRng);
				break;
			case 221:
				method_13(sxRng);
				break;
			case 220:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_11(SxRng sxRng_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		sxRng_0.pivotGroupByType_0 = Class1224.smethod_36(byte_0[0]);
		sxRng_0.bool_0 = ((((uint)byte_0[1] & (true ? 1u : 0u)) != 0) ? true : false);
		sxRng_0.bool_1 = (((byte_0[1] & 2u) != 0) ? true : false);
		if (((byte_0[1] & 4u) != 0) ? true : false)
		{
			double doubleValue = BitConverter.ToDouble(byte_0, 2);
			double doubleValue2 = BitConverter.ToDouble(byte_0, 10);
			sxRng_0.dateTime_0 = CellsHelper.GetDateTimeFromDouble(doubleValue, date1904: false);
			sxRng_0.dateTime_1 = CellsHelper.GetDateTimeFromDouble(doubleValue2, date1904: false);
		}
		else
		{
			sxRng_0.double_0 = BitConverter.ToDouble(byte_0, 2);
			sxRng_0.double_1 = BitConverter.ToDouble(byte_0, 10);
		}
		sxRng_0.double_2 = BitConverter.ToDouble(byte_0, 18);
	}

	private void method_12(SxRng sxRng_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		sxRng_0.arrayList_1 = new ArrayList();
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 26:
				byte_0 = class1218_0.method_0(class1212_0);
				sxRng_0.arrayList_1.Add(BitConverter.ToInt32(byte_0, 0));
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 226:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_13(SxRng sxRng_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		sxRng_0.arrayList_0 = new ArrayList();
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 25:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				@class.object_0 = method_18(byte_0, 0);
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			case 24:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				int num4 = 0;
				@class.object_0 = Class1217.smethod_5(byte_0, ref num4);
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			case 23:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				switch (byte_0[0])
				{
				case 15:
					@class.object_0 = "#VALUE!";
					break;
				case 7:
					@class.object_0 = "#DIV/0!";
					break;
				case 0:
					@class.object_0 = "#NULL!";
					break;
				case 29:
					@class.object_0 = "#NAME?";
					break;
				case 23:
					@class.object_0 = "#REF!";
					break;
				case 42:
					@class.object_0 = "#N/A";
					break;
				case 36:
					@class.object_0 = "#NUM!";
					break;
				}
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			case 22:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				@class.object_0 = byte_0[0] != 0;
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			case 21:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				@class.object_0 = BitConverter.ToDouble(byte_0, 0);
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			case 20:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				Class1158 @class = new Class1158();
				@class.object_0 = null;
				sxRng_0.arrayList_0.Add(@class);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 191:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num = BitConverter.ToInt16(byte_0, 0);
				int num2 = BitConverter.ToInt32(byte_0, 2);
				int num3 = 6;
				switch (num)
				{
				case 32:
				{
					for (int l = 0; l < num2; l++)
					{
						Class1158 @class = new Class1158();
						@class.object_0 = method_18(byte_0, num3);
						sxRng_0.arrayList_0.Add(@class);
						num3 += 8;
					}
					break;
				}
				case 1:
				{
					for (int j = 0; j < num2; j++)
					{
						Class1158 @class = new Class1158();
						@class.object_0 = BitConverter.ToDouble(byte_0, num3);
						sxRng_0.arrayList_0.Add(@class);
						num3 += 8;
					}
					break;
				}
				case 2:
				{
					for (int k = 0; k < num2; k++)
					{
						Class1158 @class = new Class1158();
						@class.object_0 = Class1217.smethod_5(byte_0, ref num3);
						sxRng_0.arrayList_0.Add(@class);
					}
					break;
				}
				case 4:
				{
					for (int i = 0; i < num2; i++)
					{
						Class1158 @class = new Class1158();
						@class.object_0 = byte_0[num3] != 0;
						sxRng_0.arrayList_0.Add(@class);
						num3++;
					}
					break;
				}
				}
				break;
			}
			case 222:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_14(Class1161 class1161_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		short num = BitConverter.ToInt16(byte_0, 0);
		class1161_0.method_15((((uint)num & 4u) != 0) ? true : false);
		class1161_0.method_13((((uint)num & 8u) != 0) ? true : false);
		class1161_0.method_30((((uint)num & 0x10u) != 0) ? true : false);
		class1161_0.method_7((((uint)num & 0x40u) != 0) ? true : false);
		class1161_0.method_9((((uint)num & 0x80u) != 0) ? true : false);
		class1161_0.bool_1 = ((((uint)num & 0x200u) != 0) ? true : false);
		Class1158 @class = new Class1158();
		int num2 = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 31:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				num2 = 0;
				@class.object_0 = Class1217.smethod_5(byte_0, ref num2);
				int num5 = BitConverter.ToInt16(byte_0, 0);
				@class.bool_0 = ((((uint)num5 & 2u) != 0) ? true : false);
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 25:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				@class.object_0 = method_18(byte_0, 0);
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 24:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				num2 = 0;
				@class.object_0 = Class1217.smethod_5(byte_0, ref num2);
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 23:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				switch (byte_0[0])
				{
				case 15:
					@class.object_0 = "#VALUE!";
					break;
				case 7:
					@class.object_0 = "#DIV/0!";
					break;
				case 0:
					@class.object_0 = "#NULL!";
					break;
				case 29:
					@class.object_0 = "#NAME?";
					break;
				case 23:
					@class.object_0 = "#REF!";
					break;
				case 42:
					@class.object_0 = "#N/A";
					break;
				case 36:
					@class.object_0 = "#NUM!";
					break;
				}
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 22:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				@class.object_0 = byte_0[0] != 0;
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 21:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				@class.object_0 = BitConverter.ToDouble(byte_0, 0);
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 20:
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1158();
				@class.object_0 = null;
				class1161_0.arrayList_0.Add(@class);
				class1161_0.method_3(bool_2: true);
				break;
			case 191:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				short num3 = BitConverter.ToInt16(byte_0, 0);
				int num4 = BitConverter.ToInt32(byte_0, 2);
				num2 = 6;
				for (int i = 0; i < num4; i++)
				{
					@class = new Class1158();
					switch (num3)
					{
					case 16:
						switch (byte_0[num2])
						{
						case 15:
							@class.object_0 = "#VALUE!";
							break;
						case 7:
							@class.object_0 = "#DIV/0!";
							break;
						case 0:
							@class.object_0 = "#NULL!";
							break;
						case 29:
							@class.object_0 = "#NAME?";
							break;
						case 23:
							@class.object_0 = "#REF!";
							break;
						case 42:
							@class.object_0 = "#N/A";
							break;
						case 36:
							@class.object_0 = "#NUM!";
							break;
						}
						num2++;
						break;
					case 1:
						@class.object_0 = BitConverter.ToDouble(byte_0, num2);
						num2 += 8;
						break;
					case 2:
						@class.object_0 = Class1217.smethod_5(byte_0, ref num2);
						break;
					case 4:
						@class.object_0 = byte_0[num2] != 0;
						num2++;
						break;
					case 256:
						@class.object_0 = null;
						break;
					case 32:
						@class.object_0 = method_18(byte_0, num2);
						num2 += 8;
						break;
					}
					class1161_0.arrayList_0.Add(@class);
				}
				class1161_0.method_3(bool_2: true);
				break;
			}
			case 190:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_15()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1148 @class = new Class1148(class1141_0);
		if (class1141_0.class988_0 == null)
		{
			class1141_0.class988_0 = new Class988();
		}
		class1141_0.class988_0.Add(@class);
		@class.method_1(BitConverter.ToInt32(byte_0, 0));
		int num = 4;
		int num2 = BitConverter.ToInt32(byte_0, 4);
		if (num2 > 0)
		{
			@class.byte_0 = new byte[num2];
			Array.Copy(byte_0, num + 4, @class.byte_0, 0, num2);
			@class.SetFormula(@class.method_4());
		}
		Class1171 class1171_ = new Class1171();
		@class.class1171_0 = class1171_;
		method_16(@class.class1171_0);
	}

	private void method_16(Class1171 class1171_0)
	{
		Class1162 @class = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 251:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1162();
				class1171_0.arrayList_0.Add(@class);
				@class.method_2((ushort)BitConverter.ToInt32(byte_0, 0));
				int num = BitConverter.ToInt16(byte_0, 8);
				@class.bool_1 = ((((uint)num & (true ? 1u : 0u)) != 0) ? true : false);
				@class.bool_2 = ((((uint)num & 2u) != 0) ? true : false);
				@class.bool_3 = ((((uint)num & 4u) != 0) ? true : false);
				@class.bool_4 = ((((uint)num & 8u) != 0) ? true : false);
				@class.bool_5 = ((((uint)num & 0x10u) != 0) ? true : false);
				@class.bool_6 = ((((uint)num & 0x20u) != 0) ? true : false);
				@class.bool_7 = ((((uint)num & 0x40u) != 0) ? true : false);
				@class.bool_8 = ((((uint)num & 0x80u) != 0) ? true : false);
				@class.bool_9 = ((((uint)num & 0x100u) != 0) ? true : false);
				@class.bool_10 = ((((uint)num & 0x200u) != 0) ? true : false);
				@class.bool_11 = ((((uint)num & 0x400u) != 0) ? true : false);
				@class.bool_12 = ((((uint)num & 0x800u) != 0) ? true : false);
				@class.method_6((((uint)byte_0[10] & (true ? 1u : 0u)) != 0) ? true : false);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 247:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				class1171_0.byte_1 = byte_0[0];
				int num2 = BitConverter.ToInt32(byte_0, 4);
				class1171_0.method_13(byte_0[4]);
				class1171_0.method_1((((uint)num2 & 0x100u) != 0) ? true : false);
				class1171_0.method_3((((uint)num2 & 0x200u) != 0) ? true : false);
				class1171_0.method_5((((uint)num2 & 0x400u) != 0) ? true : false);
				class1171_0.method_7((((uint)num2 & 0x800u) != 0) ? true : false);
				class1171_0.method_9((((uint)num2 & 0x1000u) != 0) ? true : false);
				class1171_0.method_15((((uint)num2 & 0x2000u) != 0) ? true : false);
				class1171_0.method_17((((uint)num2 & 0x4000u) != 0) ? true : false);
				class1171_0.method_11((byte)(byte_0[6] & 0xFu));
				class1171_0.byte_0 = (byte)((uint)((byte_0[6] & 0xF0) >> 4 + byte_0[7]) & 0xFu);
				break;
			}
			case 382:
				byte_0 = class1218_0.method_0(class1212_0);
				if (@class.arrayList_0 == null)
				{
					@class.arrayList_0 = new ArrayList();
				}
				@class.arrayList_0.Add(BitConverter.ToInt32(byte_0, 0));
				break;
			case 248:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	internal void method_17()
	{
		Hashtable hashtable = class1547_0.method_6();
		if (hashtable != null && string_3 != null)
		{
			if (!hashtable.ContainsKey(string_3))
			{
				throw new CellsException(ExceptionType.InvalidData, "pivotCacheRecord rid " + int_0 + " not found in pivotCache rels file");
			}
			Class1564 @class = (Class1564)hashtable[string_3];
			Class412 class2 = new Class412(class1218_0, class1547_0, class1141_0, @class.string_3, class746_0);
			string text = "xl/pivotCache/" + Path.GetFileName(@class.string_3);
			class2.Read(Class1218.smethod_1(class746_0, text));
		}
	}

	private DateTime method_18(byte[] byte_1, int int_2)
	{
		int year = BitConverter.ToUInt16(byte_0, int_2);
		int month = BitConverter.ToUInt16(byte_0, 2 + int_2);
		byte b = byte_0[4 + int_2];
		DateTime dateTime = new DateTime(1900, 1, 1);
		return (b != 0) ? new DateTime(year, month, byte_0[4 + int_2], byte_0[5 + int_2], byte_0[6 + int_2], byte_0[7 + int_2]) : new DateTime(year, month, 1);
	}
}
