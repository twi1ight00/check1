using Aspose.Slides.Charts;
using ns24;
using ns56;

namespace ns25;

internal class Class321 : Class278
{
	private Class1885 class1885_0;

	private IFormat iformat_0;

	public IFormat LeaderLinesFormat => iformat_0;

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public Class321(IChart parentChart)
	{
		iformat_0 = new Format(parentChart);
	}
}
