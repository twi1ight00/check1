using Aspose.Slides.Charts;
using ns56;

namespace ns25;

internal class Class313 : Class312
{
	private bool bool_0 = true;

	private Class1885 class1885_0;

	public bool LayoutByOutside
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

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

	public Class313(IChart parent)
		: base(parent)
	{
	}
}
