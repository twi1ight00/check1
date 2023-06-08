using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns27;
using ns59;

namespace ns7;

internal class Class1329
{
	private Class1725 class1725_0;

	private WorksheetCollection worksheetCollection_0;

	private Chart chart_0;

	private int int_0;

	private FileFormatType fileFormatType_0;

	internal Class1329(Class1725 class1725_1, WorksheetCollection worksheetCollection_1, int int_1, Chart chart_1)
	{
		class1725_0 = class1725_1;
		worksheetCollection_0 = worksheetCollection_1;
		chart_0 = chart_1;
		int_0 = int_1;
		fileFormatType_0 = worksheetCollection_1.method_23();
	}

	private void method_0(Area area_0)
	{
		if (area_0 != null)
		{
			Class594 @class = new Class594(fileFormatType_0, worksheetCollection_0.method_24());
			@class.method_4(area_0);
			@class.vmethod_0(class1725_0);
			method_1(@class);
		}
	}

	private Class643 method_1(Class594 class594_0)
	{
		Class643 @class = null;
		if (class594_0 == null)
		{
			return null;
		}
		if (class594_0.Area.method_0())
		{
			FillFormat fillFormat = class594_0.Area.FillFormat;
			@class = new Class643();
			@class.method_4(fillFormat);
			@class.vmethod_0(class1725_0);
			PicFormatOption picFormatOption = null;
			if (fillFormat.SetType == FormatSetType.IsTextureSet)
			{
				picFormatOption = fillFormat.TextureFill.method_5();
			}
			if (picFormatOption != null)
			{
				class1725_0.method_5(4147);
				Class590 class2 = new Class590(picFormatOption);
				class2.vmethod_0(class1725_0);
				class1725_0.method_5(4148);
			}
		}
		else if (class594_0.method_5())
		{
			@class = new Class643();
			@class.method_8(class594_0.Area);
			@class.vmethod_0(class1725_0);
		}
		return @class;
	}

