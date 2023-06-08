using System;
using Aspose.Slides;
using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class997
{
	public static void smethod_0(Class142 cellTextStyle, Class1943 tableStyleTextStyleElementData)
	{
		if (tableStyleTextStyleElementData == null)
		{
			return;
		}
		Class2605 themeableFontStyles = tableStyleTextStyleElementData.ThemeableFontStyles;
		if (themeableFontStyles == null)
		{
			cellTextStyle.FontSource = Enum274.const_0;
		}
		else
		{
			switch (themeableFontStyles.Name)
			{
			case "fontRef":
			{
				Class1846 @class = (Class1846)themeableFontStyles.Object;
				cellTextStyle.FontSource = Enum274.const_2;
				Class930.smethod_1(cellTextStyle.FontColor, @class.Color);
				cellTextStyle.FontIndex = @class.Idx;
				break;
			}
			case "font":
			{
				Class1845 fontCollectionElementData = (Class1845)themeableFontStyles.Object;
				cellTextStyle.FontSource = Enum274.const_1;
				Class952.smethod_0(cellTextStyle.Fonts, fontCollectionElementData);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + themeableFontStyles.Name + "\"");
			}
		}
		Class930.smethod_1(cellTextStyle.SchemeColor, tableStyleTextStyleElementData.Color);
		cellTextStyle.IsBold = (NullableBool)tableStyleTextStyleElementData.B;
		cellTextStyle.IsItalic = (NullableBool)tableStyleTextStyleElementData.I;
		cellTextStyle.PPTXUnsupportedProps.ExtensionList = tableStyleTextStyleElementData.ExtLst;
	}

	public static void smethod_1(Class142 cellTextStyle, Class1943.Delegate1696 addTcTxStyle)
	{
		if (cellTextStyle.NeedElement)
		{
			Class1943 @class = addTcTxStyle();
			switch (cellTextStyle.FontSource)
			{
			case Enum274.const_1:
			{
				Class1845 fontCollectionElementData = (Class1845)@class.delegate2773_1("font").Object;
				Class952.smethod_2(cellTextStyle.Fonts, fontCollectionElementData);
				break;
			}
			case Enum274.const_2:
			{
				Class1846 class2 = (Class1846)@class.delegate2773_1("fontRef").Object;
				Class930.smethod_4(cellTextStyle.FontColor, class2.delegate2773_0);
				class2.Idx = cellTextStyle.FontIndex;
				break;
			}
			}
			Class930.smethod_4(cellTextStyle.SchemeColor, @class.delegate2773_0);
			@class.B = (Enum307)cellTextStyle.IsBold;
			@class.I = (Enum307)cellTextStyle.IsItalic;
			@class.delegate1535_0(cellTextStyle.PPTXUnsupportedProps.ExtensionList);
		}
	}
}
