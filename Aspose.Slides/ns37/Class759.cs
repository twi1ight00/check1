using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class759 : Interface21
{
	private Class740 class740_0;

	private Class750 class750_0;

	private Class752 class752_0;

	private Class752 class752_1;

	private Class755 class755_0;

	private Class741 class741_0;

	private Class756 class756_0;

	private string string_0;

	private bool bool_0;

	private Class747 class747_0;

	private bool bool_1;

	private Class762 class762_0;

	private ChartType chartType_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private Class755 class755_1;

	private Class755 class755_2;

	private Class755 class755_3;

	private Class746 class746_0;

	private Class746 class746_1;

	private bool bool_6;

	private bool bool_7 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3 = 50;

	private int int_4 = 75;

	private bool bool_8;

	private Class755 class755_4;

	private int int_5 = 100;

	private bool bool_9;

	private Enum149 enum149_0;

	private int int_6;

	private ChartType chartType_1;

	private ChartShapeType chartShapeType_0;

	private Class757 class757_0;

	private Class748 class748_0;

	private int int_7;

	private int int_8;

	internal Size size_0 = new Size(0, 0);

	private bool bool_10;

	internal Class748 VirtualPointInternal => class748_0;

	public Interface12 VirtualPoint => class748_0;

	internal Class740 Chart
	{
		get
		{
			return class740_0;
		}
		set
		{
			class740_0 = value;
		}
	}

	internal Class750 DataLabelsInternal => class750_0;

	public Interface13 DataLabels => class750_0;

	internal Class752 YErrorBarInternal
	{
		get
		{
			if (class752_0 == null)
			{
				class752_0 = new Class752(class740_0, this);
			}
			return class752_0;
		}
	}

	public Interface15 YErrorBar
	{
		get
		{
			if (class752_0 == null)
			{
				class752_0 = new Class752(class740_0, this);
			}
			return class752_0;
		}
	}

	internal Class752 XErrorBarInternal
	{
		get
		{
			if (class752_1 == null)
			{
				class752_1 = new Class752(class740_0, this);
			}
			class752_1.YDirection = false;
			return class752_1;
		}
	}

	public Interface15 XErrorBar
	{
		get
		{
			if (class752_1 == null)
			{
				class752_1 = new Class752(class740_0, this);
			}
			class752_1.YDirection = false;
			return class752_1;
		}
	}

	internal Class755 LineInternal => class755_0;

	public Interface18 Line => class755_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal Class756 MarkerInternal => class756_0;

	public Interface19 Marker => class756_0;

	public string Name
	{
		get
		{
			if (string_0 == null)
			{
				return "Series" + (Index + 1);
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool PlotOnSecondAxis
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal Class747 PointsInternal => class747_0;

	public Interface11 Points => class747_0;

	public bool Smooth
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

	internal Class762 TrendlinesInternal => class762_0;

	public Interface22 Trendlines => class762_0;

	public ChartType Type
	{
		get
		{
			return chartType_0;
		}
		set
		{
			chartType_0 = value;
		}
	}

	public ChartShapeType BarShape
	{
		get
		{
			return chartShapeType_0;
		}
		set
		{
			chartShapeType_0 = value;
		}
	}

	public bool IsColorVaried
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
			bool_7 = false;
		}
	}

	internal bool IsColorVariedAuto => bool_7;

	public int GapWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 0 && value <= 500)
			{
				int_0 = value;
			}
		}
	}

	public int Overlap
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= -100 && value <= 100)
			{
				int_1 = value;
			}
		}
	}

	public bool HasDropLines
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool HasHighLowLines
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool HasUpDownBars
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	internal Class755 DropLinesInternal => class755_2;

	public Interface18 DropLines => class755_2;

	internal Class755 HighLowLinesInternal => class755_3;

	public Interface18 HighLowLines => class755_3;

	public bool HasLeaderLines
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	internal Class755 LeaderLinesInternal => class755_1;

	public Interface18 LeaderLines => class755_1;

	internal Class746 UpBarsInternal => class746_0;

	public Interface10 UpBars => class746_0;

	internal Class746 DownBarsInternal => class746_1;

	public Interface10 DownBars => class746_1;

	public int AngleOfFirstSlice
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value % 360;
		}
	}

	public int DoughnutHoleSize
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 10)
			{
				int_3 = 10;
			}
			else if (value > 90)
			{
				int_3 = 90;
			}
			else
			{
				int_3 = value;
			}
		}
	}

	public bool HasSeriesLines
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	internal Class755 SeriesLinesInternal => class755_4;

	public Interface18 SeriesLines => class755_4;

	public int BubbleScale
	{
		get
		{
			return int_5;
		}
		set
		{
			if (value > 300)
			{
				int_5 = 300;
			}
			else
			{
				int_5 = value;
			}
		}
	}

	public bool ShowNegativeBubbles
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public Enum149 SizeRepresents
	{
		get
		{
			return enum149_0;
		}
		set
		{
			enum149_0 = value;
		}
	}

	public int DisplayOrder
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	internal Enum141 AxisGroup
	{
		get
		{
			if (PlotOnSecondAxis)
			{
				return Enum141.const_1;
			}
			return Enum141.const_0;
		}
		set
		{
			if (value == Enum141.const_1)
			{
				PlotOnSecondAxis = true;
			}
			else
			{
				PlotOnSecondAxis = false;
			}
		}
	}

	internal ChartType ResembleType
	{
		get
		{
			return chartType_1;
		}
		set
		{
			chartType_1 = value;
		}
	}

	internal Class757 NSeries
	{
		get
		{
			return class757_0;
		}
		set
		{
			class757_0 = value;
		}
	}

	internal int Index => class757_0.ListSeries.IndexOf(this);

	public int SeriesIndex
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	internal bool IsDrawMarkerInPlot
	{
		get
		{
			if (Type != ChartType.Line && Type != ChartType.StackedLine && Type != ChartType.PercentsStackedLine && Type != ChartType.LineWithMarkers && Type != ChartType.StackedLineWithMarkers && Type != ChartType.PercentsStackedLineWithMarkers && Type != ChartType.Radar && Type != ChartType.RadarWithMarkers && Type != ChartType.ScatterWithMarkers && Type != ChartType.ScatterWithSmoothLinesAndMarkers && Type != ChartType.ScatterWithSmoothLines && Type != ChartType.ScatterWithStraightLinesAndMarkers && Type != ChartType.ScatterWithStraightLines)
			{
				return false;
			}
			return true;
		}
	}

	internal bool IsWideKeyInLegend
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.Line:
			case ChartType.StackedLine:
			case ChartType.PercentsStackedLine:
			case ChartType.LineWithMarkers:
			case ChartType.StackedLineWithMarkers:
			case ChartType.PercentsStackedLineWithMarkers:
			case ChartType.ScatterWithMarkers:
			case ChartType.ScatterWithSmoothLinesAndMarkers:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLinesAndMarkers:
			case ChartType.ScatterWithStraightLines:
			case ChartType.Radar:
			case ChartType.RadarWithMarkers:
				if (LineInternal.IsVisible)
				{
					return true;
				}
				return false;
			}
		}
	}

	internal bool IsColumnSeries
	{
		get
		{
			if (Type == ChartType.ClusteredColumn)
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsStatckedSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.StackedColumn:
			case ChartType.StackedColumn3D:
			case ChartType.StackedCylinder:
			case ChartType.StackedCone:
			case ChartType.StackedPyramid:
			case ChartType.StackedLine:
			case ChartType.StackedLineWithMarkers:
			case ChartType.StackedBar:
			case ChartType.StackedBar3D:
			case ChartType.StackedHorizontalCylinder:
			case ChartType.StackedHorizontalCone:
			case ChartType.StackedHorizontalPyramid:
			case ChartType.StackedArea:
			case ChartType.StackedArea3D:
				return true;
			}
		}
	}

	internal bool IsAreaStatckedSeries
	{
		get
		{
			ChartType type = Type;
			if (type != ChartType.StackedArea && type != ChartType.StackedArea3D)
			{
				return false;
			}
			return true;
		}
	}

	internal bool IsPercentSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.PercentsStackedColumn:
			case ChartType.PercentsStackedColumn3D:
			case ChartType.PercentsStackedCylinder:
			case ChartType.PercentsStackedCone:
			case ChartType.PercentsStackedPyramid:
			case ChartType.PercentsStackedLine:
			case ChartType.PercentsStackedLineWithMarkers:
			case ChartType.PercentsStackedBar:
			case ChartType.PercentsStackedBar3D:
			case ChartType.PercentsStackedHorizontalCylinder:
			case ChartType.PercentsStackedHorizontalCone:
			case ChartType.PercentsStackedHorizontalPyramid:
			case ChartType.PercentsStackedArea:
			case ChartType.PercentsStackedArea3D:
				return true;
			}
		}
	}

	internal bool IsAreaPercentSeries
	{
		get
		{
			ChartType type = Type;
			if (type != ChartType.PercentsStackedArea && type != ChartType.PercentsStackedArea3D)
			{
				return false;
			}
			return true;
		}
	}

	internal bool IsPieSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.Pie:
			case ChartType.Pie3D:
			case ChartType.PieOfPie:
			case ChartType.ExplodedPie:
			case ChartType.ExplodedPie3D:
			case ChartType.BarOfPie:
			case ChartType.Doughnut:
			case ChartType.ExplodedDoughnut:
				return true;
			}
		}
	}

	internal bool IsRardarSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.Radar:
			case ChartType.RadarWithMarkers:
			case ChartType.FilledRadar:
				return true;
			}
		}
	}

	internal bool IsBubbleSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.Bubble:
			case ChartType.BubbleWith3D:
				return true;
			}
		}
	}

	internal bool IsXValueSeries
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case ChartType.ScatterWithMarkers:
			case ChartType.ScatterWithSmoothLinesAndMarkers:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLinesAndMarkers:
			case ChartType.ScatterWithStraightLines:
			case ChartType.Bubble:
			case ChartType.BubbleWith3D:
				return true;
			}
		}
	}

	internal bool IsDataLabelsShown
	{
		get
		{
			foreach (Class748 item in PointsInternal)
			{
				if (item.DataLabelsInternal.IsShown)
				{
					return true;
				}
			}
			return false;
		}
	}

	public int ID
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	public bool UseExcel4Palette
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	internal Class759(Class740 chart, Class757 parent, ChartType type)
	{
		class740_0 = chart;
		class757_0 = parent;
		Type = type;
		class750_0 = new Class750(chart, this, Enum140.const_12);
		class755_0 = new Class755(chart, Enum145.const_8);
		class741_0 = new Class741(chart, this, Enum140.const_6);
		class756_0 = new Class756(chart, this);
		class755_4 = new Class755(chart, Enum145.const_20);
		class762_0 = new Class762(chart, this);
		class747_0 = new Class747(chart, this);
		int_0 = 150;
		class755_1 = new Class755(chart, Enum145.const_21);
		class755_2 = new Class755(chart, Enum145.const_22);
		class755_3 = new Class755(chart, Enum145.const_23);
		class746_0 = new Class746(chart, this, Enum140.const_14, Enum145.const_16);
		class746_1 = new Class746(chart, this, Enum140.const_15, Enum145.const_17);
		class746_1.AreaInternal.ForegroundColor = Color.Black;
		method_0();
	}

	private void method_0()
	{
		switch (Type)
		{
		case ChartType.ScatterWithMarkers:
			class755_0.Formatting = FillType.NoFill;
			break;
		case ChartType.ScatterWithSmoothLinesAndMarkers:
			Smooth = true;
			break;
		case ChartType.ScatterWithSmoothLines:
			MarkerInternal.MarkerStyle = MarkerStyleType.None;
			Smooth = true;
			break;
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.ScatterWithStraightLines:
		case ChartType.Radar:
			MarkerInternal.MarkerStyle = MarkerStyleType.None;
			break;
		case ChartType.PieOfPie:
		case ChartType.BarOfPie:
			class748_0 = new Class748(class740_0);
			class748_0.ChartPoints = class747_0;
			HasSeriesLines = true;
			break;
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.PercentsStackedBar:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
			Overlap = 100;
			break;
		}
		switch (Type)
		{
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.LineWithMarkers:
		case ChartType.StackedLineWithMarkers:
		case ChartType.PercentsStackedLineWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
			class755_0.LineStyleInternal.Width = 3.0;
			break;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Class759)
		{
			Class759 @class = (Class759)obj;
			if (this != obj)
			{
				return false;
			}
			if (class757_0 != @class.class757_0)
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return (Index + 1).GetHashCode() + class757_0.GetHashCode();
	}

	internal string method_1()
	{
		return Name;
	}

	public void imethod_0(params double[] yValues)
	{
		PointsInternal.Add(yValues);
	}

	public void imethod_1(params double[] xValues)
	{
		PointsInternal.imethod_0(xValues);
	}

	public void imethod_2(params double[] sizes)
	{
		class747_0.imethod_1(sizes);
	}

	internal bool method_2(ChartType[] chartType)
	{
		int num = 0;
		while (true)
		{
			if (num < chartType.Length)
			{
				ChartType chartType2 = chartType[num];
				if (Type == chartType2)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal bool method_3(ChartType[] chartType)
	{
		int num = 0;
		while (true)
		{
			if (num < chartType.Length)
			{
				ChartType chartType2 = chartType[num];
				if (chartType_1 == chartType2)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}
