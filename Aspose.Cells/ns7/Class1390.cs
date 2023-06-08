using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns1;
using ns2;
using ns27;
using ns52;
using ns59;

namespace ns7;

internal class Class1390
{
	private FileFormatType fileFormatType_0;

	private ChartCollection chartCollection_0;

	private Chart chart_0;

	private Class1725 class1725_0;

	private ArrayList arrayList_0;

	internal bool bool_0;

	private int int_0;

	private WorksheetCollection worksheetCollection_0;

	internal static byte[] smethod_0(Aspose.Cells.Font font_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		int length = font_0.Name.Length;
		int num = 32 + length * 2;
		byte[] array = new byte[num];
		Array.Copy(Encoding.Unicode.GetBytes(font_0.Name), 0, array, 0, length * 2);
		int num2 = length;
		Array.Copy(BitConverter.GetBytes(font_0.method_16()), 0, array, num2, 4);
		num2 += 4;
		if (font_0.IsBold)
		{
			array[num2] |= 1;
		}
		if (font_0.IsItalic)
		{
			array[num2] |= 2;
		}
		if (font_0.Underline != 0)
		{
			array[num2] |= 4;
		}
		if (font_0.IsStrikeout)
		{
			array[num2] |= 128;
		}
		array[num2 + 1] = 1;
		if (font_0.DoubleSize * 96.0 / 72.0 < 6.0)
		{
			array[num2 + 1] |= 2;
		}
		num2 += 2;
		Array.Copy(BitConverter.GetBytes(font_0.Weight), 0, array, num2, 2);
		num2 += 2;
		array[num2] = font_0.method_8();
		num2 += 2;
		switch (font_0.Underline)
		{
		case FontUnderlineType.Single:
			array[num2] = 1;
			break;
		case FontUnderlineType.Double:
			array[num2] = 2;
			break;
		case FontUnderlineType.Accounting:
			array[num2] = 33;
			break;
		case FontUnderlineType.DoubleAccounting:
			array[num2] = 34;
			break;
		}
		num2++;
		array[num2++] = font_0.method_11();
		array[num2++] = font_0.method_2();
		num2++;
		Color color = font_0.Color;
		array[num2++] = color.R;
		array[num2++] = color.G;
		array[num2++] = color.B;
		num2++;
		Array.Copy(BitConverter.GetBytes(int_1), 0, array, num2, 4);
		num2 += 4;
		array[num2++] = (byte)int_2;
		Array.Copy(BitConverter.GetBytes(int_3), 0, array, num2, 4);
		num2 += 4;
		Array.Copy(BitConverter.GetBytes(int_4), 0, array, num2, 4);
		num2 += 4;
		array[num2++] = (byte)int_5;
		return array;
	}

	internal Class1390(WorksheetCollection worksheetCollection_1, int int_1, ChartCollection chartCollection_1, Class1725 class1725_1)
	{
		fileFormatType_0 = worksheetCollection_1.method_23();
		chartCollection_0 = chartCollection_1;
		class1725_0 = class1725_1;
		worksheetCollection_0 = worksheetCollection_1;
		int_0 = int_1;
		method_0();
	}

	private void method_0()
	{
		if (chartCollection_0.Count == 0)
		{
			return;
		}
		Worksheet worksheet = worksheetCollection_0[int_0];
		switch (worksheet.Type)
		{
		case SheetType.Worksheet:
		{
			foreach (Chart item in chartCollection_0)
			{
				smethod_2(item);
			}
			break;
		}
		case SheetType.Chart:
			smethod_2(chartCollection_0[0]);
			break;
		}
	}

