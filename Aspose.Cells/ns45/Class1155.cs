using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns2;
using ns22;
using ns27;
using ns57;
using ns59;

namespace ns45;

internal class Class1155
{
	private Class1730 class1730_0;

	private byte[] byte_0;

	private Class1723 class1723_0;

	private ushort ushort_0;

	private byte[] byte_1;

	private ushort ushort_1;

	private PivotTable pivotTable_0;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private PivotField pivotField_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	internal Class1155()
	{
		byte_0 = new byte[2];
	}

	internal void Read(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, Class1730 class1730_1, Class1723 class1723_1)
	{
		worksheet_0 = worksheet_1;
		worksheetCollection_0 = worksheetCollection_1;
		class1723_0 = class1723_1;
		class1730_0 = class1730_1;
		pivotTable_0 = new PivotTable(worksheet_1.PivotTables);
		pivotTable_0.bool_1 = true;
		worksheet_1.PivotTables.method_5(pivotTable_0);
		if (!method_7())
		{
			ushort_0 = 176;
			method_6();
			return;
		}
		bool bool_ = true;
		bool bool_2 = true;
		while (true)
		{
			ushort_0 = class1723_1.method_2(byte_0);
			switch (ushort_0)
			{
			case 241:
				method_11();
				break;
			case 2148:
				method_2();
				break;
			case 2064:
				method_4();
				break;
			case 2050:
				method_3();
				break;
			case 177:
				method_15();
				break;
			case 180:
				method_12(bool_);
				bool_ = false;
				break;
			case 181:
				method_5(bool_2);
				bool_2 = false;
				break;
			case 182:
				method_13();
				break;
			case 197:
				method_14();
				break;
			default:
				class1723_1.method_3(-2);
				return;
			}
		}
	}

