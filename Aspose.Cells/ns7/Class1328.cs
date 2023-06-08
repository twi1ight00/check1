using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns27;
using ns59;

namespace ns7;

internal class Class1328
{
	private Class1725 class1725_0;

	private WorksheetCollection worksheetCollection_0;

	private Chart chart_0;

	private FileFormatType fileFormatType_0;

	private Class1390 class1390_0;

	internal bool bool_0;

	private bool bool_1;

	internal Class1328(WorksheetCollection worksheetCollection_1, int int_0, Chart chart_1, Class1390 class1390_1, Class1725 class1725_1)
	{
		fileFormatType_0 = worksheetCollection_1.method_23();
		chart_0 = chart_1;
		class1390_0 = class1390_1;
		class1725_0 = class1725_1;
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal void Write()
	{
		method_2();
		if (method_13())
		{
			method_3();
		}
	}

	private void method_0(Area area_0)
	{
		if (area_0 != null)
		{
			Class594 @class = new Class594(fileFormatType_0, worksheetCollection_0.method_24());
			@class.method_4(area_0);
			@class.vmethod_0(class1725_0);
			method_1(area_0, @class.method_5());
		}
	}

	private void method_1(Area area_0, bool bool_2)
	{
		if (area_0 != null && (area_0.method_0() || bool_2))
		{
			Class643 @class = new Class643();
			@class.method_4(area_0.FillFormat);
			@class.vmethod_0(class1725_0);
			PicFormatOption picFormatOption = null;
			if (area_0.FillFormat.SetType == FormatSetType.IsTextureSet)
			{
				picFormatOption = area_0.FillFormat.TextureFill.method_5();
			}
			if (picFormatOption != null)
			{
				class1725_0.method_5(4147);
				Class590 class2 = new Class590(picFormatOption);
				class2.vmethod_0(class1725_0);
				class1725_0.method_5(4148);
			}
		}
	}

	private void method_2()
	{
		method_14();
		method_15(0);
		class1725_0.method_5(4147);
		Class669 @class = new Class669(bool_0: false);
		@class.method_4(chart_0.PlotArea);
		@class.vmethod_0(class1725_0);
		ChartType chartType_ = chart_0.Type;
		if (chart_0.class1388_0.Count != 0)
		{
			chartType_ = chart_0.class1388_0.method_2(bool_0: false).method_11();
		}
		if (ChartCollection.smethod_4(chartType_))
		{
			if (ChartCollection.smethod_12(chartType_))
			{
				method_5(chart_0.CategoryAxis, 0, chartType_, bool_2: false);
			}
			else
			{
				method_4(chart_0.CategoryAxis, chartType_, bool_2: false);
			}
			method_5(chart_0.ValueAxis, 1, chartType_, bool_2: false);
			if (ChartCollection.smethod_6(chartType_))
			{
				method_6(chart_0.method_21(), chartType_);
			}
		}
		method_11(chart_0.CategoryAxis);
		method_11(chart_0.ValueAxis);
		if (ChartCollection.smethod_6(chartType_) && chart_0.method_21() != null && chart_0.method_21().method_20() != null)
		{
			method_11(chart_0.SeriesAxis);
		}
		if (chart_0.PlotArea.Area.Formatting != FormattingType.None || chart_0.PlotArea.Border.IsVisible)
		{
			class1725_0.method_5(4149);
			method_34(chart_0.PlotArea, bool_2: false);
		}
		for (int i = 0; i < chart_0.class1388_0.Count; i++)
		{
			if (!chart_0.class1388_0[i].PlotOnSecondAxis)
			{
				method_26(chart_0.class1388_0[i], i == 0 && !method_25());
			}
		}
		if (bool_0)
		{
			Class680 class2 = new Class680();
			class2.method_4(0, 0, 0, 0);
			class2.vmethod_0(class1725_0);
			bool_0 = false;
		}
		class1725_0.method_5(4148);
	}

	private void method_3()
	{
		method_15(1);
		class1725_0.method_5(4147);
		Class669 @class = new Class669(bool_0: false);
		@class.vmethod_0(class1725_0);
		ChartType chartType_ = chart_0.Type;
		Class1387 class2 = chart_0.class1388_0.method_2(bool_0: true);
		if (class2 != null)
		{
			chartType_ = class2.method_11();
		}
		if (ChartCollection.smethod_4(chartType_))
		{
			if (ChartCollection.smethod_12(chartType_))
			{
				method_5(chart_0.SecondCategoryAxis, 0, chartType_, bool_2: true);
			}
			else
			{
				method_4(chart_0.SecondCategoryAxis, chartType_, bool_2: true);
			}
			method_5(chart_0.SecondValueAxis, 1, chartType_, bool_2: true);
		}
		method_11(chart_0.SecondCategoryAxis);
		method_11(chart_0.SecondValueAxis);
		for (int i = 0; i < chart_0.class1388_0.Count; i++)
		{
			if (chart_0.class1388_0[i].PlotOnSecondAxis)
			{
				method_26(chart_0.class1388_0[i], i == 0 && method_25());
			}
		}
		if (bool_0)
		{
			Class680 class3 = new Class680();
			class3.method_4(0, 0, 0, 0);
			class3.vmethod_0(class1725_0);
			bool_0 = false;
		}
		class1725_0.method_5(4148);
	}

	internal void method_4(Axis axis_0, ChartType chartType_0, bool bool_2)
	{
		Class601 @class = new Class601(0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		method_12(0, axis_0, chartType_0);
		Class599 class2 = new Class599(axis_0);
		class2.vmethod_0(class1725_0);
		class2 = null;
		method_24(axis_0);
		method_19(axis_0, chartType_0);
		method_21(axis_0);
		method_9(axis_0);
		method_16(axis_0);
		method_17(axis_0);
		if (!bool_2)
		{
			method_7(chartType_0);
		}
		if (axis_0.arrayList_0 != null)
		{
			for (int i = 0; i < axis_0.arrayList_0.Count; i++)
			{
				Class549 class3 = new Class549();
				class3.method_4((byte[])axis_0.arrayList_0[i]);
				class3.vmethod_0(class1725_0);
			}
		}
		else
		{
			Class549 class4 = new Class549();
			class4.method_5(axis_0);
			class4.vmethod_0(class1725_0);
		}
		if (bool_1)
		{
			Class680 class5 = new Class680();
			class5.method_4(4, 0, 0, 0);
			class5.vmethod_0(class1725_0);
			bool_1 = false;
		}
		class1725_0.method_5(4148);
	}

	private void method_5(Axis axis_0, byte byte_0, ChartType chartType_0, bool bool_2)
	{
		Class601 @class = new Class601(byte_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class716 class2 = new Class716();
		class2.method_4(axis_0);
		class2.vmethod_0(class1725_0);
		method_18(axis_0);
		method_24(axis_0);
		method_20(axis_0, chartType_0);
		method_21(axis_0);
		method_9(axis_0);
		method_16(axis_0);
		method_17(axis_0);
		if (!bool_2 && ChartCollection.smethod_0(chartType_0))
		{
			method_8();
		}
		if (bool_1)
		{
			Class680 class3 = new Class680();
			class3.method_4(4, 0, 0, 0);
			class3.vmethod_0(class1725_0);
			bool_1 = false;
		}
		class1725_0.method_5(4148);
	}

	private void method_6(Axis axis_0, ChartType chartType_0)
	{
		Class601 @class = new Class601(2);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		method_12(2, axis_0, chartType_0);
		method_24(axis_0);
		Class714 class2 = new Class714(fileFormatType_0);
		if (axis_0 != null)
		{
			class2.method_4(axis_0);
		}
		class2.vmethod_0(class1725_0);
		method_21(axis_0);
		method_9(axis_0);
		method_16(axis_0);
		method_17(axis_0);
		class1725_0.method_5(4148);
	}

	internal void method_7(ChartType chartType_0)
	{
		if (ChartCollection.smethod_0(chartType_0) && chart_0.method_29() != null)
		{
			Walls walls = chart_0.Walls;
			Class600 @class = new Class600(3);
			@class.vmethod_0(class1725_0);
			Class651 class2 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class2.method_6(walls.Border, bool_0: false);
			class2.vmethod_0(class1725_0);
			method_0(walls);
		}
	}

	internal void method_8()
	{
		if (chart_0.method_28() != null)
		{
			Floor floor = chart_0.Floor;
			Class600 @class = new Class600(3);
			@class.vmethod_0(class1725_0);
			Class651 class2 = new Class651(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class2.method_6(floor.Border, bool_0: false);
			class2.vmethod_0(class1725_0);
			method_0(floor);
		}
	}

	internal void method_9(Axis axis_0)
	{
		if (axis_0 != null)
		{
			if (!axis_0.IsVisible)
			{
				Class600 @class = new Class600(0);
				@class.vmethod_0(class1725_0);
				Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
				class2.method_4();
				class2.vmethod_0(class1725_0);
			}
			else if (axis_0.method_11() != null)
			{
				Class600 class3 = new Class600(0);
				class3.vmethod_0(class1725_0);
				Class651 class4 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
				class4.method_6(axis_0.AxisLine, bool_0: true);
				class4.vmethod_0(class1725_0);
			}
		}
	}

	private void method_10(Font font_0, int int_0, int int_1, ArrayList arrayList_0)
	{
		if (font_0 == null && int_0 == -1)
		{
			return;
		}
		if (font_0 != null)
		{
			int_0 = font_0.method_21();
		}
		if (arrayList_0 != null)
		{
			Class593 @class = new Class593();
			int num = @class.method_4(int_1, int_0, arrayList_0);
			if (num == -1)
			{
				Class638 class2 = new Class638(int_0);
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
			Class638 class4 = new Class638(int_0);
			class4.vmethod_0(class1725_0);
		}
	}

	internal void method_11(Axis axis_0)
	{
		Title title = axis_0.method_20();
		bool flag;
		if (title != null && ((flag = title.Text != null && title.Text != "") || title.IsAutoText))
		{
			Class713 @class = new Class713(fileFormatType_0);
			@class.method_7(title);
			@class.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			if (title.method_23() != 0 || title.method_25() != 0)
			{
				Class669 class2 = new Class669(bool_0: false);
				class2.method_6(title);
				class2.vmethod_0(class1725_0);
			}
			method_10(title.method_12(), title.method_13(), flag ? title.Text.Length : 0, title.method_39());
			Class592 class3 = new Class592();
			class3.method_5();
			class3.vmethod_0(class1725_0);
			if (flag)
			{
				Class700 class4 = new Class700(fileFormatType_0, title.Text);
				class4.vmethod_0(class1725_0);
			}
			if (title.method_42())
			{
				method_34(title, bool_2: true);
			}
			Class662 class5 = new Class662();
			switch (axis_0.Type)
			{
			case Enum195.const_0:
				class5.method_4(3);
				break;
			case Enum195.const_1:
				class5.method_4(2);
				break;
			case Enum195.const_2:
				class5.method_4(7);
				break;
			}
			class5.vmethod_0(class1725_0);
			class1725_0.method_5(4148);
		}
	}

	private void method_12(int int_0, Axis axis_0, ChartType chartType_0)
	{
		Class610 @class = new Class610();
		switch (chartType_0)
		{
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			@class.method_4(fileFormatType_0, int_0);
			break;
		}
		if (axis_0 != null)
		{
			@class.method_5(axis_0);
		}
		@class.vmethod_0(class1725_0);
	}

	[SpecialName]
	internal bool method_13()
	{
		if (chart_0.NSeries.Count <= 1)
		{
			return false;
		}
		if (chart_0.class1388_0.method_1())
		{
			return true;
		}
		if (chart_0.SecondValueAxis.IsVisible)
		{
			chart_0.NSeries[0].PlotOnSecondAxis = true;
			return true;
		}
		return false;
	}

	private void method_14()
	{
		class1725_0.method_8(4166);
		class1725_0.method_8(2);
		if (method_13())
		{
			class1725_0.method_8(2);
		}
		else
		{
			class1725_0.method_8(1);
		}
	}

	private void method_15(int int_0)
	{
		class1725_0.method_8(4161);
		class1725_0.method_8(18);
		class1725_0.method_7((short)int_0);
		if (chart_0.PlotArea.InnerWidth + chart_0.PlotArea.InnerHeight == 0)
		{
			chart_0.Calculate(bool_9: false, bool_10: false);
			chart_0.PlotArea.method_19(bool_5: false);
			chart_0.PlotArea.method_21(bool_5: false);
			chart_0.PlotArea.IsAutoSize = false;
			chart_0.PlotArea.method_31(bool_5: false);
			chart_0.PlotArea.IsInnerMode = false;
			if (chart_0.method_58() != null)
			{
				long long_ = class1725_0.method_10();
				class1725_0.Seek(chart_0.method_58().long_0);
				chart_0.method_58().method_4(chart_0);
				chart_0.method_58().vmethod_0(class1725_0);
				class1725_0.Seek(long_);
				chart_0.method_59(null);
			}
		}
		class1725_0.method_5(chart_0.PlotArea.InnerX);
		class1725_0.method_5(chart_0.PlotArea.InnerY);
		class1725_0.method_5(chart_0.PlotArea.InnerWidth);
		class1725_0.method_5(chart_0.PlotArea.InnerHeight);
	}

	internal void method_16(Axis axis_0)
	{
		if (axis_0 != null && axis_0.method_26() != null && axis_0.MajorGridLines.IsVisible)
		{
			Class600 @class = new Class600(1);
			@class.vmethod_0(class1725_0);
			Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
			class2.method_6(axis_0.MajorGridLines, bool_0: false);
			class2.vmethod_0(class1725_0);
		}
	}

	internal void method_17(Axis axis_0)
	{
		if (axis_0 != null && axis_0.method_28() != null && axis_0.MinorGridLines.IsVisible)
		{
			Class600 @class = new Class600(2);
			@class.vmethod_0(class1725_0);
			Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
			class2.method_6(axis_0.MinorGridLines, bool_0: false);
			class2.vmethod_0(class1725_0);
		}
	}

	internal void method_18(Axis axis_0)
	{
		if (axis_0.DisplayUnit == DisplayUnitType.None)
		{
			return;
		}
		if (!bool_0)
		{
			Class679 @class = new Class679();
			@class.method_4(0, 0, (!axis_0.method_30()) ? 1 : 0, 0);
			@class.vmethod_0(class1725_0);
			bool_0 = true;
		}
		if (!bool_1)
		{
			Class679 @class = new Class679();
			@class.method_4(4, 0, 0, 0);
			@class.vmethod_0(class1725_0);
			bool_1 = true;
		}
		Class710 class2 = new Class710();
		class2.method_4(axis_0.IsDisplayUnitLabelShown, axis_0.DisplayUnit);
		class2.vmethod_0(class1725_0);
		DisplayUnitLabel displayUnitLabel = axis_0.method_18();
		if (displayUnitLabel != null)
		{
			Class681 class3 = new Class681();
			class3.method_4(16);
			class3.vmethod_0(class1725_0);
			Class678 class4 = new Class678();
			class4.method_6(axis_0, displayUnitLabel, worksheetCollection_0.method_23());
			class4.vmethod_0(class1725_0);
			class4.method_7();
			class4.vmethod_0(class1725_0);
			class4.method_8(displayUnitLabel);
			class4.vmethod_0(class1725_0);
			if (class4.method_9(displayUnitLabel.method_12(), displayUnitLabel.method_13()))
			{
				class4.vmethod_0(class1725_0);
			}
			class4.method_10(displayUnitLabel.byte_1);
			class4.vmethod_0(class1725_0);
			if (displayUnitLabel.Text != null && displayUnitLabel.Text.Length != 0)
			{
				class4.method_11(worksheetCollection_0.method_23(), displayUnitLabel.Text);
				class4.vmethod_0(class1725_0);
			}
			if (!displayUnitLabel.IsAuto && displayUnitLabel.method_41())
			{
				class4.method_12(displayUnitLabel.IsAutoSize, displayUnitLabel);
				class4.vmethod_0(class1725_0);
				class4.method_7();
				class4.vmethod_0(class1725_0);
				class4.method_13(displayUnitLabel.Border, worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
				class4.vmethod_0(class1725_0);
				class4.method_14(displayUnitLabel.Area, worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
				class4.vmethod_0(class1725_0);
				class4.method_15(displayUnitLabel.Area, worksheetCollection_0.method_24(), class1725_0);
				class4.method_17();
				class4.vmethod_0(class1725_0);
			}
			class4.method_16();
			class4.vmethod_0(class1725_0);
			class4.method_17();
			class4.vmethod_0(class1725_0);
			Class682 class5 = new Class682();
			class5.method_4(16);
			class5.vmethod_0(class1725_0);
		}
	}

	internal void method_19(Axis axis_0, ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			method_22(axis_0);
			break;
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
		{
			Class714 @class = new Class714(fileFormatType_0);
			if (axis_0.method_13())
			{
				@class.method_4(axis_0);
			}
			@class.vmethod_0(class1725_0);
			break;
		}
		}
	}

	internal void method_20(Axis axis_0, ChartType chartType_0)
	{
		if (axis_0.method_13())
		{
			Class714 @class = new Class714(fileFormatType_0);
			@class.method_4(axis_0);
			@class.vmethod_0(class1725_0);
		}
	}

	internal void method_21(Axis axis_0)
	{
		if (axis_0 != null && axis_0.method_14() != null)
		{
			method_10(axis_0.method_14().method_0(), axis_0.method_14().method_1(), 0, null);
		}
	}

	internal void method_22(Axis axis_0)
	{
		TickLabels tickLabels = axis_0.method_14();
		bool_1 = false;
		int num = tickLabels?.Offset ?? 100;
		if (num != 100 || (axis_0.TickLabelSpacing == 1 && !axis_0.method_16()))
		{
			bool_1 = true;
			Class679 @class = new Class679();
			if (!bool_0)
			{
				@class.method_4(0, 0, (!axis_0.method_30()) ? 1 : 0, 0);
				@class.vmethod_0(class1725_0);
				bool_0 = true;
			}
			@class.method_4(4, 0, 0, 0);
			@class.vmethod_0(class1725_0);
			Class609 class2 = new Class609();
			class2.method_4(num, axis_0.method_16());
			class2.vmethod_0(class1725_0);
		}
		Class714 class3 = new Class714(fileFormatType_0);
		class3.method_4(axis_0);
		class3.vmethod_0(class1725_0);
	}

	internal void method_23(Axis axis_0, Axis axis_1)
	{
		bool flag = axis_0.DisplayUnit == DisplayUnitType.None || !axis_0.IsDisplayUnitLabelShown;
		bool flag2 = axis_1.DisplayUnit == DisplayUnitType.None || !axis_1.IsDisplayUnitLabelShown;
		if (flag && flag2)
		{
			return;
		}
		int num = -1;
		int num2 = -1;
		if (!flag)
		{
			num = ((axis_0.DisplayUnitLabel.method_12() == null) ? axis_0.DisplayUnitLabel.method_13() : axis_0.DisplayUnitLabel.Font.method_21());
		}
		if (!flag2)
		{
			num2 = ((axis_1.DisplayUnitLabel.method_12() == null) ? axis_1.DisplayUnitLabel.method_13() : axis_1.DisplayUnitLabel.Font.method_21());
		}
		Class685 @class = new Class685();
		@class.method_4(num, num2);
		@class.vmethod_0(class1725_0);
		Class681 class2 = new Class681();
		class2.method_4(17);
		class2.vmethod_0(class1725_0);
		Class678 class3 = new Class678();
		if (num != -1)
		{
			class3.method_4(axis_0.DisplayUnitLabel.Font, worksheetCollection_0.method_23());
			class3.vmethod_0(class1725_0);
			if (axis_0.DisplayUnitLabel.AutoScaleFont)
			{
				class3.method_5((Class1383)axis_0.DisplayUnitLabel.Font.method_4());
				class3.vmethod_0(class1725_0);
			}
		}
		if (num2 != -1)
		{
			class3.method_4(axis_1.DisplayUnitLabel.Font, worksheetCollection_0.method_23());
			class3.vmethod_0(class1725_0);
			if (axis_1.DisplayUnitLabel.AutoScaleFont)
			{
				class3.method_5((Class1383)axis_1.DisplayUnitLabel.Font.method_4());
				class3.vmethod_0(class1725_0);
			}
		}
		Class682 class4 = new Class682();
		class4.method_4(17);
		class4.vmethod_0(class1725_0);
	}

	internal void method_24(Axis axis_0)
	{
		if (axis_0 != null && axis_0.method_14() != null)
		{
			TickLabels tickLabels = axis_0.method_14();
			if (tickLabels.NumberFormat != null && tickLabels.NumberFormat != "")
			{
				ushort ushort_ = (ushort)tickLabels.method_6();
				class1725_0.method_8(4174);
				class1725_0.method_8(2);
				class1725_0.method_6(ushort_);
			}
			else if (tickLabels.Number != 0)
			{
				class1725_0.method_8(4174);
				class1725_0.method_8(2);
				class1725_0.method_6((ushort)tickLabels.Number);
			}
		}
	}

	[SpecialName]
	private bool method_25()
	{
		return chart_0.class1388_0[0].PlotOnSecondAxis;
	}

	private void method_26(Class1387 class1387_0, bool bool_2)
	{
		ChartType chartType = class1387_0.method_11();
		Class613 @class = new Class613();
		@class.method_5(class1387_0.Index);
		if (class1387_0.IsColorVaried)
		{
			@class.method_4();
		}
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		switch (chartType)
		{
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
		{
			Class595 class8 = new Class595();
			class8.method_4(chartType);
			class8.vmethod_0(class1725_0);
			method_28();
			break;
		}
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		{
			Class693 class11 = new Class693(fileFormatType_0, class1387_0);
			class11.vmethod_0(class1725_0);
			break;
		}
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
		{
			Class603 class6 = new Class603(fileFormatType_0, class1387_0.Overlap, class1387_0.GapWidth);
			class6.method_4(chartType, class1387_0.method_22());
			class6.vmethod_0(class1725_0);
			method_28();
			break;
		}
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		{
			Class667 class9 = new Class667(class1387_0);
			class9.vmethod_0(class1725_0);
			break;
		}
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
		{
			Class652 class10 = new Class652();
			class10.method_4(class1387_0.method_11());
			class10.vmethod_0(class1725_0);
			method_28();
			break;
		}
		case ChartType.Pie:
		case ChartType.PieExploded:
		{
			Class667 class9 = new Class667(class1387_0);
			class9.vmethod_0(class1725_0);
			break;
		}
		case ChartType.Pie3D:
		case ChartType.Pie3DExploded:
		{
			Class667 class9 = new Class667(class1387_0);
			class9.vmethod_0(class1725_0);
			method_28();
			break;
		}
		case ChartType.PiePie:
		case ChartType.PieBar:
		{
			Class607 class7 = new Class607(class1387_0);
			class7.vmethod_0(class1725_0);
			if (class1387_0.byte_0 != null)
			{
				class1725_0.method_7(4199);
				class1725_0.method_7((short)class1387_0.byte_0.Length);
				class1725_0.method_3(class1387_0.byte_0);
			}
			break;
		}
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
		{
			Class603 class6 = new Class603(fileFormatType_0, class1387_0.Overlap, chart_0.GapWidth);
			class6.method_4(chartType, class1387_0.method_22());
			class6.vmethod_0(class1725_0);
			method_28();
			break;
		}
		case ChartType.Radar:
		case ChartType.RadarWithDataMarkers:
		{
			Class673 class5 = new Class673(class1387_0);
			class5.vmethod_0(class1725_0);
			break;
		}
		case ChartType.RadarFilled:
		{
			Class672 class4 = new Class672(class1387_0);
			class4.vmethod_0(class1725_0);
			break;
		}
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
		{
			Class693 class3 = new Class693(fileFormatType_0, class1387_0);
			class3.vmethod_0(class1725_0);
			break;
		}
		default:
			throw new CellsException(ExceptionType.Chart, "Invalid chart type.");
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
		{
			Class711 class2 = new Class711();
			class2.method_4(chartType, class1387_0);
			class2.vmethod_0(class1725_0);
			method_28();
			break;
		}
		}
		if (chart_0.ValueAxis.DisplayUnit != 0)
		{
			Class612 class12 = new Class612();
			class12.method_4();
			class12.vmethod_0(class1725_0);
		}
		if (chart_0.ShowLegend && bool_2)
		{
			method_32();
		}
		if (class1387_0.HasUpDownBars)
		{
			method_29(class1387_0);
		}
		if (class1387_0.HasLeaderLines && ChartCollection.smethod_3(chartType))
		{
			method_27(3, class1387_0.LeaderLines);
		}
		if (class1387_0.HasSeriesLines)
		{
			method_27(2, class1387_0.SeriesLines);
		}
		if (class1387_0.HasDropLines)
		{
			method_27(0, class1387_0.DropLines);
		}
		if (class1387_0.HasHiLoLines)
		{
			method_27(1, class1387_0.HiLoLines);
		}
		switch (chartType)
		{
		case ChartType.Bubble3D:
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.DoughnutExploded:
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
		case ChartType.Radar:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			method_31(class1387_0);
			break;
		}
		class1725_0.method_5(4148);
	}

	private void method_27(byte byte_0, Line line_0)
	{
		Class614 @class = new Class614(byte_0);
		@class.vmethod_0(class1725_0);
		Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
		class2.method_6(line_0, bool_0: false);
		class2.vmethod_0(class1725_0);
	}

	private void method_28()
	{
		if (ChartCollection.smethod_0(chart_0.Type))
		{
			Class611 @class = new Class611();
			@class.method_10(chart_0);
			@class.vmethod_0(class1725_0);
		}
	}

	private void method_29(Class1387 class1387_0)
	{
		Class627 @class = new Class627(class1387_0.GapWidth);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		DropBars dropBars = class1387_0.method_19();
		Class651 class2 = new Class651(FileFormatType.Default, worksheetCollection_0.method_24());
		if (dropBars != null && dropBars.method_0() != null)
		{
			class2.method_6(dropBars.Border, bool_0: false);
		}
		class2.vmethod_0(class1725_0);
		Class594 class3 = new Class594(FileFormatType.Default, worksheetCollection_0.method_24());
		if (dropBars != null)
		{
			class3.method_4(dropBars.Area);
		}
		class3.vmethod_0(class1725_0);
		if (dropBars != null)
		{
			method_1(dropBars.Area, class3.method_5());
		}
		class1725_0.method_5(4148);
		@class = new Class627(class1387_0.GapWidth);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		dropBars = class1387_0.method_20();
		class2 = new Class651(FileFormatType.Default, worksheetCollection_0.method_24());
		if (dropBars != null)
		{
			class2.method_6(dropBars.Border, bool_0: false);
		}
		class2.vmethod_0(class1725_0);
		class3 = new Class594(FileFormatType.Default, worksheetCollection_0.method_24());
		if (dropBars != null)
		{
			class3.method_4(dropBars.Area);
		}
		class3.vmethod_0(class1725_0);
		if (dropBars != null)
		{
			method_1(dropBars.Area, class3.method_5());
		}
		class1725_0.method_5(4148);
	}

	private void method_30(ChartType chartType_0)
	{
		Class604 @class = new Class604();
		@class.method_5(chartType_0);
		@class.vmethod_0(class1725_0);
	}

	private void method_31(Class1387 class1387_0)
	{
		Class622 @class = new Class622();
		@class.method_6(class1387_0.method_11());
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		method_30(class1387_0.method_11());
		Class1632 class2 = class1387_0.method_3();
		if (class2 == null)
		{
			class1725_0.method_5(4148);
			return;
		}
		if (class2.Border != null)
		{
			Class651 class3 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
			class3.method_6(class2.Border, bool_0: false);
			class3.vmethod_0(class1725_0);
		}
		if (class2.Area != null)
		{
			Class594 class4 = new Class594(fileFormatType_0, worksheetCollection_0.method_24());
			class4.method_4(class2.Area);
			class4.vmethod_0(class1725_0);
		}
		if (class2.method_8() != null)
		{
			Class666 class5 = new Class666();
			class5.method_4(class2.method_8());
			class5.vmethod_0(class1725_0);
		}
		if (class2.Smooth || class2.method_11())
		{
			Class698 class6 = new Class698(class2.Smooth, bool_1: false, class2.method_11());
			class6.vmethod_0(class1725_0);
		}
		if (class2.Marker != null)
		{
			Class653 class7 = new Class653(worksheetCollection_0.method_23(), worksheetCollection_0.method_24());
			class7.method_4(class2.Marker, 0);
			class7.vmethod_0(class1725_0);
		}
		class1725_0.method_5(4148);
	}

	private void method_32()
	{
		ChartFrame chartFrame = chart_0.method_24();
		Class649 @class = new Class649(fileFormatType_0);
		if (chartFrame != null)
		{
			@class.method_5(chart_0.method_24());
		}
		@class.method_6((byte)chart_0.Legend.Position);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		int[] int_ = null;
		Class669 class2;
		if (!chart_0.method_24().method_17() || !chart_0.method_24().IsAutoSize)
		{
			class2 = new Class669(bool_0: true);
			int_ = class2.method_5(chart_0.Legend);
			class2.vmethod_0(class1725_0);
		}
		Class713 class3 = new Class713(fileFormatType_0);
		int[] array = class3.method_9(chart_0.Legend);
		class3.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		class2 = new Class669(bool_0: false);
		class2.vmethod_0(class1725_0);
		method_10(chart_0.Legend.method_12(), chart_0.Legend.method_13(), 0, null);
		Class592 class4 = new Class592();
		class4.method_5();
		class4.vmethod_0(class1725_0);
		class1725_0.method_5(4148);
		if (!chart_0.method_24().IsAuto)
		{
			Class641 class5 = ((!chartFrame.IsAutoSize) ? new Class641(2) : new Class641(3));
			class5.method_4(chartFrame);
			class5.vmethod_0(class1725_0);
			class1725_0.method_5(4147);
			Class651 class6 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
			class6.method_6(chartFrame.Border, bool_0: false);
			class6.vmethod_0(class1725_0);
			method_0(chartFrame.Area);
			class1725_0.method_5(4148);
		}
		bool flag = false;
		Legend legend = chart_0.Legend;
		if (legend.byte_1 != null || legend.byte_2 != null)
		{
			flag = true;
		}
		if (flag)
		{
			Class679 class7 = new Class679();
			class7.method_4(9, 1, 0, 0);
			class7.vmethod_0(class1725_0);
			if (legend.byte_1 != null)
			{
				int value = method_33(legend, int_);
				Array.Copy(BitConverter.GetBytes(value), 0, legend.byte_1, 12, 4);
				int num = legend.byte_1.Length;
				byte[] array2 = new byte[num + 4];
				array2[0] = 157;
				array2[1] = 8;
				Array.Copy(BitConverter.GetBytes(num), 0, array2, 2, 2);
				Array.Copy(legend.byte_1, 0, array2, 4, num);
				class1725_0.method_3(array2);
			}
			if (legend.byte_2 != null)
			{
				Class1735 class8 = new Class1735();
				class8.Update(Class1390.smethod_0(legend.Font, array[0], array[1], array[2], array[3], array[4]));
				int num2 = legend.byte_2.Length;
				byte[] array3 = new byte[num2 + 4];
				array3[0] = 165;
				array3[1] = 8;
				Array.Copy(BitConverter.GetBytes(num2), 0, array3, 2, 2);
				Array.Copy(legend.byte_2, 0, array3, 4, num2);
				class1725_0.method_3(array3);
			}
			Class680 class9 = new Class680();
			class9.method_4(9, 0, 0, 0);
			class9.vmethod_0(class1725_0);
		}
		class1725_0.method_5(4148);
	}

	private int method_33(Legend legend_0, int[] int_0)
	{
		int num = legend_0.method_23() ^ legend_0.method_25();
		if (int_0 != null)
		{
			num ^= (int)((double)((float)(int_0[0] * worksheetCollection_0.method_75()) / 72f) + 0.5);
			num ^= (int)((double)((float)(int_0[1] * worksheetCollection_0.method_75()) / 72f) + 0.5);
		}
		num ^= ((!legend_0.method_18()) ? 1 : 0);
		num ^= ((!legend_0.method_20()) ? 1 : 0);
		return num ^ ((!legend_0.IsAutoSize) ? 1 : 0);
	}

	internal void method_34(ChartFrame chartFrame_0, bool bool_2)
	{
		Class641 @class = ((!chartFrame_0.IsAutoSize) ? new Class641(2) : new Class641(3));
		@class.method_4(chartFrame_0);
		@class.vmethod_0(class1725_0);
		class1725_0.method_5(4147);
		Class651 class2 = new Class651(fileFormatType_0, worksheetCollection_0.method_24());
		class2.method_6(chartFrame_0.Border, bool_2);
		class2.vmethod_0(class1725_0);
		method_0(chartFrame_0.Area);
		class1725_0.method_5(4148);
	}
}
