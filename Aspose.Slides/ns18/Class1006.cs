using System;
using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class1006
{
	public static void smethod_0(Class149 lineFormat, Class1973 lineStyleElementData)
	{
		if (lineStyleElementData == null)
		{
			return;
		}
		lineFormat.LineIndex = 0u;
		lineFormat.Source = Enum275.const_0;
		if (lineStyleElementData.ThemeableLineStyle != null)
		{
			switch (lineStyleElementData.ThemeableLineStyle.Name)
			{
			case "lnRef":
			{
				Class1929 @class = (Class1929)lineStyleElementData.ThemeableLineStyle.Object;
				lineFormat.Source = Enum275.const_2;
				Class930.smethod_1(lineFormat.StyleColor, @class.Color);
				lineFormat.LineIndex = @class.Idx;
				break;
			}
			case "ln":
			{
				Class1875 linePropertiesElementData = (Class1875)lineStyleElementData.ThemeableLineStyle.Object;
				lineFormat.Source = Enum275.const_1;
				Class968.smethod_0(lineFormat.LineFormat, linePropertiesElementData);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + lineStyleElementData.ThemeableLineStyle.Name + "\"");
			}
		}
	}

	public static void smethod_1(Class149 lineFormat, Class1973.Delegate1786 addLineStyle)
	{
		if (lineFormat.Source != 0)
		{
			Class1973 @class = addLineStyle();
			switch (lineFormat.Source)
			{
			case Enum275.const_1:
			{
				Class1875 linePropertiesElementData = (Class1875)@class.delegate2773_0("ln").Object;
				Class968.smethod_3(lineFormat.LineFormat, linePropertiesElementData);
				break;
			}
			case Enum275.const_2:
			{
				Class1929 class2 = (Class1929)@class.delegate2773_0("lnRef").Object;
				Class930.smethod_4(lineFormat.StyleColor, class2.delegate2773_0);
				class2.Idx = lineFormat.LineIndex;
				break;
			}
			}
		}
	}
}
