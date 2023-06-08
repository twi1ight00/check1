using Aspose.Slides;
using ns56;

namespace ns24;

internal class Class300 : Class296
{
	public delegate ILayoutSlide Delegate13(SlideLayoutType layoutType);

	public Delegate13 delegate13_0;

	private Class1885 class1885_3;

	private Class1885 class1885_4;

	private Class494 class494_0 = new Class494();

	public Class494 HeaderFooter => class494_0;

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_3;
		}
		set
		{
			class1885_3 = value;
		}
	}

	public Class1885 ExtensionListOfStyles
	{
		get
		{
			return class1885_4;
		}
		set
		{
			class1885_4 = value;
		}
	}
}
