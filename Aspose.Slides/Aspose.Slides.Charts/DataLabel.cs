using System;
using ns25;

namespace Aspose.Slides.Charts;

public class DataLabel : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ILayoutable, IDataLabel
{
	private DataLabelFormat dataLabelFormat_0;

	private TextFrame textFrame_0;

	private ChartSeries chartSeries_0;

	private Class315 class315_0;

	internal Class315 PPTXUnsupportedProps => class315_0;

	public IChart Chart => ParentSeries.Chart;

	public bool IsVisible
	{
		get
		{
			if (!dataLabelFormat_0.ShowLegendKey && !dataLabelFormat_0.ShowValue && !dataLabelFormat_0.ShowCategoryName && !dataLabelFormat_0.ShowSeriesName && !dataLabelFormat_0.ShowPercentage)
			{
				return dataLabelFormat_0.ShowBubbleSize;
			}
			return true;
		}
	}

	public ITextFrame TextFrameForOverriding => textFrame_0;

	public IChartTextFormat TextFormat => dataLabelFormat_0.TextFormatManager.TextFormatOfAutoText;

	public float X
	{
		get
		{
			return PPTXUnsupportedProps.X;
		}
		set
		{
			PPTXUnsupportedProps.X = value;
		}
	}

	public float Y
	{
		get
		{
			return PPTXUnsupportedProps.Y;
		}
		set
		{
			PPTXUnsupportedProps.Y = value;
		}
	}

	public float Width
	{
		get
		{
			return PPTXUnsupportedProps.Width;
		}
		set
		{
			PPTXUnsupportedProps.Width = value;
		}
	}

	public float Height
	{
		get
		{
			return PPTXUnsupportedProps.Height;
		}
		set
		{
			PPTXUnsupportedProps.Height = value;
		}
	}

	public float Right => PPTXUnsupportedProps.Right;

	public float Bottom => PPTXUnsupportedProps.Bottom;

	public IDataLabelFormat DataLabelFormat => dataLabelFormat_0;

	[Obsolete("Use DataLabelFormat.IsNumberFormatLinkedToSource property instead. Property will be removed after 01.09.2013.")]
	public bool LinkedSource
	{
		get
		{
			return DataLabelFormat.IsNumberFormatLinkedToSource;
		}
		set
		{
			DataLabelFormat.IsNumberFormatLinkedToSource = value;
		}
	}

	internal ChartSeries ParentSeries => chartSeries_0;

	ILayoutable IDataLabel.AsILayoutable => this;

	IOverridableText IDataLabel.AsIOverridableText => this;

	IFormattedTextContainer IOverridableText.AsIFormattedTextContainer => this;

	IChartComponent ILayoutable.AsIChartComponent => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide => ((ISlideComponent)chartSeries_0).Slide;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation => ((IPresentationComponent)chartSeries_0).Presentation;

	public DataLabel(IChartSeries parent)
	{
		class315_0 = new Class315(parent.Chart);
		chartSeries_0 = (ChartSeries)parent;
		textFrame_0 = new TextFrame(this);
		dataLabelFormat_0 = new DataLabelFormat(this);
		((EffectFormat)dataLabelFormat_0.format_0.Effect).method_0((EffectFormat)parent.Labels.DefaultDataLabelFormat.Format.Effect);
		((ThreeDFormat)dataLabelFormat_0.format_0.Effect3D).method_1((ThreeDFormat)parent.Labels.DefaultDataLabelFormat.Format.Effect3D);
		((FillFormat)dataLabelFormat_0.format_0.Fill).method_0((FillFormat)parent.Labels.DefaultDataLabelFormat.Format.Fill);
		((LineFormat)dataLabelFormat_0.format_0.Line).method_0((LineFormat)parent.Labels.DefaultDataLabelFormat.Format.Line);
		dataLabelFormat_0.IsNumberFormatLinkedToSource = parent.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource;
		dataLabelFormat_0.NumberFormat = parent.Labels.DefaultDataLabelFormat.NumberFormat;
		dataLabelFormat_0.Position = parent.Labels.DefaultDataLabelFormat.Position;
		dataLabelFormat_0.Separator = parent.Labels.DefaultDataLabelFormat.Separator;
		dataLabelFormat_0.ShowBubbleSize = parent.Labels.DefaultDataLabelFormat.ShowBubbleSize;
		dataLabelFormat_0.ShowCategoryName = parent.Labels.DefaultDataLabelFormat.ShowCategoryName;
		dataLabelFormat_0.ShowLegendKey = parent.Labels.DefaultDataLabelFormat.ShowLegendKey;
		dataLabelFormat_0.ShowPercentage = parent.Labels.DefaultDataLabelFormat.ShowPercentage;
		dataLabelFormat_0.ShowSeriesName = parent.Labels.DefaultDataLabelFormat.ShowSeriesName;
		dataLabelFormat_0.ShowValue = parent.Labels.DefaultDataLabelFormat.ShowValue;
		ITextFrame textFrame = new TextFrame(this);
		((ChartTextFormat)parent.Labels.DefaultDataLabelFormat.TextFormat).CopyTo(textFrame);
		dataLabelFormat_0.TextFormatManager.TextFormatOfAutoText.CopyFrom(textFrame);
	}

