using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Render;
using Aspose.Cells.Rendering;
using ns14;
using ns16;
using ns19;
using ns2;
using ns31;
using ns32;
using ns33;
using ns35;
using ns36;
using ns37;
using ns47;
using ns5;
using ns52;
using ns6;
using ns7;

namespace ns3;

internal class Class870 : IDisposable
{
	private Chart chart_0;

	private Interface7 interface7_0;

	private Class787 class787_0;

	private Class821 class821_0;

	private ImageOrPrintOptions imageOrPrintOptions_0;

	private Workbook workbook_0;

	private bool bool_0;

	private bool bool_1 = true;

	internal bool bool_2;

	private bool bool_3;

	internal Class870(ImageOrPrintOptions imageOrPrintOptions_1)
	{
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		if (imageOrPrintOptions_0 == null)
		{
			imageOrPrintOptions_0 = new ImageOrPrintOptions();
		}
	}

	private bool method_0(Chart chart_1)
	{
		if (chart_1.ChartObject.Height != 0 && chart_1.ChartObject.Width != 0)
		{
			switch (chart_1.Type)
			{
			default:
				return true;
			case ChartType.Surface3D:
			case ChartType.SurfaceWireframe3D:
			case ChartType.SurfaceContour:
			case ChartType.SurfaceContourWireframe:
				return false;
			}
		}
		return false;
	}

	private Interface42 method_1(Chart chart_1, Stream stream_0, ImageFormat imageFormat_0)
	{
		method_4(chart_1);
		int int_ = Class1036.int_0;
		return Class1036.smethod_0(int_, interface7_0.imethod_13().Width, interface7_0.imethod_13().Height, imageFormat_0, imageOrPrintOptions_0, stream_0, interface7_0);
	}

	internal void ToImage(string string_0, Chart chart_1)
	{
		if (method_0(chart_1))
		{
			ImageFormat bmp = ImageFormat.Bmp;
			bmp = Class872.smethod_0(Path.GetExtension(string_0), bmp);
			ToImage(string_0, bmp, chart_1);
		}
	}

