using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns290;

internal class Class6941 : Interface350
{
	private bool bool_0;

	public bool imethod_0(Class6855 word, Class6845 container)
	{
		Class6892.smethod_0(word, "word");
		Class6892.smethod_0(container, "container");
		if (!word.IsSpaceBox)
		{
			bool_0 = true;
			return false;
		}
		Enum959 @enum = smethod_2(container);
		bool result;
		switch (@enum)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The whiteSpaceType is out of range: {0}", new object[1] { @enum }));
		case Enum959.const_2:
			result = method_0(word, container);
			break;
		case Enum959.const_1:
		case Enum959.const_3:
			result = false;
			break;
		case Enum959.const_0:
		case Enum959.const_4:
			result = method_1(word, container);
			break;
		}
		bool_0 = false;
		return result;
	}

	private bool method_0(Class6855 word, Class6845 container)
	{
		if (bool_0)
		{
			smethod_0(word);
			return false;
		}
		if (container.InnerBoxes.Count == 0)
		{
			return true;
		}
		if (word is Class6856 @class && @class.IsNewLine)
		{
			return false;
		}
		Class6844 class2 = smethod_1(container);
		Class6855 class3 = class2 as Class6855;
		if (bool_0 && (class3 == null || !class3.IsSpaceBox))
		{
			smethod_0(word);
			return false;
		}
		return true;
	}

	private bool method_1(Class6855 word, Class6845 container)
	{
		if (bool_0)
		{
			smethod_0(word);
			return false;
		}
		if (container.InnerBoxes.Count == 0)
		{
			return true;
		}
		Class6844 @class = smethod_1(container);
		Class6855 class2 = @class as Class6855;
		if (bool_0 && (class2 == null || !class2.IsSpaceBox))
		{
			smethod_0(word);
			return false;
		}
		return true;
	}

	private static void smethod_0(Class6855 whitespace)
	{
		if (whitespace is Class6856 @class)
		{
			@class.IsNewLine = false;
			@class.IsTab = false;
		}
	}

	private static Class6844 smethod_1(Class6845 container)
	{
		return container.InnerBoxes[container.InnerBoxes.Count - 1];
	}

	private static Enum959 smethod_2(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		Enum959 @enum = container.Style.WhiteSpace;
		if (@enum == Enum959.const_5)
		{
			Class6845 @class = container;
			while (@class.Parent != null && @class.Style.WhiteSpace == Enum959.const_5 && @class.Parent is Class6845)
			{
				@class = @class.Parent as Class6845;
			}
			@enum = ((@class.Style.WhiteSpace != Enum959.const_5) ? @class.Style.WhiteSpace : Enum959.const_0);
		}
		return @enum;
	}
}
