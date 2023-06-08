using Aspose.Slides.Charts;

namespace ns25;

internal class Class316 : Class312
{
	private IFormat iformat_0;

	public IFormat Format
	{
		get
		{
			return iformat_0;
		}
		set
		{
			iformat_0 = value;
		}
	}

	public Class316(IChart parent)
		: base(parent)
	{
		iformat_0 = new Format(parent);
	}
}
