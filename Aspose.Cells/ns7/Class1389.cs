using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns27;
using ns52;
using ns59;

namespace ns7;

internal class Class1389
{
	private ChartCollection chartCollection_0;

	private Chart chart_0;

	private Class1730 class1730_0;

	private byte[] byte_0;

	private Class1723 class1723_0;

	private ushort ushort_0;

	private byte[] byte_1;

	private ushort ushort_1;

	private Palette palette_0;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private bool bool_0;

	private int int_0;

	private ArrayList arrayList_0;

	private bool bool_1;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private Hashtable hashtable_0;

	private byte byte_2;

	private int int_1;

	private Class1330 class1330_0;

	private bool bool_2;

	private int int_2;

	private int int_3;

	internal Class1389(Class1730 class1730_1, Class1723 class1723_1, WorksheetCollection worksheetCollection_1, Worksheet worksheet_1)
	{
		class1730_0 = class1730_1;
		class1723_0 = class1723_1;
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
		palette_0 = worksheetCollection_1.method_24();
		chartCollection_0 = worksheet_1.Charts;
		byte_0 = new byte[2];
		arrayList_0 = new ArrayList();
		arrayList_2 = new ArrayList();
	}

	internal void method_0(Chart chart_1)
	{
		chart_1.method_57(Enum19.const_2);
		bool_2 = false;
		int_1 = 0;
		chart_0 = chart_1;
		chart_0.ShowLegend = false;
		bool_1 = false;
		bool_0 = false;
		chart_1.method_35().Clear();
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 2150:
				class1730_0.method_96(class1723_0, chart_1.PageSetup);
				break;
			case 2146:
				method_4();
				break;
			case 2136:
				method_8();
				break;
			case 2138:
				method_16();
				break;
			case 2215:
				method_5(class1723_0);
				break;
			case 2204:
			case 2206:
			{
				method_1();
				byte[] array = new byte[ushort_1 + 4];
				Array.Copy(BitConverter.GetBytes(ushort_0), 0, array, 0, 2);
				Array.Copy(BitConverter.GetBytes(ushort_1), 0, array, 2, 2);
				Array.Copy(byte_1, 0, array, 4, ushort_1);
				chart_0.method_3().Add(array);
				break;
			}
			case 2154:
			{
				Class1330 class3 = method_26(null, bool_3: false);
				if (class3.method_50() != null)
				{
					class3.method_60(chart_1, arrayList_2, null);
				}
				break;
			}
			case 4147:
				method_94();
				break;
			case 4148:
				method_95();
				break;
			case 4132:
				method_62();
				break;
			case 4133:
			{
				Class1330 class2 = new Class1330(worksheetCollection_0, chart_0);
				method_63(class2, bool_3: true);
				if (class2.method_50() != null)
				{
					switch (class2.method_49().byte_0)
					{
					case 4:
						class2.method_60(chart_1, arrayList_2, arrayList_1);
						break;
					case 1:
						class2.method_57(chart_0.Title);
						break;
					}
				}
				break;
			}
			case 4098:
				method_59();
				break;
			case 4099:
			{
				Series series_ = new Series(worksheetCollection_0, chart_1.NSeries, chart_1.NSeries.Count);
				method_71(series_);
				break;
			}
			case 4192:
				method_18(chart_0.method_35());
				break;
			case 4195:
				method_14();
				break;
			case 4196:
				method_60();
				break;
			case 4197:
				method_9();
				break;
			case 4164:
				method_75();
				method_57();
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4166:
				method_56();
				break;
			case 4161:
				method_22();
				break;
			case 20:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.method_27(byte_1);
				}
				break;
			case 21:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.method_28(byte_1);
				}
				break;
			case 160:
				if (worksheet_0.Type == SheetType.Chart)
				{
					method_1();
					worksheet_0.Zoom = (int)((double)((float)(int)BitConverter.ToUInt16(byte_1, 0) * 100f / (float)(int)BitConverter.ToUInt16(byte_1, 2)) + 0.5);
				}
				else
				{
					class1723_0.method_3(6);
				}
				break;
			case 161:
				method_1();
				if (byte_1 != null && byte_1.Length != 0 && !chart_1.PageSetup.method_0())
				{
					chart_1.PageSetup.method_11(byte_1);
					chart_1.PageSetup.method_1(bool_14: true);
				}
				break;
			case 51:
				method_1();
				switch (byte_1[0])
				{
				case 1:
					chart_1.PrintSize = PrintSizeType.Custom;
					break;
				case 2:
					chart_1.PrintSize = PrintSizeType.Fit;
					break;
				case 3:
					chart_1.PrintSize = PrintSizeType.Full;
					break;
				}
				break;
			case 38:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.LeftMarginInch = BitConverter.ToDouble(byte_1, 0);
				}
				break;
			case 39:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.RightMarginInch = BitConverter.ToDouble(byte_1, 0);
				}
				break;
			case 40:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.TopMarginInch = BitConverter.ToDouble(byte_1, 0);
				}
				break;
			case 41:
				method_1();
				if (byte_1 != null && byte_1.Length != 0)
				{
					chart_1.PageSetup.BottomMarginInch = BitConverter.ToDouble(byte_1, 0);
				}
				break;
			case 442:
				if (worksheet_0.Type == SheetType.Chart)
				{
					method_7();
					break;
				}
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 236:
			{
				Class1709 @class = new Class1709(class1730_0, class1723_0, worksheetCollection_0, worksheet_0, chart_0);
				@class.method_1();
				break;
			}
			case 233:
				method_6(class1723_0);
				break;
			case 2129:
				method_17();
				break;
			case 2057:
				method_93();
				break;
			case 574:
				if (worksheet_0.Type == SheetType.Chart)
				{
					method_1();
					if ((byte_1[2] & 6u) != 0)
					{
						worksheetCollection_0.ActiveSheetIndex = worksheet_0.SheetIndex;
					}
				}
				else
				{
					ushort_1 = class1723_0.method_2(byte_0);
					class1723_0.method_3(ushort_1);
				}
				break;
			case 10:
				method_92();
				method_20();
				return;
			}
		}
	}

	private void method_1()
	{
		class1730_0.method_5(class1723_0);
		byte_1 = class1730_0.method_105();
		ushort_1 = class1730_0.method_106();
	}

	private void method_2(int int_4)
	{
		class1730_0.method_74(class1723_0, int_4);
		byte_1 = class1730_0.method_105();
		ushort_1 = class1730_0.method_106();
	}

	private void method_3()
	{
		class1730_0.method_73(class1723_0);
		byte_1 = class1730_0.method_105();
		ushort_1 = class1730_0.method_106();
	}

	private void method_4()
	{
		method_1();
		int num = BitConverter.ToInt32(byte_1, 16);
		if (num <= 65)
		{
			worksheet_0.method_40(BitConverter.ToInt32(byte_1, 16));
		}
	}

	private void method_5(Class1723 class1723_1)
	{
		method_1();
		PlotArea plotArea = chart_0.PlotArea;
		plotArea.byte_1 = new byte[ushort_1];
		Array.Copy(byte_1, 0, plotArea.byte_1, 0, ushort_1);
	}

	private void method_6(Class1723 class1723_1)
	{
		ArrayList arrayList = new ArrayList();
		class1723_1.method_3(-2);
		method_3();
		arrayList.Add(byte_1);
		int num = byte_1.Length - 12;
		int num2 = BitConverter.ToInt32(byte_1, 8);
		num2 -= num;
		while (num2 > 0)
		{
			method_3();
			int num3 = BitConverter.ToInt16(byte_1, 0);
			if (num3 == 233 || num3 == 60)
			{
				arrayList.Add(byte_1);
				num2 -= byte_1.Length - 4;
				continue;
			}
			throw new IOException("File is corrupted");
		}
		worksheet_0.method_48(arrayList);
	}

	private void method_7()
	{
		method_1();
		if (byte_1[2] == 0)
		{
			worksheet_0.method_46(Class937.smethod_3(byte_1, 3, byte_1.Length - 3));
		}
		else
		{
			worksheet_0.method_46(Encoding.Unicode.GetString(byte_1, 3, byte_1.Length - 3));
		}
	}

	private void method_8()
	{
		method_1();
		string text = Encoding.Unicode.GetString(byte_1, 8, byte_1.Length - 8);
		if (text != null && text.Length > 0)
		{
			text = text.Trim();
			if (text[0] == '[')
			{
				int num = text.IndexOf(']');
				if (num != -1)
				{
					text = ((text.Length <= num + 1) ? null : text.Substring(num + 1));
				}
			}
		}
		if (text != null && text.Length > 0)
		{
			chart_0.PivotSource = text;
		}
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 == 2137)
		{
			method_1();
			chart_0.HidePivotFieldButtons = byte_1[4] != 0;
		}
		else
		{
			class1723_0.method_3(-2);
		}
	}

	private void method_9()
	{
		method_1();
		byte byte_ = byte_1[0];
		ushort rowIndex = 0;
		ushort colIndex = 0;
		double num = 0.0;
		ArrayList[] array = new ArrayList[arrayList_2.Count];
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4197:
				method_10(array, byte_);
				method_1();
				byte_ = byte_1[0];
				array = new ArrayList[arrayList_2.Count];
				break;
			case 513:
				method_1();
				rowIndex = BitConverter.ToUInt16(byte_1, 0);
				colIndex = BitConverter.ToUInt16(byte_1, 2);
				if (array[colIndex] == null)
				{
					array[colIndex] = new ArrayList();
				}
				array[colIndex].Add(new Class1693(rowIndex, bool_2: false, bool_3: false, ""));
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 515:
				num = method_11(out rowIndex, out colIndex);
				if (array[colIndex] == null)
				{
					array[colIndex] = new ArrayList();
				}
				array[colIndex].Add(new Class1693(rowIndex, bool_2: true, bool_3: false, num));
				break;
			case 516:
			{
				string object_ = method_13(out rowIndex, out colIndex);
				if (array[colIndex] == null)
				{
					array[colIndex] = new ArrayList();
				}
				array[colIndex].Add(new Class1693(rowIndex, bool_2: false, bool_3: false, object_));
				break;
			}
			case 517:
			{
				string object_ = method_12(out rowIndex, out colIndex);
				if (array[colIndex] == null)
				{
					array[colIndex] = new ArrayList();
				}
				array[colIndex].Add(new Class1693(rowIndex, bool_2: false, bool_3: true, object_));
				break;
			}
			case 10:
			case 442:
			case 2128:
				method_10(array, byte_);
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private void method_10(ArrayList[] arrayList_3, byte byte_3)
	{
		int num = 0;
		Class1693 @class = null;
		for (int i = 0; i < arrayList_3.Length; i++)
		{
			if (arrayList_3[i] == null || arrayList_3[i].Count == 0)
			{
				continue;
			}
			Class1690 class2 = (Class1690)arrayList_2[i];
			Interface45 @interface = Class1195.smethod_0(worksheetCollection_0, worksheet_0);
			Enum126 @enum = Enum126.const_1;
			num = 0;
			arrayList_3[i].Sort(new Class1134());
			ArrayList arrayList = new ArrayList();
			for (int j = 0; j < arrayList_3[i].Count; j++)
			{
				@class = (Class1693)arrayList_3[i][j];
				if (!@class.bool_1 && !@class.bool_0)
				{
					@enum = Enum126.const_6;
					break;
				}
			}
			for (int k = 0; k < arrayList_3[i].Count; k++)
			{
				@class = (Class1693)arrayList_3[i][k];
				if (@class.ushort_0 - num != 1)
				{
					for (; num < @class.ushort_0 - 1; num++)
					{
						if (@enum == Enum126.const_6)
						{
							arrayList.Add("0");
						}
						else
						{
							arrayList.Add(0.0);
						}
					}
				}
				arrayList.Add(@class.object_0);
				num = @class.ushort_0;
			}
			@interface.imethod_3(arrayList);
			@interface.imethod_14(@enum);
			if (class2.byte_0 == 0)
			{
				Series series = (Series)class2.object_0;
				switch (byte_3)
				{
				case 1:
					if (series.method_16() == null)
					{
						series.method_17(@interface);
					}
					else
					{
						series.method_16().imethod_3(arrayList);
					}
					break;
				case 2:
					if (series.method_18() == null)
					{
						series.method_19(@interface);
					}
					else
					{
						series.method_18().imethod_3(arrayList);
					}
					break;
				case 3:
					if (series.method_20() == null)
					{
						series.method_21(@interface);
					}
					else
					{
						series.method_20().imethod_3(arrayList);
					}
					break;
				}
			}
			else
			{
				if (class2.byte_0 != 2)
				{
					continue;
				}
				ErrorBar errorBar = (ErrorBar)class2.object_0;
				if (class2.bool_0)
				{
					if (errorBar.method_35() == null)
					{
						errorBar.method_36(@interface);
					}
					else
					{
						errorBar.method_35().imethod_3(arrayList);
					}
				}
				else if (errorBar.method_37() == null)
				{
					errorBar.method_38(@interface);
				}
				else
				{
					errorBar.method_37().imethod_3(arrayList);
				}
			}
		}
	}

	private double method_11(out ushort rowIndex, out ushort colIndex)
	{
		method_1();
		rowIndex = BitConverter.ToUInt16(byte_1, 0);
		colIndex = BitConverter.ToUInt16(byte_1, 2);
		return BitConverter.ToDouble(byte_1, 6);
	}

	private string method_12(out ushort rowIndex, out ushort colIndex)
	{
		method_1();
		rowIndex = BitConverter.ToUInt16(byte_1, 0);
		colIndex = BitConverter.ToUInt16(byte_1, 2);
		return byte_1[6] switch
		{
			15 => "#VALUE!", 
			7 => "#DIV/0!", 
			0 => "#NULL!", 
			29 => "#NAME?", 
			23 => "#REF!", 
			42 => "#N/A", 
			36 => "#NUM!", 
			_ => "#N/A", 
		};
	}

	private string method_13(out ushort rowIndex, out ushort colIndex)
	{
		method_1();
		rowIndex = BitConverter.ToUInt16(byte_1, 0);
		colIndex = BitConverter.ToUInt16(byte_1, 2);
		int num = BitConverter.ToUInt16(byte_1, 6);
		if (num == 0)
		{
			return "";
		}
		if (byte_1[8] == 0)
		{
			return Encoding.ASCII.GetString(byte_1, 9, num);
		}
		return Encoding.Unicode.GetString(byte_1, 9, 2 * num);
	}

	private void method_14()
	{
		chart_0.ShowDataTable = true;
		method_15();
		int num = 0;
		ChartDataTable chartDataTable = chart_0.ChartDataTable;
		Class1330 @class = new Class1330(worksheetCollection_0, chart_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4146:
				method_61(@class);
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					@class?.method_56(chartDataTable);
					return;
				}
				break;
			case 4133:
				method_63(@class, bool_3: false);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_15()
	{
		method_1();
		chart_0.ChartDataTable.HasBorderHorizontal = (byte_1[0] & 1) != 0;
		chart_0.ChartDataTable.HasBorderVertical = (byte_1[0] & 2) != 0;
		chart_0.ChartDataTable.HasBorderOutline = (byte_1[0] & 4) != 0;
		chart_0.ChartDataTable.ShowLegendKey = (byte_1[0] & 8) != 0;
	}

	private void method_16()
	{
		method_2(ushort_0);
		ArrayList arrayList = new ArrayList();
		chart_0.arrayList_0 = arrayList;
		arrayList.Add(byte_1);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 2129:
			case 2132:
			case 2133:
				break;
			default:
				class1723_0.method_3(-2);
				return;
			}
			method_2(ushort_0);
			arrayList.Add(byte_1);
		}
	}

	private void method_17()
	{
		class1723_0.method_3(-2);
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 2130:
			case 2131:
			case 2132:
			case 2133:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 2129:
				num = class1723_0.method_2(byte_0);
				class1723_0.method_3(4);
				ushort_0 = class1723_0.method_2(byte_0);
				switch (ushort_0)
				{
				case 4192:
					method_18(arrayList_0);
					break;
				default:
					class1723_0.method_3(num - 6);
					break;
				case 10:
				case 574:
					throw new IOException("File is corrupted");
				}
				break;
			default:
				class1723_0.method_3(-2);
				return;
			}
		}
	}

	private void method_18(ArrayList arrayList_3)
	{
		method_1();
		Class1383 @class = new Class1383(chart_0, 0, bool_0: false);
		@class.ushort_0 = BitConverter.ToUInt16(byte_1, 0);
		@class.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
		@class.ushort_3 = BitConverter.ToUInt16(byte_1, 4);
		@class.ushort_2 = BitConverter.ToUInt16(byte_1, 6);
		@class.int_0 = BitConverter.ToUInt16(byte_1, 8);
		arrayList_3.Add(@class);
	}

	private int method_19()
	{
		method_1();
		int num = BitConverter.ToUInt16(byte_1, 0);
		if (num == 65535)
		{
			num = 0;
		}
		return num;
	}

	private void method_20()
	{
		if (!bool_1)
		{
			chart_0.PlotArea.Area.Formatting = FormattingType.None;
			chart_0.PlotArea.Border.IsVisible = false;
		}
		ChartType chartType = chart_0.method_18().method_2(bool_0: false).method_11();
		int count = chart_0.method_18().Count;
		if (chart_0.NSeries.Count == 3 && count == 1 && chartType == ChartType.Line)
		{
			if (chart_0.class1388_0[0].HasHiLoLines)
			{
				chartType = ChartType.StockHighLowClose;
			}
		}
		else if (chart_0.NSeries.Count == 4)
		{
			switch (count)
			{
			case 1:
				if (chartType == ChartType.Line && chart_0.method_18()[0].HasUpDownBars)
				{
					chartType = ChartType.StockOpenHighLowClose;
				}
				break;
			case 2:
				if (!chart_0.method_18()[0].PlotOnSecondAxis && chart_0.method_18()[1].PlotOnSecondAxis && chartType == ChartType.Column && chart_0.method_18()[1].method_11() == ChartType.Line)
				{
					chartType = ChartType.StockVolumeHighLowClose;
				}
				break;
			}
		}
		else if (chart_0.NSeries.Count == 5 && count == 2 && !chart_0.method_18()[0].PlotOnSecondAxis && chart_0.method_18()[1].PlotOnSecondAxis && chartType == ChartType.Column && chart_0.method_18()[1].method_11() == ChartType.Line && chart_0.method_18()[1].HasUpDownBars)
		{
			chartType = ChartType.StockVolumeOpenHighLowClose;
		}
		chart_0.method_19(chartType);
		foreach (Series item in chart_0.NSeries)
		{
			if (item.method_16() != null && item.method_3() != null)
			{
				item.method_3().method_4();
			}
		}
		if (chart_0.method_16() != null && chart_0.method_16().Count != 0)
		{
			foreach (Shape shape in chart_0.Shapes)
			{
				if (shape.Placement != PlacementType.MoveAndSize)
				{
					shape.method_27().method_7().method_4(PlacementType.MoveAndSize);
					shape.Placement = PlacementType.Move;
				}
			}
		}
		if (class1330_0 != null || byte_2 != 0 || class1330_0 != null)
		{
			Class1330 @class = class1330_0;
			if (hashtable_0 != null)
			{
				if (hashtable_0[0] != null)
				{
					if (@class == null)
					{
						@class = (Class1330)hashtable_0[0];
					}
					else
					{
						@class.method_49().byte_1 |= ((Class1330)hashtable_0[0]).method_49().byte_1;
					}
				}
				if (hashtable_0[1] != null)
				{
					if (@class == null)
					{
						@class = (Class1330)hashtable_0[1];
					}
					else
					{
						@class.method_49().byte_1 |= ((Class1330)hashtable_0[1]).method_49().byte_1;
					}
				}
			}
			for (int i = 0; i < arrayList_2.Count; i++)
			{
				Class1690 class2 = (Class1690)arrayList_2[i];
				if (class2.byte_0 != 0)
				{
					continue;
				}
				Series series2 = (Series)class2.object_0;
				bool flag = false;
				if (arrayList_1 != null)
				{
					for (int j = 0; j < arrayList_1.Count; j++)
					{
						Class1692 class3 = (Class1692)arrayList_1[j];
						if (class3.ushort_0 == i && class3.ushort_1 == ushort.MaxValue)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					continue;
				}
				DataLabels dataLabels = series2.DataLabels;
				if (@class != null)
				{
					@class.method_61(dataLabels, -1, arrayList_1);
					continue;
				}
				bool bool_;
				if (bool_ = (byte_2 & 1) != 0)
				{
					dataLabels.method_45(Enum127.const_1, bool_);
				}
				if (bool_ = (byte_2 & 2) != 0)
				{
					dataLabels.method_45(Enum127.const_2, bool_);
				}
				if (bool_ = (byte_2 & 0x10) != 0)
				{
					dataLabels.method_45(Enum127.const_3, bool_);
				}
				if (bool_ = (byte_2 & 0x20) != 0)
				{
					dataLabels.method_45(Enum127.const_4, bool_);
				}
			}
		}
		chart_0.int_5 = int_1;
		if (int_1 != 0)
		{
			method_21();
		}
		if (ChartCollection.smethod_0(chart_0.Type))
		{
			if (!bool_2)
			{
				chart_0.Walls.Formatting = FormattingType.Automatic;
			}
			chart_0.method_33().Copy(chart_0.Walls);
		}
	}

	private void method_21()
	{
		int num = 0;
		for (int i = 0; i < arrayList_2.Count; i++)
		{
			Class1690 @class = (Class1690)arrayList_2[i];
			if (@class.byte_0 == 0)
			{
				if (@class.legendEntry_0 != null)
				{
					@class.legendEntry_0.Index = num;
				}
				num++;
			}
		}
		int count = chart_0.NSeries.Count;
		for (int j = 0; j < arrayList_2.Count; j++)
		{
			Class1690 class2 = (Class1690)arrayList_2[j];
			if (class2.byte_0 == 1)
			{
				if (class2.legendEntry_0 != null)
				{
					class2.legendEntry_0.Index = num;
				}
				Trendline trendline = (Trendline)class2.object_0;
				trendline.method_39(num - count);
				num++;
			}
		}
	}

	private void method_22()
	{
		method_1();
		bool flag = byte_1[0] == 1;
		int int_ = BitConverter.ToInt16(byte_1, 2);
		int int_2 = BitConverter.ToInt16(byte_1, 6);
		int int_3 = BitConverter.ToInt16(byte_1, 10);
		int int_4 = BitConverter.ToInt16(byte_1, 14);
		chart_0.PlotArea.method_40(int_, int_2, int_3, int_4);
		Axis axis = null;
		int num = 0;
		Color color = Color.Empty;
		bool isAutoFontColor = true;
		Class1330 @class = null;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4125:
				method_1();
				isAutoFontColor = true;
				color = Color.Empty;
				switch (byte_1[0])
				{
				case 0:
					axis = ((!flag) ? chart_0.CategoryAxis : chart_0.SecondCategoryAxis);
					break;
				case 1:
					axis = ((!flag) ? chart_0.ValueAxis : chart_0.SecondValueAxis);
					break;
				case 2:
					axis = chart_0.SeriesAxis;
					break;
				}
				axis.IsVisible = true;
				break;
			case 4126:
				color = method_32(axis, out isAutoFontColor);
				break;
			case 4127:
				method_51(axis);
				break;
			case 4128:
				method_53(axis);
				break;
			case 4129:
				method_52(axis);
				break;
			case 4133:
				@class = new Class1330(worksheetCollection_0, chart_0);
				method_63(@class, bool_3: true);
				if (@class.method_50() != null)
				{
					@class.method_59(chart_0, flag);
				}
				break;
			case 4134:
			{
				int num2 = method_19();
				if (num2 != -1)
				{
					axis.TickLabels.method_2(num2);
					Class1383 class2 = method_25(num2);
					axis.TickLabels.method_3(class2 != null);
					Aspose.Cells.Font font_ = method_24(num2);
					if (!smethod_0(font_, color))
					{
						axis.TickLabels.Font.Color = color;
					}
				}
				break;
			}
			case 4116:
				method_34(flag);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4194:
				method_55(axis);
				break;
			case 4174:
				method_33(axis);
				break;
			case 4175:
				method_69(chart_0.PlotArea, !flag);
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			case 4149:
				method_50();
				break;
			case 2206:
				if (num == 2)
				{
					if (axis.arrayList_0 == null)
					{
						axis.arrayList_0 = new ArrayList();
					}
					axis.arrayList_0.Add(method_23());
				}
				else
				{
					ushort_1 = class1723_0.method_2(byte_0);
					class1723_0.method_3(ushort_1);
				}
				break;
			case 2134:
				method_31(axis);
				break;
			case 2135:
				@class = method_26(axis, bool_3: false);
				if (@class.method_49() != null)
				{
					@class.method_58(axis, axis.DisplayUnitLabel, arrayList_0);
				}
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private byte[] method_23()
	{
		method_1();
		int num = BitConverter.ToInt32(byte_1, 12);
		byte[] array = new byte[num];
		Array.Copy(byte_1, 16, array, 0, num);
		return array;
	}

	internal static bool smethod_0(Aspose.Cells.Font font_0, Color color_0)
	{
		if (color_0.IsEmpty)
		{
			if (font_0.ColorIndex != -1)
			{
				return font_0.ColorIndex > 56;
			}
			return true;
		}
		return font_0.Color.Equals(color_0);
	}

	private Aspose.Cells.Font method_24(int int_4)
	{
		return worksheetCollection_0.method_53(int_4);
	}

	private Class1383 method_25(int int_4)
	{
		foreach (Class1383 item in chart_0.method_35())
		{
			if (item.int_0 == int_4)
			{
				return item;
			}
		}
		return null;
	}

	private Class1330 method_26(Axis axis_0, bool bool_3)
	{
		if (ushort_0 != 2135)
		{
			ushort_1 = class1723_0.method_2(byte_0);
			class1723_0.method_3(ushort_1);
		}
		else
		{
			method_30(axis_0);
		}
		int num = 0;
		Class1330 @class = new Class1330(worksheetCollection_0, chart_0);
		@class.method_48(bool_3);
		int num2 = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 2130:
			case 2131:
			case 2132:
			case 2133:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 2129:
				num = class1723_0.method_2(byte_0);
				class1723_0.method_3(4);
				ushort_0 = class1723_0.method_2(byte_0);
				switch (ushort_0)
				{
				case 4109:
					@class.method_41(method_84());
					break;
				case 4106:
					method_90(@class.Area);
					break;
				case 4103:
					method_88(@class.Border);
					break;
				case 4146:
					method_86(@class);
					break;
				case 4147:
					class1723_0.method_3(num - 6);
					num2++;
					break;
				case 4133:
					method_70(@class);
					break;
				case 4134:
					@class.method_14(method_19());
					@class.class1383_0 = method_25(@class.method_13());
					if (ushort_1 + 8 < num)
					{
						class1723_0.method_3(num - 8 - ushort_1);
					}
					break;
				case 4135:
					method_66(@class.method_49());
					if (@class.method_49().byte_0 == 4 && !@class.method_47())
					{
						if (arrayList_1 == null)
						{
							arrayList_1 = new ArrayList();
						}
						arrayList_1.Add(@class.method_49());
					}
					break;
				case 4198:
					method_27(@class.Area);
					break;
				case 4175:
					method_69(@class, bool_3: true);
					break;
				default:
					class1723_0.method_3(num - 6);
					break;
				case 4177:
					method_67(@class);
					break;
				case 4164:
					class1723_0.method_3(num - 6);
					num2--;
					if (num2 == 0)
					{
						return @class;
					}
					break;
				case 10:
				case 574:
					throw new IOException("File is corrupted");
				}
				break;
			case 2155:
				method_65(@class.method_50());
				break;
			default:
				class1723_0.method_3(-2);
				return @class;
			}
		}
	}

	private void method_27(Area area_0)
	{
		ArrayList arrayList = new ArrayList();
		while (true)
		{
			method_1();
			arrayList.Add(byte_1);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 2129)
			{
				break;
			}
			class1723_0.method_3(6);
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 4198 || ushort_0 != 60)
			{
				class1723_0.method_3(-10);
				break;
			}
		}
		area_0.FillFormat.method_3(area_0.FillFormat.method_4(arrayList), bool_1: false);
	}

	private void method_28(Area area_0)
	{
		method_1();
		TextureFill textureFill = area_0.FillFormat.TextureFill;
		if (textureFill != null)
		{
			PicFormatOption picFormatOption = new PicFormatOption();
			switch (byte_1[0])
			{
			default:
				picFormatOption.Type = FillPictureType.Stretch;
				break;
			case 1:
				picFormatOption.Type = FillPictureType.Stretch;
				break;
			case 2:
				picFormatOption.Type = FillPictureType.Stack;
				break;
			case 3:
				picFormatOption.Type = FillPictureType.StackAndScale;
				break;
			}
			picFormatOption.ushort_1 = BitConverter.ToUInt16(byte_1, 2);
			picFormatOption.method_1(BitConverter.ToUInt16(byte_1, 4));
			if (picFormatOption.Type == FillPictureType.StackAndScale)
			{
				picFormatOption.Scale = BitConverter.ToDouble(byte_1, 6);
			}
			textureFill.PicFormatOption = picFormatOption;
		}
	}

	private void method_29(Area area_0)
	{
		ArrayList arrayList = new ArrayList();
		do
		{
			method_1();
			arrayList.Add(byte_1);
			ushort_0 = class1723_0.method_2(byte_0);
		}
		while (ushort_0 == 4198 || ushort_0 == 60);
		class1723_0.method_3(-2);
		area_0.FillFormat.method_3(area_0.FillFormat.method_4(arrayList), bool_1: false);
	}

	private void method_30(Axis axis_0)
	{
		method_1();
		axis_0.IsDisplayUnitLabelShown = (byte_1[14] & 2) != 0;
		switch (byte_1[4])
		{
		case 1:
			axis_0.DisplayUnit = DisplayUnitType.Hundreds;
			break;
		case 2:
			axis_0.DisplayUnit = DisplayUnitType.Thousands;
			break;
		case 5:
			axis_0.DisplayUnit = DisplayUnitType.Millions;
			break;
		case 8:
			axis_0.DisplayUnit = DisplayUnitType.Billions;
			break;
		case 9:
			axis_0.DisplayUnit = DisplayUnitType.Trillions;
			break;
		case 3:
		case 4:
		case 6:
		case 7:
			break;
		}
	}

	private void method_31(Axis axis_0)
	{
		method_1();
		if (axis_0.Type == Enum195.const_0)
		{
			axis_0.TickLabels.Offset = BitConverter.ToUInt16(byte_1, 4);
			if (axis_0.TickLabelSpacing == 1)
			{
				axis_0.method_17((byte_1[8] & 1) != 0);
			}
		}
	}

	private Color method_32(Axis axis, out bool isAutoFontColor)
	{
		method_1();
		switch (byte_1[0])
		{
		case 0:
			axis.MajorTickMark = TickMarkType.None;
			break;
		case 1:
			axis.MajorTickMark = TickMarkType.Inside;
			break;
		case 2:
			axis.MajorTickMark = TickMarkType.Outside;
			break;
		case 3:
			axis.MajorTickMark = TickMarkType.Cross;
			break;
		}
		switch (byte_1[1])
		{
		case 0:
			axis.MinorTickMark = TickMarkType.None;
			break;
		case 1:
			axis.MinorTickMark = TickMarkType.Inside;
			break;
		case 2:
			axis.MinorTickMark = TickMarkType.Outside;
			break;
		case 3:
			axis.MinorTickMark = TickMarkType.Cross;
			break;
		}
		switch (byte_1[2])
		{
		case 0:
			axis.TickLabelPosition = TickLabelPositionType.None;
			break;
		case 1:
			axis.TickLabelPosition = TickLabelPositionType.Low;
			break;
		case 2:
			axis.TickLabelPosition = TickLabelPositionType.High;
			break;
		case 3:
			axis.TickLabelPosition = TickLabelPositionType.NextToAxis;
			break;
		}
		if ((byte_1[24] & 2u) != 0)
		{
			axis.TickLabels.BackgroundMode = BackgroundMode.Automatic;
		}
		else
		{
			switch (byte_1[3])
			{
			case 1:
				axis.TickLabels.BackgroundMode = BackgroundMode.Transparent;
				break;
			case 2:
				axis.TickLabels.BackgroundMode = BackgroundMode.Opaque;
				break;
			}
		}
		if ((byte_1[24] & 0x20) == 0)
		{
			if (byte_1[28] > 90 && byte_1[28] != byte.MaxValue)
			{
				axis.TickLabels.RotationAngle = 90 - byte_1[28];
			}
			else
			{
				axis.TickLabels.RotationAngle = byte_1[28];
			}
		}
		if ((byte_1[25] & 0x40u) != 0)
		{
			axis.TickLabels.TextDirection = TextDirectionType.LeftToRight;
		}
		else if ((byte_1[25] & 0x80u) != 0)
		{
			axis.TickLabels.TextDirection = TextDirectionType.RightToLeft;
		}
		isAutoFontColor = (byte_1[24] & 1) != 0;
		if (!isAutoFontColor)
		{
			return GetColor(byte_1, 4);
		}
		return Color.Empty;
	}

	private void method_33(Axis axis_0)
	{
		method_1();
		TickLabels tickLabels = axis_0.TickLabels;
		tickLabels.NumberFormatLinked = false;
		int int_ = BitConverter.ToUInt16(byte_1, 0);
		string text = method_97(int_);
		if (text != null && !(text == ""))
		{
			tickLabels.NumberFormat = text;
		}
		else
		{
			tickLabels.method_7(int_);
		}
	}

	private void method_34(bool bool_3)
	{
		method_1();
		int num = BitConverter.ToUInt16(byte_1, 18);
		Class1387 @class = chart_0.method_18().method_0(num);
		@class.PlotOnSecondAxis = bool_3;
		@class.IsColorVaried = (byte_1[16] & 1) != 0;
		int num2 = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4147:
				num2++;
				method_94();
				break;
			case 4148:
				method_95();
				num2--;
				if (num2 == 0)
				{
					method_107(@class);
					return;
				}
				break;
			case 4117:
				method_48();
				break;
			case 4119:
				method_47(@class);
				break;
			case 4120:
				method_44(@class);
				break;
			case 4121:
				method_43(@class);
				break;
			case 4122:
				method_39(@class);
				break;
			case 4123:
				method_41(@class);
				break;
			case 4124:
				method_40(@class);
				break;
			case 4130:
				method_45(@class);
				break;
			case 4132:
				method_62();
				break;
			case 4199:
				method_1();
				@class.byte_0 = byte_1;
				@class.method_21(bool_11: false);
				break;
			case 4193:
				method_42(@class);
				break;
			case 4154:
				method_46(@class);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4157:
				method_35(@class);
				break;
			case 4158:
				method_38(@class);
				break;
			case 4159:
				method_36(@class);
				break;
			case 4160:
				method_37(@class);
				break;
			case 4102:
				method_78(@class);
				break;
			case 2154:
				class1330_0 = method_26(null, bool_3: true);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_35(Class1387 class1387_0)
	{
		method_1();
		class1387_0.method_18(bool_11: true);
		DropBars upBars = class1387_0.UpBars;
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4198:
				method_29(upBars.Area);
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					ushort_0 = class1723_0.method_2(byte_0);
					if (ushort_0 != 4157)
					{
						class1723_0.method_3(-2);
						return;
					}
					method_1();
				}
				break;
			case 4106:
				method_90(upBars.Area);
				break;
			case 4103:
				method_88(upBars.Border);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_36(Class1387 class1387_0)
	{
		method_1();
		if (((uint)byte_1[0] & (true ? 1u : 0u)) != 0)
		{
			class1387_0.method_13(ChartType.Surface3D);
		}
		else
		{
			class1387_0.method_13(ChartType.SurfaceWireframe3D);
		}
		class1387_0.method_23((byte_1[0] & 2) != 0);
	}

	private void method_37(Class1387 class1387_0)
	{
		method_1();
		class1387_0.HasRadarAxisLabels = (byte_1[0] & 1) != 0;
		class1387_0.method_13(ChartType.RadarFilled);
	}

	private void method_38(Class1387 class1387_0)
	{
		method_1();
		class1387_0.HasRadarAxisLabels = (byte_1[0] & 1) != 0;
		class1387_0.method_23((byte_1[0] & 2) != 0);
		class1387_0.method_13(ChartType.RadarWithDataMarkers);
	}

	private void method_39(Class1387 class1387_0)
	{
		method_1();
		bool flag = (byte_1[0] & 1) != 0;
		bool flag2 = (byte_1[0] & 2) != 0;
		class1387_0.method_23((byte_1[0] & 4) != 0);
		if (flag)
		{
			if (flag2)
			{
				class1387_0.method_13(ChartType.Area100PercentStacked);
			}
			else
			{
				class1387_0.method_13(ChartType.AreaStacked);
			}
		}
		else
		{
			class1387_0.method_13(ChartType.Area);
		}
	}

	private void method_40(Class1387 class1387_0)
	{
		method_1();
		Line line = null;
		switch (byte_1[0])
		{
		case 0:
			class1387_0.method_17(bool_11: true);
			line = class1387_0.DropLines;
			break;
		case 1:
			class1387_0.method_15(bool_11: true);
			line = class1387_0.HiLoLines;
			break;
		case 2:
			class1387_0.method_16(bool_11: true);
			line = class1387_0.SeriesLines;
			break;
		case 3:
			line = class1387_0.LeaderLines;
			break;
		}
		if (line != null)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			if (ushort_0 != 4103)
			{
				throw new IOException("File is corrupted");
			}
			method_88(line);
		}
	}

	private void method_41(Class1387 class1387_0)
	{
		method_1();
		if (((uint)byte_1[4] & (true ? 1u : 0u)) != 0)
		{
			class1387_0.method_23((byte_1[4] & 4) != 0);
			class1387_0.ShowNegativeBubbles = (byte_1[4] & 2) != 0;
			class1387_0.method_13(ChartType.Bubble);
			class1387_0.BubbleScale = BitConverter.ToUInt16(byte_1, 0);
			switch (byte_1[2])
			{
			case 1:
				class1387_0.SizeRepresents = BubbleSizeRepresents.SizeIsArea;
				break;
			case 2:
				class1387_0.SizeRepresents = BubbleSizeRepresents.SizeIsWidth;
				break;
			}
		}
		else
		{
			class1387_0.method_13(ChartType.ScatterConnectedByLinesWithDataMarker);
		}
	}

	private void method_42(Class1387 class1387_0)
	{
		method_1();
		switch (byte_1[0])
		{
		case 0:
			return;
		case 1:
			class1387_0.method_13(ChartType.PiePie);
			break;
		case 2:
			class1387_0.method_13(ChartType.PieBar);
			break;
		}
		if (byte_1[1] != 1)
		{
			switch (byte_1[2])
			{
			case 0:
				class1387_0.SplitType = ChartSplitType.Position;
				class1387_0.SplitValue = BitConverter.ToInt16(byte_1, 4);
				break;
			case 1:
				class1387_0.SplitType = ChartSplitType.Value;
				class1387_0.SplitValue = BitConverter.ToInt16(byte_1, 6);
				break;
			case 2:
				class1387_0.SplitType = ChartSplitType.PercentValue;
				class1387_0.SplitValue = BitConverter.ToDouble(byte_1, 12);
				break;
			case 3:
				class1387_0.SplitType = ChartSplitType.Custom;
				class1387_0.method_21(bool_11: false);
				break;
			}
		}
		class1387_0.SecondPlotSize = BitConverter.ToUInt16(byte_1, 8);
		class1387_0.GapWidth = BitConverter.ToUInt16(byte_1, 10);
		class1387_0.method_23((byte_1[20] & 1) != 0);
	}

	private void method_43(Class1387 class1387_0)
	{
		method_1();
		class1387_0.FirstSliceAngle = BitConverter.ToUInt16(byte_1, 0);
		class1387_0.DoughnutHoleSize = BitConverter.ToUInt16(byte_1, 2);
		class1387_0.method_23((byte_1[4] & 1) != 0);
		class1387_0.HasLeaderLines = (byte_1[4] & 2) != 0;
		if (class1387_0.DoughnutHoleSize == 0)
		{
			class1387_0.method_13(ChartType.Pie);
		}
		else
		{
			class1387_0.method_13(ChartType.Doughnut);
		}
	}

	private void method_44(Class1387 class1387_0)
	{
		method_1();
		bool flag = (byte_1[0] & 1) != 0;
		bool flag2 = (byte_1[0] & 2) != 0;
		class1387_0.method_23((byte_1[0] & 4) != 0);
		ChartType chartType_ = ChartType.LineWithDataMarkers;
		if (flag)
		{
			chartType_ = ((!flag2) ? ChartType.LineStackedWithDataMarkers : ChartType.Line100PercentStackedWithDataMarkers);
		}
		class1387_0.method_13(chartType_);
	}

	private void method_45(Class1387 class1387_0)
	{
		class1723_0.method_3(12);
	}

	private void method_46(Class1387 class1387_0)
	{
		method_1();
		chart_0.RotationAngle = BitConverter.ToInt16(byte_1, 0);
		chart_0.Elevation = BitConverter.ToInt16(byte_1, 2);
		chart_0.Perspective = BitConverter.ToInt16(byte_1, 4);
		chart_0.HeightPercent = BitConverter.ToInt16(byte_1, 6);
		chart_0.DepthPercent = BitConverter.ToInt16(byte_1, 8);
		chart_0.GapDepth = BitConverter.ToInt16(byte_1, 10);
		chart_0.AutoScaling = (byte_1[12] & 4) != 0;
		chart_0.WallsAndGridlines2D = (byte_1[12] & 0x20) != 0;
		chart_0.RightAngleAxes = (byte_1[12] & 1) == 0;
		bool flag = (byte_1[12] & 2) != 0;
		switch (class1387_0.method_11())
		{
		case ChartType.Surface3D:
			if (chart_0.Elevation == 90 && chart_0.RotationAngle == 0)
			{
				class1387_0.method_13(ChartType.SurfaceContour);
			}
			break;
		case ChartType.SurfaceWireframe3D:
			if (chart_0.Elevation == 90 && chart_0.RotationAngle == 0)
			{
				class1387_0.method_13(ChartType.SurfaceContourWireframe);
			}
			break;
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
			class1387_0.method_13(ChartType.Line3D);
			break;
		case ChartType.Pie:
			class1387_0.method_13(ChartType.Pie3D);
			break;
		case ChartType.PieExploded:
			class1387_0.method_13(ChartType.Pie3DExploded);
			break;
		case ChartType.Area:
			class1387_0.method_13(ChartType.Area3D);
			break;
		case ChartType.AreaStacked:
			class1387_0.method_13(ChartType.Area3DStacked);
			break;
		case ChartType.Area100PercentStacked:
			class1387_0.method_13(ChartType.Area3D100PercentStacked);
			break;
		case ChartType.Bar:
			class1387_0.method_13(ChartType.Bar3DClustered);
			break;
		case ChartType.BarStacked:
			class1387_0.method_13(ChartType.Bar3DStacked);
			break;
		case ChartType.Bar100PercentStacked:
			class1387_0.method_13(ChartType.Bar3D100PercentStacked);
			break;
		case ChartType.Column:
			if (flag)
			{
				class1387_0.method_13(ChartType.Column3DClustered);
			}
			else
			{
				class1387_0.method_13(ChartType.Column3D);
			}
			break;
		case ChartType.ColumnStacked:
			class1387_0.method_13(ChartType.Column3DStacked);
			break;
		case ChartType.Column100PercentStacked:
			class1387_0.method_13(ChartType.Column3D100PercentStacked);
			break;
		}
	}

	private void method_47(Class1387 class1387_0)
	{
		method_1();
		class1387_0.Overlap = -BitConverter.ToInt16(byte_1, 0);
		class1387_0.GapWidth = BitConverter.ToInt16(byte_1, 2);
		bool flag = (byte_1[4] & 1) != 0;
		bool flag2 = (byte_1[4] & 2) != 0;
		bool flag3 = (byte_1[4] & 4) != 0;
		class1387_0.method_23((byte_1[4] & 8) != 0);
		ChartType chartType_;
		if (flag)
		{
			chartType_ = ChartType.Bar;
			if (flag2)
			{
				chartType_ = ((!flag3) ? ChartType.BarStacked : ChartType.Bar100PercentStacked);
			}
		}
		else
		{
			chartType_ = ChartType.Column;
			if (flag2)
			{
				chartType_ = ((!flag3) ? ChartType.ColumnStacked : ChartType.Column100PercentStacked);
			}
		}
		class1387_0.method_13(chartType_);
	}

	private void method_48()
	{
		chart_0.ShowLegend = true;
		Legend legend = chart_0.Legend;
		method_49(legend);
		int num = 0;
		Class1330 @class = new Class1330(worksheetCollection_0, chart_0);
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4133:
				method_63(@class, bool_3: false);
				break;
			case 2213:
				method_1();
				@class.byte_3 = new byte[ushort_1];
				Array.Copy(byte_1, 0, @class.byte_3, 0, ushort_1);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4175:
				method_68(legend);
				break;
			case 4146:
				method_61(@class);
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					@class.method_55(legend, bool_17: true);
					return;
				}
				break;
			case 2205:
				method_1();
				@class.byte_2 = new byte[ushort_1];
				Array.Copy(byte_1, 0, @class.byte_2, 0, ushort_1);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_49(Legend legend_0)
	{
		method_1();
		legend_0.method_46((byte_1[18] & 0x10) != 0);
		int num = BitConverter.ToInt32(byte_1, 0);
		int num2 = BitConverter.ToInt32(byte_1, 4);
		if (num >= 0 && num2 >= 0)
		{
			legend_0.method_22(num);
			legend_0.method_24(num2);
			int num3 = BitConverter.ToInt32(byte_1, 8);
			if (num3 != 0)
			{
				legend_0.method_28(num3);
			}
			num3 = BitConverter.ToInt32(byte_1, 12);
			if (num3 != 0)
			{
				legend_0.method_27(num3);
			}
			legend_0.method_19((byte_1[18] & 4) != 0);
			legend_0.method_21((byte_1[18] & 8) != 0);
		}
		switch (byte_1[16])
		{
		case 0:
			legend_0.method_39(LegendPositionType.Bottom);
			break;
		case 1:
			legend_0.method_39(LegendPositionType.Corner);
			break;
		case 2:
			legend_0.method_39(LegendPositionType.Top);
			break;
		case 3:
			legend_0.method_39(LegendPositionType.Right);
			break;
		case 4:
			legend_0.method_39(LegendPositionType.Left);
			break;
		case 7:
			if (legend_0.method_17())
			{
				legend_0.method_39(LegendPositionType.Right);
			}
			else
			{
				legend_0.method_39(LegendPositionType.NotDocked);
			}
			break;
		case 5:
		case 6:
			break;
		}
	}

	private void method_50()
	{
		bool_1 = true;
		class1723_0.method_3(2);
		ushort num = class1723_0.method_2(byte_0);
		if (num != 4146)
		{
			throw new IOException("File is corrupted");
		}
		method_61(chart_0.PlotArea);
	}

	private void method_51(Axis axis_0)
	{
		method_1();
		byte b = byte_1[40];
		bool flag2 = (axis_0.IsLogarithmic = (b & 0x20) != 0);
		if ((b & 1) == 0)
		{
			if (flag2)
			{
				axis_0.MinValue = Math.Pow(10.0, BitConverter.ToDouble(byte_1, 0));
			}
			else
			{
				axis_0.MinValue = BitConverter.ToDouble(byte_1, 0);
			}
		}
		if ((b & 2) == 0)
		{
			if (flag2)
			{
				axis_0.MaxValue = Math.Pow(10.0, BitConverter.ToDouble(byte_1, 8));
			}
			else
			{
				axis_0.MaxValue = BitConverter.ToDouble(byte_1, 8);
			}
		}
		if ((b & 4) == 0)
		{
			if (flag2)
			{
				axis_0.MajorUnit = Math.Pow(10.0, BitConverter.ToDouble(byte_1, 16));
			}
			else
			{
				axis_0.MajorUnit = BitConverter.ToDouble(byte_1, 16);
			}
		}
		if ((b & 8) == 0)
		{
			if (flag2)
			{
				axis_0.MinorUnit = Math.Pow(10.0, BitConverter.ToDouble(byte_1, 24));
			}
			else
			{
				axis_0.MinorUnit = BitConverter.ToDouble(byte_1, 24);
			}
		}
		if ((b & 0x10) == 0)
		{
			if (flag2)
			{
				axis_0.method_12(Math.Pow(10.0, BitConverter.ToDouble(byte_1, 32)));
			}
			else
			{
				axis_0.method_12(BitConverter.ToDouble(byte_1, 32));
			}
		}
		axis_0.IsPlotOrderReversed = (b & 0x40) != 0;
		if ((b & 0x80u) != 0)
		{
			axis_0.CrossType = CrossType.Maximum;
		}
	}

	private void method_52(Axis axis_0)
	{
		method_1();
		byte b = byte_1[0];
		ushort num = class1723_0.method_2(byte_0);
		if (num != 4103)
		{
			throw new IOException("File is corrupted");
		}
		switch (b)
		{
		default:
			throw new IOException("File is corrupted");
		case 0:
			method_87(axis_0);
			break;
		case 1:
		{
			Line line2 = new Line(chart_0, axis_0);
			method_88(line2);
			axis_0.method_27(line2);
			break;
		}
		case 2:
		{
			Line line = new Line(chart_0, axis_0);
			method_88(line);
			axis_0.method_29(line);
			break;
		}
		case 3:
		{
			if (axis_0.Type == Enum195.const_0)
			{
				bool_2 = true;
				method_88(chart_0.method_34().Border);
			}
			else if (axis_0.Type == Enum195.const_1)
			{
				method_88(chart_0.method_27().Border);
			}
			else
			{
				bool_2 = true;
				method_88(chart_0.method_34().Border);
			}
			num = class1723_0.method_2(byte_0);
			if (num != 4106)
			{
				throw new IOException("File is corrupted");
			}
			Area area = null;
			area = axis_0.Type switch
			{
				Enum195.const_0 => chart_0.method_34(), 
				Enum195.const_1 => chart_0.method_27(), 
				_ => chart_0.method_34(), 
			};
			method_90(area);
			num = class1723_0.method_2(byte_0);
			if (num != 4198)
			{
				class1723_0.method_3(-2);
			}
			else
			{
				method_29(area);
			}
			break;
		}
		}
	}

	private void method_53(Axis axis_0)
	{
		method_1();
		axis_0.IsPlotOrderReversed = (byte_1[6] & 4) != 0;
		axis_0.AxisBetweenCategories = (byte_1[6] & 1) != 0;
		if ((byte_1[6] & 2u) != 0)
		{
			axis_0.CrossType = CrossType.Maximum;
		}
		else
		{
			axis_0.CrossAt = (int)BitConverter.ToUInt16(byte_1, 0);
		}
		ushort num = BitConverter.ToUInt16(byte_1, 2);
		if (num != 1)
		{
			axis_0.TickLabelSpacing = num;
		}
		axis_0.TickMarkSpacing = BitConverter.ToUInt16(byte_1, 4);
	}

	private DateTime method_54(int int_4, TimeUnit timeUnit_0)
	{
		if (timeUnit_0 != 0)
		{
			DateTime dateTime = new DateTime(1900, 1, 1);
			return timeUnit_0 switch
			{
				TimeUnit.Months => dateTime.AddMonths(int_4), 
				TimeUnit.Years => dateTime.AddYears(int_4), 
				_ => dateTime, 
			};
		}
		return CellsHelper.GetDateTimeFromDouble(int_4, worksheetCollection_0.Workbook.Settings.Date1904);
	}

	private void method_55(Axis axis_0)
	{
		method_1();
		bool flag = (byte_1[16] & 0x10) != 0;
		bool flag2 = (byte_1[16] & 0x80) != 0;
		if (flag)
		{
			axis_0.CategoryType = CategoryType.TimeScale;
		}
		else if (flag2)
		{
			axis_0.CategoryType = CategoryType.AutomaticScale;
		}
		else
		{
			axis_0.CategoryType = CategoryType.CategoryScale;
		}
		axis_0.BaseUnitScale = method_99(byte_1[12]);
		axis_0.method_23((byte_1[16] & 0x20) != 0);
		if ((byte_1[16] & 1) != 1)
		{
			int num = BitConverter.ToUInt16(byte_1, 0);
			if (flag && !axis_0.method_22())
			{
				axis_0.MinValue = method_54(num, axis_0.BaseUnitScale);
			}
			else
			{
				axis_0.MinValue = num;
			}
		}
		if ((byte_1[16] & 2) != 2)
		{
			int num2 = BitConverter.ToUInt16(byte_1, 2);
			if (flag && !axis_0.method_22())
			{
				axis_0.MaxValue = method_54(num2, axis_0.BaseUnitScale);
			}
			else
			{
				axis_0.MaxValue = num2;
			}
		}
		if ((byte_1[16] & 4) != 4)
		{
			axis_0.method_8((int)BitConverter.ToUInt16(byte_1, 4));
			axis_0.IsAutomaticMajorUnit = false;
			axis_0.method_24(method_99(byte_1[6]));
		}
		if ((byte_1[16] & 8) != 8)
		{
			axis_0.method_10((int)BitConverter.ToUInt16(byte_1, 8));
			axis_0.IsAutomaticMinorUnit = false;
			axis_0.method_25(method_99(byte_1[10]));
		}
		if ((byte_1[16] & 0x40) != 64)
		{
			axis_0.CrossAt = (int)BitConverter.ToUInt16(byte_1, 14);
		}
		else
		{
			axis_0.bool_4 = true;
		}
	}

	private void method_56()
	{
		method_1();
		bool_0 = byte_1[0] == 2;
	}

	private void method_57()
	{
		method_1();
		chart_0.method_11(byte_1[0]);
		if ((byte_1[0] & 0x18) == 24)
		{
			chart_0.PlotArea.method_19(bool_5: false);
			chart_0.PlotArea.method_21(bool_5: false);
			chart_0.PlotArea.IsAutoSize = false;
		}
		switch (byte_1[2])
		{
		case 0:
			chart_0.PlotEmptyCellsType = PlotEmptyCellsType.NotPlotted;
			break;
		case 1:
			chart_0.PlotEmptyCellsType = PlotEmptyCellsType.Zero;
			break;
		case 2:
			chart_0.PlotEmptyCellsType = PlotEmptyCellsType.Interpolated;
			break;
		}
	}

	private int method_58(byte[] byte_3, int int_4)
	{
		double num = (float)(int)BitConverter.ToUInt16(byte_3, int_4 + 2) + (float)(int)BitConverter.ToUInt16(byte_3, int_4) / 65536f;
		return (int)(num * (double)worksheetCollection_0.method_75() / 72.0 + 0.5);
	}

	internal void method_59()
	{
		if (worksheet_0.Type == SheetType.Chart && chart_0 == worksheet_0.Charts[0])
		{
			method_1();
			chart_0.ChartObject.method_27().method_7().method_4(PlacementType.FreeFloating);
			chart_0.ChartObject.method_27().method_7().Left = method_58(byte_1, 0);
			chart_0.ChartObject.method_27().method_7().Top = method_58(byte_1, 4);
			chart_0.ChartObject.method_27().method_7().Right = method_58(byte_1, 8);
			chart_0.ChartObject.method_27().method_7().Bottom = method_58(byte_1, 12);
		}
		else
		{
			method_1();
			int_2 = method_58(byte_1, 8);
			int_3 = method_58(byte_1, 12);
		}
	}

	private void method_60()
	{
		method_1();
		chart_0.method_50((float)(int)BitConverter.ToUInt16(byte_1, 2) + (float)(int)BitConverter.ToUInt16(byte_1, 0) / 65536f);
		chart_0.method_52((float)(int)BitConverter.ToUInt16(byte_1, 6) + (float)(int)BitConverter.ToUInt16(byte_1, 4) / 65536f);
		ushort_0 = class1723_0.method_2(byte_0);
		if (ushort_0 != 4146)
		{
			chart_0.ChartArea.Border.IsVisible = false;
			chart_0.ChartArea.Area.Formatting = FormattingType.None;
			class1723_0.method_3(-2);
		}
		else
		{
			method_61(chart_0.ChartArea);
			chart_0.IsRectangularCornered = !chart_0.ChartArea.Area.InvertIfNegative;
		}
	}

	private void method_61(ChartFrame chartFrame_0)
	{
		method_86(chartFrame_0);
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4198:
				method_29(chartFrame_0.Area);
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			case 4106:
				method_90(chartFrame_0.Area);
				break;
			case 4103:
				method_88(chartFrame_0.Border);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_62()
	{
		method_1();
		byte b = byte_1[0];
		ushort_0 = class1723_0.method_2(byte_0);
		Class1330 @class = new Class1330(worksheetCollection_0, chart_0);
		@class.method_48(bool_17: true);
		method_63(@class, bool_3: false);
		switch (b)
		{
		case 0:
		case 1:
			if (@class.method_49() != null && @class.method_49().bool_0)
			{
				if (hashtable_0 == null)
				{
					hashtable_0 = new Hashtable();
				}
				hashtable_0.Add((int)b, @class);
			}
			break;
		case 2:
			@class.method_54(chart_0.ChartArea, bool_17: false, bool_18: false);
			break;
		case 3:
			if (@class.method_13() != -1)
			{
				chart_0.ChartArea.method_40(@class.method_13());
			}
			break;
		}
	}

	private void method_63(Class1330 class1330_1, bool bool_3)
	{
		method_70(class1330_1);
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4109:
				class1330_1.method_41(method_84());
				break;
			case 2213:
				method_1();
				class1330_1.byte_3 = new byte[ushort_1];
				Array.Copy(byte_1, 0, class1330_1.byte_3, 0, ushort_1);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4175:
				method_69(class1330_1, bool_3);
				break;
			case 4176:
				method_64(class1330_1);
				break;
			case 4177:
				method_67(class1330_1);
				break;
			case 4146:
				class1330_1.bool_15 = true;
				method_61(class1330_1);
				break;
			case 4147:
				method_94();
				num++;
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			case 4134:
				class1330_1.method_14(method_19());
				class1330_1.class1383_0 = method_25(class1330_1.method_13());
				break;
			case 4135:
				method_66(class1330_1.method_49());
				if (class1330_1.method_49().byte_0 == 4 && !class1330_1.method_47())
				{
					if (arrayList_1 == null)
					{
						arrayList_1 = new ArrayList();
					}
					arrayList_1.Add(class1330_1.method_49());
				}
				break;
			case 2205:
				method_1();
				class1330_1.byte_2 = new byte[ushort_1];
				Array.Copy(byte_1, 0, class1330_1.byte_2, 0, ushort_1);
				break;
			case 2155:
				method_65(class1330_1.method_50());
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_64(Class1330 class1330_1)
	{
		method_1();
		class1330_1.method_40(new ArrayList());
		int num = 0;
		int num2 = 0;
		for (int i = 2; i < ushort_1 - 4; i += 4)
		{
			num = num2;
			num2 = BitConverter.ToUInt16(byte_1, i + 4);
			FontSetting fontSetting = new FontSetting(num, num2 - num, worksheetCollection_0, bool_1: true);
			fontSetting.Font.Copy(worksheetCollection_0.method_53(BitConverter.ToUInt16(byte_1, i + 2)));
			class1330_1.method_39().Add(fontSetting);
		}
	}

	private void method_65(Class1692 class1692_0)
	{
		method_1();
		if (class1692_0 == null)
		{
			return;
		}
		class1692_0.bool_0 = true;
		class1692_0.byte_1 = byte_1[12];
		int num = BitConverter.ToUInt16(byte_1, 14);
		if (num != 0)
		{
			if (byte_1[16] == 0)
			{
				class1692_0.string_0 = Encoding.ASCII.GetString(byte_1, 17, num);
			}
			else
			{
				class1692_0.string_0 = Encoding.Unicode.GetString(byte_1, 17, 2 * num);
			}
		}
	}

	private void method_66(Class1692 class1692_0)
	{
		method_1();
		class1692_0.byte_0 = byte_1[0];
		class1692_0.ushort_0 = BitConverter.ToUInt16(byte_1, 2);
		class1692_0.ushort_1 = BitConverter.ToUInt16(byte_1, 4);
	}

	private void method_67(Class1330 class1330_1)
	{
		method_1();
		class1330_1.bool_12 = (byte_1[2] & 1) == 0;
		if (!class1330_1.bool_12)
		{
			int num = BitConverter.ToUInt16(byte_1, 4);
			string text = method_97(num);
			if (text != null && text != "")
			{
				class1330_1.NumberFormat = text;
			}
			class1330_1.Number = num;
		}
		int num2 = BitConverter.ToUInt16(byte_1, 6);
		if (num2 != 0)
		{
			class1330_1.byte_1 = new byte[num2 + 2];
			Array.Copy(byte_1, 6, class1330_1.byte_1, 0, class1330_1.byte_1.Length);
		}
	}

	private void method_68(Legend legend_0)
	{
		method_1();
		legend_0.IsAutoSize = byte_1[2] == 2;
		if (!legend_0.IsAutoSize)
		{
			if (chart_0.ChartObject.method_30())
			{
				legend_0.method_41((int)((float)(legend_0.method_29() * int_2) * 72f / (float)(worksheetCollection_0.method_75() * 4000) - (float)BitConverter.ToInt32(byte_1, 12)));
				legend_0.method_43((int)((float)(legend_0.method_26() * int_3) * 72f / (float)(worksheetCollection_0.method_75() * 4000) - (float)BitConverter.ToInt32(byte_1, 16)));
			}
			else
			{
				legend_0.method_41((int)((float)legend_0.Width / 4000f * (float)int_2 * 72f / (float)worksheetCollection_0.method_75() - (float)BitConverter.ToInt32(byte_1, 12)));
				legend_0.method_43((int)((float)legend_0.Height / 4000f * (float)int_3 * 72f / (float)worksheetCollection_0.method_76() - (float)BitConverter.ToInt32(byte_1, 16)));
			}
		}
	}

	private void method_69(ChartFrame chartFrame_0, bool bool_3)
	{
		if (bool_3)
		{
			method_1();
			chartFrame_0.method_22(BitConverter.ToInt16(byte_1, 4));
			chartFrame_0.method_24(BitConverter.ToInt16(byte_1, 8));
			chartFrame_0.method_28(BitConverter.ToInt16(byte_1, 12));
			chartFrame_0.method_27(BitConverter.ToInt16(byte_1, 16));
		}
		else
		{
			class1723_0.method_3(22);
		}
	}

	private void method_70(Class1330 class1330_1)
	{
		method_1();
		Class1694 position = class1330_1.Position;
		position.int_0 = BitConverter.ToInt32(byte_1, 8);
		position.int_1 = BitConverter.ToInt32(byte_1, 12);
		position.int_2 = BitConverter.ToInt32(byte_1, 16);
		position.int_3 = BitConverter.ToInt32(byte_1, 20);
		class1330_1.ushort_0 = BitConverter.ToUInt16(byte_1, 24);
		if ((byte_1[24] & 0x80u) != 0)
		{
			class1330_1.BackgroundMode = BackgroundMode.Automatic;
		}
		else
		{
			switch (byte_1[2])
			{
			case 1:
				class1330_1.BackgroundMode = BackgroundMode.Transparent;
				break;
			case 2:
				class1330_1.BackgroundMode = BackgroundMode.Opaque;
				break;
			}
		}
		ushort num = BitConverter.ToUInt16(byte_1, 30);
		if (num == 255)
		{
			class1330_1.RotationAngle = 255;
		}
		else if (num == 254)
		{
			class1330_1.bool_13 = true;
		}
		else if (num > 90)
		{
			class1330_1.RotationAngle = 90 - num;
		}
		else
		{
			class1330_1.RotationAngle = num;
		}
		switch (byte_1[0])
		{
		case 1:
			class1330_1.TextHorizontalAlignment = TextAlignmentType.Left;
			break;
		case 2:
			class1330_1.TextHorizontalAlignment = TextAlignmentType.Center;
			break;
		case 3:
			class1330_1.TextHorizontalAlignment = TextAlignmentType.Right;
			break;
		case 4:
			class1330_1.TextHorizontalAlignment = TextAlignmentType.Justify;
			break;
		case 7:
			class1330_1.TextHorizontalAlignment = TextAlignmentType.Distributed;
			break;
		}
		switch (byte_1[1])
		{
		case 1:
			class1330_1.TextVerticalAlignment = TextAlignmentType.Top;
			break;
		case 2:
			class1330_1.TextVerticalAlignment = TextAlignmentType.Center;
			break;
		case 3:
			class1330_1.TextVerticalAlignment = TextAlignmentType.Bottom;
			break;
		case 4:
			class1330_1.TextVerticalAlignment = TextAlignmentType.Justify;
			break;
		case 7:
			class1330_1.TextVerticalAlignment = TextAlignmentType.Distributed;
			break;
		}
		if ((byte_1[29] & 0x40u) != 0)
		{
			class1330_1.TextDirection = TextDirectionType.LeftToRight;
		}
		else if ((byte_1[29] & 0x80u) != 0)
		{
			class1330_1.TextDirection = TextDirectionType.RightToLeft;
		}
		switch (byte_1[28] & 0xF)
		{
		case 1:
			class1330_1.method_51(LabelPositionType.OutsideEnd);
			break;
		case 2:
			class1330_1.method_51(LabelPositionType.InsideEnd);
			break;
		case 3:
			class1330_1.method_51(LabelPositionType.Center);
			break;
		case 4:
			class1330_1.method_51(LabelPositionType.InsideBase);
			break;
		case 5:
			class1330_1.method_51(LabelPositionType.Above);
			break;
		case 6:
			class1330_1.method_51(LabelPositionType.Below);
			break;
		case 7:
			class1330_1.method_51(LabelPositionType.Left);
			break;
		case 8:
			class1330_1.method_51(LabelPositionType.Right);
			break;
		case 9:
			class1330_1.method_51(LabelPositionType.BestFit);
			break;
		case 10:
			class1330_1.bool_14 = true;
			class1330_1.method_51(LabelPositionType.Moved);
			break;
		}
		if ((byte_1[24] & 1) == 0)
		{
			class1330_1.FontColor = method_100(byte_1, 26);
		}
		else
		{
			class1330_1.FontColor = Color.Empty;
		}
		class1330_1.bool_11 = (byte_1[24] & 2) != 0;
	}

	private void method_71(Series series_0)
	{
		method_83(series_0);
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4163:
				method_72(arrayList_2.Count - 1);
				break;
			case 4165:
				method_77(series_0);
				chart_0.NSeries.method_8(series_0);
				arrayList_2.Add(new Class1690(series_0, 0));
				break;
			case 4147:
				num++;
				method_94();
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4177:
				method_85(series_0);
				break;
			case 4170:
				method_73(series_0);
				break;
			case 4109:
			{
				string text = method_84();
				if (series_0.method_13() == null)
				{
					series_0.method_12(text);
				}
				else
				{
					series_0.string_0 = text;
				}
				break;
			}
			case 4102:
				method_78(series_0);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_72(int int_4)
	{
		method_1();
		int num = BitConverter.ToUInt16(byte_1, 0);
		if (num == 65535)
		{
			num = int_4;
		}
		LegendEntry legendEntry = chart_0.Legend.LegendEntries[num];
		Class1690 @class = (Class1690)arrayList_2[int_4];
		@class.legendEntry_0 = legendEntry;
		if (((uint)byte_1[2] & (true ? 1u : 0u)) != 0)
		{
			legendEntry.IsDeleted = true;
			return;
		}
		Class1330 class2 = new Class1330(worksheetCollection_0, chart_0);
		int num2 = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4147:
				num2++;
				method_94();
				break;
			case 4148:
				method_95();
				num2--;
				if (num2 == 0)
				{
					class2.method_53(legendEntry);
					return;
				}
				break;
			case 4133:
				method_63(class2, bool_3: false);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_73(Series series_0)
	{
		method_1();
		int num = BitConverter.ToUInt16(byte_1, 0) - 1;
		Class1690 @class = null;
		if (num >= arrayList_2.Count)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				class1723_0.method_3(-2);
				break;
			case 4187:
				@class = new Class1690(series_0, 2);
				method_1();
				@class.byte_1 = byte_1;
				@class.int_0 = num;
				arrayList_2.Add(@class);
				break;
			case 4171:
				@class = new Class1690(series_0, 1);
				method_1();
				@class.byte_1 = byte_1;
				@class.int_0 = num;
				arrayList_2.Add(@class);
				break;
			}
		}
		else
		{
			@class = (Class1690)arrayList_2[num];
			if (@class.byte_0 != 0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Unspported TrendLine/ErrorBar in the chart.");
			}
			Series series_ = (Series)@class.object_0;
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				class1723_0.method_3(-2);
				break;
			case 4187:
				method_74(series_, series_0, null);
				break;
			case 4171:
				method_76(series_, series_0, null);
				int_1++;
				break;
			}
		}
	}

	private void method_74(Series series_0, Series series_1, Class1690 class1690_0)
	{
		method_1();
		bool flag = true;
		ErrorBarDisplayType errorBarDisplayType = ErrorBarDisplayType.None;
		switch (byte_1[0])
		{
		default:
			return;
		case 1:
			flag = false;
			errorBarDisplayType = ErrorBarDisplayType.Plus;
			break;
		case 2:
			flag = false;
			errorBarDisplayType = ErrorBarDisplayType.Minus;
			break;
		case 3:
			errorBarDisplayType = ErrorBarDisplayType.Plus;
			break;
		case 4:
			errorBarDisplayType = ErrorBarDisplayType.Minus;
			break;
		}
		ErrorBar errorBar = null;
		errorBar = ((!flag) ? series_0.XErrorBar : series_0.YErrorBar);
		if (class1690_0 == null)
		{
			class1690_0 = new Class1690(errorBar, 2);
			arrayList_2.Add(class1690_0);
		}
		else
		{
			class1690_0.object_0 = errorBar;
		}
		class1690_0.bool_0 = errorBarDisplayType == ErrorBarDisplayType.Plus;
		if (errorBar.DisplayType != ErrorBarDisplayType.None && errorBar.DisplayType != errorBarDisplayType && errorBar.method_33() == flag)
		{
			errorBar.method_31(ErrorBarDisplayType.Both);
			if (errorBar.Type == ErrorBarType.Custom)
			{
				switch (errorBarDisplayType)
				{
				case ErrorBarDisplayType.Minus:
					errorBar.method_38(series_1.method_16());
					break;
				case ErrorBarDisplayType.Plus:
					errorBar.method_36(series_1.method_16());
					break;
				case ErrorBarDisplayType.None:
					break;
				}
			}
			return;
		}
		errorBar.method_31(errorBarDisplayType);
		switch (byte_1[1])
		{
		case 1:
			errorBar.Type = ErrorBarType.Percent;
			break;
		case 2:
			errorBar.Type = ErrorBarType.FixedValue;
			break;
		case 3:
			errorBar.Type = ErrorBarType.StDev;
			break;
		case 4:
			errorBar.Type = ErrorBarType.Custom;
			break;
		case 5:
			errorBar.Type = ErrorBarType.StError;
			break;
		}
		errorBar.ShowMarkerTTop = byte_1[2] == 1;
		errorBar.method_32(BitConverter.ToDouble(byte_1, 4));
		errorBar.Copy(series_1.Line);
		if (errorBar.Type == ErrorBarType.Custom)
		{
			switch (errorBarDisplayType)
			{
			case ErrorBarDisplayType.Minus:
				errorBar.method_38(series_1.method_16());
				break;
			case ErrorBarDisplayType.Plus:
				errorBar.method_36(series_1.method_16());
				break;
			case ErrorBarDisplayType.None:
				break;
			}
		}
	}

	private void method_75()
	{
		for (int i = 0; i < arrayList_2.Count; i++)
		{
			Class1690 @class = (Class1690)arrayList_2[i];
			if (@class.byte_0 == 0 || @class.byte_1 == null)
			{
				continue;
			}
			Class1690 class2 = (Class1690)arrayList_2[@class.int_0];
			if (class2.byte_0 == 0)
			{
				switch (@class.byte_0)
				{
				case 1:
					method_76((Series)class2.object_0, (Series)@class.object_0, @class);
					break;
				case 2:
					method_74((Series)class2.object_0, (Series)@class.object_0, @class);
					break;
				}
			}
		}
	}

	private void method_76(Series series_0, Series series_1, Class1690 class1690_0)
	{
		if (class1690_0 == null)
		{
			method_1();
		}
		TrendlineType trendlineType = TrendlineType.Linear;
		switch (byte_1[0])
		{
		case 0:
			trendlineType = ((byte_1[1] == 1) ? TrendlineType.Linear : TrendlineType.Polynomial);
			break;
		case 1:
			trendlineType = TrendlineType.Exponential;
			break;
		case 2:
			trendlineType = TrendlineType.Logarithmic;
			break;
		case 3:
			trendlineType = TrendlineType.Power;
			break;
		case 4:
			trendlineType = TrendlineType.MovingAverage;
			break;
		}
		int index = series_0.TrendLines.method_0(trendlineType);
		Trendline trendline = series_0.TrendLines[index];
		if (class1690_0 == null)
		{
			arrayList_2.Add(new Class1690(trendline, 1));
		}
		else
		{
			class1690_0.object_0 = trendline;
		}
		switch (trendlineType)
		{
		case TrendlineType.MovingAverage:
			trendline.method_34(byte_1[1]);
			break;
		case TrendlineType.Polynomial:
			trendline.int_2 = byte_1[1];
			break;
		}
		double num = BitConverter.ToDouble(byte_1, 2);
		if (!double.IsNaN(num))
		{
			trendline.Intercept = num;
		}
		trendline.DisplayEquation = byte_1[10] == 1;
		trendline.DisplayRSquared = byte_1[11] == 1;
		trendline.Forward = BitConverter.ToDouble(byte_1, 12);
		trendline.method_35(BitConverter.ToDouble(byte_1, 20));
		if (series_1.Name != null && series_1.Name != "")
		{
			trendline.IsNameAuto = false;
			trendline.Name = series_1.Name;
		}
		trendline.Copy(series_1.Line);
	}

	private void method_77(Series series_0)
	{
		method_1();
		series_0.method_29(method_96(BitConverter.ToUInt16(byte_1, 0)));
	}

	private void method_78(object object_0)
	{
		method_1();
		bool flag = false;
		Class1632 @class = new Class1632(object_0);
		if (((uint)byte_1[6] & (true ? 1u : 0u)) != 0)
		{
			@class.bool_2 = true;
		}
		if (object_0 is Series)
		{
			Series series = (Series)object_0;
			ushort num = BitConverter.ToUInt16(byte_1, 0);
			switch (num)
			{
			case 65534:
				method_98();
				return;
			default:
			{
				ChartPoint chartPoint = series.Points.method_1(num);
				chartPoint.method_3(@class);
				object_0 = chartPoint;
				flag = true;
				break;
			}
			case ushort.MaxValue:
				series.method_8(@class);
				series.method_1(BitConverter.ToUInt16(byte_1, 4));
				break;
			}
		}
		else if (object_0 is Class1387)
		{
			Class1387 class2 = (Class1387)object_0;
			class2.method_4(@class);
		}
		int num2 = 0;
		bool flag2 = false;
		bool flag3 = false;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			case 4156:
				method_28(@class.Area);
				break;
			case 4147:
				num2++;
				method_94();
				break;
			case 4148:
				if (flag && !flag3 && !flag2)
				{
					@class.Border.IsAuto = true;
					@class.Area.Formatting = FormattingType.Automatic;
				}
				method_95();
				num2--;
				if (num2 == 0)
				{
					return;
				}
				break;
			case 4198:
				method_29(@class.Area);
				break;
			case 4189:
				method_80(@class);
				break;
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4191:
				method_81(@class);
				break;
			case 4103:
				method_88(@class.Border);
				flag2 = true;
				break;
			case 4105:
				method_91(@class.Marker);
				break;
			case 4106:
				method_90(@class.Area);
				flag3 = true;
				break;
			case 4107:
				method_89(@class.method_8());
				break;
			case 4108:
				if (object_0 is Series)
				{
					method_82(((Series)object_0).DataLabels);
				}
				else if (object_0 is ChartPoint)
				{
					method_82(((ChartPoint)object_0).DataLabels);
				}
				else if (object_0 is Class1387)
				{
					method_1();
					byte_2 = byte_1[0];
				}
				else
				{
					method_82(null);
				}
				break;
			case 2212:
				method_79(@class);
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private void method_79(Class1632 class1632_0)
	{
		method_1();
		int num = BitConverter.ToInt32(byte_1, 20) + 8;
		class1632_0.byte_0 = new byte[num];
		if (num <= ushort_1 - 16)
		{
			Array.Copy(byte_1, 16, class1632_0.byte_0, 0, num);
		}
		else
		{
			Array.Copy(byte_1, 16, class1632_0.byte_0, 0, ushort_1 - 16);
		}
	}

	private void method_80(Class1632 class1632_0)
	{
		method_1();
		class1632_0.Smooth = (byte_1[0] & 1) != 0;
		class1632_0.method_12((byte_1[0] & 2) != 0);
		class1632_0.Shadow = (byte_1[0] & 4) != 0;
	}

	private void method_81(Class1632 class1632_0)
	{
		method_1();
		switch (byte_1[0])
		{
		case 0:
			switch (byte_1[1])
			{
			case 0:
				class1632_0.method_2(Bar3DShapeType.Box);
				break;
			case 1:
				class1632_0.method_2(Bar3DShapeType.PyramidToPoint);
				break;
			case 2:
				class1632_0.method_2(Bar3DShapeType.PyramidToMax);
				break;
			}
			break;
		case 1:
			switch (byte_1[1])
			{
			case 0:
				class1632_0.method_2(Bar3DShapeType.Cylinder);
				break;
			case 1:
				class1632_0.method_2(Bar3DShapeType.ConeToPoint);
				break;
			case 2:
				class1632_0.method_2(Bar3DShapeType.ConeToMax);
				break;
			}
			break;
		}
	}

	private void method_82(DataLabels dataLabels_0)
	{
		if (dataLabels_0 == null)
		{
			class1723_0.method_3(4);
			return;
		}
		method_1();
		bool bool_;
		if (bool_ = (byte_1[0] & 1) != 0)
		{
			dataLabels_0.method_45(Enum127.const_1, bool_);
		}
		if (bool_ = (byte_1[0] & 2) != 0)
		{
			dataLabels_0.method_45(Enum127.const_2, bool_);
		}
		if (bool_ = (byte_1[0] & 0x10) != 0)
		{
			dataLabels_0.method_45(Enum127.const_3, bool_);
		}
		if (bool_ = (byte_1[0] & 0x20) != 0)
		{
			dataLabels_0.method_45(Enum127.const_4, bool_);
		}
	}

	private void method_83(Series series_0)
	{
		method_1();
		int_0 = BitConverter.ToUInt16(byte_1, 6);
	}

	private string method_84()
	{
		method_1();
		byte b = byte_1[2];
		if (b == 0)
		{
			return "";
		}
		if (byte_1[3] == 0)
		{
			return Encoding.ASCII.GetString(byte_1, 4, b);
		}
		return Encoding.Unicode.GetString(byte_1, 4, 2 * b);
	}

	private void method_85(Series series_0)
	{
		method_1();
		int num = BitConverter.ToUInt16(byte_1, 6);
		int num2 = BitConverter.ToUInt16(byte_1, 4);
		if (num == 0)
		{
			return;
		}
		byte[] array = new byte[num + 2];
		Array.Copy(byte_1, 6, array, 0, num + 2);
		Interface45 @interface = Class1195.smethod_0(worksheetCollection_0, worksheet_0);
		switch (array[2])
		{
		default:
			@interface.imethod_14(Enum126.const_5);
			break;
		case 57:
		case 89:
		case 121:
			@interface.imethod_14(Enum126.const_4);
			break;
		case 58:
		case 60:
		case 90:
		case 92:
		case 122:
		case 124:
			@interface.imethod_14(Enum126.const_2);
			if (num != 7)
			{
				@interface.imethod_14(Enum126.const_5);
			}
			break;
		case 59:
		case 61:
		case 91:
		case 93:
		case 123:
		case 125:
			@interface.imethod_14(Enum126.const_3);
			if (num != 11)
			{
				@interface.imethod_14(Enum126.const_5);
			}
			break;
		}
		@interface.imethod_5(array);
		switch (byte_1[0])
		{
		case 0:
			series_0.method_12(array);
			break;
		case 1:
			series_0.method_17(@interface);
			series_0.int_2 = num2;
			break;
		case 2:
			series_0.method_19(@interface);
			break;
		case 3:
			series_0.method_21(@interface);
			break;
		}
	}

	private void method_86(ChartFrame chartFrame_0)
	{
		method_1();
		chartFrame_0.Shadow = (byte_1[0] & 4) != 0;
		chartFrame_0.IsAutoSize = (byte_1[2] & 1) != 0;
	}

	private void method_87(Axis axis_0)
	{
		method_1();
		if ((byte_1[8] & 8u) != 0 && (byte_1[8] & 4) == 0 && byte_1[4] == 5)
		{
			axis_0.IsVisible = false;
		}
		if (!axis_0.IsVisible)
		{
			return;
		}
		Line axisLine = axis_0.AxisLine;
		if ((byte_1[8] & 1) == 0)
		{
			axisLine.method_25(LineType.Solid);
			switch (byte_1[4])
			{
			case 0:
				axisLine.method_25(LineType.Solid);
				break;
			case 1:
				axisLine.method_25(LineType.Dash);
				break;
			case 2:
				axisLine.method_25(LineType.Dot);
				break;
			case 3:
				axisLine.method_25(LineType.DashDot);
				break;
			case 4:
				axisLine.method_25(LineType.DashDotDot);
				break;
			case 5:
				axisLine.IsVisible = false;
				break;
			case 6:
				axisLine.method_25(LineType.DarkGray);
				break;
			case 7:
				axisLine.method_25(LineType.MediumGray);
				break;
			case 8:
				axisLine.method_25(LineType.LightGray);
				break;
			}
			switch (byte_1[6])
			{
			case byte.MaxValue:
				axisLine.Weight = WeightType.HairLine;
				break;
			case 0:
				axisLine.Weight = WeightType.SingleLine;
				break;
			case 1:
				axisLine.Weight = WeightType.MediumLine;
				break;
			case 2:
				axisLine.Weight = WeightType.WideLine;
				break;
			}
			if (byte_1[10] < 64)
			{
				axisLine.method_21(GetColor(byte_1, 0));
			}
		}
	}

	private void method_88(Line line_0)
	{
		method_1();
		bool isAuto;
		if (isAuto = (byte_1[8] & 1) != 0)
		{
			line_0.IsAuto = isAuto;
			return;
		}
		line_0.method_25(LineType.Solid);
		switch (byte_1[6])
		{
		case byte.MaxValue:
			line_0.Weight = WeightType.HairLine;
			break;
		case 0:
			line_0.Weight = WeightType.SingleLine;
			break;
		case 1:
			line_0.Weight = WeightType.MediumLine;
			break;
		case 2:
			line_0.Weight = WeightType.WideLine;
			break;
		}
		int num = byte_1[10];
		if (num < 64)
		{
			line_0.Color = worksheetCollection_0.method_24().method_7(num);
		}
		switch (byte_1[4])
		{
		case 0:
			line_0.method_25(LineType.Solid);
			break;
		case 1:
			line_0.method_25(LineType.Dash);
			break;
		case 2:
			line_0.method_25(LineType.Dot);
			break;
		case 3:
			line_0.method_25(LineType.DashDot);
			break;
		case 4:
			line_0.method_25(LineType.DashDotDot);
			break;
		case 5:
			line_0.IsVisible = false;
			break;
		case 6:
			line_0.method_25(LineType.DarkGray);
			break;
		case 7:
			line_0.method_25(LineType.MediumGray);
			break;
		case 8:
			line_0.method_25(LineType.LightGray);
			break;
		}
	}

	private void method_89(Class1633 class1633_0)
	{
		method_1();
		class1633_0.method_1(BitConverter.ToUInt16(byte_1, 0));
	}

	private void method_90(Area area_0)
	{
		method_1();
		bool flag = (byte_1[10] & 1) != 0;
		area_0.InvertIfNegative = (byte_1[10] & 2) != 0;
		if (flag)
		{
			area_0.Formatting = FormattingType.Automatic;
			return;
		}
		switch (byte_1[8])
		{
		case 0:
			area_0.Formatting = FormattingType.None;
			break;
		case 1:
			area_0.Formatting = FormattingType.Custom;
			break;
		case 2:
			area_0.FillFormat.Pattern = FillPattern.Gray50;
			break;
		case 3:
			area_0.FillFormat.Pattern = FillPattern.Gray75;
			break;
		case 4:
			area_0.FillFormat.Pattern = FillPattern.Gray25;
			break;
		case 5:
			area_0.FillFormat.Pattern = FillPattern.DarkHorizontal;
			break;
		case 6:
			area_0.FillFormat.Pattern = FillPattern.DarkVertical;
			break;
		case 7:
			area_0.FillFormat.Pattern = FillPattern.DarkDownwardDiagonal;
			break;
		case 8:
			area_0.FillFormat.Pattern = FillPattern.DarkUpwardDiagonal;
			break;
		case 9:
			area_0.FillFormat.Pattern = FillPattern.Plaid;
			break;
		case 10:
			area_0.FillFormat.Pattern = FillPattern.Trellis;
			break;
		case 11:
			area_0.FillFormat.Pattern = FillPattern.LightHorizontal;
			break;
		case 12:
			area_0.FillFormat.Pattern = FillPattern.LightVertical;
			break;
		case 13:
			area_0.FillFormat.Pattern = FillPattern.LightDownwardDiagonal;
			break;
		case 14:
			area_0.FillFormat.Pattern = FillPattern.LightUpwardDiagonal;
			break;
		case 15:
			area_0.FillFormat.Pattern = FillPattern.HorizontalBrick;
			break;
		case 16:
			area_0.FillFormat.Pattern = FillPattern.Gray30;
			break;
		case 17:
			area_0.FillFormat.Pattern = FillPattern.Gray20;
			break;
		case 18:
			area_0.FillFormat.Pattern = FillPattern.Gray5;
			break;
		}
		if (area_0.Formatting == FormattingType.Custom && area_0.FillFormat.Type == FillType.Solid)
		{
			int num = BitConverter.ToInt32(byte_1, 0);
			int num2 = BitConverter.ToUInt16(byte_1, 12);
			if (num == 0 && num2 < 64)
			{
				area_0.FillFormat.SolidFill.internalColor_0.SetColor(ColorType.IndexedColor, BitConverter.ToUInt16(byte_1, 12));
			}
			else
			{
				area_0.FillFormat.SolidFill.internalColor_0.SetColor(ColorType.RGB, GetColor(byte_1, 0).ToArgb());
			}
			num = BitConverter.ToInt32(byte_1, 4);
			num2 = BitConverter.ToUInt16(byte_1, 14);
			if (num == 0 && num2 < 64)
			{
				area_0.FillFormat.SolidFill.internalColor_1.SetColor(ColorType.IndexedColor, BitConverter.ToUInt16(byte_1, 14));
			}
			else
			{
				area_0.FillFormat.SolidFill.internalColor_1.SetColor(ColorType.RGB, GetColor(byte_1, 4).ToArgb());
			}
		}
	}

	private void method_91(Marker marker_0)
	{
		method_1();
		if (((uint)byte_1[10] & (true ? 1u : 0u)) != 0)
		{
			return;
		}
		switch (byte_1[8])
		{
		case 0:
			marker_0.MarkerStyle = ChartMarkerType.None;
			break;
		case 1:
			marker_0.MarkerStyle = ChartMarkerType.Square;
			break;
		case 2:
			marker_0.MarkerStyle = ChartMarkerType.Diamond;
			break;
		case 3:
			marker_0.MarkerStyle = ChartMarkerType.Triangle;
			break;
		case 4:
			marker_0.MarkerStyle = ChartMarkerType.SquareX;
			break;
		case 5:
			marker_0.MarkerStyle = ChartMarkerType.SquareStar;
			break;
		case 6:
			marker_0.MarkerStyle = ChartMarkerType.Dot;
			break;
		case 7:
			marker_0.MarkerStyle = ChartMarkerType.Dash;
			break;
		case 8:
			marker_0.MarkerStyle = ChartMarkerType.Circle;
			break;
		case 9:
			marker_0.MarkerStyle = ChartMarkerType.SquarePlus;
			break;
		}
		marker_0.MarkerSize = (int)BitConverter.ToUInt16(byte_1, 16) / 20;
		if ((byte_1[10] & 0x10u) != 0)
		{
			marker_0.MarkerBackgroundColorSetType = FormattingType.None;
		}
		else
		{
			int num = BitConverter.ToUInt16(byte_1, 14);
			int num2 = num;
			if (num2 == 255)
			{
				marker_0.MarkerBackgroundColor = Color.FromArgb(byte_1[4], byte_1[5], byte_1[6]);
			}
			else
			{
				marker_0.MarkerBackgroundColor = palette_0.method_7(num);
			}
		}
		if ((byte_1[10] & 0x20u) != 0)
		{
			marker_0.MarkerForegroundColorSetType = FormattingType.None;
			return;
		}
		int num3 = BitConverter.ToUInt16(byte_1, 12);
		switch (num3)
		{
		case 255:
			marker_0.MarkerForegroundColor = Color.FromArgb(byte_1[0], byte_1[1], byte_1[2]);
			break;
		default:
			marker_0.MarkerForegroundColor = palette_0.method_7(num3);
			break;
		case 79:
			marker_0.MarkerForegroundColor = Color.Black;
			break;
		}
	}

	private void method_92()
	{
		class1723_0.method_3(2);
	}

	private void method_93()
	{
		class1723_0.method_3(18);
	}

	private void method_94()
	{
		class1723_0.method_3(2);
	}

	private void method_95()
	{
		class1723_0.method_3(2);
	}

	private Class1387 method_96(int int_4)
	{
		if (int_4 >= chart_0.method_18().Count)
		{
			int num = int_4 - chart_0.method_18().Count + 1;
			for (int i = 0; i < num; i++)
			{
				Class1387 class1387_ = new Class1387(chart_0.method_18());
				chart_0.method_18().Add(class1387_);
			}
		}
		return chart_0.method_18()[int_4];
	}

	private string method_97(int int_4)
	{
		foreach (Class639 item in worksheetCollection_0.method_55())
		{
			if (item.Index == int_4)
			{
				return item.Custom;
			}
		}
		return "";
	}

	private void method_98()
	{
		int num = 0;
		while (true)
		{
			ushort_0 = class1723_0.method_2(byte_0);
			switch (ushort_0)
			{
			default:
				ushort_1 = class1723_0.method_2(byte_0);
				class1723_0.method_3(ushort_1);
				break;
			case 4147:
				method_94();
				num++;
				break;
			case 4148:
				method_95();
				num--;
				if (num == 0)
				{
					return;
				}
				break;
			case 10:
			case 574:
				throw new IOException("File is corrupted");
			}
		}
	}

	private TimeUnit method_99(int int_4)
	{
		return int_4 switch
		{
			0 => TimeUnit.Days, 
			1 => TimeUnit.Months, 
			2 => TimeUnit.Years, 
			_ => TimeUnit.Days, 
		};
	}

	private Color GetColor(byte[] byte_3, int int_4)
	{
		return Color.FromArgb(byte_3[int_4], byte_3[int_4 + 1], byte_3[int_4 + 2]);
	}

	private Color method_100(byte[] byte_3, int int_4)
	{
		int num = BitConverter.ToInt16(byte_3, int_4);
		return worksheetCollection_0.method_24().method_7(num);
	}

	private void method_101(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class == null)
		{
			return;
		}
		switch (class1387_0.method_11())
		{
		case ChartType.Bar3DClustered:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
					class1387_0.method_13(ChartType.PyramidBar);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.CylindricalBar);
					break;
				case Bar3DShapeType.ConeToPoint:
					class1387_0.method_13(ChartType.ConicalBar);
					break;
				case Bar3DShapeType.PyramidToMax:
					break;
				}
			}
			break;
		case ChartType.Bar3DStacked:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
					class1387_0.method_13(ChartType.PyramidBarStacked);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.CylindricalBarStacked);
					break;
				case Bar3DShapeType.ConeToPoint:
					class1387_0.method_13(ChartType.ConicalBarStacked);
					break;
				case Bar3DShapeType.PyramidToMax:
					break;
				}
			}
			break;
		case ChartType.Bar3D100PercentStacked:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
				case Bar3DShapeType.PyramidToMax:
					class1387_0.method_13(ChartType.PyramidBar100PercentStacked);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.CylindricalBar100PercentStacked);
					break;
				case Bar3DShapeType.ConeToPoint:
				case Bar3DShapeType.ConeToMax:
					class1387_0.method_13(ChartType.ConicalBar100PercentStacked);
					break;
				}
			}
			break;
		case ChartType.Column3D:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
					class1387_0.method_13(ChartType.PyramidColumn3D);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.CylindricalColumn3D);
					break;
				case Bar3DShapeType.ConeToPoint:
					class1387_0.method_13(ChartType.ConicalColumn3D);
					break;
				case Bar3DShapeType.PyramidToMax:
					break;
				}
			}
			break;
		case ChartType.Column3DClustered:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
					class1387_0.method_13(ChartType.Pyramid);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.Cylinder);
					break;
				case Bar3DShapeType.ConeToPoint:
					class1387_0.method_13(ChartType.Cone);
					break;
				case Bar3DShapeType.PyramidToMax:
					break;
				}
			}
			break;
		case ChartType.Column3DStacked:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
					class1387_0.method_13(ChartType.PyramidStacked);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.CylinderStacked);
					break;
				case Bar3DShapeType.ConeToPoint:
					class1387_0.method_13(ChartType.ConeStacked);
					break;
				case Bar3DShapeType.PyramidToMax:
					break;
				}
			}
			break;
		case ChartType.Column3D100PercentStacked:
			if (@class.bool_4)
			{
				switch (@class.method_3())
				{
				case Bar3DShapeType.PyramidToPoint:
				case Bar3DShapeType.PyramidToMax:
					class1387_0.method_13(ChartType.Pyramid100PercentStacked);
					break;
				case Bar3DShapeType.Cylinder:
					class1387_0.method_13(ChartType.Cylinder100PercentStacked);
					break;
				case Bar3DShapeType.ConeToPoint:
				case Bar3DShapeType.ConeToMax:
					class1387_0.method_13(ChartType.Cone100PercentStacked);
					break;
				}
			}
			break;
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		case ChartType.Column:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
			break;
		}
	}

	private void method_102(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class != null && @class.method_7() != null && @class.Marker.MarkerStyle == ChartMarkerType.None)
		{
			switch (class1387_0.method_11())
			{
			case ChartType.LineWithDataMarkers:
				class1387_0.method_13(ChartType.Line);
				break;
			case ChartType.LineStackedWithDataMarkers:
				class1387_0.method_13(ChartType.LineStacked);
				break;
			case ChartType.Line100PercentStackedWithDataMarkers:
				class1387_0.method_13(ChartType.Line100PercentStacked);
				break;
			}
		}
	}

	private void method_103(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class != null && @class.method_6() != null && @class.method_8().method_0() != 0)
		{
			switch (class1387_0.method_11())
			{
			case ChartType.Pie:
				class1387_0.method_13(ChartType.PieExploded);
				break;
			case ChartType.Pie3D:
				class1387_0.method_13(ChartType.Pie3DExploded);
				break;
			case ChartType.Doughnut:
				class1387_0.method_13(ChartType.DoughnutExploded);
				break;
			}
		}
	}

	private void method_104(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class != null && @class.method_11())
		{
			class1387_0.method_13(ChartType.Bubble3D);
		}
	}

	private void method_105(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class != null && @class.method_7() != null && @class.Marker.MarkerStyle == ChartMarkerType.None)
		{
			class1387_0.method_13(ChartType.Radar);
		}
	}

	private void method_106(Class1387 class1387_0, Class1632 class1632_0)
	{
		bool flag = class1632_0.method_7() == null || class1632_0.Marker.MarkerStyle != ChartMarkerType.None;
		bool flag2 = class1632_0.method_4() == null || class1632_0.Border.IsVisible;
		bool smooth = class1632_0.Smooth;
		if (!flag2)
		{
			class1387_0.method_13(ChartType.Scatter);
		}
		else if (flag)
		{
			if (smooth)
			{
				class1387_0.method_13(ChartType.ScatterConnectedByCurvesWithDataMarker);
			}
			else
			{
				class1387_0.method_13(ChartType.ScatterConnectedByLinesWithDataMarker);
			}
		}
		else if (smooth)
		{
			class1387_0.method_13(ChartType.ScatterConnectedByCurvesWithoutDataMarker);
		}
		else
		{
			class1387_0.method_13(ChartType.ScatterConnectedByLinesWithoutDataMarker);
		}
	}

	private void method_107(Class1387 class1387_0)
	{
		Class1632 @class = class1387_0.method_5();
		if (@class == null && chart_0.NSeries.Count == 1)
		{
			@class = chart_0.NSeries[0].method_9();
		}
		if (@class != null)
		{
			switch (class1387_0.method_11())
			{
			case ChartType.LineWithDataMarkers:
			case ChartType.LineStackedWithDataMarkers:
			case ChartType.Line100PercentStackedWithDataMarkers:
				method_102(class1387_0);
				break;
			case ChartType.Doughnut:
			case ChartType.Pie:
			case ChartType.Pie3D:
				method_103(class1387_0);
				break;
			case ChartType.Bubble:
				method_104(class1387_0);
				break;
			case ChartType.Bar:
			case ChartType.BarStacked:
			case ChartType.Bar100PercentStacked:
			case ChartType.Bar3DClustered:
			case ChartType.Bar3DStacked:
			case ChartType.Bar3D100PercentStacked:
			case ChartType.Column:
			case ChartType.ColumnStacked:
			case ChartType.Column100PercentStacked:
			case ChartType.Column3D:
			case ChartType.Column3DClustered:
			case ChartType.Column3DStacked:
			case ChartType.Column3D100PercentStacked:
				method_101(class1387_0);
				break;
			case ChartType.ScatterConnectedByLinesWithDataMarker:
				method_106(class1387_0, @class);
				break;
			case ChartType.RadarWithDataMarkers:
				method_105(class1387_0);
				break;
			}
		}
	}
}
