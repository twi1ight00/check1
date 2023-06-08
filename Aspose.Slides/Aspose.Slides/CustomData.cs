using ns22;
using ns24;

namespace Aspose.Slides;

public class CustomData : ICustomData
{
	private TagCollection tagCollection_0 = new TagCollection();

	private Class336 class336_0 = new Class336();

	private Class271 class271_0 = new Class271();

	public ITagCollection Tags => tagCollection_0;

	internal Class336 PPTXUnsupportedProps => class336_0;

	internal Class271 PPTUnsupportedProps => class271_0;

	internal CustomData()
	{
	}
}
