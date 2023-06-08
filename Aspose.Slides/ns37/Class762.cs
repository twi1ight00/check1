using System.Collections;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class762 : CollectionBase, Interface22
{
	private Class759 class759_0;

	private Class740 class740_0;

	internal Class740 Chart => class740_0;

	public Class759 ASeriesInternal => class759_0;

	public Interface21 ASeries => class759_0;

	public Interface23 this[int index] => (Class763)base.InnerList[index];

	internal Class762(Class740 chart, Class759 aSeries)
	{
		class740_0 = chart;
		class759_0 = aSeries;
	}

	internal Class763 method_0(int index)
	{
		return (Class763)base.InnerList[index];
	}

	public int Add(TrendlineType type)
	{
		Class763 @class = new Class763(class740_0, this);
		@class.Type = type;
		return base.InnerList.Add(@class);
	}

	public int Add(TrendlineType type, string name)
	{
		Class763 @class = new Class763(class740_0, this);
		@class.Type = type;
		@class.Name = name;
		return base.InnerList.Add(@class);
	}
}