	internal Bitmap ToImage(Chart chart_1)
	{
		if (!method_0(chart_1))
		{
			return null;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		return method_1(chart_1, null, bmp)?.imethod_3();
	}

	internal void ToImage(string string_0, ImageFormat imageFormat_0, Chart chart_1)
	{
		if (!method_0(chart_1))
		{
			return;
		}
		using FileStream stream_ = new FileStream(string_0, FileMode.Create);
		method_1(chart_1, stream_, imageFormat_0)?.imethod_2();
	}

	internal void ToImage(string string_0, long long_0, Chart chart_1)
	{
		if (method_0(chart_1))
		{
			ImageFormat jpeg = ImageFormat.Jpeg;
			imageOrPrintOptions_0.Quality = (int)long_0;
			ToImage(string_0, jpeg, chart_1);
		}
	}

	internal void ToImage(Stream stream_0, long long_0, Chart chart_1)
	{
		if (method_0(chart_1))
		{
			ImageFormat jpeg = ImageFormat.Jpeg;
			imageOrPrintOptions_0.Quality = (int)long_0;
			ToImage(stream_0, jpeg, chart_1);
		}
	}

	internal void ToImage(Stream stream_0, ImageFormat imageFormat_0, Chart chart_1)
	{
		if (method_0(chart_1))
		{
			method_1(chart_1, stream_0, imageFormat_0)?.imethod_2();
		}
	}

	internal static Interface7 smethod_0(Chart chart_1)
	{
		using Class870 @class = new Class870(null);
		Interface7 @interface = null;
		try
		{
			@interface = ((!chart_1.method_14().Workbook.method_23()) ? ((Interface7)@class.method_2(chart_1)) : ((Interface7)@class.method_3(chart_1)));
			return @interface;
		}
		finally
		{
			if (@interface != null && @interface.imethod_0() != null)
			{
				@interface.imethod_0().Dispose();
			}
		}
	}

	internal Class787 method_2(Chart chart_1)
	{
		if (!method_0(chart_1))
		{
			return null;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		method_1(chart_1, null, bmp);
		class787_0.Calculate();
		return class787_0;
	}

	internal Class821 method_3(Chart chart_1)
	{
		if (!method_0(chart_1))
		{
			return null;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		method_1(chart_1, null, bmp);
		class821_0.Calculate();
		return class821_0;
	}

	private Interface7 method_4(Chart chart_1)
	{
		workbook_0 = chart_1.method_14().Workbook;
		if (bool_2)
		{
			if (chart_1.method_56() == Enum19.const_1)
			{
				bool_1 = true;
			}
			else
			{
				bool_1 = false;
			}
		}
		else
		{
			bool_1 = workbook_0.method_23();
		}
		chart_0 = chart_1;
		bool_0 = chart_1.PivotSource != null && chart_1.PivotSource.Length > 0;
		if (bool_0 && chart_1.NSeries.Count == 0)
		{
			chart_1.RefreshPivotData();
		}
		System.Drawing.Font font = null;
		Color color_ = Color.Empty;
		font = method_39(chart_1.ChartArea.Font);
		if (!chart_1.ChartArea.Font.InternalColor.method_2() && !chart_1.ChartArea.Font.Color.IsEmpty)
		{
			color_ = ((chart_1.ChartArea.Font.Color.A != 0) ? chart_1.ChartArea.Font.Color : Color.FromArgb(chart_1.ChartArea.Font.Color.ToArgb() | -16777216));
		}
		if (bool_1)
		{
			class821_0 = new Class821(font, color_);
			interface7_0 = class821_0;
		}
		else
		{
			class787_0 = new Class787(font, color_);
			interface7_0 = class787_0;
		}
		interface7_0.imethod_12(Class1677.smethod_35());
		interface7_0.imethod_11(chart_0.Charts.method_0().method_2().Workbook.Settings.Date1904);
		method_5();
		method_7();
		method_13();
		if (bool_1)
		{
			method_18(chart_1, class821_0);
		}
		else
		{
			method_19(chart_1, class787_0);
		}
		method_6();
		interface7_0.imethod_9(Class972.smethod_0() == Enum134.const_0);
		return interface7_0;
	}

	private void method_5()
	{
		interface7_0.imethod_14(chart_0.method_14().Workbook.Settings.method_3());
		interface7_0.imethod_8(chart_0.method_0());
		if (interface7_0.imethod_7() == -1)
		{
			interface7_0.imethod_8(2);
		}
		ChangePalette(chart_0.method_14().Workbook);
		interface7_0.Type = Class869.smethod_9(chart_0.Type);
		interface7_0.IsRectangularCornered = chart_0.IsRectangularCornered;
		method_11();
		method_12();
		method_15();
		method_17();
		if (bool_1)
		{
			if (chart_0.method_20() != null && (!chart_0.Title.method_45() || (chart_0.Title.Text != null && chart_0.Title.Text != "")))
			{
				method_38(chart_0.Title, interface7_0.Title, bool_4: true);
			}
		}
		else if (chart_0.method_20() == null)
		{
			if (chart_0.NSeries.Count == 1 && chart_0.NSeries[0].Name != null)
			{
				string text = method_22(chart_0.NSeries[0]);
				if (text != null)
				{
					interface7_0.Title.Text = text;
				}
			}
		}
		else if (chart_0.Title.Text == null)
		{
			if (chart_0.Title.IsAutoText && chart_0.NSeries.Count == 1 && chart_0.NSeries[0].Name != null)
			{
				string text2 = method_22(chart_0.NSeries[0]);
				if (text2 != null)
				{
					interface7_0.Title.Text = text2;
					method_38(chart_0.Title, interface7_0.Title, bool_4: true);
				}
			}
		}
		else if (chart_0.Title.Text != "")
		{
			method_38(chart_0.Title, interface7_0.Title, bool_4: true);
		}
		if (ChartCollection.smethod_0(chart_0.Type))
		{
			interface7_0.GapDepth = chart_0.GapDepth;
			interface7_0.GapWidth = chart_0.GapWidth;
			interface7_0.Elevation = chart_0.Elevation;
			interface7_0.Rotation = chart_0.RotationAngle;
			interface7_0.AutoScaling = chart_0.AutoScaling;
			interface7_0.RightAngleAxes = chart_0.RightAngleAxes;
			interface7_0.DepthPercent = chart_0.DepthPercent;
			interface7_0.HeightPercent = chart_0.HeightPercent;
			if (chart_0.method_28() != null)
			{
				method_47(chart_0.Floor, interface7_0.Floor);
			}
			if (chart_0.method_29() != null)
			{
				method_48(chart_0.Walls, interface7_0.Walls);
			}
			if (chart_0.method_30() != null)
			{
				method_48(chart_0.BackWall, interface7_0.imethod_6());
			}
			else if (chart_0.method_29() != null)
			{
				method_48(chart_0.Walls, interface7_0.imethod_6());
			}
			if (chart_0.method_32() != null)
			{
				method_48(chart_0.SideWall, interface7_0.imethod_5());
			}
			else if (chart_0.method_29() != null)
			{
				method_48(chart_0.Walls, interface7_0.imethod_5());
			}
		}
	}

	private void method_6()
	{
		foreach (Shape shape in chart_0.Shapes)
		{
			if (shape.MsoDrawingType == MsoDrawingType.Chart)
			{
				ChartShape chartShape = (ChartShape)shape;
				Chart chart_ = chartShape.method_69();
				Class870 @class = new Class870(imageOrPrintOptions_0);
				Interface7 @interface = @class.method_4(chart_);
				@interface.imethod_9(bool_0: false);
				@interface.X = shape.Left;
				@interface.Y = shape.Top;
				interface7_0.imethod_10().Add(@interface);
			}
		}
	}

	private void method_7()
	{
		method_21();
		int num = 0;
		ArrayList arrayList = new ArrayList();
		foreach (Class1387 item in chart_0.method_18())
		{
			foreach (Series item2 in chart_0.NSeries)
			{
				if (item2.IsVisible && item2.method_28() == item)
				{
					Struct66 @struct = new Struct66(item2);
					@struct.method_1(num);
					num++;
					arrayList.Add(@struct);
				}
			}
		}
		arrayList.Sort();
		for (int i = 0; i < arrayList.Count; i++)
		{
			Struct66 struct2 = (Struct66)arrayList[i];
			ChartType_Chart chartType_Chart_ = Class869.smethod_9(struct2.method_2().Type);
			Interface28 @interface = interface7_0.NSeries.Add(chartType_Chart_);
			@interface.imethod_8(struct2.method_0());
			method_8(struct2.method_2(), @interface);
			if (@interface.Points.Count == 0)
			{
				interface7_0.NSeries.RemoveAt(interface7_0.NSeries.Count - 1);
			}
			else if (struct2.method_2().TrendLines != null && struct2.method_2().TrendLines.Count > 0)
			{
				method_46(@interface, struct2.method_2());
			}
		}
	}

	private void method_8(Series series_0, Interface28 interface28_0)
	{
		interface28_0.BarShape = Class869.smethod_29(series_0.Bar3DShapeType);
		string text = null;
		bool flag = false;
		if (series_0.method_13() != null)
		{
			if (series_0.method_13() is string)
			{
				interface28_0.Name = series_0.Name;
			}
			else if (bool_0 && series_0.string_0 != null)
			{
				interface28_0.Name = series_0.string_0;
			}
			else
			{
				bool flag2 = false;
				Interface45 @interface = Class1195.smethod_0(series_0.method_10(), series_0.method_11());
				@interface.imethod_5((byte[])series_0.method_13());
				ArrayList arrayList = @interface.imethod_8(bool_0: false, bool_0, ref flag2);
				if (flag2)
				{
					if (series_0.string_0 != null)
					{
						interface28_0.Name = series_0.string_0;
					}
				}
				else if (arrayList != null && arrayList.Count != 0)
				{
					interface28_0.Name = "";
					for (int i = 0; i < arrayList.Count; i++)
					{
						Class1196 class1196_ = (Class1196)arrayList[i];
						interface28_0.Name += method_23(class1196_);
						if (i != arrayList.Count - 1)
						{
							interface28_0.Name += " ";
						}
					}
				}
			}
		}
		bool flag3 = false;
		ArrayList arrayList2 = series_0.method_16().imethod_8(bool_0: true, bool_0, ref flag3);
		if (arrayList2 == null || arrayList2.Count == 0)
		{
			return;
		}
		for (int j = 0; j < arrayList2.Count; j++)
		{
			Class1196 @class = (Class1196)arrayList2[j];
			if (chart_0.PlotVisibleCells && !@class.bool_0)
			{
				continue;
			}
			method_24(@class, out var doubleValue);
			Interface16 interface2 = interface28_0.Points.Add(doubleValue);
			interface2.imethod_15(@class.object_0);
			interface2.imethod_14(Class869.smethod_36(@class.cellValueType_0));
			text = @class.string_0;
			if ((text == null || text == "") && @class.int_0 != 0)
			{
				text = workbook_0.Settings.method_3().method_8(@class.int_0);
			}
			interface2.imethod_16(text);
			interface2.imethod_17(flag);
			if (@class.bool_1)
			{
				if (chart_0.PlotEmptyCellsType == PlotEmptyCellsType.NotPlotted)
				{
					interface2.imethod_1(bool_0: true);
				}
				else if (chart_0.PlotEmptyCellsType == PlotEmptyCellsType.Interpolated)
				{
					interface2.imethod_4(bool_0: true);
					interface2.imethod_1(bool_0: true);
				}
			}
			CellValueType cellValueType_ = @class.cellValueType_0;
			if (cellValueType_ == CellValueType.IsError)
			{
				interface2.imethod_7(bool_0: true);
			}
		}
		if (ChartCollection.smethod_11(series_0.Type) || ChartCollection.smethod_17(series_0.Type))
		{
			bool flag4 = false;
			if (series_0.method_18() != null)
			{
				arrayList2 = series_0.method_18().imethod_8(bool_0: true, bool_0, ref flag3);
				for (int k = 0; k < arrayList2.Count; k++)
				{
					Class1196 class2 = (Class1196)arrayList2[k];
					int num = k;
					method_24(class2, out var doubleValue2);
					Interface16 interface3 = interface28_0.Points[num];
					interface3.XValue = doubleValue2;
					interface3.imethod_9(class2.object_0);
					interface3.imethod_8(Class869.smethod_36(class2.cellValueType_0));
					text = class2.string_0;
					if ((text == null || text == "") && class2.int_0 != 0)
					{
						text = workbook_0.Settings.method_3().method_8(class2.int_0);
					}
					interface3.imethod_11(text);
					interface3.imethod_13(flag);
					if (class2.cellValueType_0 == CellValueType.IsError)
					{
						interface3.imethod_5(bool_0: true);
					}
					if (class2.bool_1 && chart_0.PlotEmptyCellsType == PlotEmptyCellsType.NotPlotted)
					{
						interface28_0.Points[num].imethod_3(bool_0: true);
						continue;
					}
					switch (class2.cellValueType_0)
					{
					case CellValueType.IsError:
						interface3.imethod_3(bool_0: true);
						break;
					case CellValueType.IsString:
					case CellValueType.IsUnknown:
						flag4 = true;
						break;
					}
					if (num == interface28_0.Points.Count - 1)
					{
						break;
					}
				}
			}
			else
			{
				flag4 = true;
			}
			if (flag4)
			{
				for (int l = 0; l < interface28_0.Points.Count; l++)
				{
					Interface16 interface4 = interface28_0.Points[l];
					interface4.imethod_3(bool_0: false);
					interface4.imethod_5(bool_0: false);
					interface4.XValue = l + 1;
				}
				if (ChartCollection.smethod_17(series_0.Type))
				{
					interface7_0.CategoryAxis.MajorUnit = 1.0;
				}
			}
		}
		if (ChartCollection.smethod_17(series_0.Type) && series_0.method_20() != null)
		{
			interface28_0.BubbleScale = series_0.BubbleScale;
			interface28_0.ShowNegativeBubbles = series_0.ShowNegativeBubbles;
			interface28_0.SizeRepresents = Class869.smethod_5(series_0.SizeRepresents);
			arrayList2 = series_0.method_20().imethod_8(bool_0: true, bool_0, ref flag3);
			int num2 = 0;
			foreach (Class1196 item in arrayList2)
			{
				int num3 = num2;
				method_24(item, out var doubleValue3);
				Interface16 interface5 = interface28_0.Points[num3];
				interface5.imethod_18(doubleValue3);
				text = item.string_0;
				if ((text == null || text == "") && item.int_0 != 0)
				{
					text = workbook_0.Settings.method_3().method_8(item.int_0);
				}
				interface5.imethod_19(text);
				interface5.imethod_20(flag);
				num2++;
				if (num3 == interface28_0.Points.Count - 1)
				{
					break;
				}
			}
		}
		if (method_51(series_0.Type))
		{
			method_25(series_0.Marker, interface28_0.Marker);
		}
		if (series_0.method_5() != null)
		{
			method_42(series_0.Area, interface28_0.Area);
		}
		else if (series_0.method_28().method_9() != null)
		{
			method_42(series_0.method_28().method_9(), interface28_0.Area);
		}
		if (series_0.method_6() != null)
		{
			method_41(series_0.Border, interface28_0.Line);
		}
		else if (series_0.method_28().method_8() != null)
		{
			method_41(series_0.method_28().method_8(), interface28_0.Line);
		}
		bool flag5 = false;
		if (series_0.method_3() != null)
		{
			flag5 = true;
			for (int m = 0; m < interface28_0.Points.Count; m++)
			{
				method_10(series_0, interface28_0.Points[m], m);
			}
			if (chart_0.Type == ChartType.PieBar || chart_0.Type == ChartType.PiePie)
			{
				method_10(series_0, interface28_0.imethod_2(), interface28_0.Points.Count);
			}
		}
		else if ((series_0.method_6() != null && !series_0.Border.IsAuto) || (series_0.method_5() != null && series_0.Area.Formatting != 0) || (series_0.method_30() != null && series_0.Marker.MarkerStyle != 0) || (series_0.method_30() != null && series_0.Marker.Border.method_26() != 0) || (series_0.method_30() != null && series_0.Marker.Area.Formatting != 0))
		{
			flag5 = true;
			for (int n = 0; n < interface28_0.Points.Count; n++)
			{
				method_9(series_0, interface28_0.Points[n]);
			}
			if (chart_0.Type == ChartType.PieBar || chart_0.Type == ChartType.PiePie)
			{
				method_9(series_0, interface28_0.imethod_2());
			}
		}
		if (interface28_0.Marker.MarkerStyle != Enum65.const_5)
		{
			switch (interface28_0.Type)
			{
			case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
				interface28_0.Type = ChartType_Chart.ScatterConnectedByCurvesWithDataMarker;
				break;
			case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
				interface28_0.Type = ChartType_Chart.ScatterConnectedByLinesWithDataMarker;
				break;
			}
		}
		interface28_0.PlotOnSecondAxis = series_0.PlotOnSecondAxis;
		interface28_0.IsColorVaried = series_0.IsColorVaried;
		if (series_0.method_24() != null)
		{
			method_29(series_0.DataLabels, interface28_0.DataLabels, series_0.Type);
			if (!flag5)
			{
				for (int num4 = 0; num4 < interface28_0.Points.Count; num4++)
				{
					method_29(series_0.DataLabels, interface28_0.Points[num4].DataLabels, series_0.Type);
				}
			}
		}
		if (series_0.method_32() != null)
		{
			method_28(series_0.XErrorBar, interface28_0.XErrorBar);
		}
		if (series_0.method_33() != null)
		{
			method_28(series_0.YErrorBar, interface28_0.YErrorBar);
		}
		interface28_0.Smooth = series_0.Smooth;
		interface28_0.HasDropLines = series_0.HasDropLines;
		if (series_0.HasDropLines)
		{
			method_41(series_0.DropLines, interface28_0.DropLines);
		}
		interface28_0.imethod_4(series_0.HasHiLoLines);
		if (series_0.HasHiLoLines)
		{
			method_41(series_0.HiLoLines, interface28_0.imethod_5());
		}
		interface28_0.HasLeaderLines = series_0.HasLeaderLines;
		if (series_0.HasLeaderLines)
		{
			method_41(series_0.LeaderLines, interface28_0.LeaderLines);
		}
		interface28_0.HasUpDownBars = series_0.HasUpDownBars;
		if (series_0.HasUpDownBars)
		{
			method_26(series_0.UpBars, interface28_0.UpBars);
			method_26(series_0.DownBars, interface28_0.DownBars);
		}
		interface28_0.GapWidth = series_0.GapWidth;
		interface28_0.Overlap = series_0.Overlap;
		interface28_0.imethod_6(series_0.FirstSliceAngle);
		interface28_0.DoughnutHoleSize = series_0.DoughnutHoleSize;
		interface28_0.imethod_7(series_0.SecondPlotSize);
		if (!series_0.method_34())
		{
			interface28_0.Explosion = series_0.Explosion;
		}
		if (!series_0.IsAutoSplit)
		{
			interface28_0.SplitType = Class869.smethod_35(series_0.SplitType);
			interface28_0.SplitValue = series_0.SplitValue;
		}
		else
		{
			interface28_0.SplitType = Enum2.const_0;
		}
		interface28_0.HasSeriesLines = series_0.HasSeriesLines;
		if (series_0.HasSeriesLines)
		{
			method_41(series_0.SeriesLines, interface28_0.SeriesLines);
		}
		interface28_0.imethod_0(series_0.method_0());
		interface28_0.imethod_1(series_0.Index);
		if (!bool_1)
		{
			interface28_0.imethod_9(series_0.method_38());
		}
		interface28_0.imethod_10(series_0.Shadow);
	}

	private void method_9(Series series_0, Interface16 interface16_0)
	{
		Line line = ((series_0.method_6() == null) ? series_0.method_28().method_8() : series_0.method_6());
		if (line != null)
		{
			method_41(line, interface16_0.Border);
		}
		Area area = ((series_0.method_5() == null) ? series_0.method_28().method_9() : series_0.method_5());
		if (area != null)
		{
			method_42(area, interface16_0.Area);
		}
		Marker marker = ((series_0.method_30() == null) ? series_0.method_28().method_7() : series_0.method_30());
		if (marker != null)
		{
			method_25(marker, interface16_0.Marker);
		}
		DataLabels dataLabels = series_0.method_24();
		if (dataLabels != null)
		{
			method_29(dataLabels, interface16_0.DataLabels, series_0.Type);
		}
		interface16_0.imethod_21(series_0.Shadow);
	}

	private void method_10(Series series_0, Interface16 interface16_0, int int_0)
	{
		ChartPoint chartPoint = series_0.Points.method_5(int_0);
		if (chartPoint == null)
		{
			interface16_0.imethod_21(series_0.Shadow);
			Line line = series_0.method_6();
			if (line == null)
			{
				line = series_0.method_28().method_8();
			}
			if (line != null)
			{
				method_41(line, interface16_0.Border);
			}
			Area area = series_0.method_5();
			if (area == null)
			{
				area = series_0.method_28().method_9();
			}
			if (area != null)
			{
				method_42(area, interface16_0.Area);
			}
			Marker marker = series_0.method_30();
			if (marker == null)
			{
				marker = series_0.method_28().method_7();
			}
			if (marker != null)
			{
				method_25(marker, interface16_0.Marker);
			}
			DataLabels dataLabels = series_0.method_24();
			if (dataLabels != null)
			{
				method_29(dataLabels, interface16_0.DataLabels, series_0.Type);
			}
			return;
		}
		interface16_0.imethod_21(chartPoint.Shadow);
		if (!chartPoint.method_4())
		{
			interface16_0.Explosion = chartPoint.Explosion;
		}
		Line line2 = ((chartPoint.method_5() == null) ? series_0.method_6() : chartPoint.method_5());
		if (line2 == null)
		{
			line2 = series_0.method_28().method_8();
		}
		if (line2 != null)
		{
			method_41(line2, interface16_0.Border);
		}
		Area area2 = ((chartPoint.method_6() == null) ? series_0.method_5() : chartPoint.method_6());
		if (area2 == null)
		{
			area2 = series_0.method_28().method_9();
		}
		if (area2 != null)
		{
			method_42(area2, interface16_0.Area);
		}
		Marker marker2 = ((chartPoint.method_7() == null) ? series_0.method_30() : chartPoint.method_7());
		if (marker2 == null)
		{
			marker2 = series_0.method_28().method_7();
		}
		if (marker2 != null)
		{
			method_25(marker2, interface16_0.Marker);
		}
		DataLabels dataLabels2 = ((chartPoint.method_9() == null) ? series_0.method_24() : chartPoint.method_9());
		if (dataLabels2 != null)
		{
			method_29(dataLabels2, interface16_0.DataLabels, series_0.Type);
		}
	}

	private void method_11()
	{
		method_37(chart_0.ChartArea, interface7_0.ChartArea);
		interface7_0.ChartArea.Width = chart_0.ChartObject.Width;
		interface7_0.ChartArea.Height = chart_0.ChartObject.Height;
	}

	private void method_12()
	{
		method_37(chart_0.PlotArea, interface7_0.PlotArea);
		if ((chart_0.method_10() & 0x18) == 24)
		{
			interface7_0.PlotArea.X = chart_0.PlotArea.method_23();
			interface7_0.PlotArea.Y = chart_0.PlotArea.method_25();
			interface7_0.PlotArea.Width = chart_0.PlotArea.Width;
			interface7_0.PlotArea.Height = chart_0.PlotArea.Height;
		}
		interface7_0.IsInnerMode = chart_0.PlotArea.IsInnerMode;
		if (bool_1 && chart_0.PlotArea.IsInnerMode && (!chart_0.PlotArea.method_17() || !chart_0.PlotArea.IsAutoSize))
		{
			interface7_0.PlotArea.imethod_5(bool_0: false);
			interface7_0.PlotArea.X = chart_0.PlotArea.InnerX;
			interface7_0.PlotArea.Y = chart_0.PlotArea.InnerY;
			interface7_0.PlotArea.Width = chart_0.PlotArea.InnerWidth;
			interface7_0.PlotArea.Height = chart_0.PlotArea.InnerHeight;
		}
	}

	private void method_13()
	{
		method_14(chart_0.CategoryAxis, interface7_0.CategoryAxis);
		method_14(chart_0.ValueAxis, interface7_0.ValueAxis);
		method_14(chart_0.SecondCategoryAxis, interface7_0.imethod_3());
		method_14(chart_0.SecondValueAxis, interface7_0.imethod_4());
		for (int i = 0; i < chart_0.class1388_0.Count; i++)
		{
			Class1387 @class = chart_0.class1388_0[i];
			if (!ChartCollection.smethod_15(@class.method_11()))
			{
				continue;
			}
			if (@class.PlotOnSecondAxis)
			{
				if (!@class.HasRadarAxisLabels)
				{
					interface7_0.imethod_3().TickLabelPosition = Enum83.const_3;
				}
			}
			else if (!@class.HasRadarAxisLabels)
			{
				interface7_0.CategoryAxis.TickLabelPosition = Enum83.const_3;
			}
		}
		if (method_32(chart_0))
		{
			method_14(chart_0.SeriesAxis, interface7_0.SeriesAxis);
		}
	}

	private void method_14(Axis axis_0, Interface9 interface9_0)
	{
		interface9_0.IsVisible = axis_0.IsVisible;
		interface9_0.imethod_11(axis_0.string_0);
		interface9_0.AxisBetweenCategories = axis_0.AxisBetweenCategories;
		if (!bool_1 && axis_0.Type == Enum195.const_2)
		{
			interface9_0.AxisBetweenCategories = true;
		}
		if (axis_0.method_11() != null)
		{
			method_41(axis_0.AxisLine, interface9_0.AxisLine);
		}
		interface9_0.CategoryType = Class869.smethod_8(axis_0.CategoryType);
		if (axis_0.CategoryType != CategoryType.CategoryScale)
		{
			interface9_0.imethod_1(axis_0.method_22());
			if (!axis_0.method_22())
			{
				interface9_0.BaseUnitScale = Class869.smethod_6(axis_0.BaseUnitScale);
			}
			interface9_0.MajorUnitScale = Class869.smethod_6(axis_0.MajorUnitScale);
			interface9_0.MinorUnitScale = Class869.smethod_6(axis_0.MinorUnitScale);
		}
		interface9_0.CrossType = Class869.smethod_7(axis_0.CrossType);
		if (axis_0.CrossType == CrossType.Custom)
		{
			interface9_0.CrossAt = axis_0.CrossAt;
		}
		else if (axis_0.CrossType == CrossType.Automatic && axis_0.IsLogarithmic)
		{
			interface9_0.CrossAt = 1.0;
		}
		interface9_0.IsLogarithmic = axis_0.IsLogarithmic;
		interface9_0.LogBase = axis_0.LogBase;
		interface9_0.IsPlotOrderReversed = axis_0.IsPlotOrderReversed;
		interface9_0.imethod_8(axis_0.method_7());
		if (!axis_0.method_7())
		{
			interface9_0.MajorUnit = method_33(axis_0.MajorUnit);
		}
		interface9_0.imethod_10(axis_0.method_9());
		if (!axis_0.method_9())
		{
			interface9_0.MinorUnit = method_33(axis_0.MinorUnit);
		}
		interface9_0.imethod_6(axis_0.method_6());
		if (!axis_0.method_6())
		{
			if (axis_0.MaxValue is DateTime)
			{
				interface9_0.MaxValue = CellsHelper.GetDoubleFromDateTime((DateTime)axis_0.MaxValue, chart_0.Charts.method_0().method_2().Workbook.Settings.Date1904);
			}
			else
			{
				interface9_0.MaxValue = method_33((double)axis_0.MaxValue);
			}
		}
		interface9_0.imethod_4(axis_0.method_3());
		if (!axis_0.method_3())
		{
			if (axis_0.MinValue is DateTime)
			{
				interface9_0.MinValue = CellsHelper.GetDoubleFromDateTime((DateTime)axis_0.MinValue, chart_0.Charts.method_0().method_2().Workbook.Settings.Date1904);
			}
			else
			{
				interface9_0.MinValue = method_33((double)axis_0.MinValue);
			}
		}
		if (axis_0.method_26() != null)
		{
			method_41(axis_0.MajorGridLines, interface9_0.MajorGridLines);
		}
		else
		{
			interface9_0.MajorGridLines.Formatting = Enum71.const_0;
		}
		if (axis_0.method_28() != null)
		{
			method_41(axis_0.MinorGridLines, interface9_0.MinorGridLines);
		}
		else
		{
			interface9_0.MinorGridLines.Formatting = Enum71.const_0;
		}
		if (axis_0.method_20() != null && ((axis_0.Title.Text != null && axis_0.Title.Text != "") || axis_0.Title.IsAutoText))
		{
			method_38(axis_0.Title, interface9_0.Title, bool_4: false);
		}
		if (axis_0.method_13())
		{
			interface9_0.MajorTickMark = Class869.smethod_17(axis_0.MajorTickMark);
			interface9_0.MinorTickMark = Class869.smethod_17(axis_0.MinorTickMark);
			interface9_0.TickLabelPosition = Class869.smethod_16(axis_0.TickLabelPosition);
			interface9_0.imethod_2(axis_0.method_16());
			if (!axis_0.method_16())
			{
				interface9_0.TickLabelSpacing = axis_0.TickLabelSpacing;
			}
			interface9_0.TickMarkSpacing = axis_0.TickMarkSpacing;
			if (axis_0.method_14() != null)
			{
				method_36(axis_0, axis_0.TickLabels, interface9_0.TickLabels);
			}
		}
		if (axis_0.DisplayUnit != 0)
		{
			interface9_0.DisplayUnit.imethod_1(Class869.smethod_0(axis_0.DisplayUnit));
			if (axis_0.IsDisplayUnitLabelShown)
			{
				interface9_0.DisplayUnit.imethod_3(bool_0: true);
				method_35(axis_0.DisplayUnitLabel, interface9_0.DisplayUnit);
			}
			else
			{
				interface9_0.DisplayUnit.imethod_3(bool_0: false);
			}
		}
	}

	private void method_15()
	{
		if (!chart_0.ShowLegend)
		{
			interface7_0.IsLegendShown = false;
			return;
		}
		interface7_0.IsLegendShown = true;
		if (chart_0.method_24() == null)
		{
			return;
		}
		Legend legend = chart_0.Legend;
		Interface23 legend2 = interface7_0.Legend;
		legend2.imethod_1(legend.method_45());
		method_37(legend, legend2.imethod_0());
		legend2.imethod_2(Class869.smethod_14(legend.Position));
		legend2.imethod_0().imethod_4(legend.IsAutoSize);
		legend2.imethod_0().imethod_1(legend.method_18());
		legend2.imethod_0().imethod_2(legend.method_20());
		if (!bool_1)
		{
			LegendPositionType position = legend.Position;
			if (position == LegendPositionType.Right && !legend2.imethod_0().imethod_0() && chart_0.PlotArea.IsAutoSize && chart_0.PlotArea.method_17())
			{
				legend2.imethod_0().imethod_1(bool_0: true);
			}
		}
		if (!legend.IsAutoSize)
		{
			legend2.imethod_0().Width = legend.Width;
			legend2.imethod_0().Height = legend.Height;
		}
		if (legend.method_44() != null)
		{
			method_16();
		}
	}

	private void method_16()
	{
		Legend legend = chart_0.Legend;
		Interface23 legend2 = interface7_0.Legend;
		for (int i = 0; i < legend.LegendEntries.Count; i++)
		{
			LegendEntry legendEntry = legend.LegendEntries.method_1(i);
			Interface22 @interface = legend2.LegendEntries.Add(legendEntry.Index);
			@interface.Font = method_39(legendEntry.Font);
			if (!legendEntry.Font.Color.IsEmpty)
			{
				if (legendEntry.Font.Color.A == 0)
				{
					@interface.FontColor = Color.FromArgb(legendEntry.Font.Color.ToArgb() | -16777216);
				}
				else
				{
					@interface.FontColor = legendEntry.Font.Color;
				}
			}
			@interface.IsDeleted = legendEntry.IsDeleted;
		}
	}

	private void method_17()
	{
		interface7_0.IsDataTableShown = chart_0.ShowDataTable;
		if (!chart_0.ShowDataTable)
		{
			return;
		}
		ChartDataTable chartDataTable = chart_0.ChartDataTable;
		Interface13 chartDataTable2 = interface7_0.ChartDataTable;
		method_41(chartDataTable.Border, chartDataTable2.Border);
		if (chartDataTable.method_0() != null || chartDataTable.method_1() != -1)
		{
			chartDataTable2.Font = method_39(chartDataTable.Font);
			if (!chartDataTable.Font.Color.IsEmpty)
			{
				chartDataTable2.FontColor = method_50(chartDataTable.Font.Color);
			}
		}
		chartDataTable2.imethod_3(chartDataTable.HasBorderHorizontal);
		chartDataTable2.imethod_0(chartDataTable.ShowLegendKey);
		chartDataTable2.IsOutlineShown = chartDataTable.HasBorderOutline;
		chartDataTable2.imethod_2(chartDataTable.HasBorderVertical);
	}

	private void method_18(Chart chart_1, Class821 class821_1)
	{
		if (chart_1.method_16() == null || chart_1.method_16().Count == 0)
		{
			return;
		}
		foreach (Shape shape in chart_1.Shapes)
		{
			if (!shape.IsHidden && shape.MsoDrawingType != MsoDrawingType.Chart)
			{
				Class913 class913_ = class821_1.Shapes.Add(Class912.smethod_22(shape.MsoDrawingType));
				Class912.smethod_3(shape, class913_);
			}
		}
	}

	private void method_19(Chart chart_1, Class787 class787_1)
	{
		if (chart_1.method_16() == null || chart_1.method_16().Count == 0)
		{
			return;
		}
		int int_ = Class817.int_2;
		foreach (Shape shape in chart_1.Shapes)
		{
			if (!shape.IsHidden && shape.MsoDrawingType != MsoDrawingType.Chart)
			{
				Class898 @class = class787_1.Shapes.Add(Class897.smethod_21(shape.MsoDrawingType));
				Class897.smethod_3(shape, @class);
				Class1698 class2 = shape.method_27().method_7();
				Rectangle empty = Rectangle.Empty;
				empty = ((class2.method_3() == PlacementType.MoveAndSize) ? new Rectangle(class2.Left, class2.Top, class2.Right - class2.Left, class2.Bottom - class2.Top) : ((class2.method_3() != PlacementType.Move) ? new Rectangle(class2.Left, class2.Top, 0, 0) : new Rectangle(class2.Left, class2.Top, (int)(4000f * (float)class2.Right / (float)class787_1.Width), (int)(4000f * (float)class2.Bottom / (float)class787_1.Height))));
				Rectangle empty2 = Rectangle.Empty;
				int num = class787_1.Width - 2 * int_;
				int num2 = class787_1.Height - 2 * int_;
				if (num < 0)
				{
					num = 0;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				empty2.X = (int)((float)(empty.Left * num) / 4000f) + int_;
				empty2.Y = (int)((float)(empty.Top * num2) / 4000f) + int_;
				empty2.Width = (int)((float)(empty.Width * num) / 4000f);
				empty2.Height = (int)((float)(empty.Height * num2) / 4000f);
				@class.X = empty2.X;
				@class.Y = empty2.Y;
				@class.Width = empty2.Width;
				@class.Height = empty2.Height;
			}
		}
	}

	private ArrayList[] method_20(bool bool_4, Interface45 interface45_0, Interface10 interface10_0, ref bool bool_5)
	{
		int int_ = 1;
		bool flag = false;
		bool_5 = true;
		for (int i = 0; i < chart_0.NSeries.Count; i++)
		{
			Interface45 @interface = chart_0.NSeries[i].method_16();
			if (chart_0.NSeries[i].PlotOnSecondAxis == bool_4 && @interface != null && @interface.imethod_1())
			{
				flag = true;
				break;
			}
		}
		ArrayList arrayList = interface45_0.imethod_7(flag, bool_0, ref int_);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (int_ == 1)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					Class1196 @class = (Class1196)arrayList[j];
					if (!chart_0.PlotVisibleCells || @class.bool_0)
					{
						Interface11 interface2 = interface10_0.AddLabel(@class.object_0);
						interface2.imethod_8(@class.bool_1);
						interface2.imethod_4(@class.string_0);
						if (@class.cellValueType_0 == CellValueType.IsDateTime)
						{
							interface2.imethod_6(@class.bool_2);
						}
						if (@class.int_0 != 0)
						{
							interface2.imethod_4(workbook_0.Settings.method_3().method_8(@class.int_0));
						}
					}
				}
				bool_5 = interface10_0.Count != 0;
				if (!bool_5)
				{
					Interface11 interface3 = interface10_0.AddLabel("");
					interface3.imethod_8(bool_0: true);
				}
				return null;
			}
			int count = arrayList.Count;
			ArrayList[] array = new ArrayList[count];
			ArrayList[] array2 = new ArrayList[count];
			for (int k = 0; k < array2.Length; k++)
			{
				array[k] = (ArrayList)arrayList[k];
				array2[k] = new ArrayList();
			}
			array[count - 1] = (ArrayList)arrayList[count - 1];
			int count2 = array[0].Count;
			ArrayList arrayList2 = null;
			Interface11 interface4 = null;
			bool flag2 = false;
			for (int l = 0; l < count2; l++)
			{
				flag2 = false;
				for (int m = 0; m < array.Length; m++)
				{
					Class1196 class2 = (Class1196)array[m][l];
					if (l == 0 || flag2 || m == array.Length - 1 || (class2.object_0 != null && (!(class2.object_0 is string) || !((string)class2.object_0 == ""))))
					{
						flag2 = true;
						Interface11 interface5;
						if (m == 0)
						{
							interface5 = interface10_0.AddLabel(class2.object_0);
						}
						else
						{
							arrayList2 = array2[m - 1];
							interface4 = (Interface11)arrayList2[arrayList2.Count - 1];
							interface5 = interface4.imethod_9().AddLabel(class2.object_0);
						}
						interface5.imethod_8(class2.bool_1);
						interface5.imethod_4(class2.string_0);
						if (class2.cellValueType_0 == CellValueType.IsDateTime)
						{
							interface5.imethod_6(class2.bool_2);
						}
						if (class2.int_0 != 0)
						{
							interface5.imethod_4(workbook_0.Settings.method_3().method_8(class2.int_0));
						}
						array2[m].Add(interface5);
					}
				}
			}
			return array2;
		}
		return null;
	}

	private void method_21()
	{
		if (chart_0.NSeries.Count == 0)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool bool_ = true;
		bool bool_2 = true;
		foreach (Series item in chart_0.NSeries)
		{
			if (item.method_18() == null)
			{
				if (item.PlotOnSecondAxis)
				{
					flag2 = true;
				}
				else
				{
					flag = true;
				}
				continue;
			}
			if (item.PlotOnSecondAxis)
			{
				if (!flag2 && !ChartCollection.smethod_12(item.Type))
				{
					method_20(bool_4: true, item.method_18(), interface7_0.NSeries.imethod_1(), ref bool_2);
					flag2 = true;
				}
			}
			else if (!flag && !ChartCollection.smethod_12(item.Type))
			{
				method_20(bool_4: false, item.method_18(), interface7_0.NSeries.imethod_0(), ref bool_);
				flag = true;
			}
			if (!flag2 || !flag)
			{
				continue;
			}
			break;
		}
	}

	private string method_22(Series series_0)
	{
		if (series_0.method_13() != null)
		{
			if (series_0.method_13() is string)
			{
				return series_0.Name;
			}
			bool flag = false;
			Interface45 @interface = Class1195.smethod_0(series_0.method_10(), series_0.method_11());
			@interface.imethod_5((byte[])series_0.method_13());
			ArrayList arrayList = @interface.imethod_8(bool_0: false, bool_0, ref flag);
			if (flag)
			{
				if (series_0.string_0 != null)
				{
					return series_0.string_0;
				}
			}
			else if (arrayList != null && arrayList.Count != 0)
			{
				string text = "";
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class1196 @class = (Class1196)arrayList[i];
					Class518 class2 = ((@class.string_0 == null || !(@class.string_0 == "")) ? workbook_0.Settings.method_3().Format(@class.string_0, @class.object_0, bool_1: false) : workbook_0.Settings.method_3().Format(null, @class.object_0, bool_1: false));
					text += class2.StringValue;
					if (i != arrayList.Count - 1)
					{
						text += " ";
					}
				}
				return text;
			}
		}
		return null;
	}

