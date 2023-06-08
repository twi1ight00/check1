using System;
using ns2;

namespace Aspose.Slides.Charts;

public class DataLabelFormat : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IDataLabelFormat
{
	private IChartComponent ichartComponent_0;

	private uint uint_0;

	private DataLabelCollection dataLabelCollection_0;

	private IChartSeries ichartSeries_0;

	private string string_0;

	private bool bool_0 = true;

	internal Format format_0;

	private readonly Class17 class17_0;

	private LegendDataLabelPosition legendDataLabelPosition_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private string string_1;

	public bool IsNumberFormatLinkedToSource
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.IsNumberFormatLinkedToSource = value;
				}
			}
			method_0();
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
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.NumberFormat = value;
				}
			}
			method_0();
		}
	}

	public IFormat Format => format_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public LegendDataLabelPosition Position
	{
		get
		{
			return legendDataLabelPosition_0;
		}
		set
		{
			string text = DataLabel.smethod_0(ichartSeries_0, value);
			if (text == "")
			{
				legendDataLabelPosition_0 = value;
				if (dataLabelCollection_0 != null)
				{
					foreach (IDataLabel item in dataLabelCollection_0)
					{
						item.DataLabelFormat.Position = value;
					}
				}
				method_0();
				return;
			}
			throw new InvalidOperationException("Wrong label position for this type of series. Possible values: " + text);
		}
	}

	public bool ShowLegendKey
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowLegendKey = value;
				}
			}
			method_0();
		}
	}

	public bool ShowValue
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowValue = value;
				}
			}
			method_0();
		}
	}

	public bool ShowCategoryName
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowCategoryName = value;
				}
			}
			method_0();
		}
	}

	public bool ShowSeriesName
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowSeriesName = value;
				}
			}
			method_0();
		}
	}

	public bool ShowPercentage
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowPercentage = value;
				}
			}
			method_0();
		}
	}

	public bool ShowBubbleSize
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowBubbleSize = value;
				}
			}
			method_0();
		}
	}

	public bool ShowLeaderLines
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.ShowLeaderLines = value;
				}
			}
			method_0();
		}
	}

	public string Separator
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (dataLabelCollection_0 != null)
			{
				foreach (IDataLabel item in dataLabelCollection_0)
				{
					item.DataLabelFormat.Separator = value;
				}
			}
			method_0();
		}
	}

	internal IChartComponent Parent => ichartComponent_0;

	internal uint Version => uint_0 + format_0.Version + class17_0.TextFormatOfAutoText.Version;

	IFormattedTextContainer IDataLabelFormat.AsIFormattedTextContainer => this;

	IChartComponent IDataLabelFormat.AsIChartComponent => this;

	public IChart Chart => ichartComponent_0.Chart;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (ichartComponent_0 == null)
			{
				return null;
			}
			return ichartComponent_0.Slide;
		}
	}

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (ichartComponent_0 == null)
			{
				return null;
			}
			return ichartComponent_0.Presentation;
		}
	}

	private void method_0()
	{
		uint_0++;
	}

	internal DataLabelFormat(DataLabelCollection parentDataLabels)
		: this()
	{
		dataLabelCollection_0 = parentDataLabels;
		ichartComponent_0 = parentDataLabels;
		ichartSeries_0 = parentDataLabels.ParentSeries;
		format_0 = new Format(parentDataLabels.Chart);
	}

	internal DataLabelFormat(DataLabel parentLabel)
		: this()
	{
		ichartComponent_0 = parentLabel;
		ichartSeries_0 = parentLabel.ParentSeries;
		format_0 = new Format(parentLabel.Chart);
	}

	private DataLabelFormat()
	{
		class17_0 = new Class17(this);
		legendDataLabelPosition_0 = LegendDataLabelPosition.NotDefined;
		string_1 = "";
		string_0 = "";
	}
}
