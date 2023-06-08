using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns1;
using ns11;
using ns2;
using ns27;
using ns45;
using ns59;

namespace ns20;

internal class Class537
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Class982 class982_0;

	private readonly int int_0;

	public Class537(Workbook workbook_1, Class982 class982_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_1.Worksheets;
		int_0 = worksheetCollection_0.Count;
		class982_0 = class982_1;
	}

	internal void Write(Class1725 class1725_0, int[] int_1)
	{
		Class605 @class = new Class605(worksheetCollection_0.method_23());
		@class.vmethod_0(class1725_0);
		if (workbook_0.Settings.IsWriteProtected)
		{
			class1725_0.method_5(134);
		}
		if (worksheetCollection_0.method_28() != null)
		{
			Class635 class2 = new Class635();
			class2.method_4(worksheetCollection_0.method_28());
			class2.vmethod_0(class1725_0);
		}
		else if (workbook_0.Settings.Password != null && workbook_0.Settings.Password != "")
		{
			if (workbook_0.method_12() == EncryptionType.XOR)
			{
				Class635 class3 = new Class635();
				class3.method_5(workbook_0.Settings.Password);
				class3.vmethod_0(class1725_0);
			}
			else
			{
				Class1638 class4 = Class1638.smethod_0(workbook_0.Settings.Password, workbook_0.method_12(), workbook_0.method_14());
				Class635 class5 = new Class635();
				class5.method_6(class4);
				class5.vmethod_0(class1725_0);
				worksheetCollection_0.method_31(class4);
			}
		}
		if (workbook_0.Settings.IsWriteProtected)
		{
			Class636 class6 = new Class636(workbook_0);
			class6.vmethod_0(class1725_0);
		}
		if (worksheetCollection_0.method_50() != null && worksheetCollection_0.method_50().method_1() != null && worksheetCollection_0.method_50().method_1().Count != 0)
		{
			for (int i = 0; i < worksheetCollection_0.method_50().method_1().Count; i++)
			{
				byte[] byte_ = (byte[])worksheetCollection_0.method_50().method_1()[i];
				class1725_0.method_3(byte_);
			}
		}
		byte[] array = new byte[6] { 66, 0, 2, 0, 176, 4 };
		Array.Copy(BitConverter.GetBytes(workbook_0.Settings.short_0), 0, array, 4, 2);
		class1725_0.method_3(array);
		if (worksheetCollection_0.HasMacro)
		{
			class1725_0.method_5(211);
			if (worksheetCollection_0.method_19())
			{
				class1725_0.method_5(445);
			}
		}
		if (worksheetCollection_0.CodeName != null)
		{
			Class616 class7 = new Class616();
			class7.method_4(worksheetCollection_0.CodeName);
			class7.vmethod_0(class1725_0);
		}
		if (int_0 < 4113)
		{
			class1725_0.method_8(317);
			class1725_0.method_8(2 * int_0);
			for (int j = 1; j <= int_0; j++)
			{
				class1725_0.method_8(j);
			}
		}
		if (worksheetCollection_0.OleSize != null)
		{
			Class664 class8 = new Class664((CellArea)worksheetCollection_0.OleSize);
			class8.vmethod_0(class1725_0);
		}
		if (worksheetCollection_0.IsProtected)
		{
			class1725_0.method_8(25);
			class1725_0.method_8(2);
			if (worksheetCollection_0.method_77())
			{
				class1725_0.method_8(1);
			}
			else
			{
				class1725_0.method_8(0);
			}
			class1725_0.method_8(18);
			class1725_0.method_8(2);
			if (worksheetCollection_0.method_79())
			{
				class1725_0.method_8(1);
			}
			else
			{
				class1725_0.method_8(0);
			}
			class1725_0.method_8(19);
			if (worksheetCollection_0.method_81() == 0)
			{
				class1725_0.method_8(2);
				class1725_0.method_8(0);
			}
			else
			{
				class1725_0.method_8(2);
				class1725_0.method_6(worksheetCollection_0.method_81());
			}
		}
		if (worksheetCollection_0.method_50() != null)
		{
			worksheetCollection_0.method_50().method_9(class1725_0);
		}
		method_3(class1725_0);
		Class637 class9 = new Class637();
		Hashtable hashtable = new Hashtable();
		for (int k = 0; k < worksheetCollection_0.method_52().Count; k++)
		{
			Font font_ = (Font)worksheetCollection_0.method_52()[k];
			Class1685 class10 = class9.method_5(font_, FileFormatType.Default);
			if (class10 != null && class10.Count != 0)
			{
				hashtable[(k >= 4) ? (k + 1) : k] = class10;
			}
			class9.vmethod_0(class1725_0);
		}
		for (int l = 0; l < worksheetCollection_0.method_55().Count; l++)
		{
			Class639 class11 = (Class639)worksheetCollection_0.method_55()[l];
			class11.vmethod_0(class1725_0);
		}
		Class720 class12 = new Class720();
		Hashtable hashtable2 = new Hashtable();
		Class1735 class13 = new Class1735();
		if (class982_0 != null && class982_0.class978_0 != null)
		{
			for (int m = 0; m < class982_0.class978_0.int_3; m++)
			{
				Style style_ = worksheetCollection_0.method_58()[m];
				method_7(style_, m, class12, class13, hashtable, hashtable2);
				class12.vmethod_0(class1725_0);
			}
			for (int n = 0; n < class982_0.class978_0.arrayList_1.Count; n++)
			{
				Style style_2 = (Style)class982_0.class978_0.arrayList_1[n];
				method_7(style_2, n + class982_0.class978_0.int_3, class12, class13, hashtable, hashtable2);
				class12.vmethod_0(class1725_0);
			}
		}
		else
		{
			for (int num = 0; num < worksheetCollection_0.method_58().Count; num++)
			{
				Style style_3 = worksheetCollection_0.method_58()[num];
				method_7(style_3, num, class12, class13, hashtable, hashtable2);
				class12.vmethod_0(class1725_0);
			}
		}
		if (hashtable2.Count != 0)
		{
			Class587 class14 = new Class587();
			class14.method_4(worksheetCollection_0.method_58().Count, class13.Value);
			class14.vmethod_0(class1725_0);
			for (int num2 = 0; num2 < worksheetCollection_0.method_58().Count; num2++)
			{
				Class1685 class15 = (Class1685)hashtable2[num2];
				if (class15 != null)
				{
					Class588 class16 = new Class588();
					class16.method_4(num2, class15);
					class16.vmethod_0(class1725_0);
				}
			}
		}
		class13 = null;
		method_0(class1725_0);
		for (int num3 = 0; num3 < worksheetCollection_0.method_58().Count; num3++)
		{
			Style style = worksheetCollection_0.method_58()[num3];
			if (style.Name == null || !(style.Name != ""))
			{
				continue;
			}
			Class708 class17 = new Class708();
			string name;
			if ((name = style.Name) != null)
			{
				if (Class1742.dictionary_8 == null)
				{
					Class1742.dictionary_8 = new Dictionary<string, int>(6)
					{
						{ "Normal", 0 },
						{ "Comma", 1 },
						{ "Currency", 2 },
						{ "Percent", 3 },
						{ "Comma [0]", 4 },
						{ "Currency [0]", 5 }
					};
				}
				if (Class1742.dictionary_8.TryGetValue(name, out var value))
				{
					switch (value)
					{
					case 0:
						break;
					case 1:
						goto IL_0711;
					case 2:
						goto IL_071e;
					case 3:
						goto IL_072b;
					case 4:
						goto IL_0738;
					case 5:
						goto IL_0745;
					default:
						goto IL_0752;
					}
					class17.SetStyle((ushort)num3, 0);
					goto IL_0763;
				}
			}
			goto IL_0752;
			IL_0738:
			class17.SetStyle((ushort)num3, 6);
			goto IL_0763;
			IL_072b:
			class17.SetStyle((ushort)num3, 5);
			goto IL_0763;
			IL_071e:
			class17.SetStyle((ushort)num3, 4);
			goto IL_0763;
			IL_0711:
			class17.SetStyle((ushort)num3, 3);
			goto IL_0763;
			IL_0752:
			class17.SetStyle((ushort)num3, style.Name);
			goto IL_0763;
			IL_0763:
			class17.vmethod_0(class1725_0);
			continue;
			IL_0745:
			class17.SetStyle((ushort)num3, 7);
			goto IL_0763;
		}
		method_1(class1725_0);
		Class551 class18 = new Class551();
		class18.method_4(worksheetCollection_0.method_24());
		class18.vmethod_0(class1725_0);
		if (worksheetCollection_0.method_22() != null)
		{
			ArrayList arrayList = worksheetCollection_0.method_22();
			if (arrayList.Count > 0)
			{
				for (int num4 = 0; num4 < arrayList.Count; num4++)
				{
					byte[] array2 = (byte[])arrayList[num4];
					class1725_0.method_8(425);
					class1725_0.method_7((short)array2.Length);
					class1725_0.method_3(array2);
				}
				class1725_0.method_8(352);
				class1725_0.method_8(2);
				if (worksheetCollection_0.method_14())
				{
					class1725_0.method_8(1);
				}
				else
				{
					class1725_0.method_8(0);
				}
			}
		}
		if (worksheetCollection_0.method_90() != null && worksheetCollection_0.method_90().Count != 0)
		{
			foreach (Class1141 item in worksheetCollection_0.method_90())
			{
				item.method_17(class1725_0);
			}
		}
		if (worksheetCollection_0.method_14())
		{
			class1725_0.method_8(352);
			class1725_0.method_8(2);
			class1725_0.method_8(1);
		}
		for (int num5 = 0; num5 < int_0; num5++)
		{
			int_1[num5] = (int)(class1725_0.method_10() + 4);
			Worksheet worksheet = worksheetCollection_0[num5];
			string name2 = worksheet.Name;
			short num6 = worksheet.method_26();
			if (worksheet.Type == SheetType.VB)
			{
				num6 = (short)(num6 + 1536);
			}
			else if (worksheet.Type == SheetType.Chart)
			{
				num6 = (short)(num6 + 512);
			}
			else if (worksheet.Type == SheetType.BIFF4Macro)
			{
				num6 = (short)(num6 + 256);
			}
			Class608 class20 = new Class608(num6, name2, FileFormatType.Default);
			class20.vmethod_0(class1725_0);
		}
		Class620 class21 = new Class620(workbook_0.Settings.LanguageCode, workbook_0.Settings.Region);
		class21.vmethod_0(class1725_0);
		int int_2 = -1;
		if (worksheetCollection_0.method_39() != null && worksheetCollection_0.method_39().Count != 0)
		{
			for (int num7 = 0; num7 < worksheetCollection_0.method_39().Count; num7++)
			{
				Class1718 class22 = worksheetCollection_0.method_39()[num7];
				Class709 class23 = new Class709();
				class23.method_4(class22, int_0);
				class23.method_8(class1725_0);
				for (int num8 = 0; num8 < class22.method_0().Count; num8++)
				{
					Class631 class24 = new Class631();
					class24.method_4((Class1653)class22.method_0()[num8]);
					class24.vmethod_0(class1725_0);
				}
				if (class22.method_7() == null)
				{
					continue;
				}
				ArrayList arrayList2 = class22.method_7();
				for (int num9 = 0; num9 < arrayList2.Count; num9++)
				{
					Class1373 class25 = (Class1373)arrayList2[num9];
					if (class25 != null && class25.method_1())
					{
						method_4(class1725_0, class25, num9);
					}
				}
			}
		}
		method_6(class1725_0, int_2);
		method_5(class1725_0, int_2);
		Class674 class26 = new Class674(FileFormatType.Default);
		class26.vmethod_0(class1725_0);
		if (worksheetCollection_0.method_88() != null && worksheetCollection_0.method_88().method_0().Count != 0)
		{
			Class687 class27 = new Class687();
			class27.method_4(worksheetCollection_0, worksheetCollection_0.method_88());
			class27.method_5(class1725_0);
		}
		if (worksheetCollection_0.method_85() != null)
		{
			Class655 class28 = new Class655(worksheetCollection_0, 0);
			class28.method_5(worksheetCollection_0.method_85());
			class28.vmethod_0(class1725_0);
		}
		Class585 class29 = new Class585();
		if (class982_0 != null && class982_0.class978_0 != null)
		{
			class29.method_5(worksheetCollection_0.class1301_0, class982_0.class978_0);
		}
		else
		{
			class29.method_4(worksheetCollection_0.class1301_0);
		}
		class29.method_6(class1725_0, worksheetCollection_0);
		if (worksheetCollection_0.method_50() != null)
		{
			worksheetCollection_0.method_50().method_11(class1725_0);
			worksheetCollection_0.method_50().method_10(class1725_0);
		}
		if (workbook_0.class1569_0.method_0())
		{
			Class586 class30 = new Class586();
			class30.Write(workbook_0);
			class30.method_5(class1725_0);
		}
		Class581 class31 = new Class581(0, worksheetCollection_0.Workbook.Settings.CheckComptiliblity);
		class31.vmethod_0(class1725_0);
		Class630 class32 = new Class630();
		class32.vmethod_0(class1725_0);
	}

	private void method_0(Class1725 class1725_0)
	{
		TableStyleCollection tableStyleCollection = workbook_0.Worksheets.method_91();
		if (tableStyleCollection == null || tableStyleCollection.Count == 0)
		{
			return;
		}
		Class1337 @class = workbook_0.Worksheets.method_56();
		if (@class.Count != 0)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				Style style_ = @class[i];
				Class542 class2 = new Class542();
				class2.SetStyle(style_, bool_0: false, workbook_0);
				class2.vmethod_0(class1725_0);
			}
		}
	}

	private void method_1(Class1725 class1725_0)
	{
		TableStyleCollection tableStyleCollection = workbook_0.Worksheets.method_91();
		if (tableStyleCollection == null)
		{
			return;
		}
		int count = tableStyleCollection.Count;
		if (count != 0)
		{
			Class547 @class = new Class547(tableStyleCollection);
			@class.vmethod_0(class1725_0);
			for (int i = 0; i < count; i++)
			{
				TableStyle tableStyle_ = tableStyleCollection[i];
				method_2(tableStyle_, class1725_0);
			}
		}
	}

	private void method_2(TableStyle tableStyle_0, Class1725 class1725_0)
	{
		Class546 @class = new Class546(tableStyle_0);
		@class.vmethod_0(class1725_0);
		int count = tableStyle_0.TableStyleElements.Count;
		for (int i = 0; i < count; i++)
		{
			TableStyleElement tableStyleElement_ = tableStyle_0.TableStyleElements[i];
			Class545 class2 = new Class545(tableStyleElement_);
			class2.vmethod_0(class1725_0);
		}
	}

	private void method_3(Class1725 class1725_0)
	{
		WorkbookSettings settings = workbook_0.Settings;
		if (worksheetCollection_0.ActiveSheetIndex - worksheetCollection_0.FirstVisibleTab > 10)
		{
			worksheetCollection_0.FirstVisibleTab = worksheetCollection_0.ActiveSheetIndex - 10;
		}
		Class718 @class = new Class718(worksheetCollection_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_8(64);
		class1725_0.method_8(2);
		class1725_0.method_8(0);
		class1725_0.method_8(141);
		class1725_0.method_8(2);
		switch (settings.DisplayDrawingObjects)
		{
		default:
			class1725_0.method_8(0);
			break;
		case DisplayDrawingObjects.DisplayShapes:
			class1725_0.method_8(0);
			break;
		case DisplayDrawingObjects.Placeholders:
			class1725_0.method_8(1);
			break;
		case DisplayDrawingObjects.Hide:
			class1725_0.method_8(2);
			break;
		}
		class1725_0.method_8(34);
		class1725_0.method_8(2);
		if (settings.Date1904)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(14);
		class1725_0.method_8(2);
		if (settings.PrecisionAsDisplayed)
		{
			class1725_0.method_8(0);
		}
		else
		{
			class1725_0.method_8(1);
		}
		class1725_0.method_8(439);
		class1725_0.method_8(2);
		class1725_0.method_8(0);
		class1725_0.method_8(218);
		class1725_0.method_8(2);
		class1725_0.method_6(worksheetCollection_0.method_8());
	}

	private void method_4(Class1725 class1725_0, Class1373 class1373_0, int int_1)
	{
		byte[] array = new byte[8] { 89, 0, 4, 0, 0, 0, 0, 0 };
		Array.Copy(BitConverter.GetBytes((ushort)class1373_0.arrayList_0.Count), 0, array, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 6, 2);
		class1725_0.method_3(array);
		for (int i = 0; i < class1373_0.arrayList_0.Count; i++)
		{
			Class1117 @class = (Class1117)class1373_0.arrayList_0[i];
			if (@class.method_3())
			{
				Class621 class2 = new Class621();
				class2.method_6(@class);
				class2.vmethod_0(class1725_0);
			}
		}
	}

	private void method_5(Class1725 class1725_0, int int_1)
	{
		NameCollection names = worksheetCollection_0.Names;
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			Class659 @class = new Class659(name);
			@class.vmethod_0(class1725_0);
			if (name.Comment != null && name.Comment != "")
			{
				Class658 class2 = new Class658();
				class2.method_4(name);
				class2.vmethod_0(class1725_0);
			}
		}
	}

	private void method_6(Class1725 class1725_0, int int_1)
	{
		Class1303 @class = worksheetCollection_0.method_39();
		if (@class != null && @class.Count != 0)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				Class1718 class2 = @class[i];
				if (class2.method_12())
				{
					break;
				}
			}
		}
		Class632 class3 = new Class632(worksheetCollection_0.method_23());
		worksheetCollection_0.method_32().method_1(class3.arrayList_0);
		class3.vmethod_0(class1725_0);
	}

	private void method_7(Style style_0, int int_1, Class720 class720_0, Class1735 class1735_0, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		class720_0.Reset();
		class720_0.method_4((ushort)style_0.Font.method_21());
		Class1685 @class = class720_0.SetStyle(style_0, int_1);
		class1735_0.Update(class720_0.Data);
		Class1685 class2 = (Class1685)hashtable_0[style_0.Font.method_21()];
		if (class2 != null)
		{
			@class.Add(class2);
		}
		if (@class.Count != 0)
		{
			hashtable_1[int_1] = @class;
		}
	}
}