	private void method_0()
	{
		method_16();
		Class1163 @class = new Class1163(pivotTable_0.class1164_0);
		@class.byte_0 = (byte)(byte_1[0] & 0xFu);
		BitConverter.ToUInt16(byte_1, 2);
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 240)
		{
			method_16();
			Class1171 class2 = (@class.class1171_0 = new Class1171());
			class2.byte_0 = byte_1[0];
			class2.byte_1 = byte_1[1];
			class2.ushort_0 = BitConverter.ToUInt16(byte_1, 2);
			int num = BitConverter.ToUInt16(byte_1, 6);
			if (class2.method_16() && byte_1.Length == 12)
			{
				class2.byte_2 = byte_1[8];
				class2.byte_3 = byte_1[9];
				class2.byte_4 = byte_1[10];
				class2.byte_5 = byte_1[11];
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 242)
					{
						break;
					}
					method_16();
					Class1162 class3 = new Class1162();
					class2.arrayList_0.Add(class3);
					class3.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
					class3.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
					class3.Function = BitConverter.ToUInt16(byte_1, 4);
					int num3 = BitConverter.ToUInt16(byte_1, 6);
					if (num3 > 0)
					{
						ushort_0 = class1723_0.method_2(byte_0);
						if (ushort_0 != 245)
						{
							class1723_0.method_3(-2);
							return;
						}
						method_16();
						int num4 = 0;
						for (int i = 0; i < num3; i++)
						{
							if (num4 >= byte_1.Length)
							{
								break;
							}
							class3.arrayList_0.Add((int)BitConverter.ToUInt16(byte_1, num4));
							num4 += 2;
						}
					}
					num2++;
					continue;
				}
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 == 244)
				{
					method_16();
					int int_ = 0;
					Style style_ = new Style(worksheetCollection_0);
					if (byte_1 != null)
					{
						method_1(byte_1, ref int_, style_);
						@class.method_0(style_);
					}
					pivotTable_0.class1164_0.Add(@class);
				}
				else
				{
					class1723_0.method_3(-2);
				}
				return;
			}
			class1723_0.method_3(-2);
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_1(byte[] byte_2, ref int int_6, Style style_0)
	{
		uint num = BitConverter.ToUInt32(byte_2, int_6);
		int_6 += 4;
		ushort num2 = BitConverter.ToUInt16(byte_2, int_6);
		bool flag = (byte_2[int_6] & 1) != 0;
		int_6 += 2;
		if (num == 0)
		{
			return;
		}
		if ((num & 0x2000000u) != 0)
		{
			if (!flag)
			{
				int num3 = byte_2[int_6 + 1];
				for (int i = 0; i < worksheetCollection_0.method_55().Count; i++)
				{
					Class639 @class = (Class639)worksheetCollection_0.method_55()[i];
					if (@class.Index == num3)
					{
						if (@class.Custom != null && !(@class.Custom == ""))
						{
							style_0.Custom = @class.Custom;
						}
						break;
					}
				}
				style_0.Number = num3;
				if (style_0.Number == 14)
				{
					style_0.Custom = "0.00%";
				}
				int_6 += 2;
			}
			else
			{
				int num4 = BitConverter.ToInt16(byte_1, int_6);
				int_6 += 2;
				if (num4 > 0)
				{
					int num5 = BitConverter.ToInt16(byte_1, int_6);
					int_6 += 2;
					if (num5 > 0)
					{
						style_0.Custom = method_9(ref int_6, num5);
					}
				}
			}
		}
		if ((num & 0x4000000u) != 0)
		{
			int num6 = byte_2[int_6];
			if (num6 > 0)
			{
				int int_7 = int_6 + 1;
				style_0.Font.Name = method_9(ref int_7, num6);
			}
			bool flag2 = BitConverter.ToInt32(byte_2, int_6 + 92) == 0;
			bool flag3 = BitConverter.ToInt32(byte_2, int_6 + 96) == 0;
			bool flag4 = BitConverter.ToInt32(byte_2, int_6 + 100) == 0;
			bool flag5 = (byte_2[int_6 + 88] & 2) == 0;
			bool flag6 = (byte_2[int_6 + 88] & 0x80) == 0;
			int num7 = BitConverter.ToInt32(byte_2, int_6 + 64);
			if (num7 != -1)
			{
				style_0.Font.Size = (short)(num7 / 20);
			}
			if (flag5)
			{
				style_0.Font.IsItalic = (byte_2[int_6 + 68] & 2) != 0;
			}
			if (flag4)
			{
				style_0.Font.Weight = BitConverter.ToUInt16(byte_2, int_6 + 72);
			}
			if (flag6)
			{
				style_0.Font.IsStrikeout = (byte_2[int_6 + 68] & 0x80) != 0;
			}
			if (flag2)
			{
				switch (BitConverter.ToInt16(byte_2, int_6 + 74))
				{
				case 1:
					style_0.Font.IsSuperscript = true;
					break;
				case 2:
					style_0.Font.IsSubscript = true;
					break;
				}
			}
			if (flag3)
			{
				switch (byte_2[int_6 + 76])
				{
				case 33:
					style_0.Font.Underline = FontUnderlineType.Accounting;
					break;
				case 34:
					style_0.Font.Underline = FontUnderlineType.DoubleAccounting;
					break;
				case 0:
					style_0.Font.Underline = FontUnderlineType.None;
					break;
				case 1:
					style_0.Font.Underline = FontUnderlineType.Single;
					break;
				case 2:
					style_0.Font.Underline = FontUnderlineType.Double;
					break;
				}
			}
			num7 = BitConverter.ToInt32(byte_2, int_6 + 80);
			if (num7 != -1)
			{
				style_0.Font.Color = worksheetCollection_0.method_24().method_7(num7);
			}
			int_6 += 118;
		}
		if ((num & 0x8000000u) != 0)
		{
			if ((num & 1) == 0)
			{
				style_0.HorizontalAlignment = Class1673.smethod_10(byte_2[int_6] & 7, bool_0: false);
			}
			if ((num & 2) == 0)
			{
				style_0.VerticalAlignment = Class1673.smethod_10((byte_2[int_6] & 0x70) >> 4, bool_0: true);
			}
			if ((num & 4) == 0)
			{
				style_0.IsTextWrapped = (byte_2[int_6] & 8) != 0;
			}
			if ((num & 8) == 0)
			{
				style_0.RotationAngle = byte_2[int_6 + 1];
			}
			if ((num & 0x20) == 0)
			{
				int indentLevel = byte_2[int_6 + 2] & 0xF;
				int num8 = byte_2[int_6 + 4];
				if (num8 != 255)
				{
					style_0.IndentLevel = num8;
				}
				else
				{
					style_0.IndentLevel = indentLevel;
				}
			}
			if ((num & 0x40) == 0)
			{
				style_0.ShrinkToFit = (byte_2[int_6 + 2] & 0x10) != 0;
			}
			if ((num & 0x80000000u) == 0)
			{
				switch ((byte_2[int_6 + 2] & 0xC0) >> 6)
				{
				case 0:
					style_0.TextDirection = TextDirectionType.Context;
					break;
				case 1:
					style_0.TextDirection = TextDirectionType.LeftToRight;
					break;
				case 2:
					style_0.TextDirection = TextDirectionType.RightToLeft;
					break;
				}
			}
			int_6 += 8;
		}
		if ((num & 0x10000000u) != 0)
		{
			if ((num2 & 4u) != 0)
			{
				style_0.Borders.Outline = true;
			}
			ushort num9 = BitConverter.ToUInt16(byte_2, int_6);
			uint num10 = BitConverter.ToUInt16(byte_2, int_6 + 2);
			int num11 = 0;
			bool flag7 = false;
			bool flag8 = false;
			if ((num & 0x400) == 0)
			{
				style_0.Borders[BorderType.LeftBorder].LineStyle = (CellBorderType)(num9 & 0xF);
				num11 = (int)(num10 & 0x7F);
				style_0.Borders[BorderType.LeftBorder].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			if ((num & 0x800) == 0)
			{
				style_0.Borders[BorderType.RightBorder].LineStyle = (CellBorderType)((num9 & 0xF0) >> 4);
				num11 = (int)((num10 & 0x3F80) >> 7);
				style_0.Borders[BorderType.RightBorder].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			flag7 = (num10 & 0x4000) != 0;
			flag8 = (num10 & 0x8000) != 0;
			num10 = BitConverter.ToUInt32(byte_2, int_6 + 4);
			if ((num & 0x1000) == 0)
			{
				style_0.Borders[BorderType.TopBorder].LineStyle = (CellBorderType)((num9 & 0xF00) >> 8);
				num11 = (int)(num10 & 0x7F);
				style_0.Borders[BorderType.TopBorder].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			if ((num & 0x2000) == 0)
			{
				style_0.Borders[BorderType.BottomBorder].LineStyle = (CellBorderType)((num9 & 0xF000) >> 12);
				num11 = (int)((num10 & 0x3F80) >> 7);
				style_0.Borders[BorderType.BottomBorder].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			if ((num & 0x4000) == 0 && flag7)
			{
				style_0.Borders[BorderType.DiagonalDown].LineStyle = (CellBorderType)((num10 & 0x1E00000) >> 21);
				num11 = (int)((num10 & 0x1FC00) >> 14);
				style_0.Borders[BorderType.DiagonalDown].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			if ((num & 0x8000) == 0 && flag8)
			{
				style_0.Borders[BorderType.DiagonalUp].LineStyle = (CellBorderType)((num10 & 0x1E00000) >> 21);
				num11 = (int)((num10 & 0x1FC00) >> 14);
				style_0.Borders[BorderType.DiagonalUp].Color = worksheetCollection_0.method_24().method_7(num11);
			}
			int_6 += 8;
		}
		if ((num & 0x20000000u) != 0)
		{
			if ((num & 0x10000) == 0)
			{
				style_0.Pattern = (BackgroundType)(byte_2[int_6 + 1] >> 2);
			}
			int num12 = 0;
			if ((num & 0x20000) == 0)
			{
				num12 = byte_2[int_6 + 2] & 0x7F;
				style_0.ForegroundColor = worksheetCollection_0.method_24().method_7(num12);
			}
			if ((num & 0x40000) == 0)
			{
				num12 = (BitConverter.ToUInt16(byte_2, int_6 + 2) & 0x3F80) >> 7;
				style_0.BackgroundColor = worksheetCollection_0.method_24().method_7(num12);
			}
			int_6 += 4;
		}
		if ((num & 0x40000000u) != 0)
		{
			if ((num & 0x100) == 0)
			{
				style_0.IsLocked = (byte_2[int_6] & 1) != 0;
			}
			if ((num & 0x200) == 0)
			{
				style_0.IsFormulaHidden = (byte_2[int_6] & 2) != 0;
			}
			int_6 += 2;
		}
	}

	private void method_2()
	{
		method_16();
		byte[] array = new byte[byte_1.Length - 4];
		Array.Copy(byte_1, 4, array, 0, array.Length);
		pivotTable_0.class1140_0.Add(array);
		if (byte_1[4] == 0)
		{
			if (byte_1[5] == 30)
			{
				int num = 14;
				int num2 = BitConverter.ToInt16(byte_1, 14);
				if (num2 > 0)
				{
					num += 2;
					pivotTable_0.PivotTableStyleName = method_10(ref num, num2);
				}
			}
			else if (byte_1[5] == 2)
			{
				if ((byte_1[7] & 4u) != 0)
				{
					pivotTable_0.EnableFieldList = false;
				}
				else
				{
					pivotTable_0.EnableFieldList = true;
				}
			}
		}
		else if (byte_1[4] == 23)
		{
			PivotField pivotField = null;
			if (byte_1[5] != 0)
			{
				return;
			}
			int num3 = 12;
			int num4 = BitConverter.ToInt16(byte_1, 12);
			if (num4 > 0)
			{
				num3 += 2;
				string name = method_9(ref num3, num4);
				pivotField = pivotTable_0.BaseFields[name];
			}
			ushort_0 = class1723_0.method_2(byte_0);
			ushort num5 = ushort_0;
			if (num5 == 2148)
			{
				method_16();
				array = new byte[byte_1.Length - 4];
				Array.Copy(byte_1, 4, array, 0, array.Length);
				pivotTable_0.class1140_0.Add(array);
				if (byte_1[5] == 25 && pivotField != null)
				{
					if ((byte_1[6] & 0x20u) != 0)
					{
						pivotField.IsIncludeNewItemsInFilter = false;
					}
					else
					{
						pivotField.IsIncludeNewItemsInFilter = true;
					}
					if ((byte_1[6] & 8u) != 0)
					{
						pivotField.ShowCompact = true;
					}
					else
					{
						pivotField.ShowCompact = false;
					}
				}
			}
			else
			{
				class1723_0.method_3(-2);
			}
		}
		else
		{
			if (byte_1[4] != 29)
			{
				return;
			}
			if (byte_1[5] == 56)
			{
				int index = BitConverter.ToInt32(byte_1, 6);
				pivotTable_0.pivotField_1 = pivotTable_0.BaseFields[index];
			}
			else if (byte_1[5] == 60)
			{
				double num6 = BitConverter.ToDouble(byte_1, 26);
				if (pivotTable_0.pivotField_1 != null)
				{
					pivotTable_0.pivotField_1.int_0 = (int)num6;
				}
			}
		}
	}

	private void method_3()
	{
		method_16();
		Class1172 @class = new Class1172();
		pivotTable_0.class1172_0 = @class;
		@class.byte_0 = new byte[14];
		Array.Copy(byte_1, 2, @class.byte_0, 0, 14);
		int num = 16;
		int int_ = BitConverter.ToInt16(byte_1, 16);
		num = 16 + 2;
		@class.string_0 = method_9(ref num, int_);
		@class.ushort_0 = BitConverter.ToUInt16(byte_1, num);
	}

	private void method_4()
	{
		method_16();
		Class1176 class1176_ = pivotTable_0.class1176_0;
		class1176_.int_0 = BitConverter.ToInt32(byte_1, 8);
		class1176_.method_2(Class1152.smethod_0(BitConverter.ToUInt16(byte_1, 12)));
		int num = BitConverter.ToInt16(byte_1, 14);
		if (num > 0)
		{
			int int_ = 16;
			class1176_.string_0 = method_9(ref int_, num);
		}
	}

	private void method_5(bool bool_0)
	{
		method_16();
		int num = 0;
		ArrayList arrayList = null;
		int num2;
		if (bool_0)
		{
			num = int_0;
			arrayList = (pivotTable_0.arrayList_0 = new ArrayList(num));
			num2 = int_2;
		}
		else
		{
			num = int_1;
			arrayList = (pivotTable_0.arrayList_1 = new ArrayList(num));
			num2 = int_3;
		}
		int i = 0;
		int num3 = 4 + num2;
		int[] array = null;
		int num4 = 0;
		while (true)
		{
			if (num4 >= num)
			{
				return;
			}
			if (i + num3 * 2 > byte_1.Length)
			{
				array = new int[num3];
				arrayList.Add(array);
				int j = 0;
				for (; i < byte_1.Length; i += 2)
				{
					array[j++] = BitConverter.ToInt16(byte_1, i);
				}
				ushort_0 = class1723_0.method_2(byte_0);
				if (ushort_0 != 60)
				{
					break;
				}
				method_16();
				i = 0;
				for (; j < num3; j++)
				{
					array[j] = BitConverter.ToInt16(byte_1, i);
					i += 2;
				}
			}
			array = new int[num3];
			arrayList.Add(array);
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = BitConverter.ToInt16(byte_1, i);
				i += 2;
			}
			num4++;
		}
		class1723_0.method_3(-2);
	}

	private void method_6()
	{
		byte[] array = new byte[byte_1.Length + 4];
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes((short)byte_1.Length), 0, array, 2, 2);
		Array.Copy(byte_1, 0, array, 4, byte_1.Length);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(array);
		pivotTable_0.arrayList_2 = arrayList;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			ushort num = ushort_0;
			if (num == 10 || num == 176 || num == 574)
			{
				break;
			}
			method_17();
			arrayList.Add(byte_1);
		}
		class1723_0.method_3(-2);
	}

	private bool method_7()
	{
		method_16();
		bool flag = false;
		int int_ = BitConverter.ToUInt16(byte_1, 14);
		if (worksheetCollection_0.method_89().Count > 0)
		{
			Class1141 @class = worksheetCollection_0.method_89()[int_];
			@class.int_5++;
			PivotTableSourceType pivotTableSourceType_ = @class.pivotTableSourceType_0;
			if (pivotTableSourceType_ != PivotTableSourceType.ListDatabase && pivotTableSourceType_ != PivotTableSourceType.Consilidation)
			{
				Class1143 class2 = new Class1143();
				class2.method_0(@class, worksheet_0, class1730_0);
				method_8(@class);
				flag = true;
			}
			else
			{
				Class1143 class3 = new Class1143();
				class3.Read(@class, worksheet_0, class1730_0);
				pivotTable_0.class1141_0 = @class;
				pivotTable_0.class1141_0.int_7 = int_;
			}
		}
		pivotTable_0.int_0 = BitConverter.ToUInt16(byte_1, 0);
		pivotTable_0.int_1 = BitConverter.ToUInt16(byte_1, 2);
		pivotTable_0.int_2 = byte_1[4];
		pivotTable_0.int_3 = byte_1[6];
		pivotTable_0.int_4 = BitConverter.ToUInt16(byte_1, 8);
		pivotTable_0.int_5 = BitConverter.ToUInt16(byte_1, 10);
		pivotTable_0.int_6 = byte_1[12];
		int_2 = BitConverter.ToUInt16(byte_1, 24);
		int_3 = BitConverter.ToUInt16(byte_1, 26);
		int_4 = BitConverter.ToUInt16(byte_1, 28);
		int_5 = BitConverter.ToUInt16(byte_1, 30);
		int_0 = BitConverter.ToUInt16(byte_1, 32);
		int_1 = BitConverter.ToUInt16(byte_1, 34);
		pivotTable_0.class1175_0.ushort_0 = BitConverter.ToUInt16(byte_1, 36);
		pivotTable_0.class1175_0.short_0 = BitConverter.ToInt16(byte_1, 38);
		ushort num = BitConverter.ToUInt16(byte_1, 40);
		ushort num2 = BitConverter.ToUInt16(byte_1, 42);
		int num3 = 44;
		if (byte_1[44] == 0)
		{
			byte[] array = new byte[2 * num];
			for (int i = 0; i < num; i++)
			{
				array[2 * i] = byte_1[num3 + 1 + i];
			}
			pivotTable_0.class1175_0.string_0 = Encoding.Unicode.GetString(array, 0, array.Length);
			num3 += num + 1;
		}
		else
		{
			pivotTable_0.class1175_0.string_0 = Encoding.Unicode.GetString(byte_1, num3 + 1, num * 2);
			num3 += num * 2 + 1;
		}
		if (byte_1[num3] == 0)
		{
			pivotTable_0.class1175_0.string_1 = Encoding.ASCII.GetString(byte_1, num3 + 1, num2);
			num3 += num2 + 1;
		}
		else
		{
			pivotTable_0.class1175_0.string_1 = Encoding.Unicode.GetString(byte_1, num3 + 1, num2 * 2);
			num3 += num2 * 2 + 1;
		}
		if (int_5 > 1)
		{
			pivotField_0 = new PivotField();
			pivotField_0.int_1 = -2;
			pivotField_0.pivotTable_0 = pivotTable_0;
			pivotField_0.pivotFieldCollection_0 = pivotTable_0.BaseFields;
			pivotField_0.pivotField_0 = pivotField_0;
			pivotTable_0.pivotField_0 = pivotField_0;
		}
		if (flag)
		{
			return false;
		}
		return true;
	}

	private void method_8(Class1141 class1141_0)
	{
		Class1317 class1317_ = class1730_0.class1317_0;
		Class1319 @class = class1317_.method_9().method_0("_SX_DB_CUR");
		if (@class != null)
		{
			string text = Class1025.smethod_6(class1141_0.int_6);
			MemoryStream stream = @class.GetStream(text);
			if (stream != null)
			{
				@class.Remove(text);
			}
		}
	}

	[Attribute0(true)]
	private string method_9(ref int int_6, int int_7)
	{
		string text = null;
		if (byte_1[int_6] == 0)
		{
			text = Encoding.ASCII.GetString(byte_1, int_6 + 1, int_7);
			int_6 += int_7 + 1;
		}
		else
		{
			text = Encoding.Unicode.GetString(byte_1, int_6 + 1, int_7 * 2);
			int_6 += int_7 * 2 + 1;
		}
		return text;
	}

	[Attribute0(true)]
	private string method_10(ref int int_6, int int_7)
	{
		string text = null;
		text = Encoding.Unicode.GetString(byte_1, int_6, int_7 * 2);
		int_6 += int_7 * 2;
		return text;
	}

	private void method_11()
	{
		method_16();
		Class1160 class1160_ = pivotTable_0.class1160_0;
		class1160_.short_0 = BitConverter.ToInt16(byte_1, 0);
		short num = BitConverter.ToInt16(byte_1, 2);
		short num2 = BitConverter.ToInt16(byte_1, 4);
		short num3 = BitConverter.ToInt16(byte_1, 6);
		class1160_.short_1 = BitConverter.ToInt16(byte_1, 8);
		class1160_.ushort_0 = BitConverter.ToUInt16(byte_1, 14);
		class1160_.ushort_1 = BitConverter.ToUInt16(byte_1, 16);
		short num4 = BitConverter.ToInt16(byte_1, 18);
		short num5 = BitConverter.ToInt16(byte_1, 20);
		short num6 = BitConverter.ToInt16(byte_1, 22);
		int int_ = 24;
		if (num != -1)
		{
			class1160_.string_0 = method_9(ref int_, num);
		}
		if (num2 != -1)
		{
			class1160_.string_1 = method_9(ref int_, num2);
		}
		if (num3 != -1)
		{
			class1160_.string_2 = method_9(ref int_, num3);
		}
		if (num4 != -1)
		{
			class1160_.string_3 = method_9(ref int_, num4);
		}
		if (num5 != -1)
		{
			class1160_.string_4 = method_9(ref int_, num5);
		}
		if (num6 != -1)
		{
			class1160_.string_5 = method_9(ref int_, num6);
		}
		if (class1160_.short_0 + class1160_.short_1 == 0)
		{
			return;
		}
		ArrayList arrayList = (class1160_.arrayList_0 = new ArrayList());
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				method_17();
				arrayList.Add(byte_1);
				break;
			case 251:
				method_0();
				break;
			case 10:
			case 176:
			case 574:
			case 2050:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private void method_12(bool bool_0)
	{
		method_16();
		PivotFieldCollection pivotFieldCollection = null;
		pivotFieldCollection = ((!bool_0) ? pivotTable_0.ColumnFields : ((int_2 == 0) ? pivotTable_0.ColumnFields : pivotTable_0.RowFields));
		for (int i = 0; i < byte_1.Length; i += 2)
		{
			int num = BitConverter.ToInt16(byte_1, i);
			if (num < 0)
			{
				pivotFieldCollection.method_4(pivotField_0);
				pivotField_0.pivotFieldType_0 = pivotFieldCollection.pivotFieldType_0;
			}
			else
			{
				PivotField pivotField = pivotTable_0.BaseFields[num];
				pivotFieldCollection.method_4(pivotField);
			}
		}
	}

	private void method_13()
	{
		method_16();
		for (int i = 0; i < byte_1.Length; i += 6)
		{
			PivotField pivotField = pivotTable_0.BaseFields[BitConverter.ToUInt16(byte_1, i)];
			pivotTable_0.PageFields.method_4(pivotField);
			pivotField.class1170_0 = new Class1170(pivotField);
			pivotField.class1170_0.short_0 = BitConverter.ToInt16(byte_1, i + 2);
			int num = BitConverter.ToUInt16(byte_1, i + 4);
			worksheet_0.Shapes.method_19(num);
		}
	}

	private void method_14()
	{
		method_16();
		PivotFieldCollection dataFields = pivotTable_0.DataFields;
		PivotField pivotField = new PivotField();
		pivotField.pivotFieldCollection_0 = dataFields;
		pivotField.Index = dataFields.Count;
		dataFields.method_4(pivotField);
		int index = BitConverter.ToUInt16(byte_1, 0);
		pivotField.pivotField_0 = pivotTable_0.BaseFields[index];
		Class1159 @class = (pivotField.class1159_0 = new Class1159());
		@class.pivotField_0 = pivotField;
		switch (byte_1[2])
		{
		case 0:
			@class.consolidationFunction_0 = ConsolidationFunction.Sum;
			break;
		case 1:
			@class.consolidationFunction_0 = ConsolidationFunction.Count;
			break;
		case 2:
			@class.consolidationFunction_0 = ConsolidationFunction.Average;
			break;
		case 3:
			@class.consolidationFunction_0 = ConsolidationFunction.Max;
			break;
		case 4:
			@class.consolidationFunction_0 = ConsolidationFunction.Min;
			break;
		case 5:
			@class.consolidationFunction_0 = ConsolidationFunction.Product;
			break;
		case 6:
			@class.consolidationFunction_0 = ConsolidationFunction.CountNums;
			break;
		case 7:
			@class.consolidationFunction_0 = ConsolidationFunction.StdDev;
			break;
		case 8:
			@class.consolidationFunction_0 = ConsolidationFunction.StdDevp;
			break;
		case 9:
			@class.consolidationFunction_0 = ConsolidationFunction.Var;
			break;
		case 10:
			@class.consolidationFunction_0 = ConsolidationFunction.Varp;
			break;
		}
		@class.pivotFieldDataDisplayFormat_0 = (PivotFieldDataDisplayFormat)byte_1[4];
		@class.int_0 = BitConverter.ToInt16(byte_1, 6);
		@class.int_1 = BitConverter.ToInt16(byte_1, 8);
		@class.short_0 = BitConverter.ToInt16(byte_1, 10);
		@class.string_0 = worksheetCollection_0.method_46(@class.short_0);
		ushort num = BitConverter.ToUInt16(byte_1, 12);
		if (num != ushort.MaxValue)
		{
			if (byte_1[14] == 0)
			{
				@class.string_1 = Encoding.ASCII.GetString(byte_1, 15, num);
			}
			else
			{
				@class.string_1 = Encoding.Unicode.GetString(byte_1, 15, num * 2);
			}
		}
		if (pivotField_0 != null)
		{
			PivotItem pivotItem = new PivotItem(pivotField_0.pivotItemCollection_0);
			pivotField_0.pivotItemCollection_0.Add(pivotItem);
			pivotItem.Index = pivotField.Index;
			pivotItem.pivotField_0 = pivotField;
		}
	}

	private void method_15()
	{
		PivotField pivotField = new PivotField(pivotTable_0.BaseFields);
		pivotField.pivotTable_0 = pivotTable_0;
		pivotField.int_1 = pivotTable_0.BaseFields.Count;
		if (pivotTable_0.class1141_0 != null && pivotTable_0.class1141_0.arrayList_0 != null && pivotField.int_1 < pivotTable_0.class1141_0.arrayList_0.Count)
		{
			pivotField.class1161_0 = (Class1161)pivotTable_0.class1141_0.arrayList_0[pivotTable_0.BaseFields.Count];
		}
		pivotTable_0.BaseFields.method_4(pivotField);
		method_16();
		BitConverter.ToUInt16(byte_1, 2);
		pivotField.method_5((byte_1[0] & 8) != 0);
		int num = byte_1[0] & 0xF;
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Row;
		}
		else if (((uint)num & 2u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Column;
		}
		else if (((uint)num & 4u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Page;
		}
		else if (((uint)num & 8u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Data;
		}
		pivotField.class1173_0.ushort_0 = BitConverter.ToUInt16(byte_1, 4);
		int num2 = BitConverter.ToUInt16(byte_1, 6);
		ushort num3 = BitConverter.ToUInt16(byte_1, 8);
		if (num3 != ushort.MaxValue)
		{
			if (byte_1[10] == 0)
			{
				pivotField.class1173_0.string_0 = Encoding.ASCII.GetString(byte_1, 11, num3);
			}
			else
			{
				pivotField.class1173_0.string_0 = Encoding.Unicode.GetString(byte_1, 11, num3 * 2);
			}
		}
		for (int i = 0; i < num2; i++)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 == 178)
			{
				method_16();
				if (byte_1[0] == 0)
				{
					PivotItem pivotItem = new PivotItem(pivotField.PivotItems);
					pivotField.PivotItems.Add(pivotItem);
					pivotItem.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
					pivotItem.Index = BitConverter.ToUInt16(byte_1, 4);
					num3 = BitConverter.ToUInt16(byte_1, 6);
					if (num3 != ushort.MaxValue)
					{
						if (byte_1[8] == 0)
						{
							pivotItem.string_0 = Encoding.ASCII.GetString(byte_1, 9, num3);
						}
						else
						{
							pivotItem.string_0 = Encoding.Unicode.GetString(byte_1, 9, num3 * 2);
						}
					}
				}
				else if (byte_1[0] != 1)
				{
				}
				continue;
			}
			class1723_0.method_3(-2);
			break;
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 256)
		{
			method_16();
			Class1174 class1174_ = pivotField.class1174_0;
			class1174_.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
			class1174_.byte_0 = byte_1[2];
			class1174_.byte_1 = byte_1[3];
			class1174_.short_1 = BitConverter.ToInt16(byte_1, 4);
			class1174_.short_2 = BitConverter.ToInt16(byte_1, 6);
			class1174_.short_0 = BitConverter.ToInt16(byte_1, 8);
			class1174_.string_0 = worksheetCollection_0.method_46(class1174_.short_0);
			if (byte_1.Length <= 10)
			{
				return;
			}
			short num4 = BitConverter.ToInt16(byte_1, 10);
			if (num4 == -1)
			{
				return;
			}
			if (num4 + 21 <= byte_1.Length)
			{
				byte[] array = new byte[2 * num4];
				for (int j = 0; j < num4; j++)
				{
					array[2 * j] = byte_1[21 + j];
				}
				class1174_.string_1 = Encoding.Unicode.GetString(array, 0, array.Length);
				if (class1174_.string_1[0] == '?')
				{
					class1174_.string_1 = pivotField.class1173_0.string_0 + class1174_.string_1.Substring(1);
				}
			}
			else
			{
				class1174_.string_1 = Encoding.Unicode.GetString(byte_1, 20, num4 * 2);
			}
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_16()
	{
		class1730_0.method_5(class1723_0);
		byte_1 = class1730_0.method_105();
		ushort_1 = class1730_0.method_106();
	}

	private void method_17()
	{
		class1730_0.method_74(class1723_0, ushort_0);
		byte_1 = class1730_0.method_105();
	}
}
