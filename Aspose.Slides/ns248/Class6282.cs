using ns219;
using ns250;
using ns261;

namespace ns248;

internal class Class6282 : Interface271
{
	private Interface264 interface264_0;

	private Class5945 class5945_0;

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

	public Class6420 imethod_0(Class5945 reader)
	{
		class5945_0 = reader;
		if (class5945_0.LocalName != "style")
		{
			return null;
		}
		Class6420 @class = new Class6420();
		while (class5945_0.method_0("style"))
		{
			switch (class5945_0.LocalName)
			{
			case "lnRef":
				@class.LineReference = method_0();
				break;
			case "fontRef":
				@class.FontReference = method_1();
				break;
			case "fillRef":
				@class.FillReference = method_2();
				break;
			case "effectRef":
				@class.EffectReference = method_3();
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
		return @class;
	}

	private Class6419 method_0()
	{
		Class6419 @class = new Class6419();
		@class.StyleMatrixIndex = class5945_0.method_5("idx", 0);
		method_4(@class);
		return @class;
	}

	private Class6418 method_1()
	{
		Class6418 @class = new Class6418();
		switch (class5945_0.method_4("idx", string.Empty))
		{
		case "none":
			@class.FontCollectionIndex = Enum817.const_2;
			break;
		case "minor":
			@class.FontCollectionIndex = Enum817.const_1;
			break;
		case "major":
			@class.FontCollectionIndex = Enum817.const_0;
			break;
		}
		method_4(@class);
		return @class;
	}

	private Class6417 method_2()
	{
		Class6417 @class = new Class6417();
		@class.StyleMatrixIndex = class5945_0.method_5("idx", 0);
		method_4(@class);
		return @class;
	}

	private Class6416 method_3()
	{
		Class6416 @class = new Class6416();
		@class.StyleMatrixIndex = class5945_0.method_5("idx", 0);
		method_4(@class);
		return @class;
	}

	private void method_4(Class6415 reference)
	{
		string localName = class5945_0.LocalName;
		while (class5945_0.method_0(localName))
		{
			Interface274 @interface = ColorBuilder.imethod_1(class5945_0);
			if (@interface != null)
			{
				reference.Color = @interface;
			}
		}
	}
}