	public void Hide()
	{
		dataLabelFormat_0.ShowLegendKey = false;
		dataLabelFormat_0.ShowValue = false;
		dataLabelFormat_0.ShowCategoryName = false;
		dataLabelFormat_0.ShowSeriesName = false;
		dataLabelFormat_0.ShowPercentage = false;
		dataLabelFormat_0.ShowBubbleSize = false;
	}

	public ITextFrame AddTextFrameForOverriding(string text)
	{
		if (textFrame_0 == null)
		{
			textFrame_0 = new TextFrame(this);
		}
		((ParagraphCollection)textFrame_0.Paragraphs).Text = text;
		return textFrame_0;
	}

	internal static string smethod_0(IChartSeries series, LegendDataLabelPosition position)
	{
		if (position == LegendDataLabelPosition.NotDefined)
		{
			return "";
		}
		if (series.Type != 0 && series.Type != ChartType.ClusteredBar)
		{
			if (series.Type != ChartType.StackedColumn && series.Type != ChartType.PercentsStackedColumn && series.Type != ChartType.StackedBar && series.Type != ChartType.PercentsStackedBar)
			{
				if (series.Type != ChartType.Pie && series.Type != ChartType.Pie3D && series.Type != ChartType.PieOfPie && series.Type != ChartType.BarOfPie && series.Type != ChartType.ExplodedPie && series.Type != ChartType.ExplodedPie3D)
				{
					if (series.Type != ChartType.LineWithMarkers && series.Type != ChartType.StackedLineWithMarkers && series.Type != ChartType.PercentsStackedLineWithMarkers && series.Type != ChartType.Line && series.Type != ChartType.PercentsStackedLine && series.Type != ChartType.StackedLine && series.Type != ChartType.ScatterWithMarkers && series.Type != ChartType.ScatterWithSmoothLines && series.Type != ChartType.ScatterWithSmoothLinesAndMarkers && series.Type != ChartType.ScatterWithStraightLines && series.Type != ChartType.ScatterWithStraightLinesAndMarkers && series.Type != ChartType.HighLowClose && series.Type != ChartType.OpenHighLowClose && series.Type != ChartType.VolumeHighLowClose && series.Type != ChartType.VolumeOpenHighLowClose && series.Type != ChartType.Bubble && series.Type != ChartType.BubbleWith3D)
					{
						return "supports only default value";
					}
					if (position != LegendDataLabelPosition.Center && position != 0 && position != LegendDataLabelPosition.Top && position != LegendDataLabelPosition.Left && position != LegendDataLabelPosition.Right)
					{
						return string.Concat(LegendDataLabelPosition.Center, ", ", LegendDataLabelPosition.Bottom, ", ", LegendDataLabelPosition.Top, ", ", LegendDataLabelPosition.Left, ", ", LegendDataLabelPosition.Right);
					}
					return "";
				}
				if (position != LegendDataLabelPosition.Center && position != LegendDataLabelPosition.InsideEnd && position != LegendDataLabelPosition.BestFit && position != LegendDataLabelPosition.OutsideEnd)
				{
					return LegendDataLabelPosition.Center.ToString() + ", " + LegendDataLabelPosition.InsideEnd.ToString() + ", " + LegendDataLabelPosition.BestFit.ToString() + ", " + LegendDataLabelPosition.OutsideEnd;
				}
				return "";
			}
			if (position != LegendDataLabelPosition.Center && position != LegendDataLabelPosition.InsideBase && position != LegendDataLabelPosition.InsideEnd)
			{
				return LegendDataLabelPosition.Center.ToString() + ", " + LegendDataLabelPosition.InsideBase.ToString() + ", " + LegendDataLabelPosition.InsideEnd;
			}
			return "";
		}
		if (position != LegendDataLabelPosition.Center && position != LegendDataLabelPosition.InsideBase && position != LegendDataLabelPosition.InsideEnd && position != LegendDataLabelPosition.OutsideEnd)
		{
			return LegendDataLabelPosition.Center.ToString() + ", " + LegendDataLabelPosition.InsideBase.ToString() + ", " + LegendDataLabelPosition.InsideEnd.ToString() + ", " + LegendDataLabelPosition.OutsideEnd;
		}
		return "";
	}
}