	private void method_2(Font font_0, int int_1, int int_2, ArrayList arrayList_0)
	{
		if (font_0 == null && int_1 == -1)
		{
			return;
		}
		if (font_0 != null)
		{
			int_1 = font_0.method_21();
		}
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			Class593 @class = new Class593();
			int num = @class.method_4(int_2, int_1, arrayList_0);
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

	internal ArrayList method_3()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < chart_0.NSeries.Count; i++)
		{
			method_7(chart_0.NSeries[i], i);
			arrayList.Add(new Class1690(chart_0.NSeries[i], 0));
		}
		for (int j = 0; j < chart_0.NSeries.Count; j++)
		{
			Series series = chart_0.NSeries[j];
			if (series.method_22() != null && series.method_22().Count > 0)
			{
				method_13(series, j, arrayList, chart_0.NSeries.Count);
			}
		}
		method_14(arrayList, chart_0.NSeries.Count);
		for (int k = 0; k < chart_0.NSeries.Count; k++)
		{
			Series series2 = chart_0.NSeries[k];
			method_4(series2.method_33(), k, arrayList);
			method_4(series2.method_32(), k, arrayList);
		}
		Class591 @class = new Class591(chart_0);
		@class.long_0 = class1725_0.method_10();
		@class.vmethod_0(class1725_0);
		chart_0.method_59(@class);
		return arrayList;
	}

	internal void method_4(ErrorBar errorBar_0, int int_1, ArrayList arrayList_0)
	{
		if (errorBar_0 == null || errorBar_0.DisplayType == ErrorBarDisplayType.None)
		{
			return;
		}
		if (errorBar_0.Type != 0)
		{
			if (errorBar_0.DisplayType == ErrorBarDisplayType.Both)
			{
				errorBar_0.method_31(ErrorBarDisplayType.Plus);
				method_5(errorBar_0, worksheetCollection_0.method_24(), int_1, null, arrayList_0.Count);
				method_6(errorBar_0, 2, bool_0: true, arrayList_0);
				errorBar_0.method_31(ErrorBarDisplayType.Minus);
				method_5(errorBar_0, worksheetCollection_0.method_24(), int_1, null, arrayList_0.Count);
				method_6(errorBar_0, 2, bool_0: false, arrayList_0);
				errorBar_0.method_31(ErrorBarDisplayType.Both);
			}
			else
			{
				method_5(errorBar_0, worksheetCollection_0.method_24(), int_1, null, arrayList_0.Count);
				method_6(errorBar_0, 2, errorBar_0.DisplayType == ErrorBarDisplayType.Plus, arrayList_0);
			}
			return;
		}
		ErrorBarDisplayType displayType = errorBar_0.DisplayType;
		if (errorBar_0.method_35() != null)
		{
			errorBar_0.method_31(ErrorBarDisplayType.Plus);
			method_5(errorBar_0, worksheetCollection_0.method_24(), int_1, errorBar_0.method_35(), arrayList_0.Count);
			method_6(errorBar_0, 2, bool_0: true, arrayList_0);
		}
		if (errorBar_0.method_37() != null)
		{
			errorBar_0.method_31(ErrorBarDisplayType.Minus);
			method_5(errorBar_0, worksheetCollection_0.method_24(), int_1, errorBar_0.method_37(), arrayList_0.Count);
			method_6(errorBar_0, 2, bool_0: false, arrayList_0);
		}
		errorBar_0.method_31(displayType);
	}

	internal void method_5(ErrorBar errorBar_0, Palette palette_0, int int_1, Interface45 interface45_0, int int_2)
	{
		Class699 @class = new Class699(FileFormatType.Default);
		@class.method_5(errorBar_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		for (int i = 0; i < 4; i++)
		{
			Class592 class2 = new Class592();
			if (i == 1 && interface45_0 != null)
			{
				class2.method_9(1, interface45_0, int_0, class1725_0, 0);
				continue;
			}
			class2.method_4(i);
			class2.vmethod_0(class1725_0);
		}
		Class622 class3 = new Class622();
		class3.method_5(int_2);
		class3.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class604 class4 = new Class604();
		class4.vmethod_0(class1725_0);
		Class651 class5 = new Class651(FileFormatType.Default, palette_0);
		if (!errorBar_0.IsAuto)
		{
			class5.method_6(errorBar_0, bool_0: false);
		}
		class5.vmethod_0(class1725_0);
		Class594 class6 = new Class594(FileFormatType.Default, palette_0);
		class6.vmethod_0(class1725_0);
		Class666 class7 = new Class666();
		class7.vmethod_0(class1725_0);
		Class653 class8 = new Class653(FileFormatType.Default, palette_0);
		class8.vmethod_0(class1725_0);
		class1725_0.method_5(4148);
		Class701 class9 = new Class701();
		class9.method_4((ushort)(int_1 + 1));
		class9.vmethod_0(class1725_0);
		Class696 class10 = new Class696();
		class10.method_4(errorBar_0);
		class10.vmethod_0(class1725_0);
		class1725_0.method_5(4148);
	}

	private void method_6(object object_0, byte byte_0, bool bool_0, ArrayList arrayList_0)
	{
		Class1690 @class = new Class1690(object_0, byte_0);
		@class.bool_0 = bool_0;
		arrayList_0.Add(@class);
	}

	private void method_7(Series series_0, int int_1)
	{
		method_8(series_0);
		class1725_0.method_5(4147);
		Class592 @class = new Class592();
		@class.method_10(chart_0, series_0, worksheetCollection_0, int_0, class1725_0);
		method_10(series_0, int_1, series_0.method_0(), series_0.Type);
	}

	private void method_8(Series series_0)
	{
		Class699 @class = new Class699(fileFormatType_0);
		@class.method_6(series_0, series_0.Type);
		@class.vmethod_0(class1725_0);
	}

	internal void method_9(Chart chart_1)
	{
		for (int i = 0; i < chart_1.NSeries.Count; i++)
		{
			Series series = chart_1.NSeries[i];
			if (series.method_3() != null)
			{
				for (int j = 0; j < series.Points.method_4(); j++)
				{
					ChartPoint chartPoint = series.Points.method_7(j);
					if (chartPoint.method_9() != null && (chartPoint.method_9().method_65() || chartPoint.method_9().IsDeleted))
					{
						method_16(chartPoint.method_9(), i, chartPoint.int_0);
					}
				}
			}
			if (series.method_24() != null && series.method_24().method_65())
			{
				method_16(series.method_24(), i, 65535);
			}
		}
		int num = chart_1.NSeries.Count;
		for (int k = 0; k < chart_1.NSeries.Count; k++)
		{
			Series series2 = chart_1.NSeries[k];
			if (series2.method_22() == null || series2.TrendLines.Count == 0)
			{
				continue;
			}
			for (int l = 0; l < series2.TrendLines.Count; l++)
			{
				Trendline trendline = series2.TrendLines[l];
				if (trendline.method_36() != null)
				{
					method_16(trendline.DataLabels, num, 65535);
				}
				num++;
			}
		}
	}

	internal void method_10(Series series_0, int int_1, int int_2, ChartType chartType_0)
	{
		method_15(65535, int_1, int_2, series_0.method_9() != null && series_0.method_7().bool_2);
		class1725_0.method_5(4147);
		Class604 @class = new Class604();
		if (ChartCollection.smethod_10(series_0.Type))
		{
			@class.method_4(series_0.Bar3DShapeType);
		}
		@class.vmethod_0(class1725_0);
		bool flag = (flag = series_0.method_9() != null && !series_0.method_7().IsAuto) | (series_0.method_24() != null);
		if (series_0.method_28().method_3() != null && !series_0.method_28().method_3().IsAuto && !flag)
		{
			flag = series_0.method_30() != null;
		}
		Line line = series_0.method_6();
		if (line == null && flag)
		{
			line = series_0.method_28().method_8();
		}
		Class651 class2 = null;
		if (line != null || flag)
		{
			class2 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			if (line != null)
			{
				class2.method_5(line, int_1);
			}
			class2.vmethod_0(class1725_0);
		}
		Area area = series_0.method_5();
		if (area == null && flag)
		{
			area = series_0.method_28().method_9();
		}
		Class594 class3 = null;
		if (area != null || flag)
		{
			class3 = new Class594(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			if (area != null)
			{
				class3.method_4(area);
			}
			class3.vmethod_0(class1725_0);
		}
		if (area != null)
		{
			method_1(class3);
		}
		if (series_0.method_28().method_10() != null)
		{
			Class666 class4 = new Class666();
			class4.method_4(series_0.method_28().method_10());
			class4.vmethod_0(class1725_0);
		}
		if (series_0.Smooth || series_0.Has3DEffect || series_0.Shadow)
		{
			Class698 class5 = new Class698(series_0.Smooth, series_0.Shadow, series_0.Has3DEffect);
			class5.vmethod_0(class1725_0);
		}
		Marker marker = series_0.method_30();
		if (marker == null && flag)
		{
			marker = series_0.method_28().method_7();
		}
		if (marker != null || flag)
		{
			Class653 class6 = new Class653(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			if (marker != null)
			{
				class6.method_4(marker, int_1);
			}
			class6.vmethod_0(class1725_0);
			class6 = null;
		}
		if (series_0.method_24() != null && series_0.method_24().method_64())
		{
			Class597 class7 = new Class597();
			class7.method_4(series_0.method_24(), worksheetCollection_0.method_23());
			class7.vmethod_0(class1725_0);
		}
		bool flag2 = false;
		if (series_0.method_9() != null && series_0.method_9().byte_0 != null)
		{
			flag2 = true;
			Class679 class8 = new Class679();
			class8.method_4(12, 0, int_1, 0);
			class8.vmethod_0(class1725_0);
			Class679 class9 = new Class679();
			class9.method_4(14, int_1, 65535, 0);
			class9.vmethod_0(class1725_0);
			Class552 class10 = new Class552();
			class10.method_4(0, series_0.method_9().byte_0);
			class10.vmethod_0(class1725_0);
			Class680 class11 = new Class680();
			class11.method_4(14, 0, 0, 0);
			class11.vmethod_0(class1725_0);
		}
		class1725_0.method_5(4148);
		if (series_0.method_3() != null && series_0.method_3().method_4() > 0)
		{
			method_12(series_0, int_1, chartType_0);
		}
		class1725_0.method_8(4165);
		class1725_0.method_8(2);
		class1725_0.method_7((short)series_0.method_25());
		if (chart_0.method_24() != null && chart_0.method_24().method_44() != null && chart_0.Legend.LegendEntries.Count != 0)
		{
			LegendEntryCollection legendEntries = chart_0.Legend.LegendEntries;
			if (!ChartCollection.smethod_3(series_0.Type) && !ChartCollection.smethod_13(series_0.Type) && !ChartCollection.smethod_5(series_0.Type) && (chart_0.NSeries.Count != 1 || !series_0.IsColorVaried))
			{
				LegendEntry legendEntry = legendEntries.method_0(int_1);
				if (legendEntry != null && (legendEntry.IsDeleted || legendEntry.method_0() != null))
				{
					method_11(legendEntry, 65535);
				}
			}
			else if (int_1 == 0)
			{
				foreach (LegendEntry item in legendEntries)
				{
					method_11(item, item.Index);
				}
			}
		}
		if (flag2)
		{
			Class680 class12 = new Class680();
			class12.method_4(12, 0, 0, 0);
			class12.vmethod_0(class1725_0);
		}
		class1725_0.method_5(4148);
	}

	private void method_11(LegendEntry legendEntry_0, int int_1)
	{
		Class650 @class = new Class650(legendEntry_0.IsDeleted, int_1);
		@class.vmethod_0(class1725_0);
		if (!legendEntry_0.IsDeleted)
		{
			class1725_0.method_5(4147);
			Class713 class2 = new Class713(worksheetCollection_0.method_23());
			class2.method_5(legendEntry_0.Font);
			class2.method_10(legendEntry_0.BackgroundMode);
			class2.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			Class669 class3 = new Class669(bool_0: false);
			class3.vmethod_0(class1725_0);
			method_2(legendEntry_0.method_0(), legendEntry_0.method_1(), 0, null);
			Class592 class4 = new Class592();
			class4.method_5();
			class4.vmethod_0(class1725_0);
			class1725_0.method_5(4148);
			class1725_0.method_5(4148);
		}
	}

	private void method_12(Series series_0, int int_1, ChartType chartType_0)
	{
		ChartPointCollection chartPointCollection = series_0.method_3();
		for (int i = 0; i < series_0.method_3().method_4(); i++)
		{
			ChartPoint chartPoint = chartPointCollection.method_7(i);
			if (!chartPoint.IsAuto)
			{
				method_15(chartPoint.int_0, int_1, int_1, chartPoint.method_2().bool_2);
				class1725_0.method_5(4147);
				Class604 @class = new Class604();
				@class.method_5(series_0.method_27());
				@class.vmethod_0(class1725_0);
				Class651 class2 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
				class2.method_6(chartPoint.Border, bool_0: false);
				class2.vmethod_0(class1725_0);
				method_0(chartPoint.Area);
				Class666 class3 = new Class666();
				if (chartPoint.method_8() != null)
				{
					class3.method_4(chartPoint.method_8());
				}
				class3.vmethod_0(class1725_0);
				Class653 class4 = new Class653(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
				class4.method_4(chartPoint.Marker, int_1);
				class4.vmethod_0(class1725_0);
				if (chartPoint.method_9() != null && chartPoint.method_9().method_64())
				{
					Class597 class5 = new Class597();
					class5.method_4(chartPoint.method_9(), worksheetCollection_0.method_23());
					class5.vmethod_0(class1725_0);
				}
				class1725_0.method_5(4148);
			}
		}
	}

	private void method_13(Series series_0, int int_1, ArrayList arrayList_0, int int_2)
	{
		TrendlineCollection trendlineCollection = series_0.method_22();
		for (int i = 0; i < trendlineCollection.Count; i++)
		{
			Trendline trendline = trendlineCollection[i];
			Class1690 @class = new Class1690(trendline, 1);
			@class.int_0 = int_1;
			@class.int_1 = i;
			int j;
			for (j = int_2; j < arrayList_0.Count; j++)
			{
				Trendline trendline2 = (Trendline)((Class1690)arrayList_0[j]).object_0;
				if (trendline.method_38() < trendline2.method_38())
				{
					break;
				}
			}
			if (j < arrayList_0.Count)
			{
				arrayList_0.Insert(j, @class);
			}
			else
			{
				arrayList_0.Add(@class);
			}
		}
	}

	private void method_14(ArrayList arrayList_0, int int_1)
	{
		for (int i = int_1; i < arrayList_0.Count; i++)
		{
			Class1690 @class = (Class1690)arrayList_0[i];
			Trendline trendline = (Trendline)@class.object_0;
			Series series = trendline.method_31();
			_ = series.Type;
			Class699 class2 = new Class699(FileFormatType.Default);
			class2.method_4(trendline);
			class2.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			for (int j = 0; j < 4; j++)
			{
				Class592 class3 = new Class592();
				class3.method_4(j);
				class3.vmethod_0(class1725_0);
				if (j == 0 && !trendline.IsNameAuto)
				{
					Class700 class4 = new Class700(FileFormatType.Default, trendline.Name);
					class4.vmethod_0(class1725_0);
				}
			}
			Class622 class5 = new Class622();
			class5.method_4(i, @class.int_1);
			class5.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			Class604 class6 = new Class604();
			class6.vmethod_0(class1725_0);
			Class651 class7 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			if (!trendline.IsAuto)
			{
				class7.method_6(trendline, bool_0: false);
			}
			class7.vmethod_0(class1725_0);
			Class594 class8 = new Class594(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class8.vmethod_0(class1725_0);
			Class666 class9 = new Class666();
			class9.vmethod_0(class1725_0);
			Class653 class10 = new Class653(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class10.vmethod_0(class1725_0);
			class1725_0.method_5(4148);
			Class701 class11 = new Class701();
			class11.method_4((ushort)(@class.int_0 + 1));
			class11.vmethod_0(class1725_0);
			Class697 class12 = new Class697();
			class12.method_4(trendline);
			class12.vmethod_0(class1725_0);
			if (chart_0.method_24() != null && chart_0.method_24().method_44() != null && chart_0.Legend.LegendEntries.Count != 0)
			{
				LegendEntryCollection legendEntries = chart_0.Legend.LegendEntries;
				if (!ChartCollection.smethod_3(series.Type) && !ChartCollection.smethod_13(series.Type) && !ChartCollection.smethod_5(series.Type) && (chart_0.NSeries.Count != 1 || !series.IsColorVaried))
				{
					LegendEntry legendEntry = legendEntries.method_0(trendline.method_38() + int_1);
					if (legendEntry != null && (legendEntry.IsDeleted || legendEntry.method_0() != null))
					{
						method_11(legendEntry, 65535);
					}
				}
			}
			class1725_0.method_5(4148);
		}
	}

	private void method_15(int int_1, int int_2, int int_3, bool bool_0)
	{
		class1725_0.method_8(4102);
		class1725_0.method_8(8);
		class1725_0.method_6((ushort)int_1);
		class1725_0.method_6((ushort)int_2);
		class1725_0.method_6((ushort)int_3);
		if (bool_0)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
	}

	internal void method_16(DataLabels dataLabels_0, int int_1, int int_2)
	{
		Class713 @class = new Class713(worksheetCollection_0.method_23());
		@class.method_4(dataLabels_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class669 class2 = new Class669(bool_0: false);
		class2.method_7(dataLabels_0);
		class2.vmethod_0(class1725_0);
		if (dataLabels_0.method_39() != null && dataLabels_0.method_39().Count > 0 && dataLabels_0.method_41() != null && dataLabels_0.method_41().Length > 0)
		{
			method_2(dataLabels_0.method_44(), dataLabels_0.method_13(), dataLabels_0.method_41().Length, dataLabels_0.method_39());
		}
		else
		{
			method_2(dataLabels_0.method_44(), dataLabels_0.method_13(), 0, null);
		}
		Class592 class3 = new Class592();
		class3.method_7(dataLabels_0, worksheetCollection_0, worksheetCollection_0.method_23(), dataLabels_0.byte_3);
		class3.vmethod_0(class1725_0);
		if (!dataLabels_0.method_61() && dataLabels_0.method_41() != null && dataLabels_0.method_41() != "")
		{
			Class700 class4 = new Class700(worksheetCollection_0.method_23(), dataLabels_0.method_41());
			class4.vmethod_0(class1725_0);
		}
		if (!dataLabels_0.IsAuto && dataLabels_0.method_43())
		{
			method_17(dataLabels_0);
		}
		Class662 class5 = new Class662();
		class5.method_5(4, int_1, int_2);
		class5.vmethod_0(class1725_0);
		bool flag = dataLabels_0.method_63();
		bool flag2 = dataLabels_0.byte_2 != null;
		if (flag || flag2)
		{
			Class679 class6 = new Class679();
			class6.method_4(2, 5, int_2, int_1);
			class6.vmethod_0(class1725_0);
		}
		if (flag)
		{
			Class670 class7 = new Class670();
			class7.method_4(dataLabels_0);
			class7.vmethod_0(class1725_0);
		}
		if (flag2)
		{
			int value = 0;
			if (!dataLabels_0.method_17())
			{
				value = dataLabels_0.X ^ dataLabels_0.Y;
				value ^= 1;
			}
			Array.Copy(BitConverter.GetBytes(value), 0, dataLabels_0.byte_2, 12, 4);
			int num = dataLabels_0.byte_2.Length;
			byte[] array = new byte[num + 4];
			array[0] = 157;
			array[1] = 8;
			Array.Copy(BitConverter.GetBytes(num), 0, array, 2, 2);
			Array.Copy(dataLabels_0.byte_2, 0, array, 4, num);
			class1725_0.method_3(array);
		}
		if (flag || flag2)
		{
			Class680 class8 = new Class680();
			class8.method_4(2, 0, 0, 0);
			class8.vmethod_0(class1725_0);
		}
		class1725_0.method_5(4148);
	}

	internal void method_17(ChartFrame chartFrame_0)
	{
		Class641 @class = ((!chartFrame_0.IsAutoSize) ? new Class641(2) : new Class641(3));
		@class.method_4(chartFrame_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class651 class2 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
		class2.method_6(chartFrame_0.Border, bool_0: false);
		class2.vmethod_0(class1725_0);
		method_0(chartFrame_0.Area);
		class1725_0.method_5(4148);
	}
}
