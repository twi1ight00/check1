using System.IO;
using ns101;
using ns102;
using ns99;

namespace ns119;

internal class Class4490
{
	internal Enum639 enum639_0;

	internal Class4492[] class4492_0;

	internal Class4519 class4519_0;

	internal Class4519 class4519_1;

	internal string string_0;

	internal string string_1;

	public virtual string FontName => string_0;

	public virtual Class4519 FontNames => class4519_0;

	public virtual string PostscriptName => string_1;

	public Class4519 PostscriptNames => class4519_1;

	public Enum639 FontType => enum639_0;

	public Class4492[] FileDefinitions => class4492_0;

	public static Class4490 smethod_0(string fileName, Enum639 fontType)
	{
		switch (fontType)
		{
		default:
		{
			Class4487 fontStreamSource2 = new Class4489(fileName);
			Class4683 class2 = new Class4683();
			return class2.imethod_0(fontStreamSource2);
		}
		case Enum639.const_1:
		{
			Class4487 fontStreamSource = new Class4489(fileName);
			Class4693 @class = new Class4693();
			return @class.imethod_0(fontStreamSource);
		}
		case Enum639.const_2:
			return new Class4490(fontType, new Class4492(new FileInfo(fileName)));
		}
	}

	public static Class4490 smethod_1(Class4487 source, Enum639 fontType)
	{
		switch (fontType)
		{
		default:
		{
			Class4683 class2 = new Class4683();
			return class2.imethod_0(source);
		}
		case Enum639.const_1:
		{
			Class4693 @class = new Class4693();
			return @class.imethod_0(source);
		}
		case Enum639.const_2:
			return new Class4490(fontType, source);
		}
	}

	internal Class4490()
	{
	}

	public Class4490(Enum639 fontType, string fileExtension, Class4487 streamSource)
		: this(fontType, new Class4492(fileExtension, streamSource))
	{
	}

	public Class4490(Enum639 fontType, Class4487 streamSource)
		: this(fontType, new Class4492(streamSource))
	{
	}

	public Class4490(string fontName, Enum639 fontType, string fileExtension, Class4487 streamSource)
		: this(fontName, fontType, new Class4492(fileExtension, streamSource))
	{
	}

	public Class4490(Enum639 fontType, Class4492 fileDefinition)
		: this(fontType, new Class4492[1] { fileDefinition })
	{
	}

	public Class4490(string fontName, Enum639 fontType, Class4492 fileDefinition)
		: this(fontName, fontName, fontType, new Class4492[1] { fileDefinition })
	{
	}

	public Class4490(string fontName, string postscriptName, Enum639 fontType, Class4492 fileDefinition)
		: this(fontName, postscriptName, fontType, new Class4492[1] { fileDefinition })
	{
	}

	public Class4490(Enum639 fontType, Class4492[] fileDefinitions)
		: this(string.Empty, string.Empty, fontType, fileDefinitions)
	{
	}

	public Class4490(string fontName, string postscriptName, Enum639 fontType, Class4492[] fileDefinitions)
	{
		class4519_0 = new Class4519(fontName);
		string_0 = fontName;
		class4519_1 = new Class4519(postscriptName);
		string_1 = postscriptName;
		enum639_0 = fontType;
		class4492_0 = fileDefinitions;
	}

	public Class4490(Class4519 fontNames, Class4519 postscriptNames, Enum639 fontType, Class4492 fileDefinition)
		: this(fontNames, postscriptNames, fontType, new Class4492[1] { fileDefinition })
	{
	}

	public Class4490(Class4519 fontNames, Class4519 postscriptNames, Enum639 fontType, Class4492[] fileDefinitions)
	{
		class4519_0 = fontNames;
		class4519_1 = postscriptNames;
		string_0 = fontNames.method_3();
		string_1 = postscriptNames.method_3();
		enum639_0 = fontType;
		class4492_0 = fileDefinitions;
	}
}
