using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns16;
using ns2;
using ns27;
using ns55;

namespace ns10;

internal class Class1220
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Class1212 class1212_0;

	private Class1218 class1218_0;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private ArrayList arrayList_4;

	private ArrayList arrayList_5;

	private int int_0;

	private int int_1;

	private byte[] byte_0;

	private Class1547 class1547_0;

	internal Class1220(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		worksheetCollection_0 = workbook_0.Worksheets;
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		arrayList_5 = new ArrayList();
		arrayList_3 = new ArrayList();
		arrayList_4 = new ArrayList();
		arrayList_2 = new ArrayList();
		class1547_0 = class1218_1.class1547_0;
	}

	internal void Read(Class1212 class1212_1)
	{
		class1212_0 = class1212_1;
		method_15();
		class1212_0.Position = 0;
		ArrayList arrayList_ = null;
		bool bool_ = false;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 626:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				arrayList_ = arrayList_3;
				bool_ = false;
				break;
			case 617:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				arrayList_ = arrayList_4;
				bool_ = true;
				break;
			case 507:
				method_6();
				break;
			case 508:
				method_3();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 510:
				method_4();
				break;
			case 43:
				method_13();
				break;
			case 44:
				method_14();
				break;
			case 45:
				method_12();
				break;
			case 46:
				method_10();
				break;
			case 47:
				method_7(arrayList_, bool_);
				break;
			case 48:
				method_9();
				break;
			case 279:
				class1212_0.Seek(1L);
				method_0();
				return;
			}
		}
	}

	internal void method_0()
	{
		class1547_0.method_10(new Hashtable());
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Aspose.Cells.Font font = (Aspose.Cells.Font)arrayList_0[i];
			worksheetCollection_0.method_63(font);
			class1547_0.method_9().Add(i, font.method_21());
		}
		Class1683 @class = worksheetCollection_0.method_58();
		Hashtable hashtable = new Hashtable(arrayList_3.Count);
		for (int j = 0; j < arrayList_3.Count; j++)
		{
			Class1206 class1206_ = (Class1206)arrayList_3[j];
			Style style = new Style(worksheetCollection_0);
			style.method_16(0);
			SetStyle(class1206_, style, bool_0: false);
			style.method_11(bool_0: false);
			style.method_13(-1);
			Class1529 class2 = method_8(j);
			string text = null;
			if (j == 0)
			{
				text = "Normal";
			}
			else if (class2 != null)
			{
				text = class2.string_0;
				if (text.Equals("Default"))
				{
					text = "Normal";
				}
			}
			if (text != null)
			{
				style.method_3(text);
				if (text.Equals("Normal"))
				{
					style.method_16(252);
					@class[0] = style;
					hashtable[j] = 0;
				}
				else
				{
					hashtable[j] = worksheetCollection_0.method_58().method_5(style);
				}
			}
			else
			{
				hashtable[j] = worksheetCollection_0.method_59(style);
			}
		}
		class1218_0.class1547_0.hashtable_3 = new Hashtable(arrayList_4.Count);
		for (int k = 0; k < arrayList_4.Count; k++)
		{
			Class1206 class3 = (Class1206)arrayList_4[k];
			int num = 0;
			if (class3.short_4 > 0)
			{
				num = (int)hashtable[(int)class3.short_4];
			}
			Style style2 = new Style(worksheetCollection_0);
			style2.method_16(0);
			style2.method_11(bool_0: true);
			style2.method_13(num);
			SetStyle(class3, style2, bool_0: true);
			if (k == 0)
			{
				@class[15] = style2;
				worksheetCollection_0.DefaultStyle = style2;
				style2.method_13(0);
				class1218_0.class1547_0.hashtable_3.Add(0, 15);
			}
			else
			{
				int num2 = @class.method_0(style2);
				class1218_0.class1547_0.hashtable_3.Add(k, num2);
			}
		}
		method_1();
	}

	private void method_1()
	{
		WorksheetCollection worksheets = workbook_0.Worksheets;
		worksheets.method_74();
		int num = ((worksheets.method_72() * 8 + worksheets.method_73()) / 8 + 1) * 8;
		double width = (double)(num - worksheets.method_73()) / (double)worksheets.method_72();
		for (int i = 0; i < worksheets.Count; i++)
		{
			Cells cells = worksheets[i].Cells;
			cells.Columns.Width = width;
		}
	}

	internal void SetStyle(Class1206 class1206_0, Style style_0, bool bool_0)
	{
		if (bool_0 || class1206_0.bool_11)
		{
			if (class1206_0.int_2 > 0)
			{
				style_0.IndentLevel = class1206_0.int_2;
			}
			style_0.HorizontalAlignment = class1206_0.textAlignmentType_0;
			style_0.VerticalAlignment = class1206_0.textAlignmentType_1;
			style_0.RotationAngle = class1206_0.int_1;
			style_0.IsTextWrapped = class1206_0.bool_1;
			style_0.ShrinkToFit = class1206_0.bool_2;
			style_0.TextDirection = class1206_0.textDirectionType_0;
		}
		style_0.method_22(class1206_0.bool_11);
		if (bool_0 || class1206_0.bool_10)
		{
			Class1208 @class = (Class1208)arrayList_2[class1206_0.short_3];
			if (@class.class1207_1 != null)
			{
				method_2(style_0.Borders[BorderType.LeftBorder], @class.class1207_1);
			}
			if (@class.class1207_3 != null)
			{
				method_2(style_0.Borders[BorderType.RightBorder], @class.class1207_3);
			}
			if (@class.class1207_0 != null)
			{
				method_2(style_0.Borders[BorderType.TopBorder], @class.class1207_0);
			}
			if (@class.class1207_2 != null)
			{
				method_2(style_0.Borders[BorderType.BottomBorder], @class.class1207_2);
			}
			if (@class.class1207_4 != null)
			{
				if (@class.bool_0)
				{
					method_2(style_0.Borders[BorderType.DiagonalDown], @class.class1207_4);
				}
				if (@class.bool_1)
				{
					method_2(style_0.Borders[BorderType.DiagonalUp], @class.class1207_4);
				}
			}
		}
		style_0.method_24(class1206_0.bool_10);
		if (bool_0 || class1206_0.bool_8)
		{
			Class1209 class2 = (Class1209)arrayList_1[class1206_0.short_2];
			style_0.Pattern = class2.backgroundType_0;
			style_0.ForeInternalColor.method_19(class2.internalColor_0);
			style_0.BackgroundInternalColor.method_19(class2.internalColor_1);
		}
		style_0.method_26(class1206_0.bool_9);
		if (bool_0 || class1206_0.bool_8)
		{
			style_0.Font.Copy((Aspose.Cells.Font)arrayList_0[class1206_0.short_1]);
		}
		style_0.method_20(class1206_0.bool_8);
		if (bool_0 || class1206_0.bool_7)
		{
			style_0.Custom = workbook_0.Worksheets.method_46(class1206_0.short_0);
			style_0.method_45(class1206_0.short_0);
		}
		style_0.method_18(class1206_0.bool_7);
		if (bool_0 || class1206_0.bool_12)
		{
			style_0.IsFormulaHidden = class1206_0.bool_4;
			style_0.IsLocked = class1206_0.bool_3;
		}
		style_0.method_28(class1206_0.bool_12);
	}

	private void method_2(Border border_0, Class1207 class1207_0)
	{
		border_0.InternalColor.method_19(class1207_0.internalColor_0);
		border_0.LineStyle = class1207_0.cellBorderType_0;
	}

	private void method_3()
	{
		TableStyleCollection tableStyles = worksheetCollection_0.TableStyles;
		byte_0 = class1218_0.method_0(class1212_0);
		int num = 4;
		tableStyles.method_1(Class1217.smethod_8(byte_0, 4));
		tableStyles.method_3(Class1217.smethod_8(int_0: (tableStyles.method_0() == null) ? (num + 4) : (num + (4 + tableStyles.method_0().Length * 2)), byte_0: byte_0));
	}

	private void method_4()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		TableStyle tableStyle = null;
		string string_ = Class1217.smethod_8(byte_0, 6);
		int index = worksheetCollection_0.TableStyles.Add(string_);
		tableStyle = worksheetCollection_0.TableStyles[index];
		tableStyle.method_3(bool_2: false);
		tableStyle.method_5(bool_2: false);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 512:
				method_5(tableStyle);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 511:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_5(TableStyle tableStyle_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		tableStyle_0.method_1(new TableStyleElementCollection(tableStyle_0));
		int num = BitConverter.ToInt32(byte_0, 0);
		int size = BitConverter.ToInt32(byte_0, 4);
		int num2 = BitConverter.ToInt32(byte_0, 8);
		try
		{
			TableStyleElement tableStyleElement = new TableStyleElement(tableStyle_0.TableStyleElements, Class1224.smethod_30(num));
			tableStyleElement.Size = size;
			tableStyleElement.int_1 = num2;
			tableStyle_0.TableStyleElements.Add(tableStyleElement);
		}
		catch
		{
		}
	}

	internal void method_6()
	{
		Class1205 @class = new Class1205(worksheetCollection_0);
		bool flag = false;
		bool flag2 = false;
		byte_0 = class1218_0.method_0(class1212_0);
		@class.bool_0 = (byte_0[1] & 0x80) != 0;
		int num = 4;
		int num2 = BitConverter.ToInt16(byte_0, 4);
		num = 4 + 2;
		Border border = null;
		bool isNotSet = false;
		Class1528 class2 = new Class1528();
		ArrayList arrayList = new ArrayList(4);
		ArrayList arrayList2 = new ArrayList(4);
		for (int i = 0; i < num2; i++)
		{
			int num3 = BitConverter.ToInt16(byte_0, num);
			int num4 = BitConverter.ToInt16(byte_0, num + 2);
			switch (num3)
			{
			case 0:
				@class.style_0.Pattern = Class1224.smethod_13(byte_0[num + 4]);
				break;
			case 1:
				@class.style_0.ForeInternalColor = method_17(byte_0, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.ForegroundColor);
				break;
			case 2:
				@class.style_0.BackgroundInternalColor = method_17(byte_0, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.BackgroundColor);
				break;
			case 3:
				switch (BitConverter.ToInt32(byte_0, num + 4))
				{
				case 0:
					class2.string_0 = "linear";
					break;
				case 1:
					class2.string_0 = "path";
					break;
				}
				class2.int_0 = (int)BitConverter.ToDouble(byte_0, num + 8);
				class2.double_0 = BitConverter.ToDouble(byte_0, num + 16);
				class2.double_1 = BitConverter.ToDouble(byte_0, num + 24);
				class2.double_2 = BitConverter.ToDouble(byte_0, num + 32);
				class2.double_3 = BitConverter.ToDouble(byte_0, num + 40);
				@class.style_0.method_36(StyleModifyFlag.BackgroundColor);
				break;
			case 4:
			{
				double num6 = BitConverter.ToDouble(byte_0, num + 6);
				InternalColor value = method_17(byte_0, num + 14, out isNotSet);
				arrayList.Add(num6);
				arrayList2.Add(value);
				break;
			}
			case 5:
				@class.Font.InternalColor = method_17(byte_0, num + 4, out isNotSet);
				@class.style_0.method_36(StyleModifyFlag.FontColor);
				break;
			case 6:
				method_16(@class.style_0.Borders[BorderType.TopBorder], byte_0, num + 4);
				break;
			case 7:
				method_16(@class.style_0.Borders[BorderType.BottomBorder], byte_0, num + 4);
				break;
			case 8:
				method_16(@class.style_0.Borders[BorderType.LeftBorder], byte_0, num + 4);
				break;
			case 9:
				method_16(@class.style_0.Borders[BorderType.RightBorder], byte_0, num + 4);
				break;
			case 10:
				if (flag)
				{
					border = @class.style_0.Borders[BorderType.DiagonalUp];
					method_16(border, byte_0, num + 4);
				}
				else if (flag2)
				{
					method_16(@class.style_0.Borders[BorderType.DiagonalDown], byte_0, num + 4);
				}
				break;
			case 11:
				method_16(@class.style_0.Borders[BorderType.Vertical], byte_0, num + 4);
				break;
			case 12:
				method_16(@class.style_0.Borders[BorderType.Horizontal], byte_0, num + 4);
				break;
			case 13:
				flag = byte_0[num + 4] == 1;
				break;
			case 14:
				flag2 = byte_0[num + 4] == 1;
				break;
			case 15:
				@class.style_0.HorizontalAlignment = Class1224.smethod_8(byte_0[num + 4]);
				break;
			case 16:
				@class.style_0.VerticalAlignment = Class1224.smethod_6(byte_0[num + 4]);
				break;
			case 17:
				@class.style_0.RotationAngle = byte_0[num + 4];
				break;
			case 18:
				@class.style_0.IndentLevel = BitConverter.ToInt16(byte_0, num + 4);
				break;
			case 19:
				switch (byte_0[num + 4])
				{
				default:
					@class.style_0.TextDirection = TextDirectionType.Context;
					break;
				case 1:
					@class.style_0.TextDirection = TextDirectionType.LeftToRight;
					break;
				case 2:
					@class.style_0.TextDirection = TextDirectionType.RightToLeft;
					break;
				}
				break;
			case 20:
				@class.style_0.IsTextWrapped = byte_0[num + 4] != 0;
				break;
			case 22:
				@class.style_0.ShrinkToFit = byte_0[num + 4] != 0;
				break;
			case 24:
				@class.Font.method_14(Class1217.smethod_9(byte_0, num + 4), Enum193.const_0);
				break;
			case 25:
				@class.Font.Weight = BitConverter.ToInt16(byte_0, num + 4);
				break;
			case 26:
				@class.Font.Underline = Class1224.smethod_4(BitConverter.ToInt16(byte_0, num + 4));
				break;
			case 27:
				switch (byte_0[num + 4])
				{
				case 1:
					@class.Font.IsSuperscript = true;
					break;
				case 2:
					@class.Font.IsSubscript = true;
					break;
				}
				break;
			case 28:
				@class.Font.IsItalic = byte_0[num + 4] != 0;
				break;
			case 29:
				@class.Font.IsStrikeout = byte_0[num + 4] != 0;
				break;
			case 34:
				@class.Font.method_3(byte_0[num + 4]);
				break;
			case 35:
				@class.Font.method_12(byte_0[num + 4]);
				break;
			case 36:
				@class.Font.method_17(BitConverter.ToInt16(byte_0, num + 4));
				break;
			case 37:
				@class.Font.method_1(Class1224.smethod_38(byte_0[num + 4]));
				break;
			case 38:
			{
				int num5 = num + 4;
				@class.style_0.Custom = Class1217.smethod_9(byte_0, num5);
				break;
			}
			case 41:
				@class.style_0.method_45(BitConverter.ToInt16(byte_0, num + 4));
				break;
			case 43:
				@class.style_0.IsFormulaHidden = byte_0[num + 4] != 0;
				break;
			case 44:
				@class.style_0.IsLocked = byte_0[num + 4] != 0;
				break;
			}
			num += num4;
		}
		int count = arrayList.Count;
		if (count != 0)
		{
			class2.double_4 = new double[count];
			class2.internalColor_0 = new InternalColor[count];
			for (int j = 0; j < count; j++)
			{
				class2.double_4[j] = (double)arrayList[j];
				class2.internalColor_0[j] = (InternalColor)arrayList2[j];
			}
			Class1528.smethod_1(class2, @class.style_0);
		}
		worksheetCollection_0.method_56().method_1(@class.style_0);
	}

	internal void method_7(ArrayList arrayList_6, bool bool_0)
	{
		Class1206 @class = new Class1206();
		arrayList_6.Add(@class);
		byte_0 = class1218_0.method_0(class1212_0);
		@class.short_4 = BitConverter.ToInt16(byte_0, 0);
		int num = 2;
		@class.short_0 = BitConverter.ToInt16(byte_0, 2);
		num = 2 + 2;
		@class.short_1 = BitConverter.ToInt16(byte_0, 4);
		num = 4 + 2;
		@class.short_2 = BitConverter.ToInt16(byte_0, 6);
		num = 6 + 2;
		@class.short_3 = BitConverter.ToInt16(byte_0, 8);
		num = 8 + 2;
		byte[] array = byte_0;
		num = 10 + 1;
		@class.int_1 = array[10];
		if (@class.int_1 > 90)
		{
			@class.int_1 = 90 - @class.int_1;
		}
		@class.int_2 = byte_0[num++];
		byte b = (byte)(byte_0[num] & 7u);
		@class.textAlignmentType_0 = Class1224.smethod_8(b);
		b = (byte)((byte_0[num] & 0x38) >> 3);
		@class.textAlignmentType_1 = Class1224.smethod_6(b);
		@class.bool_1 = (byte_0[num] & 0x40) != 0;
		num++;
		@class.bool_2 = (byte_0[num] & 1) != 0;
		switch ((byte)((byte_0[num] & 0xC0) >> 2))
		{
		default:
			@class.textDirectionType_0 = TextDirectionType.Context;
			break;
		case 1:
			@class.textDirectionType_0 = TextDirectionType.LeftToRight;
			break;
		case 2:
			@class.textDirectionType_0 = TextDirectionType.RightToLeft;
			break;
		}
		@class.bool_3 = (byte_0[num] & 0x10) != 0;
		@class.bool_4 = (byte_0[num] & 0x20) != 0;
		@class.bool_5 = (byte_0[num] & 0x40) != 0;
		@class.bool_6 = (byte_0[num] & 0x80) != 0;
		num++;
		if (bool_0)
		{
			@class.bool_7 = (byte_0[num] & 1) != 0;
			@class.bool_8 = (byte_0[num] & 2) != 0;
			@class.bool_11 = (byte_0[num] & 4) != 0;
			@class.bool_10 = (byte_0[num] & 8) != 0;
			@class.bool_9 = (byte_0[num] & 0x10) != 0;
			@class.bool_12 = (byte_0[num] & 0x20) != 0;
		}
		else
		{
			@class.bool_7 = (byte_0[num] & 1) == 0;
			@class.bool_8 = (byte_0[num] & 2) == 0;
			@class.bool_11 = (byte_0[num] & 4) == 0;
			@class.bool_10 = (byte_0[num] & 8) == 0;
			@class.bool_9 = (byte_0[num] & 0x10) == 0;
			@class.bool_12 = (byte_0[num] & 0x20) == 0;
		}
	}

	internal Class1529 method_8(int int_2)
	{
		int num = 0;
		Class1529 @class;
		while (true)
		{
			if (num < arrayList_5.Count)
			{
				@class = (Class1529)arrayList_5[num];
				if (@class.int_0 == int_2)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	internal void method_9()
	{
		Class1529 @class = new Class1529();
		arrayList_5.Add(@class);
		byte_0 = class1218_0.method_0(class1212_0);
		@class.int_0 = BitConverter.ToInt32(byte_0, 0);
		if (((uint)byte_0[4] & (true ? 1u : 0u)) != 0)
		{
			@class.string_0 = Class1224.smethod_2(byte_0[6], byte_0[7]);
		}
		if (@class.string_0 == null || @class.string_0 == "")
		{
			@class.string_0 = Class1217.smethod_8(byte_0, 8);
		}
	}

	internal void method_10()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1208 @class = new Class1208();
		@class.bool_0 = (byte_0[0] & 1) != 0;
		@class.bool_1 = (byte_0[0] & 2) != 0;
		int num = 1;
		@class.class1207_0 = method_11(byte_0, 1);
		num = 1 + 10;
		@class.class1207_2 = method_11(byte_0, 11);
		num = 11 + 10;
		@class.class1207_1 = method_11(byte_0, 21);
		num = 21 + 10;
		@class.class1207_3 = method_11(byte_0, 31);
		num = 31 + 10;
		if (@class.bool_1 || @class.bool_0)
		{
			@class.class1207_4 = method_11(byte_0, num);
			num += 10;
		}
		arrayList_2.Add(@class);
	}

	internal Class1207 method_11(byte[] byte_1, int int_2)
	{
		Class1207 @class = new Class1207();
		@class.cellBorderType_0 = Class1224.smethod_10(byte_0[int_2]);
		int_2 += 2;
		bool isNotSet = false;
		@class.internalColor_0 = smethod_0(byte_1, int_2, out isNotSet);
		return @class;
	}

	internal void method_12()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1209 @class = new Class1209();
		arrayList_1.Add(@class);
		@class.backgroundType_0 = Class1224.smethod_13(byte_0[0]);
		bool isNotSet = false;
		@class.internalColor_0 = smethod_0(byte_0, 4, out isNotSet);
		@class.internalColor_1 = smethod_0(byte_0, 12, out isNotSet);
	}

	internal void method_13()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Aspose.Cells.Font font = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
		arrayList_0.Add(font);
		int num = 0;
		font.method_17(BitConverter.ToInt16(byte_0, 0));
		num = 0 + 2;
		font.IsItalic = (byte_0[2] & 2) != 0;
		font.IsStrikeout = (byte_0[2] & 8) != 0;
		num = 2 + 2;
		font.Weight = BitConverter.ToInt16(byte_0, 4);
		num = 4 + 2;
		switch (byte_0[6])
		{
		case 1:
			font.IsSuperscript = true;
			break;
		case 2:
			font.IsSubscript = true;
			break;
		}
		num += 2;
		font.Underline = Class1224.smethod_4(byte_0[num]);
		num++;
		font.method_12(byte_0[num++]);
		font.method_3(byte_0[num++]);
		num++;
		bool isNotSet = false;
		font.InternalColor = smethod_0(byte_0, num, out isNotSet);
		num += 8;
		Enum193 enum193_ = Class1224.smethod_37(byte_0[num]);
		num++;
		font.method_14(Class1217.smethod_5(byte_0, ref num), enum193_);
	}

	internal void method_14()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		ushort num = BitConverter.ToUInt16(byte_0, 0);
		int num2 = 2;
		string string_ = Class1217.smethod_5(byte_0, ref num2);
		Class639 @class = new Class639();
		@class.method_4(string_, num);
		if (worksheetCollection_0.method_41() < num)
		{
			worksheetCollection_0.method_42(num);
		}
		worksheetCollection_0.method_55().Add(@class);
	}

	internal void method_15()
	{
		int num = 0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 475:
				byte_0 = class1218_0.method_0(class1212_0);
				BitConverter.ToInt32(byte_0, 0);
				if (num < 8)
				{
					num++;
					break;
				}
				workbook_0.ChangePalette(Color.FromArgb(byte_0[3], byte_0[0], byte_0[1], byte_0[2]), num - 8);
				num++;
				break;
			case 279:
			case 474:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	internal static InternalColor smethod_0(byte[] buffer, int offset, out bool isNotSet)
	{
		isNotSet = false;
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.Tint = (double)BitConverter.ToInt16(buffer, offset + 2) / 32767.0;
		switch ((buffer[offset] & 0xFE) >> 1)
		{
		default:
			internalColor.method_3(bool_0: true);
			isNotSet = true;
			break;
		case 0:
			internalColor.method_3(bool_0: true);
			break;
		case 1:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(ColorType.IndexedColor, buffer[offset + 1]);
			}
			break;
		case 2:
			offset += 4;
			internalColor.SetColor(ColorType.RGB, (buffer[offset] << 16) + (buffer[offset + 1] << 8) + buffer[offset + 2]);
			break;
		case 3:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(ColorType.Theme, buffer[offset + 1]);
			}
			break;
		}
		return internalColor;
	}

	internal void method_16(Border border_0, byte[] byte_1, int int_2)
	{
		bool isNotSet = false;
		border_0.InternalColor = method_17(byte_1, int_2, out isNotSet);
		int_2 += 8;
		border_0.LineStyle = Class1224.smethod_10(byte_0[int_2]);
	}

	internal InternalColor method_17(byte[] buffer, int offset, out bool isNotSet)
	{
		isNotSet = false;
		InternalColor internalColor = new InternalColor(bool_0: false);
		internalColor.Tint = (double)BitConverter.ToInt16(buffer, offset + 2) / 32767.0;
		switch ((buffer[offset] & 0xFE) >> 1)
		{
		default:
			internalColor.method_3(bool_0: true);
			break;
		case 0:
			internalColor.method_3(bool_0: true);
			break;
		case 1:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(ColorType.IndexedColor, buffer[offset + 1]);
			}
			break;
		case 2:
			offset += 4;
			internalColor.SetColor(ColorType.RGB, (buffer[offset] << 16) + (buffer[offset + 1] << 8) + buffer[offset + 2]);
			break;
		case 3:
			if (buffer[offset + 1] >= 64)
			{
				internalColor.method_3(bool_0: true);
			}
			else
			{
				internalColor.SetColor(ColorType.Theme, buffer[offset + 1]);
			}
			break;
		case 4:
			isNotSet = true;
			break;
		}
		return internalColor;
	}
}
