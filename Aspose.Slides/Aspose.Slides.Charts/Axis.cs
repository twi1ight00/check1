using System;
using ns16;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class Axis : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IAxis
{
	private bool bool_0;

	private float float_0;

	private DisplayUnitType displayUnitType_0;

	private double double_0;

	private Class16 class16_0;

	private bool bool_1 = true;

	private double double_1;

	private bool bool_2 = true;

	private double double_2;

	private bool bool_3 = true;

	private double double_3;

	private bool bool_4 = true;

	private double double_4;

	private bool bool_5;

	private double double_5 = 10.0;

	private bool bool_6;

	private bool bool_7 = true;

	private TickMarkType tickMarkType_0 = TickMarkType.Outside;

	private TickMarkType tickMarkType_1 = TickMarkType.None;

	private TickLabelPositionType tickLabelPositionType_0 = TickLabelPositionType.NextTo;

	private TimeUnitType timeUnitType_0;

	private TimeUnitType timeUnitType_1;

	private TimeUnitType timeUnitType_2;

	private ChartLinesFormat chartLinesFormat_0 = new ChartLinesFormat();

	private ChartLinesFormat chartLinesFormat_1 = new ChartLinesFormat();

	private TextFrame textFrame_0;

	private readonly AxisFormat axisFormat_0;

	private readonly ChartTitle chartTitle_0;

	private CrossesType crossesType_0;

	private AxisPositionType axisPositionType_0;

	private Chart chart_0;

	private uint uint_0 = 1u;

	private bool bool_8 = true;

	private string string_0 = "";

	private bool bool_9 = true;

	private bool bool_10;

	private bool bool_11;

	private readonly Class17 class17_0;

	private TimeUnitType timeUnitType_3;

	private Class307 class307_0 = new Class307();

	internal Class307 PPTXUnsupportedProps => class307_0;

	public IChart Chart => chart_0;

	public bool AxisBetweenCategories
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

	public float CrossAt
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public DisplayUnitType DisplayUnit
	{
		get
		{
			return displayUnitType_0;
		}
		set
		{
			displayUnitType_0 = value;
		}
	}

	internal Class16 DisplayUnitLabel => class16_0;

	public bool IsAutomaticMaxValue
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

	public double MaxValue
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

	public double MinorUnit
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public bool IsAutomaticMinorUnit
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

	public double MajorUnit
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

	public bool IsAutomaticMajorUnit
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

	public bool IsAutomaticMinValue
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

	public double MinValue
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public bool IsLogarithmic
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

	public double LogBase
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public bool IsPlotOrderReversed
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

	public bool IsVisible
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

	public TickMarkType MajorTickMark
	{
		get
		{
			return tickMarkType_0;
		}
		set
		{
			tickMarkType_0 = value;
		}
	}

	public TickMarkType MinorTickMark
	{
		get
		{
			return tickMarkType_1;
		}
		set
		{
			tickMarkType_1 = value;
		}
	}

	public TickLabelPositionType TickLabelPosition
	{
		get
		{
			return tickLabelPositionType_0;
		}
		set
		{
			tickLabelPositionType_0 = value;
		}
	}

	public TimeUnitType MajorUnitScale
	{
		get
		{
			return timeUnitType_0;
		}
		set
		{
			timeUnitType_0 = value;
		}
	}

	public TimeUnitType MinorUnitScale
	{
		get
		{
			return timeUnitType_1;
		}
		set
		{
			timeUnitType_1 = value;
		}
	}

	public TimeUnitType BaseUnitScale
	{
		get
		{
			return timeUnitType_2;
		}
		set
		{
			timeUnitType_2 = value;
		}
	}

	public IChartLinesFormat MinorGridLinesFormat => chartLinesFormat_0;

	public IChartLinesFormat MajorGridLinesFormat => chartLinesFormat_1;

	public bool ShowMinorGridLines => chartLinesFormat_0.Line.FillFormat.FillType != FillType.NoFill;

	public bool ShowMajorGridLines => chartLinesFormat_1.Line.FillFormat.FillType != FillType.NoFill;

	public IAxisFormat Format => axisFormat_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public IChartTitle Title => chartTitle_0;

	public CrossesType CrossType
	{
		get
		{
			return crossesType_0;
		}
		set
		{
			crossesType_0 = value;
		}
	}

	public AxisPositionType Position
	{
		get
		{
			return axisPositionType_0;
		}
		set
		{
			axisPositionType_0 = value;
		}
	}

	public bool HasTitle
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public string NumberFormat
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

	[Obsolete("Use IsNumberFormatLinkedToSource property instead. Property will be removed after 01.09.2013.")]
	public bool SourceLinked
	{
		get
		{
			return IsNumberFormatLinkedToSource;
		}
		set
		{
			IsNumberFormatLinkedToSource = value;
		}
	}

	public bool IsNumberFormatLinkedToSource
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

	[Obsolete("Use TickLabelRotationAngle property instead. Property will be removed after 01.09.2013.")]
	public float RotationAngle
	{
		get
		{
			return ((TextFrameFormat)TextFormat.TextBlockFormat).RotationAngle;
		}
		set
		{
			((TextFrameFormat)TextFormat.TextBlockFormat).RotationAngle = value;
		}
	}

	public float TickLabelRotationAngle
	{
		get
		{
			return ((TextFrameFormat)TextFormat.TextBlockFormat).RotationAngle;
		}
		set
		{
			((TextFrameFormat)TextFormat.TextBlockFormat).RotationAngle = value;
		}
	}

	public uint TickLabelSpacing
	{
		get
		{
			return uint_0;
		}
		set
		{
			if (value == 0)
			{
				throw new PptxException("Invalid value: must be greater than 0");
			}
			uint_0 = value;
		}
	}

	public bool IsAutomaticTickLabelSpacing
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

	internal Enum268 CrossBetween => PPTXUnsupportedProps.CrossBetween;

	IChartComponent IAxis.AsIChartComponent => this;

	IFormattedTextContainer IAxis.AsIFormattedTextContainer => this;

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

	internal Axis(Chart parent)
	{
		chart_0 = parent;
		axisFormat_0 = new AxisFormat(this);
		chartTitle_0 = new ChartTitle(parent);
		class17_0 = new Class17(this);
		class16_0 = new Class16(parent);
	}

	internal void method_0(AxisPositionType position)
	{
		axisPositionType_0 = position;
	}
}
