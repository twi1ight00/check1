using Aspose.Slides.Charts;

namespace ns2;

internal class Class17
{
	private IFormattedTextContainer iformattedTextContainer_0;

	private ChartTextFormat chartTextFormat_0;

	internal ChartTextFormat TextFormatOfAutoText
	{
		get
		{
			if (chartTextFormat_0 == null)
			{
				chartTextFormat_0 = new ChartTextFormat(iformattedTextContainer_0, this);
			}
			return chartTextFormat_0;
		}
	}

	internal Class17 TextFormatManagerInherited
	{
		get
		{
			if (iformattedTextContainer_0 is Chart)
			{
				return null;
			}
			if (iformattedTextContainer_0 != null)
			{
				IChartComponent chartComponent = iformattedTextContainer_0;
				if (!(iformattedTextContainer_0 is Legend) && !(iformattedTextContainer_0 is DataTable) && !(iformattedTextContainer_0 is Axis) && !(iformattedTextContainer_0 is ChartTitle))
				{
					if (iformattedTextContainer_0 is LegendEntryProperties)
					{
						return ((Legend)chartComponent.Chart.Legend).TextFormatManager;
					}
					if (iformattedTextContainer_0 is DataLabelFormat)
					{
						DataLabelFormat dataLabelFormat = (DataLabelFormat)iformattedTextContainer_0;
						if (dataLabelFormat.Parent is DataLabelCollection)
						{
							return ((Chart)dataLabelFormat.Parent.Chart).TextFormatManager;
						}
						if (dataLabelFormat.Parent is DataLabel)
						{
							DataLabel dataLabel = (DataLabel)dataLabelFormat.Parent;
							return ((DataLabelFormat)dataLabel.ParentSeries.Labels.DefaultDataLabelFormat).TextFormatManager;
						}
						return null;
					}
					if (iformattedTextContainer_0 is DataLabel)
					{
						DataLabel dataLabel2 = (DataLabel)iformattedTextContainer_0;
						return ((DataLabelFormat)dataLabel2.ParentSeries.Labels.DefaultDataLabelFormat).TextFormatManager;
					}
					return null;
				}
				return ((Chart)chartComponent.Chart).TextFormatManager;
			}
			return null;
		}
	}

	internal Class17(IFormattedTextContainer parent)
	{
		iformattedTextContainer_0 = parent;
	}
}