	private string method_23(Class1196 class1196_0)
	{
		CellValueType cellValueType_ = class1196_0.cellValueType_0;
		if (cellValueType_ == CellValueType.IsDateTime)
		{
			if (class1196_0.object_0 != null && class1196_0.StringValue != "")
			{
				double num = 0.0;
				try
				{
					num = (double)class1196_0.object_0;
				}
				catch
				{
					return class1196_0.StringValue;
				}
				string text = null;
				text = class1196_0.string_0;
				if ((text == null || text == "") && class1196_0.int_0 != 0)
				{
					text = workbook_0.Settings.method_3().method_8(class1196_0.int_0);
				}
				DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(num, chart_0.method_15().Workbook.Settings.Date1904);
				if (text != null && text == "")
				{
					text = null;
				}
				Class518 @class = workbook_0.Settings.method_3().Format(text, dateTimeFromDouble, bool_1: false);
				return @class.StringValue;
			}
			return class1196_0.StringValue;
		}
		if (class1196_0.object_0 != null && class1196_0.StringValue != "")
		{
			string text2 = null;
			text2 = class1196_0.string_0;
			if ((text2 == null || text2 == "") && class1196_0.int_0 != 0)
			{
				text2 = workbook_0.Settings.method_3().method_8(class1196_0.int_0);
			}
			if (text2 != null && text2 == "")
			{
				text2 = null;
			}
			Class518 class2 = workbook_0.Settings.method_3().Format(text2, class1196_0.object_0, bool_1: false);
			return class2.StringValue;
		}
		return class1196_0.StringValue;
	}

