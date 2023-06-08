using System;
using ns16;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class ChartSeriesGroup : IChartSeriesGroup
{
	private Class318 class318_0;

	private CombinableSeriesTypesGroup combinableSeriesTypesGroup_0;

	private bool bool_0;

	private Class14 class14_0;

	private UpDownBarsManager upDownBarsManager_0;

	private ushort ushort_0 = 150;

	private ushort ushort_1;

	private bool bool_1;

	private ushort ushort_2;

	private bool bool_2;

	private sbyte sbyte_0;

	public CombinableSeriesTypesGroup Type => combinableSeriesTypesGroup_0;

	public bool PlotOnSecondAxis => bool_0;

	public IChartSeriesReadonlyCollection Series => class14_0;

	public IChartSeries this[int index] => class14_0[index];

	public IUpDownBarsManager UpDownBars => upDownBarsManager_0;

	public ushort GapWidth
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public ushort GapDepth
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	public ushort FirstSliceAngle
	{
		get
		{
			return ushort_2;
		}
		set
		{
			if (value < 0 || value > 360)
			{
				throw new ArgumentOutOfRangeException("FirstSliceAngle can be from 0 to 360 degrees.");
			}
			ushort_2 = value;
		}
	}

	internal byte DoughnutHoleSize => PPTXUnsupportedProps.DoughnutHoleSize;

	public sbyte Overlap
	{
		get
		{
			return sbyte_0;
		}
		set
		{
			if (value < -100 || value > 100)
			{
				throw new ArgumentOutOfRangeException("Overlap value should be in the range from -100 to 100.");
			}
			sbyte_0 = value;
		}
	}

	internal ushort SecondPieSize => PPTXUnsupportedProps.SecondPieSize;

	internal bool ShowNegativeBubbles => PPTXUnsupportedProps.ShowNegativeBubbles;

	internal Enum266 BubbleSizeRepresentation => PPTXUnsupportedProps.BubbleSizeRepresentation;

	internal double OfPieSplitPosition => PPTXUnsupportedProps.OfPieSplitPosition;

	internal Enum270 OfPieSplitType => PPTXUnsupportedProps.OfPieSplitType;

	public bool IsColorVaried
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

	public bool HasSeriesLines
	{
		get
		{
			return PPTXUnsupportedProps.HasSeriesLines;
		}
		set
		{
			PPTXUnsupportedProps.HasSeriesLines = value;
		}
	}

	internal bool HasDropLines => PPTXUnsupportedProps.HasDropLines;

	internal bool HasHiLowLines => PPTXUnsupportedProps.HasHiLowLines;

	internal bool Wireframe
	{
		get
		{
			if (Type != CombinableSeriesTypesGroup.SurfaceChart_WireframeContour)
			{
				return Type == CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D;
			}
			return true;
		}
	}

	internal int BubbleSizeScale => PPTXUnsupportedProps.BubbleSizeScale;

	internal Class318 PPTXUnsupportedProps => class318_0;

	internal ChartSeriesGroup(ChartSeries series)
	{
		class318_0 = new Class318(this);
		combinableSeriesTypesGroup_0 = ChartTypeCharacterizer.smethod_2(series.Type);
		bool_0 = series.PlotOnSecondAxis;
		class14_0 = new Class14(this);
		class14_0.Add(series);
		upDownBarsManager_0 = new UpDownBarsManager(series.Chart);
	}
}
