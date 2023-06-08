using ns218;
using ns252;
using ns254;

namespace ns248;

internal class Class6273 : Interface265
{
	private Interface264 interface264_0;

	private Class5944 class5944_0;

	public Interface264 ColorBuilder
	{
		get
		{
			if (interface264_0 == null)
			{
				interface264_0 = new Class6271();
			}
			return interface264_0;
		}
		set
		{
			interface264_0 = value;
		}
	}

	public Interface281 imethod_0(Class5944 reader)
	{
		class5944_0 = reader;
		switch (reader.LocalName)
		{
		case "biLevel":
			return method_0();
		case "clrChange":
			return method_1();
		case "grayscl":
			return smethod_0();
		case "lum":
			return method_2();
		default:
			class5944_0.method_2();
			return null;
		}
	}

	private Class6343 method_0()
	{
		Class6343 @class = new Class6343();
		@class.Threshold = new Class6329(class5944_0.method_6("thresh", 0.0));
		return @class;
	}

	private Class6345 method_1()
	{
		Class6345 @class = new Class6345();
		@class.ConsiderAlphaValues = class5944_0.method_7("useA", defaultValue: true);
		string localName = class5944_0.LocalName;
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "clrTo":
				@class.ColorTo = ColorBuilder.imethod_0(class5944_0);
				break;
			case "clrFrom":
				@class.ColorFrom = ColorBuilder.imethod_0(class5944_0);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private static Class6347 smethod_0()
	{
		return new Class6347();
	}

	private Class6348 method_2()
	{
		Class6348 @class = new Class6348();
		@class.Brightness = new Class6329(class5944_0.method_6("bright", 0.0));
		@class.Contrast = new Class6329(class5944_0.method_6("contrast", 0.0));
		return @class;
	}
}
