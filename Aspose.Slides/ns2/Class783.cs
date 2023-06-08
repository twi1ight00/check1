using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;
using ns37;

namespace ns2;

internal class Class783
{
	private Class785 class785_0;

	private Axis axis_0;

	private Font font_0;

	private Color color_0;

	private int int_0;

	private bool bool_0 = true;

	private int int_1;

	private int int_2;

	private bool bool_1;

	private Enum160 enum160_0;

	private TimeUnitType timeUnitType_0;

	private TimeUnitType timeUnitType_1;

	private float float_0;

	private double double_0;

	private double double_1;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private double double_2;

	private double double_3;

	private int int_3 = 1;

	private bool bool_4 = true;

	private int int_4 = 1;

	private Class751 class751_0;

	private Class784 class784_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal float float_4;

	internal float float_5;

	internal float float_6;

	internal ArrayList arrayList_0 = new ArrayList();

	internal int int_5;

	internal bool bool_5 = true;

	[CompilerGenerated]
	private bool bool_6;

	public Font TickLabelTextFont => font_0;

	public Color TickLabelFontColor => color_0;

	public int TickLableRotation
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

	internal Class785 AxisTitleRenderContext => class785_0;

	internal Axis Axis => axis_0;

	internal bool TickLabelAutoRotation
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

	internal int TickLabelsOffsetPixel
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int TickLabelsOffset
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public bool IsLinkedSource => bool_1;

	public Enum160 AxisType => enum160_0;

	internal double LogMaxValue
	{
		get
		{
			if (Axis.IsLogarithmic)
			{
				return method_0(MaxValue);
			}
			return MaxValue;
		}
	}

	internal double LogMinValue
	{
		get
		{
			if (Axis.IsLogarithmic)
			{
				return method_0(MinValue);
			}
			return MinValue;
		}
	}

	internal double LogCrossAt
	{
		get
		{
			if (Axis.IsLogarithmic)
			{
				return method_0(CrossAt);
			}
			return CrossAt;
		}
	}

	internal float CrossAt
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

	internal double MinValue
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

	internal double MaxValue
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

	internal TimeUnitType MajorUnitScale
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

	internal TimeUnitType MinorUnitScale
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

	public bool IsAutoMajorUnit
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

	public bool IsAutoMinorUnit
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

	public double MinorUnit
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			IsAutoMinorUnit = false;
		}
	}

	public double MajorUnit
	{
		get
		{
			return double_3;
		}
		set
		{
			if (value > 0.0)
			{
				double_3 = value;
				bool_2 = false;
			}
		}
	}

	public int TickLabelSpacing
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value > 0)
			{
				int_3 = value;
			}
		}
	}

	public bool IsAutoTickLabelSpacing
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

	public int TickMarkSpacing
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value > 0)
			{
				int_4 = value;
			}
		}
	}

	internal Class751 DisplayUnitInternal => class751_0;

	public Interface14 DisplayUnit => class751_0;

	public bool AxisBetweenCategories
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public Class784 ChartRenderContext => class784_0;

	internal Class783(Axis axis, Class784 chartRenderContext, Enum160 axisType)
	{
		AxisBetweenCategories = true;
		class784_0 = chartRenderContext;
		if (axis != null)
		{
			enum160_0 = axisType;
			Chart chart = (Chart)axis.Chart;
			axis_0 = axis;
			if (axis.HasTitle)
			{
				class785_0 = new Class785((ChartTitle)axis.Title, chartRenderContext);
			}
			if (chart.Style + 1 > StyleType.Style41)
			{
				color_0 = chartRenderContext.method_0(ColorSchemeIndex.Light1);
			}
			else
			{
				color_0 = chartRenderContext.method_0(ColorSchemeIndex.Dark1);
			}
			color_0 = chart.method_14(axis_0.TextFormatManager, null, color_0, chartRenderContext.Chart2007);
			font_0 = chart.method_15(axis_0.TextFormatManager, null, isBold: false, isTitle: false);
			float rotationAngle = ((TextFrameFormat)axis.TextFormatManager.TextFormatOfAutoText.TextBlockFormat).RotationAngle;
			if (!float.IsNaN(rotationAngle) && rotationAngle != -1000f)
			{
				bool_0 = false;
				int_0 = (int)((TextFrameFormat)axis.TextFormatManager.TextFormatOfAutoText.TextBlockFormat).RotationAngle * -1;
			}
			int_2 = axis.PPTXUnsupportedProps.LabelOffset;
			if (axis.NumberFormat == "" && axis.NumberFormat == "General")
			{
				bool_1 = true;
			}
			CrossAt = axis.CrossAt;
			MinValue = axis.MinValue;
			MaxValue = axis.MaxValue;
			MajorUnitScale = axis.MajorUnitScale;
			MinorUnitScale = axis.MinorUnitScale;
			if (!axis.IsAutomaticMajorUnit)
			{
				IsAutoMajorUnit = false;
				MajorUnit = axis.MajorUnit;
			}
			if (!axis.IsAutomaticMinorUnit)
			{
				IsAutoMinorUnit = false;
				MinorUnit = axis.MinorUnit;
			}
			TickLabelSpacing = (int)axis.TickLabelSpacing;
			IsAutoTickLabelSpacing = axis.IsAutomaticTickLabelSpacing;
			class751_0 = new Class751(chartRenderContext.Chart2007, null, Enum140.const_13);
			DisplayUnit.DisplayUnitType = axis.DisplayUnit;
		}
	}

	internal double method_0(double d)
	{
		return Math.Log(d, Axis.LogBase);
	}

	internal double method_1(double d)
	{
		return Math.Pow(Axis.LogBase, d);
	}

	internal double method_2(double yValue)
	{
		if (yValue > LogMaxValue)
		{
			yValue = LogMaxValue;
		}
		if (yValue < LogMinValue)
		{
			yValue = LogMinValue;
		}
		return yValue;
	}

	public void method_3(float x1, float y1, float x2, float y2)
	{
		Color empty = Color.Empty;
		empty = class784_0.method_0(ColorSchemeIndex.Dark1);
		empty = Struct44.smethod_10(empty, 0.75);
		empty = Color.FromArgb(255, empty);
		Struct44.smethod_0(new PointF(x1, y1), new PointF(x2, y2), empty, (LineFormat)Axis.Format.Line, class784_0);
	}

	public void method_4(float x1, float y1, float x2, float y2)
	{
		Color empty = Color.Empty;
		empty = class784_0.method_0(ColorSchemeIndex.Dark1);
		empty = Struct44.smethod_10(empty, 0.75);
		empty = Color.FromArgb(255, empty);
		Struct44.smethod_0(new PointF(x1, y1), new PointF(x2, y2), empty, (LineFormat)Axis.MajorGridLinesFormat.Line, class784_0);
	}

	public void method_5(float x1, float y1, float x2, float y2)
	{
		Color empty = Color.Empty;
		if (class784_0.Chart.Style + 1 <= StyleType.Style41)
		{
			empty = class784_0.method_0(ColorSchemeIndex.Dark1);
			empty = Struct44.smethod_10(empty, 0.5);
			empty = Color.FromArgb(255, empty);
		}
		else
		{
			empty = class784_0.method_0(ColorSchemeIndex.Dark1);
			empty = Struct44.smethod_10(empty, 0.9);
			empty = Color.FromArgb(255, empty);
		}
		Struct44.smethod_0(new PointF(x1, y1), new PointF(x2, y2), empty, (LineFormat)Axis.MajorGridLinesFormat.Line, class784_0);
	}
}