	private bool method_24(Class1196 dataValue, out double doubleValue)
	{
		switch (dataValue.cellValueType_0)
		{
		default:
			doubleValue = 0.0;
			return true;
		case CellValueType.IsBool:
			try
			{
				doubleValue = Convert.ToDouble(dataValue.object_0);
			}
			catch
			{
				doubleValue = 0.0;
			}
			return true;
		case CellValueType.IsNull:
			doubleValue = 0.0;
			return false;
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
			if (dataValue.StringValue != "")
			{
				doubleValue = Convert.ToDouble(dataValue.object_0);
				return true;
			}
			doubleValue = 0.0;
			return false;
		case CellValueType.IsError:
		case CellValueType.IsString:
		case CellValueType.IsUnknown:
			doubleValue = 0.0;
			return true;
		}
	}

	private void ChangePalette(Workbook workbook_1)
	{
		if (bool_1)
		{
			Class928[] class928_ = workbook_1.class1569_0.class928_0;
			Color[] array = new Color[12];
			for (int i = 0; i < array.Length && i < class928_.Length; i++)
			{
				ref Color reference = ref array[i];
				reference = class928_[i].Color;
			}
			interface7_0.ChangePalette(array);
			return;
		}
		new SortedList();
		SortedList sortedList = workbook_1.Worksheets.method_24().method_0();
		Color[] array2 = new Color[sortedList.Count - 8];
		int num = 0;
		for (int j = 24; j < sortedList.Count; j++)
		{
			int num2 = (int)sortedList[j];
			int red = num2 & 0xFF;
			int green = (num2 & 0xFF00) >> 8;
			int blue = (num2 & 0xFF0000) >> 16;
			ref Color reference2 = ref array2[num++];
			reference2 = Color.FromArgb(red, green, blue);
		}
		for (int k = 8; k < 24; k++)
		{
			int num3 = (int)sortedList[k];
			int red2 = num3 & 0xFF;
			int green2 = (num3 & 0xFF00) >> 8;
			int blue2 = (num3 & 0xFF0000) >> 16;
			ref Color reference3 = ref array2[num++];
			reference3 = Color.FromArgb(red2, green2, blue2);
		}
		interface7_0.ChangePalette(array2);
	}

