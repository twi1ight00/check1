using System;
using System.Collections.Generic;
using System.Globalization;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class913
{
	public static void smethod_0(IChartSeries series, Class2038 seriesElementData, ChartDataWorkbook chartDataWorkbook, Class2021 chartPlotElementData, Class892 chartPartDeserializationContext)
	{
		if (seriesElementData == null)
		{
			throw new Exception("seriesElementData must not be null.");
		}
		Class1341 deserializationContext = chartPartDeserializationContext.SlideDeserializationContext.DeserializationContext;
		Class319 pPTXUnsupportedProps = ((ChartSeries)series).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Idx = seriesElementData.Idx.Val;
		series.Order = (int)seriesElementData.Order.Val;
		smethod_8(series, seriesElementData, chartDataWorkbook);
		Class921.smethod_0(series.Format, seriesElementData.SpPr, deserializationContext);
		Class924.smethod_0(series.Marker, seriesElementData.Marker, deserializationContext);
		pPTXUnsupportedProps.PictureOptions = seriesElementData.PictureOptions;
		smethod_1(series, seriesElementData, chartDataWorkbook, deserializationContext);
		if (seriesElementData.InvertIfNegative != null)
		{
			series.InvertIfNegative = seriesElementData.InvertIfNegative.Val;
		}
		if (chartPlotElementData.Smooth != null)
		{
			series.Smooth = chartPlotElementData.Smooth.Val;
		}
		if (seriesElementData.Smooth != null)
		{
			series.Smooth = seriesElementData.Smooth.Val;
		}
		if (seriesElementData.TrendlineList != null)
		{
			Class2129[] trendlineList = seriesElementData.TrendlineList;
			foreach (Class2129 @class in trendlineList)
			{
				ITrendline trendline = series.TrendLines.Add(@class.TrendlineType.Val);
				Class927.smethod_0(trendline, @class, deserializationContext);
			}
		}
		if (seriesElementData is Class2040)
		{
			Class2040 class2 = (Class2040)seriesElementData;
			if (chartPlotElementData is Class2024)
			{
				if (chartPlotElementData.Shape != null)
				{
					series.Bar3DShape = chartPlotElementData.Shape.Val;
				}
				if (class2.Shape != null)
				{
					series.Bar3DShape = class2.Shape.Val;
				}
			}
		}
		if (seriesElementData is Class2043)
		{
			Class2043 class3 = (Class2043)seriesElementData;
			if (class3.Explosion != null)
			{
				series.Explosion = (int)class3.Explosion.Val;
			}
		}
		smethod_4(series, seriesElementData.XVal, Enum166.const_0, chartDataWorkbook);
		smethod_4(series, seriesElementData.YVal, Enum166.const_1, chartDataWorkbook);
		smethod_4(series, seriesElementData.BubbleSize, Enum166.const_2, chartDataWorkbook);
		smethod_4(series, seriesElementData.Val, Enum166.const_3, chartDataWorkbook);
		series.NumberFormatOfValues = ((seriesElementData.Val == null) ? "" : seriesElementData.Val.vmethod_7());
		series.NumberFormatOfXValues = ((seriesElementData.XVal == null) ? "" : seriesElementData.XVal.vmethod_7());
		series.NumberFormatOfYValues = ((seriesElementData.YVal == null) ? "" : seriesElementData.YVal.vmethod_7());
		series.NumberFormatOfBubbleSizes = ((seriesElementData.BubbleSize == null) ? "" : seriesElementData.BubbleSize.vmethod_7());
		if (seriesElementData.DPtList != null)
		{
			Class2071[] dPtList = seriesElementData.DPtList;
			foreach (Class2071 class4 in dPtList)
			{
				Class907.smethod_0(series.DataPoints.GetOrCreateDataPointByIdx(class4.Idx.Val), class4, deserializationContext);
			}
		}
		Class918.smethod_0(series.Labels, chartPlotElementData.DLbls, deserializationContext);
		Class918.smethod_0(series.Labels, seriesElementData.DLbls, deserializationContext);
		pPTXUnsupportedProps.ExtensionList = seriesElementData.ExtLst;
	}

	private static void smethod_1(IChartSeries series, Class2038 seriesElementData, ChartDataWorkbook chartDataWorkbook, Class1341 deserializationContext)
	{
		if (seriesElementData.ErrBarsList != null)
		{
			Class2073[] errBarsList = seriesElementData.ErrBarsList;
			foreach (Class2073 @class in errBarsList)
			{
				if (@class.ErrDir.Val == Enum264.const_1)
				{
					smethod_2(series, @class, chartDataWorkbook, deserializationContext);
				}
				else if (@class.ErrDir.Val == Enum264.const_2)
				{
					smethod_3(series, @class, chartDataWorkbook, deserializationContext);
				}
			}
		}
		else
		{
			if (seriesElementData.ErrBars == null)
			{
				return;
			}
			Class2073 errBars = seriesElementData.ErrBars;
			if (errBars.ErrDir != null)
			{
				if (errBars.ErrDir.Val == Enum264.const_1)
				{
					smethod_2(series, errBars, chartDataWorkbook, deserializationContext);
				}
				else if (errBars.ErrDir.Val == Enum264.const_2)
				{
					smethod_3(series, errBars, chartDataWorkbook, deserializationContext);
				}
			}
			else if (ChartTypeCharacterizer.IsErrorBarsXAllowed(series.Type) && !ChartTypeCharacterizer.IsErrorBarsYAllowed(series.Type))
			{
				smethod_2(series, errBars, chartDataWorkbook, deserializationContext);
			}
			else if (!ChartTypeCharacterizer.IsErrorBarsXAllowed(series.Type) && ChartTypeCharacterizer.IsErrorBarsYAllowed(series.Type))
			{
				smethod_3(series, errBars, chartDataWorkbook, deserializationContext);
			}
			else if ((!ChartTypeCharacterizer.IsErrorBarsXAllowed(series.Type) && !ChartTypeCharacterizer.IsErrorBarsYAllowed(series.Type)) || (ChartTypeCharacterizer.IsErrorBarsXAllowed(series.Type) && ChartTypeCharacterizer.IsErrorBarsYAllowed(series.Type)))
			{
				throw new Exception("illegal situation");
			}
		}
	}

	private static void smethod_2(IChartSeries series, Class2073 errorBarsElementData, ChartDataWorkbook chartDataWorkbook, Class1341 deserializationContext)
	{
		Class236.smethod_0(((ChartSeries)series).ErrorBarsXFormat, errorBarsElementData, deserializationContext);
		if (((ChartSeries)series).ErrorBarsXFormat.ValueType == ErrorBarValueType.Custom)
		{
			smethod_4(series, errorBarsElementData.Minus, Enum166.const_5, chartDataWorkbook);
			smethod_4(series, errorBarsElementData.Plus, Enum166.const_4, chartDataWorkbook);
		}
	}

	private static void smethod_3(IChartSeries series, Class2073 errorBarsElementData, ChartDataWorkbook chartDataWorkbook, Class1341 deserializationContext)
	{
		Class236.smethod_0(((ChartSeries)series).ErrorBarsYFormat, errorBarsElementData, deserializationContext);
		if (((ChartSeries)series).ErrorBarsYFormat.ValueType == ErrorBarValueType.Custom)
		{
			smethod_4(series, errorBarsElementData.Minus, Enum166.const_7, chartDataWorkbook);
			smethod_4(series, errorBarsElementData.Plus, Enum166.const_6, chartDataWorkbook);
		}
	}

	private static void smethod_4(IChartSeries series, Class2340 dataSourceElementData, Enum166 dimension, ChartDataWorkbook chartDataWorkbook)
	{
		if (dataSourceElementData == null)
		{
			return;
		}
		DataSourceType dataSourceType = dataSourceElementData.vmethod_5();
		Class309 pPTXUnsupportedProps = ((ChartDataPointCollection)series.DataPoints).PPTXUnsupportedProps;
		switch (dimension)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum166.const_0:
			series.DataPoints.DataSourceTypeForXValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfXValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_1:
			series.DataPoints.DataSourceTypeForYValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfYValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_2:
			series.DataPoints.DataSourceTypeForBubbleSizes = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfBubbleSizes = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_3:
			series.DataPoints.DataSourceTypeForValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_4:
			((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfErrorBarsXPlusValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_5:
			((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfErrorBarsXMinusValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_6:
			((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfErrorBarsXPlusValues = dataSourceElementData.vmethod_8();
			break;
		case Enum166.const_7:
			((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = dataSourceType;
			pPTXUnsupportedProps.ExtensionListOfErrorBarsYMinusValues = dataSourceElementData.vmethod_8();
			break;
		}
		switch (dataSourceType)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case DataSourceType.Worksheet:
		{
			List<IChartDataCell> list = smethod_7(dataSourceElementData.vmethod_6(), chartDataWorkbook);
			for (int j = 0; j < list.Count; j++)
			{
				smethod_5(series.DataPoints.GetOrCreateDataPointByIdx((uint)j), dimension).AsCell = list[j];
			}
			break;
		}
		case DataSourceType.StringLiterals:
		{
			Class2119 class3 = (Class2119)((Class2341)dataSourceElementData).AxisDataSource.Object;
			Class2121[] ptList2 = class3.PtList;
			foreach (Class2121 class4 in ptList2)
			{
				IBaseChartValue baseChartValue2 = smethod_5(series.DataPoints.GetOrCreateDataPointByIdx(class4.Idx), dimension);
				((IStringOrDoubleChartValue)baseChartValue2).AsLiteralString = class4.V;
			}
			break;
		}
		case DataSourceType.DoubleLiterals:
		{
			Class2096 @class = null;
			if (dataSourceElementData is Class2341)
			{
				@class = (Class2096)((Class2341)dataSourceElementData).AxisDataSource.Object;
			}
			else if (dataSourceElementData is Class2342)
			{
				@class = (Class2096)((Class2342)dataSourceElementData).DataSource.Object;
			}
			Class2099[] ptList = @class.PtList;
			foreach (Class2099 class2 in ptList)
			{
				IBaseChartValue baseChartValue = smethod_5(series.DataPoints.GetOrCreateDataPointByIdx(class2.Idx), dimension);
				if (baseChartValue is IDoubleChartValue)
				{
					((IDoubleChartValue)baseChartValue).AsLiteralDouble = Convert.ToDouble(class2.V, CultureInfo.InvariantCulture);
				}
				else if (baseChartValue is IStringOrDoubleChartValue)
				{
					((IStringOrDoubleChartValue)baseChartValue).AsLiteralDouble = Convert.ToDouble(class2.V, CultureInfo.InvariantCulture);
				}
			}
			break;
		}
		}
	}

	private static ISingleCellChartValue smethod_5(IChartDataPoint dataPoint, Enum166 dimension)
	{
		return dimension switch
		{
			Enum166.const_0 => dataPoint.XValue, 
			Enum166.const_1 => dataPoint.YValue, 
			Enum166.const_2 => dataPoint.BubbleSize, 
			Enum166.const_3 => dataPoint.Value, 
			Enum166.const_4 => ((ChartDataPoint)dataPoint).ErrorBarsCustomValues.XPlus, 
			Enum166.const_5 => ((ChartDataPoint)dataPoint).ErrorBarsCustomValues.XMinus, 
			Enum166.const_6 => ((ChartDataPoint)dataPoint).ErrorBarsCustomValues.YPlus, 
			Enum166.const_7 => ((ChartDataPoint)dataPoint).ErrorBarsCustomValues.YMinus, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private static string smethod_6(IChartSeries series, Enum166 dimension)
	{
		return dimension switch
		{
			Enum166.const_0 => series.NumberFormatOfXValues, 
			Enum166.const_1 => series.NumberFormatOfYValues, 
			Enum166.const_2 => series.NumberFormatOfBubbleSizes, 
			Enum166.const_3 => series.NumberFormatOfValues, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private static List<IChartDataCell> smethod_7(string formula, ChartDataWorkbook chartDataWorkbook)
	{
		List<IChartDataCell> list = new List<IChartDataCell>();
		List<object[]> list2 = chartDataWorkbook.method_6(formula);
		foreach (object[] item in list2)
		{
			string name = (string)item[0];
			ChartDataWorksheet chartDataWorksheet = chartDataWorkbook.Worksheets[name];
			int count = ((List<int>)item[1]).Count;
			for (int i = 0; i < count; i++)
			{
				int row = ((List<int>)item[1])[i];
				int col = ((List<int>)item[2])[i];
				IChartDataCell chartDataCell = chartDataWorksheet.Cells[row, col];
				if (!chartDataCell.IsHidden)
				{
					list.Add(chartDataCell);
				}
			}
		}
		return list;
	}

	private static void smethod_8(IChartSeries series, Class2038 seriesElementData, IChartDataWorkbook chartDataWorkbook)
	{
		Class2114 tx = seriesElementData.Tx;
		string text = "";
		string text2 = null;
		if (tx != null)
		{
			switch (tx.Text.Name)
			{
			case "v":
				text2 = (string)tx.Text.Object;
				break;
			case "strRef":
			{
				Class2120 @class = (Class2120)tx.Text.Object;
				text = @class.F;
				break;
			}
			default:
				throw new Exception("Unknown element \"" + tx.Text.Name + "\"");
			}
		}
		if (text != "")
		{
			series.Name.DataSourceType = DataSourceType.Worksheet;
			smethod_9(series, text, chartDataWorkbook);
		}
		if (text2 != null)
		{
			series.Name.DataSourceType = DataSourceType.StringLiterals;
			series.Name.AsLiteralString = text2;
		}
	}

	public static void smethod_9(IChartSeries series, string seriesNameRefF, IChartDataWorkbook chartDataWorkbook)
	{
		if (!string.IsNullOrEmpty(seriesNameRefF))
		{
			series.Name.AsCells = chartDataWorkbook.GetCellCollection(seriesNameRefF, skipHiddenCells: false);
		}
	}

	internal static bool smethod_10(Class2021 parentChartPlotElementData, Class892 chartPartDeserializationContext)
	{
		List<int> list = Class903.smethod_3(chartPartDeserializationContext);
		int num = 0;
		Class1774[] axIdList = parentChartPlotElementData.AxIdList;
		foreach (Class1774 @class in axIdList)
		{
			if (list.Contains(@class.Val))
			{
				num++;
			}
		}
		bool result = false;
		if (num != 0)
		{
			if (num != parentChartPlotElementData.AxIdList.Length)
			{
				throw new Exception();
			}
			result = true;
		}
		return result;
	}

	public static void smethod_11(IChartSeries series, Class2038 seriesElementData, Class2021 chartPlotElementData, IChartDataWorkbook chartDataWorkbook, Class882 chartPartSerializationContext)
	{
		Class319 pPTXUnsupportedProps = ((ChartSeries)series).PPTXUnsupportedProps;
		Class1346 serializationContext = chartPartSerializationContext.SlideSerializationContext.SerializationContext;
		if (!chartPartSerializationContext.UsedChartSeriesIdxs.ContainsKey(pPTXUnsupportedProps.Idx))
		{
			seriesElementData.Idx.Val = pPTXUnsupportedProps.Idx;
			if (chartPartSerializationContext.MaxChartSeriesIdxUsed < pPTXUnsupportedProps.Idx)
			{
				chartPartSerializationContext.MaxChartSeriesIdxUsed = (int)pPTXUnsupportedProps.Idx;
			}
		}
		else
		{
			pPTXUnsupportedProps.Idx = (uint)(++chartPartSerializationContext.MaxChartSeriesIdxUsed);
			seriesElementData.Idx.Val = pPTXUnsupportedProps.Idx;
		}
		chartPartSerializationContext.UsedChartSeriesIdxs.Add(seriesElementData.Idx.Val, null);
		seriesElementData.Order.Val = (uint)series.Order;
		smethod_12(series, seriesElementData);
		Class921.smethod_1(series.Format, seriesElementData.delegate1630_0, serializationContext);
		Class924.smethod_1(series.Marker, seriesElementData.delegate1991_0, serializationContext);
		if (seriesElementData.delegate384_0 != null)
		{
			seriesElementData.delegate384_0(pPTXUnsupportedProps.PictureOptions);
		}
		if (((ChartSeries)series).ErrorBarsXFormat != null && ((ChartSeries)series).ErrorBarsXFormat.IsVisible)
		{
			Class2073 @class = seriesElementData.delegate1933_0();
			@class.delegate33_0().Val = Enum264.const_1;
			Class236.smethod_1(((ChartSeries)series).ErrorBarsXFormat, @class, serializationContext);
			if (((ChartSeries)series).ErrorBarsXFormat.ValueType == ErrorBarValueType.Custom)
			{
				smethod_13(series, @class.delegate2767_1(), Enum166.const_5, chartDataWorkbook);
				smethod_13(series, @class.delegate2767_0(), Enum166.const_4, chartDataWorkbook);
			}
		}
		if (((ChartSeries)series).ErrorBarsYFormat != null && ((ChartSeries)series).ErrorBarsYFormat.IsVisible)
		{
			Class2073 class2 = seriesElementData.delegate1933_0();
			class2.delegate33_0().Val = Enum264.const_2;
			Class236.smethod_1(((ChartSeries)series).ErrorBarsYFormat, class2, serializationContext);
			if (((ChartSeries)series).ErrorBarsYFormat.ValueType == ErrorBarValueType.Custom)
			{
				smethod_13(series, class2.delegate2767_1(), Enum166.const_7, chartDataWorkbook);
				smethod_13(series, class2.delegate2767_0(), Enum166.const_6, chartDataWorkbook);
			}
		}
		if (seriesElementData.delegate2763_1 != null)
		{
			seriesElementData.delegate2763_1().Val = series.InvertIfNegative;
		}
		if (seriesElementData.delegate2763_0 != null)
		{
			seriesElementData.delegate2763_0().Val = series.Smooth;
		}
		if (series.TrendLines != null)
		{
			foreach (ITrendline trendLine in series.TrendLines)
			{
				Class927.smethod_1(trendLine, seriesElementData.delegate2118_0(), serializationContext);
			}
		}
		if (seriesElementData is Class2040)
		{
			Class2040 class3 = (Class2040)seriesElementData;
			if (series.Bar3DShape != ChartShapeType.NotDefined)
			{
				class3.delegate2072_0().Val = series.Bar3DShape;
			}
		}
		else if (seriesElementData is Class2043)
		{
			Class2043 class4 = (Class2043)seriesElementData;
			if (series.Explosion != 0)
			{
				class4.delegate2136_0().Val = (uint)series.Explosion;
			}
		}
		else if (seriesElementData is Class2041)
		{
			Class2041 class5 = (Class2041)seriesElementData;
			class5.delegate2763_2().Val = series.Type == ChartType.BubbleWith3D;
		}
		Class918.smethod_1(series.Labels, seriesElementData.delegate1920_0, serializationContext);
		if (series.PlotOnSecondAxis && series.Chart.ChartData.UseSecondaryCategories)
		{
			Class906.smethod_5(series.Chart.ChartData.SecondaryCategories, seriesElementData.delegate2765_0);
		}
		else
		{
			Class906.smethod_5(series.Chart.ChartData.Categories, seriesElementData.delegate2765_0);
		}
		if (seriesElementData.delegate2765_1 != null)
		{
			smethod_13(series, seriesElementData.delegate2765_1(), Enum166.const_0, chartDataWorkbook);
		}
		if (seriesElementData.delegate2767_1 != null)
		{
			smethod_13(series, seriesElementData.delegate2767_1(), Enum166.const_1, chartDataWorkbook);
		}
		if (seriesElementData.delegate2767_2 != null)
		{
			smethod_13(series, seriesElementData.delegate2767_2(), Enum166.const_2, chartDataWorkbook);
		}
		if (seriesElementData.delegate2767_0 != null)
		{
			smethod_13(series, seriesElementData.delegate2767_0(), Enum166.const_3, chartDataWorkbook);
		}
		for (int i = 0; i < series.DataPoints.Count; i++)
		{
			Class907.smethod_2(series.DataPoints[i], seriesElementData.delegate1927_0, (uint)i, serializationContext);
		}
		seriesElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	private static void smethod_12(IChartSeries series, Class2038 seriesElementData)
	{
		switch (series.Name.DataSourceType)
		{
		default:
			throw new Exception();
		case DataSourceType.Worksheet:
		{
			if (series.Name.AsCells.Count == 0)
			{
				break;
			}
			Class2114 @class = seriesElementData.delegate2069_0();
			Class2120 class2 = (Class2120)@class.delegate2773_0("strRef").Object;
			class2.F = series.Name.GetCellsAddressInWorkbook();
			Class2119 class3 = class2.delegate2085_0();
			IChartCellCollection asCells = series.Name.AsCells;
			class3.delegate2136_0().Val = (uint)asCells.Count;
			for (int i = 0; i < asCells.Count; i++)
			{
				if (asCells[i].Value != null)
				{
					Class2121 class4 = class3.delegate2091_0();
					class4.Idx = (uint)i;
					class4.V = Convert.ToString(asCells[i].Value, CultureInfo.InvariantCulture);
				}
			}
			break;
		}
		case DataSourceType.StringLiterals:
			if (series.Name.AsLiteralString != null)
			{
				Class2114 @class = seriesElementData.delegate2069_0();
				@class.Text = new Class2605("v", series.Name.AsLiteralString);
			}
			break;
		}
	}

	private static void smethod_13(IChartSeries series, Class2340 dataSourceElementData, Enum166 dimension, IChartDataWorkbook chartDataWorkbook)
	{
		if (dataSourceElementData == null)
		{
			return;
		}
		Class309 pPTXUnsupportedProps;
		switch ((DataSourceType)(dimension switch
		{
			Enum166.const_0 => (int)series.DataPoints.DataSourceTypeForXValues, 
			Enum166.const_1 => (int)series.DataPoints.DataSourceTypeForYValues, 
			Enum166.const_2 => (int)series.DataPoints.DataSourceTypeForBubbleSizes, 
			Enum166.const_3 => (int)series.DataPoints.DataSourceTypeForValues, 
			Enum166.const_4 => (int)((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues, 
			Enum166.const_5 => (int)((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues, 
			Enum166.const_6 => (int)((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues, 
			Enum166.const_7 => (int)((ChartDataPointCollection)series.DataPoints).DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues, 
			_ => throw new ArgumentOutOfRangeException(), 
		}))
		{
		default:
			throw new ArgumentOutOfRangeException();
		case DataSourceType.Worksheet:
		{
			IChartCellCollection cellCollection = chartDataWorkbook.GetCellCollection("", skipHiddenCells: true);
			foreach (IChartDataPoint dataPoint in series.DataPoints)
			{
				ISingleCellChartValue singleCellChartValue = smethod_5(dataPoint, dimension);
				if (singleCellChartValue.AsCell != null)
				{
					cellCollection.Add(singleCellChartValue.AsCell);
				}
			}
			if (dataSourceElementData is Class2341)
			{
				bool flag = true;
				string[] array = new string[series.DataPoints.Count];
				for (int i = 0; i < series.DataPoints.Count; i++)
				{
					ISingleCellChartValue singleCellChartValue2 = smethod_5(series.DataPoints[i], dimension);
					if (singleCellChartValue2.Data != null)
					{
						array[i] = Convert.ToString(singleCellChartValue2.AsCell.Value, CultureInfo.InvariantCulture);
						flag &= double.TryParse(array[i], NumberStyles.Any, CultureInfo.InvariantCulture, out var _);
					}
				}
				if (flag)
				{
					smethod_14(series, cellCollection, (Class2098)((Class2341)dataSourceElementData).delegate2773_0("numRef").Object, dimension);
				}
				else
				{
					smethod_15(cellCollection, (Class2120)((Class2341)dataSourceElementData).delegate2773_0("strRef").Object);
				}
			}
			else
			{
				if (!(dataSourceElementData is Class2342))
				{
					throw new Exception();
				}
				smethod_14(series, cellCollection, (Class2098)((Class2342)dataSourceElementData).delegate2773_0("numRef").Object, dimension);
			}
			goto IL_0309;
		}
		case DataSourceType.StringLiterals:
			if (dataSourceElementData is Class2341)
			{
				smethod_17(series.DataPoints, (Class2119)((Class2341)dataSourceElementData).delegate2773_0("strLit").Object, dimension);
				goto IL_0309;
			}
			throw new Exception();
		case DataSourceType.DoubleLiterals:
			{
				if (dataSourceElementData is Class2341)
				{
					smethod_16(series.DataPoints, (Class2096)((Class2341)dataSourceElementData).delegate2773_0("numLit").Object, dimension);
				}
				else
				{
					if (!(dataSourceElementData is Class2342))
					{
						throw new Exception();
					}
					smethod_16(series.DataPoints, (Class2096)((Class2342)dataSourceElementData).delegate2773_0("numLit").Object, dimension);
				}
				goto IL_0309;
			}
			IL_0309:
			pPTXUnsupportedProps = ((ChartDataPointCollection)series.DataPoints).PPTXUnsupportedProps;
			switch (dimension)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case Enum166.const_0:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfXValues);
				break;
			case Enum166.const_1:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfYValues);
				break;
			case Enum166.const_2:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfBubbleSizes);
				break;
			case Enum166.const_3:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfValues);
				break;
			case Enum166.const_4:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfErrorBarsXPlusValues);
				break;
			case Enum166.const_5:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfErrorBarsXMinusValues);
				break;
			case Enum166.const_6:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfErrorBarsYPlusValues);
				break;
			case Enum166.const_7:
				dataSourceElementData.vmethod_9(pPTXUnsupportedProps.ExtensionListOfErrorBarsYMinusValues);
				break;
			}
			break;
		}
	}

	private static void smethod_14(IChartSeries series, IChartCellCollection dataPointsCells, Class2098 numRefElementData, Enum166 dimension)
	{
		numRefElementData.F = dataPointsCells.GetCellsAddress();
		Class2096 @class = numRefElementData.delegate2006_0();
		if (dataPointsCells.Count > 0)
		{
			if (dataPointsCells[0].CustomNumberFormat.Trim() != "")
			{
				@class.FormatCode = dataPointsCells[0].CustomNumberFormat;
			}
			else
			{
				@class.FormatCode = Class903.smethod_7(dataPointsCells[0].PresetNumberFormat);
			}
		}
		@class.delegate2136_0().Val = (uint)dataPointsCells.Count;
		for (int i = 0; i < dataPointsCells.Count; i++)
		{
			if (dataPointsCells[i].Value == null)
			{
				continue;
			}
			Class2099 class2 = @class.delegate2015_0();
			class2.Idx = (uint)i;
			string text = Convert.ToString(dataPointsCells[i].Value, CultureInfo.InvariantCulture);
			if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var _))
			{
				class2.V = text;
				continue;
			}
			if (dataPointsCells[i].CustomNumberFormat.Trim() != "")
			{
				class2.FormatCode = dataPointsCells[i].CustomNumberFormat;
			}
			else
			{
				class2.FormatCode = Class903.smethod_7(dataPointsCells[i].PresetNumberFormat);
			}
			class2.V = "0";
		}
	}

	private static void smethod_15(IChartCellCollection dataPointsCells, Class2120 strRefElementData)
	{
		strRefElementData.F = dataPointsCells.GetCellsAddress();
		Class2119 @class = strRefElementData.delegate2085_0();
		@class.delegate2136_0().Val = (uint)dataPointsCells.Count;
		for (int i = 0; i < dataPointsCells.Count; i++)
		{
			if (dataPointsCells[i].Value != null)
			{
				Class2121 class2 = @class.delegate2091_0();
				class2.Idx = (uint)i;
				class2.V = Convert.ToString(dataPointsCells[i].Value, CultureInfo.InvariantCulture);
			}
		}
	}

	private static void smethod_16(IChartDataPointCollection dataPoints, Class2096 numLitElementData, Enum166 dimension)
	{
		numLitElementData.FormatCode = "General";
		numLitElementData.delegate2136_0().Val = (uint)dataPoints.Count;
		for (int i = 0; i < dataPoints.Count; i++)
		{
			ISingleCellChartValue singleCellChartValue = smethod_5(dataPoints[i], dimension);
			if (singleCellChartValue.Data != null)
			{
				Class2099 @class = numLitElementData.delegate2015_0();
				@class.Idx = (uint)i;
				@class.V = Convert.ToString(singleCellChartValue.Data, CultureInfo.InvariantCulture);
			}
		}
	}

	private static void smethod_17(IChartDataPointCollection dataPoints, Class2119 strLitElementData, Enum166 dimension)
	{
		strLitElementData.delegate2136_0().Val = (uint)dataPoints.Count;
		for (int i = 0; i < dataPoints.Count; i++)
		{
			ISingleCellChartValue singleCellChartValue = smethod_5(dataPoints[i], dimension);
			if (singleCellChartValue.Data != null)
			{
				Class2121 @class = strLitElementData.delegate2091_0();
				@class.Idx = (uint)i;
				@class.V = Convert.ToString(singleCellChartValue.Data, CultureInfo.InvariantCulture);
			}
		}
	}
}
