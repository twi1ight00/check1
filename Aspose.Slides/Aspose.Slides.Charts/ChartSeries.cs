using System;
using ns16;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class ChartSeries : IPresentationComponent, ISlideComponent, IChartComponent, IChartSeries
{
	private Chart chart_0;

	private Format format_0;

	private ChartType chartType_0;

	private int int_0;

	private Marker marker_0;

	private DataLabelCollection dataLabelCollection_0;

	private bool bool_0;

	private int int_1;

	private string string_0 = "";

	internal ushort ushort_0;

	private ChartShapeType chartShapeType_0;

	private string string_1 = "";

	private string string_2 = "";

	private string string_3 = "";

	private string string_4 = "";

	private TrendlineCollection trendlineCollection_0;

	private bool bool_1 = true;

	private bool bool_2;

	private LegendEntryProperties legendEntryProperties_0;

	private StringChartValue stringChartValue_0;

	private ChartSeriesGroup chartSeriesGroup_0;

	private readonly ChartDataPointCollection chartDataPointCollection_0;

	private readonly Class319 class319_0;

	private readonly ErrorBarsFormat errorBarsFormat_0;

	private readonly ErrorBarsFormat errorBarsFormat_1;

	internal Class319 PPTXUnsupportedProps => class319_0;

	public IChart Chart => chart_0;

	[Obsolete("Use Marker property instead. Property will be removed after 01.09.2013.")]
	public IFormat MarkerFill => Marker.Format;

	public int Explosion
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				method_1();
			}
		}
	}

	public bool Smooth
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				method_1();
			}
		}
	}

	[Obsolete("Use Marker property instead. Property will be removed after 01.09.2013.")]
	public int MarkerSize
	{
		get
		{
			return Marker.Size;
		}
		set
		{
			Marker.Size = value;
		}
	}

	[Obsolete("Use Marker property instead. Property will be removed after 01.09.2013.")]
	public MarkerStyleType MarkerSymbol
	{
		get
		{
			return Marker.Symbol;
		}
		set
		{
			Marker.Symbol = value;
		}
	}

	[Obsolete("Use Name property instead. Property will be removed after 01.09.2013.")]
	public IChartCellCollection NameCells => Name.AsCells;

	public IStringChartValue Name => stringChartValue_0;

	public IChartDataPointCollection DataPoints => chartDataPointCollection_0;

	public ChartType Type
	{
		get
		{
			return chartType_0;
		}
		set
		{
			if (value == ChartType.SeriesOfMixedTypes)
			{
				throw new InvalidOperationException("It's meaningless to assign ChartType.SeriesOfMixedTypes value to ChartSeries.Type.");
			}
			if (chartType_0 != value)
			{
				if (value == ChartType.ExplodedPie || value == ChartType.ExplodedPie3D || value == ChartType.ExplodedDoughnut)
				{
					int_1 = 25;
				}
				chartType_0 = value;
				method_2();
				method_0();
			}
		}
	}

	public bool PlotOnSecondAxis
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			method_0();
		}
	}

	public IChartSeriesGroup ParentSeriesGroup => chartSeriesGroup_0;

	public IFormat Format => format_0;

	public int Order
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public IDataLabelCollection Labels => dataLabelCollection_0;

	public ITrendlineCollection TrendLines
	{
		get
		{
			if (!ChartTypeCharacterizer.HasSeriesTrendLines(chartType_0))
			{
				return null;
			}
			return trendlineCollection_0;
		}
	}

	public IErrorBarsFormat ErrorBarsXFormat
	{
		get
		{
			if (!ChartTypeCharacterizer.IsErrorBarsXAllowed(chartType_0))
			{
				return null;
			}
			return errorBarsFormat_0;
		}
	}

	public IErrorBarsFormat ErrorBarsYFormat
	{
		get
		{
			if (!ChartTypeCharacterizer.IsErrorBarsYAllowed(chartType_0))
			{
				return null;
			}
			return errorBarsFormat_1;
		}
	}

	internal LegendEntryProperties LegendEntryProperties
	{
		get
		{
			if (legendEntryProperties_0 == null)
			{
				legendEntryProperties_0 = new LegendEntryProperties(chart_0);
			}
			return legendEntryProperties_0;
		}
	}

	public string NumberFormatOfValues
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string NumberFormatOfXValues
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string NumberFormatOfYValues
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string NumberFormatOfBubbleSizes
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public IMarker Marker => marker_0;

	public ChartShapeType Bar3DShape
	{
		get
		{
			if (ChartTypeCharacterizer.IsBar3DChart(Type))
			{
				return chartShapeType_0;
			}
			return ChartShapeType.NotDefined;
		}
		set
		{
			if (ChartTypeCharacterizer.IsBar3DChart(Type))
			{
				if (chartShapeType_0 != value)
				{
					ChartShapeType chartShapeType = chartShapeType_0;
					chartShapeType_0 = value;
					if ((chartShapeType != ChartShapeType.Cone || value != ChartShapeType.ConeToMax) && (chartShapeType != ChartShapeType.ConeToMax || value != ChartShapeType.Cone) && (chartShapeType != ChartShapeType.Pyramid || value != ChartShapeType.PyramidToMaximum) && (chartShapeType != ChartShapeType.PyramidToMaximum || value != ChartShapeType.Pyramid))
					{
						method_1();
					}
				}
				return;
			}
			throw new InvalidOperationException("Not applicable for non-Bar3dChart series type.");
		}
	}

	public bool InvertIfNegative
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal bool IsHiddenPieSeries
	{
		get
		{
			if (Type != ChartType.Pie && Type != ChartType.Pie3D)
			{
				return false;
			}
			if (chartSeriesGroup_0.Series.Count == 1)
			{
				return false;
			}
			return chartSeriesGroup_0.Series[0] != this;
		}
	}

	public bool HasUpDownBars => chartSeriesGroup_0.UpDownBars.HasUpDownBars;

	internal bool HasDropLines => chartSeriesGroup_0.HasDropLines;

	internal bool HasHiLowLines => chartSeriesGroup_0.HasHiLowLines;

	public int GapWidth => chartSeriesGroup_0.GapWidth;

	public int GapDepth => chartSeriesGroup_0.GapDepth;

	internal ushort FirstSliceAngle => chartSeriesGroup_0.FirstSliceAngle;

	internal byte DoughnutHoleSize => chartSeriesGroup_0.DoughnutHoleSize;

	public sbyte Overlap => chartSeriesGroup_0.Overlap;

	internal ushort SecondPieSize => chartSeriesGroup_0.SecondPieSize;

	public bool HasSeriesLines => chartSeriesGroup_0.HasSeriesLines;

	internal bool ShowNegativeBubbles => chartSeriesGroup_0.ShowNegativeBubbles;

	internal Enum266 BubbleSizeRepresentation => chartSeriesGroup_0.BubbleSizeRepresentation;

	internal double OfPieSplitPosition => chartSeriesGroup_0.OfPieSplitPosition;

	internal Enum270 OfPieSplitType => chartSeriesGroup_0.OfPieSplitType;

	public bool IsColorVaried => chartSeriesGroup_0.IsColorVaried;

	internal bool Wireframe => chartSeriesGroup_0.Wireframe;

	internal int BubbleSizeScale => chartSeriesGroup_0.BubbleSizeScale;

	IChartComponent IChartSeries.AsIChartComponent => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (chart_0 == null)
			{
				return null;
			}
			return chart_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (chart_0 == null)
			{
				return null;
			}
			return chart_0.Presentation;
		}
	}

	internal ChartSeries(Chart parent, ChartType type)
	{
		chart_0 = parent;
		marker_0 = new Marker(this);
		trendlineCollection_0 = new TrendlineCollection(this);
		stringChartValue_0 = new StringChartValue(parent, new Class1035(), centralizedTypeChangingRestriction: false);
		chartDataPointCollection_0 = new ChartDataPointCollection(this);
		dataLabelCollection_0 = new DataLabelCollection(this);
		errorBarsFormat_0 = new ErrorBarsFormat(this);
		errorBarsFormat_1 = new ErrorBarsFormat(this);
		class319_0 = new Class319();
		int num = -1;
		foreach (ChartSeries item in parent.ChartData.Series)
		{
			if (item.Order > num)
			{
				num = item.Order;
			}
		}
		int_0 = num + 1;
		format_0 = new Format(parent);
		((LineFillFormat)format_0.Line.FillFormat).FillTypeChanged += method_1;
		switch (type)
		{
		case ChartType.SeriesOfMixedTypes:
			throw new InvalidOperationException("It's meaningless to create series of ChartType.SeriesOfMixedTypes type.");
		case ChartType.ExplodedPie:
		case ChartType.ExplodedPie3D:
		case ChartType.ExplodedDoughnut:
			int_1 = 25;
			break;
		}
		chartType_0 = type;
		method_2();
	}

	internal void method_0()
	{
		((AxesManager)chart_0.Axes).method_1();
		((Class13)chart_0.ChartData.SeriesGroups).method_0(this);
	}

	internal void method_1()
	{
		ChartType chartType = chartType_0;
		if (ChartTypeCharacterizer.IsBar3DChart(chartType_0))
		{
			switch (chartType_0)
			{
			case ChartType.ClusteredColumn3D:
			case ChartType.ClusteredCylinder:
			case ChartType.ClusteredCone:
			case ChartType.ClusteredPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.ClusteredColumn3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.ClusteredCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.ClusteredCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.ClusteredPyramid;
					break;
				}
				break;
			case ChartType.StackedColumn3D:
			case ChartType.StackedCylinder:
			case ChartType.StackedCone:
			case ChartType.StackedPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.StackedColumn3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.StackedCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.StackedCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.StackedPyramid;
					break;
				}
				break;
			case ChartType.PercentsStackedColumn3D:
			case ChartType.PercentsStackedCylinder:
			case ChartType.PercentsStackedCone:
			case ChartType.PercentsStackedPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.PercentsStackedColumn3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.PercentsStackedCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.PercentsStackedCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.PercentsStackedPyramid;
					break;
				}
				break;
			case ChartType.Column3D:
			case ChartType.Cylinder3D:
			case ChartType.Cone3D:
			case ChartType.Pyramid3D:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.Column3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.Cone3D;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.Cylinder3D;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.Pyramid3D;
					break;
				}
				break;
			default:
				throw new Exception();
			case ChartType.ClusteredBar3D:
			case ChartType.ClusteredHorizontalCylinder:
			case ChartType.ClusteredHorizontalCone:
			case ChartType.ClusteredHorizontalPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.ClusteredBar3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.ClusteredHorizontalCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.ClusteredHorizontalCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.ClusteredHorizontalPyramid;
					break;
				}
				break;
			case ChartType.StackedBar3D:
			case ChartType.StackedHorizontalCylinder:
			case ChartType.StackedHorizontalCone:
			case ChartType.StackedHorizontalPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.StackedBar3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.StackedHorizontalCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.StackedHorizontalCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.StackedHorizontalPyramid;
					break;
				}
				break;
			case ChartType.PercentsStackedBar3D:
			case ChartType.PercentsStackedHorizontalCylinder:
			case ChartType.PercentsStackedHorizontalCone:
			case ChartType.PercentsStackedHorizontalPyramid:
				switch (chartShapeType_0)
				{
				case ChartShapeType.Box:
					chartType_0 = ChartType.PercentsStackedBar3D;
					break;
				case ChartShapeType.Cone:
				case ChartShapeType.ConeToMax:
					chartType_0 = ChartType.PercentsStackedHorizontalCone;
					break;
				case ChartShapeType.Cylinder:
					chartType_0 = ChartType.PercentsStackedHorizontalCylinder;
					break;
				case ChartShapeType.Pyramid:
				case ChartShapeType.PyramidToMaximum:
					chartType_0 = ChartType.PercentsStackedHorizontalPyramid;
					break;
				}
				break;
			}
		}
		else
		{
			switch (chartType_0)
			{
			case ChartType.Doughnut:
			case ChartType.ExplodedDoughnut:
				chartType_0 = ((Explosion == 0) ? ChartType.Doughnut : ChartType.ExplodedDoughnut);
				break;
			case ChartType.Radar:
			case ChartType.RadarWithMarkers:
			{
				bool flag = Marker.Symbol != MarkerStyleType.None;
				chartType_0 = (flag ? ChartType.RadarWithMarkers : ChartType.Radar);
				break;
			}
			case ChartType.ScatterWithMarkers:
			case ChartType.ScatterWithSmoothLinesAndMarkers:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLinesAndMarkers:
			case ChartType.ScatterWithStraightLines:
			{
				bool flag5 = Marker.Symbol != MarkerStyleType.None;
				bool flag6 = Format.Line.FillFormat.FillType == FillType.NoFill;
				bool smooth = Smooth;
				if (flag5)
				{
					if (flag6)
					{
						chartType_0 = ChartType.ScatterWithMarkers;
					}
					else if (smooth)
					{
						chartType_0 = ChartType.ScatterWithSmoothLinesAndMarkers;
					}
					else
					{
						chartType_0 = ChartType.ScatterWithStraightLinesAndMarkers;
					}
				}
				else if (smooth)
				{
					chartType_0 = ChartType.ScatterWithSmoothLines;
				}
				else
				{
					chartType_0 = ChartType.ScatterWithStraightLines;
				}
				break;
			}
			case ChartType.Line:
			case ChartType.LineWithMarkers:
			{
				bool flag2 = Marker.Symbol != MarkerStyleType.None;
				chartType_0 = (flag2 ? ChartType.LineWithMarkers : ChartType.Line);
				break;
			}
			case ChartType.StackedLine:
			case ChartType.StackedLineWithMarkers:
			{
				bool flag4 = Marker.Symbol != MarkerStyleType.None;
				chartType_0 = (flag4 ? ChartType.StackedLineWithMarkers : ChartType.StackedLine);
				break;
			}
			case ChartType.PercentsStackedLine:
			case ChartType.PercentsStackedLineWithMarkers:
			{
				bool flag3 = Marker.Symbol != MarkerStyleType.None;
				chartType_0 = (flag3 ? ChartType.PercentsStackedLineWithMarkers : ChartType.PercentsStackedLine);
				break;
			}
			case ChartType.Pie:
			case ChartType.ExplodedPie:
				chartType_0 = ((Explosion == 0) ? ChartType.Pie : ChartType.ExplodedPie);
				break;
			case ChartType.Pie3D:
			case ChartType.ExplodedPie3D:
				chartType_0 = ((Explosion == 0) ? ChartType.Pie3D : ChartType.ExplodedPie3D);
				break;
			}
		}
		if (chartType != chartType_0)
		{
			method_0();
		}
	}

	private void method_2()
	{
		if (ChartTypeCharacterizer.IsBar3DChart(chartType_0))
		{
			switch (chartType_0)
			{
			default:
				throw new ArgumentException();
			case ChartType.ClusteredColumn3D:
			case ChartType.StackedColumn3D:
			case ChartType.PercentsStackedColumn3D:
			case ChartType.Column3D:
			case ChartType.ClusteredBar3D:
			case ChartType.StackedBar3D:
			case ChartType.PercentsStackedBar3D:
				chartShapeType_0 = ChartShapeType.Box;
				break;
			case ChartType.ClusteredCylinder:
			case ChartType.StackedCylinder:
			case ChartType.PercentsStackedCylinder:
			case ChartType.Cylinder3D:
			case ChartType.ClusteredHorizontalCylinder:
			case ChartType.StackedHorizontalCylinder:
			case ChartType.PercentsStackedHorizontalCylinder:
				chartShapeType_0 = ChartShapeType.Cylinder;
				break;
			case ChartType.ClusteredCone:
			case ChartType.StackedCone:
			case ChartType.PercentsStackedCone:
			case ChartType.Cone3D:
			case ChartType.ClusteredHorizontalCone:
			case ChartType.StackedHorizontalCone:
			case ChartType.PercentsStackedHorizontalCone:
				chartShapeType_0 = ChartShapeType.Cone;
				break;
			case ChartType.ClusteredPyramid:
			case ChartType.StackedPyramid:
			case ChartType.PercentsStackedPyramid:
			case ChartType.Pyramid3D:
			case ChartType.ClusteredHorizontalPyramid:
			case ChartType.StackedHorizontalPyramid:
			case ChartType.PercentsStackedHorizontalPyramid:
				chartShapeType_0 = ChartShapeType.Pyramid;
				break;
			}
			return;
		}
		if ((chartType_0 == ChartType.Line || chartType_0 == ChartType.StackedLine || chartType_0 == ChartType.PercentsStackedLine || chartType_0 == ChartType.ScatterWithSmoothLines || chartType_0 == ChartType.ScatterWithStraightLines || chartType_0 == ChartType.Radar) && marker_0.Symbol == MarkerStyleType.NotDefined)
		{
			marker_0.markerStyleType_0 = MarkerStyleType.None;
		}
		else if (chartType_0 == ChartType.ScatterWithSmoothLinesAndMarkers || chartType_0 == ChartType.ScatterWithStraightLinesAndMarkers || chartType_0 == ChartType.ScatterWithMarkers || chartType_0 == ChartType.RadarWithMarkers || chartType_0 == ChartType.LineWithMarkers || chartType_0 == ChartType.PercentsStackedLineWithMarkers || chartType_0 == ChartType.StackedLineWithMarkers)
		{
			marker_0.markerStyleType_0 = MarkerStyleType.NotDefined;
		}
		if (chartType_0 != ChartType.ScatterWithSmoothLines && chartType_0 != ChartType.ScatterWithSmoothLinesAndMarkers)
		{
			if (chartType_0 == ChartType.ScatterWithStraightLines || chartType_0 == ChartType.ScatterWithStraightLinesAndMarkers)
			{
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
		}
		if (chartType_0 == ChartType.ScatterWithMarkers)
		{
			((LineFillFormat)Format.Line.FillFormat).fillType_0 = FillType.NoFill;
		}
		else if (Format.Line.FillFormat.FillType == FillType.NoFill)
		{
			((LineFillFormat)Format.Line.FillFormat).fillType_0 = FillType.NotDefined;
		}
		if (chartType_0 == ChartType.Pie || chartType_0 == ChartType.Pie3D || chartType_0 == ChartType.Doughnut)
		{
			int_1 = 0;
		}
	}

	internal void method_3(bool value)
	{
		bool_2 = value;
	}

	internal void method_4(ChartSeriesGroup parentSeriesGroup)
	{
		chartSeriesGroup_0 = parentSeriesGroup;
	}
}
