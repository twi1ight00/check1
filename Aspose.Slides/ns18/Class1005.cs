using System;
using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class1005
{
	public static void smethod_0(Class148 themeableFillFormat, Class2605 fillStyleElementData, Class1341 deserializationContext)
	{
		if (fillStyleElementData == null)
		{
			return;
		}
		if (fillStyleElementData.Name == "fill")
		{
			themeableFillFormat.Source = Enum273.const_1;
			Class1842 @class = (Class1842)fillStyleElementData.Object;
			Class949.smethod_0(themeableFillFormat.FillFormat, @class.FillProperties, deserializationContext);
			return;
		}
		if (!(fillStyleElementData.Name == "fillRef"))
		{
			throw new Exception();
		}
		themeableFillFormat.Source = Enum273.const_2;
		Class1929 class2 = (Class1929)fillStyleElementData.Object;
		Class930.smethod_1(themeableFillFormat.StyleColor, class2.Color);
		themeableFillFormat.FillStyleIndex = class2.Idx;
	}

	public static void smethod_1(Class148 themeableFillFormat, Class2605.Delegate2773 addFillStyle, Class1346 serializationContext)
	{
		switch (themeableFillFormat.Source)
		{
		case Enum273.const_1:
		{
			Class1842 class2 = (Class1842)addFillStyle("fill").Object;
			Class949.smethod_1(themeableFillFormat.FillFormat, class2.delegate2773_0, serializationContext);
			break;
		}
		case Enum273.const_2:
		{
			Class1929 @class = (Class1929)addFillStyle("fillRef").Object;
			Class930.smethod_4(themeableFillFormat.StyleColor, @class.delegate2773_0);
			@class.Idx = themeableFillFormat.FillStyleIndex;
			break;
		}
		case Enum273.const_0:
			break;
		}
	}
}