	private static void smethod_1(Chart chart_1, Interface45 interface45_0, int int_1, Class1725 class1725_1)
	{
		if (interface45_0 == null || (interface45_0.imethod_13() != Enum126.const_1 && interface45_0.imethod_13() != Enum126.const_6 && interface45_0.imethod_0() && !Class1674.smethod_12(interface45_0.imethod_4(), -1, -1, chart_1.method_14())))
		{
			return;
		}
		ArrayList arrayList = interface45_0.imethod_2();
		if (arrayList == null || arrayList.Count == 0)
		{
			return;
		}
		interface45_0.imethod_13();
		Class648 @class = new Class648();
		Class661 class2 = new Class661();
		for (int i = 0; i < arrayList.Count; i++)
		{
			if (arrayList[i] is string)
			{
				if (Class1673.smethod_8((string)arrayList[i]))
				{
					Class606 class3 = new Class606();
					byte byte_ = 0;
					string key;
					if ((key = (string)arrayList[i]) != null)
					{
						if (Class1742.dictionary_105 == null)
						{
							Class1742.dictionary_105 = new Dictionary<string, int>(7)
							{
								{ "#N/A", 0 },
								{ "#DIV/0!", 1 },
								{ "#NAME?", 2 },
								{ "#NULL!", 3 },
								{ "#NUM!", 4 },
								{ "#REF!", 5 },
								{ "#VALUE!", 6 }
							};
						}
						if (Class1742.dictionary_105.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								byte_ = 42;
								break;
							case 1:
								byte_ = 7;
								break;
							case 2:
								byte_ = 29;
								break;
							case 3:
								byte_ = 0;
								break;
							case 4:
								byte_ = 36;
								break;
							case 5:
								byte_ = 23;
								break;
							case 6:
								byte_ = 15;
								break;
							}
						}
					}
					class3.method_4((ushort)i, (byte)int_1, 0, byte_, bool_0: false);
					class3.vmethod_0(class1725_1);
				}
				else
				{
					@class.method_4((ushort)i, (ushort)int_1, 0, (string)arrayList[i]);
					@class.vmethod_0(class1725_1);
				}
			}
			else if (arrayList[i] is double)
			{
				class2.method_4((ushort)i, (ushort)int_1, 0, (double)arrayList[i]);
				class2.vmethod_0(class1725_1);
			}
		}
	}

	internal void method_1(Chart chart_1)
	{
		chart_0 = chart_1;
		method_7();
		Class677 @class = new Class677();
		@class.method_4(10);
		@class.vmethod_0(class1725_0);
		chart_1.method_55(class1725_0);
		Class671 class2 = new Class671(chart_1.PrintSize);
		class2.vmethod_0(class1725_0);
		class1725_0.method_3(new byte[6] { 18, 0, 2, 0, 0, 0 });
		class1725_0.method_3(new byte[6] { 1, 16, 2, 0, 0, 0 });
		if (worksheetCollection_0[int_0].Type == SheetType.Chart)
		{
			object obj = worksheetCollection_0[int_0].method_49();
			if (obj != null)
			{
				if (obj is ArrayList)
				{
					foreach (byte[] item in (ArrayList)obj)
					{
						class1725_0.method_3(item);
					}
				}
				else if (obj is byte[])
				{
					Class602 class3 = new Class602();
					class3.method_4((byte[])obj);
					class3.vmethod_0(class1725_0);
				}
			}
		}
		if (chart_1.method_35() != null && chart_1.method_35().Count != 0)
		{
			Class634 class4 = new Class634();
			foreach (Class1383 item2 in chart_1.method_35())
			{
				class4.method_4(item2);
				class4.vmethod_0(class1725_0);
			}
		}
		if (chart_1.PivotSource != null && chart_1.PivotSource != "")
		{
			Class683 class5 = new Class683();
			string text = chart_1.PivotSource;
			if (text.IndexOf('[') == -1)
			{
				text = "[Aspose.xls]" + text;
			}
			class5.SetDataSource(text);
			class5.vmethod_0(class1725_0);
			Class684 class6 = new Class684();
			class6.method_4(chart_1.HidePivotFieldButtons);
			class6.vmethod_0(class1725_0);
		}
		if (chart_1.method_16() != null && chart_1.method_16().Count != 0)
		{
			Class1710 class7 = new Class1710(worksheetCollection_0, worksheetCollection_0[int_0], chart_1.Shapes, class1725_0);
			class7.method_0();
		}
		method_9();
		method_6();
		method_2();
		if (worksheetCollection_0[int_0].Type == SheetType.Chart)
		{
			string codeName = worksheetCollection_0[int_0].CodeName;
			if (codeName != null && codeName != "")
			{
				Class616 class8 = new Class616();
				class8.method_4(codeName);
				class8.vmethod_0(class1725_0);
			}
			if (!worksheetCollection_0[int_0].internalColor_0.method_2())
			{
				int num = worksheetCollection_0[int_0].method_41();
				if (num != 64)
				{
					Class686 class9 = new Class686(num, worksheetCollection_0[int_0].internalColor_0);
					class9.vmethod_0(class1725_0);
				}
			}
		}
		if (chart_0.method_4() != null)
		{
			foreach (byte[] item3 in chart_1.method_3())
			{
				class1725_0.method_3(item3);
			}
		}
		method_8();
		chart_0.method_26(bool_9: false);
	}

	private void method_2()
	{
		if (worksheetCollection_0[int_0].Type == SheetType.Chart && chart_0 == worksheetCollection_0[int_0].Charts[0])
		{
			class1725_0.method_8(574);
			class1725_0.method_8(10);
			if (int_0 == worksheetCollection_0.ActiveSheetIndex)
			{
				class1725_0.method_8(1538);
			}
			else
			{
				class1725_0.method_8(2);
			}
			class1725_0.method_5(0);
			class1725_0.method_5(0);
			method_14();
		}
	}

	private void method_3()
	{
		for (int i = 0; i < chart_0.NSeries.Count; i++)
		{
			Interface45 interface45_ = chart_0.NSeries[i].method_16();
			smethod_1(chart_0, interface45_, i, class1725_0);
		}
		if (arrayList_0 == null || arrayList_0.Count <= chart_0.NSeries.Count)
		{
			return;
		}
		for (int j = chart_0.NSeries.Count; j < arrayList_0.Count; j++)
		{
			Class1690 @class = (Class1690)arrayList_0[j];
			if (@class.byte_0 != 2)
			{
				continue;
			}
			ErrorBar errorBar = (ErrorBar)@class.object_0;
			if (errorBar.method_33())
			{
				if (@class.bool_0)
				{
					smethod_1(chart_0, errorBar.method_35(), j, class1725_0);
				}
				else
				{
					smethod_1(chart_0, errorBar.method_37(), j, class1725_0);
				}
			}
		}
	}

	private void method_4()
	{
		for (int i = 0; i < chart_0.NSeries.Count; i++)
		{
			Interface45 interface45_ = chart_0.NSeries[i].method_18();
			smethod_1(chart_0, interface45_, i, class1725_0);
		}
		if (arrayList_0 == null || arrayList_0.Count <= chart_0.NSeries.Count)
		{
			return;
		}
		for (int j = chart_0.NSeries.Count; j < arrayList_0.Count; j++)
		{
			Class1690 @class = (Class1690)arrayList_0[j];
			if (@class.byte_0 != 2)
			{
				continue;
			}
			ErrorBar errorBar = (ErrorBar)@class.object_0;
			if (!errorBar.method_33())
			{
				if (@class.bool_0)
				{
					smethod_1(chart_0, errorBar.method_35(), j, class1725_0);
				}
				else
				{
					smethod_1(chart_0, errorBar.method_37(), j, class1725_0);
				}
			}
		}
	}

	internal void method_5()
	{
		if (ChartCollection.smethod_17(chart_0.Type))
		{
			for (int i = 0; i < chart_0.NSeries.Count; i++)
			{
				Interface45 interface45_ = chart_0.NSeries[i].method_20();
				smethod_1(chart_0, interface45_, i, class1725_0);
			}
		}
	}

	private void method_6()
	{
		Class704 @class = new Class704(2);
		@class.vmethod_0(class1725_0);
		method_4();
		@class = new Class704(1);
		@class.vmethod_0(class1725_0);
		method_3();
		@class = new Class704(3);
		@class.vmethod_0(class1725_0);
		method_5();
	}

	private void method_7()
	{
		Class605 @class = new Class605(SheetType.Chart, worksheetCollection_0.method_23());
		@class.vmethod_0(class1725_0);
	}

	private void method_8()
	{
		Class630 @class = new Class630();
		@class.vmethod_0(class1725_0);
	}

	private void method_9()
	{
		Class1328 @class = new Class1328(worksheetCollection_0, int_0, chart_0, this, class1725_0);
		@class.method_13();
		method_13();
		class1725_0.method_5(4147);
		Class679 class2 = new Class679();
		class2.method_4(13, 0, 0, 0);
		class2.vmethod_0(class1725_0);
		bool_0 = true;
		if (chart_0.arrayList_0 != null)
		{
			for (int i = 0; i < chart_0.arrayList_0.Count; i++)
			{
				byte[] byte_ = (byte[])chart_0.arrayList_0[i];
				class1725_0.method_3(byte_);
			}
		}
		@class.method_23(chart_0.ValueAxis, chart_0.SecondValueAxis);
		method_14();
		method_15();
		if (chart_0.ChartArea.Border.IsVisible || chart_0.ChartArea.Area.Formatting != FormattingType.None || !chart_0.IsRectangularCornered)
		{
			chart_0.ChartArea.Area.InvertIfNegative = !chart_0.IsRectangularCornered;
			method_16(chart_0.ChartArea, bool_1: true);
		}
		Class1329 class3 = new Class1329(class1725_0, worksheetCollection_0, int_0, chart_0);
		arrayList_0 = class3.method_3();
		method_18(2);
		method_18(3);
		@class.Write();
		method_12();
		if (chart_0.ShowDataTable)
		{
			method_11();
		}
		class3.method_9(chart_0);
		PlotArea plotArea = chart_0.PlotArea;
		bool flag = (chart_0.method_10() & 0x10) != 0;
		if (plotArea.byte_1 != null && !flag)
		{
			if ((chart_0.method_10() & 8) != 0 == flag)
			{
				plotArea.byte_1[12] = 1;
			}
			else
			{
				plotArea.byte_1[12] = 0;
			}
			Class548 class4 = new Class548();
			class4.method_3(plotArea.byte_1);
			class4.vmethod_0(class1725_0);
		}
		if (bool_0)
		{
			Class680 class5 = new Class680();
			class5.method_4(13, 0, 0, 0);
			class5.vmethod_0(class1725_0);
			bool_0 = false;
		}
		class1725_0.method_5(4148);
	}

	private void method_10(Aspose.Cells.Font font_0, int int_1, int int_2, ArrayList arrayList_1)
	{
		if (font_0 == null && int_1 == -1)
		{
			return;
		}
		if (font_0 != null)
		{
			int_1 = font_0.method_21();
		}
		if (arrayList_1 != null)
		{
			Class593 @class = new Class593();
			int num = @class.method_4(int_2, int_1, arrayList_1);
			if (num == -1)
			{
				Class638 class2 = new Class638(int_1);
				class2.vmethod_0(class1725_0);
				@class.vmethod_0(class1725_0);
			}
			else
			{
				Class638 class3 = new Class638(num);
				class3.vmethod_0(class1725_0);
			}
		}
		else
		{
			Class638 class4 = new Class638(int_1);
			class4.vmethod_0(class1725_0);
		}
	}

	private void method_11()
	{
		ChartDataTable chartDataTable = chart_0.ChartDataTable;
		Class623 @class = new Class623();
		if (chartDataTable != null)
		{
			@class.method_4(chartDataTable);
		}
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class649 class2 = new Class649(fileFormatType_0);
		class2.method_4();
		class2.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Aspose.Cells.Font font_ = null;
		if (chart_0.method_25() != null)
		{
			font_ = chart_0.method_25().method_0();
		}
		Class713 class3 = new Class713(fileFormatType_0);
		class3.method_5(font_);
		if (chart_0.method_25() != null)
		{
			class3.method_10(chart_0.method_25().BackgroundMode);
		}
		class3.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		method_10(font_, chartDataTable.method_1(), 0, null);
		Class592 class4 = new Class592();
		class4.method_5();
		class4.vmethod_0(class1725_0);
		class1725_0.method_5(4148);
		if (chartDataTable != null && chartDataTable.method_4() != null && !chartDataTable.method_4().IsAuto)
		{
			Class641 class5 = new Class641(3);
			class5.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			Class651 class6 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class6.method_6(chartDataTable.Border, bool_0: false);
			class6.vmethod_0(class1725_0);
			Class594 class7 = new Class594(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class7.vmethod_0(class1725_0);
			class1725_0.method_5(4148);
		}
		class1725_0.method_5(4148);
		class1725_0.method_5(4148);
	}

	private void method_12()
	{
		Title title = chart_0.method_20();
		if (title != null)
		{
			Class713 @class = new Class713(fileFormatType_0);
			@class.method_7(title);
			@class.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			if (title.Text != null && title.Text != "")
			{
				Class669 class2 = new Class669(bool_0: false);
				class2.method_6(title);
				class2.vmethod_0(class1725_0);
				method_10(title.method_12(), title.method_13(), title.Text.Length, title.method_39());
				Class592 class3 = new Class592();
				class3.method_6(title.byte_1);
				class3.vmethod_0(class1725_0);
				Class700 class4 = new Class700(fileFormatType_0, title.Text);
				class4.vmethod_0(class1725_0);
			}
			else
			{
				Class669 class5 = new Class669(bool_0: false);
				class5.method_6(title);
				class5.vmethod_0(class1725_0);
				method_10(title.method_12(), title.method_13(), 0, null);
				Class592 class6 = new Class592();
				class6.method_6(title.byte_1);
				class6.vmethod_0(class1725_0);
			}
			if (!title.IsDeleted && title.method_42())
			{
				method_16(title, bool_1: false);
			}
			Class662 class7 = new Class662();
			class7.method_4(1);
			class7.vmethod_0(class1725_0);
			class1725_0.method_5(4148);
		}
	}

	private void method_13()
	{
		Class615 @class = new Class615(chart_0);
		@class.vmethod_0(class1725_0);
	}

	private void method_14()
	{
		if (worksheetCollection_0[int_0].Type != SheetType.Chart)
		{
			class1725_0.method_8(160);
			class1725_0.method_8(4);
			class1725_0.method_5(65537);
		}
		else
		{
			Class694 @class = new Class694(worksheetCollection_0[int_0].Zoom);
			@class.vmethod_0(class1725_0);
		}
	}

	private void method_15()
	{
		byte[] array = new byte[12]
		{
			100, 16, 8, 0, 0, 0, 0, 0, 0, 0,
			0, 0
		};
		int num = 4;
		double num2 = 0.0;
		num2 = chart_0.method_49();
		if (num2 - (double)(int)num2 != 0.0)
		{
			Array.Copy(BitConverter.GetBytes((ushort)((num2 - (double)(int)num2) * 65536.0)), 0, array, num, 2);
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, num + 2, 2);
		num += 4;
		num2 = chart_0.method_51();
		if (num2 - (double)(int)num2 != 0.0)
		{
			Array.Copy(BitConverter.GetBytes((ushort)((num2 - (double)(int)num2) * 65536.0)), 0, array, num, 2);
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, num + 2, 2);
		num += 4;
		class1725_0.method_3(array);
	}

	private void method_16(ChartFrame chartFrame_0, bool bool_1)
	{
		Class641 @class = (bool_1 ? new Class641(2) : ((chartFrame_0.IsAutoSize && chartFrame_0.method_17()) ? new Class641(3) : (chartFrame_0.method_17() ? new Class641(2) : ((!chartFrame_0.IsAutoSize) ? new Class641(2) : new Class641(3)))));
		@class.method_4(chartFrame_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
		class2.method_6(chartFrame_0.Border, bool_0: false);
		class2.vmethod_0(class1725_0);
		method_17(chartFrame_0.Area);
		class1725_0.method_5(4148);
	}

	private void method_17(Area area_0)
	{
		if (area_0 != null)
		{
			Class594 @class = new Class594(fileFormatType_0, worksheetCollection_0.method_24());
			@class.method_4(area_0);
			@class.vmethod_0(class1725_0);
			if (area_0.method_0())
			{
				Class643 class2 = new Class643();
				class2.method_4(area_0.FillFormat);
				class2.vmethod_0(class1725_0);
			}
			else if (@class.method_5())
			{
				Class643 class3 = new Class643();
				class3.method_8(area_0);
				class3.vmethod_0(class1725_0);
			}
		}
	}

	private void method_18(short short_0)
	{
		method_19(short_0);
		Class713 @class = new Class713(fileFormatType_0);
		@class.method_9(chart_0.ChartArea);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class669 class2 = new Class669(bool_0: false);
		class2.vmethod_0(class1725_0);
		if (chart_0.ChartArea.AutoScaleFont)
		{
			int int_ = 0;
			ChartArea chartArea = chart_0.ChartArea;
			switch (short_0)
			{
			case 2:
				if (chartArea.method_12() == null && chartArea.method_13() != -1)
				{
					int_ = chartArea.method_13();
				}
				else if (chart_0.method_35().Count > 0)
				{
					Class1383 class4 = (Class1383)chart_0.method_35()[0];
					int_ = class4.int_0;
				}
				break;
			case 3:
				if (chartArea.method_12() == null && chartArea.method_39() != -1)
				{
					int_ = chartArea.method_39();
				}
				else if (chart_0.method_35().Count > 1)
				{
					Class1383 class3 = (Class1383)chart_0.method_35()[1];
					int_ = class3.int_0;
				}
				break;
			}
			method_10(null, int_, 0, null);
		}
		else
		{
			method_10(chart_0.ChartArea.method_12(), chart_0.ChartArea.method_13(), 0, null);
		}
		class1725_0.method_8(4177);
		class1725_0.method_8(8);
		class1725_0.method_8(256);
		class1725_0.method_5(0);
		class1725_0.method_8(0);
		class1725_0.method_5(4148);
	}

	private void method_19(short short_0)
	{
		class1725_0.method_8(4132);
		class1725_0.method_8(2);
		class1725_0.method_7(short_0);
	}

	private static void smethod_2(Chart chart_1)
	{
	}
}
