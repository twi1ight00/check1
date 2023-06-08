using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class998
{
	public static void smethod_0(Class143 tablePartStyle, Class1941 tcStyleElementData, Class1341 deserializationContext)
	{
		if (tcStyleElementData != null)
		{
			if (tcStyleElementData.TcBdr != null)
			{
				Class1933 tcBdr = tcStyleElementData.TcBdr;
				Class1006.smethod_0(tablePartStyle.LeftBorder, tcBdr.Left);
				Class1006.smethod_0(tablePartStyle.RightBorder, tcBdr.Right);
				Class1006.smethod_0(tablePartStyle.TopBorder, tcBdr.Top);
				Class1006.smethod_0(tablePartStyle.BottomBorder, tcBdr.Bottom);
				Class1006.smethod_0(tablePartStyle.InsideHorizontalBorder, tcBdr.InsideH);
				Class1006.smethod_0(tablePartStyle.InsideVerticalBorder, tcBdr.InsideV);
				Class1006.smethod_0(tablePartStyle.TopLeftToBottomRightBorder, tcBdr.Tl2br);
				Class1006.smethod_0(tablePartStyle.TopRightToBottomLeftBorder, tcBdr.Tr2bl);
				tablePartStyle.PPTXUnsupportedProps.ExtensionList = tcBdr.ExtLst;
			}
			Class1005.smethod_0(tablePartStyle.FillFormat, tcStyleElementData.ThemeableFillStyle, deserializationContext);
			tablePartStyle.PPTXUnsupportedProps.Cell3D = tcStyleElementData.Cell3D;
		}
	}

	public static void smethod_1(Class143 tablePartStyle, Class1941.Delegate1690 addTcStyle, Class1346 serializationContext)
	{
		if (tablePartStyle.NeedElement)
		{
			Class1941 @class = addTcStyle();
			if (tablePartStyle.LeftBorder.Source != 0 || tablePartStyle.RightBorder.Source != 0 || tablePartStyle.TopBorder.Source != 0 || tablePartStyle.BottomBorder.Source != 0 || tablePartStyle.InsideHorizontalBorder.Source != 0 || tablePartStyle.InsideVerticalBorder.Source != 0 || tablePartStyle.TopLeftToBottomRightBorder.Source != 0 || tablePartStyle.TopRightToBottomLeftBorder.Source != 0 || tablePartStyle.PPTXUnsupportedProps.ExtensionList != null)
			{
				Class1933 class2 = @class.delegate1666_0();
				Class1006.smethod_1(tablePartStyle.LeftBorder, class2.delegate1786_0);
				Class1006.smethod_1(tablePartStyle.RightBorder, class2.delegate1786_1);
				Class1006.smethod_1(tablePartStyle.TopBorder, class2.delegate1786_2);
				Class1006.smethod_1(tablePartStyle.BottomBorder, class2.delegate1786_3);
				Class1006.smethod_1(tablePartStyle.InsideHorizontalBorder, class2.delegate1786_4);
				Class1006.smethod_1(tablePartStyle.InsideVerticalBorder, class2.delegate1786_5);
				Class1006.smethod_1(tablePartStyle.TopLeftToBottomRightBorder, class2.delegate1786_6);
				Class1006.smethod_1(tablePartStyle.TopRightToBottomLeftBorder, class2.delegate1786_7);
				class2.delegate1535_0(tablePartStyle.PPTXUnsupportedProps.ExtensionList);
			}
			Class1005.smethod_1(tablePartStyle.FillFormat, @class.delegate2773_0, serializationContext);
			@class.delegate304_0(tablePartStyle.PPTXUnsupportedProps.Cell3D);
		}
	}
}