	private void method_25(Marker marker_0, Interface26 interface26_0)
	{
		if (!marker_0.bool_0)
		{
			interface26_0.MarkerSize = (int)((float)(marker_0.MarkerSize * workbook_0.Worksheets.method_75()) / 72f + 0.5f);
		}
		interface26_0.MarkerStyle = Class869.smethod_2(marker_0.MarkerStyle);
		Line line = marker_0.method_3();
		if (line != null)
		{
			method_41(line, interface26_0.Border);
		}
		Area area = marker_0.method_2();
		if (area != null)
		{
			method_42(area, interface26_0.Area);
		}
	}

	private void method_26(DropBars dropBars_0, Interface14 interface14_0)
	{
		if (dropBars_0.method_1() != null)
		{
			method_42(dropBars_0.Area, interface14_0.Area);
		}
		if (dropBars_0.method_0() != null)
		{
			method_41(dropBars_0.Border, interface14_0.Border);
		}
	}

	private ArrayList method_27(Series series_0, Interface45 interface45_0)
	{
		bool flag = false;
		ArrayList arrayList = interface45_0.imethod_8(bool_0: true, bool_0, ref flag);
		ArrayList arrayList2 = new ArrayList();
		if (arrayList.Count == 1)
		{
			int count = series_0.Points.Count;
			object object_ = ((Class1196)arrayList[0]).object_0;
			for (int i = 0; i < count; i++)
			{
				arrayList2.Add(object_);
			}
		}
		else
		{
			for (int j = 0; j < arrayList.Count; j++)
			{
				object object_2 = ((Class1196)arrayList[j]).object_0;
				arrayList2.Add(object_2);
			}
		}
		return arrayList2;
	}

