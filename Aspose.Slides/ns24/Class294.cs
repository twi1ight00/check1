using Aspose.Slides;
using ns56;

namespace ns24;

internal class Class294 : Class278
{
	private BlackWhiteMode blackWhiteMode_0 = BlackWhiteMode.White;

	private Class2605 class2605_0;

	private Class1885 class1885_0;

	private bool bool_0;

	private IShape ishape_0;

	private uint uint_0;

	public BlackWhiteMode BwMode
	{
		get
		{
			return blackWhiteMode_0;
		}
		set
		{
			blackWhiteMode_0 = value;
		}
	}

	public Class2605 EffectProperties
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
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

	public bool ShadeToTitle
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

	public IShape ShadeToShape
	{
		get
		{
			return ishape_0;
		}
		set
		{
			ishape_0 = value;
		}
	}

	public uint Idx
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}
}
