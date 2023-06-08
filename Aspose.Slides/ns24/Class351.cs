using Aspose.Slides.SlideShow;
using ns56;

namespace ns24;

internal class Class351 : Class278
{
	private readonly SlideShowTransition slideShowTransition_0;

	private string string_0;

	private Class1885 class1885_0;

	public string Duration
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
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

	public void method_0()
	{
		class1885_0 = null;
	}

	public Class351(SlideShowTransition parent)
	{
		slideShowTransition_0 = parent;
	}

	internal bool Equals(Class351 unsupportedProps)
	{
		if (unsupportedProps == null)
		{
			return false;
		}
		if ((class1885_0 == null) ^ (unsupportedProps.class1885_0 == null))
		{
			return false;
		}
		if (string_0 == unsupportedProps.string_0)
		{
			if (class1885_0 != null)
			{
				return class1885_0.ExtList.Equals(unsupportedProps.class1885_0.ExtList);
			}
			return true;
		}
		return false;
	}
}
