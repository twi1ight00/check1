using System;
using System.Collections;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class DataLabelCollection : IEnumerable, IPresentationComponent, ISlideComponent, IChartComponent, IDataLabelCollection
{
	private readonly ChartSeries chartSeries_0;

	private readonly DataLabelFormat dataLabelFormat_0;

	private readonly Class321 class321_0;

	internal Class321 PPTXUnsupportedProps => class321_0;

	public IChart Chart => ParentSeries.Chart;

	[Obsolete("Use DefaultDataLabelFormat.NumberFormat property instead. Property will be removed after 01.07.2013.")]
	public string NumberFormat
	{
		get
		{
			return dataLabelFormat_0.NumberFormat;
		}
		set
		{
			dataLabelFormat_0.NumberFormat = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.IsNumberFormatLinkedToSource property instead. Property will be removed after 01.07.2013.")]
	public bool LinkedSource
	{
		get
		{
			return dataLabelFormat_0.IsNumberFormatLinkedToSource;
		}
		set
		{
			dataLabelFormat_0.IsNumberFormatLinkedToSource = value;
		}
	}

	[Obsolete("Use IsVisible property instead. Property will be removed after 01.09.2013.")]
	public bool Delete
	{
		get
		{
			return !IsVisible;
		}
		set
		{
			if (!value)
			{
				Hide();
			}
			else
			{
				dataLabelFormat_0.ShowValue = true;
			}
		}
	}

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

	[Obsolete("Use DefaultDataLabelFormat.Format property instead. Property will be removed after 01.09.2013.")]
	public Format Format
	{
		get
		{
			return dataLabelFormat_0.format_0;
		}
		set
		{
			dataLabelFormat_0.format_0 = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.Position property instead. Property will be removed after 01.09.2013.")]
	public LegendDataLabelPosition Position
	{
		get
		{
			return dataLabelFormat_0.Position;
		}
		set
		{
			dataLabelFormat_0.Position = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowLegendKey property instead. Property will be removed after 01.09.2013.")]
	public bool ShowLegendKey
	{
		get
		{
			return dataLabelFormat_0.ShowLegendKey;
		}
		set
		{
			dataLabelFormat_0.ShowLegendKey = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowLeaderLines property instead. Property will be removed after 01.09.2013.")]
	public bool ShowLeaderLines
	{
		get
		{
			return dataLabelFormat_0.ShowLeaderLines;
		}
		set
		{
			dataLabelFormat_0.ShowLeaderLines = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowCategoryName property instead. Property will be removed after 01.09.2013.")]
	public bool ShowCategoryName
	{
		get
		{
			return dataLabelFormat_0.ShowCategoryName;
		}
		set
		{
			dataLabelFormat_0.ShowCategoryName = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowValue property instead. Property will be removed after 01.09.2013.")]
	public bool ShowValue
	{
		get
		{
			return dataLabelFormat_0.ShowValue;
		}
		set
		{
			dataLabelFormat_0.ShowValue = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowPercentage property instead. Property will be removed after 01.09.2013.")]
	public bool ShowPercentage
	{
		get
		{
			return dataLabelFormat_0.ShowPercentage;
		}
		set
		{
			dataLabelFormat_0.ShowPercentage = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowSeriesName property instead. Property will be removed after 01.09.2013.")]
	public bool ShowSeriesName
	{
		get
		{
			return dataLabelFormat_0.ShowSeriesName;
		}
		set
		{
			dataLabelFormat_0.ShowSeriesName = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.ShowBubbleSize property instead. Property will be removed after 01.09.2013.")]
	public bool ShowBubbleSize
	{
		get
		{
			return dataLabelFormat_0.ShowBubbleSize;
		}
		set
		{
			dataLabelFormat_0.ShowBubbleSize = value;
		}
	}

	[Obsolete("Use DefaultDataLabelFormat.Separator property instead. Property will be removed after 01.09.2013.")]
	public string Separator
	{
		get
		{
			return dataLabelFormat_0.Separator;
		}
		set
		{
			dataLabelFormat_0.Separator = value;
		}
	}

	public int CountOfVisibleDataLabels
	{
		get
		{
			int num = 0;
			for (int i = 0; i < ParentSeries.DataPoints.Count; i++)
			{
				if (ParentSeries.DataPoints[i].Label.IsVisible)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int Count => ParentSeries.DataPoints.Count;

	public IDataLabelFormat DefaultDataLabelFormat => dataLabelFormat_0;

	public IChartSeries ParentSeries => chartSeries_0;

	public IDataLabel this[int index] => ParentSeries.DataPoints[index].Label;

	IChartComponent IDataLabelCollection.AsIChartComponent => this;

	IEnumerable IDataLabelCollection.AsIEnumerable => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide => ((ISlideComponent)chartSeries_0).Slide;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation => ((IPresentationComponent)chartSeries_0).Presentation;

	internal DataLabelCollection(ChartSeries parentSeries)
	{
		class321_0 = new Class321(parentSeries.Chart);
		chartSeries_0 = parentSeries;
		dataLabelFormat_0 = new DataLabelFormat(this);
	}

	public IEnumerator GetEnumerator()
	{
		return new Class15(ParentSeries.DataPoints);
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

	public int IndexOf(IDataLabel value)
	{
		int num = 0;
		while (true)
		{
			if (num < ParentSeries.DataPoints.Count)
			{
				if (this[num] == value)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}
}
