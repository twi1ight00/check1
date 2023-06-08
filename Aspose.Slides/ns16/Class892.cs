using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns56;

namespace ns16;

internal class Class892
{
	private Class1030 class1030_0;

	private SortedList<uint, IChartSeries> sortedList_0;

	private Class2106 class2106_0;

	public Class1030 SlideDeserializationContext => class1030_0;

	public SortedList<uint, IChartSeries> SeriesXmlIdxToSeries
	{
		get
		{
			return sortedList_0;
		}
		set
		{
			sortedList_0 = value;
		}
	}

	public Class2106 PlotAreaElementData
	{
		get
		{
			return class2106_0;
		}
		set
		{
			class2106_0 = value;
		}
	}

	public Class892(Class1030 slideDeserializationContext)
	{
		class1030_0 = slideDeserializationContext;
		sortedList_0 = new SortedList<uint, IChartSeries>();
	}
}
