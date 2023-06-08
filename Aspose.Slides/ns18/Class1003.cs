using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class1003
{
	public static void smethod_0(ITextStyle textStyle, Class1958 textListStyleElementData, Class1341 deserializationContext)
	{
		if (textListStyleElementData == null)
		{
			return;
		}
		Class971.smethod_0(textStyle.DefaultParagraphFormat, textListStyleElementData.DefPPr, deserializationContext);
		Class1963[] array = new Class1963[9] { textListStyleElementData.Lvl1pPr, textListStyleElementData.Lvl2pPr, textListStyleElementData.Lvl3pPr, textListStyleElementData.Lvl4pPr, textListStyleElementData.Lvl5pPr, textListStyleElementData.Lvl6pPr, textListStyleElementData.Lvl7pPr, textListStyleElementData.Lvl8pPr, textListStyleElementData.Lvl9pPr };
		for (int i = 0; i < 9; i++)
		{
			if (array[i] != null)
			{
				Class971.smethod_0(((TextStyle)textStyle).method_3(i), array[i], deserializationContext);
			}
		}
	}

	public static void smethod_1(ITextStyle textStyle, Class1958.Delegate1741 addTextListStyle, Class1346 serializationContext)
	{
		if (textStyle == null)
		{
			return;
		}
		Class1958 @class = addTextListStyle();
		Class971.smethod_2(textStyle.DefaultParagraphFormat, @class.delegate1756_0, serializationContext);
		Class1963.Delegate1756[] array = new Class1963.Delegate1756[9] { @class.delegate1756_1, @class.delegate1756_2, @class.delegate1756_3, @class.delegate1756_4, @class.delegate1756_5, @class.delegate1756_6, @class.delegate1756_7, @class.delegate1756_8, @class.delegate1756_9 };
		for (int i = 0; i <= 8; i++)
		{
			IParagraphFormat level = textStyle.GetLevel(i);
			if (level != null)
			{
				Class971.smethod_2(level, array[i], serializationContext);
			}
		}
	}
}
