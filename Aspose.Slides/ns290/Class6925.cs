using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using ns277;
using ns284;
using ns301;

namespace ns290;

internal class Class6925 : Interface344
{
	private const string string_0 = " ";

	private const string string_1 = "WordBox";

	private const string string_2 = "AnonimousBlock";

	private const string string_3 = "Table";

	private const string string_4 = "tr";

	private const string string_5 = "td";

	private Class6786 class6786_0;

	public Class6925(Class6786 renderContext)
	{
		class6786_0 = renderContext;
	}

	public Class6855 imethod_1(string word)
	{
		Class6892.smethod_1(word, "word");
		Class6855 @class;
		if (!word.Equals("\n") && !word.Equals("\r"))
		{
			if (!word.Equals("\t") && !word.Equals("\t"))
			{
				@class = new Class6855(null);
				@class.WordUndecoded = word;
				@class.Tag = "WordBox";
			}
			else
			{
				@class = imethod_5();
			}
		}
		else
		{
			@class = method_0(br: false);
		}
		if (word.Trim().Length == 0)
		{
			@class.WordUndecoded = " ";
			@class.IsSpaceBox = true;
		}
		return @class;
	}

	private Class6855 method_0(bool br)
	{
		Class6856 @class = imethod_4();
		@class.IsBr = br;
		return @class;
	}

	public Class6856 imethod_5()
	{
		Class6856 @class = new Class6856(null);
		@class.IsTab = true;
		@class.WordUndecoded = " ";
		return @class;
	}

	public Class6856 imethod_4()
	{
		Class6856 @class = new Class6856(null);
		@class.IsNewLine = true;
		@class.IsBr = true;
		@class.WordUndecoded = " ";
		return @class;
	}

	public Class6850 imethod_6(Class6845 containerBox)
	{
		Class6892.smethod_0(containerBox, "containerBox");
		Class6850 @class = new Class6850(containerBox);
		@class.Size = new SizeF(containerBox.InnerBound.Width, 20f);
		@class.Style = Class6960.smethod_1(containerBox.Style);
		return @class;
	}

	public Class6849 imethod_7(SizeF pageSize)
	{
		if (pageSize.Width < 50f || pageSize.Height < 50f)
		{
			throw new ArgumentOutOfRangeException("pageSize", "Specified size is too small for a page box");
		}
		Class6849 @class = new Class6849(null);
		@class.Size = pageSize;
		return @class;
	}

	public Class6852 imethod_8()
	{
		Class6852 @class = new Class6852(null);
		@class.Style.Display = Enum952.const_5;
		@class.Tag = "Table";
		return @class;
	}

	public Class6854 imethod_9()
	{
		Class6854 @class = new Class6854(null);
		@class.Style.Display = Enum952.const_10;
		@class.Tag = "tr";
		return @class;
	}

	public Class6853 imethod_10()
	{
		Class6853 @class = new Class6853(null);
		@class.Style.Display = Enum952.const_13;
		@class.Tag = "td";
		return @class;
	}

	public Class6845 imethod_2(Interface329 style, string name)
	{
		name = name.ToUpper();
		Class6845 @class;
		switch (style.Display)
		{
		case Enum952.const_13:
			@class = imethod_10();
			break;
		case Enum952.const_2:
			@class = imethod_12(style);
			break;
		case Enum952.const_4:
			@class = imethod_13();
			break;
		case Enum952.const_5:
		case Enum952.const_6:
			@class = imethod_8();
			break;
		default:
			@class = ((style.Position != Enum956.const_1) ? new Class6845(null) : new Class6849(null));
			break;
		case Enum952.const_10:
			@class = imethod_9();
			break;
		}
		@class.Style = style;
		@class.Tag = name;
		if (name.Equals("IMG"))
		{
			smethod_0(@class, class6786_0);
		}
		return @class;
	}

	private static void smethod_0(Class6845 box, Class6786 renderContext)
	{
		if (Class6973.smethod_0(box.Style.BackgroundImage))
		{
			return;
		}
		try
		{
			Class6814 @class = renderContext.ResourceLoadingCallback.imethod_0(renderContext, new EventArgs13(box.Style.BackgroundImage));
			using MemoryStream stream = new MemoryStream(@class.Data);
			Image image = Image.FromStream(stream);
			if (box.Style.Width.IsAuto)
			{
				box.Style.Width = new Class6959(image.Width, Enum955.const_4);
			}
			if (box.Style.Height.IsAuto)
			{
				box.Style.Height = new Class6959(image.Height, Enum955.const_4);
			}
		}
		catch (Exception)
		{
		}
	}

	public Class6846 imethod_13()
	{
		Class6846 @class = new Class6846(null);
		@class.Style.Display = Enum952.const_4;
		return @class;
	}

	public Class6851 imethod_12(Interface329 style)
	{
		Class6851 @class = new Class6851(null);
		if (style != null)
		{
			Class6960.smethod_0(@class.ContentBox.Style, style);
		}
		Class6845 class2 = new Class6845(@class);
		Class6855 class3 = new Class6855(class2);
		if (style != null)
		{
			Class6960.smethod_0(class3.Style, style);
		}
		class2.InnerBoxes.Add(class3);
		@class.Marker = class3;
		switch (style.ListStylePosition)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The style.ListStylePosition is out of range: {0}", new object[1] { style.ListStylePosition }));
		case Enum938.const_0:
			class2.Style.Display = Enum952.const_1;
			if (style.Direction == Enum936.const_1)
			{
				@class.InnerBoxes.Add(class2);
			}
			else
			{
				@class.InnerBoxes.Insert(0, class2);
			}
			break;
		case Enum938.const_1:
			class2.Style.Display = Enum952.const_0;
			class2.Style.MarginRight = @class.Style.PaddingLeft;
			@class.ContentBox.InnerBoxes.Insert(0, class2);
			break;
		}
		@class.Style.Display = Enum952.const_2;
		return @class;
	}

	public Class6851 imethod_11()
	{
		return imethod_12(null);
	}

	public Class6848 imethod_3()
	{
		Class6848 @class = new Class6848(null);
		@class.Style.Display = Enum952.const_1;
		@class.Tag = "AnonimousBlock";
		return @class;
	}

	public Class6849 imethod_0(Interface329 style, string name)
	{
		Class6849 @class = new Class6849(null);
		@class.Style = style;
		@class.Tag = name;
		return @class;
	}
}