	private void method_28(ErrorBar errorBar_0, Interface19 interface19_0)
	{
		interface19_0.Type = Class869.smethod_11(errorBar_0.Type);
		interface19_0.Amount = errorBar_0.Amount;
		interface19_0.DisplayType = Class869.smethod_10(errorBar_0.DisplayType);
		if (errorBar_0.Type == ErrorBarType.Custom)
		{
			if (errorBar_0.DisplayType == ErrorBarDisplayType.Both || errorBar_0.DisplayType == ErrorBarDisplayType.Minus)
			{
				Interface45 @interface = errorBar_0.method_37();
				if (@interface.imethod_6())
				{
					interface19_0.Type = Enum69.const_1;
				}
				else
				{
					ArrayList arrayList = method_27(errorBar_0.method_39(), @interface);
					if (arrayList != null)
					{
						interface19_0.imethod_1(arrayList.ToArray());
					}
				}
			}
			if (errorBar_0.DisplayType == ErrorBarDisplayType.Both || errorBar_0.DisplayType == ErrorBarDisplayType.Minus)
			{
				Interface45 interface2 = errorBar_0.method_35();
				if (interface2.imethod_6())
				{
					interface19_0.Type = Enum69.const_1;
				}
				else
				{
					ArrayList arrayList2 = method_27(errorBar_0.method_39(), interface2);
					if (arrayList2 != null)
					{
						interface19_0.imethod_2(arrayList2.ToArray());
					}
				}
			}
		}
		interface19_0.imethod_0(errorBar_0.method_33());
		method_41(errorBar_0, interface19_0.Border);
	}

	private void method_29(DataLabels dataLabels_0, Interface17 interface17_0, ChartType chartType_0)
	{
		if (dataLabels_0.IsDeleted)
		{
			interface17_0.Text = "";
			return;
		}
		if (!dataLabels_0.IsAutoText)
		{
			if (dataLabels_0.Text == null)
			{
				interface17_0.Text = "";
			}
			else
			{
				interface17_0.Text = dataLabels_0.Text;
				if (dataLabels_0.method_39() != null)
				{
					bool flag = false;
					if (dataLabels_0.method_39().Count > 1)
					{
						flag = method_30(dataLabels_0.method_39(), dataLabels_0.Text, interface17_0.imethod_4());
					}
					if (flag || dataLabels_0.method_39().Count == 1)
					{
						FontSetting fontSetting = (FontSetting)dataLabels_0.method_39()[0];
						interface17_0.imethod_0().Font = method_39(fontSetting.Font);
						if (!fontSetting.Font.Color.IsEmpty)
						{
							if (fontSetting.Font.Color.A == 0)
							{
								interface17_0.imethod_0().FontColor = Color.FromArgb(fontSetting.Font.Color.ToArgb() | -16777216);
							}
							else
							{
								interface17_0.imethod_0().FontColor = fontSetting.Font.Color;
							}
						}
					}
				}
			}
		}
		interface17_0.IsCategoryNameShown = dataLabels_0.ShowCategoryName;
		interface17_0.IsLegendKeyShown = dataLabels_0.ShowLegendKey;
		interface17_0.IsPercentageShown = dataLabels_0.ShowPercentage;
		interface17_0.IsSeriesNameShown = dataLabels_0.ShowSeriesName;
		interface17_0.IsValueShown = dataLabels_0.ShowValue;
		interface17_0.IsBubbleSizeShown = dataLabels_0.ShowBubbleSize;
		interface17_0.Separator = Class869.smethod_4(dataLabels_0.Separator);
		if (dataLabels_0.bool_15)
		{
			interface17_0.imethod_1(method_31(chartType_0));
		}
		else
		{
			interface17_0.imethod_1(Class869.smethod_13(dataLabels_0.Position));
		}
		method_37(dataLabels_0, interface17_0.imethod_0());
		if (dataLabels_0.method_12() == null && dataLabels_0.method_13() == -1 && dataLabels_0.method_60() != null && dataLabels_0.method_60() is ChartPoint)
		{
			ChartPoint chartPoint = (ChartPoint)dataLabels_0.method_60();
			Series series = chartPoint.method_0();
			if (series.DataLabels.method_12() != null || series.DataLabels.method_13() != -1)
			{
				interface17_0.imethod_0().Font = method_39(series.DataLabels.Font);
				if (!series.DataLabels.Font.Color.IsEmpty)
				{
					if (series.DataLabels.Font.Color.A == 0)
					{
						interface17_0.imethod_0().FontColor = Color.FromArgb(series.DataLabels.Font.Color.ToArgb() | -16777216);
					}
					else
					{
						interface17_0.imethod_0().FontColor = series.DataLabels.Font.Color;
					}
				}
			}
		}
		interface17_0.LinkedSource = dataLabels_0.NumberFormatLinked;
		if (!dataLabels_0.NumberFormatLinked)
		{
			if (dataLabels_0.Number != 0)
			{
				interface17_0.imethod_3(workbook_0.Settings.method_3().method_8(dataLabels_0.Number));
			}
			else if (dataLabels_0.NumberFormat != null && dataLabels_0.NumberFormat != "")
			{
				interface17_0.imethod_3(dataLabels_0.NumberFormat);
			}
		}
		interface17_0.Rotation = dataLabels_0.RotationAngle;
		interface17_0.TextHorizontalAlignment = Class869.smethod_15(dataLabels_0.TextHorizontalAlignment);
		interface17_0.TextVerticalAlignment = Class869.smethod_15(dataLabels_0.TextVerticalAlignment);
		if (dataLabels_0.method_34())
		{
			interface17_0.imethod_0().imethod_6(bool_0: true);
			interface17_0.imethod_0().X = dataLabels_0.X;
			interface17_0.imethod_0().Y = dataLabels_0.Y;
			interface17_0.imethod_0().Width = dataLabels_0.Width;
			interface17_0.imethod_0().Height = dataLabels_0.Height;
		}
		else if (dataLabels_0.method_36())
		{
			interface17_0.imethod_0().imethod_6(bool_0: false);
			interface17_0.imethod_0().X = dataLabels_0.OffsetX;
			interface17_0.imethod_0().Y = dataLabels_0.OffsetY;
			interface17_0.imethod_0().Width = dataLabels_0.method_37();
			interface17_0.imethod_0().Height = dataLabels_0.method_38();
		}
	}

