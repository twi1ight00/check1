using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns7;

namespace ns2;

internal class Class1330 : Title
{
	private Class1694 class1694_1;

	private LabelPositionType labelPositionType_0;

	private string string_1;

	private int int_13;

	private Class1692 class1692_0;

	private Color color_0;

	private WorksheetCollection worksheetCollection_0;

	internal bool bool_10 = true;

	internal bool bool_11;

	internal bool bool_12 = true;

	internal bool bool_13;

	internal ushort ushort_0;

	internal Class1383 class1383_0;

	internal bool bool_14;

	internal bool bool_15;

	internal byte[] byte_2;

	internal byte[] byte_3;

	private bool bool_16;

	internal Class1694 Position
	{
		get
		{
			if (class1694_1 == null)
			{
				class1694_1 = new Class1694();
			}
			return class1694_1;
		}
	}

	internal Color FontColor
	{
		set
		{
			color_0 = value;
		}
	}

	internal int Number
	{
		set
		{
			int_13 = value;
		}
	}

	internal string NumberFormat
	{
		set
		{
			string_1 = value;
		}
	}

	internal Class1330(WorksheetCollection worksheetCollection_1, Chart chart_1)
		: base(chart_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	[SpecialName]
	internal bool method_47()
	{
		return bool_16;
	}

	[SpecialName]
	internal void method_48(bool bool_17)
	{
		bool_16 = bool_17;
	}

	[SpecialName]
	internal Class1692 method_49()
	{
		if (class1692_0 == null)
		{
			class1692_0 = new Class1692();
		}
		return class1692_0;
	}

	internal Class1692 method_50()
	{
		return class1692_0;
	}

	[SpecialName]
	internal void method_51(LabelPositionType labelPositionType_1)
	{
		bool_10 = false;
		labelPositionType_0 = labelPositionType_1;
	}

	internal bool method_52()
	{
		Aspose.Cells.Font font_ = (Aspose.Cells.Font)worksheetCollection_0.method_52()[(method_13() > 4) ? (method_13() - 1) : method_13()];
		return Class1389.smethod_0(font_, color_0);
	}

	internal void method_53(LegendEntry legendEntry_0)
	{
		if (method_13() != -1)
		{
			legendEntry_0.method_2(method_13());
			legendEntry_0.method_3(class1383_0 != null);
			if (!method_52())
			{
				legendEntry_0.Font.Color = color_0;
			}
		}
		legendEntry_0.BackgroundMode = base.BackgroundMode;
	}

	internal void method_54(ChartFrame chartFrame_0, bool bool_17, bool bool_18)
	{
		chartFrame_0.method_33(class1694_1);
		if (method_13() != -1)
		{
			chartFrame_0.method_14(method_13());
			chartFrame_0.method_15(class1383_0 != null, class1383_0);
			if (!method_52())
			{
				chartFrame_0.Font.Color = color_0;
			}
		}
		if (!bool_17 && ((chartFrame_0.method_7() == Enum18.const_3 && method_23() > -2000 && method_25() > -2000) || chartFrame_0.method_7() != Enum18.const_3))
		{
			chartFrame_0.method_22(method_23());
			chartFrame_0.method_24(method_25());
			chartFrame_0.method_28(method_29());
			chartFrame_0.method_27(method_26());
			chartFrame_0.method_19(method_18());
			chartFrame_0.method_21(method_20());
			chartFrame_0.IsAutoSize = base.IsAutoSize;
			if (!bool_18 && (bool_14 || method_23() != 0 || method_25() != 0))
			{
				chartFrame_0.method_19(bool_5: false);
				chartFrame_0.method_21(bool_5: false);
			}
		}
		chartFrame_0.BackgroundMode = base.BackgroundMode;
		if (!base.IsAuto)
		{
			chartFrame_0.Area.Copy(base.Area);
			chartFrame_0.Border.Copy(base.Border);
			chartFrame_0.Shadow = base.Shadow;
			chartFrame_0.method_31(base.IsAuto);
		}
	}

	internal void method_55(Legend legend_0, bool bool_17)
	{
		method_54(legend_0, bool_17, bool_18: true);
		if (byte_3 != null)
		{
			legend_0.byte_2 = byte_3;
		}
		if (byte_2 != null)
		{
			legend_0.byte_1 = byte_2;
		}
	}

	internal void method_56(ChartDataTable chartDataTable_0)
	{
		if (method_13() != -1)
		{
			chartDataTable_0.method_2(method_13());
			chartDataTable_0.method_3(class1383_0 != null);
			if (!method_52())
			{
				chartDataTable_0.Font.Color = color_0;
			}
		}
		if (!base.IsAuto)
		{
			chartDataTable_0.Border.Copy(base.Border);
			chartDataTable_0.BackgroundMode = base.BackgroundMode;
		}
	}

	internal void method_57(Title title_0)
	{
		title_0.byte_1 = byte_1;
		title_0.Border.IsVisible = true;
		title_0.Border.IsAuto = true;
		title_0.Area.Formatting = FormattingType.Automatic;
		method_54(title_0, bool_17: false, bool_18: false);
		title_0.method_33(class1694_1);
		title_0.IsAutoSize = true;
		if ((ushort_0 & 0x40u) != 0)
		{
			title_0.method_41(null);
		}
		else
		{
			title_0.method_41(base.Text);
			title_0.IsDeleted = false;
			title_0.IsAutoText = (ushort_0 & 0x10) != 0;
		}
		title_0.TextDirection = base.TextDirection;
		title_0.TextHorizontalAlignment = base.TextHorizontalAlignment;
		title_0.TextVerticalAlignment = base.TextVerticalAlignment;
		if (!bool_13)
		{
			title_0.RotationAngle = base.RotationAngle;
		}
		if (method_39() != null)
		{
			title_0.method_40(method_39());
		}
		if (!bool_15)
		{
			title_0.Border.IsVisible = false;
			title_0.Area.Formatting = FormattingType.None;
		}
	}

	internal void method_58(Axis axis_1, DisplayUnitLabel displayUnitLabel_0, ArrayList arrayList_1)
	{
		method_54(displayUnitLabel_0, bool_17: false, bool_18: false);
		displayUnitLabel_0.Text = base.Text;
		if ((ushort_0 & 0x40u) != 0)
		{
			axis_1.method_19(bool_15: false);
		}
		displayUnitLabel_0.byte_1 = byte_1;
		displayUnitLabel_0.TextDirection = base.TextDirection;
		displayUnitLabel_0.TextHorizontalAlignment = base.TextHorizontalAlignment;
		displayUnitLabel_0.TextVerticalAlignment = base.TextVerticalAlignment;
		if (!bool_13)
		{
			displayUnitLabel_0.RotationAngle = base.RotationAngle;
		}
	}

	internal void method_59(Chart chart_1, bool bool_17)
	{
		if (bool_17)
		{
			switch (method_49().byte_0)
			{
			case 2:
				method_57(chart_1.SecondValueAxis.Title);
				break;
			case 3:
				method_57(chart_1.SecondCategoryAxis.Title);
				break;
			}
			return;
		}
		switch (method_49().byte_0)
		{
		case 7:
			method_57(chart_1.SeriesAxis.Title);
			break;
		case 2:
			method_57(chart_1.ValueAxis.Title);
			break;
		case 3:
			method_57(chart_1.CategoryAxis.Title);
			break;
		}
	}

	internal void method_60(Chart chart_1, ArrayList arrayList_1, ArrayList arrayList_2)
	{
		ChartType type = chart_1.Type;
		bool flag = false;
		DataLabels dataLabels = null;
		int num = -1;
		if (method_49().ushort_0 >= arrayList_1.Count)
		{
			return;
		}
		Class1690 @class = (Class1690)arrayList_1[method_49().ushort_0];
		if (@class != null)
		{
			if (@class.byte_0 == 0)
			{
				Series series = (Series)@class.object_0;
				type = series.Type;
				flag = true;
				if (method_49().ushort_1 == ushort.MaxValue)
				{
					num = method_49().ushort_0;
					dataLabels = series.DataLabels;
				}
				else
				{
					ChartPoint chartPoint = series.Points.method_1(method_49().ushort_1);
					dataLabels = chartPoint.DataLabels;
				}
			}
			else
			{
				if (@class.byte_0 != 1)
				{
					return;
				}
				Trendline trendline = (Trendline)@class.object_0;
				dataLabels = trendline.DataLabels;
			}
		}
		dataLabels.byte_2 = byte_2;
		method_54(dataLabels, bool_17: false, bool_18: false);
		dataLabels.method_42(string_0);
		dataLabels.byte_3 = byte_1;
		dataLabels.IsAutoText = (ushort_0 & 0x10) != 0;
		dataLabels.IsDeleted = (ushort_0 & 0x40) != 0;
		dataLabels.method_40(method_39());
		dataLabels.TextDirection = base.TextDirection;
		dataLabels.TextHorizontalAlignment = base.TextHorizontalAlignment;
		dataLabels.TextVerticalAlignment = base.TextVerticalAlignment;
		if (!bool_13)
		{
			dataLabels.RotationAngle = base.RotationAngle;
		}
		if (!bool_10)
		{
			bool flag2 = false;
			if (labelPositionType_0 != LabelPositionType.Moved && flag)
			{
				LabelPositionType labelPositionType = labelPositionType_0;
				if (labelPositionType == LabelPositionType.OutsideEnd)
				{
					switch (type)
					{
					case ChartType.BarStacked:
					case ChartType.Bar100PercentStacked:
					case ChartType.ColumnStacked:
					case ChartType.Column100PercentStacked:
						dataLabels.method_67(LabelPositionType.Center);
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				dataLabels.method_67(labelPositionType_0);
			}
		}
		dataLabels.NumberFormatLinked = bool_12;
		if (!bool_12)
		{
			if (string_1 != null && string_1 != "")
			{
				dataLabels.method_49(string_1);
			}
			else
			{
				dataLabels.method_51(int_13);
			}
		}
		dataLabels.method_47(bool_11);
		if (method_49().bool_0)
		{
			byte b = method_49().byte_1;
			if (b == 0)
			{
				dataLabels.method_45(Enum127.const_1, (ushort_0 & 4) != 0);
				dataLabels.method_45(Enum127.const_2, (ushort_0 & 0x1000) != 0);
				dataLabels.method_45(Enum127.const_4, (ushort_0 & 0x2000) != 0);
				dataLabels.method_45(Enum127.const_3, (ushort_0 & 0x4000) != 0);
			}
			else
			{
				dataLabels.method_45(Enum127.const_5, (b & 1) != 0);
				dataLabels.method_45(Enum127.const_3, (b & 2) != 0);
				dataLabels.method_45(Enum127.const_1, (b & 4) != 0);
				dataLabels.method_45(Enum127.const_2, (b & 8) != 0);
				dataLabels.method_45(Enum127.const_4, (b & 0x10) != 0);
			}
			if (method_49().string_0 != null)
			{
				switch (method_49().string_0[0])
				{
				case ' ':
					dataLabels.Separator = DataLablesSeparatorType.Space;
					break;
				case '\n':
					dataLabels.Separator = DataLablesSeparatorType.NewLine;
					break;
				case ';':
					dataLabels.Separator = DataLablesSeparatorType.Semicolon;
					break;
				case ',':
					dataLabels.Separator = DataLablesSeparatorType.Comma;
					break;
				case '.':
					dataLabels.Separator = DataLablesSeparatorType.Period;
					break;
				}
			}
		}
		else if (dataLabels.bool_14)
		{
			dataLabels.method_45(Enum127.const_1, (ushort_0 & 4) != 0);
			dataLabels.method_45(Enum127.const_2, (ushort_0 & 0x1000) != 0);
			dataLabels.method_45(Enum127.const_4, (ushort_0 & 0x2000) != 0);
			if (ChartCollection.smethod_16(type))
			{
				dataLabels.method_45(Enum127.const_5, (ushort_0 & 0x4000) != 0);
				dataLabels.method_45(Enum127.const_3, bool_16: false);
			}
			else
			{
				dataLabels.method_45(Enum127.const_3, (ushort_0 & 0x4000) != 0);
			}
		}
		else
		{
			dataLabels.method_45(Enum127.const_1, (ushort_0 & 4) != 0);
			dataLabels.method_45(Enum127.const_2, (ushort_0 & 0x1000) != 0);
			dataLabels.method_45(Enum127.const_4, (ushort_0 & 0x2000) != 0);
			dataLabels.method_45(Enum127.const_3, (ushort_0 & 0x4000) != 0);
		}
		if (num != -1)
		{
			method_62(dataLabels, num, arrayList_2);
		}
	}

	internal void method_61(DataLabels dataLabels_0, int int_14, ArrayList arrayList_1)
	{
		method_54(dataLabels_0, bool_17: false, bool_18: false);
		dataLabels_0.method_42(base.Text);
		dataLabels_0.IsAutoText = (ushort_0 & 0x10) != 0;
		dataLabels_0.TextDirection = base.TextDirection;
		dataLabels_0.TextHorizontalAlignment = base.TextHorizontalAlignment;
		dataLabels_0.TextVerticalAlignment = base.TextVerticalAlignment;
		if (!bool_13)
		{
			dataLabels_0.RotationAngle = base.RotationAngle;
		}
		if (!bool_10)
		{
			dataLabels_0.method_67(labelPositionType_0);
		}
		dataLabels_0.NumberFormatLinked = bool_12;
		if (!bool_12)
		{
			if (string_1 != null && string_1 != "")
			{
				dataLabels_0.NumberFormat = string_1;
			}
			else
			{
				dataLabels_0.method_51(int_13);
			}
		}
		dataLabels_0.ShowLegendKey = bool_11;
		if (method_49().bool_0)
		{
			byte b = method_49().byte_1;
			dataLabels_0.ShowSeriesName = (b & 1) != 0;
			dataLabels_0.ShowCategoryName = (b & 2) != 0;
			dataLabels_0.ShowValue = (b & 4) != 0;
			dataLabels_0.ShowPercentage = (b & 8) != 0;
			dataLabels_0.ShowBubbleSize = (b & 0x10) != 0;
			if (method_49().string_0 != null)
			{
				switch (method_49().string_0[0])
				{
				case ' ':
					dataLabels_0.Separator = DataLablesSeparatorType.Space;
					break;
				case '\n':
					dataLabels_0.Separator = DataLablesSeparatorType.NewLine;
					break;
				case ';':
					dataLabels_0.Separator = DataLablesSeparatorType.Semicolon;
					break;
				case ',':
					dataLabels_0.Separator = DataLablesSeparatorType.Comma;
					break;
				case '.':
					dataLabels_0.Separator = DataLablesSeparatorType.Period;
					break;
				}
			}
		}
		else if (dataLabels_0.bool_14)
		{
			dataLabels_0.ShowValue = (ushort_0 & 4) != 0;
			dataLabels_0.ShowPercentage = (ushort_0 & 0x1000) != 0;
			dataLabels_0.ShowBubbleSize = (ushort_0 & 0x2000) != 0;
			dataLabels_0.ShowCategoryName = (ushort_0 & 0x4000) != 0;
		}
		if (int_14 != -1)
		{
			method_62(dataLabels_0, int_14, arrayList_1);
		}
	}

	internal void method_62(DataLabels dataLabels_0, int int_14, ArrayList arrayList_1)
	{
		Series series = (Series)dataLabels_0.method_60();
		if (series.method_3() == null)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		Class1692 @class = null;
		if (arrayList_1 != null)
		{
			for (int num = arrayList_1.Count - 1; num >= 0; num--)
			{
				@class = (Class1692)arrayList_1[num];
				if (@class.ushort_0 == int_14 && @class.ushort_1 != ushort.MaxValue)
				{
					arrayList.Add(@class.ushort_1);
				}
			}
		}
		if (arrayList.Count == 0)
		{
			for (int i = 0; i < series.Points.method_4(); i++)
			{
				DataLabels dataLabels = series.Points.method_7(i).method_9();
				if (dataLabels != null)
				{
					method_63(dataLabels_0, dataLabels);
				}
			}
			return;
		}
		bool flag = true;
		for (int j = 0; j < series.Points.method_4(); j++)
		{
			ChartPoint chartPoint = series.Points.method_7(j);
			DataLabels dataLabels2 = chartPoint.method_9();
			if (dataLabels2 == null)
			{
				continue;
			}
			flag = true;
			foreach (ushort item in arrayList)
			{
				if (item == chartPoint.int_0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				method_63(dataLabels_0, dataLabels2);
			}
		}
	}

	internal void method_63(DataLabels dataLabels_0, DataLabels dataLabels_1)
	{
		dataLabels_1.method_15(dataLabels_0.AutoScaleFont, null);
		dataLabels_1.method_16(dataLabels_0.BackgroundMode);
		dataLabels_1.method_31(dataLabels_0.IsAuto);
		dataLabels_1.Border.Copy(dataLabels_0.Border);
		dataLabels_1.Area.Copy(dataLabels_0.Area);
		dataLabels_1.method_14(dataLabels_0.method_13());
		if (dataLabels_0.method_44() != null)
		{
			dataLabels_1.Font.Copy(dataLabels_0.method_44());
		}
		dataLabels_1.method_52(dataLabels_0.NumberFormatLinked);
		if (!dataLabels_0.NumberFormatLinked)
		{
			if (dataLabels_0.NumberFormat != null && dataLabels_0.NumberFormat != "")
			{
				dataLabels_1.method_49(dataLabels_0.NumberFormat);
			}
			else
			{
				dataLabels_1.method_51(dataLabels_0.Number);
			}
		}
		dataLabels_1.RotationAngle = dataLabels_0.RotationAngle;
		dataLabels_1.TextHorizontalAlignment = dataLabels_0.TextHorizontalAlignment;
		dataLabels_1.TextVerticalAlignment = dataLabels_0.TextVerticalAlignment;
		dataLabels_1.TextDirection = dataLabels_0.TextDirection;
		if (dataLabels_0.bool_14 && dataLabels_0.bool_14)
		{
			if (dataLabels_0.ShowValue)
			{
				dataLabels_1.ShowValue = true;
			}
			if (dataLabels_0.ShowPercentage)
			{
				dataLabels_1.ShowPercentage = true;
			}
			if (dataLabels_0.ShowCategoryName)
			{
				dataLabels_1.ShowCategoryName = true;
			}
		}
	}
}
