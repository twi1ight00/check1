using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class748 : Interface12
{
	private Class747 class747_0;

	private Class740 class740_0;

	private Class741 class741_0;

	private Class755 class755_0;

	private Class756 class756_0;

	private Class750 class750_0;

	private double double_0;

	private object object_0;

	private double double_1;

	private object object_1;

	private double double_2;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private int int_0;

	private bool bool_8 = true;

	private bool bool_9;

	public bool NotPlotted
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool XNotPlotted
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

	public bool Interpolated
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public bool IsXValueError
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

	public bool IsYValueError
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

	internal Class747 ChartPoints
	{
		get
		{
			return class747_0;
		}
		set
		{
			class747_0 = value;
		}
	}

	internal Class740 Chart => class740_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	internal Class756 MarkerInternal => class756_0;

	public Interface19 Marker => class756_0;

	internal Class750 DataLabelsInternal => class750_0;

	public Interface13 DataLabels => class750_0;

	public double XValue
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public object XValueOriginal
	{
		get
		{
			if (object_0 == null)
			{
				return XValue;
			}
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public string XFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool XValueIsCulture
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

	public double YValue
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public object YValueOriginal
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public string YFormat
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

	public bool YValueIsCulture
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

	public double BubbleSizeValue
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public string BubbleSizeFormat
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

	public bool BubbleSizeIsCulture
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

	internal bool IsValueNegative
	{
		get
		{
			if (YValue < 0.0)
			{
				return true;
			}
			return false;
		}
	}

	public int Explosion
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_8 = false;
		}
	}

	public bool IsExplosionAuto
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

	public bool IsShadow
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

	internal int Index => ChartPoints.ListPoints.IndexOf(this);

	internal Class748(Class740 chart)
	{
		class740_0 = chart;
		class741_0 = new Class741(chart, this, Enum140.const_7);
		class755_0 = new Class755(chart, Enum145.const_9);
		class756_0 = new Class756(chart, this);
		class750_0 = new Class750(chart, this, Enum140.const_12);
	}

	internal void method_0()
	{
		if (class747_0 != null && class747_0.ASeries != null)
		{
			switch (class747_0.ASeries.Type)
			{
			case ChartType.ExplodedPie:
			case ChartType.ExplodedPie3D:
				int_0 = 25;
				break;
			case ChartType.ScatterWithMarkers:
				class755_0.Formatting = FillType.NoFill;
				break;
			case ChartType.Line:
			case ChartType.StackedLine:
			case ChartType.PercentsStackedLine:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLines:
			case ChartType.Radar:
				MarkerInternal.MarkerStyle = MarkerStyleType.None;
				BorderInternal.LineStyleInternal.Width = 3.0;
				break;
			}
			switch (class747_0.ASeries.Type)
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
				BorderInternal.LineStyleInternal.Width = 3.0;
				break;
			}
		}
	}

	internal Class748(Class740 chart, double yValue)
		: this(chart)
	{
		double_1 = yValue;
	}

	internal Class748(Class740 chart, double yValue, double xValue)
		: this(chart)
	{
		double_1 = yValue;
		double_0 = xValue;
	}
}