	private bool method_30(ArrayList arrayList_0, string string_0, Interface38 interface38_0)
	{
		bool flag = true;
		Color color = Color.Empty;
		System.Drawing.Font font_ = null;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			FontSetting fontSetting = (FontSetting)arrayList_0[i];
			string string_ = string_0.Substring(fontSetting.StartIndex, fontSetting.Length);
			System.Drawing.Font font = method_39(fontSetting.Font);
			if (i == 0)
			{
				font_ = font;
				color = fontSetting.Font.Color;
			}
			else if (flag && (!method_40(font_, font) || color.R != fontSetting.Font.Color.R || color.G != fontSetting.Font.Color.G || color.B != fontSetting.Font.Color.B))
			{
				flag = false;
			}
			interface38_0.Add(string_, font, Color.FromArgb(255, fontSetting.Font.Color), Enum81.const_2);
		}
		if (flag)
		{
			interface38_0.Clear();
		}
		return flag;
	}

	private Enum74 method_31(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			return Enum74.const_0;
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
			return Enum74.const_1;
		case ChartType.Bar:
		case ChartType.Bar3DClustered:
		case ChartType.Column:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Cone:
		case ChartType.ConicalBar:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalColumn3D:
		case ChartType.Pyramid:
		case ChartType.PyramidBar:
		case ChartType.PyramidColumn3D:
			return Enum74.const_4;
		default:
			return Enum74.const_1;
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			return Enum74.const_8;
		}
	}

	private bool method_32(Chart chart_1)
	{
		switch (chart_1.Type)
		{
		default:
			return false;
		case ChartType.Area3D:
		case ChartType.Column3D:
		case ChartType.ConicalColumn3D:
		case ChartType.CylindricalColumn3D:
		case ChartType.Line3D:
		case ChartType.PyramidColumn3D:
			return true;
		}
	}

	private double method_33(double double_0)
	{
		if (double_0 > 1.0)
		{
			return double_0;
		}
		int num = method_34(double_0);
		if (num > 15)
		{
			double value = double_0 * Math.Pow(10.0, num - 15 - 1);
			double num2 = Math.Round(value, 15);
			return num2 * Math.Pow(10.0, 16 - num);
		}
		return double_0;
	}

	private int method_34(double double_0)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		int num = 1;
		string text = "";
		string text2 = double_0.ToString();
		int num2 = text2.IndexOf("E");
		int num3 = text2.IndexOf("e");
		if (num2 > 0 || num3 > 0)
		{
			string[] array = ((num2 <= 0) ? text2.Split('e') : text2.Split('E'));
			if (array[0][0] == '-')
			{
				array[0] = array[0].Substring(1);
			}
			int num4 = array[0].IndexOf(c);
			int num5 = Math.Abs(Convert.ToInt32(array[1]));
			if (num4 > 0)
			{
				text = array[0].Substring(0, num4) + array[0].Substring(num4 + 1);
				if (array[1][0] == '-')
				{
					int num6 = num5 - (num4 - 1);
					if (num6 > 0)
					{
						while (num6 > 0)
						{
							text = "0" + text;
							num6--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num6 < 0)
					{
						text = text.Substring(0, num4 + num6) + c + text.Substring(num4 + num6);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			else
			{
				text = array[0];
				if (array[1][0] == '-')
				{
					int num7 = num5 - (text.Length - 1);
					if (num7 > 0)
					{
						while (num7 > 0)
						{
							text = "0" + text;
							num7--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num7 < 0)
					{
						text = text.Substring(0, text.Length + num7) + c + text.Substring(text.Length + num7);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			text2 = text;
		}
		int num8 = text2.IndexOf(c, 0);
		if (num8 > 0)
		{
			for (int i = num8 + 1; i < text2.Length; i++)
			{
				num++;
			}
		}
		return num;
	}

	private void method_35(DisplayUnitLabel displayUnitLabel_0, Interface18 interface18_0)
	{
		method_37(displayUnitLabel_0, interface18_0.imethod_0());
		interface18_0.TextHorizontalAlignment = Class869.smethod_15(displayUnitLabel_0.TextHorizontalAlignment);
		interface18_0.TextVerticalAlignment = Class869.smethod_15(displayUnitLabel_0.TextVerticalAlignment);
		interface18_0.Rotation = displayUnitLabel_0.RotationAngle;
		if (displayUnitLabel_0.Text != null && displayUnitLabel_0.Text != "")
		{
			interface18_0.imethod_2(displayUnitLabel_0.Text);
		}
	}

	private void method_36(Axis axis_0, TickLabels tickLabels_0, Interface29 interface29_0)
	{
		if (tickLabels_0.method_0() != null || tickLabels_0.method_1() != -1)
		{
			interface29_0.Font = method_39(tickLabels_0.Font);
			if (!tickLabels_0.Font.Color.IsEmpty)
			{
				interface29_0.FontColor = method_50(tickLabels_0.Font.Color);
			}
		}
		interface29_0.LinkedSource = tickLabels_0.NumberFormatLinked;
		if (!tickLabels_0.NumberFormatLinked)
		{
			int number = tickLabels_0.Number;
			string numberFormat = tickLabels_0.NumberFormat;
			if (numberFormat != null && numberFormat != "")
			{
				interface29_0.imethod_1(numberFormat);
			}
			else if (number != 0)
			{
				interface29_0.imethod_1(workbook_0.Settings.method_3().method_8(number));
			}
		}
		interface29_0.Offset = tickLabels_0.Offset;
		if (!tickLabels_0.method_5())
		{
			interface29_0.Rotation = tickLabels_0.RotationAngle;
		}
	}

	private void method_37(ChartFrame chartFrame_0, Interface14 interface14_0)
	{
		method_41(chartFrame_0.Border, interface14_0.Border);
		method_42(chartFrame_0.Area, interface14_0.Area);
		if (chartFrame_0.method_12() != null || chartFrame_0.method_13() != -1)
		{
			interface14_0.Font = method_39(chartFrame_0.Font);
			if (!chartFrame_0.Font.InternalColor.method_2() && !chartFrame_0.Font.Color.IsEmpty)
			{
				if (chartFrame_0.Font.Color.A == 0)
				{
					interface14_0.FontColor = Color.FromArgb(chartFrame_0.Font.Color.ToArgb() | -16777216);
				}
				else
				{
					interface14_0.FontColor = chartFrame_0.Font.Color;
				}
			}
		}
		if (!chartFrame_0.method_17() || !chartFrame_0.IsAutoSize)
		{
			interface14_0.imethod_5(bool_0: false);
			interface14_0.X = chartFrame_0.method_23();
			interface14_0.Y = chartFrame_0.method_25();
			interface14_0.Width = chartFrame_0.Width;
			interface14_0.Height = chartFrame_0.Height;
		}
	}

	private void method_38(Title title_0, Interface30 interface30_0, bool bool_4)
	{
		method_41(title_0.Border, interface30_0.imethod_0().Border);
		method_42(title_0.Area, interface30_0.imethod_0().Area);
		if (title_0.method_12() != null || title_0.method_13() != -1)
		{
			interface30_0.imethod_0().Font = method_39(title_0.Font);
			if (!title_0.Font.InternalColor.method_2() && !title_0.Font.Color.IsEmpty)
			{
				if (title_0.Font.Color.A == 0)
				{
					interface30_0.imethod_0().FontColor = Color.FromArgb(title_0.Font.Color.ToArgb() | -16777216);
				}
				else
				{
					interface30_0.imethod_0().FontColor = title_0.Font.Color;
				}
			}
		}
		if (bool_1)
		{
			if (!title_0.method_17())
			{
				interface30_0.imethod_0().X = title_0.method_23();
				interface30_0.imethod_0().Y = title_0.method_25();
			}
			interface30_0.imethod_0().imethod_6(title_0.method_1() || title_0.method_3());
		}
		else if (!title_0.method_17())
		{
			interface30_0.imethod_0().X = title_0.method_23();
			interface30_0.imethod_0().Y = title_0.method_25();
			interface30_0.imethod_0().imethod_6(title_0.method_1() || title_0.method_3());
		}
		interface30_0.imethod_0().imethod_4(bool_0: true);
		interface30_0.Rotation = title_0.RotationAngle;
		if (title_0.IsAutoText)
		{
			if (bool_4)
			{
				if (bool_1)
				{
					if ((chart_0.NSeries.Count == 1 || ChartCollection.smethod_3(chart_0.Type)) && chart_0.NSeries[0].Name != null)
					{
						string text = method_22(chart_0.NSeries[0]);
						if (text != null)
						{
							interface7_0.Title.Text = text;
						}
						else
						{
							interface30_0.Text = "Chart Title";
						}
					}
					else
					{
						interface30_0.Text = "Chart Title";
					}
				}
			}
			else if (title_0.axis_0 != null)
			{
				interface30_0.Text = "Axis Title";
			}
		}
		else if (interface30_0.Text == null)
		{
			interface30_0.Text = "";
		}
		else
		{
			interface30_0.Text = title_0.Text;
			if (title_0.method_39() != null)
			{
				bool flag = false;
				if (title_0.method_39().Count > 1)
				{
					flag = method_30(title_0.method_39(), title_0.Text, interface30_0.imethod_1());
				}
				if (flag || title_0.method_39().Count == 1)
				{
					FontSetting fontSetting = (FontSetting)title_0.method_39()[0];
					interface30_0.imethod_0().Font = method_39(fontSetting.Font);
					if (!fontSetting.Font.Color.IsEmpty)
					{
						if (fontSetting.Font.Color.A == 0)
						{
							interface30_0.imethod_0().FontColor = Color.FromArgb(fontSetting.Font.Color.ToArgb() | -16777216);
						}
						else
						{
							interface30_0.imethod_0().FontColor = fontSetting.Font.Color;
						}
					}
				}
			}
		}
		interface30_0.TextHorizontalAlignment = Class869.smethod_15(title_0.TextHorizontalAlignment);
		interface30_0.TextVerticalAlignment = Class869.smethod_15(title_0.TextVerticalAlignment);
	}

	private System.Drawing.Font method_39(Aspose.Cells.Font font_0)
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (font_0.IsBold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (font_0.IsItalic)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (font_0.IsStrikeout)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		if (font_0.Underline != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		double doubleSize = font_0.DoubleSize;
		string name = font_0.Name;
		try
		{
			return new System.Drawing.Font(name, (float)doubleSize, fontStyle);
		}
		catch
		{
			Class1460 @class = Class1462.smethod_3(name, fontStyle, bool_0: false);
			return new System.Drawing.Font(font_0.Name, (float)doubleSize, @class.Style);
		}
	}

	private bool method_40(System.Drawing.Font font_0, System.Drawing.Font font_1)
	{
		if (font_0.Name != font_1.Name)
		{
			return false;
		}
		if (font_0.Size != font_1.Size)
		{
			return false;
		}
		if (font_0.Bold != font_1.Bold)
		{
			return false;
		}
		if (font_0.Italic != font_1.Italic)
		{
			return false;
		}
		if (font_0.Strikeout != font_1.Strikeout)
		{
			return false;
		}
		if (font_0.Underline != font_1.Underline)
		{
			return false;
		}
		return true;
	}

	private void method_41(Line line_0, Interface25 interface25_0)
	{
		if (line_0 == null)
		{
			return;
		}
		if (!line_0.IsVisible)
		{
			interface25_0.Formatting = Enum71.const_0;
			return;
		}
		if (line_0.IsAuto)
		{
			interface25_0.Formatting = Enum71.const_1;
			return;
		}
		interface25_0.Formatting = Class869.smethod_19(line_0.method_26());
		if (line_0.Color.IsEmpty)
		{
			interface25_0.imethod_0(bool_0: true);
		}
		else
		{
			interface25_0.imethod_0(bool_0: false);
			interface25_0.Color = method_49(line_0.Color, line_0.method_22());
		}
		if (bool_1)
		{
			if (line_0.method_28())
			{
				interface25_0.LineStyle.Width = line_0.WeightPt * (double)chart_0.method_14().method_75() / 72.0;
			}
			interface25_0.LineStyle.imethod_0(Class869.smethod_23(line_0.method_1()));
			interface25_0.LineStyle.DashStyle = Class869.smethod_20(line_0.method_3());
			interface25_0.LineStyle.imethod_1(Class869.smethod_24(line_0.method_5()));
			interface25_0.LineStyle.imethod_2(Class869.smethod_25(line_0.method_7()));
			interface25_0.LineStyle.imethod_5(Class869.smethod_27(line_0.method_13()));
			interface25_0.LineStyle.imethod_3(Class869.smethod_26(line_0.method_9()));
			interface25_0.LineStyle.imethod_4(Class869.smethod_28(line_0.method_17()));
			interface25_0.LineStyle.imethod_8(Class869.smethod_27(line_0.method_15()));
			interface25_0.LineStyle.imethod_6(Class869.smethod_26(line_0.method_11()));
			interface25_0.LineStyle.imethod_7(Class869.smethod_28(line_0.method_19()));
			if (line_0.GradientFill != null)
			{
				method_44(line_0.GradientFill, interface25_0.GradientFill);
			}
		}
		else
		{
			interface25_0.LineStyle.DashStyle = Class869.smethod_21(line_0.Style);
			interface25_0.LineStyle.Width = Class869.smethod_22(line_0.Weight);
		}
	}

	private void method_42(Area area_0, Interface8 interface8_0)
	{
		if (area_0 == null)
		{
			return;
		}
		interface8_0.Formatting = Class869.smethod_12(area_0.Formatting);
		if (area_0.Formatting == FormattingType.Custom)
		{
			if (!area_0.BackgroundColor.IsEmpty)
			{
				interface8_0.BackgroundColor = method_49(area_0.BackgroundColor, area_0.method_3());
			}
			if (!area_0.ForegroundColor.IsEmpty)
			{
				interface8_0.ForegroundColor = method_49(area_0.ForegroundColor, area_0.method_3());
			}
		}
		if (area_0.method_0())
		{
			method_43(area_0.FillFormat, interface8_0);
		}
		interface8_0.InvertIfNegative = area_0.InvertIfNegative;
	}

	private void method_43(FillFormat fillFormat_0, Interface8 interface8_0)
	{
		Interface34 fillFormat = interface8_0.FillFormat;
		switch (fillFormat_0.SetType)
		{
		case FormatSetType.IsGradientSet:
			interface8_0.Formatting = Enum71.const_3;
			method_44(fillFormat_0.GradientFill, fillFormat.GradientFill);
			break;
		case FormatSetType.IsTextureSet:
		{
			interface8_0.Formatting = Enum71.const_4;
			byte[] imageData = fillFormat_0.TextureFill.ImageData;
			MemoryStream stream = new MemoryStream(imageData);
			Image image_ = Image.FromStream(stream);
			method_45(fillFormat_0, fillFormat_0.TextureFill, fillFormat.TextureFill);
			fillFormat.TextureFill.imethod_0(image_);
			break;
		}
		case FormatSetType.IsPatternSet:
		{
			interface8_0.Formatting = Enum71.const_5;
			Color color_ = method_50(fillFormat_0.method_0().ForegroundColor);
			Color color_2 = method_50(fillFormat_0.method_0().BackgroundColor);
			fillFormat.imethod_0(color_, color_2, Class869.smethod_1(fillFormat_0.Pattern));
			break;
		}
		}
	}

	private void method_44(GradientFill gradientFill_0, Interface35 interface35_0)
	{
		interface35_0.Angle = gradientFill_0.Angle;
		interface35_0.imethod_0(Class869.smethod_30(gradientFill_0.FillType));
		interface35_0.imethod_1(Class869.smethod_31(gradientFill_0.DirectionType));
		for (int i = 0; i < gradientFill_0.GradientStops.Count; i++)
		{
			GradientStop gradientStop = gradientFill_0.GradientStops[i];
			int num = gradientStop.internalColor_0.method_7(workbook_0);
			int red = num & 0xFF;
			int green = (num & 0xFF00) >> 8;
			int blue = (num & 0xFF0000) >> 16;
			Color.FromArgb(gradientStop.method_2() * 255 / 100, red, green, blue);
			red = gradientStop.CellsColor.Color.R;
			green = gradientStop.CellsColor.Color.G;
			blue = gradientStop.CellsColor.Color.B;
			Color color_ = Color.FromArgb(gradientStop.method_2() * 255 / 100, red, green, blue);
			interface35_0.GradientStops.Add(color_, (float)gradientStop.Position);
		}
	}

	private void method_45(FillFormat fillFormat_0, TextureFill textureFill_0, Interface40 interface40_0)
	{
		interface40_0.Transparency = fillFormat_0.method_0().method_3();
		if (textureFill_0 != null)
		{
			interface40_0.imethod_1(textureFill_0.method_3());
			if (textureFill_0.method_3())
			{
				interface40_0.OffsetX = textureFill_0.TilePicOption.OffsetX;
				interface40_0.OffsetY = textureFill_0.TilePicOption.OffsetY;
				interface40_0.ScaleX = textureFill_0.TilePicOption.ScaleX;
				interface40_0.ScaleY = textureFill_0.TilePicOption.ScaleY;
				interface40_0.imethod_2(Class869.smethod_32(textureFill_0.TilePicOption.AlignmentType));
				interface40_0.MirrorType = Class869.smethod_33(textureFill_0.TilePicOption.MirrorType);
			}
			else
			{
				interface40_0.imethod_3(Class869.smethod_34(textureFill_0.PicFormatOption.Type));
				interface40_0.imethod_4(textureFill_0.PicFormatOption.Left);
				interface40_0.imethod_5(textureFill_0.PicFormatOption.Right);
				interface40_0.imethod_6(textureFill_0.PicFormatOption.Top);
				interface40_0.imethod_7(textureFill_0.PicFormatOption.Bottom);
				interface40_0.imethod_8(textureFill_0.PicFormatOption.Scale);
			}
		}
	}

	private void method_46(Interface28 interface28_0, Series series_0)
	{
		foreach (Trendline trendLine in series_0.TrendLines)
		{
			Enum88 @enum = Class869.smethod_18(trendLine.Type);
			int int_ = interface28_0.imethod_3().Add(@enum);
			Interface32 @interface = interface28_0.imethod_3()[int_];
			@interface.IsNameAuto = trendLine.IsNameAuto;
			if (!trendLine.IsNameAuto)
			{
				@interface.Name = trendLine.Name;
			}
			method_41(trendLine, @interface.Border);
			switch (@enum)
			{
			case Enum88.const_4:
				@interface.Order = trendLine.Order;
				break;
			case Enum88.const_3:
				@interface.Period = trendLine.Period;
				break;
			}
			@interface.Forward = trendLine.Forward;
			@interface.Backward = trendLine.Backward;
			method_29(trendLine.DataLabels, @interface.DataLabels, series_0.Type);
			if (trendLine.method_37())
			{
				@interface.Intercept = trendLine.Intercept;
			}
			@interface.DisplayEquation = trendLine.DisplayEquation;
			@interface.DisplayRSquared = trendLine.DisplayRSquared;
			@interface.imethod_0(trendLine.method_38());
		}
	}

	private void method_47(Floor floor_0, Interface20 interface20_0)
	{
		method_42(floor_0, interface20_0.Area);
		method_41(floor_0.Border, interface20_0.Border);
	}

	private void method_48(Walls walls_0, Interface33 interface33_0)
	{
		method_42(walls_0, interface33_0.Area);
		method_41(walls_0.Border, interface33_0.Border);
	}

	private Color method_49(Color color_0, int int_0)
	{
		return Color.FromArgb(int_0 * 255 / 100, color_0);
	}

	private Color method_50(Color color_0)
	{
		return Color.FromArgb(255, color_0.R, color_0.G, color_0.B);
	}

	private bool method_51(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
		case ChartType.Radar:
		case ChartType.RadarWithDataMarkers:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	~Class870()
	{
		Dispose(bool_4: false);
	}

	public void Dispose()
	{
		Dispose(bool_4: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_4)
	{
		if (bool_3)
		{
			return;
		}
		if (bool_4)
		{
			if (class787_0 != null)
			{
				class787_0.Dispose();
			}
			if (class821_0 != null)
			{
				class821_0.Dispose();
			}
		}
		bool_3 = true;
	}
}
